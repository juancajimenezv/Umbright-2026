Imports System.Text
Public Class frm_int_ListadoInternaciones

    Dim ds_internaciones As New DataSet
    Dim sEmpresaPedido As String
    Private Sub Llenar_Combos()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ls_sql As String

        Dim clsgen As New ClasesGenerales.General

        Try
            otrans.open()
            'ls_sql = "pa_sel_um_v_pg_estados 1"
            'dt = otrans.Obtiene(ls_sql)
            'Me.cmb_estados.DataSource = dt
            'Me.cmb_estados.ValueMember = "cod_estado"
            'Me.cmb_estados.DisplayMember = "estado"

            ls_sql = "pa_sel_um_v_pg_estados 3"
            dt = otrans.Obtiene(ls_sql)
            dt.Columns.Add("mostrar", GetType(Int16))
            For Each dr As DataRow In dt.Rows
                dr.Item("mostrar") = 0
                If CInt(dr.Item("cod_estado").ToString) Mod 2 <> 0 Then dr.Item("mostrar") = 1

            Next
            dt.DefaultView.RowFilter = "mostrar=1"

            Me.cmbEstadoReal.DataSource = dt.DefaultView
            Me.cmbEstadoReal.ValueMember = "cod_estado"
            Me.cmbEstadoReal.DisplayMember = "estado"

            dt.TableName = "pg_estados"
            ds_internaciones.Tables.Add(dt.Copy)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub


    Private Sub aplicarFiltro()
        Dim lsFiltro As String = String.Empty

        If gi_tipo_usuario = 1 Or gi_tipo_usuario = 2 Then
            lsFiltro = "estado <> 5"
            'Si revisa memos solo le muestro aquellos que estan solicitados
            '  Me.chkOperadasCD.Visible = True
        Else

            If tiene_permisos("mci_int_estado_inicilizada") Then lsFiltro += IIf(lsFiltro.Length > 0, " OR ", "(") & "estado = 0"
            If tiene_permisos("mci_int_estado_aprobadaDA") Then lsFiltro += IIf(lsFiltro.Length > 0, " OR ", IIf(lsFiltro.ToLower.IndexOf("(") >= 0, "", "(")) & "estado = 1"
            If tiene_permisos("mci_int_estado_preparacionPoliza") Then lsFiltro += IIf(lsFiltro.Length > 0, " OR ", IIf(lsFiltro.ToLower.IndexOf("(") >= 0, "", "(")) & "estado = 2"
            If tiene_permisos("mci_int_estado_PolizaPagada") Then lsFiltro += IIf(lsFiltro.Length > 0, " OR ", IIf(lsFiltro.ToLower.IndexOf("(") >= 0, "", "(")) & "estado = 3"
            If tiene_permisos("mci_int_estado_TrasladoCD") Then lsFiltro += IIf(lsFiltro.Length > 0, " OR ", IIf(lsFiltro.ToLower.IndexOf("(") >= 0, "", "(")) & "estado = 4"
            If tiene_permisos("mci_int_estado_OperadaCD") Then
                lsFiltro += IIf(lsFiltro.Length > 0, " OR ", IIf(lsFiltro.ToLower.IndexOf("(") >= 0, "", "(")) & "estado = 5"
                '       Me.chkOperadasCD.Visible = True
            End If
            lsFiltro += IIf(lsFiltro.ToLower.IndexOf("(") >= 0, ")", "")
        End If

        ds_internaciones.Tables("internaciones_pendientes").DefaultView.RowFilter = lsFiltro

    End Sub


    Private Sub aplicarFiltroReal()
        Dim lsFiltro As String = "estado_real in ("
        Dim lsdatos As String()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        '   gs_usuario = "festrada"
        If gi_tipo_usuario = 1 Or gi_tipo_usuario = 2 Or Me.CheckBox1.CheckState = CheckState.Checked Then
            lsFiltro = "estado_real not in (99,24)"
            '    'Si revisa memos solo le muestro aquellos que estan solicitados
            '    Me.chkOperadasCD.Visible = True
        Else

            Try
                otrans.open()
                dt = otrans.Obtiene("pa_sel_um_sg_usuario_menu_opcion_empresa 14,'" & gs_usuario & "',null,'" & gs_empresa & "'")
                dt.DefaultView.RowFilter = "cod_sub_menu = 15"
                dt = clsGen.ValoresDistinto(dt.DefaultView.ToTable, "opcion".Split(","))
                For Each dr As DataRow In dt.Rows
                    lsdatos = dr.Item("opcion").ToString.Split("_")
                    If lsdatos.Length > 3 Then
                        Try
                            If CInt(lsdatos(lsdatos.Length - 1)) > 0 Then
                                lsFiltro += lsdatos(lsdatos.Length - 1) + ","
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
                lsFiltro += ")"

            Catch ex As Exception
            Finally
                otrans.close()
                otrans = Nothing
            End Try
        End If

        'If gi_tipo_usuario = 1 Or gi_tipo_usuario = 2 Then
        '    lsFiltro = "estado <> 5"
        '    'Si revisa memos solo le muestro aquellos que estan solicitados
        '    Me.chkOperadasCD.Visible = True
        'Else

        '    If tiene_permisos("mci_int_estado_inicilizada") Then lsFiltro += IIf(lsFiltro.Length > 0, " OR ", "(") & "estado = 0"
        '    If tiene_permisos("mci_int_estado_aprobadaDA") Then lsFiltro += IIf(lsFiltro.Length > 0, " OR ", IIf(lsFiltro.ToLower.IndexOf("(") >= 0, "", "(")) & "estado = 1"
        '    If tiene_permisos("mci_int_estado_preparacionPoliza") Then lsFiltro += IIf(lsFiltro.Length > 0, " OR ", IIf(lsFiltro.ToLower.IndexOf("(") >= 0, "", "(")) & "estado = 2"
        '    If tiene_permisos("mci_int_estado_PolizaPagada") Then lsFiltro += IIf(lsFiltro.Length > 0, " OR ", IIf(lsFiltro.ToLower.IndexOf("(") >= 0, "", "(")) & "estado = 3"
        '    If tiene_permisos("mci_int_estado_TrasladoCD") Then lsFiltro += IIf(lsFiltro.Length > 0, " OR ", IIf(lsFiltro.ToLower.IndexOf("(") >= 0, "", "(")) & "estado = 4"
        '    If tiene_permisos("mci_int_estado_OperadaCD") Then
        '        lsFiltro += IIf(lsFiltro.Length > 0, " OR ", IIf(lsFiltro.ToLower.IndexOf("(") >= 0, "", "(")) & "estado = 5"
        '        Me.chkOperadasCD.Visible = True
        '    End If
        '    lsFiltro += IIf(lsFiltro.ToLower.IndexOf("(") >= 0, ")", "")
        'End If

        ds_internaciones.Tables("internaciones_pendientes").DefaultView.RowFilter = lsFiltro

    End Sub

    Private Sub Llenar_Internaciones_pendientes()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ls_sql As String
        Dim dr As DataRow

        Dim clsgen As New ClasesGenerales.General
        Dim clsDias As New ClasesGenerales.DiasHabiles

        Try
            otrans.open()

            If ds_internaciones.Tables.IndexOf("internaciones_pendientes") > -1 Then ds_internaciones.Tables.Remove("internaciones_pendientes")

            If ds_internaciones.Tables.IndexOf("internaciones_detalle") > -1 Then ds_internaciones.Tables.Remove("internaciones_detalle")

            If ds_internaciones.Tables.IndexOf("internaciones_dua") > -1 Then ds_internaciones.Tables.Remove("internaciones_dua")


            ls_sql = "pa_var_um_int_pedido_pendientes"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "internaciones_pendientes"
            ds_internaciones.Tables.Add(dt.Copy)
            Me.dgv_internaciones.DataSource = ds_internaciones.Tables("internaciones_pendientes")

            ls_sql = "pa_sel_um_int_pedido_detalle_pendientes"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "internaciones_detalle"
            ds_internaciones.Tables.Add(dt.Copy)
            Me.dg_detalle.DataSource = ds_internaciones.Tables("internaciones_detalle")

            'aplicarFiltro()
            Me.aplicarFiltroReal()
            'verificarFechaIngreso()



            'For Each drv As DataRowView In ds_internaciones.Tables("internaciones_pendientes").DefaultView
            '    drv.Item("dias_tramite") = clsDias.Obtener_DiasHabiles(gs_empresa, Date.Parse(drv.Item("fecha").ToString), Today) - 1

            '    If drv.Item("dias_tramite") < 0 Then drv.Item("dias_tramite") = 0

            'Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        If ds_internaciones.Tables.Contains("internaciones_pendientes") Then clsgen.Alinear_GridView(ds_internaciones.Tables("internaciones_pendientes"), dgv_internaciones, "", ",estado,lead_time,estado_real,cod_pedido=pedido,", "", ",dias_estado_actual,", ",fechaingreso=Fecha Prob Ingreso,", ",cod_pedido=40,fecha=75,fechaingreso=75,dias_tramite=30,dias_estado_actual=40,", "", True, True, 200, 0)
        If ds_internaciones.Tables.Contains("internaciones_detalle") Then clsgen.Alinear_GridView(ds_internaciones.Tables("internaciones_detalle"), dg_detalle, "", "", "", "", "", ",cod_pedido=30,cantidad=40,", "", True, True, 250, 0)
        clsgen = Nothing
    End Sub

    Private Sub verificarFechaIngreso()
        Dim oTrans As New Transaccional.Conexion("Umbral")

        Dim dfechaInicio As DateTime
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            oTrans.open()


            ds_internaciones.Tables("internaciones_pendientes").DefaultView.Sort = "fecha" '.Compute("Min(Fecha)", "cod_pedido>0")
            dfechaInicio = ds_internaciones.Tables("internaciones_pendientes").DefaultView(0)("fecha")
            lsSQL = "pa_var_um_calendario_habil '" & gs_empresa & "','" & dfechaInicio.ToString("dd/MM/yyyy") & "'"
            dt = oTrans.Obtiene(lsSQL)

            For Each drv As DataRowView In ds_internaciones.Tables("internaciones_pendientes").DefaultView
                dt.DefaultView.RowFilter = "fecha >= '" & drv.Item("fecha") & "'"
                dt.DefaultView.Sort = "fecha"
                drv.Item("fechaIngreso") = dt.DefaultView(drv.Item("lead_time") - 1).Item("fecha")
            Next


        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing

        End Try
    End Sub

    'Private Sub Actualizar_Estado(ByVal npedido As Integer, ByVal nestado As Integer)
    '    Dim ls_sql As String
    '    Dim otrans As New Transaccional.Conexion("SCM")
    '    Dim dt As DataTable
    '    Dim dr As DataRow
    '    Dim lbProcesarEstado As Boolean = False


    '    Try
    '        otrans.open()
    '        'Verificamos que este en el mismo estado
    '        ls_sql = "pa_var_um_int_pedido_pendientes " & npedido.ToString
    '        dt = otrans.Obtiene(ls_sql)
    '        dr = dt.Rows(0)
    '        If Me.cmb_estados.SelectedValue < Int32.Parse(dr.Item("estado").ToString) Or _
    '            Me.cmb_estados.SelectedValue > Int32.Parse(dr.Item("estado").ToString) + 1 Then

    '            If Me.cmb_estados.SelectedValue = 10 Then ''(c) Estado Anulado
    '                lbProcesarEstado = True
    '            Else
    '                MessageBox.Show("No Puede Asignar Estado " & Me.cmb_estados.Text & " A este Pedido")
    '            End If
    '        Else
    '            lbProcesarEstado = True
    '        End If


    '        If lbProcesarEstado Then

    '            ls_sql = "pa_ins_um_int_pedido_estado " & npedido.ToString & "," & Me.cmb_estados.SelectedValue & ",'" & _
    '                    gs_usuario & "','" & Me.txt_comentarios.Text.Trim & "'"
    '            If otrans.Ingresa(ls_sql) Then
    '                If Me.cmb_estados.SelectedValue <> Int32.Parse(dr.Item("estado").ToString) Then

    '                    'If Me.cmb_estados.SelectedValue = 1 Then
    '                    '    If MessageBox.Show("Desea Generar Reserva", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                    '        generarReserva(otrans)
    '                    '    End If
    '                    'End If

    '                    If Me.cmb_estados.SelectedValue = 3 Then

    '                        Dim oform As New frm_int_informacionDI
    '                        oform.ShowDialog()
    '                        If oform.txtDI.Text.Length > 0 Then
    '                            ls_sql = "pa_upd_um_int_pedido_encabezado_di " & npedido.ToString & ",'" & oform.txtDI.Text.Trim & "'," & oform.txtDai.Text & "," & oform.txtIva.Text
    '                            otrans.Actualiza(ls_sql)
    '                        End If
    '                        oform.Dispose()
    '                        oform = Nothing

    '                    End If
    '                    guardarAvisoReal(npedido, Me.cmb_estados.SelectedValue)
    '                End If

    '                MessageBox.Show("Actualizacion Exitosa !!!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If
    '        End If

    '    Catch ex As Exception
    '    Finally
    '        otrans.close()
    '        otrans = Nothing
    '        Llenar_Internaciones_pendientes()
    '    End Try

    'End Sub

    Private Sub actualizarEstadoNuevo(ByVal npedido As Integer, ByVal di As String)
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim dr As DataRow
        Dim lbProcesarEstado As Boolean = False


        Try
            otrans.open()
            'Verificamos que este en el mismo estado
            ls_sql = "pa_var_um_int_pedido_pendientes " & npedido.ToString
            dt = otrans.Obtiene(ls_sql)
            dr = dt.Rows(0)
            If Me.cmbEstadoReal.SelectedValue < Int32.Parse(dr.Item("estado_real").ToString) Or
                Me.cmbEstadoReal.SelectedValue > Int32.Parse(dr.Item("estado_real").ToString) + 1 Then

                If Me.cmbEstadoReal.SelectedValue > 90 Or Me.cmbEstadoReal.SelectedValue = 13 Then ''(c) Estado Anulado
                    lbProcesarEstado = True
                Else
                    MessageBox.Show("No Puede Asignar Estado " & Me.cmbEstadoReal.Text & " A este Pedido")
                End If
            Else

                lbProcesarEstado = True
                If Me.cmbEstadoReal.SelectedValue <> Int32.Parse(dr.Item("estado_real").ToString) Then


                    If Me.cmbEstadoReal.SelectedValue = 7 Then ''DI GENERADA

                        Dim oform As New frm_int_informacionDI
                        oform.ShowDialog()
                        If oform.txtDI.Text.Length > 0 Then
                            ls_sql = "pa_upd_um_int_pedido_encabezado_di " & npedido.ToString & ",'" & oform.txtDI.Text.Trim & "'," & oform.txtDai.Text & "," & oform.txtIva.Text
                            otrans.Actualiza(ls_sql)
                            If di = "" Then di = oform.txtDI.Text.Trim
                        Else
                            MessageBox.Show("No se Procesara El Cambio, Por Falta de Informacion", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            lbProcesarEstado = False
                        End If
                        oform.Dispose()
                        oform = Nothing



                    ElseIf Me.cmbEstadoReal.SelectedValue = 13 Then ''Agregar Informacion del Formulario
                        Dim sformulario As String
                        sformulario = InputBox("Ingrese Numero de Formulario", "Formulario 3091")
                        If sformulario.Length > 0 Then
                            ls_sql = "pa_upd_um_int_pedido_encabezado_formulario " & npedido.ToString & ",'" & sformulario & "'"
                            otrans.Actualiza(ls_sql)
                        Else
                            MessageBox.Show("No se Procesara El Cambio, Por Falta de Informacion", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            lbProcesarEstado = False
                        End If
                    End If
                End If
            End If


            If lbProcesarEstado Then

                ls_sql = "pa_ins_um_int_pedido_estado_real " & npedido.ToString & "," & Me.cmbEstadoReal.SelectedValue & ",'" &
                        gs_usuario & "','" & Me.txt_comentarios.Text.Trim & "'"
                If otrans.Ingresa(ls_sql) Then
                    If Me.cmbEstadoReal.SelectedValue <> 99 Then
                        If Me.cmbEstadoReal.SelectedValue = 98 Then
                            ''Cuando La DI fue rechazada por JC se debe regresar a espera de DI
                            ls_sql = "pa_ins_um_int_pedido_estado_real " & npedido.ToString & ",6,'" &
                                          gs_usuario & "','" & Me.txt_comentarios.Text.Trim & "'"

                        ElseIf Me.cmbEstadoReal.SelectedValue = 11 Then ''Agregar Informacion del Formulario
                            If MessageBox.Show("Este Traslado Necesita Formulario 3091", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                ''Debo Trasladar el pedido al siguiente paso
                                ls_sql = "pa_ins_um_int_pedido_estado_real " & npedido.ToString & "," & (Me.cmbEstadoReal.SelectedValue + 1) & ",'" &
                                              gs_usuario & "','" & Me.txt_comentarios.Text.Trim & "'"

                            Else
                                ''Debo Trasladar el pedido al siguiente paso
                                ls_sql = "pa_ins_um_int_pedido_estado_real " & npedido.ToString & "," & (Me.cmbEstadoReal.SelectedValue + 3) & ",'" &
                                              gs_usuario & "','" & Me.txt_comentarios.Text.Trim & "'"
                                guardarAvisoReal(npedido, 13, di)

                            End If
                        Else
                            ''Debo Trasladar el pedido al siguiente paso
                            ls_sql = "pa_ins_um_int_pedido_estado_real " & npedido.ToString & "," & (Me.cmbEstadoReal.SelectedValue + 1) & ",'" &
                                          gs_usuario & "','" & Me.txt_comentarios.Text.Trim & "'"
                        End If
                        otrans.Ingresa(ls_sql)
                    End If


                    guardarAvisoReal(npedido, Me.cmbEstadoReal.SelectedValue, di)

                    MessageBox.Show("Actualizacion Exitosa !!!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        Catch ex As Exception
            otrans.Escribir_Log(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            Llenar_Internaciones_pendientes()
        End Try

    End Sub

    Private Sub generarReserva(ByVal otrans As Transaccional.Conexion)
        Dim sbRegistro As New StringBuilder


        Try
            'If btn_grabar.Text.ToUpper = "GUARDAR" Then
            sbRegistro.Append("pa_ins_um_da_reserva  ").Append("'")
            'Else
            '    sb_registro.Append("pa_upd_um_da_reserva  ").Append("'")
            'End If
            'sbRegistro.Append(dtp_fecha.Value.ToShortDateString).Append("', '")
            'sbRegistro.Append(txt_numero.Text).Append("', '")
            'sbRegistro.Append(gs_usuario).Append("', '")
            'sbRegistro.Append(gs_empresa).Append("', '")
            'sbRegistro.Append(Mid(lbl_proveedor.Text, 13)).Append("', '")
            'sbRegistro.Append(txt_dua.Text).Append("', '")
            'sbRegistro.Append(cb_bodega.Text).Append("', '")
            'sbRegistro.Append(.Rows(ii)("producto")).Append("', '")
            'sbRegistro.Append(.Rows(ii)("descripcion")).Append("', '")
            'sbRegistro.Append("BULTOS").Append("', '")
            'sbRegistro.Append(cb_bodega.Text).Append("', '")
            'sbRegistro.Append(ii + 1).Append("', ")
            'sbRegistro.Append(.Rows(ii)("bultos")).Append(", ")
            'sbRegistro.Append(.Rows(ii)("cantidad")).Append(", '")
            'sbRegistro.Append(cmb_estatus.Text).Append("', ")
            'sbRegistro.Append("''")
            'sbRegistro.Append(",'").Append(.Rows(ii)("lote"))
            'sbRegistro.Append("','").Append(Me.txtObservaciones.Text).Append("'")

            'otrans.Ingresa(sb_registro.ToString)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub guardarAvisoReal(ByVal ipedido As Integer, ByVal iestado As Integer, ByVal di As String)
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim clsGen As New ClasesGenerales.General

        Dim lsSQL As String
        Dim dt As DataTable
        Dim idaviso As Integer = 0
        Dim dtCorreo As DataTable
        Dim sCuentas As String = ""

        Try
            'If iestado > 10 Or iestado = 2 Then Exit Sub

            'If iestado = 1 Then iestado = 11
            ''       If iestado = 2 Then iestado = 12
            'If iestado = 3 Then iestado = 12
            'If iestado = 4 Then iestado = 13
            'If iestado = 5 Then iestado = 14
            'If iestado = 6 Then iestado = 15


            '10:         'Solicitud de Internacion'
            '11:         'Aprobacion de Internacion'
            '12:         'Preparacion de Poliza'
            '13:         'Poliza Pagada'
            '14:         'Traslado al CD'
            '15:         'Operada en CD'
            If iestado = 99 Then Exit Sub
            If iestado = 1 Then
                idaviso = 10
            ElseIf iestado = 3 Then
                idaviso = 11
            ElseIf iestado = 7 Then  ''Di Generada
                idaviso = 18
            ElseIf iestado = 9 Then
                idaviso = 19
            ElseIf iestado = 13 Then
                idaviso = 20
            ElseIf iestado = 15 Then
                idaviso = 13
            ElseIf iestado = 17 Then
                idaviso = 21
            ElseIf iestado = 19 Then
                idaviso = 22
            ElseIf iestado = 21 Then
                idaviso = 14
            ElseIf iestado = 23 Then
                idaviso = 15
            ElseIf iestado = 97 Then
                idaviso = 23
            End If

            If idaviso = 0 Then Exit Sub
            '1: Inicializada()   10
            '2	Esperando Aprobacion DA (Juan Carlos)
            '3: Aprobada(DA)  11
            '4	Esperando Traslado a Agente Aduanal (Ana Luisa)
            '5	Trasladado al Agente Aduanal     --No Genera Aviso
            '6	Esperando DI (Ana Luisa)  
            '7: DI(generada)                    ---Aviso DI Generada Espera de Revision 18
            '8	Esperando Revision DI (Juan Carlos)
            '9: DI(revisada)                    --Aviso DI Aprobada     19
            '10	Esperando Asignacion (Pago o Formulario) (Fern)
            '11:DI(asignada)                    -- Si es Pago Aviso de Pago 20
            '12	Esperando Formulario 3091 (Fernando)
            '13	Formulario 3091 Listo           --Aviso de Pendiente de pago 20
            '14:Esperando(Pago(Finanzas))
            '15:Poliza(Pagada) 13               --Aviso de poliza pagada 13
            '16	En Espera de Revision SAT (Juan Carlos)
            '17	Revisada por SAT                --Aviso de Revision hecha por sat 21
            '18	En Espera de Retiro (Ana Luisa)
            '19:Retiro(Elaborado)               --Aviso de Elaboracion de Retiro 22
            '20	Espera Traslado a CD (Juan Carlos)
            '21	Traslado a CD                   --Aviso de Traslado hacia el CD 14
            '22	Espera Operacion CD (Concepcion)
            '23	Operado en CD                   --Aviso de Finalizacion de proceso 15
            '24:Cerrado()
            '97	DI Rechazada (Ana Luisa)        --Aviso de Rechazo 23
            '99:Anulado()



            myOtrans.open()
            lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema (" & idaviso.ToString & ")" '1= Ingreso de Dua OC
            dt = myOtrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows

                clsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", "Solicitud No " &
                                      ipedido.ToString & "  " &
                                      IIf(di.Trim.Length > 0, "DI " & di & " ", "") &
                                      Me.cmbEstadoReal.Text & " " &
                                      Me.txt_comentarios.Text.Trim, idaviso)

                dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & dr.Item("usuario").ToString & "'")
                If dtCorreo.Rows.Count > 0 Then
                    If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                    scuentas = scuentas & dtCorreo.Rows(0).Item("correo").ToString
                End If
            Next



            If scuentas.ToString.Length > 0 Then
                enviarCorreo(sCuentas, ipedido, di)
            End If

        Catch ex As Exception
            clsGen.Escribir_Log(ex.Message)
        Finally
            myOtrans.close()
            myOtrans = Nothing
            clsGen = Nothing
        End Try
    End Sub


    Private Sub enviarCorreo(sCuentas As String, ipedido As Integer, di As String)


        Dim sBody As String
        Dim clsGen As New ClasesGenerales.General
        Dim sRemitente As String = "lgs1@logiservicios.com"
        Dim snombreRemitente As String = "LGS1"
        'Dim scuentas As String = ""
        Dim sSubject As String = ""
        Dim ldFechaDocto As Date

        Try





            Dim iCount As Integer = 0

            sSubject = "Internaciones " & ipedido.ToString & "  " & IIf(di.Trim.Length > 0, "DI " & di & " ", "") &
                                      Me.cmbEstadoReal.Text ' Me.cmbTipoDocto.SelectedValue.ToString & "-" & Me.txtNumero.Text


            sBody = "<br>"
            'sBody = sBody & "Se les Informa que se ha ingresado a " & Me.txtBodega.Text.ToUpper & " lo siguiente " + "<br>"
            sBody = sBody & "Seguimiento de Internaciones UMBRIGHT<br>"
            sBody = sBody & " <br>"

            sBody = sBody & "Empresa          : " & sEmpresaPedido & "  " & "<br>"
            sBody = sBody & "Numero de Pedido : " & ipedido.ToString & "  " & "<br>"
            sBody = sBody & IIf(di.Trim.Length > 0, "Numero de DI :" & di & " ", "") & "<br>"
            sBody = sBody & "Status :  " & Me.cmbEstadoReal.Text & " " & "<br>"
            sBody = sBody & " <br>"
            sBody = sBody & "Comentarios " & Me.txt_comentarios.Text.Trim
            'sBody = sBody & "Proveedor " & Me.txtProveedor.Text & "<br>"
            sBody = sBody & " <br>"
            sBody = sBody & " <br>"

            sBody = sBody & " <br>"
            sBody = sBody & " <br>"
            'If Me.txtComentario4.Text.Length > 0 Then
            '    sBody = sBody & " Comentarios " & Me.txtComentario4.Text
            'End If




            Try
                'Dim dtBU As DataTable
                'Dim dtCorreo As DataTable
                'dtBU = clsGen.selectQuery("FlexLine", "pa_sel_um_documentod '" & gs_empresa & "','" & Me.cmbTipoDocto.SelectedValue.ToString & "','" & Me.txtNumero.Text & "'")
                'ldFechaDocto = dtBU.Rows(0).Item("fecha_docto")
                'dtBU = clsGen.ValoresDistinto(dtBU, "analisisproducto17".Split(","))
                'For Each dr As DataRow In dtBU.Rows
                '    '' Debo obtener las personas que tienen permisos para esa unidad de negocio
                '    Dim dtUsuarioBU As DataTable = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_menu_opcion_empresa_empresa null,null, '" & dr.Item("analisisproducto17").ToString & "','" & gs_empresa & "'")
                '    For Each drBU As DataRow In dtUsuarioBU.Rows
                '        dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & drBU.Item("usuario").ToString & "'")
                '        If dtCorreo.Rows.Count > 0 Then
                '            If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                '            scuentas = scuentas & dtCorreo.Rows(0).Item("correo").ToString
                '        End If
                '    Next

                'Next
                '''Correos por empresa
                'dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod null, 'gen_correo_internaci', '" & gs_empresa & "'")
                'For Each dr As DataRow In dtCorreo.Rows
                '    If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                '    scuentas = scuentas & dr.Item("descripcion").ToString
                'Next



            Catch ex As Exception

            End Try




            'scuentas = "coscal@umbral.com.gt, chernandez@logiservicios.com"
            'Dim lsRuta As String = generarPDF(ldFechaDocto.ToString("yyyyMM"))


            Dim lsRutaAdjunto As String = ""
            If Me.cmbEstadoReal.SelectedValue = 7 Then
                sBody = sBody & "Adjunto se envia el documento de Ingreso <br>"
                sBody = sBody & " <br>"

                lsRutaAdjunto = "\\" & clsGen.Obtener_XMLConfig("Servidor_Alterno_" & clsGen.Obtener_XMLConfig("ubicacion", False), False) & "\di$\" & sEmpresaPedido & "\" &
                                    di & ".pdf"

            End If


            clsGen.enviarcorreo(sRemitente, snombreRemitente, sCuentas, sSubject, sBody, lsRutaAdjunto)

            'Ruta En Servidor

            'Dim lsRutaServidor As String = "\\" & clsGen.Obtener_XMLConfig("servidor_alterno_" & clsGen.Obtener_XMLConfig("ubicacion", False), False) & "\flexline$\" &
            '            gs_empresa & "\" & ldFechaDocto.ToString("yyyyMM")


            'Try
            '    If Not Directory.Exists(lsRutaServidor) Then
            '        Directory.CreateDirectory(lsRutaServidor)
            '    End If
            'Catch ex As Exception

            'End Try

            'lsRutaServidor &= "\" & Me.cmbTipoDocto.SelectedValue.ToString.Replace(" ", "_") & "_" & Me.txtNumero.Text & ".pdf"

            'clsGen.Copiar_Archivo(lsRuta, lsRutaServidor, True)

        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)

        Finally
            clsGen = Nothing
        End Try

    End Sub


    'Mostrar los productos en los diferentes grids
    Private Sub Mostrar_Productos()

        Dim nrow, npedido As Integer
        Dim clsGen As New ClasesGenerales.General

        Try
            nrow = Me.dgv_internaciones.CurrentCell.RowIndex
            npedido = Me.dgv_internaciones.Item(0, nrow).Value.ToString

            ds_internaciones.Tables("internaciones_detalle").DefaultView.RowFilter = "cod_pedido = " & npedido
            'ds_internaciones.Tables("internaciones_dua").DefaultView.RowFilter = "cod_pedido = " & npedido
            clsGen.Alinear_GridView(ds_internaciones.Tables("internaciones_detalle"), dg_detalle, "", "", "", "", "", ",cod_pedido=30,cantidad=40,", "", True, True, 250, 0)
            Me.cmbEstadoReal.SelectedValue = CInt(Me.dgv_internaciones.Item("estado_real", nrow).Value.ToString) + 1
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Exportar_Pedido()
        Dim nrow, npedido As Integer
        Dim ls_sql As String

        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim Oaut As New Automatizar.exportar_excel

        Try
            nrow = Me.dgv_internaciones.CurrentCell.RowIndex
            npedido = Me.dgv_internaciones.Item(0, nrow).Value.ToString

            otrans.open()
            ls_sql = "pa_var_um_int_pedido_detalle_dua " & npedido.ToString
            dt = otrans.Obtiene(ls_sql)


            Oaut.nAgregar_Filas = 2
            Oaut.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}}
            Oaut.ocultar_columnas = ",proveedor,agregar,"
            Oaut.Nombre_Columnas = ",,,Traslado CJ"
            Oaut.sEncabezado = "Solicitud de Traslado del DA"
            Oaut.sTitulo = "Solicitud No. " & npedido.ToString
            Oaut.DataTableToExcel(dt)
            Oaut = Nothing




        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Imprimir_Pedido()

        Dim path_reporte As String
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String
        Dim nrow, npedido As Integer

        Try
            nrow = Me.dgv_internaciones.CurrentCell.RowIndex
            npedido = Me.dgv_internaciones.Item(0, nrow).Value.ToString

            path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Compras e Importaciones\pedido_internaciones.rpt"
            pm_parametros(0) = "Empresa"
            pm_valores(0) = "dmarte1,codicasa,alamsa,diuva"
            pm_parametros(1) = "@FechaI"
            pm_valores(1) = Today
            pm_parametros(2) = "@FechaF"
            pm_valores(2) = Now



            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "vDATASERVER", "BDflexline", "flexline", "flexline", False, True, "PDF", False, "", True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mostrarManual()
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim ls_sql, ls_rutamanual As String


        Dim proceso As New Process
        ls_sql = "pa_sel_um_gen_parametros_sistema"
        Try
            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            ls_rutamanual = dt.Rows(0).Item("path_manuales").ToString.Trim
            ls_rutamanual += "internaciones.pdf"

            proceso.Start(ls_rutamanual)



        Catch ex As Exception
        Finally
            proceso = Nothing
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub exportarVistaActual()
        Dim Oaut As New Automatizar.exportar_excel

        Try
            Oaut.nAgregar_Filas = 2
            Oaut.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}}
            Oaut.ocultar_columnas = ",estado,estado_real,"
            Oaut.Nombre_Columnas = ",,,,,estado,"
            Oaut.sEncabezado = "Listado de Internaciones Pendientes de Ingreso"
            Oaut.sTitulo = "Al " & Today
            Oaut.DataTableToExcel(ds_internaciones.Tables("internaciones_pendientes").DefaultView.ToTable)
        Catch ex As Exception
        Finally
            Oaut = Nothing
        End Try


    End Sub

    Private Function cambioValido(ByVal nestado As Integer) As Boolean
        Dim lbValido As Boolean = False

        Dim lsFiltro As String = "estado_real in ("
        Dim lsdatos As String()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        '   gs_usuario = "festrada"
        If gi_tipo_usuario = 1 Or gi_tipo_usuario = 2 Then
            lbValido = True
        Else
            Try
                otrans.open()
                dt = otrans.Obtiene("pa_sel_um_sg_usuario_menu_opcion_empresa 14,'" & gs_usuario & "',null,'" & gs_empresa & "'")
                dt.DefaultView.RowFilter = "cod_sub_menu = 15"
                dt = clsGen.ValoresDistinto(dt.DefaultView.ToTable, "opcion".Split(","))
                For Each dr As DataRow In dt.Rows
                    lsdatos = dr.Item("opcion").ToString.Split("_")
                    If lsdatos.Length > 3 Then
                        Try
                            If CInt(lsdatos(lsdatos.Length - 1)) = nestado Then
                                lbValido = True
                                Exit For
                                'lsFiltro += lsdatos(lsdatos.Length - 1) + ","
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next

            Catch ex As Exception
            Finally
                otrans.close()
                otrans = Nothing
            End Try
        End If



        Return lbValido
    End Function


    Private Sub frm_int_listado_internaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Combos()
        Llenar_Internaciones_pendientes()
        Mostrar_Productos()
    End Sub

    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        Llenar_Internaciones_pendientes()
    End Sub

    Private Sub btn_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click



        Dim ClsGen As New ClasesGenerales.frm_mostrarImagen
        Dim cls As New ClasesGenerales.General
        Dim nrow As Integer
        Try
            nrow = Me.dgv_internaciones.CurrentCell.RowIndex
            Dim sfile As String = "\\" & cls.Obtener_XMLConfig("Servidor_Alterno_" & cls.Obtener_XMLConfig("ubicacion", False), False) & "\di$\" & Me.dgv_internaciones.Item("empresa", nrow).Value.ToString.Trim & "\" &
                                    Me.dgv_internaciones.Item("di", nrow).Value.ToString.Trim & ".jpg"

            If System.IO.File.Exists(sfile) Then
                ClsGen.psimagen = sfile
                ClsGen.ShowDialog()
            Else
                Try
                    Dim proceso As Process = New Process

                    proceso.StartInfo.FileName = sfile.Replace(".jpg", ".pdf")
                    proceso.Start()
                    proceso = Nothing

                Catch ex2 As Exception
                    '  MessageBox.Show("No Se Pueden Visualizar Los Cubos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End If




        Catch ex As Exception






            '    'mExcel.Visible = True
            '    'mExcel.Workbooks.Open(ls_path & nombre_cubo & ".xls", False, True, , , , , , , , , , , , True)
            'Catch ex As Exception




        Finally
            ClsGen.Dispose()
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Exportar_Pedido()
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Imprimir_Pedido()
    End Sub

    Private Sub dg_internaciones_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv_internaciones.CurrentCellChanged
        Mostrar_Productos()
    End Sub

    Private Sub chkOperadasCD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        aplicarFiltro()
    End Sub

    Private Sub dg_internaciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_internaciones.CellContentClick

    End Sub

    Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click
        Dim nrow, npedido, nestado As Integer

        nrow = Me.dgv_internaciones.CurrentCell.RowIndex
        npedido = Me.dgv_internaciones.Item("cod_pedido", nrow).Value.ToString
        nestado = Me.dgv_internaciones.Item("estado_real", nrow).Value.ToString
        sEmpresaPedido = Me.dgv_internaciones.Item("empresa", nrow).Value.ToString.Trim

        If cambioValido(nestado) Then
            If MessageBox.Show("Esta Seguro de Cambiar Estado a Pedido No. " & npedido.ToString, "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ' Actualizar_Estado(npedido, nestado)
                actualizarEstadoNuevo(npedido, Me.dgv_internaciones.Item("DI", nrow).Value.ToString)
            End If
        Else
            MessageBox.Show("Su Usuario No Tiene Accesos Para Cambiar Este Estado", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub AgregarComentarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarComentarioToolStripMenuItem.Click
        Try

            Dim nrow, npedido, nestado As Integer
            Dim lsSQL, lsComentario As String

            nrow = Me.dgv_internaciones.CurrentCell.RowIndex
            npedido = Me.dgv_internaciones.Item("cod_pedido", nrow).Value.ToString
            nestado = Me.dgv_internaciones.Item("estado_real", nrow).Value.ToString

            lsComentario = InputBox("Ingrese Comentario", "Comentario")

            If lsComentario.Length > 0 Then
                lsSQL = "pa_ins_um_int_pedido_estado_real " & npedido.ToString & "," & nestado & ",'" & _
                  gs_usuario & "','" & lsComentario & "'"

                Dim Otrans As New Transaccional.Conexion("SCM")
                Otrans.open()
                Otrans.Ingresa(lsSQL)
                Otrans.close()
                Otrans = Nothing
            End If



        Catch ex As Exception
        Finally
            Llenar_Internaciones_pendientes()
        End Try
    End Sub

    Private Sub VerTrackingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerTrackingToolStripMenuItem.Click
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General

        Try
            Otrans.open()
            Dim nrow, npedido As Integer
            Dim lsSQL As String
            Dim dt As DataTable

            nrow = Me.dgv_internaciones.CurrentCell.RowIndex
            npedido = Me.dgv_internaciones.Item("cod_pedido", nrow).Value.ToString


            lsSQL = "pa_var_um_int_pedido_pendientes_estado_pedido '" & Me.dgv_internaciones.Item("empresa", nrow).Value.ToString & _
                    "'," & npedido
            dt = Otrans.Obtiene(lsSQL)

            Dim clsResultado As New ClasesGenerales.frm_resultado
            clsResultado.dgv_resultado.DataSource = dt.DefaultView
            clsGen.Alinear_GridView(dt, clsResultado.dgv_resultado, "", ",cod_pedido,daiv,iva,cod_estado,", "", "", "", ",cod_pedido=30,cantidad=40,", "", True, True, 250, 0)
            clsResultado.Text = "Tracking de Pedido :: " & npedido & " :: " & Me.dgv_internaciones.Item("empresa", nrow).Value.ToString
            clsResultado.ShowDialog()
            clsResultado = Nothing
            clsResultado.Dispose()

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub btn_ayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda.Click
        mostrarManual()
    End Sub

    Private Sub btnExportarListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarListado.Click
        exportarVistaActual()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub CheckBox1_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckStateChanged
        Me.aplicarFiltroReal()
    End Sub
End Class