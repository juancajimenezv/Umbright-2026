Public Class frm_FinPicking

    Private Sub buscarFactura()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim sEmpresa, sNumero, lsSQL As String
        Dim dt As DataTable

        Try
            Otrans.open()
            If Me.txtBarra.Text.Substring(0, 1) = "1" Then
                sEmpresa = "DMARTE1"
            ElseIf Me.txtBarra.Text.Substring(0, 1) = "2" Then
                sEmpresa = "CODICASA"
            ElseIf Me.txtBarra.Text.Substring(0, 1) = "3" Then
                sEmpresa = "DIUVA"
            ElseIf Me.txtBarra.Text.Substring(0, 1) = "4" Then
                sEmpresa = "VINOTECA"
            End If

            Me.txtEmpresa.Text = sEmpresa
            Me.txtDocumento.Text = Me.txtBarra.Text.Substring(1, 10)

            lsSQL = "pa_upd_gen_log_documento_tracking_finalizacion_picking '" & Me.txtEmpresa.Text & "','" & Me.txtDocumento.Text & "'"
            Otrans.Actualiza(lsSQL)
            lsSQL = "pa_var_um_gen_log_documento_tracking '" & Me.txtEmpresa.Text & "','" & Me.txtDocumento.Text & "'"
            dt = Otrans.Obtiene(lsSQL)
            If dt.Rows.Count > 1 Then
                Dim oform As New frm_resultado
                oform.dgv_resultado.DataSource = dt
                oform.Text = "Picking Para Este Numero"
                oform.ShowDialog()
                oform.Dispose()

            ElseIf dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                Dim horas As New TimeSpan
                Me.txtCliente.Text = dr.Item("ctacte").ToString & "-" & dr.Item("nombre_cliente")
                Me.txtPicker.Text = dr.Item("nombre_picking")
                Me.txtDocumento.Text = dr.Item("tipodocto") & dr.Item("numero")
                Me.txtInicioPicking.Text = dr.Item("fecha_impresion_picking")
                Me.txtFinalPicking.Text = dr.Item("fecha_finalizacion_picking")
                Me.txtTiempo.Text = dr.Item("minutos")
            End If

        Catch ex As Exception
        Finally
            Me.txtBarra.Text = String.Empty

        End Try
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarra.KeyPress
        If e.KeyChar() = Chr(13) Then
            buscarFactura()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarra.TextChanged

    End Sub
End Class