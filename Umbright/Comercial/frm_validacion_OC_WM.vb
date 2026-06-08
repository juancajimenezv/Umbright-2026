Public Class frm_validacion_OC_WM
    Dim ods As New DataSet

    Private Sub llenarPreciosEDI()

        'Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt, dtOrdenes As DataTable
        Try
            'myOtrans.open()
            dtOrdenes = clsGen.ValoresDistinto(ods.Tables("detalle"), "pedido,numero_pedido".Split(","))
            For Each drEncabezado As DataRow In dtOrdenes.Rows
                'lsSQL = "call pa_var_um_edi_pedido_precios ('" & gs_empresa & "','" & _
                '            drEncabezado.Item("pedido").ToString & "','" & _
                '            drEncabezado.Item("numero_pedido").ToString & "')"

                'dt = myOtrans.Obtiene(lsSQL)
                'If dt.Rows.Count = 0 Then
                lsSQL = "pa_var_um_edi_pedido_precios '" & gs_empresa & "','" &
                            drEncabezado.Item("pedido").ToString & "','" &
                            drEncabezado.Item("numero_pedido").ToString & "'"

                    dt = clsGen.selectQuery("Corporativo", lsSQL)
                'End If

                ods.Tables("detalle").DefaultView.RowFilter = "pedido = '" & drEncabezado.Item("pedido") & "' and numero_pedido = '" & drEncabezado.Item("numero_pedido") & "'"

                For Each drv As DataRowView In ods.Tables("detalle").DefaultView
                    dt.DefaultView.RowFilter = "codigoFlex = '" & drv.Item("producto").ToString & "'"
                    If dt.DefaultView.Count > 0 Then
                        drv.Item("precioEdi") = Math.Round(dt.DefaultView(0).Item("costonegociado"), 2, MidpointRounding.AwayFromZero)
                        drv.Item("precioEdi_iva") = Math.Round(drv.Item("precioEdi") * 1.12, 2, MidpointRounding.AwayFromZero)
                    End If
                Next

            Next






            Try
                For Each dr As DataRow In ods.Tables("encabezado").Rows
                    'dr.Item("diferencia") = ods.Tables("detalle").Compute("sum(diferencia*cantidad)", "tipodocto = '" & dr.Item("tipodocto") & "' and numero = '" & dr.Item("numero") & "'")

                    ods.Tables("detalle").DefaultView.RowFilter = "tipodocto = '" & dr.Item("tipodocto") & "' and numero = '" & dr.Item("numero").ToString & "'"
                    Dim ldTotalDiferencia As Double = 0
                    For Each drv As DataRowView In ods.Tables("detalle").DefaultView
                        drv.Item("diferencia") = Math.Abs(drv.Item("precio") - drv.Item("precioEdi_iva"))
                        ldTotalDiferencia += drv.Item("diferencia") * drv.Item("cantidad")

                    Next
                    dr.Item("diferencia") = ldTotalDiferencia
                Next
            Catch ex As Exception

            End Try
            


        Catch ex As Exception
        Finally
            'myOtrans.close()
            'myOtrans = Nothing

            ods.Tables("detalle").DefaultView.RowFilter = ""
        End Try
    End Sub
    Private Sub LlenarOrdenes()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String


        Try
            ods = New DataSet
            lsSQL = "pa_var_um_pedidos_walmart_encabezado '" & gs_empresa & "','" & dtpFechaInicio.Value.ToString("dd/MM/yyyy") & "','" & dtpFechaFinal.Value.ToString("dd/MM/yyyy") & "'"

            dt = clsGen.selectQuery("FlexLine", lsSQL)
            dt.TableName = "encabezado"

            ods.Tables.Add(dt.Copy)
            Me.dgvEncabezado.DataSource = ods.Tables("encabezado")
            clsGen.Alinear_GridView(ods.Tables("encabezado"), Me.dgvEncabezado, ",tipodocto,numero,fecha,cliente,listaprecio,total,comentario1,diferencia,", "", "", "", "", "", "", True, True, 250, 0)


            lsSQL = "pa_var_um_pedidos_walmart_detalle '" & gs_empresa & "','" & dtpFechaInicio.Value.ToString("dd/MM/yyyy") & "','" & dtpFechaFinal.Value.ToString("dd/MM/yyyy") & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            dt.TableName = "detalle"
            ods.Tables.Add(dt.Copy)
            Me.dgvDetalle.DataSource = ods.Tables("detalle")

            clsGen.Alinear_GridView(ods.Tables("detalle"), dgvDetalle, "", ",pedido,numero_pedido,", "", "", ",diferencia=diferencia,PrecioAjustado=precio_flex_S/Iva,precio=precio_flex,precioEdi=Precio_WM_S/Iva,precioEdi_iva=Precio_WM,", "", "", False, True, 250, 0)

            llenarPreciosEdi()
        Catch ex As Exception
        Finally
            clsGen = Nothing
            mostrarDetalle()
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        LlenarOrdenes()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick

    End Sub

    Private Sub mostrarDetalle()
        Dim li_row_number As Integer
        Dim lsFiltro As String

        Try
            li_row_number = Me.dgvEncabezado.CurrentRow.Index
        Catch ex As Exception
            li_row_number = 0
        End Try
        Try

            lsFiltro = "tipodocto = '" & Me.dgvEncabezado.Item("tipodocto", li_row_number).Value.ToString & _
                         "' and numero = '" & Me.dgvEncabezado.Item("numero", li_row_number).Value.ToString & "'"
            ods.Tables("detalle").DefaultView.RowFilter = lsFiltro
        Catch ex As Exception

        End Try


    End Sub

    Private Sub DataGridView2_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvDetalle.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvDetalle.Rows(rowIndex)

                If Math.Abs(Me.dgvDetalle.Item("diferencia", rowIndex).Value) > 0.01 Then
                    Me.dgvDetalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red

                End If


            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEncabezado.CellContentClick

    End Sub

    Private Sub dgvEncabezado_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvEncabezado.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvEncabezado.Rows(rowIndex)

                If Math.Abs(Me.dgvEncabezado.Item("diferencia", rowIndex).Value) > 19.99 Then
                    Me.dgvEncabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red

                End If


            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles dgvEncabezado.Click
        mostrarDetalle()
    End Sub
End Class