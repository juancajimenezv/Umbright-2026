Imports System.Windows.Forms
Public Class frm_PruebaAsignarUsuario

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim asignar As New asignarUsuarioPicking()
        asignar.asignarPicking(5)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        
        Dim asignar As New asignarUsuarioPicking()
        asignar.asignarPicking(4)

    End Sub

    Private Sub frm_PruebaAsignarUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Interval = 1800000
        'Timer1.Interval = 5000
        Timer1.Enabled = True

    End Sub
End Class