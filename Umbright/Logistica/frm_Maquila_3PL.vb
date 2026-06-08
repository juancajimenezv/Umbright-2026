Public Class frm_Maquila_3PL
    Public Numero As String
    Public Var1 As String
    Public Var2 As String
    Dim Muestra As String = ""
    Public form As New frm_Maquila_3PL_Producto

    Private Sub frm_Maquila_3PL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Documentos()
        dgv_Detalle.Enabled = False
        btn_Finalizar.Enabled = False
    End Sub

    Private Sub Carga_Documentos()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "pa_sel_um_Documento_3pl 'TODOS'"
            dt = otrans.Obtiene(lsSQL)
            dgv_Documentos.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub dgv_Documentos_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv_Documentos.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_Documentos.Rows(rowIndex)

                If Me.dgv_Documentos.Item("Estado", rowIndex).Value = "EN PROCESO" Then
                    Me.dgv_Documentos.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_Documentos_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_Documentos.RowHeaderMouseDoubleClick
        Dim nfila As Integer = 0
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        TabControl1.SelectedIndex = 1

        Try
            nfila = Me.dgv_Documentos.CurrentRow.Index
            Numero = Me.dgv_Documentos.Item("Numero", nfila).Value.ToString

            Muestra_Detalle()
            'otrans.open()   'abre conexion
            'lsSQL = "pa_sel_um_DocumentoD_3pl '" & Numero & "'"
            'dt = otrans.Obtiene(lsSQL)
            'dgv_Detalle.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Muestra_Detalle()
        Dim nfila As Integer = 0
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()   'abre conexion
            lsSQL = "pa_sel_um_DocumentoD_3pl '" & Numero & "'"
            dt = otrans.Obtiene(lsSQL)
            dgv_Detalle.DataSource = dt

            If dt.Rows.Count = 0 Then
                btn_Finalizar.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub btn_Finalizar_Click(sender As Object, e As EventArgs) Handles btn_Finalizar.Click
        TabControl1.SelectedIndex = 0
        dgv_Detalle.DataSource = Nothing
        Cierre()
        btn_Finalizar.Enabled = False
        btn_Iniciar.Enabled = True
        lb_Inicia.Text = "Inicia"
        lb_Finaliza.Text = "Finaliza"
    End Sub

    Private Sub btn_Iniciar_Click(sender As Object, e As EventArgs) Handles btn_Iniciar.Click
        dgv_Detalle.Enabled = True
        Inicia()
        lb_Inicia.Text = Now().ToString
        btn_Iniciar.Enabled = False
        btn_Finalizar.Enabled = True

    End Sub

    Private Sub Inicia()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "pa_upd_um_documento_3pl_Inicio '" & Numero & "'"
            otrans.Obtiene(lsSQL)

            lsSQL = "pa_sel_um_DocumentoD_3pl '" & Numero & "'"
            dt = otrans.Obtiene(lsSQL)
            dgv_Detalle.DataSource = dt

        Catch ex As Exception

        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Cierre()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "pa_upd_um_documento_3pl_Fin '" & Numero & "'"
            dt = otrans.Obtiene(lsSQL)

            Carga_Documentos()

        Catch ex As Exception

        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub dgv_Detalle_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_Detalle.RowHeaderMouseDoubleClick
        Dim nfila As Integer = 0
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim numero As String = ""
        Dim producto As String = ""
        Dim glosa As String = ""
        Dim cantidad As String = "0"
        Dim maquilar As String = ""

        Try
            nfila = Me.dgv_Detalle.CurrentRow.Index
            'tb_Numero.Text = Me.dgv_Detalle.Item("numero", nfila).Value.ToString
            'tb_Producto.Text = Me.dgv_Detalle.Item("producto", nfila).Value.ToString

            numero = Me.dgv_Detalle.Item("numero", nfila).Value.ToString
            producto = Me.dgv_Detalle.Item("producto", nfila).Value.ToString
            glosa = Me.dgv_Detalle.Item("glosa", nfila).Value.ToString
            cantidad = Format(Me.dgv_Detalle.Item("cantidad", nfila).Value, "###,##0")
            maquilar = Me.dgv_Detalle.Item("comentario", nfila).Value.ToString

            Dim oform As New frm_Maquila_3PL_Producto()
            oform.Numero = numero
            oform.Producto = producto
            oform.Glosa = glosa
            oform.Cantidad = cantidad
            oform.Maquilar = maquilar
            oform.ShowDialog()
            Muestra_Detalle()
            '    otrans.open()   'abre conexion
            '    lsSQL = "pa_sel_um_DocumentoD_3pl '" & Numero & "'"
            '    dt = otrans.Obtiene(lsSQL)
            '    dgv_Detalle.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Muestra_Proceso()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "pa_sel_um_Documento_3pl '" & Muestra & "'"
            dt = otrans.Obtiene(lsSQL)
            dgv_Documentos.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub btn_Pendientes_Click(sender As Object, e As EventArgs) Handles btn_Pendientes.Click
        Muestra = "PENDIENTES"
        Muestra_Proceso()
    End Sub

    Private Sub btn_Proceso_Click(sender As Object, e As EventArgs) Handles btn_Proceso.Click
        Muestra = "EN PROCESO"
        Muestra_Proceso()
    End Sub

    Private Sub btn_Finalizados_Click(sender As Object, e As EventArgs) Handles btn_Finalizados.Click
        Muestra = "FINALIZADOS"
        Muestra_Proceso()
    End Sub

    Private Sub btn_Todos_Click(sender As Object, e As EventArgs) Handles btn_Todos.Click
        Muestra = "TODOS"
        Muestra_Proceso()
    End Sub
End Class