Public Class frmRequisicionesProducto
    Dim Ods As DataSet


    Private Sub llenarCombos()

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable


        Try
            Otrans.open()
            lsSQL = "pa_sel_um_gen_tabcod null,'REQ_TIPO','LOGISERV'"
            dt = Otrans.Obtiene(lsSQL)
            dt.TableName = "tipo"
            Ods.Tables.Add(dt.Copy)

            Me.cmbTipo.DataSource = Ods.Tables("tipo")
            Me.cmbTipo.ValueMember = "TEXTO"
            Me.cmbTipo.DisplayMember = "CODIGO"

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub
    Private Sub llenarProductos()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            Otrans.open()
            lsSQL = "pa_sel_um_producto"
            dt = Otrans.Obtiene(lsSQL)
            dt.TableName = "listado"

            If Ods.Tables.Contains("listado") Then Ods.Tables.Remove("listado")

            Ods.Tables.Add(dt.Copy)
            Me.dgvListado.DataSource = Ods.Tables("listado")
            ClsGen.Alinear_GridView(Ods.Tables("listado"), dgvListado, ",producto,glosa,tipoproducto,", "", "", "", "", "", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing

        End Try
    End Sub


    Private Sub validarDescripcion()
        Dim lsFiltro As String = String.Empty
        Dim clsGen As New ClasesGenerales.General
        Try

            For Each palabra As String In Me.txtDescripcion.Text.Split(" ")
                If lsFiltro.Trim.Length > 0 And palabra.Trim.Length > 3 Then lsFiltro += " OR "

                If palabra.Trim.Length > 3 Then lsFiltro += "(glosa like '%" & palabra.Trim & "%')"

                'cubos de precios
                '
            Next
            Ods.Tables("listado").DefaultView.RowFilter = lsFiltro
            MessageBox.Show("Verifique Que Su Producto No Este En El Listado", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.btnGrabar.Enabled = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub guardarProducto()
        Dim lsSQL As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("SCM")

        Try
            Otrans.open()
            lsSQL = "pa_var_um_producto_codigo '" & Me.cmbTipo.Text & "'"
            dt = Otrans.Obtiene(lsSQL)
            Me.txtCodigo.Text = dt.Rows(0).Item("codigo").ToString.PadLeft(10, "0")

            lsSQL = "pa_ins_um_producto 'LOGISERV','" & Me.txtCodigo.Text.Trim & "','" & Me.txtDescripcion.Text.ToUpper & "','" & Me.cmbTipo.Text & "','" & gs_usuario & "'"
            Otrans.Ingresa(lsSQL)

            If Otrans.Codigo_error = 0 Then
                MessageBox.Show("Informacion Ingresada Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.llenarProductos()
                Me.txtCodigo.Text = String.Empty
                Me.txtDescripcion.Text = String.Empty
                Me.btnGrabar.Enabled = False
            End If




        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub


    Private Sub frmRequisicionesProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Ods = New DataSet
        llenarCombos()
        llenarProductos()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectionChangeCommitted
        Me.txtCodigo.Text = Me.cmbTipo.SelectedValue.ToString
        Me.btnGrabar.Enabled = False
    End Sub

    Private Sub txtDescripcion_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescripcion.Leave
        Me.txtCodigo.Text = Me.cmbTipo.SelectedValue.ToString

    End Sub


    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        Me.btnGrabar.Enabled = False
    End Sub

    Private Sub btnValidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidar.Click
        validarDescripcion()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Me.txtDescripcion.Text.Length > 5 Then
            Me.guardarProducto()
        End If

    End Sub
End Class