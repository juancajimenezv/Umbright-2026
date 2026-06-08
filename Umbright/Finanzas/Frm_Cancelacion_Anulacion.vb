Public Class Frm_Cancelacion_Anulacion
    'Dim gs_empresa As String = "VINOTECA"
    'Dim gs_usuario As String = "root"

    Private Sub Frm_Cancelacion_Anulacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_Anular_Click(sender As Object, e As EventArgs) Handles btn_Anular.Click
        If Not IsNumeric(tb_Correlativo.Text) Then
            MsgBox("Debe Ingresar Correlativo de Depósito Valido", MsgBoxStyle.Critical, "Correlativo")
            tb_Correlativo.Focus()
            tb_Correlativo.SelectAll()
        ElseIf tb_Motivo.Text.Trim.Length = 0 Then
            MsgBox("Debe Ingresar Motivo de Anulación", MsgBoxStyle.Critical, "Correlativo")
            tb_Motivo.Focus()
        Else
            Anular()
        End If
    End Sub

    Private Sub Anular()
        Dim Utrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dt As New DataTable

        Try

            Utrans.open()
            ls_sql = "pa_vb_Anula_Comprobante_Revisa '" & gs_empresa & "','DEPOSITOS','" & dtp_Fecha.Text & "','" & tb_Correlativo.Text & "'"
            dt = Utrans.Obtiene(ls_sql)

            If dt.Rows.Count = 0 Then
                MsgBox("No Existe Comprobante para Anular", MsgBoxStyle.Critical, "Verifique!!")
                Me.Close()
            Else
                ls_sql = "pa_vb_Anula_Comprobante '" & gs_empresa & "','DEPOSITOS','" & dtp_Fecha.Text & "','" & tb_Correlativo.Text & "','" & tb_Motivo.Text & "','" & gs_usuario & "'"
                Utrans.Obtiene(ls_sql)
                MsgBox("Comprobante Anulado, Revisen en Contabilidad", MsgBoxStyle.Critical, "Anulado")
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error Inesperado!! ", MsgBoxStyle.Critical, "Error")

        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Me.Close()
    End Sub
End Class