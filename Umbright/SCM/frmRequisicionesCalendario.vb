Public Class frmRequisicionesCalendario
    Public pbOpcion As Boolean = False

    Private Sub rbRepeticiones_CheckedChanged(sender As Object, e As EventArgs) Handles rbRepeticiones.CheckedChanged
        If rbRepeticiones.Checked = True Then
            Me.bgRepeticiones.Visible = True
            Me.bgFecha.Visible = False
        Else
            Me.bgRepeticiones.Visible = False
            Me.bgFecha.Visible = True
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        pbOpcion = True
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Me.Close()
    End Sub
End Class