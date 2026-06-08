Public Class FrmWait
    Private Sub FrmWait_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FrmWait_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'Me.Left = Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 10
        'Me.Top = 30
        Me.Top = Me.Top + 50
    End Sub
End Class