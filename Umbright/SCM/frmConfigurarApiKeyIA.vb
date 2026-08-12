Option Strict Off
Option Explicit On
Option Infer On

''' <summary>
''' Diálogo mínimo para guardar la API Key de Anthropic. El usuario pega el valor en
''' texto plano; aquí se cifra con AnthropicClient.GuardarApiKey (clEmpaquetar/TripleDES)
''' antes de escribirlo en flexline.um_ia_configuracion — nunca se maneja ni se ve en
''' texto plano fuera de este formulario.
''' </summary>
Public Class frmConfigurarApiKeyIA

    Private Sub frmConfigurarApiKeyIA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = RequisicionIA_Estilos.ColorFondo
        lblInstrucciones.ForeColor = RequisicionIA_Estilos.ColorTextoOscuro
        lblInstrucciones.Font = New Font(RequisicionIA_Estilos.NOMBRE_FUENTE, 8.5F)
        txtApiKey.Font = New Font(RequisicionIA_Estilos.NOMBRE_FUENTE, 9.5F)
        RequisicionIA_Estilos.EstilizarBotonPrimario(btnGuardar)
        RequisicionIA_Estilos.EstilizarBotonSuave(btnCancelar)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim clave As String = txtApiKey.Text.Trim()
        If clave.Length = 0 Then
            MessageBox.Show("Ingresa la API Key antes de guardar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            AnthropicClient.GuardarApiKey(gs_empresa, clave)
            MessageBox.Show("API Key guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("No se pudo guardar la API Key: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
