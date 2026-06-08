Public Class Frm_Suspension_Fechas
    Public FechaI As Date
    Public FechaF As Date

    Private Sub Frm_Suspension_Fechas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_Procesar_Click(sender As Object, e As EventArgs) Handles btn_Procesar.Click
        Generar()
        Me.Close()
    End Sub

    Private Sub Generar()

        If dtp_Inicial.Text > dtp_Inicial.Text Then
            MsgBox("Fechas Incorrectas Verifique!!", MsgBoxStyle.Critical, "Error En Fechas")
            dtp_Inicial.Focus()
        Else
            FechaI = CDate(dtp_Inicial.Text)
            FechaF = CDate(dtp_Final.Text)

        End If
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Me.Close()
    End Sub
End Class