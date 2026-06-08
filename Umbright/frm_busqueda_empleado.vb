Public Class frm_busqueda_empleado
    Public ficha, nombre, empresa, fecha_ingreso, fecha_fin, depto, puesto, estado As String

    Private Sub frm_busqueda_empleado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Operadores()
        txt_buscar.Focus()

    End Sub

    Private Sub Llenar_Operadores()
        Me.cmb_campo.Items.Add("Nombre")
        Me.cmb_campo.Items.Add("Apellido")
        Me.cmb_campo.Items.Add("Ficha")
        Me.cmb_campo.Text = Me.cmb_campo.Items(0).ToString


    End Sub

    Private Sub txt_buscar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_buscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            Hacer_Filtro()
        End If
    End Sub

    Private Sub Hacer_Filtro()
        Dim oTrans As New Transaccional.Conexion("Flexline")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim index As Integer
        Dim dt As DataTable

        Try
            oTrans.open()
            ls_sql = "pa_sel_per_datos_empleados NULL,"
            If txt_buscar.Text.Length > 0 Then
                If cmb_campo.Text = "Nombre" Then ls_sql = ls_sql & "'" & txt_buscar.Text & "'"
                If cmb_campo.Text = "Apellido" Then ls_sql = ls_sql & "NULL,'" & txt_buscar.Text & "'"
                If cmb_campo.Text = "Ficha" Then ls_sql = ls_sql & "NULL,NULL,'" & txt_buscar.Text & "'"

            End If

            dt = oTrans.Obtiene(ls_sql)
            dgv_empleados.DataSource = dt
            ClsGen.Alinear_GridView(dt, dgv_empleados, "", ",cod_depto,fecha_inicio,vigencia,", "", "", False, True, 255, 0)

            'Marco de Rojo los productos No Vigentes
            For Each row As DataGridViewRow In dgv_empleados.Rows

                If (dgv_empleados.Item("vigencia", index).Value).ToString = "INACTIVO" Then
                    dgv_empleados.Rows(index).DefaultCellStyle.ForeColor = Color.Red

                End If
                index += 1
            Next

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub dgv_empleados_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv_empleados.DoubleClick
        ficha = (dgv_empleados.Item("ficha", dgv_empleados.CurrentRow.Index).Value.ToString)
        nombre = (dgv_empleados.Item("nombres", dgv_empleados.CurrentRow.Index).Value.ToString) & " " & (dgv_empleados.Item("apellidos", dgv_empleados.CurrentRow.Index).Value.ToString)
        empresa = (dgv_empleados.Item("empresa", dgv_empleados.CurrentRow.Index).Value.ToString)
        fecha_ingreso = (dgv_empleados.Item("fecha_inicio", dgv_empleados.CurrentRow.Index).Value.ToString)
        fecha_fin = (dgv_empleados.Item("fecha_termino", dgv_empleados.CurrentRow.Index).Value.ToString)
        depto = (dgv_empleados.Item("depto", dgv_empleados.CurrentRow.Index).Value.ToString)
        puesto = (dgv_empleados.Item("cargo", dgv_empleados.CurrentRow.Index).Value.ToString)
        estado = (dgv_empleados.Item("vigencia", dgv_empleados.CurrentRow.Index).Value.ToString)

        Me.Close()

    End Sub

End Class