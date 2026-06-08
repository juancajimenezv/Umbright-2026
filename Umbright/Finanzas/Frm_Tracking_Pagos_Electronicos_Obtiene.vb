Public Class Frm_Tracking_Pagos_Electronicos_Obtiene
    Public Lote As String = ""
    Public Cuenta As String = ""
    Public Proveedor As String = ""
    Public Factura As String = ""
    Public Fila As Integer = 0


    Private Sub Frm_Tracking_Pagos_Electronicos_Obtiene_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Obtiene_Lotes()
    End Sub

    Private Sub Obtiene_Lotes()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try

            oTrans.open()


            lsSQL = "flexline.pa_umb_Pagos_Electronicos_Obtiene '" & gs_empresa & "','" & Lote.Trim & "'"
            dt = oTrans.Obtiene(lsSQL)

            dgv_Detalle.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub dgv_Detalle_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_Detalle.RowHeaderMouseClick
        Dim nfila As Integer = dgv_Detalle.CurrentRow.Index

        Fila = nfila
        Lote = dgv_Detalle.Item(0, nfila).Value.ToString
        Cuenta = dgv_Detalle.Item(1, nfila).Value.ToString
        Proveedor = dgv_Detalle.Item(2, nfila).Value.ToString
        Factura = dgv_Detalle.Item(4, nfila).Value.ToString

    End Sub

    Private Sub dgv_Detalle_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgv_Detalle.UserDeletingRow
        If MessageBox.Show("¿Se procederá a Eliminar la Fila " & Fila & ", Esta Seguro(a) " & gs_usuario & " ? Ya que este proceso no Tiene Reversión", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

    End Sub

    Private Sub Elimina()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try

            oTrans.open()


            lsSQL = "flexline.pa_umb_Pagos_Electronicos_Elimina '" & gs_empresa & "','" & Lote.Trim & "','" & Cuenta & "','" & Proveedor & "','" & Factura & "','" & gs_usuario & "'"
            oTrans.Obtiene(lsSQL)

            MsgBox("Fila Eliminada...")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

End Class

