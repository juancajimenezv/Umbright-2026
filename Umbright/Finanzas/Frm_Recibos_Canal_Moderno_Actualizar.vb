Public Class Frm_Recibos_Canal_Moderno_Actualizar
    'Dim gs_empresa As String = "DMARTE1"

    Private Sub Frm_Recibos_Canal_Moderno_Actualizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tb_Monto_Diferencia.Text = "0.00"
    End Sub

    Private Sub Actualizar()
        Dim Utrans As New Transaccional.Conexion("FlexLine")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim tbmonto As String
        Dim tbmontod As Double

        Try
            tbmontod = CDbl(tb_Monto_Diferencia.Text)

            tbmonto = Format(tbmontod, "######0.00")

            Utrans.open()
            ls_sql = "spa_Recibos_Canal_Moderno_Actualiza '" & gs_empresa & "','" & tb_Recibo.Text & "','" & tbmonto & "','" & tb_Comentario.Text & "'"
            Utrans.Ingresa(ls_sql)
            MsgBox("Actualizado Con Exito!!", MsgBoxStyle.MsgBoxSetForeground, "Contabilidad")
            Me.Close()

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error, Verifique el Proceso!! ", MsgBoxStyle.Critical, "Error")

        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub tb_Recibo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Recibo.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not IsNumeric(tb_Recibo.Text) Then
                MsgBox("Debe Ingresar Numero Valido", MsgBoxStyle.Critical, "Numero Recibo")
                tb_Recibo.Focus()
                tb_Recibo.SelectAll()
            Else
                tb_Monto_Diferencia.Focus()
                tb_Monto_Diferencia.SelectAll()
            End If
        End If
    End Sub

    Private Sub tb_Monto_Diferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Monto_Diferencia.KeyPress
        Dim lbmontod As Double

        If e.KeyChar = Chr(13) Then
            If Not IsNumeric(tb_Monto_Diferencia.Text) Then
                MsgBox("Debe Ingresar un Monto Valido", MsgBoxStyle.Critical, "Monto Direrencia")
                tb_Monto_Diferencia.Focus()
            Else
                lbmontod = CDbl(tb_Monto_Diferencia.Text)
                tb_Monto_Diferencia.Text = Format(lbmontod, "#,###,##0.00")

                tb_Comentario.Focus()
            End If
        End If
    End Sub

    Private Sub tb_Comentario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Comentario.KeyPress
        If e.KeyChar = Chr(13) Then
            btn_Actualizar.Focus()
        End If
    End Sub

    Private Sub btn_Actualizar_Click(sender As Object, e As EventArgs) Handles btn_Actualizar.Click
        Desactivar(btn_Actualizar)
        Actualizar()
        Me.Close()
    End Sub

    Sub Desactivar(ByVal Boton As Button)
        Boton.Enabled = False
    End Sub
End Class