Public Class frm_entradas_x_traslado

    Private Sub llenarCombos()


        Dim lsSQL As String
        Dim clsgen As New ClasesGenerales.General
        Dim dt, dt2 As DataTable


        Try




            lsSQL = "pa_sel_um_tipodocumento '" & gs_empresa & "','Boleta (v)',null"
            dt = clsgen.selectQuery("FlexLine", lsSQL)




            Me.cmbTipoDocto.DataSource = dt
            Me.cmbTipoDocto.DisplayMember = "tipoDocto"
            Me.cmbTipoDocto.ValueMember = "tipoDocto"
        Catch ex As Exception
        Finally
            clsgen = Nothing
        End Try
    End Sub


    Private Sub frm_entradas_x_traslado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos
    End Sub
End Class