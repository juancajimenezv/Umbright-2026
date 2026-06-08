Public Class frmRequisicionUsuarioCCosto

    Private Sub llenarCombos()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_sel_um_sg_usuario_todos")
            Me.cmbUsuario.DataSource = dt
            Me.cmbUsuario.ValueMember = "usuario"
            Me.cmbUsuario.DisplayMember = "nombre"



        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub frmRequisicionUsuarioCCosto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
    End Sub
End Class