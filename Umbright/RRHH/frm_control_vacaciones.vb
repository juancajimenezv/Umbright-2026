Public Class frm_control_vacaciones

    Private Sub btn_ayuda_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda.Click
        Dim frm_busqueda As New frm_busqueda_empleado
        Dim fecha_i, fecha_f As String

        frm_busqueda.ShowDialog()

        If frm_busqueda.ficha <> "" Then

            Me.txt_nombre.Text = frm_busqueda.nombre
            Me.txt_empresa.Text = frm_busqueda.empresa
            Me.txt_departamento.Text = frm_busqueda.depto
            Me.txt_puesto.Text = frm_busqueda.puesto
            fecha_i = frm_busqueda.fecha_ingreso
            fecha_f = frm_busqueda.fecha_fin
            Me.txt_fecha_ingreso.Text = Mid(fecha_i, 7, 2) & "/" & Mid(fecha_i, 5, 2) & "/" & Mid(fecha_i, 1, 4)
            Me.txt_fecha_final.Text = Mid(fecha_f, 7, 2) & "/" & Mid(fecha_f, 5, 2) & "/" & Mid(fecha_f, 1, 4)

            If frm_busqueda.estado = "INACTIVO" Then
                Lbl_estado.Visible = True
                lbl_fec_final.Visible = True
                txt_fecha_final.Visible = True

            Else
                Lbl_estado.Visible = False
                lbl_fec_final.Visible = False
                txt_fecha_final.Visible = False

            End If
            Me.txt_ficha.Text = ""
            Me.txt_ficha.Text = frm_busqueda.ficha

        End If

    End Sub

    Private Sub actualizar_datos()
        Dim dt As DataTable
        Dim total_disponibles As Double
        dgv_periodo_dias.Rows.Clear()

        'If Lbl_estado.Visible = False And txt_ficha.Text <> "" Then
        If txt_ficha.Text <> "" Then
            dt = Calcular_Dias_Disponibles_Periodo()

            total_disponibles = 0

            For Each dr As DataRow In dt.Rows
                dgv_periodo_dias.Rows.Add(dr.Item("periodo"), dr.Item("dias_disponibles"))
                total_disponibles = total_disponibles + dr.Item("dias_disponibles")

            Next
            txt_dias_disponibles.Text = total_disponibles

        End If

        If Lbl_estado.Visible = True Then
            btn_guardar.Enabled = False
            txt_dias_solicitados.ReadOnly = True
        Else
            btn_guardar.Enabled = True
            txt_dias_solicitados.ReadOnly = False


        End If

        'End If

    End Sub

    Private Sub txt_ficha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ficha.TextChanged
        actualizar_datos()

    End Sub

    Private Function obtener_periodos()
        Dim ultima_fecha, ultimo_periodo As String
        Dim año, año_anterior, año_posterior As Integer
        Dim fecha As DateTime
        Dim dt As New DataTable

        fecha = Now
        If Lbl_estado.Visible = True Then fecha = CDate(txt_fecha_final.Text).ToString("dd/MM/yyyy")

        año = CDate(fecha).ToString("yyyy")
        ultima_fecha = Convert.ToDateTime(txt_fecha_ingreso.Text).ToString("dd/MM/") & año

        If DateDiff(DateInterval.Day, CDate(ultima_fecha), fecha) < 0 Then
            año_anterior = año - 1
            año_posterior = año

        Else
            año_anterior = año
            año_posterior = año + 1

        End If

        dt.Columns.Add("periodo", GetType(String))

        For i As Integer = 0 To 6
            dt.Rows.Add(año_anterior - i & "-" & (año_posterior - i))

        Next

        Return dt

    End Function


    Private Function Calcular_Dias_Disponibles_Periodo()
        Dim oTrans As New Transaccional.Conexion("SCM")
        Dim dt, dt_periodos As New DataTable
        Dim periodo_actual, ultima_fecha, ls_sql As String
        Dim dias_actual, año_ingreso As Integer
        Dim fecha As DateTime
        Dim dRow() As DataRow

        año_ingreso = Convert.ToDateTime(txt_fecha_ingreso.Text).ToString("yyyy")
        dt_periodos = obtener_periodos()
        periodo_actual = dt_periodos.Rows(0).Item(0)
        ultima_fecha = Convert.ToDateTime(txt_fecha_ingreso.Text).ToString("dd/MM/") & Split(periodo_actual, "-")(0)
        dt_periodos.Columns.Add("dias_disponibles", GetType(String))

        'Calcular dias disponibles, proporcionales al periodo actual

        If Lbl_estado.Visible = True Then
            fecha = CDate(txt_fecha_final.Text).ToString("dd/MM/yyyy")
        Else
            fecha = Now
        End If
        dias_actual = DateDiff(DateInterval.Day, CDate(ultima_fecha), fecha)
        dias_actual = (dias_actual * 15 / 365)

        Try
            oTrans.open()
            ls_sql = "pa_sel_um_seg_usuario_vacaciones_gozadas '" & txt_empresa.Text & "','" & txt_ficha.Text & "'"
            dt = oTrans.Obtiene(ls_sql)

            'Calculo los dias disponibles
            For Each dr As DataRow In dt_periodos.Rows
                dr.Item("dias_disponibles") = 0

                If (Split(dr.Item("periodo"), "-")(0)) >= año_ingreso Then
                    dRow = dt.Select("periodo = '" & dr.Item("periodo") & "'")

                    If dRow.Length <= 0 Then
                        dr.Item("dias_disponibles") = 15

                        If dr.Item("periodo") = periodo_actual Then dr.Item("dias_disponibles") = dias_actual

                    Else
                        dr.Item("dias_disponibles") = 15 - (dRow(0).Item("dias_gozados"))

                        If Trim(dRow(0).Item("periodo").ToString) = periodo_actual Then
                            dr.Item("dias_disponibles") = dias_actual - (dRow(0).Item("dias_gozados"))

                        End If

                    End If

                End If
            Next

            Return dt_periodos

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            oTrans.close()
            oTrans = Nothing

        End Try

    End Function

    Dim validar As Boolean

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        validar = False
        validar_datos()

        If validar = True Then
            If MessageBox.Show("Esta seguro de guardar " & txt_dias_solicitados.Text & " dias de vacaciones para " & txt_nombre.Text & "?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                guardar_datos()
                actualizar_historial()

            End If
        End If

    End Sub

    Private Function guardar_datos()
        Dim oTrans As New Transaccional.Conexion("SCM")
        Dim ls_sql, periodo As String
        Dim dias, dias_disponibles, dias_solicitados As Double

        Try
            oTrans.open()
            dias_solicitados = txt_dias_solicitados.Text

            For i As Integer = dgv_periodo_dias.Rows.Count - 1 To 0 Step -1
                dias_disponibles = Convert.ToDouble(dgv_periodo_dias.Item("dias_disponibles", i).Value)
                periodo = Trim(dgv_periodo_dias.Item("periodo", i).Value.ToString)


                If dias_disponibles > 0 And dias_solicitados > 0 Then

                    If dias_disponibles <= dias_solicitados Then
                        dias = dias_disponibles
                        dias_solicitados = dias_solicitados - dias_disponibles


                    Else
                        dias = dias_solicitados
                        dias_solicitados = 0

                    End If

                    ls_sql = "pa_ins_um_seg_usuario_vacaciones '" & txt_empresa.Text & "','" & txt_ficha.Text & "','" & _
                                                            dtp_Inicio_Vacaciones.Text & "','" & dtp_fin_vacaciones.Text & "','" & _
                                                            periodo & "','" & dias & "','" & gs_usuario & "','" & Now() & "'"

                    oTrans.Ingresa(ls_sql)

                End If

            Next

            If oTrans.Codigo_error = 0 Then
                MessageBox.Show("Registro de vacaciones de " & txt_nombre.Text & " guardado correctamente.")
                limpiar()

            Else
                MessageBox.Show("Problemas al guardar, Favor verificar datos.")

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)

        Finally
            oTrans.close()

        End Try

    End Function

    Private Function limpiar()

        txt_nombre.Text = ""
        txt_empresa.Text = ""
        txt_fecha_ingreso.Text = ""
        txt_departamento.Text = ""
        txt_puesto.Text = ""
        txt_ficha.Text = ""
        txt_dias_disponibles.Text = ""
        txt_dias_solicitados.Text = ""
        dtp_Inicio_Vacaciones.Text = Now()
        dtp_fin_vacaciones.Text = Now()

        Lbl_estado.Visible = False
        lbl_fec_final.Visible = False
        txt_fecha_final.Visible = False

        btn_ayuda.Focus()

    End Function


    Private Function validar_datos()
        Dim dias As Integer

        dias = DateDiff(DateInterval.Day, CDate(dtp_Inicio_Vacaciones.Text), CDate(dtp_fin_vacaciones.Text))
        If txt_ficha.Text <> "" Then
            If IsNumeric(txt_dias_solicitados.Text) = True And IsNumeric(txt_dias_disponibles.Text) Then

                If Convert.ToDecimal(txt_dias_disponibles.Text) >= Convert.ToDecimal(txt_dias_solicitados.Text) Then

                    If (dias + 1) >= Convert.ToDecimal(txt_dias_solicitados.Text) Then
                        validar = True

                    Else
                        MessageBox.Show("ERROR: El total de dias entre la Fecha Inicio y Fecha Final es menor a los dias solicitados.")
                        txt_dias_solicitados.Focus()

                    End If

                Else
                    MessageBox.Show("ERROR: No cuenta con los suficientes dias disponibles.")
                    txt_dias_solicitados.Focus()

                End If

            Else
                MessageBox.Show("ERROR: El campo dias solicitados debe ser Numérico.")
                txt_dias_solicitados.Focus()

            End If

        Else
            MessageBox.Show("ERROR: No hay datos.")

        End If
        
    End Function

    Private Sub btn_historial_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_historial_buscar.Click
        Dim frm_busqueda_empleado As New frm_busqueda_empleado

        frm_busqueda_empleado.ShowDialog()

        If frm_busqueda_empleado.ficha <> "" Then
            txt_historial_nombre.Text = frm_busqueda_empleado.nombre
            txt_historial_ficha.Text = frm_busqueda_empleado.ficha
            txt_historial_empresa.Text = frm_busqueda_empleado.empresa

            If frm_busqueda_empleado.estado = "ACTIVO" Then
                btn_historial_eliminar.Enabled = True
                lbl_historial_estado.Visible = False

            Else
                btn_historial_eliminar.Enabled = False
                lbl_historial_estado.Visible = True

            End If

            actualizar_historial()

        End If

    End Sub

    Private Sub actualizar_historial()
        Dim oTrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dt As New DataTable

        If txt_historial_ficha.Text <> "" Then

            Try
                oTrans.open()
                ls_sql = "pa_sel_um_seg_usuario_vacaciones '" & txt_historial_empresa.Text & "','" & txt_historial_ficha.Text & "'"
                dt = oTrans.Obtiene(ls_sql)
                dgv_historial.DataSource = dt

                ClsGen.Alinear_GridView(dt, dgv_historial, "", ",empresa,", "", "", False, True, 255, 0)

            Catch ex As Exception
                MessageBox.Show("ERROR: " & ex.Message)

            Finally
                oTrans.close()

            End Try

        End If

    End Sub

    Private Sub eliminar_historial()
        Dim oTrans As New Transaccional.Conexion("SCM")
        Dim ficha, fecha_inicio, fecha_final, periodo, ls_sql As String

        Try
            If dgv_historial.Rows.Count > 0 Then
                ficha = Trim(dgv_historial.Item("ficha_empleado", dgv_historial.CurrentRow.Index).Value.ToString)
                fecha_inicio = Trim(dgv_historial.Item("fecha_inicio", dgv_historial.CurrentRow.Index).Value.ToString)
                fecha_final = Trim(dgv_historial.Item("fecha_final", dgv_historial.CurrentRow.Index).Value.ToString)
                periodo = Trim(dgv_historial.Item("periodo", dgv_historial.CurrentRow.Index).Value.ToString)

            End If

            oTrans.open()
            ls_sql = "pa_del_um_seg_usuario_vacaciones '" & txt_historial_empresa.Text & "','" & ficha & "','" & fecha_inicio & "','" & fecha_final & "','" & periodo & "'"
            oTrans.Elimina(ls_sql)

            actualizar_historial()
            actualizar_datos()

        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)

        Finally
            oTrans.close()

        End Try

    End Sub

    Private Sub btn_historial_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_historial_eliminar.Click

        If dgv_historial.Rows.Count > 0 Then

            If MessageBox.Show("Está seguro de eliminar vacaciones de " & txt_historial_nombre.Text & " ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                eliminar_historial()

            End If

        Else
            MessageBox.Show("No hay elementos para eliminar.")

        End If

    End Sub

 
    Private Sub dgv_historial_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_historial.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm_busqueda_empleado As New frm_busqueda_empleado

        frm_busqueda_empleado.ShowDialog()

        If frm_busqueda_empleado.ficha <> "" Then
            txt_empleado.Text = frm_busqueda_empleado.nombre
            txt_fi.Text = frm_busqueda_empleado.ficha
            txt_empre.Text = frm_busqueda_empleado.empresa
            empresas()

        End If

    End Sub

    Private Sub frm_control_vacaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    '(am) 05052005 actualizacion de empresa del historial de vacaciones 
    Private Sub Actualizarempresa()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim ls_sql As String = String.Empty

        Try
            Otrans.open()
            ls_sql = "pa_upd_um_seg_usuario_vacaciones_empresa '" & Me.cmb_empresa.Text & "','" & Me.txt_empre.Text & "','" & Me.txt_fi.Text & "','" & gs_usuario & "'"
            Otrans.Actualiza(ls_sql)
            Otrans.Escribir_Log(ls_sql)

            If Otrans.Codigo_error = 0 Then
                MessageBox.Show("Informacion Actualizada Con Exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(Otrans.descripcion_error)
            End If
        Catch ex As Exception

        End Try




    End Sub

    Private Sub empresas()

        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt2 As DataTable
        Try

            Otrans.open()
            dt2 = Otrans.Obtiene("pa_sel_um_empresas_vacaciones")

            Me.cmb_empresa.DataSource = dt2
            Me.cmb_empresa.ValueMember = "empresa"
            Me.cmb_empresa.DisplayMember = "empresa"

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBox.Show("Esta Seguro de Actualizar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Actualizarempresa()
        End If

    End Sub
End Class