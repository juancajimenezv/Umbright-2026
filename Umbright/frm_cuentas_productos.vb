Public Class frm_cuentas_productos
    Dim dtProductos As New DataTable

    Private Sub llenarCombo()
        Dim otrans As New Transaccional.Conexion("flexline") 'Abre conexion
        Dim clsGen As New ClasesGenerales.General           'Abre las clases generales
        Dim lsSQL As String                                 'Declara Variable lsSql como String
        Dim dt As DataTable                                 'Declara dt como DataTable

        Try
            otrans.open()   'abre conexion

            lsSQL = "spa_ProductosCuenta '" & gs_empresa & "'"  'asigna el procedimiento a lsSql

            dt = otrans.Obtiene(lsSQL)  'Ejecuta el procedimiento guardado en lsSql
            dt = clsGen.ValoresDistinto(dt, "Familia".Split(","))   'agrupa por familia

            Me.BoxFamilia.DataSource = dt               'asigna comboBox la tabla o resultado del procedimiento
            Me.BoxFamilia.DisplayMember = "Familia"     'Despliega el miembro familia
            Me.BoxFamilia.ValueMember = "Familia"       '

        Catch ex As Exception
        Finally
            otrans.close()      'cierra conexion
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        llenarCombo() ' Llama la funcion llenarcombo()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        llenarProductos() 'Llama la funcion llenarProductos()
    End Sub
    Private Sub llenarProductos()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        gs_empresa = "VINOTECA"

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_ProductosCuenta2 '" & gs_empresa & "','" & Me.BoxFamilia.Text & "'"  'asigna el procedimiento y valores a lsSql
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            Me.DataGridView1.DataSource = dt    'Despliega el resultado del procedimiento en un Grid

            clsGen.Alinear_GridView(dt, Me.DataGridView1, "", ",Empresa,", ",Producto,Glosa,Familia,TipoProducto,CuentaDev,Descripcion,CuentaDesc,Descripcion2,", "", True, True, 250, 0)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub ActualizaProductos()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String


        Try
            otrans.open()
            MsgBox(" Este Proceso Actualizara Las Cuentas Contables ", MsgBoxStyle.OkCancel, "Actualización..")
            lsSQL = "spa_ProductosCuenta_A '" & gs_empresa & "','" & Me.BoxFamilia.Text & "'"  'asigna el procedimiento y valores a lsSql
            otrans.Actualiza(lsSQL)
            MsgBox(" La Actualizacion ha Finalizado.. ")

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub
    Private Sub Vista_Previa()
       


        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(2), pm_valores_consolidado(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt

        ''Obtengo Datos de Conexion



        Try
            '   otrans.open()
            'nrow = Me.DataGridView1.CurrentRow.Index
            pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa) 'Me.dgv_encabezado.Item("empresa", nrow).Value)
            path_reporte = ppath_reporte & "Finanzas\Contabilidad\Jefatura\Cuentas Contables Por Producto.rpt"
            pm_parametros(0) = "empresa"
            pm_parametros(1) = "familia"
            pm_valores(0) = gs_empresa 'Me.dgv_encabezado.Item("empresa", nrow).Value
            pm_valores(1) = Me.BoxFamilia.Text '"HOGAR Y CUIDADO" 'Me.dgv_encabezado.Item("familia", nrow).Value


            '                _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
            '                                       pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            '                                      False, True, "PDF", False)
            'Oaut.Archivo_Generado = "c:\temp\factura_consignacion_" & Me.dgv_encabezado.Item("numero", nrow).Value & ".pdf"
            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                    False, False, "PDF", True)

            'ls_sql = "pa_upd_um_documento_fecha_vcto '" & pm_valores(0) & "','" & _
            '               pm_valores(1) & "','" & _
            '              pm_valores(2) & "',NULL,NULL,NULL,100"
            ' otrans.Actualiza(ls_sql)

        Catch ex As Exception
        Finally
            'otrans.close()
            'otrans = Nothing

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ActualizaProductos()
        llenarProductos()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'Dim forma As New frm_CuentasContables
        'forma.Show()
        Vista_Previa()
    End Sub

    Private Sub frm_cuentas_productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombo()
    End Sub
End Class