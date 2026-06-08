Imports System.Windows.form
Imports System.ComponentModel

Public Class FrmScript
    Private Sub FrmScript_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub FrmScript_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.GridListaScript.Columns(0).Width = Me.Width - 100
    End Sub

    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
        If bw.IsBusy = False Then bw.RunWorkerAsync()
    End Sub
    Private Sub ProcesarScript()

        Dim otrans As New Transaccional.Conexion(Me.lblServer.Text)

        Try
            otrans.open()

            Panel1.Enabled = False
            Dim aa
            If OpAgregar.Checked = True Then

            End If
            If OpAgregarLimpiar.Checked Then
                If MessageBox.Show("Esta Seguro de Limpiar la Información ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Sub
                End If

                otrans.Elimina("Delete from " & lbltabla.Text)
                If otrans.Codigo_error > 0 Then
                    MessageBox.Show("Se Genero el Siguiente Error, el Proceso se Detendra " & otrans.descripcion_error)
                    Exit Sub
                End If
                'SourceInfo.ExecuteCommand(lblServer.Text, "delete from  " & lbltabla.Text)
            End If

            Bar1.Value = 0
            Bar1.Maximum = GridListaScript.RowCount - 1

            For aa = 0 To GridListaScript.RowCount - 1

                '            If SourceInfo.ExecuteCommand(lblServer.Text, GridListaScript.Item(0, aa).Value) < 1 Then
                otrans.Ingresa(GridListaScript.Item(0, aa).Value)
                'MsgBox(SourceInfo.ExecuteCommand(lblServer.Text, GridListaScript.Item(0, aa).Value))
                '            End If
                Bar1.Value = aa
                'GridListaScript.Item(0, aa).Selected = True
            Next
            GridListaScript.Item(0, GridListaScript.RowCount - 1).Selected = True
            Bar1.Value = 0
            bw.CancelAsync()
            Panel1.Enabled = True
            Me.Close()
            MsgBox(aa & " Registros Insertados")
        Catch ex As Exception

        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblFechahora.Text = Now

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub bw_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bw.DoWork
        ProcesarScript()
    End Sub
End Class