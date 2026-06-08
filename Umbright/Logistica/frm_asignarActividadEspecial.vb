Imports System.Windows.Forms
Public Class frm_asignarActividadEspecial
    Private clsGen As New ClasesGenerales.General
    Private oTrans As New Transaccional.Conexion("flexline")
    Private oTransSCM As New Transaccional.Conexion("SCM")
    Private dt As DataTable
    Private sql As String
    Private isEdit As Boolean = False
    Private Sub frm_asignarActividadEspecial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getDivisiones()
    End Sub

    Private Sub cmbDivision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDivision.SelectedIndexChanged
        getEmpleados()
    End Sub

    Private Sub cmbEmpleado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpleado.SelectedIndexChanged
        llenarGridActividades()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (Me.isEdit) Then


        Else
            sql = "pa_ins_um_seg_usuario_otras_actividades '" & gs_empresa & "', '" & cmbEmpleado.Text & _
                     "','" & dtpHoraInicio.Text & "','" & dtpHoraFin.Text & "','" & dtpFechaInicio.Text & _
                     "','" & dtpFechaFin.Text & "','EN CURSO', '" & gs_usuario & "','" & txComentarios.Text & "'"
            clsGen.insertQuery("SCM", sql)
        End If
        
        llenarGridActividades()
        txComentarios.Text = ""
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        isEdit = True
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        isEdit = False
        getDivisiones()
        getEmpleados()
        llenarGridActividades()
        txComentarios.Text = ""
        MessageBox.Show("Se ha limpiado correctamente", "Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub getDivisiones()
        clsGen.fillComboBox(oTransSCM, "pa_sel_um_seg_usuario_horarios_divisiones", "divisiones", "division", "division", cmbDivision)
    End Sub

    Private Sub getEmpleados()
        clsGen.fillComboBox(oTransSCM, "pa_sel_um_seg_usuario_horarios '" & cmbDivision.Text & "'", "empleados", "nombre", "num_card", cmbEmpleado)
    End Sub

    Private Sub llenarGridActividades()
        Try
            oTransSCM.open()
            sql = "pa_sel_um_seg_usuario_otras_actividades '" & cmbEmpleado.Text & "'"
            dt = oTransSCM.Obtiene(sql)
            dgActividadesHistorial.DataSource = dt
            clsGen.Alinear_GridView(dt, dgActividadesHistorial, ",nombre,hora_inicio,hora_final,fecha_inicio,fecha_final,estado,detalle,", "", "", "", False, True, 300, 1)
        Catch ex As Exception

        Finally
            oTransSCM.close()
            dt = Nothing
        End Try
    End Sub

    Private Sub btnCompletar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompletar.Click
        Dim row As Integer = -1
        Dim estado As String
        Try
            row = dgActividadesHistorial.SelectedCells(0).RowIndex
        Catch ex As Exception
            MessageBox.Show("No hay ninguna línea seleccionada", " ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If row > -1 Then
            estado = dgActividadesHistorial.Rows(row).Cells("estado").Value.ToString
            If (estado.Equals("COMPLETADO")) Then
                MessageBox.Show("La actividad seleccionada ya ha sido completada", " ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                sql = "pa_upd_um_seg_usuario_otras_actividades NULL,NULL,NULL,NULL,NULL,'COMPLETADO', '" & _
                        dgActividadesHistorial.Rows(row).Cells("nombre").Value.ToString & "', '" & _
                        dgActividadesHistorial.Rows(row).Cells("hora_inicio").Value.ToString & "', '" & _
                        dgActividadesHistorial.Rows(row).Cells("hora_final").Value.ToString & "', '" & _
                        dgActividadesHistorial.Rows(row).Cells("fecha_inicio").Value.ToString & "', '" & _
                        dgActividadesHistorial.Rows(row).Cells("fecha_final").Value.ToString & "'"

                Try
                    oTransSCM.open()
                    oTransSCM.Actualiza(sql)
                Catch ex As Exception
                Finally
                    oTransSCM.close()
                    llenarGridActividades()
                    MessageBox.Show("La actividad ha sido marcada como completada", "Completada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        If (MessageBox.Show("Está seguro que desea eliminar? ", "Eliminar", MessageBoxButtons.YesNo)) Then
            Dim row As Integer = -1
            Try
                row = dgActividadesHistorial.SelectedCells(0).RowIndex
            Catch ex As Exception
                MessageBox.Show("No hay ninguna línea seleccionada", " ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            If row > -1 Then
                sql = "pa_del_um_seg_usuario_otras_actividades '" & _
                        dgActividadesHistorial.Rows(row).Cells("nombre").Value.ToString & "', '" & _
                        dgActividadesHistorial.Rows(row).Cells("hora_inicio").Value.ToString & "', '" & _
                        dgActividadesHistorial.Rows(row).Cells("hora_final").Value.ToString & "', '" & _
                        dgActividadesHistorial.Rows(row).Cells("fecha_inicio").Value.ToString & "', '" & _
                        dgActividadesHistorial.Rows(row).Cells("fecha_final").Value.ToString & "'"
                Try
                    oTransSCM.open()
                    oTransSCM.Elimina(sql)
                Catch ex As Exception
                Finally
                    oTransSCM.close()
                    llenarGridActividades()
                    MessageBox.Show("La actividad ha sido eliminada", "Completada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End If
        End If
    End Sub
End Class