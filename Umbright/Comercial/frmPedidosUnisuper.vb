Public Class frmPedidosUnisuper

    Dim Ods As New DataSet

    Private Sub crearEstructura()

        Dim dt2 As DataTable
        dt2 = New DataTable("detalleProcesar")
        dt2.Columns.Add(New DataColumn("upc_unisuper", GetType(String)))
        dt2.Columns.Add(New DataColumn("glosa_unisuper", GetType(String)))
        dt2.Columns.Add(New DataColumn("cantidad_unisuper", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("precio_unisuper", GetType(Decimal)))
        dt2.Columns.Add(New DataColumn("total_unisuper", GetType(Decimal)))
        dt2.Columns.Add(New DataColumn("codigo_flexline", GetType(String)))
        dt2.Columns.Add(New DataColumn("glosa_flexline", GetType(String)))
        dt2.Columns.Add(New DataColumn("precio_flexline", GetType(Decimal)))
        dt2.Columns.Add(New DataColumn("total_flexline", GetType(Decimal)))
        dt2.Columns.Add(New DataColumn("procesar", GetType(Boolean)))
        Ods.Tables.Add(dt2)
    End Sub

    Private Sub llenarInformacion()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim dtDetalle As DataTable

        Try
            dt = clsGen.selectQuery("Corporativo", "pa_var_um_unisuper_pedido_encabezado '" & gs_empresa & "','" & Me.dtpFechaInicio.Text & "','" & Me.dtpFechaFinal.Text & "'")
            dt.TableName = "Encabezado"
            If Ods.Tables.Contains("Encabezado") Then Ods.Tables.Remove("Encabezado")
            Ods.Tables.Add(dt.Copy)



            'dt = clsGen.selectQuery("Corporativo", "pa_var_um_orden_compra_detalle_unisuper '" & Me.dtpFechaInicio.Value & "','" & Me.dtpFechaFinal.Value & "'")
            dt = clsGen.selectQuery("Corporativo", "pa_var_um_unisuper_pedido_detalle '" & gs_empresa & "','" & Me.dtpFechaInicio.Text & "','" & Me.dtpFechaFinal.Text & "'")
            dt.TableName = "detalle"
            If Ods.Tables.Contains("detalle") Then Ods.Tables.Remove("detalle")
            Ods.Tables.Add(dt.Copy)



            Me.dgvEncabezado.DataSource = Ods.Tables("encabezado")
            clsGen.Alinear_GridView(Ods.Tables("encabezado"), dgvEncabezado, "", "", "", "", True, True, 250, 0)
            Me.dgvDetalle.DataSource = Ods.Tables("detalle")
            clsGen.Alinear_GridView(Ods.Tables("detalle"), dgvDetalle, "", ",empresa,", ",numero_orden,sku,glosa_unisuper,codigo_flexline,cantidad,glosa_flexine,costo,total,precio_flexine,total_flexline,", "", ",costo=precio_unisuper,", "", "", True, True, 250, 0)



        Catch ex As Exception
        Finally
            clsGen = Nothing
            filtrarEncabezado()
            FiltrarDetalle()
        End Try
    End Sub


    Private Sub FiltrarDetalle()
        Dim ClsGen As New ClasesGenerales.General

        Try
            'Me.txt_total_unidades.Text = "0"
            Me.txtComentario.Text = String.Empty
            Me.txtLineas.Text = String.Empty
            Me.txtUnidades.Text = String.Empty
            Me.txtMonto.Text = String.Empty

            Dim nrow As Integer = Me.dgvEncabezado.CurrentRow.Index

            Ods.Tables("detalle").DefaultView.RowFilter = "cod_pedido = '" & Me.dgvEncabezado.Item("cod_pedido", nrow).Value & "'"
            Me.txtComentario.Text = "OC No." & Me.dgvEncabezado.Item("numero", nrow).Value & ", " & Me.dgvEncabezado.Item("nombre", nrow).Value
            Me.txtLineas.Text = Ods.Tables("detalle").DefaultView.Count
            Me.txtUnidades.Text = Ods.Tables("detalle").DefaultView.ToTable.Compute("sum(cantidad)", "cantidad>0")
            Me.txtMonto.Text = Ods.Tables("detalle").DefaultView.ToTable.Compute("sum(total)", "cantidad>0")
            Me.txtMontoFlexLine.Text = Ods.Tables("detalle").DefaultView.ToTable.Compute("sum(total_flexline)", "cantidad>0")

            dgvDetalle.Columns("cantidad").ReadOnly = False

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

        'Me.Colorear_Grid_detalle(oDataSet.Tables("detalle_pedidos"))
    End Sub






    Private Sub procesarOrden(ByRef psNumero As String)

        Dim cOtrans As New Transaccional.Conexion("Corporativo")
        Dim ls_sql As String
        Dim dt, dt2, dt3, dtCliente As DataTable
        Dim numero_pedido As Integer
        Dim clsGen As New ClasesGenerales.General

        Try
            cOtrans.open()


            Dim nrow As Integer = Me.dgvEncabezado.CurrentRow.Index






            ls_sql = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & Me.dgvEncabezado.Item("ctacte", nrow).Value & "'"
            dtCliente = clsGen.selectQuery("FlexLine", ls_sql)



            ls_sql = "pa_ins_um_mov_pedidos_encabezado '" & gs_empresa & "','" &
                            Now.ToString("ddMMyyyyHHmmss") & "1','" &
                           Me.dgvEncabezado.Item("ctacte", nrow).Value & "','" &
                            dtCliente.Rows(0).Item("CondPago").ToString & "'," &
                            Me.txtMontoFlexLine.Text & "," &
                            Me.txtLineas.Text & ",'" &
                            Now.ToString("dd-MM-yyyy") & "','" & Now.ToString("dd-MM-yyyy") & "','" &
                                 "UNI " & Me.txtComentario.Text & "','" & gs_usuario & "',0,'" & dtCliente.Rows(0).Item("ListaPrecio").ToString & "','" &
                        Me.dgvEncabezado.Item("direccion", nrow).Value & "'"

            cOtrans.Ingresa(ls_sql)
            If cOtrans.Codigo_error = 0 Then
                dt = cOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                numero_pedido = dt.Rows(0).Item("newid").ToString

                Dim LineaLocal As Integer = 0

                Ods.Tables("detalle").DefaultView.RowFilter = "cod_pedido = '" & Me.dgvEncabezado.Item("cod_pedido", nrow).Value & "'"

                For Each drrs As DataRowView In Ods.Tables("detalle").DefaultView

                    If drrs.Item("agregar") = True And drrs.Item("total_flexline") > 0 Then


                        LineaLocal += 1
                        ls_sql = "pa_ins_um_mov_pedidos_detalle_traslado " & numero_pedido & "," &
                                            LineaLocal & ",'" & drrs.Item("codigo_flexline").ToString & "'," &
                                            drrs.Item("cantidad") & "," & drrs.Item("precio_flexline") & "," &
                                            drrs.Item("total_flexline") & ",'','','','',''"
                        cOtrans.Ingresa(ls_sql)
                    End If
                Next



                ls_sql = "pa_upd_mov_pedidos_encabezado_cell " & numero_pedido
                cOtrans.Actualiza(ls_sql)

                ls_sql = "pa_upd_unisuper_pedido_encabezado '" & gs_empresa & "','" & psNumero & "'"
                cOtrans.Actualiza(ls_sql)
                MessageBox.Show("Pedido Generado Correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'limpiarPedido()
                llenarInformacion()
            Else
                MessageBox.Show("El Proceso Genero Errores", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If




        Catch ex As Exception
            cOtrans.Escribir_Log(ex.ToString)
        Finally
            cOtrans.close()
            cOtrans = Nothing

        End Try

    End Sub





    Private Sub frmPedidosUnisuper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        crearEstructura()
        llenarInformacion()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        llenarInformacion()
    End Sub



    Private Sub dgvEncabezado_DoubleClick(sender As Object, e As EventArgs) Handles dgvEncabezado.DoubleClick
        FiltrarDetalle()
    End Sub

    Private Function validarOrden(ByRef lsnumero As String) As Boolean

        Dim lbProcesar As Boolean = False
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim liLineas As Integer = 0

        Try

            dt = clsGen.selectQuery("Corporativo", "pa_sel_um_unisuper_pedido_encabezado '" & gs_empresa & "','" & lsnumero & "'")

            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("procesado") = 0 Then
                    'lbProcesar = True

                    Ods.Tables("detalle").DefaultView.RowFilter = "cod_pedido = '" & lsnumero & "'"
                    For Each drv As DataRowView In Ods.Tables("detalle").DefaultView
                        If drv.Item("precio_flexline").ToString.Length > 0 And drv.Item("agregar") = vbTrue Then
                            liLineas += 1
                        End If
                    Next

                    If liLineas > 0 Then
                        lbProcesar = True
                    End If
                End If
            End If

            If Not lbProcesar Then
                MessageBox.Show("La Orden no se Procesará, valide que tenga lineas a Procesar o que no se haya procesado previamente", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

        Return lbProcesar
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        'validarpedido()
        If MessageBox.Show("Esta Seguro de Guardar el Pedido", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim lsNumero As String

            Dim nrow As Integer = Me.dgvEncabezado.CurrentRow.Index
            lsNumero = Me.dgvEncabezado.Item("cod_pedido", nrow).Value.ToString

            If validarOrden(lsNumero) Then
                procesarOrden(lsNumero)
            End If
        End If

    End Sub

    Private Sub dgvEncabezado_Click(sender As Object, e As EventArgs) Handles dgvEncabezado.Click
        FiltrarDetalle()
    End Sub



    Private Sub dgvEncabezado_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvEncabezado.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvEncabezado.Rows(rowIndex)

                If Me.dgvEncabezado.Item("procesado", rowIndex).Value > 0 Then
                    Me.dgvEncabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub



    Private Sub dgvDetalle_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvDetalle.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex

        Try


            'Me.dg_productos.Columns("vigente").Visible = True
            If rowIndex >= 0 And colIndex = 0 Then
                Dim therow As DataGridViewRow
                therow = Me.dgvDetalle.Rows(rowIndex)
                'If therow.Cells("codigoflex").Value = "0200060334" Then
                '    therow.Cells("codigoflex").Value = "0200060334"
                'End If
                Try
                    If therow.Cells("precio_flexline").Value.ToString.Length = 0 Then
                        therow.DefaultCellStyle.ForeColor = Color.Red
                    End If
                    If therow.Cells("precio_flexline").Value = 0 And therow.Cells("costo").Value > 0 Then
                        therow.DefaultCellStyle.ForeColor = Color.Blue
                    ElseIf therow.Cells("costo").Value - therow.Cells("precio_flexline").Value <= -0.01 Then
                        therow.DefaultCellStyle.ForeColor = Color.Red
                    ElseIf therow.Cells("costo").Value - therow.Cells("precio_flexline").Value >= 0.01 Then
                        therow.DefaultCellStyle.ForeColor = Color.Blue
                    End If
                Catch ex As Exception
                    therow.DefaultCellStyle.ForeColor = Color.Red
                End Try


            End If
            'Me.dg_productos.Columns(0).Width = 10
            'Me.dg_productos.Columns("vigente").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        filtrarEncabezado
    End Sub

    Private Sub filtrarEncabezado()

        Try

            If Me.ComboBox1.SelectedItem.ToLower = "todos" Then
                Ods.Tables("encabezado").DefaultView.RowFilter = ""
            ElseIf Me.ComboBox1.SelectedItem.ToLower = "pendientes" Then
                Ods.Tables("encabezado").DefaultView.RowFilter = "procesado = 0"
            ElseIf Me.ComboBox1.SelectedItem.ToLower = "procesados" Then
                Ods.Tables("encabezado").DefaultView.RowFilter = "procesado = 1"
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvEncabezado_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgvEncabezado.CurrentCellChanged
        FiltrarDetalle()
    End Sub

    Private Sub dgvEncabezado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEncabezado.CellContentClick

    End Sub

    Private Sub dgvDetalle_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellLeave

        ' Dim index = e.RowIndex

        ' recalcularDetalleDgv(index)

    End Sub

    Private Sub recalcularDetalleDgv(index As Integer)
        Dim selectedRow As DataGridViewRow

        If dgvDetalle.Rows.Count >= index Then
            selectedRow = dgvDetalle.Rows(index)

            If Convert.ToDecimal(selectedRow.Cells("Cantidad").Value) < 0 Then

                MsgBox("El Valor no puede ser menor que 0 ", MsgBoxStyle.OkOnly, "Advertencia")
                selectedRow.Cells("Cantidad").Value = "0"
            End If

            If Convert.ToDecimal(selectedRow.Cells("Cantidad").Value) > Convert.ToDecimal(selectedRow.Cells("cantidad_Orden").Value) Then
                MsgBox("El valor no puede ser mayor a la cantidad de la orden", MsgBoxStyle.Exclamation, "Advertencia")
                selectedRow.Cells("Cantidad").Value = selectedRow.Cells("cantidad_Orden").Value
            End If

            ''(c) 20250515
            If selectedRow.Cells("agregar").Value = True Then
                If Math.Abs(selectedRow.Cells("precio_flexline").Value - selectedRow.Cells("costo").Value) >= 0.01 Then
                    selectedRow.Cells("agregar").Value = False
                    MsgBox("No Se Puede Agregar Linea, Existen Diferencias En Precios!!!", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            End If


            selectedRow.Cells("total_flexline").Value = Convert.ToDecimal(selectedRow.Cells("Cantidad").Value) * Convert.ToDecimal(selectedRow.Cells("precio_flexline").Value)
                selectedRow.Cells("total").Value = Convert.ToDecimal(selectedRow.Cells("Cantidad").Value) * Convert.ToDecimal(selectedRow.Cells("costo").Value)
            End If
    End Sub

    Private Sub dgvDetalle_Leave(sender As Object, e As EventArgs) Handles dgvDetalle.Leave



    End Sub

    Private Sub dgvDetalle_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.RowLeave
        ' Dim index = e.RowIndex

        ' recalcularDetalleDgv(index)
    End Sub

    '''Colocar variable para maximo valor por linea
    Dim CantidadRow As Decimal

    Private Sub dgvDetalle_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellValidated
        Dim index = e.RowIndex

        recalcularDetalleDgv(index)
    End Sub

    Private Sub dgvDetalle_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvDetalle.CellValidating


    End Sub

    Private Sub dgvDetalle_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellValueChanged

    End Sub

    Private Sub dgvDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick

    End Sub
End Class