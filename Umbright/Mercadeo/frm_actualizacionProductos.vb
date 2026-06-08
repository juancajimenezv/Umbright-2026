Imports System.Windows.Forms

' Form contenedor con dos pestañas: Individual y Masiva.
' Embebe los forms existentes sin modificarlos.
Public Class frm_actualizacionProductos

    Private Sub frm_actualizacionProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EmbebeForm(New frm_actualizacionProductosIE(), tabIndividual)
        EmbebeForm(New frm_actualizacionProductosMasivaIE(), tabMasiva)
    End Sub

    Private Sub EmbebeForm(f As Form, t As TabPage)
        f.TopLevel = False
        f.FormBorderStyle = FormBorderStyle.None
        f.Dock = DockStyle.Fill
        t.Controls.Add(f)
        f.Show()
    End Sub

End Class
