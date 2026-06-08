Public Class frm_listadoDevoluciones

    Dim dtOrdenes, dtOrdenesReimpresion As DataTable

    Private Sub BuscarOrdenesWalmartReimpresion()
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim lsSQL As String

        Try
            Otrans.open()
            lsSQL = "pa_var_um_devolucionesP '" & Me.dtpInicioReimpresion.Value.ToString("dd/MM/yyyy") & "','" & Me.dtpFinalReimpresion.Value.ToString("dd/MM/yyyy") & "'"
            dtOrdenesReimpresion = Otrans.Obtiene(lsSQL)
            If dtOrdenesReimpresion.Rows.Count > 0 Then
                dtOrdenesReimpresion.Columns.Add(New DataColumn("imprimir", GetType(Boolean)))

                dtOrdenesReimpresion.DefaultView.RowFilter = "minutos >= " & Me.txt_refrescar.Text & "  and estadotransporte=2"
                '  dtOrdenesReimpresion.DefaultView.Sort = "minutos desc"

                Me.dgvReimpresion.DataSource = dtOrdenesReimpresion.DefaultView

                alinearGridReimpresion()
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub BuscarOrdenesWalmart()
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim lsSQL As String

        Try
            Otrans.open()

            lsSQL = "pa_var_um_devolucionesP '" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_final.Value.ToString("dd/MM/yyyy") & "'"
            dtOrdenes = Otrans.Obtiene(lsSQL)
            If dtOrdenes.Rows.Count > 0 Then
                dtOrdenes.Columns.Add(New DataColumn("imprimir", GetType(Boolean)))

                dtOrdenes.DefaultView.RowFilter = "minutos >= " & Me.txt_refrescar.Text & "  and estadotransporte=1"
                dtOrdenes.DefaultView.Sort = "minutos desc"

                Me.dgvListado.DataSource = dtOrdenes.DefaultView
                alinearGrid()
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub alinearGridReimpresion()
        Dim clsGen As New ClasesGenerales.General
        Try
            clsGen.Alinear_GridView(dtOrdenesReimpresion, Me.dgvReimpresion, ",imprimir,empresa,nombre_cliente,tipodocto,numero,bodega,comentarios,numero_oc,ctacte,idempresalocal,", "", ",empresa,nombre_cliente,tipodocto,numero,bodega,minutos,comentarios,numero_oc,minutos,", "", ",numero_oc=OC_Walmart,nombre_cliente=Cliente,", "", _
                ",imprimir,empresa,nombre_cliente,tipodocto,numero,minutos,numero_oc,comentarios,bodega", True, True, 250, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub


    Private Sub alinearGrid()
        Dim clsGen As New ClasesGenerales.General
        Try
            'clsGen.Alinear_GridView(dtOrdenes, Me.dgvListado, ",imprimir,empresa,", ",,", ", ,", "", ",,", "", ",,", True, True, 250, 0)
            clsGen.Alinear_GridView(dtOrdenes, Me.dgvListado, ",imprimir,empresa,nombre_cliente,tipodocto,numero,bodega,minutos,comentarios,numero_oc,ctacte,idempresalocal,", "", ",empresa,nombre_cliente,tipodocto,numero,bodega,minutos,comentarios,numero_oc,", "", ",numero_oc=OC_Walmart,nombre_cliente=Cliente,", "", ",imprimir,empresa,nombre_cliente,tipodocto,numero,minutos,numero_oc,comentarios,bodega,", True, True, 250, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Sub imprimirOrdenes()


        Dim otrans As New Transaccional.Conexion("Flexline")

        Try
            otrans.open()
            dtOrdenes.DefaultView.RowFilter = "imprimir = true"
            For Each drv As DataRowView In dtOrdenes.DefaultView
                Imprimir_Ordenes(drv.Item("empresa").ToString, drv.Item("numero").ToString)
                otrans.Actualiza(" pa_upd_um_devolucion_encabezado_trs " & drv.Item("numero").ToString)
            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            BuscarOrdenesWalmart()
        End Try
    End Sub

    Private Sub reimprimirOrdenes()

        ' Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

        Try
            ' myOtrans.open()
            dtOrdenesReimpresion.DefaultView.RowFilter = "imprimir = true"
            For Each drv As DataRowView In dtOrdenesReimpresion.DefaultView
                Imprimir_Ordenes(drv.Item("empresa").ToString, drv.Item("numero").ToString)
                'myOtrans.Actualiza("call pa_upd_um_edi_pedido_encabezado_tr ('" & drv.Item("Empresa").ToString & "','" & drv.Item("numero_oc").ToString & "','" & gs_usuario & "')")
            Next
            'dtOrdenesReimpresion.DefaultView.RowFilter = "

        Catch ex As Exception
        Finally
            '    myOtrans.close()
            '   myOtrans = Nothing
            BuscarOrdenesWalmartReimpresion()
        End Try
    End Sub

    Public Sub Imprimir_Ordenes(ByVal spEmpresa As String, ByVal spOrdendeCompra As String)
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try

            pm_conexion = ClsGen.Parametros_Conexion("DATASERVER")
            path_reporte = ClsGen.Path_Reporte()
            'path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            path_reporte += "Direccion Comercial\devoluciones.rpt"
            pm_parametros(0) = "@Pempresa"
            pm_parametros(1) = "@Pcod_devolucion"



            pm_valores(0) = spEmpresa
            pm_valores(1) = spOrdendeCompra



            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
            '                          pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            '                          True, False, "PDF", False, "", True)

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                            False, True, "PDF", False, "", True)


        Catch ex As Exception
        Finally
            ClsGen = Nothing


        End Try


    End Sub

    Private Sub frm_listadoOrdeneWM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar.Click
        BuscarOrdenesWalmart()

    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        imprimirOrdenes()
    End Sub

    Private Sub btnActualizarReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarReimpresion.Click
        BuscarOrdenesWalmartReimpresion()
    End Sub

    Private Sub btnImprimirReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirReimpresion.Click
        reImprimirOrdenes()
    End Sub




    Private Sub dgvListado_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvListado.CellPainting
        'no_pedido,sku,cantidad,uxc,precio,codigoflex,descripcionflex,precioflex,cantidad_facturar,
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex

        Try


            'Me.dg_productos.Columns("vigente").Visible = True
            If rowIndex >= 0 And colIndex = 0 Then
                Dim therow As DataGridViewRow
                therow = Me.dgvListado.Rows(rowIndex)
                'If therow.Cells("codigoflex").Value = "0200060334" Then
                '    therow.Cells("codigoflex").Value = "0200060334"
                'End If
                If therow.Cells("minutos").Value >= 60 Then
                    therow.DefaultCellStyle.ForeColor = Color.Red
                ElseIf therow.Cells("minutos").Value >= 30 Then
                    therow.DefaultCellStyle.ForeColor = Color.Orange
                End If

            End If
            'Me.dg_productos.Columns(0).Width = 10
            'Me.dg_productos.Columns("vigente").Visible = False
        Catch ex As Exception
        End Try


    End Sub

    Private Sub txt_refrescar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_refrescar.LostFocus
        If Val(Me.txt_refrescar.Text) > 30 Or Val(Me.txt_refrescar.Text) < 5 Then
            Me.txt_refrescar.Text = 5
        End If
    End Sub

    Private Sub txt_refrescar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_refrescar.TextChanged

    End Sub
End Class