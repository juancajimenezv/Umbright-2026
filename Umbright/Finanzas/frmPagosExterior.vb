Public Class frmPagosExterior

    Private Sub generarOCPendientes()

        Dim clsGen As New ClasesGenerales.General
        Dim dt As New DataTable
        Dim lsSQL As String

        Try

            lsSQL = "pa_var_um_tes_ordenes_pendientes_asociar '" & gs_empresa & "','" & Me.dtpFechaInicio.Text & "','" & Me.dtpFechaFinal.Text & "'"
            dt = clsGen.selectQuery("SCM", lsSQL)

            Me.dgvDetalle.DataSource = dt

            clsGen.Alinear_GridView(dt, dgvDetalle, "", ",tipodocto,", "", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try




    End Sub

    Private Sub generarDatosFinanzas()

        Dim clsGen As New ClasesGenerales.General
        Dim dt As New DataTable
        Dim lsSQL As String
        Dim nRow As Integer

        Try
            nRow = dgvDetalle.CurrentRow.Index

            lsSQL = "pa_var_um_tes_validar_ordenes_contable  '" & gs_empresa & "','" & dgvDetalle.Item("ctacte", nRow).Value & "','" & dgvDetalle.Item("fecha", nRow).Value & "'"
            dt = clsGen.selectQuery("SCM", lsSQL)

            Me.dgvDetalleContabilidad.DataSource = dt
            clsGen.Alinear_GridView(dt, dgvDetalleContabilidad, "", "", "", "", True, True, 250, 0)
        Catch ex As Exception

        Finally
            clsGen = Nothing
        End Try

    End Sub


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        generarOCPendientes()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        generarDatosFinanzas()
    End Sub
End Class