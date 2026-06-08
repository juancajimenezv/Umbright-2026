'Imports System.Windows.Forms.InsertKeyMode
'Imports System.Data
'Imports System.Data.SqlClient
Imports System.IO

Public Class Frm_Candidatos

    'Public gs_empresa As String = "UMBRAL"
    'Public gs_usuario As String = "admin"
    Dim contrato As String = ""


    Private Sub Llena_Combos()
        Dim ls_sql As String
        Dim tipos_doctos(20) As String
        Dim ldt_table, ldt_table_ As New DataTable
        Dim oTransaccion As New Transaccional.Conexion("flexline")
        oTransaccion.open()

        ls_sql = "pa_vb_rrhh_Region"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "region"

        Me.cb_Region.DisplayMember = "Region"
        Me.cb_Region.ValueMember = "Region"
        Me.cb_Region.DataSource = ldt_table.DefaultView


        ls_sql = "pa_vb_rrhh_Depto '" & gs_empresa & "'"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "deptos"

        Me.cb_Depto.DisplayMember = "Departamento"
        Me.cb_Depto.ValueMember = "Departamento"
        Me.cb_Depto.DataSource = ldt_table.DefaultView

        ls_sql = "pa_vb_rrhh_Cargo '" & gs_empresa & "'"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "cargo"

        Me.cb_Cargo.DisplayMember = "Cargo"
        Me.cb_Cargo.ValueMember = "Cargo"
        Me.cb_Cargo.DataSource = ldt_table.DefaultView

        ls_sql = "select Contrato from SCM.flexline.PER_CONTRATO order by Contrato "
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "contrato"

        Me.cb_Contrato.DisplayMember = "Contrato"
        Me.cb_Contrato.ValueMember = "Contrato"
        Me.cb_Contrato.DataSource = ldt_table.DefaultView



    End Sub

    Private Sub cb_Sexo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_Sexo.SelectedValueChanged
        If cb_Sexo.Text = "FEMENINO" Then
            tb_apellidoCasada.Visible = True
            Label5.Visible = True
        Else
            tb_apellidoCasada.Visible = False
            Label5.Visible = False
        End If
    End Sub


    Private Sub btn_Contrato_Click(sender As Object, e As EventArgs) Handles btn_Contrato.Click
        'If cb_Contrato.Text = "3 - Con Sueldo Variable y Sin Horas Extras" Then
        '    contrato = "Contrato3"
        '    Reporte()
        'ElseIf cb_Contrato.Text = "2 - Sin Sueldo Variable y Con Horas Extras" Then
        '    contrato = "Contrato2"
        '    Reporte()
        'ElseIf cb_Contrato.Text = "1 - Sin Sueldo Variable y Sin Horas Extras" Then
        '    contrato = "Contrato1"
        '    Reporte()
        'ElseIf cb_Contrato.Text = "4 - Con Sueldo Variable Piloto y Ayudante" Then
        '    contrato = "Contrato4"
        '    Reporte()
        'ElseIf cb_Contrato.Text = "5 - Con Sueldo Variable Auxiliar de Bodega" Then
        '    contrato = "Contrato5"
        '    Reporte()
        ' end try
        Try
            contrato = ("Contrato" & Trim(Mid(cb_Contrato.Text, 1, 2)))
            Reporte()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Frm_Candidatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Llena_Combos()
        'Me.Size = New System.Drawing.Size(396, 412)
        AgregarEnFlexLineToolStripMenuItem.Enabled = False
        'OpenFileDialog1.Filter = "Todos(*.Jpg, *.Png, *.Gif, *.Tiff, *.Jpeg, *."
        Me.ToolTip1.IsBalloon = False
        Me.ToolTip1.SetToolTip(btn_Buscar, "BUSCA EMPLEADOS EXISTENTES EN LA BASE DE DATOS...")
        Me.ToolTip1.SetToolTip(btn_Limpiar, "LIMPIA LA PANTALLA, DEJANDOLA LISTA PARA OTRA CONSULTA...")
        Me.ToolTip1.SetToolTip(btn_Grabar, "GRABA LOS DATOS A LA BASE...")
        Me.ToolTip1.SetToolTip(btn_Contrato, "MUESTRA EL CONTRATO SELECCIONADO, PARA IMPRIMIR O EXPORTAR...")
    End Sub

    Private Sub tb_Identificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Identificacion.KeyPress
        If e.KeyChar = Chr(13) Then
            Busca_Candidatos()
        End If
    End Sub

    Private Sub cb_Sexo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Sexo.KeyPress
        tb_PrimerNombre.Focus()
    End Sub

    Private Sub tb_PrimerNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_PrimerNombre.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_SegunoNombre.Focus()
        End If
    End Sub

    Private Sub tb_SegunoNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_SegunoNombre.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_PrimerApellido.Focus()
        End If
    End Sub

    Private Sub tb_PrimerApellido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_PrimerApellido.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_SegundoApellido.Focus()
        End If
    End Sub

    Private Sub tb_SegundoApellido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_SegundoApellido.KeyPress
        If e.KeyChar = Chr(13) Then
            dtp_FechaNac.Focus()
        End If
    End Sub

    Private Sub tb_apellidoCasada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_apellidoCasada.KeyPress
        If e.KeyChar = Chr(13) Then
            dtp_FechaNac.Focus()
        End If
    End Sub

    Private Sub dtp_FechaNac_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtp_FechaNac.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Nit.Focus()
        End If
    End Sub

    Private Sub tb_Nit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Nit.KeyPress
        If e.KeyChar = Chr(13) Then
            cb_Estado.Focus()
        End If
    End Sub

    Private Sub cb_Estado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Estado.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Igss.Focus()
        End If
    End Sub

    Private Sub tb_Igss_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Igss.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Licencia.Focus()
        End If
    End Sub

    Private Sub tb_Licencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Licencia.KeyPress
        If e.KeyChar = Chr(13) Then
            cb_tipo.Focus()
        End If
    End Sub

    Private Sub cb_tipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_tipo.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Direccion.Focus()
        End If
    End Sub

    Private Sub tb_Direccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Direccion.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Telefono.Focus()
        End If
    End Sub

    Private Sub tb_Telefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Telefono.KeyPress
        If e.KeyChar = Chr(13) Then
            cb_Region.Focus()
        End If
    End Sub

    Private Sub tb_Sueldo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Sueldo.KeyPress
        Dim sueldo As Double
        'Dim Msueldo As String

        If e.KeyChar = Chr(13) Then 'Chr(Keys.Tab) Then
            If Not IsNumeric(tb_Sueldo.Text) Then
                MsgBox("Debe Ingresar Valor Correcto", MsgBoxStyle.Critical, "Sueldo")
                tb_Sueldo.Focus()
                tb_Sueldo.SelectAll()
            Else

                sueldo = CDbl(tb_Sueldo.Text)
                tb_Sueldo.Text = Format(sueldo, "###,##0.00")
                btn_Grabar.Focus()
            End If
        End If
    End Sub

    Private Sub cb_Region_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_Region.SelectedValueChanged
        Dim ls_sql As String
        Dim tipos_doctos(20) As String
        Dim ldt_table, ldt_table_ As New DataTable
        Dim oTransaccion As New Transaccional.Conexion("flexline")
        oTransaccion.open()

        ls_sql = "pa_vb_rrhh_Departamento '" & cb_Region.Text & "'"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "depto"

        Me.cb_Departamento.DisplayMember = "Departamento"
        Me.cb_Departamento.ValueMember = "Departamento"
        Me.cb_Departamento.DataSource = ldt_table.DefaultView
    End Sub

    Private Sub cb_Departamento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_Departamento.SelectedValueChanged
        Dim ls_sql As String
        Dim tipos_doctos(20) As String
        Dim ldt_table, ldt_table_ As New DataTable
        Dim oTransaccion As New Transaccional.Conexion("flexline")
        oTransaccion.open()

        ls_sql = "pa_vb_rrhh_Municipio '" & cb_Region.Text & "','" & cb_Departamento.Text & "'"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "muni"

        Me.cb_Municipio.DisplayMember = "Municipio"
        Me.cb_Municipio.ValueMember = "Municipio"
        Me.cb_Municipio.DataSource = ldt_table.DefaultView
    End Sub

    Private Sub cb_Depto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Depto.KeyPress
        If e.KeyChar = Chr(13) Or e.KeyChar = Chr(10) Then
            tb_Sueldo.Focus()
        End If
    End Sub

    Private Sub btn_Grabar_Click(sender As Object, e As EventArgs) Handles btn_Grabar.Click
        If btn_Grabar.Text = "Grabar" Then
            If MsgBox("Seguro de Guardar los Datos??", MsgBoxStyle.YesNo, "Guardar") = MsgBoxResult.Yes Then
                Validar()
                Limpiar()
            End If
        Else
            If MsgBox("Seguro de Actualizar los Datos??", MsgBoxStyle.YesNo, "Guardar") = MsgBoxResult.Yes Then
                Validar()
                Limpiar()
            End If
        End If

    End Sub

    Private Sub Validar()
        Try
            If tb_Identificacion.Text.Length = 0 Then
                MsgBox("Debe Ingresar Identificación", MsgBoxStyle.Critical, "Ingresar Dato")
                tb_Identificacion.Focus()

            ElseIf tb_PrimerNombre.Text.Length = 0 Then
                MsgBox("Debe Ingresar Primer Nombre", MsgBoxStyle.Critical, "Ingresar Dato")
                tb_PrimerNombre.Focus()

            ElseIf tb_PrimerApellido.Text.Length = 0 Then
                MsgBox("Debe Ingresar Primer Apellido", MsgBoxStyle.Critical, "Ingresar Dato")
                tb_PrimerNombre.Focus()

            ElseIf cb_Sexo.Text.Length = 0 Then
                MsgBox("Debe seleccionar Sexo", MsgBoxStyle.Critical, "Seleccionar Dato")
                cb_Sexo.Focus()

            ElseIf dtp_FechaNac.Text.Length = 0 Then
                MsgBox("Debe ingresar Fecha de Nacimiento Valida", MsgBoxStyle.Critical, "Ingresar Dato")
                dtp_FechaNac.Focus()

            ElseIf cb_Estado.Text.Length = 0 Then
                MsgBox("Debe Seleccionar Estado Civil", MsgBoxStyle.Critical, "Seleccionar Dato")
                cb_Estado.Focus()

            ElseIf tb_Direccion.Text.Length = 0 Then
                MsgBox("Debe Ingresar Direccion", MsgBoxStyle.Critical, "Ingresar Dato")
                tb_Direccion.Focus()

            ElseIf cb_Depto.Text.Length = 0 Then
                MsgBox("Debe Seleccionar Departamento", MsgBoxStyle.Critical, "Seleccionar Dato")
                cb_Depto.Focus()

            ElseIf cb_Cargo.Text.Length = 0 Then
                MsgBox("Debe Seleccionar Cargo", MsgBoxStyle.Critical, "Seleccionar Dato")
                cb_Cargo.Focus()

            ElseIf tb_Sueldo.Text.Length = 0 Then
                MsgBox("Debe Ingresar Sueldo", MsgBoxStyle.Critical, "Ingresar Dato")
                tb_Sueldo.Focus()
            Else
                If btn_Grabar.Text = "Grabar" Then
                    Guardar()
                Else
                    Actualizar()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub Guardar()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim sueldos As Double
        Dim Sueldo As String
        Dim dt As DataTable
        ' Dim Imagen As System.Drawing.Image

        Try

            otrans.open()

            sueldos = CDbl(tb_Sueldo.Text)
            Sueldo = Format(sueldos, "#####0.00")

            '           Imagen = PictureBox1.Image

            lsSQL = "pa_vb_Candidatos_RRHH  '" & gs_empresa & "','" & tb_Identificacion.Text & "','" & tb_PrimerNombre.Text & "','" & tb_SegunoNombre.Text & "','" & tb_PrimerApellido.Text & "','" & tb_SegundoApellido.Text & "','" & _
            tb_apellidoCasada.Text & "','" & cb_Sexo.Text & "','" & dtp_FechaNac.Text & "','" & tb_Nit.Text & "','" & cb_Estado.Text & "','" & tb_Igss.Text & "','" & _
            tb_Licencia.Text & "','" & cb_tipo.Text & "','" & tb_Direccion.Text & "','" & tb_Telefono.Text & "','" & cb_Municipio.Text & "','" & cb_Departamento.Text & "','" & cb_Region.Text & "','" & _
            cb_Pais.Text & "','" & cb_Depto.Text & "','" & cb_Cargo.Text & "','" & Sueldo & "','" & dtp_FechaInicia.Text & "','" & cb_Contrato.Text & "','" & gs_usuario & "'"
            dt = otrans.Obtiene(lsSQL)
            ' lsSQL = "Insert Into AlmacenarImagenes(Imagen)Values(@Imagen)"
            MsgBox("Grabado Correctamente!!")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Actualizar()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim sueldos As Double
        Dim Sueldo As String
        Dim dt As DataTable

        Try

            otrans.open()

            sueldos = CDbl(tb_Sueldo.Text)
            Sueldo = Format(sueldos, "#####0.00")

            lsSQL = "pa_vb_Candidatos_RRHH_Actualiza  '" & gs_empresa & "','" & tb_Identificacion.Text & "','" & tb_PrimerNombre.Text & "','" & tb_SegunoNombre.Text & "','" & tb_PrimerApellido.Text & "','" & tb_SegundoApellido.Text & "','" & _
            tb_apellidoCasada.Text & "','" & cb_Sexo.Text & "','" & dtp_FechaNac.Text & "','" & tb_Nit.Text & "','" & cb_Estado.Text & "','" & tb_Igss.Text & "','" & _
            tb_Licencia.Text & "','" & cb_tipo.Text & "','" & tb_Direccion.Text & "','" & tb_Telefono.Text & "','" & cb_Municipio.Text & "','" & cb_Departamento.Text & "','" & cb_Region.Text & "','" & _
            cb_Pais.Text & "','" & cb_Depto.Text & "','" & cb_Cargo.Text & "','" & Sueldo & "','" & dtp_FechaInicia.Text & "','" & cb_Contrato.Text & "','" & gs_usuario & "'"
            dt = otrans.Obtiene(lsSQL)

            MsgBox("Actualizado Correctamente!!")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Reporte()
        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(1), pm_valores_consolidado(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(1) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt

        Try

            pm_conexion = ClsGen.Parametros_Conexion("SCM")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "\Recursos Humanos\Generales\" & contrato & ".rpt"

            pm_parametros(0) = "@Empresa"
            pm_valores(0) = gs_empresa

            pm_parametros(1) = "@Identificacion"
            pm_valores(1) = tb_Identificacion.Text


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub Busca_Candidatos()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()
            lsSQL = "pa_vb_Busca_Candidatos '" & gs_empresa & "','" & tb_Identificacion.Text & "'"
            dt = otrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then
                Me.tb_PrimerNombre.Text = dt.Rows(0)("PrimerNombre").ToString
                Me.tb_SegunoNombre.Text = dt.Rows(0)("SegundoNombre").ToString
                Me.tb_PrimerApellido.Text = dt.Rows(0)("PrimerApellido").ToString
                Me.tb_SegundoApellido.Text = dt.Rows(0)("SegundoApellido").ToString
                Me.tb_apellidoCasada.Text = dt.Rows(0)("ApellidoCasada").ToString
                Me.cb_Sexo.Text = dt.Rows(0)("Sexo").ToString
                Me.dtp_FechaNac.Text = dt.Rows(0)("FechaNac").ToString
                Me.tb_Nit.Text = dt.Rows(0)("Nit").ToString
                Me.cb_Estado.Text = dt.Rows(0)("EstadoCivil").ToString
                Me.tb_Igss.Text = dt.Rows(0)("AfiliacionIgss").ToString
                Me.tb_Licencia.Text = dt.Rows(0)("LicenciaNo").ToString
                Me.cb_tipo.Text = dt.Rows(0)("LicenciaTipo").ToString
                Me.tb_Direccion.Text = dt.Rows(0)("Direccion").ToString
                Me.tb_Telefono.Text = dt.Rows(0)("Telefono").ToString
                Me.cb_Region.Text = dt.Rows(0)("Region").ToString
                Me.cb_Departamento.Text = dt.Rows(0)("Departamento").ToString
                Me.cb_Municipio.Text = dt.Rows(0)("Municipio").ToString
                Me.cb_Pais.Text = dt.Rows(0)("Pais").ToString
                Me.cb_Depto.Text = dt.Rows(0)("DeptoCargo").ToString
                Me.cb_Cargo.Text = dt.Rows(0)("Cargo").ToString
                Me.dtp_FechaInicia.Text = dt.Rows(0)("FechaInicia").ToString
                Me.cb_Contrato.Text = dt.Rows(0)("TipoContrato").ToString
                Me.tb_Sueldo.Text = dt.Rows(0)("Sueldo").ToString
                btn_Grabar.Text = "Actualizar"
                tb_Identificacion.Enabled = False
                AgregarEnFlexLineToolStripMenuItem.Enabled = True
            Else
                If MsgBox("Empleado No Existe, Desea Crear uno Nuevo?", MsgBoxStyle.YesNo, tb_Identificacion.Text) = MsgBoxResult.Yes Then
                    cb_Sexo.Focus()
                Else
                    tb_Identificacion.Focus()
                    tb_Identificacion.SelectAll()
                End If

            End If

        Catch ex As Exception
            MsgBox("Empleado No Existe, Verifique", MsgBoxStyle.Critical, tb_Identificacion.Text)

        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Limpiar()
        tb_Identificacion.Text = ""
        tb_PrimerNombre.Text = ""
        tb_SegunoNombre.Text = ""
        tb_PrimerApellido.Text = ""
        tb_SegundoApellido.Text = ""

        tb_apellidoCasada.Text = ""
        cb_Sexo.Text = ""
        dtp_FechaNac.Text = ""
        tb_Nit.Text = ""
        cb_Estado.Text = ""
        tb_Igss.Text = ""

        tb_Licencia.Text = ""
        cb_tipo.Text = ""
        tb_Direccion.Text = ""
        tb_Telefono.Text = ""
        cb_Municipio.Text = ""
        cb_Departamento.Text = ""
        cb_Region.Text = ""
        cb_Pais.Text = ""
        cb_Depto.Text = ""
        cb_Cargo.Text = ""
        tb_Sueldo.Text = "0.00"
        dtp_FechaInicia.Text = ""
        cb_Contrato.Text = ""
        tb_Identificacion.Enabled = True
        tb_Identificacion.Focus()
    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        Limpiar()
    End Sub

    Private Sub btn_seleccionar_Click(sender As Object, e As EventArgs) Handles btn_seleccionar.Click
        'OpenFileDialog1.ShowDialog()
        'Label39.Text = OpenFileDialog1.FileName.ToString
        'PictureBox1.Image = System.Drawing.Image.FromFile(Label39.Text)
    End Sub

    Private Sub AgregarEnFlexLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarEnFlexLineToolStripMenuItem.Click
        If MsgBox("Desea Trasladar a Flexline?", MsgBoxStyle.YesNo, tb_Identificacion.Text) = MsgBoxResult.Yes Then
            Carga_Candidato()
            Limpiar()
        End If
    End Sub

    Private Sub Carga_Candidato()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()

            lsSQL = "pa_vb_Carga_Candidato  '" & gs_empresa & "','" & tb_Identificacion.Text & "','" & gs_usuario & "'"
            dt = otrans.Obtiene(lsSQL)

            MsgBox("Trasladado a FLEXLINE Correctamente!!", MsgBoxStyle.Information, "Flexline")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        Dim oform As New Frm_empleados
        oform.ShowDialog()

        tb_Identificacion.Text = oform.Ficha
        cb_Sexo.Text = oform.Sexo
        tb_PrimerNombre.Text = oform.PrimerNombre
        tb_PrimerApellido.Text = oform.PrimerApellido
        tb_SegundoApellido.Text = oform.SegundoApellido
        dtp_FechaNac.Text = oform.Fecha_Nac
        tb_Nit.Text = oform.Nit
        cb_Estado.Text = oform.Estado
        tb_Igss.Text = oform.Igss
        tb_Licencia.Text = oform.Licencia
        tb_Direccion.Text = oform.Direccion
        tb_Telefono.Text = oform.Telefono
        cb_Departamento.Text = oform.Depto
        cb_Municipio.Text = oform.Municipio
        cb_Pais.Text = oform.Pais
        cb_Depto.Text = oform.Departamento
        cb_Cargo.Text = oform.Cargo
        dtp_FechaInicia.Text = oform.FechaInicio
        tb_Sueldo.Text = oform.Sueldo.ToString
    End Sub
End Class