Public Class frm_HOrarioAlmuerzo

    Private Sub Horarios_Extraordinarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_combo()
        actualizar_almuerzo(Convert.ToString(clbx_empleados.SelectedItem(1)))
    End Sub

    Private Function validarHora() As Boolean
        Dim lbHorarioValido As Boolean = False

        Try
            If Me.dtp_Hora_Entrada.Value < Me.dtp_Hora_Salida.Value Then
                lbHorarioValido = True
            Else
                MessageBox.Show("Verifique el Horario", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
        End Try

        Return lbHorarioValido
    End Function

    Private Sub cargar_combo()
        Dim OTrans As New Transaccional.Conexion("SCM")
        Dim dt As New DataTable
        Dim Ods As New DataSet
        Dim ls_sql As String

        Try
            OTrans.open()
            ls_sql = "pa_sel_um_seg_usuario_horarios_divisiones"
            dt = OTrans.Obtiene(ls_sql)
            dt.TableName = "divisiones"
            Ods.Tables.Add(dt.Copy)

            Me.cmb_Division.DataSource = Ods.Tables("divisiones")
            Me.cmb_Division.DisplayMember = "division"

            cargar_empleados()

        Catch ex As Exception
            MsgBox(ex, " Error en la conexion Usuarios")
        Finally
            OTrans.close()
            OTrans = Nothing

        End Try
    End Sub

    Private Sub guardar_cambios(ByVal usuario As String, ByVal num_card As String)
        Dim sl_sql As String
        Dim dt As New DataTable
        Dim fecha, horaSalida, horaEntrada As Date
        Dim scmTrans As New Transaccional.Conexion("SCM")
        Dim liDias As Integer

        fecha = dtp_Fecha_Inicio.Text
        horaEntrada = dtp_Hora_Entrada.Text
        horaSalida = dtp_Hora_Salida.Text
        Try
            liDias = DateDiff(DateInterval.Day, dtp_Fecha_Inicio.Value, Me.dtp_Fecha_Final.Value)

            'Verifico si ya existe un horario asignado para el empleado y fecha
            scmTrans.open()
            sl_sql = "pa_sel_um_seg_usuario_horarios_extraordinario_buscar '" & num_card & "','" & Convert.ToDateTime(dtp_Fecha_Inicio.Text).ToString("dd/MM/yyyy") & "',' " & Convert.ToDateTime(dtp_Fecha_Final.Text).ToString("dd/MM/yyyy") & "'"
            dt = scmTrans.Obtiene(sl_sql)

            'Si ya existe horario para este dia confirmo actualizacion
            If (dt.Rows.Count > 0) Then
                If MessageBox.Show("Ya existe un horario asignado en la fecha " & dt.Rows(0).Item("fecha") & " para '" & _
                                            usuario & "'. Desea actualizar?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    sl_sql = "pa_upd_um_seg_usuario_horarios_extraordinario '" & num_card & "','" & _
                                            usuario & "','" & fecha.ToString("dd/MM/yyyy") & "','" & _
                                            horaEntrada.ToString("HH:mm:ss") & "','" & horaSalida.ToString("HH:mm:ss") & _
                                            "','" & gs_usuario & "',' " & Now() & "'"

                    scmTrans.Actualiza(sl_sql)

                End If

            End If

            'Guardo todos los que aun no existen
            For iCount As Integer = 0 To liDias
                If (dt.Compute("count(num_card)", "num_card='" & num_card & "' and fecha='" & fecha.AddDays(iCount).ToString("dd/MM/yyyy") & "'")) = 0 Then
                    sl_sql = "pa_ins_um_seg_usuario_horarios_extraordinario '" & num_card & "','" & usuario & "','" & _
                                               fecha.AddDays(iCount).ToString("dd/MM/yyyy") & "','" & horaEntrada.ToString("HH:mm:ss") & "','" & _
                                               horaSalida.ToString("HH:mm:ss") & "','" & gs_usuario & "',' " & Now() & "'"

                    scmTrans.Ingresa(sl_sql)

                    If scmTrans.Codigo_error > 0 Then MessageBox.Show("ERROR: " & scmTrans.descripcion_error)
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("ERROR: " & scmTrans.descripcion_error & ", " & ex.Message)
        Finally
            scmTrans.close()
            scmTrans = Nothing

        End Try

    End Sub

    Private Function validarInformacion() As Boolean

        Dim ldFechaInicio As New Date
        Dim ldFechaFinal As New Date
        Dim lbCorrecto As Boolean = True
        Try
            For Each row As DataGridViewRow In Me.dgv_Historial.Rows
                ldFechaInicio = "01/01/1900 " & row.Cells("Hora Entrada").Value
                ldFechaFinal = "01/01/1900 " & row.Cells("Hora Salida").Value

                If ldFechaInicio > ldFechaFinal Then
                    MessageBox.Show("Horario para " & row.Cells("fecha").Value.ToString & " Incorrecto", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    lbCorrecto = False
                End If

            Next

        Catch ex As Exception
            MessageBox.Show("Existen Horarios Incorrectos, Por Favor Revise", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lbCorrecto = False
        End Try


        Return lbCorrecto
    End Function

    Private Sub actualizar_almuerzo(ByVal nombre As String)
        Dim ls_sql As String
        Dim oTrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            oTrans.open()

            ls_sql = "pa_sel_um_usuario_almuerzo '" & nombre & "'"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "historial"
            ds.Tables.Add(dt.Copy)

            dgv_Historial.DataSource = ds.Tables("historial")
            clsGen.Alinear_GridView(dt, Me.dgv_Historial, ",nombre,hora_inicio,hora_final,fecha_inicio,", "", "", "", "", "", "", True, True, 250, 0)

        Catch ex As Exception
            MessageBox.Show("ERROR: " & oTrans.descripcion_error)

        Finally
            oTrans.close()
            oTrans = Nothing
            clsGen = Nothing

        End Try

    End Sub


    Private Sub eliminarLineaActual()

        Dim scmTrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try
            scmTrans.open()
            lsSQL = "pa_del_um_seg_usuario_horarios_extraordinario '" & clbx_empleados.SelectedValue & "', '" & _
            Me.dgv_Historial.Item("fecha", Me.dgv_Historial.CurrentRow.Index).Value & "'"
            scmTrans.Elimina(lsSQL)
            If scmTrans.Codigo_error = 0 Then
                MessageBox.Show("Horario Eliminado Correctamente")
            End If

        Catch ex As Exception
        Finally
            scmTrans.close()
            scmTrans = Nothing
        End Try


    End Sub


    Private Sub btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Guardar.Click
        Dim oTransSCM As New Transaccional.Conexion("SCM")
        Dim sql As String
        oTransSCM.open()
        If (chkPermanente.Checked) Then
            'ser va a hacer update a la tabla principal

            sql = "pa_upd_um_seg_usuario_horario_almuerzo '" & clbx_empleados.SelectedValue & "', '" & dtp_Hora_Entrada.Text & "', '" & dtp_Hora_Salida.Text & "' "
            oTransSCM.Actualiza(sql)

        Else
            'se crea una actividad con hora de almuerzo

            sql = "pa_ins_um_seg_usuario_otras_actividades '" & gs_empresa & "', '" & clbx_empleados.SelectedItem(1).ToString & "', '" & dtp_Hora_Entrada.Text & "', '" & dtp_Hora_Salida.Text & "', '" & _
                    dtp_Fecha_Inicio.Text & "', '" & dtp_Fecha_Final.Text & "', 'ALMUERZO', '" & gs_usuario & "', 'Hora distinta de almuerzo.'"
            oTransSCM.Ingresa(sql)
        End If
        oTransSCM.close()
        'If validarHora() Then


        '    If MessageBox.Show("Esta seguro de guardar estos horarios? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        '        For i As Integer = 0 To clbx_empleados.Items.Count - 1
        '            If clbx_empleados.GetItemChecked(i) Then
        '                clbx_empleados.SetSelected(i, True)
        '                guardar_cambios(clbx_empleados.Text, Convert.ToString(clbx_empleados.SelectedValue))
        '            End If

        '        Next
        '        MessageBox.Show("Proceso Finalizado")
        '        actualizar_historial(Convert.ToString(clbx_empleados.SelectedValue))

        '    End If
        'End If
    End Sub


    Private Sub cmb_Division_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Division.SelectionChangeCommitted
        cargar_empleados()


    End Sub

    Private Function cargar_empleados()
        Dim OTrans As New Transaccional.Conexion("SCM")
        Dim ls_sql As String
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim index As Integer

        Try
            OTrans.open()
            ls_sql = "pa_sel_um_seg_usuario_horarios '" & cmb_Division.Text & "'"
            dt = OTrans.Obtiene(ls_sql)
            dt.TableName = "empleados"
            ds.Tables.Add(dt.Copy)

            clbx_empleados.DataSource = ds.Tables("empleados")
            clbx_empleados.DisplayMember = "nombre"
            clbx_empleados.ValueMember = "num_card"

            actualizar_almuerzo(Convert.ToString(clbx_empleados.SelectedItem(1).ToString))

        Catch ex As Exception
            MessageBox.Show("ERROR: " & OTrans.descripcion_error)

        Finally

            OTrans.close()
            OTrans = Nothing
        End Try

    End Function

    Private Sub clbx_empleados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbx_empleados.Click
        actualizar_almuerzo(clbx_empleados.SelectedItem(1).ToString)

    End Sub

    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        EliminarLineaActual()
    End Sub


    Private Sub cmb_Division_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Division.SelectedIndexChanged

    End Sub
End Class
