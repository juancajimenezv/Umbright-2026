Public Class frm_buscar_producto_desarme
    Public glosa As String = ""
    Public producto As String = ""

    Private Sub frm_producto_desarme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Combos()
        Llenar_Listado()

    End Sub

    Private Sub Llenar_Combos()
        Me.cmb_Condicion.Items.Add("=")
        Me.cmb_Condicion.Items.Add(">")
        Me.cmb_Condicion.Items.Add("<")
        Me.cmb_Condicion.Items.Add("like")
        Me.cmb_Condicion.Text = Me.cmb_Condicion.Items(3).ToString

        Me.cmb_Campo.Items.Add("Producto")
        Me.cmb_Campo.Items.Add("Glosa")
        Me.cmb_Campo.Text = Me.cmb_Campo.Items(0).ToString

    End Sub

    Private Sub Llenar_Listado()
        Dim Trans As New Transaccional.Conexion("Flexline")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim index As Integer

        Try
            Trans.open()
            ls_sql = "SELECT * FROM v_um_producto_busqueda WHERE validastock = 's' and empresa = '" & gs_empresa & "'"
            dt = Trans.Obtiene(ls_sql)
            dt.TableName = "productos"
            ds.Tables.Add(dt.Copy)

            dgv_Productos.DataSource = ds.Tables("productos")

            index = 0
            ClsGen.Alinear_GridView(ds.Tables("productos"), dgv_Productos, ",Producto,Glosa,Vigente,", "", "", "", False, True, 255, 0)

            'Marco de Rojo los productos No Vigentes
            For Each row As DataGridViewRow In dgv_Productos.Rows

                If (dgv_Productos.Item("vigente", index).Value).ToString = "N" Then
                    dgv_Productos.Rows(index).DefaultCellStyle.ForeColor = Color.Red

                End If

                index += 1

            Next

        Catch ex As Exception
        Finally
            Trans.close()
            Trans = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub hacerFiltro()
        If Not validarCampos() Then Exit Sub

        Dim MyTrans As New Transaccional.Conexion("FlexLine")
        Dim SQL_tx As String = String.Empty
        Dim dt As New DataTable
        Dim index As New Integer
        Dim clsgen As New ClasesGenerales.General

        MyTrans.open()

        Try
            SQL_tx = "SELECT * FROM v_um_producto_busqueda WHERE validastock = 's' and empresa = '" & gs_empresa & "'"
            If txt_filtro.Text.Length > 0 Then
                SQL_tx += " And " & cmb_Campo.Text & " " & cmb_Condicion.Text & " "

                If cmb_Condicion.Text.ToLower = "like" Then

                    SQL_tx += " '%" & txt_Filtro.Text & "%'"
                Else

                    SQL_tx += " '" & txt_Filtro.Text & "'"
                End If
            End If

            SQL_tx += " Order by producto"
            dt = MyTrans.Obtiene(SQL_tx)

            dgv_productos.DataSource = dt
            clsgen.Alinear_GridView(dt, dgv_Productos, ",producto,glosa,vigente,", "", "", "", False, True, 255, 0)

            'Marco de Rojo los productos No Vigentes
            For Each row As DataGridViewRow In dgv_Productos.Rows

                If (dgv_Productos.Item("vigente", index).Value).ToString = "N" Then
                    dgv_Productos.Rows(index).DefaultCellStyle.ForeColor = Color.Red

                End If
                index += 1
            Next

        Catch ex As Exception
        Finally
            MyTrans.close()
            MyTrans = Nothing
            clsgen = Nothing
        End Try
    End Sub

    Private Function validarCampos() As Boolean
        If cmb_Campo.Text.Trim.Length <= 0 Then
            MessageBox.Show("Aun no ha seleccionado el campor de busqueda.", "Campo de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmb_Campo.Focus()
            Return False
        End If

        If cmb_Condicion.Text.Trim.Length <= 0 Then
            MessageBox.Show("Aun no ha seleccionado el tipo de filtro.", "Tipo Filtro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmb_Condicion.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub txt_buscar1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Filtro.KeyDown
        If e.KeyCode = Keys.Enter Then
            hacerFiltro()
        End If
    End Sub

    Private Sub dgv_Productos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv_Productos.DoubleClick

        glosa = (dgv_Productos.Item("glosa", dgv_Productos.CurrentRow.Index).Value.ToString)
        producto = (dgv_Productos.Item("producto", dgv_Productos.CurrentRow.Index).Value.ToString)

        Me.Close()

    End Sub
End Class