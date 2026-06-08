Public Class frm_ws_envio



    Private Sub llenarInformacionparaEnvio()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            Otrans.open()
            lsSQL = "pa_sel_um_ws_producto_receta_mes " & Month(Me.dtp_mes.Value) & "," & Me.dtp_año.Text & "," & Me.cmbClub.SelectedValue
            dt = Otrans.Obtiene(lsSQL)
            Me.dgvPack.DataSource = dt
            clsGen.Alinear_GridView(dt, Me.dgvPack, ",producto_pack,glosa_pack,", "", "", "", "", "", "", True, True, 250, 0)

            lsSQL = "pa_var_um_ws_socio_envio " & Month(Me.dtp_mes.Value) & "," & Me.dtp_año.Text & "," & Me.cmbClub.SelectedValue
            dt = Otrans.Obtiene(lsSQL)
            Me.dgvSocio.DataSource = dt
            clsGen.Alinear_GridView(dt, dgvSocio, ",serie,numero,nombre_socio,numero_envio,", "", "", "", "", "", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub llenarCombo()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable


        Try
            dt = clsGen.selectQuery("FlexLine", "scm.flexline.pa_sel_um_ws_club")

            Me.cmbClub.DataSource = dt
            Me.cmbClub.ValueMember = "cod_club"
            Me.cmbClub.DisplayMember = "descripcion"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_ws_envio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombo()
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        If MessageBox.Show("Esta Seguro de Generar la Informacion Para Este Mes", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            llenarInformacionparaEnvio()
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim clsGen As New ClasesGenerales.General
        Dim path_reporte As String
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String

        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim sNombreReporte As String = String.Empty


        Try
            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)
            Try
                Oaut.Archivo_Generado = Environment.GetEnvironmentVariable("TEMP") & "\" & sNombreReporte & "_" & gs_empresa & "_" & Me.dtp_mes.Text & ".pdf"
            Catch ex As Exception

            End Try
            path_reporte = clsgen.Path_Reporte()
            path_reporte += "Direccion Comercial\Vinoteca\ws_envio.rpt"
            pm_parametros(0) = "@PMes"
            pm_parametros(1) = "@PAño"
            pm_parametros(2) = "@PCodClub"

            pm_valores(0) = Month(Me.dtp_mes.Value)
            pm_valores(1) = Year(Me.dtp_año.Value)
            pm_valores(2) = Me.cmbClub.SelectedValue


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, "SCM", "SCM", "flexline", "flexline", False, False, "PDF", True)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        Dim clsGen As New ClasesGenerales.General
        Dim path_reporte As String
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String

        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim sNombreReporte As String = String.Empty


        Try
            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)

            Try
                Oaut.Archivo_Generado = Environment.GetEnvironmentVariable("TEMP") & "\" & sNombreReporte & "_" & gs_empresa & "_" & Me.dtp_mes.Text & ".pdf"
            Catch ex As Exception

            End Try

            path_reporte = clsGen.Path_Reporte()
            path_reporte += "Direccion Comercial\Vinoteca\ws_memo_entrega.rpt"
            pm_parametros(0) = "@PMes"
            pm_parametros(1) = "@PAño"
            pm_parametros(2) = "@PCodClub"

            pm_valores(0) = Month(Me.dtp_mes.Value)
            pm_valores(1) = Year(Me.dtp_año.Value)
            pm_valores(2) = Me.cmbClub.SelectedValue


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, "SCM", "SCM", "flexline", "flexline", False, False, "PDF", True)


        Catch ex As Exception

        End Try
    End Sub
End Class