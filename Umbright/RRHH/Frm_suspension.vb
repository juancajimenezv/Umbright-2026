Public Class Frm_suspension

    Public FechaIni As Date
    Public FechaFin As Date
    'Public gs_empresa As String = "LOGISERV"
    'Public gs_usuario As String = "admin"

    Private Sub Combo_Box()
        Dim otrans As New Transaccional.Conexion("flexline") 'Abre conexion
        Dim clsGen As New ClasesGenerales.General           'Abre las clases generales
        Dim lsSQL As String                                 'Declara Variable lsSql como String
        Dim dt As DataTable  'Declara dt como DataTable

        Try
            otrans.open()   'abre conexion

            lsSQL = " select  motivo_suspension from PER_MOTIVO_SUSPENSION ORDER BY MOTIVO_SUSPENSION "     'asigna el procedimiento a lsSql
            dt = otrans.Obtiene(lsSQL)                                                      'Ejecuta el procedimiento guardado en lsSql

            Me.cb_Motivo.DataSource = dt                                                'asigna comboBox la tabla o resultado del procedimiento
            Me.cb_Motivo.DisplayMember = "Motivo_Suspension"                                   'Despliega el miembro familia 
            Me.cb_Motivo.ValueMember = "Motivo_Suspension"

        Catch ex As Exception
        Finally
            otrans.close()      'cierra conexion
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub



    Private Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        Busca_Empleados()
    End Sub

    Private Sub Busca_Empleados()
        Dim AbreForma As New Frm_empleados
        AbreForma.ShowDialog()

        Try

            tb_Ficha.Enabled = False
            Me.tb_Ficha.Text = AbreForma.Ficha
            Me.lb_Nombre.Text = AbreForma.Nombre
            Me.lb_Area.Text = AbreForma.Area
            Me.lb_Departamento.Text = AbreForma.Departamento
            Me.lb_Puesto.Text = AbreForma.Cargo
            Me.lb_Fecha_Ingreso.Text = AbreForma.Fecha_Ingreso
            Me.lb_Jefe.Text = AbreForma.Jefe

            'ls_producto = Me.dgv_empleados.Item("producto", nrow).Value
            'ods.Tables("derivados").DefaultView.RowFilter = "padre = '" & ls_producto & "'"

        Catch ex As Exception

        End Try
    End Sub

    Public Sub Trae_Empleados()
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        If tb_Ficha.Text = Nothing Then
            MsgBox("No Ha Seleccionado Empleado", MsgBoxStyle.Critical, "Error")
            tb_Ficha.Focus()
            tb_Ficha.SelectAll()

        ElseIf lb_Nombre.Text = "Nombre Del Empleado" Then
            MsgBox("Empleado No Existe", MsgBoxStyle.Critical, "Error")
            tb_Ficha.Focus()
            tb_Ficha.SelectAll()
        Else

            If MessageBox.Show("¿Se Grabará La Suspensión?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Nuevo()
            Else
                Grabar()
            End If
        End If

    End Sub

    Private Sub Nuevo()

        tb_Ficha.Text = ""
        Me.lb_Nombre.Text = "Nombre"
        Me.lb_Area.Text = "Area"
        Me.lb_Departamento.Text = "Departamento"
        Me.lb_Puesto.Text = "Puesto"
        Me.lb_Fecha_Ingreso.Text = "Fecha Ingreso"
        Me.lb_Jefe.Text = "Jefe Inmediato"
        Me.cb_Motivo.Text = Nothing
        Me.dtp_FechaAccidente.Text = Nothing
        Me.dtp_FechaAlta.Text = Nothing
        Me.dtp_FechaI.Text = Nothing
        Me.dtp_FechaF.Text = Nothing
        Me.tb_CausaDiagnostico.Text = ""
        Me.tb_Ficha.Enabled = True
        Me.btn_Buscar.Enabled = True
        Me.btn_Guardar.Visible = True
        btn_Actulizar.Visible = False
        tb_Ficha.Focus()

    End Sub

    Private Sub Grabar()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        Try
            If CDate(dtp_FechaI.Text) >= CDate(dtp_FechaF.Text) Then
                MsgBox("La Fecha Inicial De suspension No Puede Ser Mayor o Igual a La Fecha Final!!", MsgBoxStyle.Critical, "Error")
                Nuevo()

            ElseIf cb_Motivo.Text = Nothing Then
                MsgBox("Debe Agregar Motivo de Suspension", MsgBoxStyle.Critical, "Error")
                Nuevo()

            ElseIf CDate(dtp_FechaAccidente.Text) > CDate(dtp_FechaI.Text) Then
                ' If dtp_FechaAccidente.Text >= dtp_FechaF.Text Then
                '   If dtp_FechaAccidente.Text >= dtp_FechaI.Text Then
                MsgBox("Fecha Accidente Mayor a Fecha Inicial, Final o Alta", MsgBoxStyle.Critical, "Error")
                Nuevo()
                'End If
                'End If

            Else

                Otrans.open()   'abre conexion

                ls_sql = "spa_Control_Suspension '" & gs_empresa & "','" & tb_Ficha.Text & "','" & lb_Nombre.Text & "','" & lb_Area.Text & "','" & _
                lb_Departamento.Text & "','" & lb_Puesto.Text & "','" & lb_Fecha_Ingreso.Text & "','" & lb_Jefe.Text & "','" & cb_Motivo.Text & "','" & _
                dtp_FechaAccidente.Text & "','" & dtp_FechaAlta.Text & "','" & dtp_FechaI.Text & "','" & dtp_FechaF.Text & "','" & tb_CausaDiagnostico.Text & "','" & _
                gs_usuario & "','" & Now() & "',1"
                Otrans.Actualiza(ls_sql)

                MessageBox.Show("Proceso Finalizado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Nuevo()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Nuevo()
    End Sub

    Private Sub btn_Suspendidos_Click(sender As Object, e As EventArgs) Handles btn_Suspendidos.Click
        Suspendidos()
    End Sub
    Private Sub Suspendidos()
        Dim AbreForma As New Frm_Buscar_Suspendidos
        AbreForma.ShowDialog()

        Try

            tb_Ficha.Enabled = False
            Me.tb_Ficha.Text = AbreForma.Ficha
            Me.lb_Nombre.Text = AbreForma.Nombre
            Me.lb_Area.Text = AbreForma.Area
            Me.lb_Departamento.Text = AbreForma.Departamento
            Me.lb_Puesto.Text = AbreForma.Cargo
            Me.lb_Fecha_Ingreso.Text = AbreForma.Fecha_Ingreso
            Me.lb_Jefe.Text = AbreForma.Jefe

            Me.cb_Motivo.Text = AbreForma.Motivo
            Me.dtp_FechaAccidente.Text = AbreForma.FechaAccidente
            Me.dtp_FechaAlta.Text = AbreForma.FechaAlta

            Me.dtp_FechaI.Text = AbreForma.FechaInicio
            Me.dtp_FechaF.Text = AbreForma.FechaFinal

            Me.tb_CausaDiagnostico.Text = AbreForma.CausaDiagnostico

            btn_Buscar.Enabled = False
            btn_Guardar.Visible = False
            btn_Actulizar.Visible = True


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        Nuevo()
    End Sub

    Private Sub Frm_suspension_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn_Actulizar.Visible = False
        Combo_Box()
    End Sub

    Private Sub btn_Actulizar_Click(sender As Object, e As EventArgs) Handles btn_Actulizar.Click
        If MessageBox.Show("Se Actualizará La Suspensión?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Nuevo()
        Else
            Actualizar_Suspension()
        End If

    End Sub

    Private Sub Actualizar_Suspension()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        Try

            If CDate(dtp_FechaI.Text) >= CDate(dtp_FechaF.Text) Then
                MsgBox("La Fecha Inicial De suspension No Puede Ser Mayor o Igual a La Fecha Final!!", MsgBoxStyle.Critical, "Error")
                Nuevo()

            ElseIf cb_Motivo.Text = Nothing Then
                MsgBox("Debe Agregar Motivo de Suspension", MsgBoxStyle.Critical, "Error")
                Nuevo()
            Else

                Otrans.open()   'abre conexion

                ls_sql = "spa_Control_Suspension_Actualiza '" & gs_empresa & "','" & tb_Ficha.Text & "','" & cb_Motivo.Text & "','" & _
                dtp_FechaAccidente.Text & "','" & dtp_FechaAlta.Text & "','" & dtp_FechaI.Text & "','" & dtp_FechaF.Text & "','" & _
                tb_CausaDiagnostico.Text & "','" & gs_usuario & "','" & Now() & "'"
                Otrans.Actualiza(ls_sql)

                MessageBox.Show("Proceso Finalizado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Nuevo()
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Nuevo()
    End Sub


    Private Sub btn_Impresion_Click(sender As Object, e As EventArgs) Handles btn_Impresion.Click

        Dim oform As New Frm_Suspension_Fechas
        oform.ShowDialog()

        FechaIni = oform.FechaI
        FechaFin = oform.FechaF
        If FechaIni < FechaFin Then
            Reporte()
        End If


    End Sub

    Private Sub Reporte()
        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(2), pm_valores_consolidado(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(2) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt


        Try

            pm_conexion = ClsGen.Parametros_Conexion("vdataserver")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "Recursos Humanos\Generales\Control De Suspensiones.rpt"

            pm_parametros(0) = "Empresa"
            pm_valores(0) = gs_empresa

            pm_parametros(1) = "FechaI"
            pm_valores(1) = FechaIni.ToString

            pm_parametros(2) = "FechaF"
            pm_valores(2) = FechaFin.ToString


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try

    End Sub
End Class