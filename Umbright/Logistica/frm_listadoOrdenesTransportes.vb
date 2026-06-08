Imports System.IO
Imports System.Linq
Imports OfficeOpenXml
Imports GemBox.Spreadsheet

Public Class frm_listadoOrdenesTransportes
    Dim dtOrdenes, dtOrdenesReimpresion As DataTable
    Dim dtDevoluciones, dtDevolucionesReimpresion As DataTable
    Dim dtFacturacionCosto, dtFacturacionCostoReimpresion As DataTable


    Private Sub BuscarOrdenesWalmartReimpresion()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim lsSQL As String
        Dim dt As DataTable
        Try
            Otrans.open()
            myOtrans.open()

            lsSQL = "pa_var_um_facturas_oc_edifact '" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_final.Value.ToString("dd/MM/yyyy") & "'"
            dtOrdenesReimpresion = Otrans.Obtiene(lsSQL)
            If dtOrdenesReimpresion.Rows.Count > 0 Then
                dtOrdenesReimpresion.Columns.Add(New DataColumn("Imprimir", GetType(Boolean)))
                dtOrdenesReimpresion.Columns.Add(New DataColumn("numero_oc", GetType(String)))
                dtOrdenesReimpresion.Columns.Add(New DataColumn("usuario_impresion", GetType(String)))
                dtOrdenesReimpresion.Columns.Add(New DataColumn("idempresalocal", GetType(String)))


                For Each dr As DataRow In dtOrdenesReimpresion.Rows
                    dr.Item("usuario_impresion") = String.Empty
                    lsSQL = "call pa_var_um_mov_edi_pedido ('" & dr.Item("empresa").ToString & "','" &
                        dr.Item("tipo_pedido").ToString & "','" & dr.Item("numero_pedido").ToString & "')"
                    dt = myOtrans.Obtiene(lsSQL)
                    If dt.Rows.Count > 0 Then
                        dr.Item("numero_oc") = dt.Rows(0).Item("idtransaccion")
                        dr.Item("usuario_impresion") = dt.Rows(0).Item("usuarioimpresion_tr").ToString
                        dr.Item("idempresalocal") = dt.Rows(0).Item("idempresalocal").ToString
                    End If

                Next

                dtOrdenesReimpresion.DefaultView.RowFilter = "len(trim(usuario_impresion)) > 0"
                'dtOrdenes.DefaultView.Sort = "minutos desc"

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
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim lsSQL As String
        Dim dt As DataTable
        Try
            Otrans.open()
            myOtrans.open()

            lsSQL = "pa_var_um_facturas_oc_edifact '" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_final.Value.ToString("dd/MM/yyyy") & "'"
            dtOrdenes = Otrans.Obtiene(lsSQL)
            If dtOrdenes.Rows.Count > 0 Then
                dtOrdenes.Columns.Add(New DataColumn("Imprimir", GetType(Boolean)))
                dtOrdenes.Columns.Add(New DataColumn("numero_oc", GetType(String)))
                dtOrdenes.Columns.Add(New DataColumn("usuario_impresion", GetType(String)))
                dtOrdenes.Columns.Add(New DataColumn("idempresalocal", GetType(String)))

                For Each dr As DataRow In dtOrdenes.Rows
                    dr.Item("usuario_impresion") = String.Empty
                    lsSQL = "call pa_var_um_mov_edi_pedido_wm ('" & dr.Item("empresa").ToString & "','" &
                        dr.Item("tipo_pedido").ToString & "','" & dr.Item("numero_pedido").ToString & "','" & dr.Item("ctacte") & "')"
                    dt = myOtrans.Obtiene(lsSQL)
                    If dt.Rows.Count > 0 Then
                        dr.Item("numero_oc") = dt.Rows(0).Item("idtransaccion")
                        dr.Item("usuario_impresion") = dt.Rows(0).Item("usuarioimpresion_tr").ToString
                        dr.Item("idempresalocal") = dt.Rows(0).Item("idempresalocal").ToString
                    End If

                Next

                dtOrdenes.DefaultView.RowFilter = "len(numero_oc) > 0 and minutos >= " & Me.txt_refrescar.Text & " and len(trim(usuario_impresion)) = 0"
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
            clsGen.Alinear_GridView(dtOrdenesReimpresion, Me.dgvReimpresion, ",imprimir,empresa,giro,tipodocto,numero,bodega,comentarios,numero_oc,ctacte,idempresalocal,", "", ",empresa,giro,tipodocto,numero,bodega,minutos,comentarios,numero_oc,minutos,", "", ",numero_oc=OC_Walmart,", "",
                ",imprimir,empresa,giro,tipodocto,numero,minutos,numero_oc,comentarios,bodega", True, True, 250, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub


    Private Sub alinearGrid()
        Dim clsGen As New ClasesGenerales.General
        Try
            clsGen.Alinear_GridView(dtOrdenes, Me.dgvListado, ",imprimir,empresa,giro,tipodocto,numero,bodega,minutos,comentarios,numero_oc,ctacte,idempresalocal,", "", ",empresa,giro,tipodocto,numero,bodega,minutos,comentarios,numero_oc,", "", ",numero_oc=OC_Walmart,", "", ",imprimir,empresa,giro,tipodocto,numero,minutos,numero_oc,comentarios,bodega", True, True, 250, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub


    Private Sub alinearGridDevoluciones()
        Dim clsGen As New ClasesGenerales.General
        Try
            clsGen.Alinear_GridView(dtDevoluciones, Me.dgv_devoluciones, ",imprimir,empresa,nombre_cliente,tipodocto,numero2,bodega,minutos,comentarios,numero_oc,ctacte,idempresalocal,", ",numero,", ",empresa,nombre_cliente,tipodocto,numero2,bodega,minutos,comentarios,numero_oc,", "", ",numero_oc=OC_Walmart,nombre_cliente=Cliente,numero2=No.,", "", ",imprimir,empresa,nombre_cliente,tipodocto,numero,minutos,numero_oc,comentarios,bodega,", True, True, 250, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Sub imprimirOrdenes()

        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

        Try
            myOtrans.open()
            dtOrdenes.DefaultView.RowFilter = "imprimir = true"
            For Each drv As DataRowView In dtOrdenes.DefaultView
                Imprimir_Ordenes(drv.Item("empresa").ToString, drv.Item("numero_oc").ToString, drv.Item("idempresalocal").ToString)
                myOtrans.Ingresa("call pa_upd_um_edi_pedido_encabezado_trs ('" & drv.Item("Empresa").ToString & "','" & drv.Item("numero_oc").ToString & "','" & gs_usuario & "','" & drv.Item("idempresalocal").ToString & "')")
            Next

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            BuscarOrdenesWalmart()
        End Try
    End Sub

    Private Sub reimprimirOrdenes()

        ' Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

        Try
            ' myOtrans.open()
            dtOrdenesReimpresion.DefaultView.RowFilter = "imprimir = true"
            For Each drv As DataRowView In dtOrdenesReimpresion.DefaultView
                Imprimir_Ordenes(drv.Item("empresa").ToString, drv.Item("numero_oc").ToString, drv.Item("idempresalocal").ToString)
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

    Public Sub Imprimir_Ordenes(ByVal spEmpresa As String, ByVal spOrdendeCompra As String, ByVal cliente_ As String)
        Dim path_reporte As String
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try

            pm_conexion = ClsGen.Parametros_Conexion("Onbase")
            path_reporte = ClsGen.Path_Reporte()
            'path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            path_reporte += "Direccion Comercial\edifact.rpt"
            pm_parametros(0) = "empresa"
            pm_parametros(1) = "cod_pedido"
            pm_parametros(2) = "cliente"


            pm_valores(0) = spEmpresa
            pm_valores(1) = spOrdendeCompra
            pm_valores(2) = cliente_


            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
            '                          pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            '                          True, False, "PDF", False, "", True)

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                            False, True, "PDF", False, "", True)


        Catch ex As Exception
        Finally
            ClsGen = Nothing


        End Try


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
        reimprimirOrdenes()
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


    Private Sub buscardevoluciones()
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim lsSQL As String

        Try
            Otrans.open()

            lsSQL = "pa_var_um_devolucionesP '" & Me.dtp_fecha_inicio_devoluciones.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_final_devoluciones.Value.ToString("dd/MM/yyyy") & "'"
            dtDevoluciones = Otrans.Obtiene(lsSQL)
            If dtDevoluciones.Rows.Count > 0 Then
                dtDevoluciones.Columns.Add(New DataColumn("imprimir", GetType(Boolean)))

                dtDevoluciones.DefaultView.RowFilter = "minutos >= " & Me.txt_refrescarDevoluciones.Text & "  and estadotransporte=1"
                dtDevoluciones.DefaultView.Sort = "minutos desc"

                Me.dgv_devoluciones.DataSource = dtDevoluciones.DefaultView
                alinearGridDevoluciones()
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.buscardevoluciones()
    End Sub
    Private Sub dgv_devoluciones_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_devoluciones.CellPainting
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

    Private Sub txt_refrescarDevoluciones_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_refrescarDevoluciones.LostFocus
        If Val(Me.txt_refrescarDevoluciones.Text) > 30 Or Val(Me.txt_refrescarDevoluciones.Text) < 5 Then
            Me.txt_refrescarDevoluciones.Text = 5
        End If
    End Sub
    Private Sub Imprimir_Devoluciones(ByVal spEmpresa As String, ByVal spOrdendeCompra As String)
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try

            pm_conexion = ClsGen.Parametros_Conexion("vDATASERVER")
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

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                            False, True, "PDF", False, "", True)


        Catch ex As Exception
        Finally
            ClsGen = Nothing


        End Try
    End Sub
    Private Sub imprimirDevoluciones()
        Dim otrans As New Transaccional.Conexion("Flexline")

        Try
            otrans.open()
            dtDevoluciones.DefaultView.RowFilter = "imprimir = true"
            For Each drv As DataRowView In dtDevoluciones.DefaultView
                Imprimir_Devoluciones(drv.Item("empresa").ToString, drv.Item("numero").ToString)
                otrans.Actualiza("pa_upd_um_devolucion_encabezado_trs " & drv.Item("numero").ToString & ",'" & gs_usuario & "'")
            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            buscardevoluciones()

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        imprimirDevoluciones()
    End Sub

    Private Sub alinearGridReimpresionDevoluciones()
        Dim clsGen As New ClasesGenerales.General
        Try
            clsGen.Alinear_GridView(dtDevolucionesReimpresion, Me.dgvReimpresionDevoluciones, ",imprimir,empresa,nombre_cliente,tipodocto,numero2,bodega,comentarios,numero_oc,ctacte,idempresalocal,", "", ",empresa,nombre_cliente,tipodocto,numero,bodega,minutos,comentarios,numero_oc,minutos,", ",numero,", ",numero_oc=OC_Walmart,nombre_cliente=Cliente,numero2=No.,", "",
                ",imprimir,empresa,nombre_cliente,tipodocto,numero2,minutos,numero_oc,comentarios,bodega", True, True, 250, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
    End Sub

    Private Sub buscarDevolucionesReimpresion()
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim lsSQL As String

        Try
            Otrans.open()
            lsSQL = "pa_var_um_devolucionesP '" & Me.dtpReimpresionInicioDevoluciones.Value.ToString("dd/MM/yyyy") & "','" & Me.dtpReimpresionFinalDevoluciones.Value.ToString("dd/MM/yyyy") & "'"
            dtDevolucionesReimpresion = Otrans.Obtiene(lsSQL)
            If dtDevolucionesReimpresion.Rows.Count > 0 Then
                dtDevolucionesReimpresion.Columns.Add(New DataColumn("imprimir", GetType(Boolean)))

                dtDevolucionesReimpresion.DefaultView.RowFilter = "minutos >= " & Me.txt_refrescar_reimpresionDevoluciones.Text & "  and estadotransporte=2"
                '  dtOrdenesReimpresion.DefaultView.Sort = "minutos desc"
                Me.dgvReimpresionDevoluciones.DataSource = dtDevolucionesReimpresion.DefaultView

                alinearGridReimpresionDevoluciones()
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        buscarDevolucionesReimpresion()
    End Sub
    Private Sub reimprimirDevoluciones()
        Try
            ' myOtrans.open()
            dtDevolucionesReimpresion.DefaultView.RowFilter = "imprimir = true"
            For Each drv As DataRowView In dtDevolucionesReimpresion.DefaultView
                Me.Imprimir_Devoluciones(drv.Item("empresa").ToString, drv.Item("numero").ToString)
                'myOtrans.Actualiza("call pa_upd_um_edi_pedido_encabezado_tr ('" & drv.Item("Empresa").ToString & "','" & drv.Item("numero_oc").ToString & "','" & gs_usuario & "')")
            Next
            'dtOrdenesReimpresion.DefaultView.RowFilter = "

        Catch ex As Exception
        Finally
            '    myOtrans.close()
            '   myOtrans = Nothing
            buscarDevolucionesReimpresion()

        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        reimprimirDevoluciones()
    End Sub

    Private Sub alineargridfc()
        Dim clsGen As New ClasesGenerales.General
        Try
            'clsGen.Alinear_GridView(dtOrdenes, Me.dgvListado, ",imprimir,empresa,", ",,", ", ,", "", ",,", "", ",,", True, True, 250, 0)
            clsGen.Alinear_GridView(dtFacturacionCosto, Me.dgvfc, ",imprimir,empresa,nombre_cliente,tipodocto,numero,bodega,minutos,comentarios,numero_oc,ctacte,idempresalocal,", "", ",empresa,nombre_cliente,tipodocto,numero,bodega,minutos,comentarios,numero_oc,", "", ",numero_oc=OC_Walmart,nombre_cliente=Cliente,", "", ",imprimir,empresa,nombre_cliente,tipodocto,numero,minutos,numero_oc,comentarios,bodega,", True, True, 250, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
    End Sub
    Private Sub buscarfc()
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim lsSQL As String

        Try
            Otrans.open()

            lsSQL = "pa_var_um_facturacion_costoP '" & Me.dtpFCinicial.Value.ToString("dd/MM/yyyy") & "','" & Me.dtpFCfinal.Value.ToString("dd/MM/yyyy") & "'"
            dtFacturacionCosto = Otrans.Obtiene(lsSQL)
            If dtFacturacionCosto.Rows.Count > 0 Then
                dtFacturacionCosto.Columns.Add(New DataColumn("imprimir", GetType(Boolean)))

                dtFacturacionCosto.DefaultView.RowFilter = "minutos >= " & Me.txt_refrescarfc.Text & "  and estadotransporte=1"
                dtFacturacionCosto.DefaultView.Sort = "minutos desc"

                Me.dgvfc.DataSource = dtFacturacionCosto.DefaultView
                Me.alineargridfc()

            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        buscarfc()
    End Sub


    Private Sub dgvfc_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvfc.CellPainting
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

    Private Sub imprimir_fc(ByVal spOrdendeCompra As String)
        Dim path_reporte As String
        Dim pm_valores(0) As String
        Dim pm_parametros(0) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try
            pm_conexion = ClsGen.Parametros_Conexion("vDATASERVER")
            path_reporte = ClsGen.Path_Reporte()
            'path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            path_reporte += "Direccion Comercial\FC.rpt"
            pm_parametros(0) = "@CodFactura"
            pm_valores(0) = spOrdendeCompra
            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
            '                          pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            '                          True, False, "PDF", False, "", True)
            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                            False, True, "PDF", False, "", True)

        Catch ex As Exception
        Finally
            ClsGen = Nothing


        End Try
    End Sub
    Private Sub imprimirfc()

        Dim otrans As New Transaccional.Conexion("Flexline")

        Try
            otrans.open()
            dtFacturacionCosto.DefaultView.RowFilter = "imprimir = true"
            For Each drv As DataRowView In dtFacturacionCosto.DefaultView
                imprimir_fc(drv.Item("numero").ToString)
                otrans.Actualiza(" pa_upd_um_factuacion_costo_trs " & drv.Item("numero").ToString)
            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            buscarfc()

        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        imprimirfc()
    End Sub
    Private Sub alinearGridReimpresionFC()
        Dim clsGen As New ClasesGenerales.General
        Try
            clsGen.Alinear_GridView(dtFacturacionCostoReimpresion, Me.DataGridView2, ",imprimir,empresa,nombre_cliente,tipodocto,numero,bodega,comentarios,numero_oc,ctacte,idempresalocal,", "", ",empresa,nombre_cliente,tipodocto,numero,bodega,minutos,comentarios,numero_oc,minutos,", "", ",numero_oc=OC_Walmart,nombre_cliente=Cliente,", "",
                ",imprimir,empresa,nombre_cliente,tipodocto,numero,minutos,numero_oc,comentarios,bodega", True, True, 250, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
    End Sub
    Private Sub buscarfcReimpresion()
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim lsSQL As String

        Try
            Otrans.open()
            lsSQL = "pa_var_um_facturacion_costoP '" & Me.dtFCreimpresionInicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtFCreimpresionFinal.Value.ToString("dd/MM/yyyy") & "'"
            dtFacturacionCostoReimpresion = Otrans.Obtiene(lsSQL)
            If dtFacturacionCostoReimpresion.Rows.Count > 0 Then
                dtFacturacionCostoReimpresion.Columns.Add(New DataColumn("imprimir", GetType(Boolean)))

                dtFacturacionCostoReimpresion.DefaultView.RowFilter = "minutos >= " & Me.txt_refrescarFC_Reimpresion.Text & "  and estadotransporte=2"
                '  dtOrdenesReimpresion.DefaultView.Sort = "minutos desc"

                Me.DataGridView2.DataSource = dtFacturacionCostoReimpresion.DefaultView

                alinearGridReimpresionFC()
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        buscarfcReimpresion()

    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub reimprimirFC()
        ' Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

        Try
            ' myOtrans.open()
            dtFacturacionCostoReimpresion.DefaultView.RowFilter = "imprimir = true"
            For Each drv As DataRowView In dtFacturacionCostoReimpresion.DefaultView
                imprimir_fc(drv.Item("numero").ToString)
                'myOtrans.Actualiza("call pa_upd_um_edi_pedido_encabezado_tr ('" & drv.Item("Empresa").ToString & "','" & drv.Item("numero_oc").ToString & "','" & gs_usuario & "')")
            Next
            'dtOrdenesReimpresion.DefaultView.RowFilter = "

        Catch ex As Exception
        Finally
            '    myOtrans.close()
            '   myOtrans = Nothing
            Me.buscarfcReimpresion()

        End Try
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        reimprimirFC()
    End Sub

    Private Sub btnGenerarCentralizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarCentralizacion.Click
        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable
        Dim dt As DataTable
        Dim drv As DataRowView
        Dim dr, dr_aux As DataRow
        Dim lbProcesar As Boolean
        Dim ls_sqltxt As String
        Dim odsFace As DataSet
        Me.crear_estructuraFACE(odsFace)

        'odsFACE.Tables("pedidos").Rows.Clear()
        ls_sqltxt = "pa_sel_um_tipodocumento_guatefacturaPURA '" & gs_empresa & "','" & Me.dtpInicioCentralizacion.Text & "','" & Me.dtpFinalCentralizacion.Text & "'"
        oTrans = New Transaccional.Conexion("flexline")
        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)

            oTabla.DefaultView.RowFilter = "tipodocto = 'pedido walmart' and vigencia <> 'a'"

            For Each drv In oTabla.DefaultView

                lbProcesar = True


                If lbProcesar Then

                    dr_aux = odsFace.Tables("pedidos").NewRow

                    dr_aux.Item("Enviar") = 0
                    dr_aux.Item("serie") = drv.Item("serie")
                    dr_aux.Item("documento") = drv.Item("documento")
                    dr_aux.Item("empresa") = drv.Item("empresa")
                    dr_aux.Item("tipodocto") = drv.Item("tipodocto")
                    dr_aux.Item("correlativo") = drv.Item("correlativo")
                    dr_aux.Item("numero") = drv.Item("numero")
                    dr_aux.Item("fecha") = drv.Item("fecha")
                    dr_aux.Item("codlegal") = drv.Item("codlegal")
                    dr_aux.Item("ctacte") = drv.Item("ctacte")
                    dr_aux.Item("nombre_cliente") = drv.Item("nombre_cliente")
                    dr_aux.Item("direccion") = drv.Item("direccion")
                    dr_aux.Item("telefono") = drv.Item("telefono")
                    dr_aux.Item("RefTipoDocto") = drv.Item("RefTipoDocto")
                    dr_aux.Item("RefCorrelativo") = drv.Item("RefCorrelativo")
                    dr_aux.Item("RefNumero") = drv.Item("NumeroRef")
                    dr_aux.Item("RefFecha") = drv.Item("fechaRef")
                    dr_aux.Item("vigencia") = drv.Item("vigencia")
                    dr_aux.Item("exento") = drv.Item("exento")
                    dr_aux.Item("PorcDescuento") = drv.Item("PorcDescuento")
                    dr_aux.Item("comentario") = drv.Item("comentario")
                    dr_aux.Item("Bodega") = drv.Item("bodega")
                    dr_aux.Item("Vendedor") = drv.Item("vendedor")
                    dr_aux.Item("Numero_Pedido") = drv.Item("numero_pedido")
                    dr_aux.Item("Numero_PedidoWM") = drv.Item("numero_pedidoWM")
                    dr_aux.Item("TipoDoctoOrigen") = drv.Item("TipoDoctoOrigen")
                    dr_aux.Item("forma_pago") = drv.Item("codigoPago")

                    Try
                        If dr.Item("FACE").ToString.Trim.Length > 0 Then
                            dr_aux.Item("numeroFACE") = drv.Item("FACE").ToString.Split(" ")(1)
                        End If
                    Catch ex As Exception

                    End Try
                    odsFace.Tables("pedidos").Rows.Add(dr_aux)
                End If


            Next


            clGen.Alinear_GridView(odsFace.Tables("pedidos"), Me.dgvCentralizacion, ",forma_pago,bodega,vigencia,tipo_docto,comentario,documento,numero,fecha,codlegal,nombre_cliente,PorcDescuento,", ",exento,numeroFACE,firmaFACE,nitFACE,nombreFACE,direccionFACE,correlativo,enviar,RefTipoDocto,RefCorrelativo,texto2,total,empresa,", ",serie,documento,empresa,tipodocto,correlativo,numero,fecha,codlegal,nombre_cliente,direccion,telefono,vigencia,", "", "", "", "", True, True, 150, 0)

            'ls_sqltxt = "pa_var_um_detalle_guatefacturaPURA '" & Me.dtpInicioCentralizacion.Text & "','" & Me.dtpFinalCentralizacion.Text & "','" & gs_empresa & "'"
            'oTabla = oTrans.Obtiene(ls_sqltxt)
            'oTabla.TableName = "detalle_pedidos"

            'odsFACE.Tables.Add(oTabla.Copy)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        oTrans.close()
        oTrans = Nothing
        clGen = Nothing

        Try
            'detalle_pedidoFACE(0)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AbrirFormatoExcel(ByVal pDir As String)

        Try

            Process.Start("EXCEL.EXE", String.Format("""{0}""", pDir))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnExpWalmart_Click(sender As Object, e As EventArgs) Handles btnExpWalmart.Click

        SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")

        If dgvCentralizacion.Rows.Count = 0 Then

            MessageBox.Show("Debe seleccionar una orden para generar el informe", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub

        End If

        If IsNothing(dgvCentralizacion.CurrentCell) Then

            MessageBox.Show("Debe seleccionar una orden para generar el informe", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub

        End If

        Dim rowIndex As Integer = Me.dgvCentralizacion.CurrentCell.RowIndex

        If (txtPlacasVehiculo.Text = String.Empty) Or (txtNoCita.Text = String.Empty) Or (txtTipoOC.Text = String.Empty) Or (txtNofurgon.Text = String.Empty) Then

            MessageBox.Show("Debe llenar todos los campos del apartado Datos de envio", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub

        End If

        If txtNoCita.Text.Length < 5 Then

            MessageBox.Show("El No de cita debe ser igual o mayor a 5 digitos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub

        End If

        Dim lSql As String = ""
        Dim dtEnvioWM As New DataTable
        Dim oFlex As New Transaccional.Conexion("Flexline")
        Dim oGuardarFormato As New SaveFileDialog()

        oGuardarFormato.Title = "Guardar formato de envio WM"
        oGuardarFormato.Filter = "Archivo Microsoft Excel|*.xls"

        Try

            oFlex.open()

        Catch ex As Exception

            oFlex.Escribir_Log("frm_listadoOrdenesTransportes, Ln:798, Exp: " & ex.Message)
            Exit Sub

        End Try

        lSql = String.Format("pa_var_um_pedidos_wm '{0}', '{1}'", gs_empresa, Me.dgvCentralizacion.Item("numero", rowIndex).Value)
        dtEnvioWM = oFlex.Obtiene(lSql)

        If dtEnvioWM.Rows.Count = 0 Then

            oFlex.Escribir_Log("frm_listadoOrdenesTransportes, Ln:808, Exp: No se encontraron datos de envio")
            Exit Sub

        End If

        If Not System.IO.File.Exists(My.Settings.Default.FormularioEntregaWM) Then

            oFlex.Escribir_Log("frm_listadoOrdenesTransportes, Ln:825, Exp: El archivo especificado en App.config no existe o no se tiene acceso")
            Exit Sub

        End If

        Dim lExcelPkg As ExcelFile = ExcelFile.Load(My.Settings.Default.FormularioEntregaWM)
        Dim lExcelWks As GemBox.Spreadsheet.ExcelWorksheet = lExcelPkg.Worksheets()("Formulario de Entrega")

        If dtEnvioWM.Rows(0)("cliente") = "49067556" Then

            lExcelWks.Cells()("E5").Value = "CENTRO DE DISTRIBUCION AMATITLAN"

        ElseIf dtEnvioWM.Rows(0)("cliente") = "49067552" Then

            lExcelWks.Cells()("E5").Value = "CENTRO DE DISTRIBUCION BARCENAS"

        Else

            lExcelWks.Cells()("E5").Value = "CENTRO DE DISTRIBUCION MIXCO"

        End If

        lExcelWks.Cells()("D6").Value = txtNoCita.Text
        lExcelWks.Cells()("D8").Value = dtEnvioWM.Rows(0)("referenciaexterna")
        lExcelWks.Cells()("D10").Value = txtPlacasVehiculo.Text
        lExcelWks.Cells()("D12").Value = txtNofurgon.Text
        lExcelWks.Cells()("G6").Value = dtHoraCita.Value.ToString("HH:mm:ss")
        lExcelWks.Cells()("G8").Value = txtTipoOC.Text

        If (dtEnvioWM.Rows(0)("cliente") = "49067552") Or (dtEnvioWM.Rows(0)("cliente") = "49067556") Then

            lExcelWks.Cells()("G10").Value = "010085261"

        Else

            lExcelWks.Cells()("G10").Value = ""

        End If

        If gs_empresa = "DMARTE1" Then

            lExcelWks.Cells()("G12").Value = "DISTRIBUIDORA MARTE, S.A."

        ElseIf gs_empresa = "CODICASA" Then

            lExcelWks.Cells()("G12").Value = "COMPAÑIA DE DISTRIBUCION CENTROAMERICANA, S.A."

        ElseIf gs_empresa = "DIUVA" Then

            lExcelWks.Cells()("G12").Value = "DISTRIBUIDORA LA UVA, S.A."

        End If

        Dim lRowNumber As Integer = 21

        For Each lDetRow As DataRow In dtEnvioWM.Rows

            lExcelWks.Cells()(String.Format("B{0}", lRowNumber.ToString())).Value = lDetRow("Plu")
            lExcelWks.Cells()(String.Format("C{0}", lRowNumber.ToString())).Value = lDetRow("VendorStockId")
            lExcelWks.Cells()(String.Format("D{0}", lRowNumber.ToString())).Value = lDetRow("Upc13")
            lExcelWks.Cells()(String.Format("E{0}", lRowNumber.ToString())).Value = lDetRow("Descripcion")
            lExcelWks.Cells()(String.Format("F{0}", lRowNumber.ToString())).Value = Convert.ToDecimal(lDetRow("analisisproducto20"))
            lExcelWks.Cells()(String.Format("G{0}", lRowNumber.ToString())).Value = Math.Round(Convert.ToDecimal(lDetRow("cPedWalm").ToString()) / Convert.ToDecimal(lDetRow("analisisproducto20").ToString()), 2)
            lExcelWks.Cells()(String.Format("H{0}", lRowNumber.ToString())).Value = Math.Round(Convert.ToDecimal(lDetRow("cantidad").ToString()) / Convert.ToDecimal(lDetRow("analisisproducto20").ToString()), 2)

            lRowNumber = lRowNumber + 1

        Next

        lExcelPkg.Calculate()

        If oGuardarFormato.ShowDialog() = DialogResult.OK Then

            Dim lNuevoArchivo As IO.FileInfo = New FileInfo(oGuardarFormato.FileName)
            lExcelPkg.Save(lNuevoArchivo.FullName)

            Try

                lExcelWks = Nothing
                lExcelPkg = Nothing

                'Process.Start("EXCEL.EXE", String.Format("""{0}""", lNuevoArchivo.FullName))

                Dim thAbreFormulario As New Thread(Sub() Me.AbrirFormatoExcel(lNuevoArchivo.FullName))
                thAbreFormulario.Name = "thAbrirExcel_" & New Random().Next(999).ToString()
                thAbreFormulario.Start()
                Thread.Sleep(4000)

            Catch ex As Exception

            End Try

        Else

            MessageBox.Show("Debe especificar el nombre del archivo a guardar", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

        Try

            oFlex.close()

        Catch ex As Exception

            oFlex.Escribir_Log(String.Format("frm_listadoOrdenesTransportes, Ln:910 Msj: No se pudo cerrar la conexion, Exp: {0}", ex.Message))

        End Try

    End Sub

    Private Sub frm_listadoOrdenesTransportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnExpWalmart.Image = My.Resources._32_exportar
    End Sub

    Private Sub btnBuscarTraslado_Click(sender As Object, e As EventArgs) Handles btnBuscarTraslado.Click

        Dim oFlex As New Transaccional.Conexion("Flexline")
        Dim lSql = String.Format("[pa_sel_um_traslado_inventario_transporte] '{0}', '{1}', '{2}'", gs_empresa, dtDelTraslado.Value.ToString("yyyy-MM-dd"), dtAlTraslado.Value.ToString("yyyy-MM-dd"))

        Try

            oFlex.open()
            Dim dtTraslados As New DataTable
            dtTraslados = oFlex.Obtiene(lSql)

            dgTraslados.DataSource = dtTraslados
            dgTraslados.Columns(0).Visible = False

            For Each dr As DataGridViewRow In dgTraslados.Rows

                If dr.Cells(0).Value = 0 Then

                    dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 146, 146)

                End If

            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        If dgTraslados.SelectedRows.Count > 0 Then

            Dim oFlex As New Transaccional.Conexion("Flexline")
            Dim lSql As String = ""

            If MessageBox.Show("Desea imprimir el traslado seleccionado?", "Imprimir traslado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Try

                    oFlex.open()

                    imprimir_traslado(dgTraslados.SelectedRows(0).Cells(2).Value, dgTraslados.SelectedRows(0).Cells(3).Value, dgTraslados.SelectedRows(0).Cells(4).Value)

                    lSql = String.Format("pa_upd_um_traslado_inv '{0}', '{1}'", dgTraslados.SelectedRows(0).Cells(2).Value, dgTraslados.SelectedRows(0).Cells(4).Value)
                    oFlex.Actualiza(lSql)

                Catch ex As Exception

                End Try

            End If

        End If

    End Sub

    Private Sub refrescarPickingConsolidado()
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            lsSQL = "pa_var_um_gen_log_documento_picking_consolidado_lotes_finalizados"
            dt = ClsGen.selectQuery("FlexLine", lsSQL)

            Me.dgvPickingConsolidado.DataSource = dt

            ClsGen.Alinear_GridView(dt, Me.dgvPickingConsolidado, "", "", ",lote,nombre_picking,fecha,doctos,", "", True, True, 250, 0)

        Catch ex As Exception

        Finally
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub btnBuscarConsolidado_Click(sender As Object, e As EventArgs) Handles btnBuscarConsolidado.Click
        refrescarPickingConsolidado()
    End Sub

    Private Sub btnImprmirConsolidado_Click(sender As Object, e As EventArgs) Handles btnImprmirConsolidado.Click

        Dim dt As DataTable
        Dim ClsGen As New ClasesGenerales.General

        Try
            dt = TryCast(Me.dgvPickingConsolidado.DataSource, DataTable)
            dt.DefaultView.RowFilter = "Agregar = True"

            Dim path_reporte As String
            Dim pm_valores(0) As String
            Dim pm_parametros(0) As String
            Dim pm_conexion(3) As String

            Dim lbreturn As Boolean = False

            If dt.DefaultView.Count > 0 Then
                For Each drv As DataRowView In dt.DefaultView


                    Try
                        'Obtengo Datos de Conexion
                        pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
                        path_reporte = ClsGen.Path_Reporte


                        path_reporte += "Logistica\Picking\Picking Detalle On Trade Consolidado.rpt"

                        pm_parametros(0) = "@Identificador"
                        pm_valores(0) = drv.Item("lote").ToString

                        lbreturn = _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                       pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                       False, True, "PDF", True, "", True, 1)



                    Catch ex As Exception
                    Finally
                        ClsGen = Nothing
                    End Try


                Next


            End If


        Catch ex As Exception

        Finally
            ClsGen = Nothing
        End Try
        refrescarPickingConsolidado()
    End Sub

    Private Sub TabPage9_Click(sender As Object, e As EventArgs) Handles TabPage9.Click

    End Sub

    Private Sub btn_ocunisuper_imprimir_Click(sender As Object, e As EventArgs) Handles btn_ocunisuper_imprimir.Click

        Dim dt As DataTable
        Dim ClsGen As New ClasesGenerales.General

        Try


            Dim path_reporte As String
            Dim pm_valores(0) As String
            Dim pm_parametros(0) As String
            Dim pm_conexion(3) As String

            Dim lbreturn As Boolean = False

            'Obtengo Datos de Conexion
            pm_conexion = ClsGen.Parametros_Conexion("bdcorporativo")
            path_reporte = ClsGen.Path_Reporte


                        path_reporte += "Logistica\Trafico\Orden_Compra_Unisuper.rpt"

                        pm_parametros(0) = "@numero"
                        pm_valores(0) = Me.txt_ocunisuper_numero.Text

                        _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                       pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                       False, True, "PDF", True, "", True, 1)





        Catch ex As Exception

        Finally
            ClsGen = Nothing
        End Try

    End Sub

    Private Function crear_estructuraFACE(ByRef odsFace As DataSet)
        Dim dt As DataTable

        odsFace = New DataSet
        dt = New DataTable("pedidos")
        dt.Columns.Add(New DataColumn("Enviar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Serie", GetType(String)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correlativo", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("codlegal", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("Comentario", GetType(String)))
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

        odsFace.Tables.Add(dt)

        Me.dgvCentralizacion.DataSource = odsFace.Tables("pedidos")

    End Function

    Private Sub btnImprimirCentralizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirCentralizacion.Click, Button11.Click

        'Dim colIndex As Integer = Me.dgvCentralizacion.ColumnIndex
        Dim rowIndex As Integer = Me.dgvCentralizacion.CurrentCell.RowIndex
        Dim ClsGen As New ClasesGenerales.General
        Try
            Dim sCita As String = InputBox("Ingrese Cita", "Informacion de Entrega")
            If sCita.Length < 5 Then
                MessageBox.Show("Informacion Incorrecta", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Try
            End If

            Dim pm_valores(3), pm_valores_consolidado(3) As String
            Dim pm_parametros(4) As String
            Dim pm_conexion(4) As String


            pm_conexion = ClsGen.Parametros_Conexion("")
            Dim ppath_reporte As String = ClsGen.Path_Reporte
            '023:

            ppath_reporte = ppath_reporte & "Logistica\Trafico\Formato Entrega Centralizada WalMart.rpt"
            pm_parametros(0) = "cita"
            pm_parametros(2) = "@empresa"
            pm_parametros(3) = "@numero"
            pm_parametros(1) = "usuario"
            pm_valores(0) = sCita
            pm_valores(2) = gs_empresa
            pm_valores(3) = Me.dgvCentralizacion.Item("numero", rowIndex).Value
            pm_valores(1) = gs_usuario

            'Guardo las copias en pdf

            _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores, _
            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                False, True, "PDF", True, "", True, 1)

        Catch ex As Exception

        End Try


    End Sub

    Private Sub imprimir_traslado(ByVal pEmpresa As String, ByVal pTipoDocto As String, ByVal pNumero As String)

        Dim path_reporte As String
        Dim pm_valores(4) As String
        Dim pm_parametros(4) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try
            pm_conexion = ClsGen.Parametros_Conexion("vDATASERVER")
            path_reporte = ClsGen.Path_Reporte()
            ''path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            path_reporte += "Logistica\Bodega\Impresion de Movimientos.rpt"

            'path_reporte = "\\192.192.1.170\reportes$\Logistica\Bodega\Impresion de Movimientos.rpt"

            pm_parametros(0) = "Empresa"
            pm_parametros(2) = "tipoDocto"
            pm_parametros(1) = "Numero"
            pm_valores(0) = pEmpresa
            pm_valores(2) = pTipoDocto
            pm_valores(1) = pNumero
            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
            '                          pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            '                          True, False, "PDF", False, "", True)
            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                            False, True, "PDF", False, "", True)

        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

    End Sub

End Class