Public Class frm_int_informacionDI

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.txtDI.Text.Trim.Length > 0 Then
            Me.Close()
        Else
            If MessageBox.Show("Esta Seguro de Continuar, No Hay Informacion de DI", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MessageBox.Show("Esta Seguro de Cancelar", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.txtDI.Text = String.Empty
            Me.Close()
        End If

    End Sub
End Class