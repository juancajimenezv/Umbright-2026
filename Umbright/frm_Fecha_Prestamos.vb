Public Class frm_Fecha_Prestamos

    Private Sub llenarPrestamos()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable


        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_PrestamosQ2 '" & gs_empresa & "','" & Me.BoxPrestamo.Text & "'"  'asigna el procedimiento y valores a lsSql
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            Me.DataGridView1.DataSource = dt    'asigna el resultado del procedimiento en un Grid

            clsGen.Alinear_GridView(dt, Me.DataGridView1, "", ",Empresa,Descripcion,modificado,", ",Ficha,Nombre,Fecha_Inicio,Cuota,Monto_Total,", "", True, True, 250, 0)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        llenarPrestamos() ' Llama la funcion llenarcombo()
    End Sub

    Private Sub Vista_Previa()
        'Dim nrow As Integer
        'Dim otrans As New Transaccional.Conexion("FlexLine")
        'Dim ls_sql As String
        'Dim llenar_memos As Boolean = False
        Dim ls_ubicaciones As String = ""
        'Dim ubicacion_actual As String
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(2), pm_valores_consolidado(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        'Dim Oaut As Automatizacion.Reportes_CraxDrt
        Dim Oaut As Automatizar.Reportes_CraxDrt

        ''Obtengo Datos de Conexion



        Try

            pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)
            path_reporte = ppath_reporte & "Recursos Humanos\Generales\Prestamos Por Empleado.rpt"
            pm_parametros(0) = "empresa"
            pm_parametros(1) = "Descripcion"
            pm_valores(0) = gs_empresa
            pm_valores(1) = Me.BoxPrestamo.Text


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Vista_Previa() ' llama proceso de impresion
    End Sub

    Private Sub Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Grabar.Click
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        If MessageBox.Show("¿Esta Accion Actualizara Los Datos Modificados?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

        Try
            Otrans.open()   'abre conexion

            dt = Me.DataGridView1.DataSource

            dt.DefaultView.RowFilter = "modificado = 1"
            For Each drv As DataRowView In dt.DefaultView

                ls_sql = "spa_PrestamoTermino '" & gs_empresa & "','" & drv.Item("ficha") & _
                        "','" & drv.Item("descripcion") & "','" & drv.Item("fecha_inicio") & "','" & drv.Item("fecha_termino") & "'" 'asigna el procedimiento y valores a lsSql
                Otrans.Actualiza(ls_sql)

                If Otrans.Codigo_error = 0 Then
                    MessageBox.Show("Ficha Actualizada: " & drv.Item("ficha").ToString, " Grabacion ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    'MsgBox(Otrans.descripcion_error)
                    MessageBox.Show("ERROR, Verifique!! " & drv.Item("Ficha").ToString & " - " & drv.Item("Nombre").ToString, "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Otrans.descripcion_error)
                End If

            Next
            dt.DefaultView.RowFilter = ""

            MessageBox.Show("Proceso Finalizado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Me.DataGridView1.Item("modificado", e.RowIndex).Value = 1
    End Sub

    Private Sub Fecha_Prestamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim otrans As New Transaccional.Conexion("flexline") 'Abre conexion
        Dim clsGen As New ClasesGenerales.General           'Abre las clases generales
        Dim lsSQL As String                                 'Declara Variable lsSql como String
        Dim dt As DataTable                                 'Declara dt como DataTable


        Try
            otrans.open()   'abre conexion

            lsSQL = "spa_PrestamosQ'" & gs_empresa & "'"  'asigna el procedimiento a lsSql

            dt = otrans.Obtiene(lsSQL)  'Ejecuta el procedimiento guardado en lsSql
            dt = clsGen.ValoresDistinto(dt, "Descripcion".Split(","))   'agrupa por familia

            Me.BoxPrestamo.DataSource = dt               'asigna comboBox la tabla o resultado del procedimiento
            Me.BoxPrestamo.DisplayMember = "Descripcion"     'Despliega el miembro familia
            Me.BoxPrestamo.ValueMember = "Descripcion"       '

        Catch ex As Exception
        Finally
            otrans.close()      'cierra conexion
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub
End Class

