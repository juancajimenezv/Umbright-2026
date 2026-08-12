Option Strict Off
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

''' <summary>
''' Orquesta una sesión de chat de generación masiva de requisiciones:
''' arma el system prompt (reglas de negocio + catálogos reales), llama a AnthropicClient,
''' corre RequisicionValidator + validación de catálogo sobre cada requisición devuelta,
''' y mantiene el estado del lote para que la UI solo tenga que pintar `Lote` y llamar
''' `EnviarMensaje` / `GuardarLoteValido`.
''' </summary>
Public Class RequisicionChatOrchestrator

    Private ReadOnly _empresa As String
    Private ReadOnly _usuario As String
    Private ReadOnly _correlativoLote As String
    Private ReadOnly _validator As New RequisicionValidator()
    Private ReadOnly _catalogo As RequisicionCatalogContext
    Private ReadOnly _cliente As AnthropicClient
    Private ReadOnly _persistencia As New RequisicionPersistenceService()
    Private ReadOnly _historial As New List(Of AnthropicClient.TurnoChat)

    Public Property Lote As New List(Of RequisicionBatchItem)

    Public Sub New(empresa As String, usuario As String)
        _empresa = empresa
        _usuario = usuario
        _correlativoLote = Guid.NewGuid().ToString()
        _catalogo = New RequisicionCatalogContext(empresa)
        _cliente = New AnthropicClient(empresa, usuario, _correlativoLote)
    End Sub

    ''' <summary>
    ''' Envía un mensaje del usuario (generación inicial o corrección), actualiza `Lote`
    ''' con el resultado validado, y devuelve el texto de respuesta del asistente para
    ''' mostrarlo en el historial del chat.
    ''' </summary>
    Public Function EnviarMensaje(mensajeUsuario As String) As String
        _historial.Add(New AnthropicClient.TurnoChat With {.Rol = "user", .Texto = mensajeUsuario})

        Dim accion As String = If(Lote.Count = 0, "GENERAR_BORRADOR", "CORRECCION")
        Dim resultado = _cliente.GenerarBorrador(ConstruirSystemPrompt(), _historial, accion)

        If Not resultado.Exitoso Then
            _historial.RemoveAt(_historial.Count - 1) ' no dejamos un turno de usuario sin respuesta en el historial
            Throw New ApplicationException(resultado.MensajeError)
        End If

        Lote = ProcesarLote(resultado.Requisiciones)

        ' El modelo debería siempre llenar 'resumen' (es un campo requerido del schema), pero
        ' si por lo que sea viene vacío, el usuario nunca debe ver un turno de chat en blanco —
        ' se arma un resumen de respaldo a partir del lote ya procesado.
        Dim resumen As String = resultado.Resumen
        If String.IsNullOrWhiteSpace(resumen) Then
            resumen = ConstruirResumenFallback()
        End If

        _historial.Add(New AnthropicClient.TurnoChat With {.Rol = "assistant", .Texto = resumen})
        Return resumen
    End Function

    Private Function ConstruirResumenFallback() As String
        If Lote.Count = 0 Then
            Return "No pude generar ninguna requisición a partir de ese mensaje. Intenta ser más específico: proveedor (opcional), productos, centro de costo, marca, canal, item de gasto, moneda."
        End If
        Return ResumenConteo()
    End Function

    ''' <summary>Guarda todas las requisiciones del lote que estén en estado Válido.</summary>
    Public Function GuardarLoteValido() As List(Of RequisicionPersistenceService.ResultadoGuardado)
        Dim resultados As New List(Of RequisicionPersistenceService.ResultadoGuardado)

        ' Se congela la lista de candidatas ANTES de revalidar, porque RevalidarItem puede
        ' cambiar el Estado del propio ítem que se está evaluando.
        For Each item In Lote.Where(Function(i) i.Estado = EstadoBorradorRequisicion.Valido).ToList()

            ' Última verificación justo antes de insertar: los catálogos (proveedor, CC,
            ' marca, canal, gasto, producto) pudieron cambiar desde la última validación,
            ' o la requisición pudo editarse a mano sin volver a pasar por el chat.
            RevalidarItem(item)
            If item.Estado <> EstadoBorradorRequisicion.Valido Then
                Dim rNoValido As New RequisicionPersistenceService.ResultadoGuardado
                rNoValido.Errores.Add("No se guardó: dejó de ser válida al revalidar justo antes de guardar. " &
                    String.Join("; ", item.Errores.Concat(item.PreguntasAclaracion)))
                resultados.Add(rNoValido)
                Continue For
            End If

            Dim r = _persistencia.GuardarRequisicion(item.Cabecera, _empresa, _usuario)
            If r.Exitoso Then
                item.NumeroRequisicionGuardada = r.Numero
            Else
                item.Errores.AddRange(r.Errores)
                item.Estado = EstadoBorradorRequisicion.ConErrores
            End If
            resultados.Add(r)
        Next
        Return resultados
    End Function

    ''' <summary>Texto corto tipo "3 listas / 1 con errores / 1 pendiente de aclaración" para el contador de la UI.</summary>
    Public Function ResumenConteo() As String
        Dim validas = Lote.Where(Function(i) i.Estado = EstadoBorradorRequisicion.Valido).Count()
        Dim conErrores = Lote.Where(Function(i) i.Estado = EstadoBorradorRequisicion.ConErrores).Count()
        Dim pendientes = Lote.Where(Function(i) i.Estado = EstadoBorradorRequisicion.PendienteAclaracion).Count()
        Return $"{Lote.Count} requisiciones — {validas} listas, {conErrores} con errores, {pendientes} pendientes de aclaración"
    End Function

    ''' <summary>
    ''' Re-valida un ítem del lote ya existente (usado por la pantalla de edición manual
    ''' después de que el usuario corrige una requisición a mano). Actualiza el ítem in-place
    ''' con las mismas reglas que se aplican a lo generado por el chat.
    ''' </summary>
    Public Sub RevalidarItem(item As RequisicionBatchItem)
        Dim resultado = ValidarItem(item.Cabecera)
        item.Errores = resultado.Errores
        item.PreguntasAclaracion = resultado.Preguntas
        item.Estado = resultado.Estado
    End Sub

    ' ------------------------------------------------------------------
    ' Validación del lote devuelto por el modelo
    ' ------------------------------------------------------------------

    Private Function ProcesarLote(requisiciones As List(Of RequisicionCabeceraDraft)) As List(Of RequisicionBatchItem)
        Dim nuevoLote As New List(Of RequisicionBatchItem)

        Dim contador As Integer = 0
        For Each cab In requisiciones
            contador += 1
            Dim item As New RequisicionBatchItem With {.Id = "R" & contador, .Cabecera = cab}
            Dim resultado = ValidarItem(cab)
            item.Errores = resultado.Errores
            item.PreguntasAclaracion = resultado.Preguntas
            item.Estado = resultado.Estado
            nuevoLote.Add(item)
        Next

        Return nuevoLote
    End Function

    ''' <summary>
    ''' Valida UNA requisición completa: reglas de negocio (100%, obligatoriedad, ITEM/A&P,
    ''' idénticas al flujo manual) + existencia real de proveedor y de cada código propuesto
    ''' contra catálogo. Nunca se hace match automático por nombre: si un código no coincide
    ''' exacto, se generan preguntas de aclaración en vez de adivinar. Se usa tanto desde el
    ''' lote generado por el chat (ProcesarLote) como desde la edición manual (RevalidarItem).
    ''' </summary>
    Private Function ValidarItem(cab As RequisicionCabeceraDraft) As (Errores As List(Of String), Preguntas As List(Of String), Estado As EstadoBorradorRequisicion)
        Dim preguntas As New List(Of String)

        Dim catCC = _catalogo.ObtenerCatalogo("CON_CCOSTO")
        Dim catMarca = _catalogo.ObtenerCatalogo("CON_MARCA")
        Dim catItem = _catalogo.ObtenerCatalogo("CON_ITEM")
        Dim catAyP = _catalogo.ObtenerCatalogo("CON_A&P")
        Dim catCanal = _catalogo.ObtenerCatalogoCanal()

        ' "bu" (unidad de negocio) es un ATRIBUTO del código de marca en el catálogo
        ' (gen_tabcod.texto4), nunca algo que el modelo o el usuario deban indicar — se
        ' auto-completa aquí ANTES de validar, para que la regla de "unidades de negocio
        ' deben corresponder a los centros de costo" (RequisicionValidator.ValidarDistribucion)
        ' funcione con datos reales en vez de quedar siempre vacía.
        For Each marca In cab.Marcas
            Dim entradaCatalogo = catMarca.FirstOrDefault(Function(c) String.Equals(c.Codigo, marca.Codigo, StringComparison.OrdinalIgnoreCase))
            If entradaCatalogo IsNot Nothing Then marca.Bu = entradaCatalogo.Bu
        Next

        Dim errores As List(Of String) = _validator.ValidarRequisicion(cab)

        ' Si el usuario mencionó explícitamente una empresa en el chat (ej. "EMPRESA: MARTE"),
        ' se valida contra la empresa de la sesión activa — solo para avisar si no coincide,
        ' NUNCA para cambiar bajo qué empresa se guarda la requisición.
        If Not String.IsNullOrWhiteSpace(cab.EmpresaMencionada) AndAlso
           Not String.Equals(cab.EmpresaMencionada.Trim, _empresa, StringComparison.OrdinalIgnoreCase) Then
            preguntas.Add($"La requisición menciona la empresa '{cab.EmpresaMencionada}', pero tu sesión activa es '{_empresa}'. Verifica que estés en la empresa correcta antes de continuar.")
        End If

        If String.IsNullOrWhiteSpace(cab.Proveedor) Then
            ' ya lo reporta ValidarCabecera como error; no se duplica aquí.
        Else
            Dim chkProveedor = _catalogo.ValidarProveedor(cab.Proveedor)
            If Not chkProveedor.Existe Then
                Dim sugerencias = _catalogo.BuscarProveedoresPorNombre(cab.Proveedor)
                If sugerencias.Count > 0 Then
                    Dim opciones As String = String.Join(", ", sugerencias.Select(Function(s) $"{s.Codigo} ({s.Descripcion})"))
                    preguntas.Add($"Proveedor '{cab.Proveedor}' (no existe). ¿Es alguno de estos?: {opciones}")
                Else
                    preguntas.Add($"Proveedor '{cab.Proveedor}' (no existe) y no encontré coincidencias por nombre. ¿Cuál es el código correcto?")
                End If
            Else
                cab.NombreProveedor = chkProveedor.Nombre
            End If
        End If

        ' Distribución (CC/Marca/Canal/Gasto): se valida UNA vez a nivel de la requisición
        ' completa, no por línea — así funciona el sistema real (ver nota en RequisicionIA_Modelos.vb).
        For Each cc In cab.CentrosCosto
            If Not RequisicionCatalogContext.ExisteEnCatalogo(catCC, cc.Codigo) Then
                preguntas.Add($"Centro de Costo '{cc.Codigo}' ({cc.Descripcion}) (no existe). ¿A cuál código real corresponde?")
            End If
        Next
        For Each marca In cab.Marcas
            If Not RequisicionCatalogContext.ExisteEnCatalogo(catMarca, marca.Codigo) Then
                preguntas.Add($"Marca '{marca.Codigo}' ({marca.Descripcion}) (no existe). ¿A cuál código real corresponde?")
            End If
        Next
        For Each canal In cab.Canales
            If Not RequisicionCatalogContext.ExisteEnCatalogo(catCanal, canal.Codigo) Then
                preguntas.Add($"Canal '{canal.Codigo}' (no existe). ¿A cuál código real corresponde?")
            End If
        Next

        Dim catGasto = If(If(cab.TipoGasto, "").ToUpper = "CON_A&P", catAyP, catItem)
        For Each gasto In cab.Gastos
            If Not RequisicionCatalogContext.ExisteEnCatalogo(catGasto, gasto.Codigo) Then
                preguntas.Add($"Item de Gasto '{gasto.Codigo}' ({gasto.Descripcion}) (no existe). ¿A cuál código real corresponde?")
            End If
        Next

        ' Producto: sí es por línea (cada línea tiene su propio código de producto).
        For Each linea In cab.Lineas
            If Not String.IsNullOrWhiteSpace(linea.Codigo) AndAlso Not _catalogo.ExisteProducto(linea.Codigo) Then
                preguntas.Add($"Línea {linea.Linea}: Producto '{linea.Codigo}' (no existe). ¿Cuál es el código correcto?")
            End If
        Next

        Dim estado As EstadoBorradorRequisicion
        If preguntas.Count > 0 Then
            estado = EstadoBorradorRequisicion.PendienteAclaracion
        ElseIf errores.Count > 0 Then
            estado = EstadoBorradorRequisicion.ConErrores
        Else
            estado = EstadoBorradorRequisicion.Valido
        End If

        Return (errores, preguntas, estado)
    End Function

    ' ------------------------------------------------------------------
    ' System prompt: reglas de negocio + catálogos reales + borrador actual
    ' ------------------------------------------------------------------

    Private Function ConstruirSystemPrompt() As String
        Dim sb As New StringBuilder()
        sb.AppendLine("Eres un asistente que genera requisiciones de compra para el sistema Umbright a partir de instrucciones en español.")
        sb.AppendLine("Responde SIEMPRE usando la herramienta 'emitir_borrador_requisiciones' con el LOTE COMPLETO y actualizado de requisiciones (no solo la que cambió respecto al turno anterior).")
        sb.AppendLine()
        sb.AppendLine("REGLAS DE NEGOCIO OBLIGATORIAS (nunca las rompas):")
        sb.AppendLine("- Cada requisición necesita: fecha de entrega, observaciones generales, moneda, y al menos una línea con código de producto. El proveedor y el lugar de entrega son OPCIONALES: captúralos si el usuario los menciona, pero no los exijas ni bloquees la requisición si faltan.")
        sb.AppendLine("- Lugar de entrega ('lugarEntrega'): si el usuario lo menciona (una dirección, sucursal, bodega, etc.), captúralo tal cual en ese campo. No lo inventes si no lo mencionan.")
        sb.AppendLine("- La moneda es obligatoria y debe ser exactamente 'QUETZALES' o 'DOLARES' (sin otras opciones).")
        sb.AppendLine("- Centro de Costo, Marca, Canal, Item de Gasto y tipoGasto (ITEM/A&P) se definen UNA sola vez por requisición (van en la cabecera, NO dentro de cada línea) — se aplican automáticamente a todas las líneas de producto, igual que en el sistema manual.")
        sb.AppendLine("- Centro de Costo es obligatorio; sus porcentajes deben sumar exactamente 100.")
        sb.AppendLine("- Marca admite VARIAS marcas en la misma requisición (es un arreglo) — el usuario puede pedir el reparto entre varias marcas libremente. Los porcentajes de todas las marcas deben sumar 100 entre sí, Y ADEMÁS en CADA marca individual 'porcentajeEmpresa' + 'porcentajeSocio' debe sumar exactamente 100 (reparto con el socio comercial de ESA marca). Si el usuario pide una marca pero no dice cómo se reparte entre empresa y socio, NO asumas 100/0: dilo en 'resumen' y pregúntale explícitamente el reparto.")
        sb.AppendLine("- No incluyas un campo 'bu' para las marcas: la unidad de negocio de cada marca la determina el sistema automáticamente a partir del código, no es algo que tú definas.")
        sb.AppendLine("- Item de Gasto es obligatorio, con porcentajes que sumen 100.")
        sb.AppendLine("- tipoGasto: 'CON_ITEM' o 'CON_A&P'. Si es 'CON_A&P', la requisición debe llevar obligatoriamente Marca y Canal (ambos sumando 100%). Si es 'CON_ITEM', Marca y Canal son opcionales.")
        sb.AppendLine("- NUNCA inventes un código de Centro de Costo, Marca, Canal, Item de Gasto o Proveedor: usa solo los códigos exactos de los catálogos de abajo. Si lo que describe el usuario no coincide con ningún código, dilo en 'resumen' pidiendo aclaración en vez de adivinar.")
        sb.AppendLine("- El catálogo de Proveedores NO se incluye aquí (es demasiado grande). Si el usuario da el código exacto del proveedor, úsalo tal cual. Si el usuario solo da el nombre/razón social, coloca ese nombre tal cual en el campo 'proveedor' — el sistema buscará coincidencias por nombre automáticamente y le preguntará al usuario cuál es la correcta antes de guardar. Si el usuario no menciona proveedor, deja el campo vacío.")
        sb.AppendLine("- El catálogo de Productos SÍ se incluye abajo. Usa solo códigos de producto que aparezcan ahí. Si el usuario describe un producto que no coincide con ninguno, dilo en 'resumen' pidiendo el código correcto en vez de adivinar.")
        sb.AppendLine("- Cantidad y precio: si el usuario da un 'Monto' o total en vez de cantidad y precio por separado, usa cantidad = 1 y precio = ese monto total. Si además menciona una cantidad en el texto libre (ej. '500 shots'), usa esa cantidad y calcula precio = monto / cantidad.")
        sb.AppendLine("- Si el usuario escribe datos en formato 'Etiqueta: valor' (uno por línea, como una tabla), interpreta cada etiqueta por su significado en español aunque no use exactamente los mismos nombres de los campos (ej. 'Codigo producto', 'Item Gasto', 'Monto' son válidos).")
        sb.AppendLine("- Un código de Marca, Centro de Costo o Item de Gasto puede venir escrito junto con su descripción (ej. '132 - Don Julio 70'): usa solo la parte numérica/código exacto que exista en el catálogo, no el texto completo.")
        sb.AppendLine("- 'empresaMencionada': si el usuario escribe explícitamente una empresa (ej. 'EMPRESA: MARTE'), captúrala tal cual en ese campo — el sistema la usa solo para avisar si no coincide con la sesión activa, nunca para elegir catálogos.")
        sb.AppendLine()
        sb.AppendLine("CATÁLOGO VIGENTE — CENTROS DE COSTO (codigo - descripcion):")
        AgregarCatalogo(sb, _catalogo.ObtenerCatalogo("CON_CCOSTO"))
        sb.AppendLine("CATÁLOGO VIGENTE — MARCAS (codigo - descripcion):")
        AgregarCatalogo(sb, _catalogo.ObtenerCatalogo("CON_MARCA"))
        sb.AppendLine("CATÁLOGO VIGENTE — ITEMS DE GASTO TIPO ITEM (codigo - descripcion):")
        AgregarCatalogo(sb, _catalogo.ObtenerCatalogo("CON_ITEM"))
        sb.AppendLine("CATÁLOGO VIGENTE — ITEMS DE GASTO TIPO A&P (codigo - descripcion):")
        AgregarCatalogo(sb, _catalogo.ObtenerCatalogo("CON_A&P"))
        sb.AppendLine("CATÁLOGO VIGENTE — CANALES (codigo):")
        AgregarCatalogo(sb, _catalogo.ObtenerCatalogoCanal())

        Dim catalogoTruncado As Boolean = False
        Dim catalogoProductos = _catalogo.ObtenerCatalogoProductos(catalogoTruncado)
        sb.AppendLine("CATÁLOGO VIGENTE — PRODUCTOS (codigo - descripcion):")
        If catalogoTruncado Then
            sb.AppendLine("  (hay más de 1000 productos; esta lista muestra solo los primeros 1000 en orden de código — si el producto que necesitas no aparece, pide el código exacto al usuario.)")
        End If
        AgregarCatalogo(sb, catalogoProductos)

        If Lote IsNot Nothing AndAlso Lote.Count > 0 Then
            sb.AppendLine()
            sb.AppendLine("BORRADOR ACTUAL DEL LOTE (corrígelo según lo que pida el usuario y devuelve el lote completo actualizado):")
            sb.AppendLine(Newtonsoft.Json.JsonConvert.SerializeObject(Lote.Select(Function(i) i.Cabecera)))
        End If

        Return sb.ToString()
    End Function

    Private Sub AgregarCatalogo(sb As StringBuilder, items As List(Of RequisicionCatalogContext.ItemCatalogo))
        For Each i In items
            sb.AppendLine($"  {i.Codigo} - {i.Descripcion}")
        Next
    End Sub

End Class
