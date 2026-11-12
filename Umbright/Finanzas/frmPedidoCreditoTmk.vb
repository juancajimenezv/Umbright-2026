Imports System.IO

Public Class frmPedidoCreditoTmk

    Dim lDsFel As DataSet
    Dim oFlex As New Transaccional.Conexion("Flexline")

    Private Sub Crear_estructuraFel(ByRef dsFel As DataSet)

        Dim dt As DataTable

        dsFel = New DataSet
        dt = New DataTable("pedidos")
        dt.Columns.Add(New DataColumn("Enviar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("SerieFel", GetType(String)))
        dt.Columns.Add(New DataColumn("NumeroFel", GetType(String)))
        dt.Columns.Add(New DataColumn("Serie", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("correlativo", GetType(String)))
        dt.Columns.Add(New DataColumn("codlegal", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("forma_Pago", GetType(String)))
        dt.Columns.Add(New DataColumn("Bodega", GetType(String)))
        dt.Columns.Add(New DataColumn("PorcDescuento", GetType(Double)))
        dt.Columns.Add(New DataColumn("direccion", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono", GetType(String)))
        dt.Columns.Add(New DataColumn("Total", GetType(String)))
        dt.Columns.Add(New DataColumn("RefTipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("RefCorrelativo", GetType(String)))
        dt.Columns.Add(New DataColumn("RefNumero", GetType(String)))
        dt.Columns.Add(New DataColumn("RefFecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("vigencia", GetType(String)))
        dt.Columns.Add(New DataColumn("exento", GetType(String)))
        dt.Columns.Add(New DataColumn("Comentario", GetType(String)))
        dt.Columns.Add(New DataColumn("Vendedor", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero_Pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero_PedidoWM", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDoctoOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("serieFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("firmaFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("nitFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("direccionFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaFACE", GetType(Date)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("Documento", GetType(String)))
        dt.Columns.Add(New DataColumn("tipodocto", GetType(String)))
        dt.Columns.Add(New DataColumn("procesado", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("MaquinaFace", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ImpresoraFace", GetType(String)))
        dt.Columns.Add(New DataColumn("BodegaInterEmpresas", GetType(String)))  ''(c)290414 Campo para definir la creacion e impresion de Documentos InterEmpresas
        dt.Columns.Add(New DataColumn("Comuna", GetType(String))) '(c)230315 Campo para informacion walmart 
        dt.Columns.Add(New DataColumn("Estado", GetType(String))) '(c)230315 Campo para informacion walmart
        dt.Columns.Add(New DataColumn("Numero_Recepcion_Walmart", GetType(String))) '(c)230315 Campo para informacion walmart
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String))) '(c)20180105 Definir si es B=Bien S=Servicio
        dt.Columns.Add(New DataColumn("moneda", GetType(String))) '(c)20180116 Definir si es B=Bien S=Servicio
        dt.Columns.Add(New DataColumn("tasa", GetType(Double))) '(c)20180116 Definir si es B=Bien S=Servicio
        dt.Columns.Add(New DataColumn("UsuarioModif", GetType(String))) '(c)20190117
        dt.Columns.Add(New DataColumn("F_FLETE", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("F_SEGURO", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("FLETE", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("SEGURO", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Analisis17", GetType(String)))
        dt.Columns.Add(New DataColumn("LisPrecio", GetType(String)))
        dt.Columns.Add(New DataColumn("SerieFace", GetType(String)))
        dt.Columns.Add(New DataColumn("NumeroAutFace", GetType(String)))
        dt.Columns.Add(New DataColumn("FechaFace", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("NoAutFel", GetType(String)))
        dt.Columns.Add(New DataColumn("NoSerieFel", GetType(String)))
        dt.Columns.Add(New DataColumn("AutFel", GetType(String)))
        dt.Columns.Add(New DataColumn("FechaAutFel", GetType(String)))
        dt.Columns.Add(New DataColumn("NitFactFel", GetType(String)))
        dt.Columns.Add(New DataColumn("ComentarioFace", GetType(String)))

        dsFel.Tables.Add(dt)

    End Sub

    Private Sub agregarPedidoPendiente(dr As DataRow, ByRef odsFACE As DataSet)

        Dim dr_aux As DataRow = odsFACE.Tables("pedidos").NewRow

        'Los documentos se cargan desmarcados; el usuario elige cuales certificar
        dr_aux.Item("Enviar") = False

        dr_aux.Item("serie") = dr.Item("serie")
        dr_aux.Item("SerieFel") = dr.Item("SerieFel")
        dr_aux.Item("NumeroFel") = dr.Item("NumeroFel")
        dr_aux.Item("documento") = dr.Item("documento")
        dr_aux.Item("empresa") = dr.Item("empresa")
        dr_aux.Item("tipodocto") = dr.Item("tipodocto")
        dr_aux.Item("correlativo") = dr.Item("correlativo")
        dr_aux.Item("numero") = dr.Item("numero")
        dr_aux.Item("fecha") = dr.Item("fecha")
        dr_aux.Item("codlegal") = dr.Item("codlegal")
        dr_aux.Item("ctacte") = dr.Item("ctacte")
        dr_aux.Item("nombre_cliente") = dr.Item("nombre_cliente")
        dr_aux.Item("direccion") = dr.Item("direccion")
        dr_aux.Item("telefono") = dr.Item("telefono")
        dr_aux.Item("RefTipoDocto") = dr.Item("RefTipoDocto")
        dr_aux.Item("RefCorrelativo") = dr.Item("RefCorrelativo")
        dr_aux.Item("RefNumero") = dr.Item("NumeroRef")
        dr_aux.Item("RefFecha") = dr.Item("fechaRef")
        dr_aux.Item("vigencia") = dr.Item("vigencia")
        dr_aux.Item("exento") = dr.Item("exento")
        dr_aux.Item("PorcDescuento") = dr.Item("PorcDescuento")
        dr_aux.Item("comentario") = dr.Item("comentario")
        dr_aux.Item("Bodega") = dr.Item("bodega")
        dr_aux.Item("Vendedor") = dr.Item("vendedor")
        dr_aux.Item("Numero_Pedido") = dr.Item("numero_pedido")
        dr_aux.Item("Numero_PedidoWM") = dr.Item("numero_pedidoWM")
        dr_aux.Item("TipoDoctoOrigen") = dr.Item("TipoDoctoOrigen")
        dr_aux.Item("forma_pago") = dr.Item("codigoPago")
        dr_aux.Item("ComentarioFace") = dr.Item("ComentarioFACE")

        'Cuando la facturacion sea en dolares
        '(c) 20180117
        If dr.Item("moneda").ToString = "1" Then
            dr_aux.Item("total") = dr.Item("total")
        Else
            dr_aux.Item("total") = dr.Item("totalIngreso")
        End If

        Try
            If dr.Item("FACE").ToString.Trim.Length > 0 Then
                dr_aux.Item("serieFACE") = dr.Item("FACE").ToString.Split(" ")(0).Trim
                dr_aux.Item("numeroFACE") = dr.Item("FACE").ToString.Split(" ")(1)
            End If
        Catch ex As Exception

        End Try
        dr_aux.Item("procesado") = 0
        Try
            If dr.Item("TipoDocto").ToString.ToUpper = "PEDIDO FACE" Or dr.Item("TipoDocto").ToString.ToUpper = "PEDIDO WALMART" Then
                dr_aux.Item("MaquinaFACE") = 1
            ElseIf dr.Item("TipoDocto").ToString.ToUpper = "PEDIDO FACE RE" Then
                dr_aux.Item("MaquinaFACE") = 2
            End If
        Catch ex As Exception

        End Try

        dr_aux.Item("ImpresoraFace") = dr.Item("impresora")
        dr_aux.Item("comuna") = dr.Item("comuna")
        dr_aux.Item("estado") = dr.Item("estado")

        Try
            dr_aux.Item("Numero_Recepcion_Walmart") = dr.Item("numero_recepcion_walmart").ToString
        Catch ex As Exception

        End Try

        '(c) 20180105 Tipo de Venta
        Try
            dr_aux.Item("tipoVenta") = dr.Item("tipoVenta").ToString
        Catch ex As Exception

        End Try

        '(c) 20180105 Tipo de Venta
        ''aqui
        Try
            dr_aux.Item("moneda") = dr.Item("moneda").ToString
            dr_aux.Item("tasa") = dr.Item("paridad").ToString
        Catch ex As Exception

        End Try

        ''Debo llamar al SP para que calcule el impuesto de distribucion
        '(c) 20150911
        Try
            Dim lsSQL As String
            Dim clsgen As New ClasesGenerales.General
            lsSQL = "spa_AddImptoDistribDetalle '" & dr_aux.Item("empresa").ToString & "','" & dr_aux.Item("TipoDocto") & "'," & dr_aux.Item("correlativo")
            '  clsgen.insertQuery("FlexLine", lsSQL)
            clsgen = Nothing
        Catch ex As Exception

        End Try


        'Llenar UsuarioModif
        '(c) 20190117
        Try
            dr_aux.Item("usuarioModif") = dr.Item("UsuarioModif").ToString

        Catch ex As Exception

        End Try

        Try

            If dr.Table.Columns.Contains("Listaprecio") = True Then

                If dr.Item("Listaprecio") IsNot DBNull.Value Then

                    dr_aux.Item("LisPrecio") = dr.Item("Listaprecio")

                Else

                    dr_aux.Item("LisPrecio") = ""

                End If

            End If

            If dr.Table.Columns.Contains("F_FLETE") = True Then

                If dr.Item("F_FLETE") IsNot DBNull.Value Then

                    dr_aux.Item("F_FLETE") = dr.Item("F_FLETE")
                    dr_aux.Item("F_SEGURO") = dr.Item("F_SEGURO")
                    dr_aux.Item("FLETE") = dr.Item("FLETE")
                    dr_aux.Item("SEGURO") = dr.Item("SEGURO")

                End If

            End If

            If dr.Item("SerieFel") IsNot DBNull.Value Then

                dr_aux.Item("SerieFel") = dr.Item("SerieFel")
                dr_aux.Item("NumeroFel") = dr.Item("NumeroFel")
                dr_aux.Item("AutFel") = dr.Item("AutFel")
                dr_aux.Item("FechaAutFel") = dr.Item("FechaAutFel")
                dr_aux.Item("NitFactFel") = dr.Item("NitFactFel")

                'dr_aux.Item("Serie") = dr.Item("documento")
                dr_aux.Item("SerieFace") = dr.Item("SerieFace")
                dr_aux.Item("NumeroAutFace") = dr.Item("numeroFEL1")
                dr_aux.Item("FechaFace") = dr.Item("FechaFace")
                dr_aux.Item("NoAutFel") = dr.Item("NoAutFel")
                dr_aux.Item("NoSerieFel") = dr.Item("NoSerieFel")

            End If

        Catch ex As Exception

        End Try

        odsFACE.Tables("pedidos").Rows.Add(dr_aux)

    End Sub

    Private Sub PedidosPendientesFEL(ByRef psEmpresa As String, ByRef psFecha As Date, ByRef odsFACE As DataSet, ByRef psFechaAdicional As Date)

        Dim oTrans As Transaccional.Conexion

        Dim clGen As New ClasesGenerales.General
        clGen.gsNombreInicialLog = "log_" & gs_empresa
        Dim oTabla As DataTable
        Dim tFacturasExcentas As DataTable = New DataTable

        Dim dr As DataRow
        Dim ls_sqltxt As String
        Dim ldfechaInicial As Date = psFecha
        Dim ldDiferenciaTotal As Double = 0

        odsFACE.Tables("pedidos").Rows.Clear()
        ls_sqltxt = "pa_sel_um_tipodocumento_FelPura_tmk '" & psEmpresa & "','" & psFecha & "','" & psFecha & "',0"

        clGen.Escribir_Log(ls_sqltxt & "1")
        oTrans = New Transaccional.Conexion("flexline")

        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)

            oTabla.DefaultView.RowFilter = "documento like 'factura'"

            For Each drv As DataRowView In oTabla.DefaultView

                agregarPedidoPendiente(drv.Row, odsFACE)

            Next

            oTabla.DefaultView.RowFilter = "documento like 'credito'"

            For Each drv As DataRowView In oTabla.DefaultView

                agregarPedidoPendiente(drv.Row, odsFACE)

            Next

            oTabla.DefaultView.RowFilter = ""
            oTabla.DefaultView.RowFilter = "documento like 'debito'"

            For Each drv As DataRowView In oTabla.DefaultView

                agregarPedidoPendiente(drv.Row, odsFACE)

            Next

            'El SP devuelve tambien los pedidos que ya tienen su documento FEL en Flexline
            'y no siempre trae SerieFel; se marcan aqui para que no se vuelvan a certificar
            MarcarPedidosConDocumentoFel(oTrans, psEmpresa, odsFACE)

            ls_sqltxt = "pa_var_um_detalle_FelPURA '" & ldfechaInicial & "','" & psFecha & "','" & psEmpresa & "'"

            If odsFACE.Tables.Contains("detalle_pedidos") Then

                odsFACE.Tables.Remove(odsFACE.Tables.Item("detalle_pedidos"))

            End If

            oTabla = oTrans.Obtiene(ls_sqltxt)

            oTabla.TableName = "detalle_pedidos"

            odsFACE.Tables.Add(oTabla.Copy)

            clGen.Escribir_Log("Registros " & odsFACE.Tables("pedidos").Rows.Count)

        Catch ex As Exception

            clGen.Escribir_Log("Send_EnviosPendientesFace " & ex.ToString)

        Finally

            oTrans.close()
            oTrans = Nothing
            clGen = Nothing

        End Try

    End Sub

    Private Function SerieFelDePedido(psTipoDocto As String) As String

        Select Case psTipoDocto.Trim().ToUpper()
            Case "PEDIDO FEL TMK"
                Return "FEL TMK"
            Case "PEDIDO FEL AUTOCONSUMO TMK"
                Return "FEL AUTOCONSUMO TMK"
            Case Else
                Return ""
        End Select

    End Function

    Private Sub MarcarPedidosConDocumentoFel(oTrans As Transaccional.Conexion, psEmpresa As String, odsFACE As DataSet)

        Dim lNumeros As New System.Collections.Generic.List(Of String)

        For Each dr As DataRow In odsFACE.Tables("pedidos").Rows

            If Convert.ToString(dr("SerieFel")).Trim() = "" AndAlso
               SerieFelDePedido(Convert.ToString(dr("tipodocto"))) <> "" Then

                lNumeros.Add("'" & Convert.ToString(dr("numero")).Replace("'", "''") & "'")

            End If

        Next

        If lNumeros.Count = 0 Then Exit Sub

        Dim lsSQL As String =
            "SELECT tipodocto, numero FROM flexline.documento " &
            "WHERE empresa = '" & psEmpresa.Replace("'", "''") & "' " &
            "AND tipodocto IN ('FEL TMK', 'FEL AUTOCONSUMO TMK') " &
            "AND numero IN (" & String.Join(",", lNumeros) & ")"

        Dim dtFel As DataTable = oTrans.Obtiene(lsSQL)

        If dtFel Is Nothing OrElse dtFel.Rows.Count = 0 Then Exit Sub

        For Each dr As DataRow In odsFACE.Tables("pedidos").Rows

            Dim lSerie As String = SerieFelDePedido(Convert.ToString(dr("tipodocto")))
            Dim lNumero As String = Convert.ToString(dr("numero")).Replace("'", "''")

            If lSerie = "" OrElse Convert.ToString(dr("SerieFel")).Trim() <> "" Then Continue For

            If dtFel.Select("tipodocto = '" & lSerie & "' AND numero = '" & lNumero & "'").Length > 0 Then

                dr("SerieFel") = lSerie

                If Convert.ToString(dr("NumeroFel")).Trim() = "" Then
                    dr("NumeroFel") = dr("numero")
                End If

            End If

        Next

    End Sub

    Private Function LlavePedido(dr As DataRow) As String

        Return Convert.ToString(dr("tipodocto")).Trim().ToUpper() & "|" & Convert.ToString(dr("numero")).Trim()

    End Function

    Private Function TotalesIguales(psTotal1 As String, psTotal2 As String) As Boolean

        Dim d1, d2 As Decimal

        If Decimal.TryParse(psTotal1, d1) AndAlso Decimal.TryParse(psTotal2, d2) Then
            Return Math.Abs(d1 - d2) <= 0.01D
        End If

        Return psTotal1.Trim() = psTotal2.Trim()

    End Function

    Private Function FormatoTotal(psTotal As String) As String

        Dim d As Decimal

        If Decimal.TryParse(psTotal, d) Then Return d.ToString("N2")

        Return psTotal

    End Function

    Private Sub Busqueda_Documentos()

        Dim lFecha = New Date(dtFecha.Value.Year, dtFecha.Value.Month, dtFecha.Value.Day)
        PedidosPendientesFEL(gs_empresa, lFecha, lDsFel, lFecha)

        lDsFel.Tables("pedidos").DefaultView.RowFilter = "tipodocto = 'PEDIDO FEL TMK' OR tipodocto = 'PEDIDO FEL AUTOCONSUMO TMK'"
        gvPedidos.DataSource = lDsFel.Tables("pedidos").DefaultView

        For Each col As DataGridViewColumn In gvPedidos.Columns

            col.ReadOnly = True
            col.Visible = False

        Next

        gvPedidos.Columns("Enviar").ReadOnly = False
        gvPedidos.Columns("Enviar").Visible = True
        gvPedidos.Columns("SerieFel").Visible = True
        gvPedidos.Columns("NumeroFel").Visible = True
        gvPedidos.Columns("fecha").Visible = True
        gvPedidos.Columns("numero").Visible = True
        gvPedidos.Columns("correlativo").Visible = True
        gvPedidos.Columns("codlegal").Visible = True
        gvPedidos.Columns("nombre_cliente").Visible = True
        gvPedidos.Columns("ComentarioFace").Visible = True

        gvPedidos.Columns("Enviar").Visible = True
        gvPedidos.Columns("SerieFel").HeaderText = "Serie FEL"
        gvPedidos.Columns("NumeroFel").HeaderText = "Numero FEL"
        gvPedidos.Columns("fecha").HeaderText = "Fecha creacion"
        gvPedidos.Columns("numero").HeaderText = "Numero Flex"
        gvPedidos.Columns("correlativo").HeaderText = "Correlativo Flex"
        gvPedidos.Columns("codlegal").HeaderText = "NIT"
        gvPedidos.Columns("nombre_cliente").HeaderText = "Cliente"
        gvPedidos.Columns("ComentarioFace").HeaderText = "Comentarios FEL"

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnObtener_Click(sender As Object, e As EventArgs) Handles btnObtener.Click

        Busqueda_Documentos()

    End Sub

    Private Sub frmPedidoCreditoTmk_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not System.IO.Directory.Exists("C:\FEL") Then

            Try

                System.IO.Directory.CreateDirectory("C:\FEL")

            Catch ex As Exception

            End Try

        End If

        If Not System.IO.Directory.Exists(My.Settings.Default.DirFel) Then

            Try

                System.IO.Directory.CreateDirectory(My.Settings.Default.DirFel)

            Catch ex As Exception

            End Try

        End If

        Crear_estructuraFel(lDsFel)

    End Sub

    Private Sub btnGenerarTXTNC_Click(sender As Object, e As EventArgs) Handles btnGenerarTXTNC.Click

        If lDsFel Is Nothing OrElse Not lDsFel.Tables.Contains("detalle_pedidos") OrElse gvPedidos.DataSource Is Nothing Then

            MessageBox.Show("Primero debe obtener los documentos.", "FEL")
            Exit Sub

        End If

        Dim lDsFelSel As New DataSet
        Dim lTblPedidos As DataTable
        Dim lTblDetPedidos As DataTable
        Dim oEnvioFel As New Umbral.FelInFile.ProcesarFel

        'Confirmar el ultimo checkbox editado antes de leer la seleccion
        gvPedidos.EndEdit()

        'Guardar la seleccion del usuario (solo marcados y sin Serie FEL) con el total que vio en pantalla
        Dim lSeleccion As New System.Collections.Generic.Dictionary(Of String, String)

        For Each dr As DataGridViewRow In gvPedidos.Rows

            Dim lEnviar As Object = dr.Cells("Enviar").Value

            If TypeOf lEnviar Is Boolean AndAlso CBool(lEnviar) AndAlso
               Convert.ToString(dr.Cells("SerieFel").Value).Trim() = "" Then

                Dim lDrv As DataRowView = CType(gvPedidos.DataSource, DataView)(dr.Index)
                Dim lLlave As String = LlavePedido(lDrv.Row)

                If Not lSeleccion.ContainsKey(lLlave) Then
                    lSeleccion.Add(lLlave, Convert.ToString(lDrv.Row("Total")))
                End If

            End If

        Next

        If lSeleccion.Count = 0 Then

            MessageBox.Show("No hay documentos seleccionados pendientes de certificar.", "FEL")
            Exit Sub

        End If

        'Volver a generar la informacion desde la base de datos para no enviar
        'datos desactualizados si el pedido se modifico despues de Obtener
        Busqueda_Documentos()

        If lDsFel Is Nothing OrElse Not lDsFel.Tables.Contains("detalle_pedidos") Then

            MessageBox.Show("No se pudo actualizar la informacion de los documentos. Intente nuevamente.", "FEL")
            Exit Sub

        End If

        lTblPedidos = lDsFel.Tables("pedidos").Clone()
        lTblDetPedidos = lDsFel.Tables("detalle_pedidos").Copy()

        Dim lCambios As New System.Text.StringBuilder
        Dim lOmitidos As New System.Text.StringBuilder

        For Each lLlave As String In lSeleccion.Keys

            Dim lDrActual As DataRow = Nothing

            For Each dr As DataRow In lDsFel.Tables("pedidos").Rows
                If LlavePedido(dr) = lLlave Then
                    lDrActual = dr
                    Exit For
                End If
            Next

            Dim lNumero As String = lLlave.Split("|"c)(1)

            If lDrActual Is Nothing Then

                lOmitidos.AppendLine("  " & lNumero & ": ya no aparece como pendiente")
                Continue For

            End If

            If Convert.ToString(lDrActual("SerieFel")).Trim() <> "" Then

                lOmitidos.AppendLine("  " & lNumero & ": ya tiene documento " & Convert.ToString(lDrActual("SerieFel")))
                Continue For

            End If

            Dim lTotalAntes As String = lSeleccion(lLlave)
            Dim lTotalAhora As String = Convert.ToString(lDrActual("Total"))

            If Not TotalesIguales(lTotalAntes, lTotalAhora) Then
                lCambios.AppendLine("  " & lNumero & ": " & FormatoTotal(lTotalAntes) & " -> " & FormatoTotal(lTotalAhora))
            End If

            lTblPedidos.ImportRow(lDrActual)

        Next

        'Mantener marcados en pantalla los que se van a enviar
        For Each dr As DataGridViewRow In gvPedidos.Rows

            Dim lDrv As DataRowView = CType(gvPedidos.DataSource, DataView)(dr.Index)

            If lSeleccion.ContainsKey(LlavePedido(lDrv.Row)) AndAlso
               Convert.ToString(lDrv.Row("SerieFel")).Trim() = "" Then
                dr.Cells("Enviar").Value = True
            End If

        Next

        If lTblPedidos.Rows.Count = 0 Then

            MessageBox.Show("No hay documentos pendientes de certificar." & vbCrLf & lOmitidos.ToString(), "FEL")
            Exit Sub

        End If

        Dim lMensaje As String = "Esta seguro de certificar " & lTblPedidos.Rows.Count & " documento(s)?"

        If lCambios.Length > 0 Then
            lMensaje = "Los siguientes pedidos cambiaron desde que se obtuvieron; se certificaran con el total actual:" &
                vbCrLf & lCambios.ToString() & vbCrLf & lMensaje
        End If

        If lOmitidos.Length > 0 Then
            lMensaje = "No se enviaran:" & vbCrLf & lOmitidos.ToString() & vbCrLf & lMensaje
        End If

        If (MessageBox.Show(lMensaje, "FEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then

            Exit Sub

        End If

        lDsFelSel.Tables.Add(lTblPedidos)
        lDsFelSel.Tables.Add(lTblDetPedidos)

        oEnvioFel.EnviarDteInfile(lDsFelSel, My.Settings.Default.DirFel)

        'Sincornizar documento
        Try

        Catch ex As Exception

        End Try

        Busqueda_Documentos()

    End Sub

    Private Sub chkSelTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelTodos.CheckedChanged

        If gvPedidos.Rows.Count > 0 Then

            If chkSelTodos.Checked Then

                'Solo se marcan los pendientes; los que ya tienen Serie FEL no se reenvian
                For Each rw As DataGridViewRow In gvPedidos.Rows

                    rw.Cells(0).Value = (Convert.ToString(rw.Cells("SerieFel").Value).Trim() = "")

                Next

            ElseIf chkSelTodos.Checked = False Then

                For Each rw As DataGridViewRow In gvPedidos.Rows

                    rw.Cells(0).Value = False

                Next

            End If

        Else

            chkSelTodos.Checked = False

        End If

    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click

        'If gi_tipo_usuario = 1 Then

        If MessageBox.Show("Desea anular la factura seleccionada?", "Anular factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim lDsFelSel As New DataSet
            Dim oFlex As New Transaccional.Conexion("Flexline")
            Dim lTblPedidos As DataTable = lDsFel.Tables("pedidos").Copy()
            Dim lTblDetPedidos As DataTable = lDsFel.Tables("detalle_pedidos").Copy()
            Dim lDvFelSel As DataView
            Dim oEnvioFel As New Umbral.FelInFile.ProcesarFel

            lTblPedidos.Rows.Clear()

            lDvFelSel = gvPedidos.DataSource

            For Each dr As DataGridViewRow In gvPedidos.Rows

                If dr.Cells(0).Value = True And dr.Cells(1).Value <> "" Then

                    lTblPedidos.ImportRow(lDvFelSel(dr.Index).Row)

                End If

            Next

            lDsFelSel.Tables.Add(lTblPedidos)
            lDsFelSel.Tables.Add(lTblDetPedidos)

            Dim lMotivo As String = InputBox("Ingrese el motivo de anulacion:")

            If lMotivo.Length > 0 Then

                Dim oAnular As New Umbral.FelInFileCreditos.AnularFel

                If oAnular.AnularDoctoInFile(lDsFelSel, lMotivo, My.Settings.Default.DirFel) Then

                    oFlex.open()
                    Dim lSql As String = "pa_upd_anula_pedidos_tmk '" & gs_empresa & "', 'FEL TMK', " & lDsFelSel.Tables(0).Rows(0)("correlativo") & ", '" & lDsFelSel.Tables(0).Rows(0)("numero") & "'"
                    oFlex.Actualiza(lSql)

                    If oFlex.Codigo_error = 0 Then

                        MessageBox.Show("Documento anulado correctamente.", "Factura al credito")

                    End If

                    'MessageBox.Show("Documento anulado correctamente.", "Factura al credito")

                Else

                    MessageBox.Show("El documento no pudo anularse.", "Factura al credito")

                End If

            End If

        End If

        Busqueda_Documentos()

        'End If

    End Sub

    Private Sub btnReimpresionNC_Click(sender As Object, e As EventArgs) Handles btnReimpresionNC.Click

        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut.pnNumeroCopias = Me.nupCopias_fel.Value
        Try

            Dim lsDirectorio As String = "c:\temp\" & gs_empresa & "\" & Me.dtFecha.Value.ToString("yyyyMM") & "\" & Me.dtFecha.Value.ToString("ddMMyyyy")


            If Not Directory.Exists(lsDirectorio) Then
                System.IO.Directory.CreateDirectory(lsDirectorio)
            End If

            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("")
            Dim ppath_reporte As String = clsGen.Path_Reporte
            '023:

            'ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas codicasa.rpt"

            pm_parametros(0) = "empresa"
            pm_parametros(1) = "tipodocto"
            pm_parametros(2) = "numero"
            pm_parametros(3) = "user_name"

            lDsFel.Tables("pedidos").DefaultView.RowFilter = "enviar = True"
            For Each drv As DataRowView In lDsFel.Tables("pedidos").DefaultView

                pm_valores(0) = gs_empresa
                pm_valores(1) = IIf(drv.Item("tipodocto").ToString() = "PEDIDO FEL TMK", "FEL TMK", "FEL AUTOCONSUMO TMK")
                pm_valores(2) = drv.Item("numero")
                pm_valores(3) = gs_usuario

                ppath_reporte = clsGen.Path_Reporte


                ppath_reporte += "Finanzas\Facturacion\Guatefacturas vinoteca FEL.rpt"

                _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
                                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                False, False, "PDF", False, "", True, Me.nupCopias_fel.Value)

            Next

        Catch ex As Exception
        Finally
            'lDsFel.Tables("pedidos").DefaultView.RowFilter = "tipodocto = '" & dboTipoDocto.SelectedValue & "'"
            Oaut = Nothing
            clsGen = Nothing
        End Try






    End Sub

End Class