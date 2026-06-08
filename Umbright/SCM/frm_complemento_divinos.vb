Public Class frm_complemento_divinos

    Dim ds As New DataSet

    Private Sub crearEstructura()
        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Double)))
        dt.Columns.Add(New DataColumn("preciou", GetType(Double)))
        dt.Columns.Add(New DataColumn("total", GetType(Double)))
        dt.Columns.Add(New DataColumn("factoralt", GetType(Double)))
        dt.Columns.Add(New DataColumn("divinos", GetType(Double))) 'Unidades Divinos
        'dt.Columns.Add(New DataColumn("lote", GetType(String)))
        'dt.Columns.Add(New DataColumn("fecha_vencimiento", GetType(DateTime)))
        'dt.Columns.Add(New DataColumn("maneja_lote", GetType(String)))

        dt.Columns("producto").Unique = True
        dt.TableName = "productos"

        If ds.Tables.Contains("productos") Then ds.Tables.Remove("productos")
        ds.Tables.Add(dt.Copy)

        dt.TableName = "productos_moc"
        If ds.Tables.Contains("productos_moc") Then ds.Tables.Remove("productos_moc")
        ds.Tables.Add(dt.Copy)


        dt = New DataTable("tipo_unidad")
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        If Not ds.Tables.Contains("tipo_unidad") Then ds.Tables.Add(dt.Copy)


    End Sub

    Private Sub LlenarCombos()
        Dim ls_sql As String

        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")

        Try
            otrans.open()

            'ls_sql = "pa_sel_um_gen_tabcod NULL,'IT_VIGENCIA','DMARTE1'"
            'otabla = otrans.Obtiene(ls_sql)
            ''otabla.DefaultView.RowFilter = "codigo <> 'A'"  ''Se podra Anular desde esta opcion (c)22Feb


            'Me.cmbEstadoOCCreditos.DataSource = otabla
            'Me.cmbEstadoOCCreditos.DisplayMember = "DESCRIPCION"
            'Me.cmbEstadoOCCreditos.ValueMember = "CODIGO"


            ls_sql = "pa_sel_um_vi_unidadingreso '" & gs_empresa & "'"
            otabla = otrans.Obtiene(ls_sql)

            For Each dr As DataRow In otabla.Rows

                Dim draux As DataRow = ds.Tables("tipo_unidad").NewRow
                draux.Item("unidad") = dr.Item("unidadingreso")
                ds.Tables("tipo_unidad").Rows.Add(draux)




            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub llenarMaestros()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            oTrans.open()
            lsSQL = "pa_sel_um_tipodocumento '" & gs_empresa & "','pedido (c)'"
            dt = oTrans.Obtiene(lsSQL)
            dt.DefaultView.RowFilter = "aprobacion ='n' and fechavcto = 's'"
            dt = dt.DefaultView.ToTable
            dt.DefaultView.RowFilter = "tipodocto <> 'confirmacion proveedor'"
            dt = dt.DefaultView.ToTable
            dt.TableName = "tipodocto"
            ds.Tables.Add(dt.Copy)

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing

        End Try

    End Sub

    Private Sub Totalizar()
        Try

            Dim total As Double
            total = ds.Tables("productos").Rows.Count
            'Me.txtLineas.Text = total
            total = ds.Tables("productos").Compute("Sum(total)", "total>0")
            'Me.txtValores.Text = total
            total = ds.Tables("productos").Compute("Sum(cantidad)", "cantidad>0")
            'Me.txtUnidades.Text = total
        Catch ex As Exception

        End Try

    End Sub

    Private Sub buscarOrdenCompra()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim draux As DataRow

        Try
            oTrans.open()
            lsSQL = "pa_sel_um_documento_detalle_proveedor 'ORDEN DE COMPRA','" & gs_empresa & "','" & Me.txtNumeroOC.Text & "'"
            dt = oTrans.Obtiene(lsSQL)
            ds.Tables("productos").Rows.Clear()
            Me.dgvProductosOC.DataSource = Nothing

            If dt.Rows.Count > 0 Then
                Dim cantidadAsignada As Integer = dt.Compute("Sum(CantidadAsignada)", "cantidad>0")
                'If cantidadAsignada = 0 Then
                If dt.Rows(0).Item("vigencia").ToString.ToLower = "s" And _
                    dt.Rows(0).Item("aprobacion").ToString.ToLower <> "n" Then      'El documento esta vigente y no esta rechazado
                    ' Me.dtpFechaVencimientoConfirmacion.Value = dt.Rows(0).Item("fechaVcto")
                    'Me.dtpFechaDespacho.Value = dt.Rows(0).Item("fechaDespacho")
                    'Me.txtParidad.Text = dt.Rows(0).Item("paridad").ToString
                    'Me.txtMoneda.Text = dt.Rows(0).Item("moneda").ToString
                    'Me.txtProveedor.Text = dt.Rows(0)("proveedor").ToString

                    For Each dr As DataRow In dt.Rows
                        draux = ds.Tables("productos").NewRow
                        draux.Item("producto") = dr.Item("producto")
                        draux.Item("glosa") = dr.Item("glosa")
                        draux.Item("unidad") = dr.Item("unidadIngreso")
                        draux.Item("cantidad") = dr.Item("cantidadIngreso")
                        draux.Item("preciou") = dr.Item("precioIngreso")
                        draux.Item("total") = dr.Item("subtotalIngreso")
                        draux.Item("divinos") = 0

                        ''(c) 20160721
                        'draux.Item("maneja_lote") = dr.Item("maneja_lote")
                        'draux.Item("lote") = dr.Item("lote")
                        'Try
                        '    draux.Item("fecha_vencimiento") = dr.Item("FechaVctod")
                        'Catch ex As Exception

                        'End Try



                        ds.Tables("productos").Rows.Add(draux)
                    Next

                    Me.dgvProductosOC.DataSource = ds.Tables("productos")

                    Dim dgtbc As New DataGridViewComboBoxColumn
                    dgtbc.DataSource = ds.Tables("tipo_unidad")
                    dgtbc.ValueMember = "unidad"
                    dgtbc.DisplayMember = "unidad"
                    dgtbc.HeaderText = "unidad"
                    dgtbc.DataPropertyName = "unidad"
                    dgtbc.Name = "unidad"

                    clsGen.Alinear_GridViewComboBox(dgtbc)
                    clsGen.Alinear_GridView(ds.Tables("productos"), Me.dgvProductosOC, "", ",factoralt,", ",preciou,unidad,producto,cantidad,glosa,total,maneja_lote,", ",cantidad,preciou,total,", ",divinos=unidades divinos,", "", "", True, True, 250, 0)
                Else

                    If dt.Rows(0).Item("vigencia").ToString.ToLower = "n" Then
                        MessageBox.Show("Esta Orden de Compra No Esta Vigente, Por Favor Verique", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtNumeroOC.Text = String.Empty
                    Else
                        MessageBox.Show("Esta Orden de Compra Esta Anulada o Rechazada, Por Favor Verique", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtNumeroOC.Text = String.Empty
                    End If
                End If
                'Else
                '    MessageBox.Show("Esta Orden de Compra ya Tiene Confirmacion de Proveedor", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Me.txtNumeroOC.Text = String.Empty
                'End If

            Else

                MessageBox.Show("Problemas con Esta Orden de Compra", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtNumeroOC.Text = String.Empty
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Problemas Al Cargar la OC", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oTrans.close()
            oTrans = Nothing
            clsGen = Nothing
            Totalizar()
        End Try

    End Sub

    Private Sub frm_complemento_divinos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        crearEstructura()
        LlenarCombos()
    End Sub

    Private Sub txtNumeroOC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroOC.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txtNumeroOC.Text = Me.txtNumeroOC.Text.PadLeft(10, "0")
            ' CrearEstructura()
            buscarOrdenCompra()
        End If
    End Sub

End Class