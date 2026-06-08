Imports System.Management
Imports System.IO
Imports System.Net
Imports Microsoft.Office.Interop
Imports System.Text

Public Class frmLiquidacionCaja
    Dim dtliquidacion As DataTable
    Dim dtTotales As DataTable
    Dim dtDetalle As DataTable
    Dim dtResumen As DataTable
    Dim dt_pendientes As DataTable
    Dim paginatab As Integer

    Private Sub buscarguia_piloto_1(psfiltro As String)

        Dim clsGen As New ClasesGenerales.General

        Try

            dtTotales = clsGen.selectQuery("FlexLine", "pa_um_liquidacion_cuadre_piloto_1 '" & Me.txtGuia.Text & "','" & psfiltro & "'")
            Me.dgvTotales.DataSource = dtTotales
            clsGen.Alinear_GridView(dtTotales, Me.dgvTotales, ",codigopago,total,cantidad,", ",id,filtro,", "", "", "", "", "", True, True, 250, 0)
            For Each dr As DataRow In dtTotales.Rows
                If dr.Item("codigopago").ToString.ToLower.Equals("total") Then
                    With dr
                        Me.txtPiloto.Text = .Item("piloto").ToString
                        Me.txtRuta.Text = .Item("ruta").ToString
                        Me.txtVehiculo.Text = .Item("vehiculo").ToString
                        Me.txtMonto.Text = .Item("total")
                        Me.txtMontoGuia2.Text = .Item("total")
                        Me.txtDoctos.Text = .Item("cantidad")
                        Me.dtpFechaGuia.Value = .Item("Fecha")
                    End With


                End If
            Next



        Catch ex As Exception




        End Try

    End Sub

    Private Sub buscarguia()
        Dim dt, dtMotivo, dtFormaPago, dtBanco As DataTable
        Dim clsGen As New ClasesGenerales.General

        'Try
        '    limpiarForma()
        '    Me.txtGuia.Text = Me.txtGuia.Text.PadLeft(10, "0")

        'buscarguia_piloto_1("")

        'dtTotales = clsGen.selectQuery("FlexLine", "pa_um_liquidacion_cuadre_piloto_1 '" & Me.txtGuia.Text & "',''")
        'Me.dgvTotales.DataSource = dtTotales
        'clsGen.Alinear_GridView(dtTotales, Me.dgvTotales, ",codigopago,total,cantidad,", ",id,filtro,", "", "", "", "", "", True, True, 250, 0)
        'For Each dr As DataRow In dtTotales.Rows
        '    If dr.Item("codigopago").ToString.ToLower.Equals("total") Then
        '        With dr
        '            Me.txtPiloto.Text = .Item("piloto").ToString
        '            Me.txtRuta.Text = .Item("ruta").ToString
        '            Me.txtVehiculo.Text = .Item("vehiculo").ToString
        '            Me.txtMonto.Text = .Item("total")
        '            Me.txtMontoGuia2.Text = .Item("total")
        '            Me.txtDoctos.Text = .Item("cantidad")
        '            Me.dtpFechaGuia.Value = .Item("Fecha")
        '        End With


        '    End If
        'Next



        'Catch ex As Exception

        'End Try


        Try
            dtDetalle = clsGen.selectQuery("FlexLine", "pa_um_liquidacion_cuadre_piloto_2 '" & Me.txtGuia.Text & "'")
            Me.dgvDetalle.DataSource = dtDetalle

            clsGen.Alinear_GridView(dtDetalle, Me.dgvDetalle, "", ",id,filtro,", "", "", "", "", "", True, True, 250, 0)
            For Each dr As DataRow In dtDetalle.Rows
                If Not dr.Item("empresa").ToString.Equals("------") Then
                    dr.Item("codigopago") = String.Empty
                Else
                    dr.Item("tipodocto") = "TOTAL " & dr.Item("codigopago")
                End If
            Next


        Catch ex As Exception

        End Try

        Try
            '   se cambia el detalle de resumen para que sirva para la entrega de guia a cajero
            '   ------------------------------------------------------------------------------
            Me.TabControl1.SelectedTab = Me.TabPage2
            dtResumen = clsGen.selectQuery("FlexLine", "pa_um_liquidacion_cuadre_piloto_3 '" & Me.txtGuia.Text & "'")
            Me.dgvResumen.DataSource = dtResumen


            clsGen.Alinear_GridView(dtResumen, Me.dgvResumen, "", ",id,filtro,fecha_guia,", ",documentos,empresa,codigopago,total,diferencia,documentosrec,piloto,usuario,fechagrabo,", "", "", "", "", True, True, 250, 0)


            Me.dgvResumen.Columns(2).ReadOnly = True    '   cantidad de documentos
            Me.dgvResumen.Columns(9).ReadOnly = True    '   usuario grabo
            Me.dgvResumen.Columns(10).ReadOnly = True   '   fecha grabo

        Catch ex As Exception

        End Try


        Try
            Me.TabControl1.SelectedTab = Me.TabPage3
            Me.dgvLiquidacion.DataSource = Nothing

            dtliquidacion = clsGen.selectQuery("FlexLine", "pa_um_liquidacion_cuadre_piloto_4 '" & Me.txtGuia.Text & "'")
            Me.dgvLiquidacion.DataSource = dtliquidacion


            'If dtliquidacion.Rows.Item("motivo_ajuste").ToString = Nothing And dtliquidacion.Rows.Item("forma_pago").ToString = Nothing Then
            '    MsgBox("Pare Aca")
            'End If


            dtMotivo = clsGen.selectQuery("FlexLine", "pa_var_um_motivo_ajuste_devolucion")
            dtFormaPago = clsGen.selectQuery("FlexLine", "pa_var_um_forma_pago")
            dtBanco = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod  NULL,'analisisctacte23','" & gs_empresa & "'")



            Dim cbformapago As New DataGridViewComboBoxColumn

            cbformapago.DataSource = dtFormaPago
            cbformapago.ValueMember = "forma_pago"
            cbformapago.DisplayMember = "forma_pago"
            cbformapago.HeaderText = "Forma Pago"
            cbformapago.DataPropertyName = "forma_pago"
            cbformapago.Name = "forma_pago"


            Dim cbColumn As New DataGridViewComboBoxColumn

            cbColumn.DataSource = dtMotivo
            cbColumn.ValueMember = "motivo_ajuste"
            cbColumn.DisplayMember = "motivo_ajuste"
            cbColumn.HeaderText = "Motivo Ajuste"
            cbColumn.DataPropertyName = "motivo_ajuste"
            cbColumn.Name = "motivo_ajuste"


            Dim cbBanco As New DataGridViewComboBoxColumn

            cbBanco.DataSource = dtBanco
            cbBanco.ValueMember = "DESCRIPCION"
            cbBanco.DisplayMember = "DESCRIPCION"
            cbBanco.HeaderText = "Banco"
            cbBanco.DataPropertyName = "Banco"
            cbBanco.Name = "Banco"



            'Add Values 
            'For value As Integer = 0 To 5
            '    cbColumn.Items.Add("Value = " & value.ToString)
            'Next

            'Add ComboBox 
            'dgvLiquidacion.Columns.Add(cbColumn)

            'Me.dgvLiquidacion.DataSource = dt  
            clsGen.Alinear_GridViewEnteros = "recibo"
            clsGen.Alinear_GridViewComboBox3(cbBanco)
            clsGen.Alinear_GridViewComboBox2(cbColumn)
            clsGen.Alinear_GridViewComboBox(cbformapago)
            clsGen.Alinear_GridView(dtliquidacion, Me.dgvLiquidacion, "", ",id,filtro,", ",empresa,tipodocto,numero,fecha,condigopago,cliente,razonsocial,total,total_recibido,forma_pago,motivo_ajuste,usuario,fecha_grabo,", "", "", ",forma_pago=140,motivo_ajuste=140,banco=140,", "", True, True, 250, 75)
            totalizarRecibido()


            '   PENDIENTES
            Try
                Dim opcion As String

                tipo_pendientes()


                If lbl_opcion.Text = "G" Then
                    opcion = txtGuia.Text

                ElseIf lbl_opcion.Text = "U" Then
                    opcion = gs_usuario
                Else
                    opcion = "todas"

                End If

                Me.TabControl1.SelectedTab = Me.TabPage4
                Me.dgv_pendientes.DataSource = Nothing

                dt_pendientes = clsGen.selectQuery("FlexLine", "pa_sel_um_liquidacion_pendiente '" & opcion & "','" & lbl_opcion.Text & "'")
                Me.dgv_pendientes.DataSource = dt_pendientes


                dtMotivo = clsGen.selectQuery("FlexLine", "pa_var_um_motivo_ajuste_devolucion")
                dtFormaPago = clsGen.selectQuery("FlexLine", "pa_var_um_forma_pago")
                dtBanco = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod  NULL,'analisisctacte23','" & gs_empresa & "'")

                Dim cbformapago2 As New DataGridViewComboBoxColumn

                cbformapago2.DataSource = dtFormaPago
                cbformapago2.ValueMember = "forma_pago"
                cbformapago2.DisplayMember = "forma_pago"
                cbformapago2.HeaderText = "Forma Pago"
                cbformapago2.DataPropertyName = "forma_pago"
                cbformapago2.Name = "forma_pago"


                Dim cbColumn2 As New DataGridViewComboBoxColumn

                cbColumn2.DataSource = dtMotivo
                cbColumn2.ValueMember = "motivo_ajuste"
                cbColumn2.DisplayMember = "motivo_ajuste"
                cbColumn2.HeaderText = "Motivo Ajuste"
                cbColumn2.DataPropertyName = "motivo_ajuste"
                cbColumn.Name = "motivo_ajuste"


                Dim cbBanco2 As New DataGridViewComboBoxColumn

                cbBanco2.DataSource = dtBanco
                cbBanco2.ValueMember = "DESCRIPCION"
                cbBanco2.DisplayMember = "DESCRIPCION"
                cbBanco2.HeaderText = "Banco"
                cbBanco2.DataPropertyName = "Banco"
                cbBanco2.Name = "Banco"

                clsGen.Alinear_GridViewEnteros = "recibo"
                clsGen.Alinear_GridViewComboBox3(cbBanco2)
                clsGen.Alinear_GridViewComboBox2(cbColumn2)
                clsGen.Alinear_GridViewComboBox(cbformapago2)
                clsGen.Alinear_GridView(dt_pendientes, Me.dgv_pendientes, "", ",filtro,", ",id,empresa,tipodocto,numero,fecha,condigopago,cliente,razonsocial,total,total_recibido,forma_pago,motivo_ajuste,usuario,fecha_grabo,", "", "", ",forma_pago=140,motivo_ajuste=140,banco=140,", "", True, True, 250, 75)
                '                totalizarRecibido()



            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try



        'Try
        '    If tiene_permisos("mfi_cr_liquidacion_credito") Then
        '        Me.chkFiltro.SetItemChecked(0, True)
        '    End If

        '    If tiene_permisos("mfi_cr_liquidacion_contado") Then
        '        Me.chkFiltro.SetItemChecked(1, True)
        '    End If

        'Catch ex As Exception

        'End Try
        Me.TabControl1.SelectedTab = Me.TabPage1

        ' aplicarfiltro()

    End Sub

    Private Sub tipo_pendientes()

        Dim message, title, defaultValue As String
        Dim myValue As Object

        ' Establecer mensaje.
        message = "Numero de Guia[G] / Usuario[U] / Todas [T]?"

        ' Establecer título.
        title = "Visualizar Documentos Pendientes Por:"

        ' Establecer valor predeterminado.
        defaultValue = "G"

        ' Mostrar mensaje, título y valor predeterminado.
        myValue = InputBox(message, title, defaultValue)

        ' Si el usuario ha hecho clic en Cancelar, establecer myValue en defaultValue
        If myValue Is "" Then myValue = defaultValue
        lbl_opcion.Text = myValue

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        chkb_opera_recibos.Checked = True
        Generar()

    End Sub


    Private Sub GenerarAvisodeRecepcion(psCuentaCorreoUsuario As String, pdrPreliquidacion As DataRow)
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General


        Try



            dt = clsGen.Fecha_Servidor("FlexLine")
            'lsSQL = lsSQL & "Fecha :" & dt.Rows(0).Item("Fecha_Actual") & "'"
            'ClsGen.insertQuery("RegionalDBintOut", lsSQL)

            Dim varMotivo As String = "Recepcion PreLiquidacion Piloto"
            Dim varMensajeAEnviar As String = "No. Guia " & Me.txtGuia.Text & "|" &
                "Fecha Guia : " & Me.dtpFechaGuia.Value & "|" &
                "Piloto     : " & Me.txtPiloto.Text & "|" &
                "Ruta       : " & Me.txtRuta.Text & "|" &
                "Vehiculo   : " & Me.txtVehiculo.Text & "|"

            Try
                varMensajeAEnviar &= "Preliquida : " & pdrPreliquidacion.Item("fechaCreacion") & "|"
            Catch ex As Exception

            End Try

            varMensajeAEnviar &= "Recibida Por : " & gs_nombre_usuario & "|" &
                "En Equipo : " & gs_nombre_equipo & "|" &
                "Fecha : " & clsGen.Fecha_Servidor("FlexLine").Rows(0).Item(0) & "|" '&


            Try

            Catch ex As Exception

            End Try

            '"Numero de Intentos : " & liIntentosFallidos & "|" & "Fecha :" & dt.Rows(0).Item("Fecha_Actual") & "| **** IMPORTANTE *** Si usted no realizó esta acción, comuniquese con Informatica y Tecnologia"

            System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2
            Dim request As WebRequest
            'request = WebRequest.Create("https://prod-104.westus.logic.azure.com:443/workflows/69578584d24848b086a7c919d4e0ecee/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=FaR-fLzV2fSMPPC3V37cMpbTpN593jqCJI9mY4W_Um8")

            request = WebRequest.Create("https://prod-126.westus.logic.azure.com:443/workflows/088f16a4366242fd8b9ada9a1606672d/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=dRClJKvja9MDGmRM5w94hvNSzgvGsSvD-zrK6lPU9lc")
            Dim response As WebResponse
            Dim postData As String = "
            {
              ""Correo"": """ & psCuentaCorreoUsuario & """,
              ""Motivo"": """ & varMotivo & """,
              ""Mensaje_a_enviar"": """ & varMensajeAEnviar & """
            }"
            Dim data As Byte() = Encoding.UTF8.GetBytes(postData)
            request.Method = "POST"
            request.ContentType = "application/json"
            request.ContentLength = data.Length
            Dim stream As Stream = request.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()
            response = request.GetResponse()
            Dim sr As New StreamReader(response.GetResponseStream())
        Catch ex As Exception

        End Try
    End Sub



    Private Sub validarpreliquidacion()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            lsSQL = "pa_sel_um_pwa_pre_liquidacion_transporte '" & Me.txtGuia.Text & "'"
            dt = clsGen.selectQuery("RegionalDBintOut", lsSQL)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("estado") = 0 Then
                    lsSQL = "pa_upd_um_pwa_pre_liquidacion_transporte '" & Me.txtGuia.Text & "',1,'" & gs_usuario & "'"
                    clsGen.insertQuery("RegionalDBintOut", lsSQL)
                    GenerarAvisodeRecepcion(dt.Rows(0).Item("cuenta_office"), dt.Rows(0)) 'Aviso a quien grabo la preliquidacion
                    GenerarAvisodeRecepcion(gs_cuenta_usuario, dt.Rows(0)) 'Aviso a quien grabo

                    Try
                        For Each scorreo As String In clsGen.Obtener_XMLConfig("usuarios_preliquidacion", False).ToString.Split(",")
                            GenerarAvisodeRecepcion(scorreo, dt.Rows(0))
                        Next


                    Catch ex As Exception

                    End Try



                    MessageBox.Show("Preliquidacion Aceptada", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub


    Private Sub Generar()

        '(c) 20241907 Validar preliquidacion

        Try
            limpiarForma()
            Me.txtGuia.Text = Me.txtGuia.Text.PadLeft(10, "0")

            buscarguia_piloto_1("")

            'dtTotales = clsGen.selectQuery("FlexLine", "pa_um_liquidacion_cuadre_piloto_1 '" & Me.txtGuia.Text & "',''")
            'Me.dgvTotales.DataSource = dtTotales
            'clsGen.Alinear_GridView(dtTotales, Me.dgvTotales, ",codigopago,total,cantidad,", ",id,filtro,", "", "", "", "", "", True, True, 250, 0)
            'For Each dr As DataRow In dtTotales.Rows
            '    If dr.Item("codigopago").ToString.ToLower.Equals("total") Then
            '        With dr
            '            Me.txtPiloto.Text = .Item("piloto").ToString
            '            Me.txtRuta.Text = .Item("ruta").ToString
            '            Me.txtVehiculo.Text = .Item("vehiculo").ToString
            '            Me.txtMonto.Text = .Item("total")
            '            Me.txtMontoGuia2.Text = .Item("total")
            '            Me.txtDoctos.Text = .Item("cantidad")
            '            Me.dtpFechaGuia.Value = .Item("Fecha")
            '        End With


            '    End If
            'Next



        Catch ex As Exception

        End Try

        validarpreliquidacion()
        buscarguia()
        busca_guia_liquidada()

    End Sub

    Private Sub busca_guia_liquidada()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            Otrans.open()

            lsSQL = "select * from scm.flexline.liquidacion_muestra_cuadre_3 where id='" & txtGuia.Text & "'"
            dt = Otrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then

                btnGuardarResumen.Enabled = False

                If dt.Rows(0).Item("fecha_grabo") <> "01/01/1900" Then
                    btnGuardarResumen.Enabled = False
                Else
                    btnGuardarResumen.Enabled = True
                End If


                lsSQL = "select * from scm.flexline.liquidacion_muestra_cuadre_4 where id='" & txtGuia.Text & "'"
                dt = Otrans.Obtiene(lsSQL)

                If dt.Rows.Count > 0 Then
                    'btn_guardar.Enabled = True
                    Me.btn_guardar.Text = "Actualizar"
                    btn_guardar.Enabled = False
                    btnGuardarResumen.Enabled = False
                Else
                    btn_guardar.Enabled = True

                End If
            Else

                lsSQL = "select * from scm.flexline.liquidacion_muestra_cuadre_4 where id='" & txtGuia.Text & "'"
                dt = Otrans.Obtiene(lsSQL)

                If dt.Rows.Count > 0 Then
                    Me.btn_guardar.Text = "Actualizar"

                    btn_guardar.Enabled = False
                    'btn_guardar.Enabled = True
                    btnGuardarResumen.Enabled = False
                End If

                btnGuardarResumen.Enabled = True
                btn_guardar.Enabled = False

            End If


        Catch ex As Exception

        End Try



    End Sub

    Private Sub dgvDetalle_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvDetalle.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvDetalle.Rows(rowIndex)

                'If dgv_detalle.Columns(colIndex).Name.ToLower.IndexOf("cantidad") > -1 Then
                'If Me.dgv_detalle.Item("cantidadasignada", rowIndex).Value.ToString = 0 Then
                'Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                'ElseIf Me.dgv_detalle.Item("cantidad", rowIndex).Value.ToString <> Me.dgv_detalle.Item("cantidadasignada", rowIndex).Value.ToString Then
                'Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Chocolate
                'End If
                If Me.dgvDetalle.Item("empresa", rowIndex).Value.ToString.ToLower.Equals("------") Then
                    Me.dgvDetalle.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGray

                End If
                'End If


            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub txtMonto_TextChanged(sender As Object, e As EventArgs) Handles txtMonto.TextChanged
        txtMonto.Text = Format(Convert.ToDecimal(txtMonto.Text), "###,###,##0.00").ToString
    End Sub

    Private Sub txtDoctos_TextChanged(sender As Object, e As EventArgs) Handles txtDoctos.TextChanged
        txtDoctos.Text = Format(Convert.ToDecimal(txtDoctos.Text), "###,###,##0").ToString
    End Sub

    Private Sub dgvTotales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTotales.CellContentClick

    End Sub

    Private Sub dgvTotales_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvTotales.CellPainting


        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvTotales.Rows(rowIndex)

                'If dgv_detalle.Columns(colIndex).Name.ToLower.IndexOf("cantidad") > -1 Then
                'If Me.dgv_detalle.Item("cantidadasignada", rowIndex).Value.ToString = 0 Then
                'Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                'ElseIf Me.dgv_detalle.Item("cantidad", rowIndex).Value.ToString <> Me.dgv_detalle.Item("cantidadasignada", rowIndex).Value.ToString Then
                'Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Chocolate
                'End If
                If Me.dgvTotales.Item("codigopago", rowIndex).Value.ToString.ToLower.Equals("total") Then
                    Me.dgvTotales.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGray

                End If
                'End If


            End If

        Catch ex As Exception
        End Try
    End Sub



    Private Sub dgvResumen_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvResumen.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvResumen.Rows(rowIndex)

                'If dgv_detalle.Columns(colIndex).Name.ToLower.IndexOf("cantidad") > -1 Then
                'If Me.dgv_detalle.Item("cantidadasignada", rowIndex).Value.ToString = 0 Then
                'Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                'ElseIf Me.dgv_detalle.Item("cantidad", rowIndex).Value.ToString <> Me.dgv_detalle.Item("cantidadasignada", rowIndex).Value.ToString Then
                'Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Chocolate
                'End If
                If Me.dgvResumen.Item("codigopago", rowIndex).Value.ToString.ToLower.Equals("total") Then
                    Me.dgvResumen.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightGray

                End If
                'End If


            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtRecibido_TextChanged(sender As Object, e As EventArgs) Handles txtRecibido.TextChanged
        txtRecibido.Text = Format(Convert.ToDecimal(txtRecibido.Text), "###,###,##0.00").ToString
    End Sub


    Private Sub dgvLiquidacion_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLiquidacion.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex

        'Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then


                '(c) 20160906 Cuando se modifica un transito se deben regenerar las coberturas
                If dgvLiquidacion.Columns(colIndex).Name.ToLower.StartsWith("ajuste") Then

                    If dgvLiquidacion.Item(colIndex, rowIndex).Value < 0 Or dgvLiquidacion.Item(colIndex, rowIndex).Value > dgvLiquidacion.Item("total", rowIndex).Value Then
                        dgvLiquidacion.Item(colIndex, rowIndex).Value = 0
                    End If

                    dgvLiquidacion.Item("total_recibido", rowIndex).Value = dgvLiquidacion.Item("total", rowIndex).Value - dgvLiquidacion.Item("Ajustes", rowIndex).Value
                    totalizarRecibido()

                End If

            End If

            Dim valorcelda As String = dgvLiquidacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
            Dim pemp As String = dgvLiquidacion.Rows(e.RowIndex).Cells("empresa").Value.ToString
            Dim ptipod As String = dgvLiquidacion.Rows(e.RowIndex).Cells("tipodocto").Value.ToString
            Dim pnum As String = dgvLiquidacion.Rows(e.RowIndex).Cells("numero").Value.ToString
            Dim pmon As Double = dgvLiquidacion.Rows(e.RowIndex).Cells("total").Value


            'tipodocto,numero
            If valorcelda = "Formas Multiples" Then

                Dim forma As New frmLiquidacionCajaP
                forma.pEmpresa = pemp
                forma.pTipodocto = ptipod
                forma.pNumero = pnum
                forma.pMonto = pmon
                forma.ShowDialog()
                forma.Dispose()
                forma = Nothing

            End If


        Catch ex As Exception
            '  Escribir_log(ex.ToString)

        End Try
    End Sub

    Private Sub dgvLiquidacion_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvLiquidacion.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvLiquidacion.Rows(rowIndex)

                If dgvLiquidacion.Columns(colIndex).Name.ToLower.StartsWith("total_reci") Then
                    If Me.dgvLiquidacion.Item(colIndex, rowIndex).Value.ToString > -1 Then
                        If Me.dgvLiquidacion.Item(colIndex, rowIndex).Value.Equals(Me.dgvLiquidacion.Item("total", rowIndex).Value) Then
                            Me.dgvLiquidacion.Item(colIndex, rowIndex).Style.BackColor = Color.LightGreen
                        ElseIf Not Me.dgvLiquidacion.Item(colIndex, rowIndex).Value.Equals(Me.dgvLiquidacion.Item("total", rowIndex).Value) Then
                            Me.dgvLiquidacion.Item(colIndex, rowIndex).Style.BackColor = Color.Coral
                        End If
                    End If


                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub totalizarRecibido()
        Try
            Me.txtRecibido.Text = "0"
            Me.txtRecibido.Text = dtliquidacion.Compute("Sum(total_recibido)", "total_recibido>0") - Double.Parse(Me.txtFaltantePiloto.Text)
            Me.txtAjuste.Text = "0"
            Me.txtAjuste.Text = dtliquidacion.Compute("Sum(ajustes)", "ajustes>=0")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtMontoGuia2_TextChanged(sender As Object, e As EventArgs) Handles txtMontoGuia2.TextChanged
        txtMontoGuia2.Text = Format(Convert.ToDecimal(txtMontoGuia2.Text), "###,###,##0.00").ToString
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chkFiltro.SelectedIndexChanged

    End Sub

    Private Sub aplicarfiltro()

        Dim lbcontado As Boolean = vbFalse
        Dim lbcredito As Boolean = vbFalse
        Dim lsfiltro As String = String.Empty

        lbcredito = Me.chkFiltro.GetItemChecked(0)
        lbcontado = Me.chkFiltro.GetItemChecked(1)



        Dim clsgen As New ClasesGenerales.General



        Try
            Me.dtDetalle.DefaultView.RowFilter = ""
            Me.dtliquidacion.DefaultView.RowFilter = ""
            Me.dtResumen.DefaultView.RowFilter = ""
            Me.dtTotales.DefaultView.RowFilter = ""

            If lbcontado And lbcredito Then
                'n0 hago nada
                'Exit Sub
                buscarguia_piloto_1("")
            ElseIf lbcontado Then
                buscarguia_piloto_1("Contado")
                lsfiltro = "filtro like '%cont%' or filtro like '%tran%'"

            ElseIf lbcredito Then
                buscarguia_piloto_1("Credito")
                lsfiltro = "filtro like '%credito%' or filtro like '%Sin%' or filtro like '%cxc%'"


            End If

            Me.dtDetalle.DefaultView.RowFilter = lsfiltro
            Me.dtliquidacion.DefaultView.RowFilter = lsfiltro
            Me.dtResumen.DefaultView.RowFilter = lsfiltro
            'Me.dtTotales.DefaultView.RowFilter = lsfiltro



            Dim ldmontoguifiltro As Double = 0
            Dim ldajustes As Double = 0
            Dim ldrecibido As Double = 0

            For Each drv As DataRowView In dtliquidacion.DefaultView
                ldajustes += drv.Item("ajustes")
                ldrecibido += drv.Item("total_recibido")
                ldmontoguifiltro += drv.Item("total")
            Next

            Me.txtMontoGuia2.Text = ldmontoguifiltro
            Me.txtAjuste.Text = ldajustes
            Me.txtRecibido.Text = ldrecibido

        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmLiquidacionCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkb_opera_recibos.Checked = True
        chkb_pendientes.Checked = True

        'Button1.Enabled = False
        ' btn_imprimir.Enabled = False
        btn_guardar.Enabled = False

        txtGuia.Focus()
    End Sub

    Private Sub btnAplicarFiltro_Click(sender As Object, e As EventArgs) Handles btnAplicarFiltro.Click
        aplicarfiltro()
    End Sub

    Private Sub txtFaltantePiloto_TextChanged(sender As Object, e As EventArgs) Handles txtFaltantePiloto.TextChanged

    End Sub

    Private Sub txtFaltantePiloto_Leave(sender As Object, e As EventArgs) Handles txtFaltantePiloto.Leave
        txtFaltantePiloto.Text = Format(Convert.ToDecimal(txtFaltantePiloto.Text), "###,###,##0.00").ToString
        Me.totalizarRecibido()
    End Sub

    Private Sub dgvResumen_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResumen.CellContentClick

    End Sub

    Private Sub dgvResumen_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResumen.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        'Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then


                '(c) 20160906 Cuando se modifica un transito se deben regenerar las coberturas
                If dgvResumen.Columns(colIndex).Name.ToLower.StartsWith("recibido") Then

                    If dgvResumen.Item(colIndex, rowIndex).Value < 0 Or dgvResumen.Item(colIndex, rowIndex).Value > dgvResumen.Item("total", rowIndex).Value Then

                        dgvResumen.Item(colIndex, rowIndex).Value = 0
                    End If

                    dgvResumen.Item("diferencia", rowIndex).Value = dgvResumen.Item("total", rowIndex).Value - dgvResumen.Item("Recibido", rowIndex).Value

                    totalizarResumen()

                End If
            End If

        Catch ex As Exception
            ' Escribir_log(ex.ToString)

        End Try
    End Sub


    Private Sub totalizarResumen()
        Dim ldtotalDiferencia As Double = 0
        Dim ldtotalRecibido As Double = 0

        Try

            For Each dr As DataRow In dtResumen.Rows
                If Not dr.Item("codigopago").ToString.ToLower.StartsWith("tota") Then
                    ldtotalDiferencia += dr.Item("diferencia")
                    ldtotalRecibido += dr.Item("recibido")
                End If
            Next

            For Each dr As DataRow In dtResumen.Rows
                If dr.Item("codigopago").ToString.ToLower.StartsWith("tota") Then
                    dr.Item("recibido") = ldtotalRecibido
                    dr.Item("diferencia") = ldtotalDiferencia

                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtGuia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGuia.KeyPress
        If e.KeyChar = Chr(13) Then
            'Me.txtGuia.Text = Me.txtGuia.Text.PadLeft(10, "0")
            Try
                limpiarForma()
                Me.txtGuia.Text = Me.txtGuia.Text.PadLeft(10, "0")

                buscarguia_piloto_1("")

            Catch ex As Exception
            End Try

            validarpreliquidacion()

            buscarguia()
            busca_guia_liquidada()
        End If
    End Sub

    Private Sub txtAjuste_TextChanged(sender As Object, e As EventArgs) Handles txtAjuste.TextChanged
        txtAjuste.Text = Format(Convert.ToDecimal(txtAjuste.Text), "###,###,##0.00").ToString
    End Sub

    Private Sub dgvLiquidacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLiquidacion.CellContentClick

    End Sub

    Private Sub dgvLiquidacion_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvLiquidacion.DataError
        MessageBox.Show("Ingreso un Valor Invaldo", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub dgvResumen_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResumen.DataError
        MessageBox.Show("Ingreso un Valor Invaldo", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiarForma()
        Me.txtGuia.Text = String.Empty
    End Sub

    Private Sub limpiarForma()
        Try


            Me.txtAjuste.Text = "0"
            Me.txtDoctos.Text = "0"
            Me.txtFaltantePiloto.Text = "0"
            Me.txtMonto.Text = "0"
            Me.txtMontoGuia2.Text = "0"
            Me.txtPiloto.Text = String.Empty
            Me.txtRecibido.Text = "0"
            Me.txtRuta.Text = String.Empty
            Me.txtVehiculo.Text = String.Empty


            btn_guardar.Enabled = False
            btnGuardarResumen.Enabled = False


            Me.dgvDetalle.DataSource = Nothing
            Me.dgvLiquidacion.DataSource = Nothing
            Me.dgvResumen.DataSource = Nothing
            Me.dgvTotales.DataSource = Nothing
            Me.dgv_pendientes.DataSource = Nothing

            txtFaltantePiloto.Text = Format(Convert.ToDecimal(txtFaltantePiloto.Text), "###,###,##0.00").ToString
        Catch ex As Exception

        End Try



    End Sub

    Private Sub btnGuardarResumen_Click(sender As Object, e As EventArgs) Handles btnGuardarResumen.Click
        If MessageBox.Show("Esta Seguro de Guardar", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarResumen()
        End If
    End Sub

    Private Sub guardarResumen()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Try
            For Each dr As DataRowView In dtResumen.DefaultView
                If Not dr.Item("codigopago").ToString.ToLower.StartsWith("tota") Then
                    If dr.Item("usuario_grabo").ToString.ToLower.Trim.Length = 0 Then
                        'documentos,empresa,codigopago,total,diferencia,documentosrec,piloto,usuario,fechagrabo

                        lsSQL = "pa_ins_um_liquidacion_muestra_cuadre_3 '" &
                        dr.Item("id").ToString & "','" &
                        dr.Item("doctos").ToString & "','" &
                        dr.Item("empresa").ToString & "','" &
                        dr.Item("codigopago").ToString & "'," &
                        dr.Item("total").ToString & "," &
                        dr.Item("recibido").ToString & "," &
                        dr.Item("diferencia").ToString & "," &
                        dr.Item("doctosrec").ToString & ",'" &
                        txtPiloto.Text & "','" &
                        gs_usuario & "'"

                        clsGen.insertQuery("SCM", lsSQL)
                    Else
                        MessageBox.Show("La forma de Pago " & dr.Item("codigopago").ToString & " No se Actualizará, Se grabo previamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

            Next
            If MessageBox.Show("Resumen Almacenado con Exito!!!, Desea Imprimir Reporte", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                imprimirResumen()
            End If

            limpiarForma()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub imprimirResumen()

        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)

        Try


            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("scm")
            Dim ppath_reporte As String = clsGen.Path_Reporte
            '023:

            'ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas codicasa.rpt"

            pm_parametros(0) = "Guia"


            ppath_reporte = clsGen.Path_Reporte
            ppath_reporte = ppath_reporte & "Finanzas\Creditos\Liquidaciones\Liquidacion Piloto Por Guia Resumen.rpt"


            pm_valores(0) = Me.txtGuia.Text

            'formaPago = drv.Item("forma_Pago").ToString

            _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
                    pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                    False, True, "PDF", True, "", True, 2)

            'llenar Linea de Picking




        Catch ex As Exception
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try





    End Sub

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Dim estado As String

        If Me.btn_guardar.Text = "Actualizar" Then
            estado = "Actualizar"
        Else
            estado = "Guardar"

        End If


        If MessageBox.Show("Esta Seguro de " & estado & " ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            btn_guardar.Enabled = False

            If estado = "Guardar" Then
                guardarDetalle()
            Else
                Actualizar_Detalle()
            End If

        End If

    End Sub
    Private Sub prepararAvisoTEAMS(psUsuarios As String, pdr As DataRowView)
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL, lsCorreo As String
        Dim dtCorreo As DataTable

        Try

            Dim varMotivo As String = "** Liquidacion Caja: Documento Pendiente/Reenvio **"

            Dim varMensajeAEnviar As String
            '"Fecha Proceso:" & dt.Rows(0).Item("Fecha_Actual")

            For Each lsUsuario As String In psUsuarios.Split(",")

                lsSQL = "pa_sel_um_sg_usuario_email '" & lsUsuario & "'"
                dtCorreo = clsGen.selectQuery("FlexLine", lsSQL)
                Try


                    lsCorreo = dtCorreo.Rows(0).Item("correo").ToString


                    varMensajeAEnviar = "Empresa: " & pdr.Item("Empresa").ToString & "|" &
                                            "Guia : " & pdr.Item("id").ToString & " Fecha: " & dtpFechaGuia.Text & "|" &
                                            "Piloto : " & Me.txtPiloto.Text & "|" &
                                            "Documento : " & pdr.Item("tipodocto") & " -" & pdr.Item("numero") & "|" &
                                            "Codigo Pago : " & pdr.Item("codigopago").ToString & "|" &
                                            "Motivo Ajuste : " & pdr.Item("motivo_ajuste").ToString & "|"

                    If lsCorreo.Length > 0 Then
                        clsGen.enviarMensajeTeams(lsCorreo, varMotivo, varMensajeAEnviar)
                    End If
                Catch ex As Exception

                End Try
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub btn_guardapendientes_Click(sender As Object, e As EventArgs) Handles btn_guardapendientes.Click

        If MessageBox.Show("Esta Seguro de Guardar Pendientes", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guarda_pendientes()
        End If

    End Sub


    Private Sub crea_lotes_Recibos()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String

        Try
            Otrans.open()

            ls_sql = "pa_in_um_liquidacion_recibo_lote '" & txtGuia.Text & "'"
            Otrans.Obtiene(ls_sql)


            MessageBox.Show("Lote de Recibos creado con Existo.... ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception


        Finally

            Otrans.close()
            Otrans = Nothing
        End Try



    End Sub

    Private Sub guardarDetalle()

        Dim clsGen As New ClasesGenerales.General
        Dim lsUsuariosAvisos As String = clsGen.Obtener_XMLConfig("usuarios_liquidaciones_pendientes", False).ToString
        Dim lsSQL As String
        Dim lsSQL2 As String
        Try
            For Each dr As DataRowView In dtliquidacion.DefaultView

                '   MsgBox(dr.Item("numero").ToString)

                If Not dr.Item("codigopago").ToString.ToLower.StartsWith("tota") Then

                    If dr.Item("usuario").ToString.ToLower.Trim.Length = 0 Then
                        'If dr.Item("motivo_ajuste").ToString = Nothing And dr.Item("motivo_ajuste").ToString = Nothing Then

                        lsSQL = "pa_ins_um_liquidacion_muestra_cuadre_4 '" &
                        dr.Item("id").ToString & "','" &
                        dtpFechaGuia.Text & "','" &
                        dr.Item("empresa").ToString & "','" &
                        dr.Item("tipodocto").ToString & "','" &
                        dr.Item("numero").ToString & "','" &
                        dr.Item("fecha").ToString & "','" &
                        dr.Item("codigopago").ToString & "','" &
                        dr.Item("cliente").ToString & "','" &
                        dr.Item("razonsocial").ToString & "'," &
                        dr.Item("total").ToString & "," &
                        dr.Item("ajustes").ToString & "," &
                        dr.Item("total_recibido").ToString & ",'" &
                        dr.Item("recibo").ToString & "','" &
                        dr.Item("motivo_ajuste").ToString & "','" &
                        dr.Item("forma_pago").ToString & "','" &
                        gs_usuario & "','"


                        If dr.Item("documento").ToString.Length > 20 Then
                            lsSQL += dr.Item("documento").ToString.Substring(0, 20) & "','"
                        Else
                            lsSQL += dr.Item("documento").ToString & "','"
                        End If

                        If dr.Item("banco").ToString.Length > 20 Then
                            lsSQL += dr.Item("banco").ToString.Substring(0, 20) & "'"
                        Else
                            lsSQL += dr.Item("banco").ToString & "'"

                        End If

                        Try
                            If dr.Item("motivo_ajuste").ToString.ToLower = "reenvio" Or dr.Item("forma_pago").ToString.ToLower = "reenvio" Then
                                prepararAvisoTEAMS(lsUsuariosAvisos, dr)
                            End If
                            If dr.Item("motivo_ajuste").ToString.ToLower = "documento pendiente" Or dr.Item("forma_pago").ToString.ToLower = "documento pendiente" Then
                                prepararAvisoTEAMS(lsUsuariosAvisos, dr)
                            End If
                        Catch ex As Exception
                            MsgBox("Problemas al Enviar Mensaje a TEAMS...")
                        End Try



                        clsGen.insertQuery("SCM", lsSQL)


                    Else
                        MessageBox.Show("La forma de Pago " & dr.Item("codigopago").ToString & " No se Actualizará, Se grabo previamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

                If dr.Item("forma_pago").ToString = "Documento Pendiente" Or dr.Item("motivo_ajuste").ToString = "Documento Pendiente" Then

                    lsSQL2 = "pa_ins_um_liquidacion_muestra_cuadre_4_Pendientes '" &
                                            dr.Item("id").ToString & "','" & dtpFechaGuia.Text & "','" &
                                            dr.Item("empresa").ToString & "','" &
                                            dr.Item("tipodocto").ToString & "','" &
                                            dr.Item("numero").ToString & "','" &
                                            dr.Item("fecha").ToString & "','" &
                                            dr.Item("codigopago").ToString & "','" &
                                            dr.Item("cliente").ToString & "','" &
                                            dr.Item("razonsocial").ToString & "'," &
                                            dr.Item("total").ToString & "," &
                                            dr.Item("ajustes").ToString & "," &
                                            dr.Item("total_recibido").ToString & ",'" &
                                            dr.Item("recibo").ToString & "','" &
                                            dr.Item("motivo_ajuste").ToString & "','" &
                                            dr.Item("forma_pago").ToString & "','" &
                                            gs_usuario & "','" &
                                            dr.Item("documento").ToString & "','" &
                                            dr.Item("banco").ToString & "'"
                    clsGen.insertQuery("SCM", lsSQL2)
                End If


            Next
            If MessageBox.Show("Liquidación Almacenada con Exito!!!, Desea Imprimir Reporte", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                imprimirDetalle()
            End If


            If chkb_opera_recibos.Checked = True Then
                crea_lotes_Recibos()
            End If

            limpiarForma()

        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
            MessageBox.Show(ex.Message)
        Finally
            clsGen = Nothing
            chkb_opera_recibos.Checked = False
        End Try



    End Sub

    Private Sub Actualizar_Detalle()
        Dim clsGen As New ClasesGenerales.General
        Dim lsUsuariosAvisos As String = clsGen.Obtener_XMLConfig("usuarios_liquidaciones_pendientes", False).ToString
        Dim lsSQL As String
        Dim lsSQL2 As String
        Try
            For Each dr As DataRowView In dtliquidacion.DefaultView

                If Not dr.Item("codigopago").ToString.ToLower.StartsWith("tota") Then

                    If (dr.Item("motivo_ajuste").ToString = Nothing And dr.Item("motivo_ajuste").ToString = Nothing) Or dr.Item("usuario").ToString = Nothing Then

                        '    MsgBox(dr.Item("numero").ToString)

                        lsSQL = "pa_ins_um_liquidacion_muestra_cuadre_4 '" &
                        dr.Item("id").ToString & "','" &
                        dtpFechaGuia.Text & "','" &
                        dr.Item("empresa").ToString & "','" &
                        dr.Item("tipodocto").ToString & "','" &
                        dr.Item("numero").ToString & "','" &
                        dr.Item("fecha").ToString & "','" &
                        dr.Item("codigopago").ToString & "','" &
                        dr.Item("cliente").ToString & "','" &
                        dr.Item("razonsocial").ToString & "'," &
                        dr.Item("total").ToString & "," &
                        dr.Item("ajustes").ToString & "," &
                        dr.Item("total_recibido").ToString & ",'" &
                        dr.Item("recibo").ToString & "','" &
                        dr.Item("motivo_ajuste").ToString & "','" &
                        dr.Item("forma_pago").ToString & "','" &
                        gs_usuario & "','"


                        If dr.Item("documento").ToString.Length > 20 Then
                            lsSQL += dr.Item("documento").ToString.Substring(0, 20) & "','"
                        Else
                            lsSQL += dr.Item("documento").ToString & "','"
                        End If

                        If dr.Item("banco").ToString.Length > 20 Then
                            lsSQL += dr.Item("banco").ToString.Substring(0, 20) & "'"
                        Else
                            lsSQL += dr.Item("banco").ToString & "'"

                        End If

                        Try
                            If dr.Item("motivo_ajuste").ToString = "Reenvio" Or dr.Item("forma_pago").ToString = "Reenvio" Then
                                prepararAvisoTEAMS(lsUsuariosAvisos, dr)
                            End If
                            If dr.Item("motivo_ajuste").ToString = "Documento Pendiente" Or dr.Item("forma_pago").ToString = "Documento Pendiente" Then
                                prepararAvisoTEAMS(lsUsuariosAvisos, dr)
                            End If
                        Catch ex As Exception
                            MsgBox("Problemas al Enviar Mensaje a TEAMS...")
                        End Try

                        clsGen.insertQuery("SCM", lsSQL)

                    Else
                        MessageBox.Show("La forma de Pago " & dr.Item("codigopago").ToString & " No se Actualizará, Se grabo previamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

                If dr.Item("forma_pago").ToString = "Documento Pendiente" Or dr.Item("motivo_ajuste").ToString = "Documento Pendiente" Then

                    lsSQL2 = "pa_ins_um_liquidacion_muestra_cuadre_4_Pendientes '" &
                                            dr.Item("id").ToString & "','" & dtpFechaGuia.Text & "','" &
                                            dr.Item("empresa").ToString & "','" &
                                            dr.Item("tipodocto").ToString & "','" &
                                            dr.Item("numero").ToString & "','" &
                                            dr.Item("fecha").ToString & "','" &
                                            dr.Item("codigopago").ToString & "','" &
                                            dr.Item("cliente").ToString & "','" &
                                            dr.Item("razonsocial").ToString & "'," &
                                            dr.Item("total").ToString & "," &
                                            dr.Item("ajustes").ToString & "," &
                                            dr.Item("total_recibido").ToString & ",'" &
                                            dr.Item("recibo").ToString & "','" &
                                            dr.Item("motivo_ajuste").ToString & "','" &
                                            dr.Item("forma_pago").ToString & "','" &
                                            gs_usuario & "','" &
                                            dr.Item("documento").ToString & "','" &
                                            dr.Item("banco").ToString & "'"
                    clsGen.insertQuery("SCM", lsSQL2)
                End If

            Next


            If MessageBox.Show("Liquidación Almacenada con Exito!!!, Desea Imprimir Reporte", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                imprimirDetalle()
            End If


            If chkb_opera_recibos.Checked = True Then
                crea_lotes_Recibos()
            End If

            limpiarForma()

        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
            MessageBox.Show(ex.Message)
        Finally
            clsGen = Nothing
            chkb_opera_recibos.Checked = False
        End Try
    End Sub

    Private Sub guarda_pendientes()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try

            For Each dr As DataRowView In dt_pendientes.DefaultView

                If Not dr.Item("codigopago").ToString.ToLower.StartsWith("tota") Then
                    If dr.Item("usuario_grabo").ToString.ToLower.Trim.Length > 0 Then

                        If dr.Item("forma_pago").ToString.Length > 5 Then

                            lsSQL = "pa_upd_um_liquidacion_muestra_cuadre_4 '" &
                   dr.Item("id").ToString & "','" &
                   dr.Item("empresa").ToString & "','" &
                   dr.Item("tipodocto").ToString & "','" &
                   dr.Item("numero").ToString & "','" &
                   dr.Item("codigopago").ToString & "','" &
                   dr.Item("cliente").ToString & "'," &
                   dr.Item("total").ToString & "," &
                   dr.Item("ajustes").ToString & "," &
                   dr.Item("total_recibido").ToString & ",'" &
                   dr.Item("recibo").ToString & "','" &
                   dr.Item("motivo_ajuste").ToString & "','" &
                   dr.Item("forma_pago").ToString & "','" &
                                              gs_usuario & "','"
                            ' dr.Item("documento").ToString & "','" &
                            '  dr.Item("banco").ToString & "','" &


                            If dr.Item("documento").ToString.Length > 20 Then
                                lsSQL += dr.Item("documento").ToString.Substring(0, 20) & "','"
                            Else
                                lsSQL += dr.Item("documento").ToString & "','"
                            End If

                            If dr.Item("banco").ToString.Length > 20 Then
                                lsSQL += dr.Item("banco").ToString.Substring(0, 20) & "'"
                            Else
                                lsSQL += dr.Item("banco").ToString & "'"

                            End If

                            clsGen.insertQuery("SCM", lsSQL)
                        End If

                    Else
                        MessageBox.Show("La forma de Pago " & dr.Item("codigopago").ToString & " No se Actualizará, Se grabo previamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

            Next
            If MessageBox.Show("Pendiente Almacenado con Exito!!!, Desea Imprimir Reporte", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                imprimirDetalle()
            End If


            If chkb_pendientes.Checked = True Then
                crea_lotes_Recibos()
            End If

            Generar()

        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
            MessageBox.Show(ex.Message)
        Finally
            clsGen = Nothing
            chkb_opera_recibos.Checked = False
        End Try


    End Sub

    Private Sub imprimirDetalle()

        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)

        Try


            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("scm")
            Dim ppath_reporte As String = clsGen.Path_Reporte
            '023:

            'ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas codicasa.rpt"

            pm_parametros(0) = "Guia"




            ppath_reporte = clsGen.Path_Reporte
            ppath_reporte = ppath_reporte & "Finanzas\Creditos\Liquidaciones\Liquidacion Piloto Por Guia Detalle.rpt"


            pm_valores(0) = Me.txtGuia.Text

            'formaPago = drv.Item("forma_Pago").ToString

            _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
                    pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                    False, True, "PDF", True, "", True, 1)

            'llenar Linea de Picking




        Catch ex As Exception
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub btn_imprimir_Click(sender As Object, e As EventArgs) Handles btn_imprimir.Click
        'IMPRIME SEGUN TAB

        If txtGuia.Text = "" Then
            Exit Sub
        Else
            If paginatab = 1 Then
                imprimirResumen()
            ElseIf paginatab = 2 Then
                imprimirDetalle()
            End If

        End If
    End Sub

    Private Sub dgvLiquidacion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLiquidacion.CellDoubleClick
        Dim valorcelda As String = dgvLiquidacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString

        'MsgBox(valorcelda)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        paginatab = Me.TabControl1.SelectedIndex
    End Sub

    Private Sub txtGuia_TextChanged(sender As Object, e As EventArgs) Handles txtGuia.TextChanged

    End Sub

    Private Sub txtGuia_QueryAccessibilityHelp(sender As Object, e As QueryAccessibilityHelpEventArgs) Handles txtGuia.QueryAccessibilityHelp

    End Sub
End Class