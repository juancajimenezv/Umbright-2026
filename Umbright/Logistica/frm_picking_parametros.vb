Imports System.Windows.Forms
Public Class parametrosPicking
    Private tiempo As Integer = 1800000
    Private cantidad As Integer = 5
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim asignar As New asignarUsuarioPicking()
        asignar.asignarPicking(cantidad)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Dim asignar As New asignarUsuarioPicking()
        'asignar.asignarPicking(cantidad)
    End Sub

    Private Sub frm_PruebaAsignarUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Interval = tiempo
        Timer1.Enabled = True
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        cantidad = Integer.Parse(TextBox2.Text.ToString) + 1
        tiempo = Integer.Parse(TextBox1.Text.ToString) * 60 * 1000
    End Sub
End Class