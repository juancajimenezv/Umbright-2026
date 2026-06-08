Public Class frm_presupuesto_marcas

    Dim dtDetalle As DataTable

    Private Sub generarInformacion()
        Dim Otrans As New Transaccional.Conexion("Umbralsa")
        Dim dt As DataTable
        Dim clsgen As New ClasesGenerales.General
        Dim lsSQL As String

        Try
            Otrans.open()
            lsSQL = "pa_var_um_integracion_finanzas_marca '" & gs_empresa & "'"
            dt = Otrans.Obtiene(lsSQL)

            Me.dgvMarca.DataSource = dt
            clsgen.Alinear_GridView(dt, Me.dgvMarca, "", "", "", "", True, True, 250, 0)

            lsSQL = "pa_var_um_integracion_finanzas_marca_detalle '" & gs_empresa & "'"
            dtDetalle = Otrans.Obtiene(lsSQL)

            Me.dgvItem.DataSource = dtDetalle
            clsgen.Alinear_GridView(dtDetalle, Me.dgvItem, "", "", "", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub filtrarInformacionDetalle(ByVal pnrow As Integer)
        Dim lsFiltro As String

        Try
            lsFiltro = "marca = '" & Me.dgvMarca.Item("marca", pnrow).Value.ToString & "' and propio = '" & Me.dgvMarca.Item("propio", pnrow).Value.ToString & "'"
            dtDetalle.DefaultView.RowFilter = lsFiltro

        Catch ex As Exception

        End Try

    End Sub


    Private Sub frm_presupuesto_marcas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        generarInformacion()
    End Sub

    Private Sub dgvMarca_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMarca.CellContentClick

    End Sub

    Private Sub dgvMarca_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMarca.CellEnter
        If e.RowIndex >= 0 Then
            filtrarInformacionDetalle(e.RowIndex)
        End If
    End Sub

    Private Sub dgvMarca_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvMarca.CellMouseClick
        If e.RowIndex >= 0 Then
            filtrarInformacionDetalle(e.RowIndex)
        End If

    End Sub
End Class