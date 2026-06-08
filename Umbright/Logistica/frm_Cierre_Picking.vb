Imports System.IO


Public Class frm_Cierre_Picking

    Private Sub frm_Cierre_Picking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  Label10.Text = My.Computer.Clock.LocalTime.ToLongTimeString
        Label2.Text = ""
        Label3.Text = ""
        Label9.Text = ""
        Label4.Text = ""
        Label11.Text = Now().ToString
    End Sub



    Private Sub Busca_Picking()
        Dim otrans As New Transaccional.Conexion("FLEXLINE")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()
            lsSQL = "pa_sel_um_Picking_Cierre '" & IIf(Mid(tb_Lectura.Text, 1, 2) = "00", Mid(tb_Lectura.Text, 2, 10), Mid(tb_Lectura.Text, 1, 12)) & "'"
            dt = otrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then

                Label11.Text = dt.Rows(0).Item("nombre_picking")
                Label2.Text = dt.Rows(0).Item("TipoDocto")
                Label3.Text = dt.Rows(0).Item("Numero")
                Label9.Text = dt.Rows(0).Item("fecha_impresion_picking")
                Label4.Text = dt.Rows(0).Item("fecha_finalizacion_picking")
                Timer1.Enabled = True
            Else

                MsgBox("No Existen Datos de Picking, Verifique", MsgBoxStyle.Critical, "No Existe Picking")
                tb_Lectura.Text = ""
                tb_Lectura.Focus()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub tb_Lectura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Lectura.KeyPress
        If e.KeyChar = Chr(13) Then
            Busca_Picking()
        End If
    End Sub

    Private Sub Limpia()
        tb_Lectura.Text = ""
        Label2.Text = ""
        Label3.Text = ""
        Label4.Text = ""
        Label9.Text = ""
        Label11.Text = ""
        Timer1.Enabled = False
        tb_Lectura.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Limpia()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Limpia()
    End Sub

    Private Sub tb_Lectura_TextChanged(sender As Object, e As EventArgs) Handles tb_Lectura.TextChanged

    End Sub
End Class