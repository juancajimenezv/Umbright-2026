Public Class frm_analisis20

    Private Sub txt_producto_LostFocus(sender As Object, e As EventArgs) Handles txt_producto.LostFocus
        buscaAnalisis()
        Me.txt_nuevo_analisis.Focus()

    End Sub

    Private Sub buscaAnalisis()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_sel_um_producto_analisis '" & gs_empresa & "','" & Me.txt_producto.Text & "'")
            If dt.Rows.Count > 0 Then
                Me.txt_descripcion.Text = dt.Rows(0)("glosa").ToString
                Me.txt_analisis.Text = dt.Rows(0)("analisisproducto20").ToString


            End If

        Catch ex As Exception

        End Try



    End Sub

    Private Sub txt_producto_TextChanged(sender As Object, e As EventArgs) Handles txt_producto.TextChanged

    End Sub

    Private Sub frm_analisis20_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub limpiaCampos()
        Me.txt_producto.Text = String.Empty
        Me.txt_descripcion.Text = String.Empty
        Me.txt_nuevo_analisis.Text = String.Empty
        Me.txt_analisis.Text = String.Empty
    End Sub
    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        limpiaCampos()
    End Sub

    Private Sub actualizaAnalisis()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String = String.Empty

        Try
            otrans.open()

            ls_sql = "pa_upd_um_analisis20 '" & gs_empresa & "' , '" & Me.txt_producto.Text & "','" & Me.txt_nuevo_analisis.Text & "' "
            otrans.Escribir_Log(ls_sql)
            otrans.Actualiza(ls_sql)
            If otrans.Codigo_error = 0 Then
                MessageBox.Show("Informacion Actualizada Con Exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(otrans.descripcion_error)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If txt_nuevo_analisis.Text.Length < 1 Then
            If MessageBox.Show("El Código no tiene Inner Pack ¿Desea Limpiar?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                actualizaAnalisis()
                limpiaCampos()

            End If
        Else
            If MessageBox.Show("¿Seguro de Actualizar el Inner Pack?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                actualizaAnalisis()
                limpiaCampos()

            End If

        End If
        
    End Sub
End Class