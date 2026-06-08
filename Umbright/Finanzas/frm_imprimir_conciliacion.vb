Public Class frm_imprimir_conciliacion
    Public pm_Cuenta As String
    Public pm_Periodo, pm_Mes, pm_SaldoBanco, pm_SaldoContable As Double

    Private Sub frm_imprimir_conciliacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then
            generar_reporte()
        Else
            MsgBox("Debe llenar todos los campos", MsgBoxStyle.Critical)
        End If

    End Sub
    Private Sub generar_reporte()
        Dim otrans As New Transaccional.Conexion("DWH")
        Dim ls_sql As String
        Dim llenar_memos As Boolean = False
        Dim ls_ubicaciones As String = ""
        Dim ubicacion_actual As String
        Dim path_reporte, ppath_reporte As String
        Dim pm_valores(6), pm_valores_consolidado(3) As String
        Dim pm_parametros(6) As String
        Dim pm_conexion(3) As String
        Dim clsgen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim ruta As String
        Randomize()
        Dim aleat As Integer

        ''Obtengo Datos de Conexion

        Try

            otrans.open()
            pm_conexion = clsgen.Parametros_Conexion("")
            ppath_reporte = clsgen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)

            '023:
            path_reporte = ppath_reporte & "Finanzas\Contabilidad\Conciliacion Bancaria.rpt"
            'path_reporte = "c:\reportes\Retail-Link2.rpt"
            pm_parametros(0) = "Empresa"
            pm_parametros(1) = "Cuenta"
            pm_parametros(2) = "Periodo"
            pm_parametros(3) = "Mes"
            pm_parametros(4) = "SaldoBanco"
            pm_parametros(5) = "SaldoContable"
            pm_parametros(6) = "Usuario"

            pm_SaldoContable = CDbl(TextBox1.Text)
            pm_SaldoBanco = CDbl(TextBox2.Text)


            pm_valores(0) = gs_empresa
            pm_valores(1) = pm_Cuenta
            pm_valores(2) = pm_Periodo
            pm_valores(3) = pm_Mes
            pm_valores(4) = pm_SaldoBanco
            pm_valores(5) = pm_SaldoContable
            pm_valores(6) = gs_usuario


            ruta = ""

            Oaut.Archivo_Generado = ruta
            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                   False, False, "PDF", False)
            ' pm_valores(1) & "','" & _
            ' pm_valores(2) & "',NULL,NULL,NULL,100"
            ' otrans.Actualiza(ls_sql)


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

            Oaut.finalizar()
            Oaut = Nothing
            clsgen = Nothing
            Me.Close()
        End Try

    End Sub
End Class