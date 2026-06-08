Imports System.IO
Imports System.Text

Public Class frmTrackingLote
    Dim ODS As DataSet


    Private Sub crear_Estructura()
        Dim dt = New DataTable("traslado_envio")
        'ods_marca_subtipo = New DataSet

        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(Double)))
        dt.Columns.Add(New DataColumn("doctos", GetType(Double)))
        dt.Columns.Add(New DataColumn("montos", GetType(Double)))
        dt.Columns.Add(New DataColumn("responsable", GetType(String)))
        dt.Columns("numero").Unique = True 'Llave Unica

        'dt.Columns.Add(New DataColumn("Fecha_vencimiento", GetType(String)))
        'dt.Columns.Add(New DataColumn("Marca", GetType(String)))
        'dt.Columns.Add(New DataColumn("Subtipo", GetType(String)))
        'dt.Columns.Add(New DataColumn("Imagen", GetType(String)))

        ODS.Tables.Add(dt)
        Me.dgvTraslado.DataSource = ODS.Tables("traslado_envio")



    End Sub

    Private Sub cargarlotes()
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable



        Try
            lsSQL = "pa_var_um_con_cajas_chicas_resumen '" & gs_empresa & "','" & Me.dtpFechaInicio.Value & "','" & Me.dtpFechaFinal.Value & "'"
            dt = clsGen.selectQuery("SCM", lsSQL)


            Me.dgvEncabezado.DataSource = dt

            lsSQL = "pa_var_um_con_cajas_chicas_detalle '" & gs_empresa & "','" & Me.dtpFechaInicio.Value & "','" & Me.dtpFechaFinal.Value & "'"
            dt = clsGen.selectQuery("SCM", lsSQL)

            clsGen.Alinear_GridView(dt, dgvEncabezado, "", "", "", "", True, True, 200, 0)


            dt.TableName = "detalle"
            If ODS.Tables.Contains("detalle") Then ODS.Tables.Remove("detalle")

            ODS.Tables.Add(dt.Copy)
            Me.dgvDetalle.DataSource = ODS.Tables("detalle")

            clsGen.Alinear_GridView(dt, dgvDetalle, "", "", "", "", True, True, 200, 0)

        Catch ex As Exception
        Finally
            clsGen = Nothing


        End Try


    End Sub


    Private Sub FiltrarDetalle()
        Dim ClsGen As New ClasesGenerales.General

        Try

            Dim nrow As Integer = Me.dgvEncabezado.CurrentRow.Index

            ODS.Tables("detalle").DefaultView.RowFilter = "lote = '" & Me.dgvEncabezado.Item("lote", nrow).Value & "'"


        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

        'Me.Colorear_Grid_detalle(oDataSet.Tables("detalle_pedidos"))
    End Sub
    Private Sub frmTrackingLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ODS = New DataSet
        'Me.dtpFechaInicio.Value = "01/06/2024"

        If gs_empresa = "UMBRAL" Then
            Me.lblMultiple.Text = "SI"
        Else
            Me.lblMultiple.Text = "NO"
        End If

        llenarCombos()
        cargarlotes()
        crear_Estructura()
    End Sub

    Private Sub llenarCombos()
        Me.dtpFechaInicio.Value = Today.AddDays(-7)
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Try
            lsSQL = "pa_sel_um_v_pg_estados 14"
            dt = clsGen.selectQuery("SCM", lsSQL)

            lsSQL = "cod_estado in (-1"

            '
            If tiene_permisos("mfi_con_traslado_lotes_cc_cxp") Then
                lsSQL += ",25"
            End If
            If tiene_permisos("mfi_con_traslado_lotes_cc_tesoreria") Then
                lsSQL += ",35"
            End If
            If tiene_permisos("mfi_con_traslado_lotes_cc_contabilidad") Then
                lsSQL += ",45"
            End If
            If tiene_permisos("mfi_con_operar_lotes_nota_debito") Then
                lsSQL += ",55"
            End If
            lsSQL += ")"
            dt.DefaultView.RowFilter = lsSQL
            Me.cmbSiguientePaso.DataSource = dt
            Me.cmbSiguientePaso.DisplayMember = "estado"
            Me.cmbSiguientePaso.ValueMember = "cod_estado"

        Catch ex As Exception

        End Try
    End Sub


    Private Sub dgvEncabezado_Click(sender As Object, e As EventArgs) Handles dgvEncabezado.Click
        FiltrarDetalle()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        cargarlotes()
    End Sub


    Private Sub buscarLoteTraslado()

        Me.txtDoctosTraslado.Text = ""
        Me.txtMontoTraslado.Text = ""
        Me.txtEstado.Text = ""


        Try
            Dim lsSql As String
            Dim clsGen As New ClasesGenerales.General
            Dim dt As DataTable

            lsSql = "pa_var_um_con_cajas_chicas_resumen_numero '" & gs_empresa & "'," & Me.txtNumeroLoteTraslado.Text & ",'" & Me.lblMultiple.Text & "'"
            dt = clsGen.selectQuery("SCM", lsSql)
            If dt.Rows.Count > 0 Then
                With dt.Rows(0)
                    Me.txtDoctosTraslado.Text = .Item("cantidad_documentos")
                    Me.txtMontoTraslado.Text = .Item("monto")
                    Me.txtEstado.Text = .Item("cod_estado") & "-" & .Item("estado")
                    Me.txtResponsableTraslado.Text = .Item("responsable")
                End With

            End If




        Catch ex As Exception

        End Try


    End Sub

    Private Sub txtNumeroLoteTraslado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroLoteTraslado.KeyPress
        If e.KeyChar = Chr(13) Then
            buscarLoteTraslado()
            Me.btnAgregarTraslado.Focus()
        End If
    End Sub

    Private Sub cmbSiguientePaso_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbSiguientePaso.SelectionChangeCommitted
        Me.cmbSiguientePaso.Enabled = False
    End Sub

    Private Sub agregartraslado()
        Try
            If Me.cmbSiguientePaso.SelectedValue = 25 And Me.txtEstado.Text.Split("-")(0) = 25 Or
            (Me.cmbSiguientePaso.SelectedValue = 35 And Me.txtEstado.Text.Split("-")(0) = 35) Or
            (Me.cmbSiguientePaso.SelectedValue = 45 And Me.txtEstado.Text.Split("-")(0) = 45) Or
            (Me.cmbSiguientePaso.SelectedValue = 55 And Me.txtEstado.Text.Split("-")(0) = 55) Then


                Dim dr_aux As DataRow
                dr_aux = ODS.Tables("traslado_envio").NewRow

                dr_aux.Item("empresa") = gs_empresa
                dr_aux.Item("tipo") = IIf(Me.lblMultiple.Text = "SI", "MULTIPLE", "SIMPLE")
                dr_aux.Item("numero") = Me.txtNumeroLoteTraslado.Text
                dr_aux.Item("doctos") = Me.txtDoctosTraslado.Text
                dr_aux.Item("montos") = Me.txtMontoTraslado.Text
                dr_aux.Item("responsable") = Me.txtResponsableTraslado.Text
                ODS.Tables("traslado_envio").Rows.Add(dr_aux)

                Me.txtDoctosTraslado.Text = String.Empty
                Me.txtMontoTraslado.Text = String.Empty
                Me.txtResponsableTraslado.Text = String.Empty
                Me.txtEstado.Text = String.Empty
                Me.txtNumeroLoteTraslado.Focus()
                Me.txtNumeroLoteTraslado.SelectAll()


            Else
                MessageBox.Show("Este Lote No Aplica Para Traslado", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


            Me.txtCantidadLotes.Text = ODS.Tables("traslado_envio").Rows.Count
            Dim clsGen As New ClasesGenerales.General
            clsGen.Alinear_GridView(ODS.Tables("traslado_envio"), Me.dgvTraslado, "", "", "", "", True, True, 250, 0)
            clsGen = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Verificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub


    Private Sub btnAgregarTraslado_Click(sender As Object, e As EventArgs) Handles btnAgregarTraslado.Click
        agregartraslado()
    End Sub

    Private Sub txtNumeroLoteTraslado_Leave(sender As Object, e As EventArgs) Handles txtNumeroLoteTraslado.Leave
        buscarLoteTraslado()
    End Sub

    Private Sub grabarTraslado()
        Dim correlativo As Integer
        Dim clsgen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            dt = clsgen.selectQuery("SCM", "pa_sel_um_con_cajas_chicas_traslados_correlativo '" & gs_empresa & "'," & Me.cmbSiguientePaso.SelectedValue)

            Me.lblNumeroTraslado.Text = dt.Rows(0).Item("correlativo").ToString

            Try
                lsSQL = "pa_ins_um_con_cajas_chicas_lote_encabezado '" & gs_empresa & "'," & Me.cmbSiguientePaso.SelectedValue & "," & Me.lblNumeroTraslado.Text & ",'" & Me.txtComentariosTraslado.Text & "','" & gs_usuario & "'"
                clsgen.insertQuery("SCM", lsSQL)

                dt = clsgen.selectQuery("SCM", "pa_var_um_con_cajas_chicas_lote_encabezado '" & gs_empresa & "'," & Me.cmbSiguientePaso.SelectedValue & "," & Me.lblNumeroTraslado.Text)
                If dt.Rows.Count = 1 Then
                    correlativo = dt.Rows(0).Item("id")
                End If

                For Each dr As DataRow In ODS.Tables("traslado_envio").Rows
                    lsSQL = "pa_ins_um_con_cajas_chicas_lote_detalle " & correlativo & ",'" & dr.Item("tipo") & "'," & dr.Item("numero") & "," & Me.cmbSiguientePaso.SelectedValue & ",'" & gs_empresa & "','" & gs_usuario & "'"
                    clsgen.insertQuery("SCM", lsSQL)

                    If Me.cmbSiguientePaso.SelectedValue = 55 Then
                        lsSQL = "pa_ins_um_con_CAJA_CHICA_LOG '" & gs_empresa & "'," & dr.Item("numero") & ",'" & dr.Item("tipo") & "'," & Me.cmbSiguientePaso.SelectedValue + 5 & ",'" & gs_usuario & "'"
                        clsgen.insertQuery("SCM", lsSQL)
                    Else



                        lsSQL = "pa_ins_um_con_CAJA_CHICA_LOG '" & gs_empresa & "'," & dr.Item("numero") & ",'" & dr.Item("tipo") & "'," & Me.cmbSiguientePaso.SelectedValue + 2 & ",'" & gs_usuario & "'"
                        clsgen.insertQuery("SCM", lsSQL)
                        lsSQL = "pa_ins_um_con_CAJA_CHICA_LOG '" & gs_empresa & "'," & dr.Item("numero") & ",'" & dr.Item("tipo") & "'," & Me.cmbSiguientePaso.SelectedValue + 3 & ",'" & gs_usuario & "'"
                        clsgen.insertQuery("SCM", lsSQL)
                    End If
                Next

                Dim sCuentaRecepcion As String = String.Empty
                Try

                    If Me.cmbSiguientePaso.SelectedValue = 25 Then
                        sCuentaRecepcion = "jcristobal"
                    End If

                    If Me.cmbSiguientePaso.SelectedValue = 35 Then
                        sCuentaRecepcion = "evivas"
                    End If

                    If Me.cmbSiguientePaso.SelectedValue = 45 Then
                        sCuentaRecepcion = "jcristobal"
                    End If

                Catch ex As Exception

                End Try

                enviarCorreo_html(ODS.Tables("traslado_envio"), "Envio de Lote de Cajas Chicas " & Me.lblNumeroTraslado.Text, Me.lblNumeroTraslado.Text, Me.txtDoctosTraslado.Text, Me.txtComentariosTraslado.Text, sCuentaRecepcion)

                MessageBox.Show("Proceso Finalizado !!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiarTraslado()

            Catch ex As Exception
            Finally

            End Try




        Catch ex As Exception

        End Try

    End Sub

    Private Sub limpiarTraslado()
        Me.lblNumeroTraslado.Text = "0000"
        ODS.Tables("traslado_envio").Rows.Clear()
        Me.txtComentariosTraslado.Text = String.Empty
        Me.cmbSiguientePaso.Enabled = True
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ODS.Tables("traslado_envio").Rows.Count > 0 Then


            If MessageBox.Show("Esta Seguro de Grabar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                grabarTraslado()

            End If
        Else

        End If
    End Sub

    Private Sub llenarRecepcionTraslados()
        Dim lsSQL As String
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General



        Try
            lsSQL = "pa_sel_um_con_cajas_chicas_lote_encabezado '" & Me.dtpDelRecepcionTraslados.Value.ToString("dd/MM/yyyy") & "','" & Me.dtpAlRecepcionTraslados.Value.ToString("dd/MM/yyyy") & "'"
            dt = clsGen.selectQuery("SCM", lsSQL)

            lsSQL = "tipo in (-1"

            If tiene_permisos("Recepcion Lotes Cajas Chicas CxP") Then
                lsSQL += ",25"
            End If

            If tiene_permisos("Recepcion Lotes Cajas Chicas Tesoreria") Then
                lsSQL += ",35"
            End If
            If tiene_permisos("Recepcion Lotes Cajas Chicas a Contabilidad") Then
                lsSQL += ",45"
            End If
            lsSQL += ")"
            dt.DefaultView.RowFilter = lsSQL

            Me.dgvListadoRecepcion.DataSource = dt.DefaultView.ToTable
            clsGen.Alinear_GridView(dt.DefaultView.ToTable, dgvListadoRecepcion, "", ",id,tipo,cod_estado,", "", "", True, True, 200, 0)




            lsSQL = "pa_sel_um_con_cajas_chicas_lote_detalle '" & gs_empresa & "','" & Me.dtpDelRecepcionTraslados.Value.ToString("dd/MM/yyyy") & "','" & Me.dtpAlRecepcionTraslados.Value.ToString("dd/MM/yyyy") & "'"
            dt = clsGen.selectQuery("SCM", lsSQL)

            dt.TableName = "detallerecepcion"
            If ODS.Tables.Contains("detallerecepcion") Then ODS.Tables.Remove("detallerecepcion")

            ODS.Tables.Add(dt.Copy)
            Me.dgvDetalleRecepcion.DataSource = ODS.Tables("detallerecepcion")

            clsGen.Alinear_GridView(dt, dgvDetalleRecepcion, "", "", "", "", True, True, 200, 0)




        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnGenerarRecepcionTraslados_Click(sender As Object, e As EventArgs) Handles btnGenerarRecepcionTraslados.Click
        llenarRecepcionTraslados()
    End Sub

    Private Sub enviarCorreo_html(pdt As DataTable, pSsubject As String, psNumero As String, psTotalDocumentos As String, psComentarios As String, psCuentaUsuarioAviso As String)



        Dim sbBody As New StringBuilder
        Dim clsGen As New ClasesGenerales.General
        Dim sRemitente As String = "notificacion@umbralcorp.com"
        Dim snombreRemitente As String = "Notificaciones Umbral"
        Dim scuentas As String = ""
        Dim sSubject As String = ""

        Dim lsSQL As String

        Try




            Dim iCount As Integer = 0

            sSubject = pSsubject


            sbBody.AppendLine("<table style:'width:100%; cellpadding:0px; cellspacing:0px;'>")

            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")
            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<tr><td colspan='20'>Informe Lotes Cajas Chicas No. " & psNumero & "</td></tr>")
            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")
            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")
            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Enviapo Por </strong></td>")
            sbBody.AppendLine("<td   style='text-align: Left;'>" + gs_nombre_usuario + "</td></tr>")


            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Fecha</strong></td>")
            sbBody.AppendLine("<td  style='text-align: Left;'>" + Today + "</td></tr>")

            sbBody.AppendLine("<td><strong>Equipo</strong></td>")
            sbBody.AppendLine("<td  style='text-align: Left;'>" + gs_nombre_equipo + "</td></tr>")



            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Total Documentos</strong></td>")
            sbBody.AppendLine("<td   style='text-align: Left;'>" + psTotalDocumentos + "</td></tr>")

            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Comentarios</strong></td>")
            sbBody.AppendLine("<td   style='text-align: Left;'>" + psComentarios + "</td></tr>")
            sbBody.AppendLine("<tr>")
            'sbBody.AppendLine("<td><strong>Rechazados</strong></td>")
            'sbBody.AppendLine("<td   style='text-align: Left;'>" + Me.lblpendientes.Text + "</td></tr>")


            'sbBody.AppendLine("<tr>")
            'sbBody.AppendLine("<td><strong>Proveedor</strong></td>")
            'sbBody.AppendLine("<td style='text-align: Left;'>" + Me.txtProveedor.Text + "</td></tr>")


            'sbBody.AppendLine("<tr>")
            'sbBody.AppendLine("<td><strong>Bodega</strong></td>")
            'sbBody.AppendLine("<td  style='text-align: Left;'>" + Me.txtBodega.Text + "</td></tr>")

            'If Me.txtComentario4.Text.Length > 0 Then


            '    sbBody.AppendLine("<tr>")
            '    sbBody.AppendLine("<td><strong>Comentarios</strong></td>")
            '    sbBody.AppendLine("<td  style='text-align: Left;'>" + Me.txtComentario4.Text + "</td></tr>")

            'End If
            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")
            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")




            Try

                Dim dt3 As DataTable
                'If lblOrigen.Text.Equals("TRANSPORTE") Or
                '    lblOrigen.Text.Equals("BODEGA") Or
                '    lblOrigen.Text.Equals("CAJA") Then
                '    scuentas = clsGen.Obtener_XMLConfig("correo_facturacion_GT", False)

                'Else

                lsSQL = "pa_sel_um_sg_usuario_email '" & psCuentaUsuarioAviso & "'"
                dt3 = clsGen.selectQuery("FlexLine", lsSQL)
                If dt3.Rows.Count > 0 Then
                    scuentas = dt3.Rows(0).Item("correo").ToString
                End If
                'End If


                If scuentas.ToString.Length > 0 Then scuentas += ","
                scuentas += gs_cuenta_usuario

                'Correo Auditoria
                'lsSQL = "pa_sel_um_sg_usuario_email 'asaravia'"
                'dt3 = clsGen.selectQuery("FlexLine", lsSQL)
                'If dt3.Rows.Count > 0 Then
                '    If scuentas.ToString.Length > 0 Then scuentas += ","
                '    scuentas += dt3.Rows(0).Item("correo").ToString
                'End If

            Catch ex As Exception

            End Try









            sbBody.AppendLine("<table style:'width:100%; cellpadding:0px; cellspacing:0px;'>")

            sbBody.AppendLine("<tr style='background-color:#560000; color:white;'>")
            sbBody.AppendLine("<td>No.</td><td>empresa</td><td>Lote</td><td>Tipo</td><td>N. Doctos</td><td>Monto</td><td>Responsable</td></tr>")
            iCount = 0

            pdt.DefaultView.Sort = ""
            For Each drLinea As DataRowView In pdt.DefaultView
                iCount += 1

                sbBody.AppendLine("<tr>")
                sbBody.AppendLine("<td>" & iCount & "</td>")


                sbBody.AppendLine("<td>" & gs_empresa & "</td>")
                sbBody.AppendLine("<td>" & drLinea.Item("numero").ToString & "</td>")
                sbBody.AppendLine("<td>" & drLinea.Item("tipo").ToString & "</td>")
                sbBody.AppendLine("<td>" & drLinea.Item("doctos").ToString & "</td>")
                sbBody.AppendLine("<td>" & drLinea.Item("montos").ToString & "</td>")
                sbBody.AppendLine("<td>" & drLinea.Item("responsable").ToString & "</td>")
                sbBody.AppendLine("</tr>")


            Next



            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")
            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")
            sbBody.AppendLine("<tr><td colspan='20'>** NO RESPONDA A ESTE CORREO **</td></tr>")







            clsGen.enviarcorreo_html(scuentas, sSubject, sbBody.ToString, "", "", sRemitente, snombreRemitente)



        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Sub FiltrarDetalleRecepcion()


        Try

            Dim nrow As Integer = Me.dgvListadoRecepcion.CurrentRow.Index

            ODS.Tables("detalleRecepcion").DefaultView.RowFilter = "id = " & Me.dgvListadoRecepcion.Item("id", nrow).Value


        Catch ex As Exception
        Finally


        End Try

        'Me.Colorear_Grid_detalle(oDataSet.Tables("detalle_pedidos"))
    End Sub

    Private Sub dgvListadoRecepcion_Click(sender As Object, e As EventArgs) Handles dgvListadoRecepcion.Click
        FiltrarDetalleRecepcion

    End Sub

    Private Sub btnProcesarRecepcionTraslados_Click(sender As Object, e As EventArgs) Handles btnProcesarRecepcionTraslados.Click




        Try
                Dim nrow As Integer = Me.dgvListadoRecepcion.CurrentRow.Index

            If Me.dgvListadoRecepcion.Item("cod_estado", nrow).Value <> 10 Then
                MessageBox.Show("Este lote ya fue recibido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub

            End If

            If MessageBox.Show("Esta Seguro de Realizar la Recepcion de Este Lote " & Me.dgvListadoRecepcion.Item("numero", nrow).Value, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim lsSQL As String
                Dim clsGen As New ClasesGenerales.General
                Dim dt As DataTable


                Try
                    lsSQL = "pa_var_um_con_cajas_chicas_lote_encabezado_id " & Me.dgvListadoRecepcion.Item("id", nrow).Value
                    dt = clsGen.selectQuery("SCM", lsSQL)
                    If dt.Rows(0).Item("cod_estado") = 10 Then

                        lsSQL = "pa_upd_um_con_cajas_chicas_lote_encabezado_id " & Me.dgvListadoRecepcion.Item("id", nrow).Value & ",20,'" & gs_usuario & "'"
                        clsGen.insertQuery("SCM", lsSQL)



                        For Each drv As DataRowView In ODS.Tables("detalleRecepcion").DefaultView


                            lsSQL = "pa_ins_um_con_CAJA_CHICA_LOG '" & gs_empresa & "'," & drv.Item("numero") & ",'" & drv.Item("tipo") & "'," & Me.dgvListadoRecepcion.Item("tipo", nrow).Value + 5 & ",'" & gs_usuario & "'"
                            clsGen.insertQuery("SCM", lsSQL)
                            lsSQL = "pa_ins_um_con_CAJA_CHICA_LOG '" & gs_empresa & "'," & drv.Item("numero") & ",'" & drv.Item("tipo") & "'," & Me.dgvListadoRecepcion.Item("tipo", nrow).Value + 10 & ",'" & gs_usuario & "'"
                            clsGen.insertQuery("SCM", lsSQL)

                        Next



                        enviarCorreo_html(ODS.Tables("detalleRecepcion"), "Recepcion  de Lote de Cajas Chicas " & Me.dgvListadoRecepcion.Item("numero", nrow).Value,
                                          Me.dgvListadoRecepcion.Item("id", nrow).Value, ODS.Tables("detalleRecepcion").DefaultView.Count, Me.txtComentariosRecepcion.Text,
Me.dgvListadoRecepcion.Item("usuario_grabo", nrow).Value.ToString)

                        MessageBox.Show("Recepción Realizada Exitosamente!!! ", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtComentariosRecepcion.Text = String.Empty
                        llenarRecepcionTraslados()
                    Else

                        MessageBox.Show("El Lote Seleccionado No Se Puede Procesar ", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Catch ex As Exception
                Finally
                    clsGen = Nothing

                End Try





            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtNumeroLoteTraslado_TextChanged(sender As Object, e As EventArgs) Handles txtNumeroLoteTraslado.TextChanged

    End Sub
End Class