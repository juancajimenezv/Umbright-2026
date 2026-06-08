Public Class frmRequisicionesProyectos


    Private Sub btnGuardar_Click_1(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Me.btnGuardar.Text = "Guardar" Then
            GuardarProyecto
        ElseIf Me.btnGuardar.Text = "Modificar" Then
        End If
    End Sub

    Private Sub guardarProyecto()
        Dim lsSQL As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("SCM")
        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_var_um_requisicionProyecto_numero")

            If dt.Rows.Count = 1 Then
                lsSQL = "pa_ins_um_requisicionproyecto " & dt.Rows(0).Item("Correlativo") & ",'" & txtNombre.Text & "','" & Me.txtObservaciones.Text & "','" & Me.dtpFechaInicial.Value.ToString("dd/MM/yyyy") & "','" & dtpFechaFinal.Value.ToString("dd/MM/yyyy") & "','" & gs_usuario & "'"
                Otrans.Ingresa(lsSQL)

                If Otrans.Codigo_error = 0 Then
                    MessageBox.Show("Se Guardo Correctamente el Proyecto con el Numero " & dt.Rows(0).Item("correlativo"))
                End If

            End If




        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub llenarCombos()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try

            lsSQL = "flexline.pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)


            Me.cmbEmpresa.DisplayMember = "empresa"
            Me.cmbEmpresa.ValueMember = "empresa"
            Me.cmbEmpresa.DataSource = dt

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

    End Sub

    Private Sub llenarListados()

        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try

            lsSQL = "pa_var_um_requisicionproyectos_listado"
            dt = clsGen.selectQuery("SCM", lsSQL)

            Me.DataGridView1.DataSource = dt



        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
    End Sub

    Private Sub frmRequisicionesProyectos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos()
        llenarListados()
    End Sub
End Class