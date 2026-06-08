Public Class Frm_Pagos_Electronicos_Menu


    Private Sub pb_Creacion_Click(sender As Object, e As EventArgs) Handles pb_Creacion.Click
        Dim oform As New Frm_Pagos_Electronicos
        oform.Show()
    End Sub

    Private Sub pb_Tracking_Click(sender As Object, e As EventArgs) Handles pb_Tracking.Click
        Dim oform As New Frm_Tracking_Pagos_Electronicos
        oform.Show()
    End Sub
End Class