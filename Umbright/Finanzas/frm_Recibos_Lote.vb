Public Class frm_Recibos_Lote

    Public total_exencion As Double = 0
    Public ptotalFactura As Double = 0
    Public pdiferencia As Double = 0
    Public dt As DataTable
    Public dt2 As DataTable
    Public ods As New DataSet
    Public ods3 As New DataSet
    Public ods4 As New DataSet
    Public ods5 As New DataSet
    Dim ods2 As New DataSet
    Public dtPagos As DataTable

    Public PbDatosTarjeta As Boolean = False

    Dim contador As Integer = 0
    Dim valor2 As Double
    Dim oDataSet As New DataSet
    Dim RowNumber As Integer

    Private Sub llenarFormasPago()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_sel_pagosVentas'" & gs_empresa & "'")

            Me.cmbFormaPago.DataSource = dt
            Me.cmbFormaPago.ValueMember = "codigo"
            Me.cmbFormaPago.DisplayMember = "codigo"


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try


    End Sub

    Private Sub llenarLotes()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_sel_um_encabezado_lote2 '" & gs_empresa & "','" & gs_usuario & "'")


            'Me.cmb_lotes.DataSource = dt
            'Me.cmb_lotes.ValueMember = "lote"
            'Me.cmb_lotes.DisplayMember = "lote"


            Me.txt_lote_dia.Text = dt.Rows(0)("lote").ToString
            Me.txt_estado_lote.Text = dt.Rows(0)("estado").ToString
            Me.txt_estado2_lote.Text = dt.Rows(0)("estado").ToString
            Me.dt_lote.Text = dt.Rows(0)("fecha").ToString




        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try


    End Sub


    Private Sub cmbFormaPago_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        txt_formaP.Text = cmbFormaPago.Text
        txtPago.Focus()


    End Sub

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub crearestructura()

        Dim dt As DataTable
        ods = New DataSet
        dt = New DataTable("agregar")
        dt.Columns.Add(New DataColumn("Forma_de_pago", GetType(String)))
        dt.Columns.Add(New DataColumn("valor", GetType(Double)))

        ods.Tables.Add(dt)
        Me.dg_valores.DataSource = ods.Tables("agregar")


    End Sub

    Private Sub crearEstructuraLote()
        Dim dt As DataTable
        ods3 = New DataSet
        dt = New DataTable("Encabezado")
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("Lote", GetType(String)))
        dt.Columns.Add(New DataColumn("Estado", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("Usuario_Grabo", GetType(String)))
        ods3.Tables.Add(dt)
        Me.dgv_encabezado_lote.DataSource = ods3.Tables("Encabezado")


    End Sub
    Private Sub crearDetalleLote()
        Dim dt As DataTable
        ods4 = New DataSet
        dt = New DataTable("Detalle")
        dt.Columns.Add(New DataColumn("Lote", GetType(String)))
        dt.Columns.Add(New DataColumn("No_Recibo", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("Tipo_Docto", GetType(String)))
        dt.Columns.Add(New DataColumn("No_Factura", GetType(String)))
        dt.Columns.Add(New DataColumn("Tipo_Pago", GetType(String)))
        dt.Columns.Add(New DataColumn("Monto_Pago", GetType(Double)))
        dt.Columns.Add(New DataColumn("Valor_Total_Recibo", GetType(Double)))
        ods4.Tables.Add(dt)
        Me.dgv_detalle_recibos.DataSource = ods4.Tables("Detalle")



    End Sub

    Private Sub llenarPagosTotales()
        Dim dt As DataTable
        ods5 = New DataSet
        dt = New DataTable("PagosTotal")
        dt.Columns.Add(New DataColumn("lote", GetType(String)))
        dt.Columns.Add(New DataColumn("Tipo_pago", GetType(String)))
        dt.Columns.Add(New DataColumn("Total", GetType(Double)))
        ods5.Tables.Add(dt)
        Me.dgv_pagos_total.DataSource = ods5.Tables("PagosTotal")
    End Sub



    Private Sub agregarLinea()
        Dim dt As DataTable
        ods2 = New DataSet
        dt = New DataTable("linea")
        dt.Columns.Add(New DataColumn("Lote", GetType(String)))
        dt.Columns.Add(New DataColumn("Cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("No. Recibo", GetType(String)))
        dt.Columns.Add(New DataColumn("Tipo Documento", GetType(String)))
        dt.Columns.Add(New DataColumn("No. Factura", GetType(String)))
        dt.Columns.Add(New DataColumn("Tipo Pago", GetType(String)))
        dt.Columns.Add(New DataColumn("Monto_Pago", GetType(Double)))
        dt.Columns.Add(New DataColumn("Cobrador", GetType(String)))
        dt.Columns.Add(New DataColumn("Valor_Recibo", GetType(Double)))


        ods2.Tables.Add(dt)
        Me.dgv_linea2.DataSource = ods2.Tables("linea")





    End Sub


    Private Sub txtPago_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPago.KeyDown

    End Sub


    Private Sub txtPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPago.KeyPress



        Try
            If txt_cte.Text = "" Then
                MessageBox.Show("Debe ingresar No. de Factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtPago.Text = String.Empty
                cmb_tipodocto.Focus()

            End If


            e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)

            If e.KeyChar = "." And Not txtPago.Text.IndexOf(".") Then
                e.Handled = True
            ElseIf e.KeyChar = "." Then
                e.Handled = False
            End If

            If e.KeyChar = Chr(13) Then

                '' Validacion




                ods.Tables("agregar").DefaultView.RowFilter = "Forma_de_Pago = '" & Me.txt_formaP.Text & "'"
                If ods.Tables("agregar").DefaultView.Count = 1 Then

                    ods.Tables("agregar").DefaultView(0).Item("valor") = Me.txtPago.Text
                    validar2()
                    txtPago.Text = String.Empty

                Else



                    ' Dim dt As DataTable

                    'Me.dg_valores.DataSource = ods.Tables("agregar")
                    Dim dr_aux As DataRow
                    dr_aux = ods.Tables("agregar").NewRow
                    dr_aux.Item("Forma_de_pago") = Me.txt_formaP.Text
                    dr_aux.Item("valor") = Me.txtPago.Text
                    ods.Tables("agregar").Rows.Add(dr_aux)
                    Me.dg_valores.DataSource = ods.Tables("agregar")

                    Dim cls2 As New ClasesGenerales.General
                    cls2.Alinear_GridView(ods.Tables("agregar"), Me.dg_valores, "", "", "", "", True, True, 250, 0)
                    validar2()
                    txtPago.Text = " "
                End If

                ods.Tables("agregar").DefaultView.RowFilter = ""


                If Double.Parse(txt_cobrado.Text) = Double.Parse(txt_total_fact.Text) Then
                    If Double.Parse(txt_cobrado.Text) = Double.Parse(txt_valorR.Text) Then
                        llenar()
                        sumar()
                        limpiarcampos()
                        If txt_suma_final.Text = txt_valorR.Text Then
                            If MessageBox.Show("Las cantidades Coinciden,¿Desea Grabar?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                                grabar()
                                actualizar()
                                IngresarEstadosLog()
                                llenarLotes()
                                contarRegistros()
                                limpiarFin()
                                txt_recibo.Text = String.Empty
                                txt_suma_final.Text = 0
                                txt_suma_final2.Text = 0
                                txtPago.Enabled = False
                                txt_b_ctacte.Enabled = False
                                txtNo_recibo.Focus()

                                txt_valorR.Enabled = True

                                If txt_cantidad.Text = 0 Then
                                    btn_validar.Enabled = False
                                    btn_cuadrar.Enabled = False
                                Else
                                    btn_validar.Enabled = True
                                    btn_cuadrar.Enabled = True
                                End If


                                cmb_tipodocto.Enabled = False
                                txt_num_fac.Enabled = False

                            End If
                        End If




                    End If


                End If


                cmbFormaPago.Focus()

            End If
        Catch ex As Exception

        End Try





        If False Then


            Try



                e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)

                If e.KeyChar = "." And Not txtPago.Text.IndexOf(".") Then
                    e.Handled = True
                ElseIf e.KeyChar = "." Then
                    e.Handled = False
                End If

                If e.KeyChar = Chr(13) Then


                    Dim total_forma_pago As Double = 0
                    Dim dr_aux As DataRow
                    Dim cls2 As New ClasesGenerales.General


                    For Each dr As DataRow In ods.Tables("agregar").Rows
                        If dr.Item("Forma_de_pago") = Me.cmbFormaPago.SelectedValue Then
                            'total_forma_pago += dr.Item("valor")


                            If MessageBox.Show("¿Desea Reemplazar?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                                dr.Delete()



                            Else

                                total_forma_pago += dr.Item("valor")

                                total_forma_pago += Me.txtPago.Text
                                ods.Tables("agregar").DefaultView.RowFilter = ""



                                dr_aux = ods.Tables("agregar").NewRow
                                dr_aux.Item("Forma_de_pago") = Me.cmbFormaPago.SelectedValue
                                dr_aux.Item("valor") = total_forma_pago 'Me.txtPago.Text 'total_forma_pago 'Me.txtPago.Text
                                ods.Tables("agregar").Rows.Add(dr_aux)
                                Me.dg_valores.DataSource = ods.Tables("agregar")


                                'cls2.Alinear_GridView(ods.Tables("agregar"), Me.dg_valores, "", "", "", "", True, True, 250, 0)
                                validar2()
                                'txtPago.Text = " "


                            End If
                            Exit For


                        End If
                    Next

                    total_forma_pago += Me.txtPago.Text
                    ods.Tables("agregar").DefaultView.RowFilter = ""



                    dr_aux = ods.Tables("agregar").NewRow
                    dr_aux.Item("Forma_de_pago") = Me.cmbFormaPago.Text
                    dr_aux.Item("valor") = Me.txtPago.Text 'total_forma_pago 'Me.txtPago.Text 'total_forma_pago 'Me.txtPago.Text
                    ods.Tables("agregar").Rows.Add(dr_aux)
                    Me.dg_valores.DataSource = ods.Tables("agregar")


                    cls2.Alinear_GridView(ods.Tables("agregar"), Me.dg_valores, "", "", "", "", True, True, 250, 0)
                    validar2()
                    txtPago.Text = " "












                    cmbFormaPago.Focus()




                End If
            Catch ex As Exception

            End Try
        End If


    End Sub


    Private Sub llenar()
        For Each dr As DataRow In ods.Tables("agregar").Rows


            Dim dr_aux2 As DataRow
            dr_aux2 = ods2.Tables("linea").NewRow


            'End If

            dr_aux2.Item("Tipo Pago") = dr.Item("Forma_de_Pago").ToString
            If dr_aux2.Item("Tipo Pago") = "SOBRANTE" Then
                dr_aux2.Item("No. Recibo") = Me.txt_recibo.Text
                dr_aux2.Item("Tipo Documento") = ""
                dr_aux2.Item("No. Factura") = ""
                dr_aux2.Item("Lote") = Me.txt_lote_dia.Text
                dr_aux2.Item("Cliente") = Me.txt_cte.Text
                dr_aux2.Item("Monto_Pago") = dr.Item("valor").ToString
                dr_aux2.Item("Cobrador") = Me.txt_cobrador.Text
                dr_aux2.Item("Valor_Recibo") = Me.txt_valorR.Text
            Else
                dr_aux2.Item("Lote") = Me.txt_lote_dia.Text
                dr_aux2.Item("Cliente") = Me.txt_cte.Text
                dr_aux2.Item("Tipo Documento") = Me.txt_tipo_docto.Text
                dr_aux2.Item("No. Factura") = Me.numero.Text
                dr_aux2.Item("Monto_Pago") = dr.Item("valor").ToString
                dr_aux2.Item("Cobrador") = Me.txt_cobrador.Text
                dr_aux2.Item("Valor_Recibo") = Me.txt_valorR.Text

                'If chk_manual.Checked Then
                '    dr_aux2.Item("No. Recibo") = Me.txtNo_recibo.Text
                'Else
                dr_aux2.Item("No. Recibo") = Me.txt_recibo.Text
            End If

            ods2.Tables("linea").Rows.Add(dr_aux2)
            Me.dgv_linea2.DataSource = ods2.Tables("linea")


        Next


        Dim cls2 As New ClasesGenerales.General
        cls2.Alinear_GridView(ods2.Tables("linea"), Me.dgv_linea2, "", "", "", "", True, True, 250, 0)





        cls2 = Nothing
    End Sub

    Private Sub recorrer()
        If txt_sm_valida.Text > 0 Then
            If MessageBox.Show("¿Desea Agregar el Resto del Recibo como Sobrante?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Dim dr_aux2 As DataRow
                dr_aux2 = ods2.Tables("linea").NewRow
                dr_aux2.Item("No. Recibo") = Me.txt_recibo.Text
                dr_aux2.Item("Tipo Pago") = "SOBRANTE"
                dr_aux2.Item("Tipo Documento") = ""
                dr_aux2.Item("No. Factura") = ""
                dr_aux2.Item("Lote") = Me.txt_lote_dia.Text
                dr_aux2.Item("Cliente") = Me.txt_b_ctacte.Text
                dr_aux2.Item("Monto_Pago") = Me.txt_sm_valida.Text
                dr_aux2.Item("Cobrador") = Me.txt_cobrador.Text
                dr_aux2.Item("Valor_Recibo") = Me.txt_valorR.Text
                ods2.Tables("linea").Rows.Add(dr_aux2)
                Me.dgv_linea2.DataSource = ods2.Tables("linea")

                Dim cls2 As New ClasesGenerales.General
                cls2.Alinear_GridView(ods2.Tables("linea"), Me.dgv_linea2, "", "", "", "", True, True, 250, 0)

            End If


        End If
    End Sub



    Private Sub limpiarcampos()

        ' Me.txt_recibo.Text = String.Empty
        'Me.txtNo_recibo.Text = String.Empty
        Me.fecha_manual.Text = String.Empty
        Me.txt_cte.Text = String.Empty
        Me.txt_razonS.Text = String.Empty
        Me.numero.Text = String.Empty
        Me.txt_tipo_docto.Text = String.Empty
        ' Me.txt_correlativo.Text = String.Empty
        Me.txt_total_fact.Text = String.Empty
        Me.txt_diferencia.Text = String.Empty

        Me.txt_num_fac.Text = String.Empty
        Me.txt_num_fac2.Text = String.Empty
        Me.txt_no.Text = String.Empty

        Me.txt_cobrado1.Text = String.Empty
        Me.txt_cobrado.Text = String.Empty
        Me.txt_val2.Text = String.Empty
        Me.txt_abono.Text = String.Empty
        Me.txt_tipoC.Text = String.Empty
        Me.txt_centralizada.Text = String.Empty
        'Me.txt_val_recibo.Text = String.Empty
        'Me.txt_valorR.Text = String.Empty
        'Me.txt_cobrador.Text = String.Empty

        dt = CType(Me.dg_valores.DataSource, DataTable)
        dt.Rows.Clear()




        '''''




    End Sub




    Private Sub validar()

        Dim valor2 As Double
        Dim dt As DataTable = DirectCast(dg_valores.DataSource, DataTable)
        Dim suma As Object = dt.Compute("SUM(valor)", Nothing)
        Try


            txt_cobrado.Text = suma
            txt_cobrado1.Text = suma

            valor2 = Convert.ToDouble(txt_cobrado.Text)

            txt_cobrado.Text = FormatNumber(txt_cobrado.Text, 2)

            txt_diferencia.Text = txt_total_fact.Text - txt_cobrado1.Text
            txt_diferencia.Text = FormatNumber(txt_diferencia.Text, 2)

        Catch ex As Exception

        End Try





    End Sub



    Private Sub validar2()

        Dim dt3 As DataTable = DirectCast(dg_valores.DataSource, DataTable)
        Dim suma As Object = dt3.Compute("SUM(valor)", Nothing)
        Try
            txt_cobrado.Text = suma
            txt_cobrado1.Text = suma

            valor2 = Convert.ToDouble(txt_cobrado.Text)

            txt_cobrado.Text = FormatNumber(txt_cobrado.Text, 2)

            txt_diferencia.Text = Double.Parse(txt_val2.Text) - Double.Parse(txt_cobrado.Text)

            If txt_abono.Text > 0 Then
                txc_txta.Text = Double.Parse(txt_abono.Text) + Double.Parse(txt_cobrado.Text)
                txt_diferencia.Text = txt_suma_.Text - txt_cobrado1.Text
            Else
                txt_diferencia.Text = txt_total_fact.Text - txt_cobrado.Text
            End If


            txt_diferencia.Text = FormatNumber(txt_diferencia.Text, 2)

        Catch ex As Exception

        End Try






    End Sub

    Private Sub grabar()
        Dim otrans As New Transaccional.Conexion("SCM")

        ' Dim lsSQL As String
        Dim lsSQL3 As String


        Try
            otrans.open()

            sumar()
            If txt_suma_final.Text = txt_valorR.Text Then



                ' lsSQL = "pa_ins_um_recibosfc '" & gs_empresa & "','" & Me.fecha_fac.Text & "','" & Me.txt_recibo.Text & "','" & Me.txt_tipo_docto.Text & "','" & Me.txt_no_factura.Text & "' ,'" & Me.txt_cliente.Text & "' ,'" & Me.txt_razon_social.Text & "' ,'" & Me.txt_total1.Text & "' ,' ',0, '" & Me.txt_cobrado1.Text & "' ,0,' ',' ', '" & gs_usuario & "','" & Me.dtFecha.Text & " ' "
                'otrans.Ingresa(lsSQL)

                For Each dr2 As DataRow In ods2.Tables("linea").Rows

                    lsSQL3 = "pa_ins_um_Detalle_lote_recibos  '" & gs_empresa & "','" & dr2.Item("Lote").ToString & "', '" & Me.Tipo.Text & "', '" & dr2.Item("Cliente").ToString & "', '" & Me.Transaccion.Text & "', '" & dr2.Item("No. Recibo").ToString & "', '" & Me.dtFecha.Text & "', '" & dr2.Item("Tipo Documento").ToString & "', '" & dr2.Item("No. Factura").ToString & "', '" & dr2.Item("Tipo Pago").ToString & "',  '" & dr2.Item("Monto_Pago").ToString & " ', '" & dr2.Item("Cobrador").ToString & "','" & dr2.Item("Valor_Recibo").ToString & "'"

                    otrans.Ingresa(lsSQL3)


                Next
                MessageBox.Show("Datos grabados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiarcampos()
                limpiarFin()
                txt_recibo.Text = String.Empty
                txt_suma_final.Text = 0
                txt_suma_final2.Text = 0
                txtPago.Enabled = False
                txt_b_ctacte.Enabled = False
                txtNo_recibo.Focus()

            Else
                MessageBox.Show("El monto de recibo no coincide con los valores ingresados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If




        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub

    Private Sub generarInfoLotes()
        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable
        Dim dt As DataTable
        oTrans = New Transaccional.Conexion("SCM")


        Dim ls_sqltxt As String
        oDataSet = New DataSet


        ls_sqltxt = "Pa_sel_um_encabezados_lote   '" & gs_empresa & "','" & Me.dt_inicio.Text & "','" & Me.dt_fin.Text & "'"
        Try
            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)
            oTabla.TableName = "Encabezado"
            dgv_encabezado_lote.DataSource = oTabla
            'oDataSet.Tables.Add(oTabla.Copy)




        Catch ex As Exception

        End Try


    End Sub

    Private Sub generarInfoDetalleLotes()

        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable



        Dim dt As DataTable
        oTrans = New Transaccional.Conexion("SCM")


        Dim ls_sqltxt As String
        oDataSet = New DataSet


        ls_sqltxt = "pa_sel_um_detalle_lote  '" & gs_empresa & "','" & txt_lote_busqueda.Text & "'"


        Try
            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)
            oTabla.TableName = "Detalle"
            dgv_detalle_recibos.DataSource = oTabla
            'oDataSet.Tables.Add(oTabla.Copy)







        Catch ex As Exception

        End Try


    End Sub



    Private Sub generarTotalLote()

        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable



        Dim dt As DataTable
        oTrans = New Transaccional.Conexion("SCM")


        Dim ls_sqltxt As String
        oDataSet = New DataSet


        ls_sqltxt = "pa_sel_um_detalle_lote_resumen_pago'" & gs_empresa & "','" & txt_lote_busqueda.Text & "'"


        Try
            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)
            oTabla.TableName = "PagosTotal"
            dgv_pagos_total.DataSource = oTabla
            'oDataSet.Tables.Add(oTabla.Copy)







        Catch ex As Exception

        End Try


    End Sub
    Private Sub detalle_pedido(ByVal pi_RowNumber As Integer)
        Dim clgen As New ClasesGenerales.General

        'ls_resultado = Me.dg_pedidos.Item(pi_RowNumber, 3)

        oDataSet.Tables("Detalle").DefaultView.RowFilter = "Lote = '" & dgv_encabezado_lote.Item("Lote", pi_RowNumber).Value & "'"

        Me.dgv_encabezado_lote.DataSource = oDataSet.Tables("Detalle")
        Me.dgv_encabezado_lote.Refresh()

        clgen.Alinear_GridView(oDataSet.Tables("Detalle"), dgv_encabezado_lote, "", "", "", "", "", "", "", True, True, 200, 0)


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        oDataSet.Tables("PagosTotal").DefaultView.RowFilter = "Lote = '" & dgv_pagos_total.Item("Lote", pi_RowNumber).Value & "'"

        Me.dgv_pagos_total.DataSource = oDataSet.Tables("PagosTotal")
        Me.dgv_pagos_total.Refresh()

        clgen.Alinear_GridView(oDataSet.Tables("PagosTotal"), dgv_pagos_total, "", "", "", "", "", "", "", True, True, 200, 0)

        Me.TabControl1.SelectedTab = Me.TabPage3

        clgen = Nothing


    End Sub


    Private Sub generarlote()
        Dim otrans As New Transaccional.Conexion("SCM")


        Dim lsSQL2 As String


        Try
            otrans.open()

            lsSQL2 = " SP_recibos_creacion_lote '" & gs_empresa & "','" & gs_usuario & "'"
            otrans.Ingresa(lsSQL2)
            MessageBox.Show("Lote Generado con Éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception

        End Try



    End Sub


    Private Sub IngresarEstadosLog()
        Dim otrans As New Transaccional.Conexion("SCM")


        Dim lsSQL2 As String
        Dim ls_sql As String


        Try
            otrans.open()
            If txt_estado_lote.Text = 10 Then
                lsSQL2 = " pa_ins_um_log_lote_recibo'" & gs_empresa & "','" & Me.txt_lote_dia.Text & "','20','" & gs_usuario & "'"
                otrans.Ingresa(lsSQL2)
            Else

                ls_sql = "pa_upd_um_log_lote_recibo'" & gs_empresa & "','" & Me.txt_lote_dia.Text & "','20','" & gs_usuario & "' "
                otrans.Actualiza(ls_sql)
            End If

        Catch ex As Exception

        End Try



    End Sub

    Private Sub IngresarEstadosLog2()
        Dim otrans As New Transaccional.Conexion("SCM")


        Dim lsSQL2 As String
        Dim ls_sql As String


        Try
            otrans.open()
            If txt_estado2_lote.Text = 20 Then
                lsSQL2 = " pa_ins_um_log_lote_recibo'" & gs_empresa & "','" & Me.txt_lote_dia.Text & "','30','" & gs_usuario & "'"
                otrans.Ingresa(lsSQL2)
            Else
            End If

        Catch ex As Exception

        End Try



    End Sub

    Private Sub IngresarEstadosLog3()
        Dim otrans As New Transaccional.Conexion("SCM")


        Dim lsSQL2 As String
        Dim ls_sql As String


        Try
            otrans.open()
            If txt_estado2_lote.Text = 20 Then
                lsSQL2 = " pa_ins_um_log_lote_recibo'" & gs_empresa & "','" & Me.txt_lote_1.Text & "','" & Me.txt_estado_actualizar.Text & "','" & gs_usuario & "'"
                otrans.Ingresa(lsSQL2)
            Else
            End If

        Catch ex As Exception

        End Try



    End Sub


    Private Sub cargarAbono()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ls_sql As String

        Dim valor As String

        Try
            Otrans.open()

            If chk_manual.Checked Then
                ls_sql = "spa_sel_abono_detalle_Recibos  '" & gs_empresa & "','" & Me.txt_num_fac2.Text & "','" & Me.cmb_tipodocto.Text & "'"
                dt = Otrans.Obtiene(ls_sql)

                If dt.Rows.Count > 0 Then
                    Me.txt_abono.Text = dt.Rows(0)("pagos").ToString
                    txt_abono.Text = FormatNumber(txt_abono.Text, 2)





                End If


            Else

                ls_sql = "spa_sel_abono_detalle_Recibos  '" & gs_empresa & "','" & Me.numero.Text & "','" & Me.txt_tipo_docto.Text & "'"
                dt = Otrans.Obtiene(ls_sql)
                If dt.Rows.Count > 0 Then
                    Me.txt_abono.Text = dt.Rows(0)("pagos").ToString
                    txt_abono.Text = FormatNumber(txt_abono.Text, 2)


                End If


            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try



    End Sub
    Private Sub contarRegistros()

        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ls_sql As String

        Dim valor As String

        Try
            Otrans.open()


            ls_sql = "pa_sel_um_contar_registros  '" & gs_empresa & "','" & Me.txt_lote_dia.Text & "'"
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                Me.txt_cantidad.Text = dt.Rows(0)("Cantidad").ToString

            End If




        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub contarRegistros2()

        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ls_sql As String

        Dim valor As String

        Try
            Otrans.open()


            ls_sql = "pa_sel_um_contar_registros  '" & gs_empresa & "','" & Me.txt_lote_busqueda.Text & "'"
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                Me.txt_registros.Text = dt.Rows(0)("Cantidad").ToString

            End If




        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub frm_Recibos_Lote1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If txt_lote_dia.Text = "" Then


        End If
        'If txt_lote_dia.Text = "" Then
        '    btn_validar.Enabled = False
        '    btn_cuadrar.Enabled = False
        'Else
        '    btn_validar.Enabled = True
        '    btn_cuadrar.Enabled = True
        'End If





        Try


            agregarLinea()
            crearestructura()

            Tipo.Text = "CONTADO"
            Transaccion.Text = "Recibo"



            'If cmbFormaPago.Text = "" Then
            'Me.TabControl1.TabPages(1).Enabled = False
            'txtPago.Visible = False


            'End If
            TipoDocto()
            'llenarFormasPago()
            If Convert.ToInt16(txt_estado2_lote.Text) = 10 Or 20 Then
                llenarLotes()
            End If
            contarRegistros()

            If txt_cantidad.Text = 0 Then
                btn_validar.Enabled = False
                btn_cuadrar.Enabled = False
            Else
                btn_validar.Enabled = True
                btn_cuadrar.Enabled = True
            End If

            If txt_cte.Text = "" Then
                txtPago.Enabled = False
                'cmbFormaPago.Enabled = False
            Else
                txtPago.Enabled = True
                'cmbFormaPago.Enabled = True
            End If




            txt_cobrado.Text = 0
            txt_diferencia.Text = 0


            txt_recibo.Visible = True
            txtNo_recibo.Visible = False
            fecha_manual.Visible = True
            fecha_manual.Enabled = False
            txt_valorR.Enabled = False
            txt_valorR.Enabled = False
            'fecha_manual.Visible = False

            Try
                If txt_estado2_lote.Text <> 20 Or 10 Then
                    btn_generar_lote.Enabled = False
                Else
                    btn_generar_lote.Enabled = True
                End If
                If txt_estado2_lote.Text = 0 Then
                    btn_generar_lote.Enabled = True
                End If

            Catch ex As Exception

            End Try





        Catch ex As Exception

        End Try




    End Sub


    Private Sub TipoDocto()

        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_sel_um_tipodocumento '" & gs_empresa & "' ,'" & "Boleta (v)" & "' ")


            Me.cmb_tipodocto.DataSource = dt
            Me.cmb_tipodocto.ValueMember = "tipoDocto"
            Me.cmb_tipodocto.DisplayMember = "tipoDocto"




        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try






    End Sub

    Dim isNuevo As Boolean = True
    Dim dt_Info As DataTable

    Private Sub buscarRecibo()
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Dim dt2 As DataTable
        Dim ls_sql As String
        Dim ls_sql2 As String
        Dim valor As String

        Try
            Otrans.open()
            ls_sql = "pa_sel_um_recibosfc '" & gs_empresa & "','" & Me.txt_recibo.Text & "'"

            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then

                valor = dt.Rows(0)("total").ToString
                Dim val As Double

                Me.txt_cte.Text = dt.Rows(0)("cliente").ToString
                Me.txt_razonS.Text = dt.Rows(0)("razonsocial").ToString
                Me.fecha_manual.Text = dt.Rows(0)("fecha").ToString
                Me.numero.Text = dt.Rows(0)("numero").ToString
                Me.txt_tipo_docto.Text = dt.Rows(0)("tipodocto").ToString
                Me.txt_val2.Text = dt.Rows(0)("total").ToString
                Me.txt_total_fact.Text = dt.Rows(0)("total").ToString
                Me.txt_valorR.Text = dt.Rows(0)("total").ToString
                'Me.txt_val_recibo.Text = dt.Rows(0)("total").ToString
                'val = Convert.ToDouble(txt_total.Text)
                txt_total_fact.Text = FormatNumber(txt_total_fact.Text, 2)




                'Me.txt_correlativo.Text = dt.Rows(0)("Correlativo").ToString
                'Me.txt_razonS.Text = dt.Rows(0)("RazonSocial").ToString

            Else

                MessageBox.Show("Recibo No Existe, Verificar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_recibo.Text = String.Empty
                limpiarcampos()

            End If
            Try
                ls_sql2 = "pa_sel_um_documento_recibo '" & gs_empresa & "','" & Me.txt_tipo_docto.Text & "','" & Me.numero.Text & "'"
                dt2 = Otrans.Obtiene(ls_sql2)
                If dt2.Rows.Count > 0 Then
                    Me.txt_tipoC.Text = dt2.Rows(0)("TipoComprobante").ToString

                    If txt_tipoC.Text = " " Then
                        txt_centralizada.Text = "NO"
                        txtPago.Enabled = False
                        btn_agregar.Enabled = False
                    Else
                        txt_centralizada.Text = "SI"
                        txtPago.Enabled = True
                        btn_agregar.Enabled = True


                        '    limpiarcampos2()
                    End If


                End If

            Catch ex As Exception

            End Try


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub



    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_recibo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_recibo.KeyPress
        If txt_lote_dia.Text = "" Then
            MessageBox.Show("Debe Generar Lote", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btn_generar_lote.Focus()
            txt_recibo.Enabled = False
            txt_recibo.Text = String.Empty
        Else
            txt_recibo.Enabled = True


        End If
    End Sub

    Private Sub txt_recibo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_recibo.LostFocus
        Try


            If chk_manual.Checked Then
                reciboExiste()

                Me.txt_b_ctacte.Enabled = False
                Me.txt_valorR.Enabled = True

                Me.fecha_manual.Enabled = True
                'fecha_manual.Focus()

                'Me.txt_valorR.Focus()

            Else

                buscarRecibo()
                txt_total_fact.Text = FormatNumber(txt_total_fact.Text, 2)
                txt_valorR.Text = FormatNumber(txt_valorR.Text, 2)
                'txt_val_recibo.Text = FormatNumber(txt_val_recibo.Text, 2)
                cargarAbono()

                If txt_abono.Text = "" Then
                    txt_abono.Text = TextBox1.Text
                End If
                If txt_abono.Text = txt_total_fact.Text Then
                    MessageBox.Show("Recibo Cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtPago.Enabled = False
                    btn_agregar.Enabled = False



                End If

                txt_cobrador.Focus()



            End If



        Catch ex As Exception

        End Try

    End Sub

    Private Sub txt_recibo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_recibo.TextChanged

    End Sub

    Private Sub txt_fecha_emision_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_tipo_docto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_ayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_total_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_valores.CellContentClick

    End Sub

    Private Sub txtPago_ParentChanged(sender As Object, e As EventArgs) Handles txtPago.ParentChanged

    End Sub




    Private Sub txtPago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPago.TextChanged

    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar_recibo.Click
        Try
            sumar()
            'hacer el cambio de la suma para que valide en todo momento.....
            recorrer()

            grabar()

            actualizar()
            IngresarEstadosLog()
            llenarLotes()
            contarRegistros()
            txt_suma_final.Text = 0
            txt_suma_final2.Text = 0
            txt_sm_valida.Text = 0
            txt_recibo.Text = String.Empty
            txtPago.Enabled = False
            txt_b_ctacte.Enabled = False
            If txt_cantidad.Text = 0 Then
                btn_validar.Enabled = False
                btn_cuadrar.Enabled = False
            Else
                btn_validar.Enabled = True
                btn_cuadrar.Enabled = True
            End If
            txt_valorR.Enabled = True
        Catch ex As Exception

        End Try





    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub suma_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub


    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiarcampos()
    End Sub

    Private Sub txt_no_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_no_factura.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub dtFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtFecha.ValueChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub Label12_Click(sender As Object, e As EventArgs)

    End Sub







    Private Sub txt_fact_LostFocus(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_fact_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs)




    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub buscarFactura()
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Dim dt2 As DataTable

        Dim ls_sql As String
        Dim ls_sql2 As String




        Dim valor1 As String

        Try




            Otrans.open()
            ls_sql = "pa_sel_um_documento_recibo '" & gs_empresa & "','" & Me.cmb_tipodocto.Text & "','" & Me.txt_num_fac2.Text & "'"
            dt = Otrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then

                valor1 = dt.Rows(0)("total").ToString
                Dim val As Double


                Me.txt_cte.Text = dt.Rows(0)("cliente").ToString
                Me.fecha_manual.Text = dt.Rows(0)("fecha").ToString
                Me.txt_tipoC.Text = dt.Rows(0)("TipoComprobante").ToString
                Me.numero.Text = dt.Rows(0)("numero").ToString
                Me.txt_tipo_docto.Text = dt.Rows(0)("tipodocto").ToString
                Me.txt_val2.Text = dt.Rows(0)("total").ToString
                Me.txt_total_fact.Text = dt.Rows(0)("total").ToString
                val = Convert.ToDouble(txt_total_fact.Text)
                txt_total_fact.Text = FormatNumber(txt_total_fact.Text, 2)


                If txt_abono.Text = txt_total_fact.Text Then
                    MessageBox.Show("Recibo Cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtPago.Enabled = False

                End If

                If txt_tipoC.Text = " " Then
                    txt_centralizada.Text = "NO"
                    txtPago.Enabled = False
                Else
                    txt_centralizada.Text = "SI"
                    txtPago.Enabled = True


                    '    limpiarcampos2()
                End If


                ls_sql2 = "pa_sel_um_cliente_recibo '" & gs_empresa & "','" & Me.txt_cte.Text & "'"
                dt2 = Otrans.Obtiene(ls_sql2)
                If dt2.Rows.Count > 0 Then
                    Me.txt_razonS.Text = dt2.Rows(0)("RazonSocial").ToString




                    If txt_cte.Text = txt_b_ctacte.Text Then

                    Else
                        MessageBox.Show("No se puede cargar Factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txt_b_ctacte.Focus()
                        limpiar2()
                    End If

                End If




            Else
                MessageBox.Show("Factura No Existe, Verificar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)




            End If

            If cmb_tipodocto.Text = "FACE-63-FEA-001" Or cmb_tipodocto.Text = "FACE-63-FEA-002" Then
                txt_num_fac.Visible = True
                txt_no.Visible = False

                txt_no.Text = " "
                txt_num_fac.Text = " "

            Else


                txt_no.Visible = True
                txt_num_fac.Visible = False

                txt_no.Text = " "
                txt_num_fac.Text = " "



            End If



        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub buscarCliente()
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Dim ls_sql2 As String

        Try
            Otrans.open()

            ls_sql2 = "pa_sel_um_cliente_recibo '" & gs_empresa & "','" & Me.txt_b_ctacte.Text & "'"
            dt2 = Otrans.Obtiene(ls_sql2)
            If dt2.Rows.Count > 0 Then
                Me.txt_razonS2.Text = dt2.Rows(0)("RazonSocial").ToString
                GroupBox6.Enabled = True
                cmb_tipodocto.Focus()

            Else
                MessageBox.Show("Cliente no existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txt_b_ctacte.Text = String.Empty
                Me.txt_b_ctacte.Focus()
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try



    End Sub



    Private Sub txt_num_final_LostFocus(sender As Object, e As EventArgs)
        buscarFactura()
    End Sub

    Private Sub txt_num_final_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_tipodocto.SelectedIndexChanged
        If cmb_tipodocto.Text = "FACE-63-FEA-001" Or cmb_tipodocto.Text = "FACE-63-FEA-002" Or cmb_tipodocto.Text = "FACE-63-FEH-001" Then
            txt_num_fac.Visible = True
            txt_no.Visible = False

            txt_no.Text = " "
            txt_num_fac.Text = " "

            txt_num_fac.Focus()


        Else


            txt_no.Visible = True
            txt_num_fac.Visible = False

            txt_no.Text = " "
            txt_num_fac.Text = " "
            txt_no.Focus()



        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''






    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btn_generar_lote.Click
        If txt_lote_dia.Text = "" Then
            generarlote()
            llenarLotes()
            contarRegistros()
            btn_generar_lote.Enabled = False
            'btn_cuadrar.Enabled = True
            'btn_validar.Enabled = True
            txt_no.Enabled = False
            txt_recibo.Enabled = True
            txt_recibo.Text = String.Empty

        End If

        If txt_cantidad.Text = 0 Then
            btn_validar.Enabled = False
            btn_cuadrar.Enabled = False
        Else
            btn_validar.Enabled = True
            btn_cuadrar.Enabled = True
        End If


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)


    End Sub
    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_total_fact_TextChanged(sender As Object, e As EventArgs) Handles txt_total_fact.TextChanged

    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs)


        'Button2.Visible = False


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)







    End Sub

    Private Sub txt_lote2_TextChanged(sender As Object, e As EventArgs)


    End Sub

    Private Sub txt_cobrado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cobrado.KeyPress

    End Sub

    Private Sub txt_cobrado_TextChanged(sender As Object, e As EventArgs) Handles txt_cobrado.TextChanged

    End Sub

    Private Sub Txt_diferencia_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btn_grabar_Factura_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub actualizar()

        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable

        Dim ls_sql As String


        Try
            Otrans.open()
            ls_sql = "pa_upd_um_encabezado_lote_recibo  '" & gs_empresa & "','20','" & Me.txt_lote_dia.Text & "' "
            Otrans.Actualiza(ls_sql)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try



    End Sub


    Private Sub actualizarCuadrado()

        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable

        Dim ls_sql As String


        Try
            Otrans.open()
            ls_sql = "pa_upd_um_encabezado_lote_recibo  '" & gs_empresa & "','30','" & Me.txt_lote_dia.Text & "' "
            Otrans.Actualiza(ls_sql)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try



    End Sub
    Private Sub actualizarRevisado()

        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable

        Dim ls_sql As String


        Try
            Otrans.open()
            ls_sql = "pa_upd_um_encabezado_lote_recibo  '" & gs_empresa & "','" & Me.txt_estado_actualizar.Text & "','" & Me.txt_lote_1.Text & "' "
            Otrans.Actualiza(ls_sql)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try



    End Sub





    Private Sub TextBox3_LostFocus(sender As Object, e As EventArgs) Handles txt_num_fac.LostFocus
        Dim valor As String = txt_num_fac.Text.Substring(0, 2)
        TextBox4.Text = valor
        TextBox5.Text = txt_num_fac.Text.Substring(2)
        txt_num_fac2.Text = valor + TextBox5.Text.PadLeft(10, "0")
        txt_num_fac2.Visible = True
        txt_num_fac.Visible = False

        buscarFactura()
        cargarAbono()

        If txt_abono.Text = "" Then
            txt_abono.Text = TextBox1.Text
        End If
        txt_suma_.Text = Double.Parse(txt_total_fact.Text) - Double.Parse(txt_abono.Text)
        resta_abonado.Text = txt_total_fact.Text - txt_abono.Text
        cmbFormaPago.Focus()
        BuscarExiste()

        If txt_num_fac2.Text > 0 Then
            txt_num_fac.Visible = False
        End If


    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txt_num_fac.TextChanged

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmb_lotes_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub



    Private Sub txt_no_LostFocus(sender As Object, e As EventArgs) Handles txt_no.LostFocus
        Try
            txt_num_fac2.Text = txt_no.Text.PadLeft(10, "0")
            txt_no.Visible = False
            txt_num_fac2.Visible = True
            buscarFactura()
            cargarAbono()
            txt_suma_.Text = Double.Parse(txt_total_fact.Text) - Double.Parse(txt_abono.Text)


            If txt_abono.Text = "" Then
                txt_abono.Text = TextBox1.Text
            End If

            cmb_tipodocto.Focus()
            resta_abonado.Text = txt_total_fact.Text - txt_abono.Text
            BuscarExiste()
            cmbFormaPago.Focus()

        Catch ex As Exception

        End Try



    End Sub

    Private Sub BuscarExiste()

        Try
            For Each dr2 As DataRow In ods2.Tables("linea").Rows
                If dr2.Item("Tipo Documento") = Me.txt_tipo_docto.Text And dr2.Item("No. Factura") = Me.numero.Text Then
                    MessageBox.Show("No se puede cargar La misma Factura Validar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    borrar()

                    Exit For
                End If

            Next



        Catch ex As Exception

        End Try


    End Sub

    Private Sub borrar()
        Me.txt_num_fac.Text = String.Empty
        Me.txt_num_fac2.Text = String.Empty
        Me.txt_cte.Text = String.Empty
        Me.txt_razonS.Text = String.Empty
        Me.numero.Text = String.Empty
        Me.txt_tipo_docto.Text = String.Empty
        Me.txt_total_fact.Text = String.Empty
        Me.txt_tipoC.Text = String.Empty
        Me.txt_centralizada.Text = String.Empty
        Me.resta_abonado.Text = String.Empty
        Me.txt_abono.Text = String.Empty
        Me.txt_suma_.Text = String.Empty
        Me.txc_txta.Text = String.Empty
        Me.txt_sm.Text = String.Empty

    End Sub

    Private Sub txt_no_TextChanged(sender As Object, e As EventArgs) Handles txt_no.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged_1(sender As Object, e As EventArgs) Handles txt_diferencia.TextChanged

    End Sub

    Private Sub txt_cobrado1_TextChanged(sender As Object, e As EventArgs) Handles txt_cobrado1.TextChanged

    End Sub


    Private Sub txt_estado_lote_TextChanged(sender As Object, e As EventArgs) Handles txt_estado_lote.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub dg_valores_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dg_valores.CellValidated

    End Sub

    Private Sub dg_valores_Click(sender As Object, e As EventArgs) Handles dg_valores.Click
        Try
            Dim nrow As Integer
            nrow = Me.dg_valores.CurrentRow.Index()
            txt_val_resta.Text = Me.dg_valores.Item("valor", nrow).Value
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dg_valores_ColumnDefaultCellStyleChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles dg_valores.ColumnDefaultCellStyleChanged

    End Sub

    Private Sub dg_valores_MouseClick(sender As Object, e As MouseEventArgs) Handles dg_valores.MouseClick


        'txt_valor_grid.Text = (dg_valores(0, 1).Value.ToString())


    End Sub

    Private Sub dg_valores_MultiSelectChanged(sender As Object, e As EventArgs) Handles dg_valores.MultiSelectChanged

    End Sub
    Private Sub validacionFrm_Pago()

    End Sub

    Private Sub dg_valores_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dg_valores.RowPrePaint

    End Sub

    Private Sub dg_valores_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dg_valores.RowsRemoved
        Try

            'txt_cobrado.Text = Double.Parse(txc_txta.Text) - Double.Parse(txt_val_resta.Text)
            txt_cobrado.Text = Double.Parse(txt_cobrado.Text) - Double.Parse(txt_val_resta.Text)

            txt_diferencia.Text = txt_total_fact.Text - txt_cobrado.Text
            'txt_diferencia.Text = Double.Parse(txc_txta.Text) - Double.Parse(txt_val_resta.Text)
            txt_diferencia.Text = FormatNumber(txt_diferencia.Text, 2)
            If txt_abono.Text > 0 Then
                txc_txta.Text = Double.Parse(txt_abono.Text) + Double.Parse(txt_val_resta.Text)
                txt_sm.Text = Double.Parse(txt_cobrado.Text) + Double.Parse(txt_abono.Text)
                txt_diferencia.Text = txt_val2.Text - txt_sm.Text



            Else
                txt_diferencia.Text = txt_total_fact.Text - txt_cobrado.Text
            End If

            txt_val_resta.Text = 0
            txt_diferencia.Text = FormatNumber(txt_diferencia.Text, 2)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chk_manual.CheckedChanged
        If chk_manual.Checked Then
            txt_recibo.Focus()
            GroupBox6.Visible = True


            Tipo.Text = "CREDITO"
            Transaccion.Text = "Factura"
            'txtNo_recibo.Visible = True
            'txt_recibo.Visible = False
            'fecha_fac.Visible = False
            fecha_manual.Enabled = True
            'txt_val_recibo.Enabled = True
            txt_valorR.Enabled = True
            txt_b_ctacte.Visible = True
            Label1.Visible = True

            'txt_val_recibo.Text = String.Empty
            txt_valorR.Text = String.Empty
            txt_recibo.Text = String.Empty
            txtNo_recibo.Text = String.Empty
            txt_razonS2.Visible = True
            Label8.Visible = True
            txt_b_ctacte.Visible = True



            limpiarcampos()
        Else
            GroupBox6.Visible = False
            Tipo.Text = "CONTADO"
            Transaccion.Text = "Recibo"
            txt_recibo.Visible = True
            txtNo_recibo.Visible = False
            'fecha_fac.Visible = True
            'fecha_fac.Enabled = False
            'txt_val_recibo.Enabled = False
            txt_recibo.Focus()
            txt_valorR.Enabled = False
            fecha_manual.Visible = True
            txt_razonS2.Visible = False
            Label8.Visible = False


            'txt_val_recibo.Text = String.Empty
            txt_valorR.Text = String.Empty
            txt_recibo.Text = String.Empty
            txtNo_recibo.Text = String.Empty
            txt_b_ctacte.Visible = False
            Label1.Visible = False




            limpiarcampos()
        End If
    End Sub

    Private Sub fecha_manual_LostFocus(sender As Object, e As EventArgs) Handles fecha_manual.LostFocus
        'Me.txt_valorR.Focus()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles fecha_manual.ValueChanged

    End Sub

    Private Sub txt_cobrador_LostFocus(sender As Object, e As EventArgs) Handles txt_cobrador.LostFocus


        txt_b_ctacte.Enabled = True
        txt_b_ctacte.Focus()






    End Sub

    Private Sub TextBox6_TextChanged_1(sender As Object, e As EventArgs) Handles txt_cobrador.TextChanged

    End Sub



    Private Sub Button1_Click_3(sender As Object, e As EventArgs)










    End Sub
    Private Sub limpiar()
        Me.txt_cobrado1.Text = String.Empty
        Me.txt_cobrado.Text = String.Empty
        dt = CType(Me.dg_valores.DataSource, DataTable)
        dt.Rows.Clear()
        Me.txt_diferencia.Text = String.Empty
    End Sub

    Private Sub limpiar2()
        cmb_tipodocto.Text = String.Empty
        Me.txt_no.Text = String.Empty
        'Me.txt_num_fac.Text = String.Empty
        Me.txt_num_fac2.Text = String.Empty
        Me.txt_cte.Text = String.Empty
        Me.txt_razonS.Text = String.Empty
        Me.txt_tipo_docto.Text = String.Empty
        Me.txt_total_fact.Text = String.Empty
        Me.txt_abono.Text = String.Empty
        Me.resta_abonado.Text = String.Empty
        Me.numero.Text = String.Empty
        Me.txt_centralizada.Text = String.Empty
        Me.txt_tipoC.Text = String.Empty

    End Sub

    Private Sub limpiarFin()

        dt2 = CType(Me.dgv_linea2.DataSource, DataTable)
        dt2.Rows.Clear()
        Me.txt_serie_recibo.Text = String.Empty
        Me.txt_recibo.Text = String.Empty
        Me.txtNo_recibo.Text = String.Empty
        Me.fecha_manual.Text = String.Empty
        'Me.txt_val_recibo.Text = String.Empty
        Me.txt_cobrador.Text = String.Empty
        Me.txt_b_ctacte.Text = String.Empty
        Me.txt_razonS2.Text = String.Empty
        Me.cmb_tipodocto.Text = String.Empty
        Me.txt_num_fac.Text = String.Empty
        Me.txt_num_fac2.Text = String.Empty
        Me.txt_no.Text = String.Empty
        Me.txt_centralizada.Text = String.Empty
        Me.txt_tipoC.Text = String.Empty
        Me.txt_valorR.Text = String.Empty


    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click

        Try


            'si esta chequeado es recibo manual
            txt_suma_final2.Text = FormatNumber(txt_suma_final2.Text, 2)
            If chk_manual.Checked Then
                If txt_cte.Text = "" Then
                    MessageBox.Show("Debe ingresar numero de factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    If Double.Parse(txt_sm_valida.Text) = 0 Then


                        If Double.Parse(txt_cobrado.Text) > Double.Parse(txt_valorR.Text) Then
                            MessageBox.Show("La suma es mayor que el monto del Recibo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else

                            If Double.Parse(txt_suma_final2.Text) = Double.Parse(txt_valorR.Text) Then
                                MessageBox.Show("La suma es mayor que el monto del Recibo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Else
                                'si el abono no tiene nada lo tiene que validar con el total_fact
                                If txt_abono.Text = 0 Then

                                    ' lo valida con el total_fact
                                    If Double.Parse(txt_cobrado.Text) <= Double.Parse(txt_total_fact.Text) Then
                                        If Double.Parse(txt_suma_final2.Text) <= Double.Parse(txt_valorR.Text) Then
                                            llenar()
                                            sumar()
                                            limpiarcampos()
                                            txtPago.Text = String.Empty
                                        Else
                                            MessageBox.Show("El monto es mayor que el monto del Recibo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        End If





                                        If txt_suma_final.Text = txt_valorR.Text Then
                                            If MessageBox.Show("Las cantidades Coinciden,¿Desea Grabar?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                                                grabar()
                                                actualizar()
                                                IngresarEstadosLog()
                                                llenarLotes()
                                                contarRegistros()
                                                limpiarFin()
                                                txt_recibo.Text = String.Empty
                                                txt_suma_final.Text = 0
                                                txt_suma_final2.Text = 0
                                                txtPago.Enabled = False
                                                txt_b_ctacte.Enabled = False
                                                txtNo_recibo.Focus()

                                                txt_valorR.Enabled = True

                                                If txt_cantidad.Text = 0 Then
                                                    btn_validar.Enabled = False
                                                    btn_cuadrar.Enabled = False
                                                Else
                                                    btn_validar.Enabled = True
                                                    btn_cuadrar.Enabled = True
                                                End If


                                                cmb_tipodocto.Enabled = False
                                                txt_num_fac.Enabled = False

                                            End If
                                        End If


                                    Else
                                        MessageBox.Show("El Monto a Pagar no puede ser Mayor que el total de la factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        limpiar()




                                    End If
                                    'valida si tiene algo abonado
                                ElseIf Double.Parse(txt_abono.Text) > 0 Then
                                    If Double.Parse(txt_cobrado.Text) <= Double.Parse(resta_abonado.Text) Then
                                        If Double.Parse(txt_suma_final2.Text) <= Double.Parse(txt_valorR.Text) Then
                                            llenar()
                                            sumar()
                                            limpiarcampos()
                                        Else
                                            MessageBox.Show("El monto es mayor que el monto del Recibo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        End If

                                        'limpiarcampos()
                                        'If (txt_suma_final.Text > txt_val_recibo.Text) Then
                                        '    MessageBox.Show("El Monto es Mayor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        '    'dt2 = CType(Me.dgv_linea2.DataSource, DataTable)
                                        '    'dt2.Rows.Clear()


                                        'End If

                                        If txt_suma_final.Text = txt_valorR.Text Then
                                            llenar()
                                            sumar()
                                            limpiarcampos()
                                            If MessageBox.Show("Las cantidades Coinciden,¿Desea Grabar?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                                                grabar()
                                                actualizar()
                                                IngresarEstadosLog()
                                                llenarLotes()

                                                contarRegistros()
                                                If txt_cantidad.Text = 0 Then
                                                    btn_validar.Enabled = False
                                                    btn_cuadrar.Enabled = False
                                                Else
                                                    btn_validar.Enabled = True
                                                    btn_cuadrar.Enabled = True
                                                End If
                                                txt_valorR.Enabled = True
                                                limpiarFin()
                                                cmb_tipodocto.Enabled = False
                                                txt_num_fac.Enabled = False


                                            End If
                                        End If
                                    Else
                                        MessageBox.Show("El Monto a Pagar no puede ser Mayor que el total abonado factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        limpiar()
                                    End If




                                End If
                            End If
                        End If
                    Else
                        If Double.Parse(txt_cobrado.Text) > Double.Parse(txt_sm_valida.Text) Then
                            MessageBox.Show("La suma es mayor que el monto del Recibo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else

                            If Double.Parse(txt_suma_final2.Text) = Double.Parse(txt_valorR.Text) Then
                                MessageBox.Show("La suma es mayor que el monto del Recibo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Else
                                'si el abono no tiene nada lo tiene que validar con el total_fact
                                If txt_abono.Text = 0 Then

                                    ' lo valida con el total_fact
                                    If Double.Parse(txt_cobrado.Text) <= Double.Parse(txt_total_fact.Text) Then
                                        If Double.Parse(txt_suma_final2.Text) <= Double.Parse(txt_valorR.Text) Then
                                            llenar()
                                            sumar()
                                            limpiarcampos()
                                        Else
                                            MessageBox.Show("El monto es mayor que el monto del Recibo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        End If





                                        If txt_suma_final.Text = txt_valorR.Text Then
                                            If MessageBox.Show("Las cantidades Coinciden,¿Desea Grabar?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                                                grabar()
                                                actualizar()
                                                IngresarEstadosLog()
                                                llenarLotes()
                                                contarRegistros()
                                                limpiarFin()
                                                txt_recibo.Text = String.Empty
                                                txtPago.Enabled = False
                                                txt_recibo.Text = String.Empty
                                                txt_suma_final.Text = 0
                                                txt_suma_final2.Text = 0

                                                txt_b_ctacte.Enabled = False
                                                txt_recibo.Focus()
                                                txt_valorR.Enabled = True
                                                If txt_cantidad.Text = 0 Then
                                                    btn_validar.Enabled = False
                                                    btn_cuadrar.Enabled = False
                                                Else
                                                    btn_validar.Enabled = True
                                                    btn_cuadrar.Enabled = True
                                                End If
                                                cmb_tipodocto.Enabled = False
                                                txt_num_fac.Enabled = False




                                            End If
                                        End If


                                    Else
                                        MessageBox.Show("El Monto a Pagar no puede ser Mayor que el total de la factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        limpiar()




                                    End If
                                    'valida si tiene algo abonado
                                ElseIf Double.Parse(txt_abono.Text) > 0 Then
                                    If Double.Parse(txt_cobrado.Text) <= Double.Parse(resta_abonado.Text) Then
                                        If Double.Parse(txt_suma_final2.Text) <= Double.Parse(txt_valorR.Text) Then
                                            llenar()
                                            sumar()
                                            limpiarcampos()
                                        Else
                                            MessageBox.Show("El monto es mayor que el monto del Recibo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        End If

                                        'limpiarcampos()
                                        'If (txt_suma_final.Text > txt_val_recibo.Text) Then
                                        '    MessageBox.Show("El Monto es Mayor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        '    'dt2 = CType(Me.dgv_linea2.DataSource, DataTable)
                                        '    'dt2.Rows.Clear()


                                        'End If

                                        If txt_suma_final.Text = txt_valorR.Text Then
                                            llenar()
                                            sumar()
                                            limpiarcampos()
                                            If MessageBox.Show("Las cantidades Coinciden,¿Desea Grabar?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                                                grabar()
                                                actualizar()
                                                IngresarEstadosLog()
                                                llenarLotes()
                                                contarRegistros()
                                                txt_valorR.Enabled = True
                                                limpiarFin()

                                                If txt_cantidad.Text = 0 Then
                                                    btn_validar.Enabled = False
                                                    btn_cuadrar.Enabled = False
                                                Else
                                                    btn_validar.Enabled = True
                                                    btn_cuadrar.Enabled = True
                                                End If
                                                cmb_tipodocto.Enabled = False
                                                txt_num_fac.Enabled = False

                                            End If
                                        End If
                                    Else
                                        MessageBox.Show("El Monto a Pagar no puede ser Mayor que el total abonado factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        limpiar()
                                    End If




                                End If
                            End If
                        End If
                    End If
                End If











                'si no esta chequeado es recibo
                txt_cobrado.Text = FormatNumber(txt_cobrado.Text, 2)
            ElseIf Double.Parse(txt_cobrado.Text) = Double.Parse(txt_total_fact.Text) Then
                llenar()
                sumar()
                If MessageBox.Show("Las cantidades Coinciden,¿Desea Grabar?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then

                    grabar()
                    actualizar()
                    IngresarEstadosLog()
                    llenarLotes()
                    contarRegistros()
                    limpiarFin()
                    btn_validar.Enabled = True
                    btn_cuadrar.Enabled = True
                    txt_valorR.Enabled = True

                    If txt_cantidad.Text = 0 Then
                        btn_validar.Enabled = False
                        btn_cuadrar.Enabled = False
                    Else
                        btn_validar.Enabled = True
                        btn_cuadrar.Enabled = True
                    End If

                End If


            Else

                MessageBox.Show("Las Cantidades no coinciden, revisar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'limpiar()


            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub txt_valor_grid_TextChanged(sender As Object, e As EventArgs)

    End Sub

    'Private Sub txt_val_recibo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_val_recibo.KeyPress
    '    e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)

    '    If e.KeyChar = "." And Not txt_val_recibo.Text.IndexOf(".") Then
    '        e.Handled = True
    '    ElseIf e.KeyChar = "." Then
    '        e.Handled = False
    '    End If



    'End Sub

    'Private Sub txt_val_recibo_LostFocus(sender As Object, e As EventArgs) Handles txt_val_recibo.LostFocus



    '        txt_valorR.Text = txt_val_recibo.Text

    '        txt_val_recibo.Text = FormatNumber(txt_val_recibo.Text, 2)
    '    txt_cobrador.Focus()
    '    txt_val_recibo.Enabled = False



    'End Sub

    Private Sub txt_val_recibo_TextChanged(sender As Object, e As EventArgs) Handles txt_val_recibo.TextChanged

    End Sub
    Private Sub sumar()
        Dim dt As DataTable = DirectCast(dgv_linea2.DataSource, DataTable)
        Dim suma2 As Object = dt.Compute("SUM(Monto_pago)", Nothing)
        Try
            txt_suma_final2.Text = suma2
            txt_suma_final.Text = suma2

            'valor2 = Convert.ToDouble(txt_cobrado.Text)

            txt_suma_final.Text = FormatNumber(txt_suma_final.Text, 2)
            txt_suma_final2.Text = FormatNumber(txt_suma_final2.Text, 2)
            txt_sm_valida.Text = Double.Parse(txt_valorR.Text) - Double.Parse(txt_suma_final.Text)
            txt_sm_valida.Text = FormatNumber(txt_sm_valida.Text, 2)
        Catch ex As Exception

        End Try



    End Sub


    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgv_linea2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_linea2.CellContentClick

    End Sub

    Private Sub txt_valor_grid_TextChanged_1(sender As Object, e As EventArgs) Handles resta_abonado.TextChanged

    End Sub

    Private Sub txt_valorR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_valorR.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)

        If e.KeyChar = "." And Not txt_valorR.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        End If
    End Sub

    Private Sub txt_valorR_LostFocus(sender As Object, e As EventArgs) Handles txt_valorR.LostFocus
        txt_valorR.Text = FormatNumber(txt_valorR.Text, 2)
        txt_cobrador.Focus()


    End Sub

    Private Sub txt_valorR_TextChanged(sender As Object, e As EventArgs) Handles txt_valorR.TextChanged

    End Sub
    Private Sub reciboExiste()
        Dim Otrans As New Transaccional.Conexion("scm")
        Dim dt As DataTable
        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_sel_um_recibo_existe '" & gs_empresa & "' ,'" & Me.txt_recibo.Text & "' ")

            If dt.Rows.Count > 0 Then
                Me.txt_resp.Text = "SI"

                MessageBox.Show("Recibo ya esta cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_recibo.Text = String.Empty


            End If





        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub txtNo_recibo_LostFocus(sender As Object, e As EventArgs) Handles txtNo_recibo.LostFocus




    End Sub

    Private Sub txtNo_recibo_TextChanged(sender As Object, e As EventArgs) Handles txtNo_recibo.TextChanged

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub btn_generar_Click(sender As Object, e As EventArgs) Handles btn_generar.Click
        crearEstructuraLote()
        generarInfoLotes()
    End Sub

    Private Sub dgv_encabezado_lote_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_encabezado_lote.CellContentClick

    End Sub

    Private Sub dgv_encabezado_lote_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_encabezado_lote.CellDoubleClick

    End Sub



    Private Sub dgv_encabezado_lote_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles dgv_encabezado_lote.DefaultValuesNeeded

    End Sub

    Private Sub dgv_encabezado_lote_DoubleClick(sender As Object, e As EventArgs) Handles dgv_encabezado_lote.DoubleClick


        Dim nrow As Integer
        nrow = Me.dgv_encabezado_lote.CurrentRow.Index()
        txt_lote_busqueda.Text = Me.dgv_encabezado_lote.Item("Lote", nrow).Value
        txt_lote_1.Text = txt_lote_busqueda.Text

        Dim nrow2 As Integer
        nrow2 = Me.dgv_encabezado_lote.CurrentRow.Index()
        txt_usr_grabo.Text = Me.dgv_encabezado_lote.Item("Usuario", nrow2).Value

        Dim nrow3 As Integer
        nrow2 = Me.dgv_encabezado_lote.CurrentRow.Index()
        txt_estado_actual.Text = Me.dgv_encabezado_lote.Item("estado", nrow2).Value


        If txt_estado_actual.Text = "Nuevo" Or txt_estado_actual.Text = "Pendiente" Then

            GroupBox2.Visible = False
            'Button2.Visible = False
            'cmb_actualiza_estado.Visible = False
            'cmb_actualiza_estado2.Visible = False
            'cmb_actualiza_estado3.Visible = False


        Else
            GroupBox2.Visible = True
            If txt_estado_actual.Text = "Cuadrado" Or txt_estado_actual.Text = "Rechazado" Then


                cmb_actualiza_estado.Visible = True
                cmb_actualiza_estado.Enabled = True
                btnGuardarEstado.Visible = True

            Else
                cmb_actualiza_estado.Visible = False
            End If


            If txt_estado_actual.Text = "Revisado" Then

                cmb_actualiza_estado2.Visible = True
                cmb_actualiza_estado2.Enabled = True
                btnGuardarEstado.Visible = True
            Else
                cmb_actualiza_estado2.Visible = False
            End If

            If txt_estado_actual.Text = "Aprobado" Then
                cmb_actualiza_estado3.Visible = True
                cmb_actualiza_estado3.Enabled = True
                btnGuardarEstado.Visible = True
            Else
                cmb_actualiza_estado3.Visible = False
            End If

            If txt_estado_actual.Text = "Actualizado" Then
                btnGuardarEstado.Enabled = False
                cmb_actualiza_estado3.Visible = True
                cmb_actualiza_estado2.Visible = True
                cmb_actualiza_estado.Visible = True

                cmb_actualiza_estado3.Enabled = False
                cmb_actualiza_estado2.Enabled = False
                cmb_actualiza_estado.Enabled = False

                cmb_actualiza_estado3.Text = String.Empty
                cmb_actualiza_estado2.Text = String.Empty
                cmb_actualiza_estado.Text = String.Empty

            Else
                btnGuardarEstado.Enabled = True


                If txt_estado_actual.Text = "Cuadrado" Or txt_estado_actual.Text = "Rechazado" Then
                    cmb_actualiza_estado.Visible = True
                    cmb_actualiza_estado.Enabled = True
                    btnGuardarEstado.Visible = True
                Else
                    cmb_actualiza_estado.Visible = False
                End If
                If txt_estado_actual.Text = "Revisado" Then
                    cmb_actualiza_estado2.Visible = True
                    cmb_actualiza_estado2.Enabled = True
                    btnGuardarEstado.Visible = True
                Else
                    cmb_actualiza_estado2.Visible = False
                End If

                If txt_estado_actual.Text = "Aprobado" Then
                    cmb_actualiza_estado3.Visible = True
                    cmb_actualiza_estado3.Enabled = True
                    btnGuardarEstado.Visible = True
                Else
                    cmb_actualiza_estado3.Visible = False
                End If





            End If
        End If


        Try
            crearDetalleLote()
            generarInfoDetalleLotes()

            llenarPagosTotales()
            generarTotalLote()
            contarRegistros2()

            detalle_pedido(Me.dgv_detalle_recibos.CurrentRow.Index)






        Catch ex As Exception
        Finally

            Me.TabControl1.SelectedTab = Me.TabPage3

        End Try
    End Sub

    Private Sub dgv_encabezado_lote_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgv_encabezado_lote.MouseDoubleClick




    End Sub

    Private Sub dgv_detalle_recibos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_detalle_recibos.CellContentClick

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs)



    End Sub

    Private Sub txt_b_ctacte_LostFocus(sender As Object, e As EventArgs) Handles txt_b_ctacte.LostFocus


        buscarCliente()
        cmb_tipodocto.Enabled = True
        txt_no.Enabled = True
        txt_num_fac.Enabled = True








    End Sub

    Private Sub txt_b_ctacte_TextChanged(sender As Object, e As EventArgs) Handles txt_b_ctacte.TextChanged

    End Sub

    Private Sub txt_lote_1_TextChanged(sender As Object, e As EventArgs) Handles txt_lote_1.TextChanged


    End Sub

    Private Sub txt_num_fac2_TextChanged(sender As Object, e As EventArgs) Handles txt_num_fac2.TextChanged

    End Sub

    Private Sub cmb_tipodocto_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_tipodocto.SelectionChangeCommitted

        'If cmb_tipodocto.Text = "FACE-63-FEA-001" Then ' Or cmb_tipodocto.Text = "FACE-63-FEH-001" Then
        '    txt_num_fac.Visible = True
        '    txt_no.Visible = False

        '    txt_no.Text = " "
        '    txt_num_fac.Text = " "

        '    txt_num_fac.Focus()


        'Else


        '    txt_no.Visible = True
        '    txt_num_fac.Visible = False

        '    txt_no.Text = " "
        '    txt_num_fac.Text = " "
        '    txt_no.Focus()



        'End If
    End Sub


    Private Sub dgv_linea2_Click(sender As Object, e As EventArgs) Handles dgv_linea2.Click
        Try
            Dim nrow As Integer
            nrow = Me.dgv_linea2.CurrentRow.Index()
            txt_monto.Text = Me.dgv_linea2.Item("Monto_Pago", nrow).Value
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txt_suma_final2_TextChanged(sender As Object, e As EventArgs) Handles txt_suma_final2.TextChanged

    End Sub

    Private Sub dgv_linea2_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv_linea2.RowsRemoved
        Try
            txt_suma_final2.Text = Double.Parse(txt_suma_final2.Text) - Double.Parse(txt_monto.Text)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txt_tipoC_TextChanged(sender As Object, e As EventArgs) Handles txt_tipoC.TextChanged

    End Sub

    Private Sub txt_val_resta_TextChanged(sender As Object, e As EventArgs) Handles txt_val_resta.TextChanged

    End Sub

    Private Sub txt_monto_TextChanged(sender As Object, e As EventArgs) Handles txt_monto.TextChanged

    End Sub

    Private Sub btn_cuadrar_Click(sender As Object, e As EventArgs) Handles btn_cuadrar.Click
        If MessageBox.Show("¿Esta seguro de Cuadrar Lote?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            actualizarCuadrado()
            IngresarEstadosLog2()
            txt_lote_dia.Text = String.Empty
            btn_generar_lote.Enabled = True
            btn_cuadrar.Enabled = False
            contarRegistros()

        End If


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmb_actualiza_estado.SelectedIndexChanged

        If cmb_actualiza_estado.Text = "REVISADO" Then
            txt_estado_actualizar.Text = 40
        End If










    End Sub

    Private Sub btnGuardarEstado_Click_1(sender As Object, e As EventArgs) Handles btnGuardarEstado.Click


        If txt_estado_actualizar.Text = 0 Then
            MessageBox.Show("Debe seleccionar Estado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf MessageBox.Show("¿Desea Actualizar Estado?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then

            Dim lbContinuar As Boolean = False
            If txt_estado_actualizar.Text = 40 Then 'Revisado
                If tiene_permisos("mfi_revisarLote") Then

                    lbContinuar = True
                End If
            ElseIf txt_estado_actualizar.Text = 50 Then 'Rechazado
                If tiene_permisos("mfi_rechazarLote") Then
                    lbContinuar = True
                End If
            ElseIf txt_estado_actualizar.Text = 60 Then 'Revisado
                If tiene_permisos("mfi_aprobarLote") Then

                    lbContinuar = True
                End If
            ElseIf txt_estado_actualizar.Text = 70 Then 'Revisado
                If tiene_permisos("mfi_actualizaLote") Then
                    lbContinuar = True
                End If
            End If


            If lbContinuar Then
                actualizarRevisado()
                IngresarEstadosLog3()
                crearDetalleLote()
                generarInfoDetalleLotes()
                llenarPagosTotales()
                generarTotalLote()
            End If



        End If




    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_2(sender As Object, e As EventArgs) Handles cmb_actualiza_estado2.SelectedIndexChanged

        If cmb_actualiza_estado2.Text = "RECHAZADO" Then
            txt_estado_actualizar.Text = 50
        End If

        If cmb_actualiza_estado2.Text = "APROBADO" Then
            txt_estado_actualizar.Text = 60
        End If


    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_actualiza_estado3.SelectedIndexChanged



        If cmb_actualiza_estado3.Text = "ACTUALIZADO" Then

            txt_estado_actualizar.Text = 70
        End If



    End Sub

    Private Sub Exportar_reporte(slLote As String)
        Dim path_reporte As String
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String


        Dim nrow, npedido As Integer
        Dim pm_conexion(2) As String
        Dim ClsGen As New ClasesGenerales.General

        Try
            pm_conexion = ClsGen.Parametros_Conexion("vdataserver")
            'pm_conexion(0) = "VDATASERVER"

            'pm_conexion(1) = "SCM"
            'pm_conexion(2) = "flexline"
            'pm_conexion(3) = "flexline"


            path_reporte = ClsGen.Path_Reporte()

            path_reporte += "Finanzas\Facturacion\Reporte Recibos Lotes.rpt"
            pm_parametros(0) = "@empresa"
            pm_valores(0) = gs_empresa
            pm_parametros(1) = "@lote"
            pm_valores(1) = slLote


            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                          pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                          False, False, "PDF", True, "", True, 1)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_validar_Click(sender As Object, e As EventArgs) Handles btn_validar.Click
        Exportar_reporte(Me.txt_lote_dia.Text.Trim)

    End Sub

    Private Sub Button1_Click_4(sender As Object, e As EventArgs) Handles Button1.Click
        limpiarFin()
        limpiar2()
        borrar()
        limpiarcampos()
        txt_cobrado.Text = 0
        txt_diferencia.Text = 0
        txt_valorR.Enabled = True
        txt_b_ctacte.Enabled = False
        cmb_tipodocto.Enabled = False
        txt_no.Enabled = False
        txt_num_fac.Enabled = False
        txt_sm_valida.Text = 0
        txt_suma_final.Text = 0
        txtPago.Text = String.Empty
    End Sub

    Private Sub txt_sm_valida_TextChanged(sender As Object, e As EventArgs) Handles txt_sm_valida.TextChanged

    End Sub

    Private Sub txt_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnReimpresionLote_Click(sender As Object, e As EventArgs) Handles btnReimpresionLote.Click
        Exportar_reporte(Me.txt_lote_1.Text.Trim)

    End Sub


End Class