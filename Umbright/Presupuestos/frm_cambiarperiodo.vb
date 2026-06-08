Public Class frm_cambiarperiodo


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click

        If MessageBox.Show("Esta Seguro de Cambiar el Periodo", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            giPeriodo = Me.DateTimePicker1.Value.Year
            System.Configuration.ConfigurationManager.AppSettings("periodo") = giPeriodo
            Me.Close()
        End If
    End Sub


End Class