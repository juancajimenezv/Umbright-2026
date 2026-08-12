Option Strict Off
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Linq

''' <summary>
''' Da acceso de solo-lectura a los catálogos reales (Centro de Costo, Marca, Item de Gasto,
''' Canal) y a la validación de Proveedor, para que el módulo de IA:
''' (a) le pase al modelo la lista de códigos válidos en el prompt, y
''' (b) verifique que cualquier código que el modelo proponga exista literalmente ahí antes
'''     de darlo por bueno — nunca se hace fuzzy-match automático.
''' Replica las mismas fuentes de datos que ya usa frmRequisiconesDetalle.vb (gen_tabcod) y
''' frmRequisiciones.vb (pa_sel_um_ctacte).
''' </summary>
Public Class RequisicionCatalogContext

    Private ReadOnly _empresa As String

    Public Sub New(empresa As String)
        _empresa = empresa
    End Sub

    ''' <summary>Código + descripción de un catálogo simple de gen_tabcod (CC, Marca o Gasto).</summary>
    Public Class ItemCatalogo
        Public Property Codigo As String
        Public Property Descripcion As String

        ''' <summary>Solo aplica a Marca: unidad de negocio (gen_tabcod.texto4), ATRIBUTO propio
        ''' del código de marca en el catálogo — nunca lo elige el usuario ni el modelo de IA
        ''' (frmRequisiconesDetalle.vb:55-73, buscarGlosaConta).</summary>
        Public Property Bu As String
    End Class

    ''' <summary>
    ''' Valida un proveedor contra flexline.ctacte, igual que buscaProveedor_requisicion
    ''' (frmRequisiciones.vb:368-395).
    ''' Un código real de proveedor nunca lleva espacios; si el texto trae espacios (p.ej.
    ''' "Esteban Fajardo" descrito por nombre), se trata como NO exacto sin ni siquiera
    ''' consultar el SP — evita que una coincidencia parcial/por nombre de pa_sel_um_ctacte
    ''' se cuele como si fuera un código válido.
    ''' </summary>
    Public Function ValidarProveedor(codigo As String) As (Existe As Boolean, Nombre As String)
        If String.IsNullOrWhiteSpace(codigo) Then Return (False, "")
        If codigo.Trim.Contains(" ") Then Return (False, "")

        Dim oTrans As New Transaccional.Conexion("flexline")
        Try
            oTrans.open()
            Dim sql As String = "pa_sel_um_ctacte '" & RequisicionSqlUtil.EscaparSql(_empresa) & "','PROVEEDOR','" & RequisicionSqlUtil.EscaparSql(codigo.Trim) & "'"
            Dim dt As DataTable = oTrans.Obtiene(sql)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return (False, "")
            End If
            Dim nombre As String = dt.Rows(0).Item("RazonSocial").ToString & "/" & dt.Rows(0).Item("giro").ToString
            Return (True, nombre)
        Finally
            oTrans.close()
        End Try
    End Function

    ''' <summary>
    ''' Busca proveedores por coincidencia parcial de razón social, para cuando el usuario
    ''' lo describe por nombre en vez de dar el código exacto de ctacte. Usa la misma vista
    ''' que ya usa el buscador genérico del sistema (frm_scm_aprobacion_tesoreria.vb:131,
    ''' nombre_vista = "v_um_ctacte_proveedor_busqueda"). Nunca se usa el resultado como
    ''' match automático — solo como sugerencias para que el usuario confirme en el chat.
    ''' </summary>
    Public Function BuscarProveedoresPorNombre(textoBusqueda As String) As List(Of ItemCatalogo)
        Dim resultado As New List(Of ItemCatalogo)
        If String.IsNullOrWhiteSpace(textoBusqueda) Then Return resultado

        Dim oTrans As New Transaccional.Conexion("flexline")
        Try
            oTrans.open()
            Dim sql As String = "SELECT TOP 10 ctacte AS codigo, razonsocial AS descripcion FROM v_um_ctacte_proveedor_busqueda " &
                "WHERE empresa = '" & RequisicionSqlUtil.EscaparSql(_empresa) & "' AND razonsocial LIKE '%" &
                RequisicionSqlUtil.EscaparSql(textoBusqueda.Trim) & "%' ORDER BY razonsocial"
            Dim dt As DataTable = oTrans.Obtiene(sql)
            For Each dr As DataRow In dt.Rows
                resultado.Add(New ItemCatalogo With {.Codigo = dr.Item("codigo").ToString.Trim, .Descripcion = dr.Item("descripcion").ToString.Trim})
            Next
        Finally
            oTrans.close()
        End Try
        Return resultado
    End Function

    ''' <summary>
    ''' Valida que un código de producto exista, igual que la verificación de
    ''' frmRequisiciones.vb:validarGuardar() (línea ~2099): `pa_sel_um_producto 'LOGISERV', '&lt;codigo&gt;'`.
    ''' </summary>
    Public Function ExisteProducto(codigo As String) As Boolean
        If String.IsNullOrWhiteSpace(codigo) Then Return False

        Dim oTrans As New Transaccional.Conexion("SCM")
        Try
            oTrans.open()
            Dim sql As String = "pa_sel_um_producto 'LOGISERV','" & RequisicionSqlUtil.EscaparSql(codigo.Trim) & "'"
            Dim dt As DataTable = oTrans.Obtiene(sql)
            Return dt IsNot Nothing AndAlso dt.Rows.Count > 0
        Finally
            oTrans.close()
        End Try
    End Function

    ''' <summary>
    ''' Devuelve la descripción (glosa) de un producto si existe, igual que la columna
    ''' "glosa" usada por el buscador real de producto (frmRequisiciones.vb:2701-2704,
    ''' `lista_campos = "producto,glosa,tipoproducto"`). Nothing si no existe.
    ''' </summary>
    Public Function ObtenerDescripcionProducto(codigo As String) As String
        If String.IsNullOrWhiteSpace(codigo) Then Return Nothing

        Dim oTrans As New Transaccional.Conexion("SCM")
        Try
            oTrans.open()
            Dim sql As String = "pa_sel_um_producto 'LOGISERV','" & RequisicionSqlUtil.EscaparSql(codigo.Trim) & "'"
            Dim dt As DataTable = oTrans.Obtiene(sql)
            If dt Is Nothing OrElse dt.Rows.Count = 0 OrElse Not dt.Columns.Contains("glosa") Then Return Nothing
            Return dt.Rows(0).Item("glosa").ToString
        Finally
            oTrans.close()
        End Try
    End Function

    ''' <summary>
    ''' Lista el catálogo de productos, con el mismo origen y filtro EXACTO que usa el
    ''' buscador real de producto en frmRequisiciones.vb:btnBuscarProducto_Click (líneas
    ''' 2701-2704): `nombre_vista = "scm.flexline.producto"`, `empresa = 'LOGISERV'`
    ''' (constante, igual que en pa_sel_um_producto — no es gs_empresa).
    ''' Se limita a TOP 1000 para no disparar el tamaño del prompt; si el catálogo real
    ''' tiene más productos que eso, no se manda completo (se le avisa al usuario, no se
    ''' trunca en silencio).
    ''' </summary>
    Public Function ObtenerCatalogoProductos(ByRef truncado As Boolean) As List(Of ItemCatalogo)
        Dim resultado As New List(Of ItemCatalogo)
        Dim oTrans As New Transaccional.Conexion("SCM")
        Try
            oTrans.open()
            Dim total As Integer = 0
            Dim dtTotal As DataTable = oTrans.Obtiene("SELECT COUNT(*) AS total FROM scm.flexline.producto WHERE empresa = 'LOGISERV'")
            If dtTotal IsNot Nothing AndAlso dtTotal.Rows.Count > 0 Then
                Integer.TryParse(dtTotal.Rows(0).Item("total").ToString, total)
            End If
            truncado = total > 1000

            Dim sql As String = "SELECT TOP 1000 producto AS codigo, glosa AS descripcion FROM scm.flexline.producto " &
                "WHERE empresa = 'LOGISERV' ORDER BY producto"
            Dim dt As DataTable = oTrans.Obtiene(sql)
            For Each dr As DataRow In dt.Rows
                resultado.Add(New ItemCatalogo With {.Codigo = dr.Item("codigo").ToString.Trim, .Descripcion = dr.Item("descripcion").ToString.Trim})
            Next
        Finally
            oTrans.close()
        End Try
        Return resultado
    End Function

    ''' <summary>
    ''' Lista los códigos de Centro de Costo (tipo=CON_CCOSTO), Marca (CON_MARCA) o Item de
    ''' Gasto (CON_ITEM / CON_A&amp;P), con el mismo filtro base que usa el buscador real
    ''' (frm_busqueda_general contra gen_tabcod en frmRequisiconesDetalle.vb líneas ~169, ~248,
    ''' ~327: `empresa = ? and tipo in (?)`, SIN filtrar por vigencia — un filtro de vigencia
    ''' que no exista en el buscador real causaría que códigos seleccionables a mano se
    ''' marquen como "no existe").
    ''' Además restringe por formato de código según el tipo (pedido explícito del usuario,
    ''' para excluir entradas de gen_tabcod que no son códigos reales de requisición):
    ''' Marca = exactamente 3 dígitos, Centro de Costo = exactamente 4 dígitos,
    ''' Item de Gasto (CON_ITEM/CON_A&amp;P) = más de 6 caracteres.
    ''' </summary>
    Public Function ObtenerCatalogo(tipo As String) As List(Of ItemCatalogo)
        Dim resultado As New List(Of ItemCatalogo)
        Dim oTrans As New Transaccional.Conexion("SCM")
        Try
            oTrans.open()
            ' texto4 se selecciona siempre (es donde vive "bu" para CON_MARCA); para los
            ' demás tipos simplemente no se usa.
            Dim sql As String = "SELECT codigo, descripcion, texto4 FROM BDflexline.[flexline].[gen_tabcod] " &
                "WHERE empresa = '" & RequisicionSqlUtil.EscaparSql(_empresa) & "' AND tipo = '" & RequisicionSqlUtil.EscaparSql(tipo) & "'"
            Dim dt As DataTable = oTrans.Obtiene(sql)
            For Each dr As DataRow In dt.Rows
                resultado.Add(New ItemCatalogo With {
                    .Codigo = dr.Item("codigo").ToString.Trim,
                    .Descripcion = dr.Item("descripcion").ToString.Trim,
                    .Bu = If(dr.Item("texto4") Is DBNull.Value, "", dr.Item("texto4").ToString.Trim)
                })
            Next
        Finally
            oTrans.close()
        End Try
        Return FiltrarPorFormato(tipo, resultado)
    End Function

    Private Shared Function FiltrarPorFormato(tipo As String, items As List(Of ItemCatalogo)) As List(Of ItemCatalogo)
        Select Case tipo
            Case "CON_MARCA"
                Return items.Where(Function(i) EsNumericoDeLongitud(i.Codigo, 3)).ToList()
            Case "CON_CCOSTO"
                Return items.Where(Function(i) EsNumericoDeLongitud(i.Codigo, 4)).ToList()
            Case "CON_ITEM", "CON_A&P"
                Return items.Where(Function(i) If(i.Codigo, "").Trim().Length > 6).ToList()
            Case Else
                Return items
        End Select
    End Function

    Private Shared Function EsNumericoDeLongitud(codigo As String, longitud As Integer) As Boolean
        Dim c As String = If(codigo, "").Trim()
        Return c.Length = longitud AndAlso c.All(Function(ch) Char.IsDigit(ch))
    End Function

    ''' <summary>
    ''' Catálogo de Canal: caso especial, vive en gen_tabcod con tipo='sysgold_ejecutivos' y
    ''' código/descripción tomados de texto4 (frmRequisiconesDetalle.vb:580-584).
    ''' </summary>
    Public Function ObtenerCatalogoCanal() As List(Of ItemCatalogo)
        Dim resultado As New List(Of ItemCatalogo)
        Dim oTrans As New Transaccional.Conexion("SCM")
        Try
            oTrans.open()
            Dim sql As String = "SELECT DISTINCT texto4 AS codigo, texto4 AS descripcion FROM [flexline].[gen_tabcod] " &
                "WHERE empresa = '" & RequisicionSqlUtil.EscaparSql(_empresa) & "' AND tipo = 'sysgold_ejecutivos' AND substring(texto4,3,1) = ')'"
            Dim dt As DataTable = oTrans.Obtiene(sql)
            For Each dr As DataRow In dt.Rows
                resultado.Add(New ItemCatalogo With {.Codigo = dr.Item("codigo").ToString.Trim, .Descripcion = dr.Item("descripcion").ToString.Trim})
            Next
        Finally
            oTrans.close()
        End Try
        Return resultado
    End Function

    ''' <summary>
    ''' Verifica que un código exista literalmente en un catálogo ya cargado (sin fuzzy match).
    ''' </summary>
    Public Shared Function ExisteEnCatalogo(catalogo As List(Of ItemCatalogo), codigo As String) As Boolean
        If catalogo Is Nothing OrElse String.IsNullOrWhiteSpace(codigo) Then Return False
        Return catalogo.Exists(Function(c) String.Equals(c.Codigo, codigo.Trim, StringComparison.OrdinalIgnoreCase))
    End Function

End Class
