Public Class frm_actualizacionProducto

    Dim ods As New DataSet


    Private Sub llenarCombos()
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try

            lsSQL = "Select distinct CODIGO from flexline.gen_tabcod " & _
                " WHERE empresa = '" & gs_empresa & "' and Tipo = 'PRODUCTO.SUBFAMILIA' " & _
                " and coalesce(tipo, '') <> ''  and isnull(vigencia, '') <> 'N' " & _
                " UNION select distinct SubFamilia from flexline.Producto where empresa='" & gs_empresa & "'  order by 1 "

            '            ls_sql = "pa_sel_um_gen_tabcod null,'PRODUCTO.SUBFAMILIA','" & gs_empresa & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            dt.TableName = "cat_SubFamilia"
            ods.Tables.Add(dt.Copy)


            Me.cmbProveedorNuevo.DataSource = ods.Tables("cat_SubFamilia")
            Me.cmbProveedorNuevo.ValueMember = "CODIGO"
            Me.cmbProveedorNuevo.DisplayMember = "CODIGO"

            'marca
            lsSQL = "pa_sel_um_gen_tabcod null,'PRODUCTO.TIPO','" & gs_empresa & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            dt.TableName = "cat_marca"
            ods.Tables.Add(dt.Copy)

            cmbMarcaNueva.DataSource = ods.Tables("cat_marca")
            cmbMarcaNueva.DisplayMember = "Codigo"
            cmbMarcaNueva.ValueMember = "Codigo"


            'hace falta tipo producto
            lsSQL = "pa_sel_um_gen_tabcod null,'PAIS_COMPRA','" & gs_empresa & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            dt.TableName = "cat_procedencia"
            ods.Tables.Add(dt.Copy)

            Me.cmbPaisCompraNuevo.DataSource = ods.Tables("cat_procedencia")
            Me.cmbPaisCompraNuevo.DisplayMember = "Codigo"
            Me.cmbPaisCompraNuevo.ValueMember = "CODIGO"


        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try


    End Sub

    Private Sub llenarProducto()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim dtPersimos As DataTable
        Dim lsFiltro As String = String.Empty

        Try
            dt = clsGen.selectQuery("FlexLine", "pa_sel_um_producto '" & gs_empresa & "',null")

            If gi_tipo_usuario = 1 Then
                dt.DefaultView.RowFilter = "validastock = 'S'"
            Else
                dtPersimos = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_menu_opcion_empresa 16,'" & gs_usuario & "',null,'" & gs_empresa & "'")
                If dtPersimos.Rows.Count > 0 Then
                    dtPersimos.DefaultView.RowFilter = "cod_sub_menu = 40"
                    For Each drPermisos As DataRowView In dtPersimos.DefaultView
                        If lsFiltro.Trim.Length > 0 Then
                            lsFiltro &= " Or "
                        ElseIf lsFiltro.Trim.Length = 0 Then
                            lsFiltro = "("
                        End If


                        lsFiltro &= "BU = '" & drPermisos.Item("descripcion").ToString & "'"

                    Next
                    If lsFiltro.Trim.Length = 0 Then
                        lsFiltro &= "BU"
                    Else
                        lsFiltro &= ")"
                    End If

                Else
                    lsFiltro = "BU"
                End If
                    dt.DefaultView.RowFilter = "validastock = 'S' and " & lsFiltro
                End If
            Me.dgvProducto.DataSource = dt
            clsGen.Alinear_GridView(dt, Me.dgvProducto, ",producto,glosa,subfamilia,tipo,factoralt,analisisproducto4,codbarra,bu,vigente,", "", "", "", ",subfamilia=proveedor,tipo=marca,analisisproducto4=pais_compra,", "", "", True, True, 175, 0)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub mostrarInformacion()
        Dim nrow As Integer
        Try
            nrow = Me.dgvProducto.CurrentRow.Index
            'detalle_pedido(nrow_number)
            Me.txtProducto.Text = Me.dgvProducto.Item("producto", nrow).Value.ToString
            Me.txtGlosaOriginal.Text = Me.dgvProducto.Item("glosa", nrow).Value.ToString
            Me.txtGlosaNueva.Text = Me.dgvProducto.Item("glosa", nrow).Value.ToString
            Me.txtMarcaOriginal.Text = Me.dgvProducto.Item("tipo", nrow).Value.ToString
            Me.cmbMarcaNueva.Text = Me.dgvProducto.Item("tipo", nrow).Value.ToString
            Me.txtProveedorOriginal.Text = Me.dgvProducto.Item("subfamilia", nrow).Value.ToString
            Me.cmbProveedorNuevo.Text = Me.dgvProducto.Item("subfamilia", nrow).Value.ToString
            Me.txtBarraOriginal.Text = Me.dgvProducto.Item("codbarra", nrow).Value.ToString
            Me.txtBarraNueva.Text = Me.dgvProducto.Item("codbarra", nrow).Value.ToString
            Me.txtPaisCompraOriginal.Text = Me.dgvProducto.Item("analisisproducto4", nrow).Value.ToString
            Me.cmbPaisCompraNuevo.Text = Me.dgvProducto.Item("analisisproducto4", nrow).Value.ToString
            Me.txtUxCOriginal.Text = FormatNumber(Me.dgvProducto.Item("factoralt", nrow).Value.ToString, 0)
            Me.txtUxCNueva.Text = FormatNumber(Me.dgvProducto.Item("factoralt", nrow).Value.ToString, 0)
            Me.txtVigenciaOriginal.Text = Me.dgvProducto.Item("vigente", nrow).Value.ToString
            Me.cmbVigenciaNueva.Text = Me.dgvProducto.Item("vigente", nrow).Value.ToString

        Catch ex As Exception

        End Try

    End Sub

    Private Function validarSinStock() As Boolean
        Dim lbSinStock As Boolean = False
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            dt = clsgen.selectQuery("FlexLine", "pa_var_um_existencias_producto '" & gs_empresa & "','" & Me.txtProducto.Text & "'")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.RowFilter = "existencia > 0"
                If dt.DefaultView.Count = 0 Then

                    lbSinStock = True
                Else
                    Dim oform As New frm_resultado
                    oform.dgv_resultado.DataSource = dt
                    oform.Text = ".::. Bodegas con Existencia .::."
                    clsgen.Alinear_GridView(dt, oform.dgv_resultado, "", "", "", "", "", ",empresa=50,", "", True, True, 150, 0)
                    oform.ShowDialog()
                    oform = Nothing
                End If
            Else
                lbSinStock = True
            End If

        Catch ex As Exception
        Finally
            clsgen = Nothing
        End Try

        Return lbSinStock
    End Function

    Private Function validarSinMovimientos() As Boolean
        Dim lbSinMovimientos As Boolean = False
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            dt = clsgen.selectQuery("FlexLine", "pa_var_um_movimientos_producto '" & gs_empresa & "','" & Me.txtProducto.Text & "'")
            If dt.Rows.Count > 0 Then

                Dim oform As New frm_resultado
                oform.dgv_resultado.DataSource = dt
                oform.Text = ".::. Movimientos de Producto .::."
                clsgen.Alinear_GridView(dt, oform.dgv_resultado, "", "", "", "", "", ",empresa=50,", "", True, True, 150, 0)
                oform.ShowDialog()
                oform = Nothing
            Else
                lbSinMovimientos = True
            End If

        Catch ex As Exception
            lbSinMovimientos = False
        Finally
            clsgen = Nothing
        End Try
        Return lbSinMovimientos
    End Function

    Private Function validaCambioBarra() As Boolean
        Dim lbCambioCorrecto As Boolean = False
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            If Me.txtBarraNueva.Text.Length > 0 Then


                dt = clsGen.selectQuery("FlexLine", "pa_var_um_prodcodbarra_glosa '" & gs_empresa & "',null,null,'" & Me.txtBarraNueva.Text & "'")
                If dt.Rows.Count > 0 Then
                    Dim oform As New frm_resultado
                    oform.dgv_resultado.DataSource = dt
                    oform.Text = ".::. Barra Asignada .::."
                    clsGen.Alinear_GridView(dt, oform.dgv_resultado, ",empresa,producto,glosa,", "", "", "", "", ",empresa=50,", "", True, True, 150, 0)
                    oform.ShowDialog()
                    oform = Nothing
                Else
                    lbCambioCorrecto = True
                End If

            Else
                lbCambioCorrecto = True
            End If
        Catch ex As Exception
            lbCambioCorrecto = False

        Finally
            clsGen = Nothing
        End Try
        Return lbCambioCorrecto
    End Function

    Private Sub realizarValidacionGuardar()
        Dim ClsGen As New ClasesGenerales.General

        Try
            ''Vigencia
            If Me.txtVigenciaOriginal.Text <> Me.cmbVigenciaNueva.Text Then

                If Me.cmbVigenciaNueva.Text.ToLower = "n" Then
                    If Not validarSinStock() Then
                        MessageBox.Show("No Se Puede Dar de Baja Por Stock", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End If
            End If

            ''Unidades x Caja
            If Val(Me.txtUxCOriginal.Text) <> Val(Me.txtUxCNueva.Text) Then
                If Not validarSinMovimientos() Then
                    MessageBox.Show("No se Puede Cambiar UxC Por Movimientos de Documentos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                Else
                    If Val(Me.txtUxCNueva.Text) < 1 Then
                        MessageBox.Show("No se Puede Cambiar UxC Por 0", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                End If


            End If

            ''Validar Cambio en Barra
            If Not Me.txtBarraOriginal.Text.Equals(Me.txtBarraNueva.Text) Then
                If txtBarraNueva.Text.Trim.Length > 0 Then

                    If Not validaCambioBarra() Then
                        MessageBox.Show("No se Puede Cambiar Barra Asignado a Otro Producto", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Else
                    If Me.txtBarraNueva.Text.Length = 0 Then
                        If MessageBox.Show("Esta Seguro de Quitar Barra de Producto", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If
                    End If
                End If
            End If



            ''(c) Si llega a esta parte es porque las validaciones se han cumplido

            ''Realizar Cambios por Unidades x Caja
            If Val(Me.txtUxCOriginal.Text) <> Val(Me.txtUxCNueva.Text) Then
                '          ClsGen.insertQuery("FlexLine", "pa_upd_um_producto_uxc '" & gs_empresa & "','" & Me.txtProducto.Text & "','" & Me.txtUxCNueva.Text & "','" & gs_usuario & "'")
            End If

            ''Realizar Cambios de Vigencia
            If Me.txtVigenciaOriginal.Text <> Me.cmbVigenciaNueva.Text Then
                '         ClsGen.insertQuery("FlexLine", "pa_upd_um_producto_vigencia '" & gs_empresa & "','" & Me.txtProducto.Text & "','" & Me.cmbVigenciaNueva.Text & "','" & gs_usuario & "'")
            End If

            ''Realizar Cambios de Codigo de Barra
            If Not Me.txtBarraOriginal.Text.Equals(Me.txtBarraNueva.Text) Then
                ClsGen.insertQuery("FlexLine", "pa_upd_um_producto_barra '" & gs_empresa & "','" & Me.txtProducto.Text & "','" & Me.txtBarraNueva.Text & "','" & gs_usuario & "'")
            End If



            MessageBox.Show("Realizar Cambios")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_actualizacionProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos()
        llenarProducto()
    End Sub

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        llenarProducto()
    End Sub



    Private Sub dgvProducto_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvProducto.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvProducto.Rows(rowIndex)

                If Me.dgvProducto.Item("vigente", rowIndex).Value.ToString.ToLower = "n" Then
                    Me.dgvProducto.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dgvProducto_DoubleClick(sender As Object, e As EventArgs) Handles dgvProducto.DoubleClick
        mostrarInformacion()
    End Sub

    Private Sub dgvProducto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducto.CellContentClick

    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        If MessageBox.Show("Esta Seguro de Aplicar Cambios", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            realizarValidacionGuardar()
        End If
    End Sub

    Private Sub txtUxCNueva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUxCNueva.KeyPress
        'SOLO NUMEROS'
 'SOLO NUMEROS'
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'SOLO LETRAS'
        'If Char.IsLetter(e.KeyChar) Then e.Handled = False ElseIf Char.IsControl(e.KeyChar) Then e.Handled = False ElseIf Char.IsSeparator(e.KeyChar) Then e.Handled = False Else e.Handled = True End If  
    End Sub


End Class