Public Class frm_productos_derivados
    Dim ods As DataSet

    Private Sub Crear_Estructura()
        ods = New DataSet

        Dim dt = New DataTable("derivados")
        dt.Columns.Add(New DataColumn("padre", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("unidades", GetType(Double)))
        'dt.Columns("producto").Unique = True


        ods.Tables.Add(dt)


    End Sub

    Private Sub Llenar_Informacion_Derivado()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("Umbralsa")
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow
        Dim ClsGen As New ClasesGenerales.General

        Try
            Otrans.open()


            ls_sql = "pa_sel_um_producto_derivado '" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)

            For Each dr_aux In dt.Rows
                dr = ods.Tables("derivados").NewRow
                dr.Item("padre") = dr_aux.Item("producto_padre")
                dr.Item("producto") = dr_aux.Item("producto")
                dr.Item("glosa") = dr_aux.Item("glosa")
                dr.Item("unidades") = dr_aux.Item("unidades")
                dr.Item("estado") = 1

                ods.Tables("derivados").Rows.Add(dr)

            Next
            Me.dgv_derivados.DataSource = ods.Tables("derivados")
            ClsGen.Alinear_GridView(ods.Tables("derivados"), Me.dgv_derivados, "", ",estado,padre,", "", "", True, True, 300, 0)
            For Each dc As DataGridViewColumn In Me.dgv_derivados.Columns
                If dc.Name.ToString.ToLower.StartsWith("unidades") Then
                    dc.DefaultCellStyle.Format = "n4"
                End If
            Next


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub Llenar_Informacion()

        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("Umbralsa")
        Dim dt As DataTable

        Dim ClsGen As New ClasesGenerales.General

        Try
            Otrans.open()
            ls_sql = "pa_var_um_producto_derivado_padre '" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "padres"
            If ods.Tables.Contains("padres") Then
                ods.Tables.Remove("padres")
            End If
            ods.Tables.Add(dt.Copy)

            Me.dgv_padres.DataSource = ods.Tables("padres")

            ClsGen.Alinear_GridView(ods.Tables("padres"), Me.dgv_padres, "", ",empresa,", "", "", True, True, 250, 0)

           
        Catch ex As Exception
        Finally
            ClsGen = Nothing
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub Mostrar_Detalle()
        Dim nrow As Integer
        Dim ls_producto As String




        Try
            nrow = Me.dgv_padres.CurrentCell.RowIndex
            Me.txt_producto_vista.Text = Me.dgv_padres.Item("producto", nrow).Value
            Me.txt_glosa_vista.Text = Me.dgv_padres.Item("glosa", nrow).Value

            ls_producto = Me.dgv_padres.Item("producto", nrow).Value
            ods.Tables("derivados").DefaultView.RowFilter = "padre = '" & ls_producto & "'"

        Catch ex As Exception
        End Try

    End Sub

    Private Function BuscarProducto(ByVal pcodigo As String) As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As New DataTable
        Dim ls_sql As String
        Dim nombre_producto As String = ""

        Try
            Otrans.open()
            ls_sql = "pa_sel_um_producto '" & gs_empresa & "','" & pcodigo & "'"
            dt = Otrans.Obtiene(ls_sql)
            nombre_producto = dt.Rows(0).Item("glosa").ToString

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        Return dt
    End Function

    Private Sub Actualizar_Derivados()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("Umbralsa")
        ods.Tables("derivados").DefaultView.RowFilter = "padre = '" & Me.txt_producto_vista.Text & "'"
        Dim lberrores As Boolean = True

        Try
            Otrans.open()
            ls_sql = "pa_del_um_producto_derivado '" & gs_empresa & "','" & Me.txt_producto_vista.Text & "'"
            Otrans.Elimina(ls_sql)

            For Each drv As DataRowView In ods.Tables("derivados").DefaultView
                ls_sql = "pa_ins_um_producto_derivado '" & gs_empresa & "','" & drv.Item("producto") & "','" & _
                        Me.txt_producto_vista.Text & "'," & drv.Item("unidades")
                Otrans.Ingresa(ls_sql)
                If Otrans.Codigo_error > 0 Then
                    lberrores = False
                    MessageBox.Show("Problemas Al Actualizar " & drv.Item("glosa") & " -- " & Otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Next
            If lberrores Then
                MessageBox.Show("Informacion Almacenada con Exito", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub Grabar_Cambios_Padres()
        Dim dr As DataRow


        Try
            dr = ods.Tables("padres").NewRow
            dr.Item("empresa") = gs_empresa
            dr.Item("producto") = Me.txt_producto.Text
            dr.Item("glosa") = Me.txt_glosa.Text

            ods.Tables("padres").Rows.Add(dr)


        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub frm_productos_derivados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Crear_Estructura()
        Llenar_Informacion()
        Llenar_Informacion_derivado()
        Mostrar_Detalle()
        Me.TabControl1.SelectedTab = Me.TabPage2
    End Sub

    Private Sub dgv_padres_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgv_padres_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dgv_derivados_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_derivados.CellContentClick

    End Sub


    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_glosa_vista.TextChanged

    End Sub

    Private Sub dgv_derivados_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_derivados.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex



        Try

            Dim c As Control = Me.dgv_derivados.EditingControl

            Select Case Me.dgv_derivados.Columns(e.ColumnIndex).Name.ToLower.Substring(0, 5)
                Case "produ"

                    Dim dt As DataTable
                    If c.Text = "+" Then
                        'Levantar la busqueda
                        Dim frm_busqueda As New frm_busqueda_general
                        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
                        frm_busqueda.parametros = "glosa,producto,tipoproducto,familia"
                        frm_busqueda.nombre_vista = "v_um_producto_busqueda"
                        frm_busqueda.lista_campos = "producto, glosa, tipoproducto, familia, subfamilia, tipo "
                        frm_busqueda.txt_buscar1.Focus()
                        frm_busqueda.ShowDialog(Me)

                        c.Text = frm_busqueda.resultado
                        frm_busqueda.Dispose()
                        frm_busqueda = Nothing
                        dt = BuscarProducto(c.Text)
                    Else
                        dt = BuscarProducto(c.Text)
                    End If
                    If dt.Rows.Count = 1 Then
                        Me.dgv_derivados.Item("producto", e.RowIndex).Value = c.Text
                        Me.dgv_derivados.Item("glosa", e.RowIndex).Value = dt.Rows(0).Item("Glosa").ToString
                        Me.dgv_derivados.Item("padre", e.RowIndex).Value = Me.txt_producto_vista.Text
                    Else
                        If c.Text.Length > 1 Then
                            MessageBox.Show("Producto No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.dgv_derivados.Item("glosa", e.RowIndex).Value = ""
                            Me.dgv_derivados.Item("padre", e.RowIndex).Value = Me.txt_producto_vista.Text
                        End If
                    End If
                    Try
                        Me.dgv_derivados.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.LightSalmon

                    Catch ex As Exception
                    End Try
            End Select



        Catch ex As Exception

        End Try
    End Sub


    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If MessageBox.Show("Esta Seguro de Actualizar el Producto ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Actualizar_Derivados()
        End If
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        If MessageBox.Show("Esta Seguro de Actualizar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Grabar_Cambios_Padres()
        End If

    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Dim dt As DataTable
        Me.txt_glosa.Text = ""
        If Me.txt_producto.Text.Length > 0 Then
            dt = BuscarProducto(Me.txt_producto.Text)
            If dt.Rows.Count = 1 Then
                Me.txt_glosa.Text = dt.Rows(0).Item("glosa")
            End If
        End If
        If Me.txt_glosa.Text.Length = 0 Then
            Dim frm_busqueda As New frm_busqueda_general
            frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
            frm_busqueda.parametros = "glosa,producto,tipoproducto,familia"
            frm_busqueda.nombre_vista = "v_um_producto_busqueda"
            frm_busqueda.lista_campos = "producto, glosa, tipoproducto, familia, subfamilia, tipo "
            frm_busqueda.txt_buscar1.Focus()
            frm_busqueda.ShowDialog(Me)
            Me.txt_producto.Text = frm_busqueda.resultado
            frm_busqueda.Dispose()
            frm_busqueda = Nothing
            dt = BuscarProducto(Me.txt_producto.Text)
            If dt.Rows.Count = 1 Then
                Me.txt_glosa.Text = dt.Rows(0).Item("glosa")
            End If

        End If

    End Sub


    Private Sub dgv_padres_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_padres.DoubleClick
        Mostrar_Detalle()
        Me.TabControl1.SelectedTab = Me.TabPage1
    End Sub

    Private Sub txt_producto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_producto.LostFocus
        If txt_producto.Text.Length = 10 Then
            Dim dt As DataTable = BuscarProducto(Me.txt_producto.Text)
            If dt.Rows.Count = 1 Then
                Me.txt_glosa.Text = dt.Rows(0).Item("glosa")
            End If
        End If
    End Sub

    Private Sub txt_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_producto.TextChanged

    End Sub

    Private Sub menuAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuAyuda.Click
        Dim ClsGen As New ClasesGenerales.General
        Try
            ClsGen.mostrarAyuda("ProductosDerivados.pdf")

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub txt_producto_vista_TextChanged(sender As Object, e As EventArgs) Handles txt_producto_vista.TextChanged

    End Sub
End Class