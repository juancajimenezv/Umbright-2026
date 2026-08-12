Option Strict Off
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports Newtonsoft.Json.Linq

''' <summary>
''' Cliente HTTP hacia la API de Anthropic (Messages API). Fuerza al modelo a responder
''' siempre con la tool "emitir_borrador_requisiciones" (JSON Schema, sin texto libre a
''' parsear), y registra el consumo de tokens de CADA llamada en
''' flexline.um_ia_log_consumo (pa_ins_um_ia_log_consumo), incluso si la respuesta luego
''' no pasa validación de negocio — así ningún gasto de tokens queda sin auditar.
''' </summary>
Public Class AnthropicClient

    Private Const API_URL As String = "https://api.anthropic.com/v1/messages"
    Private Const API_VERSION As String = "2023-06-01"
    Private Const MODELO As String = "claude-sonnet-5"
    Private Const MAX_TOKENS As Integer = 8192

    ' NOTA: se intentó fijar "temperature" en 0.3 para mayor consistencia, pero la API
    ' de Anthropic la rechaza con HTTP 400 ("`temperature` is deprecated for this model")
    ' para claude-sonnet-5 — este modelo ya no acepta ese parámetro. No se debe volver a
    ' agregar "temperature" al body mientras se use este modelo.
    Private Const NOMBRE_TOOL As String = "emitir_borrador_requisiciones"

    ''' <summary>
    ''' Clave simétrica LOCAL usada por clEmpaquetar (mod_principal.vb) para cifrar/descifrar
    ''' la API key de Anthropic guardada en gen_tabcod. NO es la API key en sí.
    ''' </summary>
    Private Const CLAVE_CIFRADO_LOCAL As String = "UmbRequisicionesIA-2026"

    Private Shared ReadOnly _http As New HttpClient()

    Private ReadOnly _empresa As String
    Private ReadOnly _usuario As String
    Private ReadOnly _correlativoLote As String

    Public Sub New(empresa As String, usuario As String, correlativoLote As String)
        _empresa = empresa
        _usuario = usuario
        _correlativoLote = correlativoLote
    End Sub

    Public Class ResultadoLlamada
        Public Property Exitoso As Boolean
        Public Property MensajeError As String
        Public Property Resumen As String
        Public Property Requisiciones As New List(Of RequisicionCabeceraDraft)
    End Class

    ''' <summary>Un turno de la conversación tal como se le presenta al modelo (role: "user"/"assistant").</summary>
    Public Class TurnoChat
        Public Property Rol As String
        Public Property Texto As String
    End Class

    ' ------------------------------------------------------------------
    ' Configuración (API Key)
    ' ------------------------------------------------------------------

    Private Function LeerApiKey() As String
        Dim oTrans As New Transaccional.Conexion("SCM")
        Try
            oTrans.open()
            Dim sql As String = "pa_sel_um_configuracion_ia '" & RequisicionSqlUtil.EscaparSql(_empresa) & "','CON_CONFIG_IA','ANTHROPIC_API_KEY'"
            Dim dt As DataTable = oTrans.Obtiene(sql)
            If dt Is Nothing OrElse dt.Rows.Count = 0 OrElse String.IsNullOrWhiteSpace(dt.Rows(0).Item("valor").ToString) Then
                Throw New Exception("No hay una API Key de Anthropic configurada para la empresa " & _empresa & " (flexline.um_ia_configuracion, tipo=CON_CONFIG_IA).")
            End If
            Dim textoCifrado As String = dt.Rows(0).Item("valor").ToString
            Dim cripto As New clEmpaquetar(CLAVE_CIFRADO_LOCAL)
            Return cripto.Decrypt(textoCifrado)
        Finally
            oTrans.close()
        End Try
    End Function

    ''' <summary>
    ''' Cifra y guarda la API Key de Anthropic. Quien llama esto (p.ej. frmConfigurarApiKeyIA)
    ''' entrega la clave en TEXTO PLANO tal como la entrega Anthropic; nunca hay que cifrarla
    ''' a mano ni guardarla en texto plano en ningún script.
    ''' </summary>
    Public Shared Sub GuardarApiKey(empresa As String, claveTextoPlano As String)
        Dim cripto As New clEmpaquetar(CLAVE_CIFRADO_LOCAL)
        Dim claveCifrada As String = cripto.Encrypt(claveTextoPlano)

        Dim oTrans As New Transaccional.Conexion("SCM")
        Try
            oTrans.open()
            Dim sql As String = "pa_upd_um_configuracion_ia '" & RequisicionSqlUtil.EscaparSql(empresa) & "','CON_CONFIG_IA','ANTHROPIC_API_KEY','" &
                RequisicionSqlUtil.EscaparSql(claveCifrada) & "','API Key de Anthropic (cifrada TripleDES)'"
            oTrans.Ingresa(sql)
            If oTrans.Codigo_error > 0 Then
                Throw New ApplicationException("No se pudo guardar la API Key: " & oTrans.descripcion_error)
            End If
        Finally
            oTrans.close()
        End Try
    End Sub

    ' ------------------------------------------------------------------
    ' Llamada principal
    ' ------------------------------------------------------------------

    ''' <summary>
    ''' Envía el prompt del sistema (reglas de negocio + catálogos) y el historial de chat,
    ''' fuerza la tool de salida estructurada, y devuelve el lote de requisiciones propuesto.
    ''' </summary>
    Public Function GenerarBorrador(systemPrompt As String, historial As List(Of TurnoChat), accion As String) As ResultadoLlamada
        Dim resultado As New ResultadoLlamada
        Dim apiKey As String

        Try
            apiKey = LeerApiKey()
        Catch ex As Exception
            resultado.Exitoso = False
            resultado.MensajeError = ex.Message
            Return resultado
        End Try

        Dim body As New JObject From {
            {"model", MODELO},
            {"max_tokens", MAX_TOKENS},
            {"system", systemPrompt},
            {"messages", ConstruirMensajes(historial)},
            {"tools", New JArray(ConstruirDefinicionTool())},
            {"tool_choice", New JObject From {{"type", "tool"}, {"name", NOMBRE_TOOL}}}
        }

        Dim request As New HttpRequestMessage(HttpMethod.Post, API_URL)
        request.Headers.Add("x-api-key", apiKey)
        request.Headers.Add("anthropic-version", API_VERSION)
        request.Content = New StringContent(body.ToString(), Encoding.UTF8, "application/json")

        Dim responseBody As String
        Try
            Dim response As HttpResponseMessage = _http.SendAsync(request).GetAwaiter().GetResult()
            responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult()
            If Not response.IsSuccessStatusCode Then
                resultado.Exitoso = False
                resultado.MensajeError = $"Error HTTP {CInt(response.StatusCode)} de la API de Anthropic: {responseBody}"
                Return resultado
            End If
        Catch ex As Exception
            resultado.Exitoso = False
            resultado.MensajeError = "Error de comunicación con la API de Anthropic: " & ex.Message
            Return resultado
        End Try

        Dim json As JObject = JObject.Parse(responseBody)

        ' --- Log de consumo de tokens: se registra SIEMPRE que la llamada HTTP respondió, ---
        ' --- sin importar si el parseo/validación posterior tiene éxito.                  ---
        Dim tokensInput As Integer = If(json("usage")?("input_tokens")?.Value(Of Integer)(), 0)
        Dim tokensOutput As Integer = If(json("usage")?("output_tokens")?.Value(Of Integer)(), 0)
        RegistrarConsumo(accion, tokensInput, tokensOutput, Nothing)

        Try
            Dim contenido As JArray = TryCast(json("content"), JArray)
            If contenido Is Nothing Then
                resultado.Exitoso = False
                resultado.MensajeError = "La respuesta de la API no trajo contenido interpretable."
                Return resultado
            End If

            Dim bloqueTool As JObject = Nothing
            For Each bloqueToken In contenido
                Dim bloque As JObject = TryCast(bloqueToken, JObject)
                If bloque IsNot Nothing AndAlso bloque("type")?.ToString() = "tool_use" Then
                    bloqueTool = bloque
                    Exit For
                End If
            Next

            If bloqueTool Is Nothing Then
                resultado.Exitoso = False
                resultado.MensajeError = "El modelo no devolvió una respuesta estructurada (tool_use)."
                Return resultado
            End If

            Dim input As JObject = TryCast(bloqueTool("input"), JObject)
            If input Is Nothing Then
                resultado.Exitoso = False
                resultado.MensajeError = "La respuesta estructurada del modelo vino vacía o con formato inesperado."
                Return resultado
            End If

            resultado.Resumen = If(input("resumen")?.ToString(), "")
            resultado.Requisiciones = ParsearRequisiciones(TryCast(input("requisiciones"), JArray))
            resultado.Exitoso = True

        Catch ex As Exception
            resultado.Exitoso = False
            resultado.MensajeError = "No se pudo interpretar la respuesta del modelo: " & ex.Message
        End Try

        Return resultado
    End Function

    Private Sub RegistrarConsumo(accion As String, tokensInput As Integer, tokensOutput As Integer, numeroRequisicion As String)
        Dim oTrans As New Transaccional.Conexion("SCM")
        Try
            oTrans.open()
            Dim sql As String = "pa_ins_um_ia_log_consumo '" & RequisicionSqlUtil.EscaparSql(_empresa) & "','" &
                RequisicionSqlUtil.EscaparSql(_usuario) & "','" & MODELO & "','" & RequisicionSqlUtil.EscaparSql(accion) & "'," &
                tokensInput & "," & tokensOutput & "," &
                If(String.IsNullOrEmpty(_correlativoLote), "NULL", "'" & RequisicionSqlUtil.EscaparSql(_correlativoLote) & "'") & "," &
                If(String.IsNullOrEmpty(numeroRequisicion), "NULL", "'" & RequisicionSqlUtil.EscaparSql(numeroRequisicion) & "'")
            oTrans.Ingresa(sql)
        Catch
            ' El log de consumo nunca debe tumbar el flujo principal del chat.
        Finally
            oTrans.close()
        End Try
    End Sub

    ' ------------------------------------------------------------------
    ' Construcción de mensajes / tool schema
    ' ------------------------------------------------------------------

    Private Function ConstruirMensajes(historial As List(Of TurnoChat)) As JArray
        Dim mensajes As New JArray
        For Each turno In historial
            mensajes.Add(New JObject From {{"role", turno.Rol}, {"content", turno.Texto}})
        Next
        Return mensajes
    End Function

    Private Function ConstruirDefinicionTool() As JObject
        Dim schemaDimension As Func(Of Boolean, JObject) = Function(incluyeSocios As Boolean)
                                                                 Dim props As New JObject From {
                                                                     {"codigo", New JObject From {{"type", "string"}}},
                                                                     {"descripcion", New JObject From {{"type", "string"}}},
                                                                     {"porcentaje", New JObject From {{"type", "number"}}}
                                                                 }
                                                                 If incluyeSocios Then
                                                                     props("porcentajeEmpresa") = New JObject From {{"type", "number"}}
                                                                     props("porcentajeSocio") = New JObject From {{"type", "number"}}
                                                                     ' "bu" (unidad de negocio) NO se le pide al modelo: es un atributo propio
                                                                     ' del código de marca en el catálogo, se auto-completa server-side
                                                                     ' (RequisicionChatOrchestrator.ValidarItem) para evitar que el modelo
                                                                     ' invente un valor sin sentido para un campo que no puede conocer.
                                                                 End If
                                                                 Return New JObject From {
                                                                     {"type", "object"},
                                                                     {"properties", props},
                                                                     {"required", New JArray("codigo", "descripcion", "porcentaje")}
                                                                 }
                                                             End Function

        ' El código de línea (producto) NO lleva distribución propia: en el sistema real
        ' (frmRequisiciones.vb:2411-2472) Centro de Costo/Marca/Canal/Gasto se define UNA vez
        ' por requisición y se reutiliza para todas sus líneas — por eso vive en la cabecera.
        Dim lineaSchema As New JObject From {
            {"type", "object"},
            {"properties", New JObject From {
                {"codigo", New JObject From {{"type", "string"}, {"description", "Código de producto, obligatorio como mínimo."}}},
                {"descripcion", New JObject From {{"type", "string"}}},
                {"cantidad", New JObject From {{"type", "number"}}},
                {"precio", New JObject From {{"type", "number"}}},
                {"observaciones", New JObject From {{"type", "string"}}}
            }},
            {"required", New JArray("codigo", "cantidad", "precio")}
        }

        Dim cabeceraSchema As New JObject From {
            {"type", "object"},
            {"properties", New JObject From {
                {"proveedor", New JObject From {{"type", "string"}}},
                {"empresaMencionada", New JObject From {{"type", "string"}, {"description", "Si el usuario menciona explícitamente una empresa (ej. 'EMPRESA: MARTE'), cópiala aquí tal cual. Si no la menciona, deja este campo vacío. NUNCA la uses para elegir catálogos ni para decidir dónde guardar — el sistema la usa solo para avisar si no coincide con la sesión activa."}}},
                {"fechaEntrega", New JObject From {{"type", "string"}, {"description", "Fecha ISO yyyy-MM-dd"}}},
                {"lugarEntrega", New JObject From {{"type", "string"}}},
                {"observaciones", New JObject From {{"type", "string"}}},
                {"moneda", New JObject From {{"type", "string"}, {"enum", New JArray("QUETZALES", "DOLARES")}}},
                {"cadena", New JObject From {{"type", "string"}}},
                {"anticipo", New JObject From {{"type", "string"}, {"enum", New JArray("SI", "NO")}}},
                {"montoAnticipo", New JObject From {{"type", "number"}}},
                {"afectaInventario", New JObject From {{"type", "string"}, {"enum", New JArray("S", "N")}}},
                {"tipoGasto", New JObject From {{"type", "string"}, {"enum", New JArray("CON_ITEM", "CON_A&P")}, {"description", "Se define UNA vez para toda la requisición, no por línea."}}},
                {"centrosCosto", New JObject From {{"type", "array"}, {"items", schemaDimension(False)}}},
                {"marcas", New JObject From {{"type", "array"}, {"items", schemaDimension(True)}}},
                {"canales", New JObject From {{"type", "array"}, {"items", schemaDimension(False)}}},
                {"gastos", New JObject From {{"type", "array"}, {"items", schemaDimension(False)}}},
                {"lineas", New JObject From {{"type", "array"}, {"items", lineaSchema}}}
            }},
            {"required", New JArray("fechaEntrega", "observaciones", "moneda", "tipoGasto", "centrosCosto", "gastos", "lineas")}
        }

        Dim inputSchema As New JObject From {
            {"type", "object"},
            {"properties", New JObject From {
                {"resumen", New JObject From {{"type", "string"}, {"description", "Texto breve en español para mostrar en el chat explicando qué se generó o corrigió."}}},
                {"requisiciones", New JObject From {{"type", "array"}, {"items", cabeceraSchema}}}
            }},
            {"required", New JArray("resumen", "requisiciones")}
        }

        Return New JObject From {
            {"name", NOMBRE_TOOL},
            {"description", "Emite el borrador completo y actualizado del lote de requisiciones de compra, reemplazando cualquier borrador anterior."},
            {"input_schema", inputSchema}
        }
    End Function

    ' ------------------------------------------------------------------
    ' Parseo de la respuesta a POCOs
    ' ------------------------------------------------------------------

    Private Function ParsearRequisiciones(arreglo As JArray) As List(Of RequisicionCabeceraDraft)
        Dim resultado As New List(Of RequisicionCabeceraDraft)
        If arreglo Is Nothing Then Return resultado

        For Each itemToken In arreglo
            Dim item As JObject = TryCast(itemToken, JObject)
            If item Is Nothing Then Continue For

            Dim cab As New RequisicionCabeceraDraft With {
                .Proveedor = item("proveedor")?.ToString(),
                .EmpresaMencionada = item("empresaMencionada")?.ToString(),
                .LugarEntrega = item("lugarEntrega")?.ToString(),
                .Observaciones = item("observaciones")?.ToString(),
                .Moneda = item("moneda")?.ToString(),
                .Cadena = item("cadena")?.ToString(),
                .Anticipo = item("anticipo")?.ToString(),
                .MontoAnticipo = If(item("montoAnticipo")?.Value(Of Double)(), 0),
                .AfectaInventario = item("afectaInventario")?.ToString(),
                .TipoGasto = item("tipoGasto")?.ToString()
            }

            Dim fechaTexto As String = item("fechaEntrega")?.ToString()
            Dim fechaParseada As Date
            If Date.TryParse(fechaTexto, fechaParseada) Then
                cab.FechaEntrega = fechaParseada
            End If

            ' Distribución única de la requisición (no por línea) — ver nota en el schema.
            ' TryCast (no CType): si el modelo omite un campo opcional (p.ej. marcas/canales
            ' en una requisición tipo ITEM) puede venir como JValue null en vez de JArray vacío,
            ' y CType lanzaría InvalidCastException. TryCast simplemente lo trata como ausente.
            cab.CentrosCosto = ParsearDimensiones(TryCast(item("centrosCosto"), JArray))
            cab.Marcas = ParsearDimensiones(TryCast(item("marcas"), JArray))
            cab.Canales = ParsearDimensiones(TryCast(item("canales"), JArray))
            cab.Gastos = ParsearDimensiones(TryCast(item("gastos"), JArray))

            Dim lineasToken As JArray = TryCast(item("lineas"), JArray)
            If lineasToken IsNot Nothing Then
                Dim numeroLinea As Integer = 0
                For Each lineaToken In lineasToken
                    Dim lineaJson As JObject = TryCast(lineaToken, JObject)
                    If lineaJson Is Nothing Then Continue For
                    numeroLinea += 1
                    Dim linea As New RequisicionLineaDraft With {
                        .Linea = numeroLinea,
                        .Codigo = lineaJson("codigo")?.ToString(),
                        .Descripcion = lineaJson("descripcion")?.ToString(),
                        .Cantidad = If(lineaJson("cantidad")?.Value(Of Double)(), 0),
                        .Precio = If(lineaJson("precio")?.Value(Of Double)(), 0),
                        .Observaciones = lineaJson("observaciones")?.ToString()
                    }
                    cab.Lineas.Add(linea)
                Next
            End If

            resultado.Add(cab)
        Next

        Return resultado
    End Function

    Private Function ParsearDimensiones(arreglo As JArray) As List(Of RequisicionDimensionDraft)
        Dim resultado As New List(Of RequisicionDimensionDraft)
        If arreglo Is Nothing Then Return resultado
        For Each token In arreglo
            Dim obj As JObject = TryCast(token, JObject)
            If obj Is Nothing Then Continue For
            resultado.Add(New RequisicionDimensionDraft With {
                .Codigo = obj("codigo")?.ToString(),
                .Descripcion = obj("descripcion")?.ToString(),
                .Porcentaje = If(obj("porcentaje")?.Value(Of Double)(), 0),
                .PorcentajeEmpresa = obj("porcentajeEmpresa")?.Value(Of Double)(),
                .PorcentajeSocio = obj("porcentajeSocio")?.Value(Of Double)(),
                .Bu = obj("bu")?.ToString()
            })
        Next
        Return resultado
    End Function

End Class
