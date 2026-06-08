Public Class frm_admin_bodegas
    Dim _dtCambioBodega As DataTable
    Private Sub frm_admin_bodegas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaTabla()
        llena_bodegas()
    End Sub

    Private Sub CreaTabla()

        _dtCambioBodega = New DataTable("cambioBodega")
        _dtCambioBodega.Columns.Add(New DataColumn("Empresa", GetType(String)))
        _dtCambioBodega.Columns.Add(New DataColumn("Bodega", GetType(String)))
        _dtCambioBodega.Columns.Add(New DataColumn("Vigencia", GetType(String)))

        dgv_cambiarBodega.DataSource = _dtCambioBodega

    End Sub

    Private Sub llena_bodegas()
        Dim dt As New DataTable
        Dim lsSQL As String
        Dim l_Dataset As New DataSet
        Dim otrans As New Transaccional.Conexion("flexline")

        Dim cbdgv_vigencia As New DataGridViewComboBoxColumn()
        cbdgv_vigencia.HeaderText = "Vigencia"
        cbdgv_vigencia.Name = "Vigencia"
        cbdgv_vigencia.Items.AddRange("S", "N")


        Try
            otrans.open()

            lsSQL = "select Empresa, codigo Bodega, Vigencia Estado from gen_Tabcod where tipo='gen_bodega' and valor1=1"
            dt = otrans.Obtiene(lsSQL)

            dgv_cambiarBodega.DataSource = dt
            dgv_cambiarBodega.Columns.Insert(3, cbdgv_vigencia)
            dgv_cambiarBodega.Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv_cambiarBodega.Columns("Vigencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        Catch ex As Exception

        End Try


    End Sub
    Private Sub btnActualiza_Click(sender As Object, e As EventArgs) Handles btnActualiza.Click
        If MessageBox.Show("Desea realizar cambios a la vigencia de la bodega?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guarda_cambios()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub guarda_cambios()
        Dim dt As New DataTable
        Dim lsSQL As String
        Dim l_Dataset As New DataSet
        Dim otrans As New Transaccional.Conexion("flexline")

        Try
            otrans.open()
            dt = Me.dgv_cambiarBodega.DataSource

            For Each row As DataGridViewRow In dgv_cambiarBodega.Rows

                Dim cEmpresa As String = row.Cells("Empresa").Value.ToString()
                Dim cBodega As String = row.Cells("Bodega").Value.ToString()
                Dim cVigencia As String = row.Cells("Vigencia").Value.ToString()

                If cVigencia <> Nothing Then

                    lsSQL = "exec pa_um_upd_gen_bodegas '" & cEmpresa & "','" & cBodega & "','" & cVigencia & "'"
                    otrans.Actualiza(lsSQL)

                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub dgv_cambiarBodega_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_cambiarBodega.CellValueChanged
        Dim dt As New DataTable
        Dim ls_SqlScript As String
        Dim l_Dataset As New DataSet
        Dim otrans As New Transaccional.Conexion("flexline")

        Try
            otrans.open()

            ' Verifica que no sea una fila nueva
            If e.RowIndex >= 0 Then

                ' Obtén la fila actual
                Dim row As DataGridViewRow = dgv_cambiarBodega.Rows(e.RowIndex)
                ' Recorre todas las columnas del DataGridView
                For Each column As DataGridViewColumn In dgv_cambiarBodega.Columns
                    ' Verifica si la columna es de tipo DataGridViewComboBoxColumn
                    If TypeOf column Is DataGridViewComboBoxColumn Then
                        ' Asigna un nombre a la columna
                        column.Name = "Vigencia"
                        ' Puedes salir del bucle si solo necesitas asignar un nombre a una columna
                        Exit For

                    End If
                Next

            End If
        Catch ex As Exception

        End Try




    End Sub
End Class