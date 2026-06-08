Public Class frm_RechazosPendientesAprobacion
    Dim dt As DataTable
    Private Sub generarDevolucionesPendientes()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General

        Dim lsSQL As String

        Try
            Otrans.open()
            lsSQL = "pa_var_um_devoluciones '" & Me.dtpInicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtpFinal.Value.ToString("dd/MM/yyyy") & "',100"
            dt = Otrans.Obtiene(lsSQL)
            Me.dgvListado.DataSource = dt
            clsGen.Alinear_GridView(dt, Me.dgvListado, ",empresa,tipodocto,numero,fecha,cliente,nombre_cliente,comentario1,glosa,bodega,", "", "", "", "", "", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        generarDevolucionesPendientes()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Dim nrow As Integer
        nrow = Me.dgvListado.CurrentRow.Index

        Try

            ''Verificar Stock
            imprimir(dgvListado.Item("empresa", nrow).Value, dgvListado.Item("tipodocto", nrow).Value, dgvListado.Item("numero", nrow).Value)

        Catch ex As Exception

        End Try


    End Sub

    Private Sub imprimir(ByVal ps_empresa As String, tipdocto As String, numero As String)


        Dim path_reporte As String

        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim fecha2 As String
        Dim dt As DataTable

        Dim fecha As Date
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            pm_conexion = ClsGen.Parametros_Conexion("VDATASERVER")
            path_reporte = ClsGen.Path_Reporte()
            Otrans.open()


            ''Aplico Seguridad
            ''Levanto el estado de cuenta
            ''Cargo el Reporte
            fecha = Format(Today, "d")
            fecha2 = fecha.ToShortDateString


            ReDim pm_parametros(3)
            ReDim pm_valores(3)
            pm_parametros(0) = "Empresa"
            pm_parametros(1) = "Numero"
            pm_parametros(2) = "tipodocto"
            pm_valores(0) = ps_empresa
            pm_valores(1) = numero
            pm_valores(2) = tipdocto


            path_reporte += "logistica\bodega\Impresion de Devoluciones de Mercaderia.rpt"



            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                        False, True, "PDF", True, "", True, 2)

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.txtBusqueda.Text.Length > 0 Then
            dt.DefaultView.RowFilter = Me.cmbFiltro.Text & " like '%" & Me.txtBusqueda.Text & "%'"
        Else
            dt.DefaultView.RowFilter = ""
        End If
    End Sub

    Private Sub frm_RechazosPendientesAprobacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class