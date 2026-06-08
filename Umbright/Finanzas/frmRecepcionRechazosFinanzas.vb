Imports System.IO
Imports System.Text

Public Class frmRecepcionRechazosFinanzas
    Dim dtDevoluciones As DataTable
    Dim dsfel As DataSet

    Private Sub Crear_estructuraFel(ByRef dsFel As DataSet)

        Dim dt As DataTable

        dsFel = New DataSet
        dt = New DataTable("pedidos")
        dt.Columns.Add(New DataColumn("Enviar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("SerieFel", GetType(String)))
        dt.Columns.Add(New DataColumn("NumeroFel", GetType(String)))
        dt.Columns.Add(New DataColumn("Serie", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("correlativo", GetType(String)))
        dt.Columns.Add(New DataColumn("codlegal", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("forma_Pago", GetType(String)))
        dt.Columns.Add(New DataColumn("Bodega", GetType(String)))
        dt.Columns.Add(New DataColumn("PorcDescuento", GetType(Double)))
        dt.Columns.Add(New DataColumn("direccion", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono", GetType(String)))
        dt.Columns.Add(New DataColumn("Total", GetType(String)))
        dt.Columns.Add(New DataColumn("RefTipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("RefCorrelativo", GetType(String)))
        dt.Columns.Add(New DataColumn("RefNumero", GetType(String)))
        dt.Columns.Add(New DataColumn("RefFecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("vigencia", GetType(String)))
        dt.Columns.Add(New DataColumn("exento", GetType(String)))
        dt.Columns.Add(New DataColumn("Comentario", GetType(String)))
        dt.Columns.Add(New DataColumn("Vendedor", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero_Pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero_PedidoWM", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDoctoOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("serieFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("firmaFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("nitFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("direccionFACE", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaFACE", GetType(Date)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("Documento", GetType(String)))
        dt.Columns.Add(New DataColumn("tipodocto", GetType(String)))
        dt.Columns.Add(New DataColumn("procesado", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("MaquinaFace", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ImpresoraFace", GetType(String)))
        dt.Columns.Add(New DataColumn("BodegaInterEmpresas", GetType(String)))  ''(c)290414 Campo para definir la creacion e impresion de Documentos InterEmpresas
        dt.Columns.Add(New DataColumn("Comuna", GetType(String))) '(c)230315 Campo para informacion walmart 
        dt.Columns.Add(New DataColumn("Estado", GetType(String))) '(c)230315 Campo para informacion walmart
        dt.Columns.Add(New DataColumn("Numero_Recepcion_Walmart", GetType(String))) '(c)230315 Campo para informacion walmart
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String))) '(c)20180105 Definir si es B=Bien S=Servicio
        dt.Columns.Add(New DataColumn("moneda", GetType(String))) '(c)20180116 Definir si es B=Bien S=Servicio
        dt.Columns.Add(New DataColumn("tasa", GetType(Double))) '(c)20180116 Definir si es B=Bien S=Servicio
        dt.Columns.Add(New DataColumn("UsuarioModif", GetType(String))) '(c)20190117
        dt.Columns.Add(New DataColumn("F_FLETE", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("F_SEGURO", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("FLETE", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("SEGURO", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Analisis17", GetType(String)))
        dt.Columns.Add(New DataColumn("LisPrecio", GetType(String)))
        dt.Columns.Add(New DataColumn("SerieFace", GetType(String)))
        dt.Columns.Add(New DataColumn("NumeroAutFace", GetType(String)))
        dt.Columns.Add(New DataColumn("FechaFace", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("NoAutFel", GetType(String)))
        dt.Columns.Add(New DataColumn("NoSerieFel", GetType(String)))
        dt.Columns.Add(New DataColumn("ComentarioFace", GetType(String)))

        dsFel.Tables.Add(dt)

    End Sub

    Private Sub llenarCombos()
        Dim clsGen As New ClasesGenerales.General

        Dim dt As DataTable

        dt = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_menu_opcion_empresa_empresa  null,null,'mfi_cr_entrega_devoluciones_creditos'")

        Me.cmbUsuarios.DataSource = dt
        Me.cmbUsuarios.DisplayMember = "nombre"
        Me.cmbUsuarios.ValueMember = "usuario"


        clsGen = Nothing



    End Sub

    Private Sub generarDevolucionesPendientes()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General

        Dim lsSQL As String

        Try
            Otrans.open()
            lsSQL = "pa_var_um_devoluciones_listado '" & Me.dtpInicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtpFinal.Value.ToString("dd/MM/yyyy") & "',100"
            dtDevoluciones = Otrans.Obtiene(lsSQL)
            Me.dgvListado.DataSource = dtDevoluciones
            clsGen.Alinear_GridView(dtDevoluciones, Me.dgvListado, ",empresa,tipodocto,numero,fecha,cliente,nombre_cliente,comentario1,glosa,bodega,", "", "", "", "", "", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        generarDevolucionesPendientes()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            dtDevoluciones.AcceptChanges()
        Catch ex As Exception

        End Try
        If MessageBox.Show("Esta Seguro de Aplicar el Traslado", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.lblNumero.Text = Now.ToString("yyMMddHHmm")
            almacenarTraslado()
        End If

    End Sub

    Private Sub almacenarTraslado()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dtValidacion As DataTable

        Try
            Otrans.open()

            For Each dr As DataRow In dtDevoluciones.Rows
                lsSQL = "pa_ins_gen_log_Traslada_documento '" & Me.lblDestino.Text & "','" & dr.Item("empresa").ToString & "','" &
                    dr.Item("tipodocto").ToString & "','" & dr.Item("numero").ToString & "','" & Me.cmbUsuarios.SelectedValue & "','" & Me.lblNumero.Text & "'"

                Otrans.Ingresa(lsSQL)
                If Otrans.Codigo_error > 0 Then
                    MessageBox.Show("Problemas al Insertar " & dr.Item("numero"), "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                '(c) grabo quien recibe el traslado
                'gs_usuario = "nhernandez"
                lsSQL = "pa_upd_um_Gen_Log_Traslada_Documento '" & dr.Item("Empresa").ToString & "','" & dr.Item("tipodocto").ToString & "','" &
                        dr.Item("numero").ToString & "'," & Me.lblNumero.Text & ",'" & gs_usuario & "',1"

                Otrans.Escribir_Log(lsSQL)
            Next


            Try

                dtDevoluciones.Columns.Add(New DataColumn("nota", GetType(String)))
            Catch ex As Exception

            End Try

            For Each dr As DataRow In dtDevoluciones.Rows
                dr.Item("nota") = String.Empty
                lsSQL = "spa_Convierte_DEVaNC_MULTIEMPRESA '" & dr.Item("empresa").ToString & "','" &
                    dr.Item("tipodocto").ToString & "','" & dr.Item("numero").ToString & "'"
                Otrans.Ingresa(lsSQL)
                'If Otrans.Codigo_error = 0 Then
                Try


                    dtValidacion = clsGen.selectQuery("FlexLine", "pa_var_um_documento '" & dr.Item("empresa").ToString & "','" & dr.Item("tipodocto").ToString & "','" & dr.Item("numero").ToString & "'")
                    If dtValidacion.Rows.Count > 0 Then
                        dr.Item("nota") = dtValidacion.Rows(0).Item("ReferenciaExterna").ToString
                    End If
                Catch ex As Exception

                End Try
                'End If

                '(c) Validar DocumentoP

                lsSQL = "pa_var_um_documentop '" & dr.Item("empresa").ToString & "','NC-FEL-DEVOLUCION','" & dr.Item("nota").ToString & "'"
                dtValidacion = clsGen.selectQuery("FlexLine", lsSQL)

                Try
                    If dtValidacion.Rows.Count = 0 Then
                        lsSQL = "pa_ins_um_documentop_ncfel_dev '" & dr.Item("empresa").ToString & "','" & dr.Item("tipodocto").ToString & "','" & dr.Item("numero").ToString & "','" & dr.Item("nota").ToString & "'"
                        Otrans.Ingresa(lsSQL)

                    Else
                        'MessageBox.Show("Documento ya existe " & dr.Item("numero"), "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Catch ex As Exception

                End Try



            Next


            'Certificar Documentos
            'Validar por empresa

            Dim dtEmpresa As DataTable = clsGen.ValoresDistinto(dtDevoluciones, "empresa".Split(","))
            Dim dtRegistro As DataTable

            Crear_estructuraFel(dsfel)
            Try

                For Each drEmpresa As DataRow In dtEmpresa.Rows

                    Dim psFecha As String = Now.ToString("dd/MM/yyyy")

                    dsfel.Tables("pedidos").Rows.Clear()
                    lsSQL = "pa_sel_um_tipodocto_creditos_FelPura '" & drEmpresa.Item("empresa").ToString & "','" & psFecha & "','" & psFecha & "',0"
                    Otrans = New Transaccional.Conexion("flexline")

                    Try
                        Otrans.open()
                        dtRegistro = Otrans.Obtiene(lsSQL)

                        dtRegistro.DefaultView.RowFilter = "documento like 'credito'"

                        For Each drv As DataRowView In dtRegistro.DefaultView
                            agregarPedidoPendiente(drv.Row, dsfel)
                        Next

                        lsSQL = "pa_var_um_detalle_creditos_FelPURA '" & psFecha & "','" & psFecha & "','" & drEmpresa.Item("empresa").ToString & "'"
                        If dsfel.Tables.Contains("detalle_pedidos") Then
                            dsfel.Tables.Remove(dsfel.Tables.Item("detalle_pedidos"))
                        End If

                        dtRegistro = Otrans.Obtiene(lsSQL)
                        dtRegistro.TableName = "detalle_pedidos"

                        dsfel.Tables.Add(dtRegistro.Copy)
                    Catch ex As Exception
                    Finally

                    End Try


                    Dim lDsFelSel As New DataSet
                    'Dim lDsFelWM As New DataSet
                    Dim lTblPedidos As DataTable = dsfel.Tables("pedidos").Copy()
                    Dim lTblDetPedidos As DataTable = dsfel.Tables("detalle_pedidos").Copy()
                    'Dim lDvFelSel As DataView
                    Dim oEnvioFel As New Umbral.FelInFile.ProcesarFel



                    lDsFelSel.Tables.Add(lTblPedidos.DefaultView.ToTable("pedidos"))
                    lDsFelSel.Tables.Add(lTblDetPedidos)

                    'oEnvioFel.EnviarDteInfile(lDsFelSel, My.Settings.Default.DirFel)

                    ''imprimirFELCreditos(drEmpresa.Item("empresa").ToString, lDsFelSel)
                    'For Each dr As DataRow In lDsFelSel.Tables("pedidos").Rows
                    '    If dr.Item("Enviar") = True Then
                    '        'Actualizar el estado del documento
                    '        lsSQL = "pa_upd_um_devolucion_encabezado_trs '" & dr.Item("empresa").ToString & "','" & dr.Item("tipodocto").ToString & "','" & dr.Item("numero").ToString & "'," & Me.lblNumero.Text & ",'" & gs_usuario & "',1"
                    '        Otrans.Escribir_Log(lsSQL)
                    '    End If

                Next
            Catch ex As Exception

            Finally
            End Try

            enviarCorreo_html(dtDevoluciones)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub imprimirFELCreditos(psEmpresa As String, psTipoDocto As String, psNumero As String)



        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(psEmpresa)
        Oaut.pnNumeroCopias = 1
        Try

            Dim lsDirectorio As String = "c:\temp\" & psEmpresa & "\" & Today.ToString("yyyyMM") & "\" & Today.ToString("ddMMyyyy")


            If Not Directory.Exists(lsDirectorio) Then
                System.IO.Directory.CreateDirectory(lsDirectorio)
            End If

            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("")
            Dim ppath_reporte As String = clsGen.Path_Reporte
            '023:

            'ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas codicasa.rpt"

            pm_parametros(0) = "empresa"
            pm_parametros(1) = "tipodocto"
            pm_parametros(2) = "numero"
            pm_parametros(3) = "user_name"



            'lDsFel.Tables("pedidos").DefaultView.RowFilter = ""
            'For Each drv As DataRowView In lDsFel.Tables("pedidos").DefaultView

            pm_valores(0) = psEmpresa
            pm_valores(1) = psTipoDocto
            pm_valores(2) = psNumero
            pm_valores(3) = gs_usuario

            ppath_reporte = clsGen.Path_Reporte
            ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas "
            If psTipoDocto = "NOTA DE ABONO" Then
                ppath_reporte += psEmpresa.ToLower.Trim + " NABNFEL DIF"
            ElseIf psTipoDocto = "PEDIDO FEL RE" Then
                ppath_reporte += psEmpresa.ToLower.Trim + " FEL"
                pm_valores(1) = "FEL RE"
            ElseIf psTipoDocto.ToString.StartsWith("NC-") Then
                ppath_reporte += psEmpresa.ToLower.Trim + " NCFEL DIF"
            End If

            'ppath_reporte += gs_empresa.ToLower.Trim + " NCFEL DIF"
            'ppath_reporte += drv.Item("serieFACE").ToString.Trim
            ppath_reporte += ".rpt"

            _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
                                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                False, True, "PDF", True, "", True, 1)


            _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
                                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), True, False, "PDF", False,
                                lsDirectorio & "\" & psTipoDocto & "-" & psNumero & ".pdf",
                                False, 1)


            'Next

        Catch ex As Exception
        Finally
            'lDsFel.Tables("pedidos").DefaultView.RowFilter = "tipodocto = '" & dboTipoDocto.SelectedValue & "'"
            Oaut = Nothing
            clsGen = Nothing
        End Try


        'lTblPedidos.ImportRow(lDvFelSel(dr.Index).Row)




    End Sub



    Private Sub enviarCorreo_html(pdt As DataTable)



        Dim sbBody As New StringBuilder
        Dim clsGen As New ClasesGenerales.General
        Dim sRemitente As String = "lgs1@logiservicios.com"
        Dim snombreRemitente As String = "LS1"
        Dim scuentas As String = ""
        Dim sSubject As String = ""

        Dim lsSQL As String

        Try




            Dim iCount As Integer = 0

            sSubject = "Recepción de Devoluciones Lote " & Me.lblNumero.Text


            sbBody.AppendLine("<table style:'width:100%; cellpadding:0px; cellspacing:0px;'>")

            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")
            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<tr><td colspan='20'>Informe de Recepcion de Documentos en " & lblDestino.Text & "</td></tr>")
            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")
            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")
            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Recibido por </strong></td>")
            sbBody.AppendLine("<td   style='text-align: Left;'>" + gs_nombre_usuario + "</td></tr>")


            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Fecha</strong></td>")
            sbBody.AppendLine("<td  style='text-align: Left;'>" + Today + "</td></tr>")

            sbBody.AppendLine("<td><strong>Equipo</strong></td>")
            sbBody.AppendLine("<td  style='text-align: Left;'>" + gs_nombre_equipo + "</td></tr>")



            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Total Documentos Recibidos </strong></td>")
            sbBody.AppendLine("<td   style='text-align: Left;'>" + pdt.Rows.Count.ToString + "</td></tr>")

            'sbBody.AppendLine("<tr>")
            'sbBody.AppendLine("<td><strong>Recibidos</strong></td>")
            'sbBody.AppendLine("<td   style='text-align: Left;'>" + Me.lblRecibidos.Text + "</td></tr>")
            'sbBody.AppendLine("<tr>")
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


                lsSQL = "pa_sel_um_sg_usuario_email '" & cmbUsuarios.SelectedValue & "'"
                dt3 = clsGen.selectQuery("FlexLine", lsSQL)
                If dt3.Rows.Count > 0 Then
                    scuentas = dt3.Rows(0).Item("correo").ToString
                End If



                If scuentas.ToString.Length > 0 Then scuentas += ","
                scuentas += gs_cuenta_usuario


                Try
                    Dim sCorreos As String = clsGen.Obtener_XMLConfig("correo_recepcion_rechazos", False)
                    scuentas += sCorreos
                Catch ex As Exception

                End Try





            Catch ex As Exception

            End Try









            sbBody.AppendLine("<table style:'width:100%; cellpadding:0px; cellspacing:0px;'>")

            sbBody.AppendLine("<tr style='background-color:#560000; color:white;'>")
            sbBody.AppendLine("<td>No.</td><td>empresa</td><td>documento</td><td>Nota</td><td>cliente</td></tr>")
            iCount = 0

            pdt.DefaultView.Sort = "empresa, numero"
            For Each drLinea As DataRowView In pdt.DefaultView
                iCount += 1

                sbBody.AppendLine("<tr>")
                sbBody.AppendLine("<td>" & iCount & "</td>")


                sbBody.AppendLine("<td>" & drLinea.Item("empresa").ToString & "</td>")
                sbBody.AppendLine("<td>" & drLinea.Item("tipodocto").ToString & "-" & drLinea.Item("numero").ToString & "</td>")
                sbBody.AppendLine("<td>" & drLinea.Item("nota").ToString & "</td>")
                sbBody.AppendLine("<td>" & drLinea.Item("nombre_cliente").ToString & "</td>")
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

    Private Sub agregarPedidoPendiente(dr As DataRow, ByRef odsFACE As DataSet)

        Dim dr_aux As DataRow = odsFACE.Tables("pedidos").NewRow

        Try
            dr_aux.Item("Enviar") = 0
            If dr.Item("fechaenvio") = "01/01/1900" Then dr_aux.Item("Enviar") = 1
        Catch ex As Exception

        End Try

        dr_aux.Item("serie") = dr.Item("serie")
        dr_aux.Item("SerieFel") = dr.Item("SerieFel")
        dr_aux.Item("NumeroFel") = dr.Item("NumeroFel")
        dr_aux.Item("documento") = dr.Item("documento")
        dr_aux.Item("empresa") = dr.Item("empresa")
        dr_aux.Item("tipodocto") = dr.Item("tipodocto")
        dr_aux.Item("correlativo") = dr.Item("correlativo")
        dr_aux.Item("numero") = dr.Item("numero")
        dr_aux.Item("fecha") = dr.Item("fecha")
        dr_aux.Item("codlegal") = dr.Item("codlegal")
        dr_aux.Item("ctacte") = dr.Item("ctacte")
        dr_aux.Item("nombre_cliente") = dr.Item("nombre_cliente")
        dr_aux.Item("direccion") = dr.Item("direccion")
        dr_aux.Item("telefono") = dr.Item("telefono")
        dr_aux.Item("RefTipoDocto") = dr.Item("RefTipoDocto")
        dr_aux.Item("RefCorrelativo") = dr.Item("RefCorrelativo")
        dr_aux.Item("RefNumero") = dr.Item("NumeroRef")
        dr_aux.Item("RefFecha") = dr.Item("fechaRef")
        dr_aux.Item("vigencia") = dr.Item("vigencia")
        dr_aux.Item("exento") = dr.Item("exento")
        dr_aux.Item("PorcDescuento") = dr.Item("PorcDescuento")
        dr_aux.Item("comentario") = dr.Item("comentario")
        dr_aux.Item("Bodega") = dr.Item("bodega")
        dr_aux.Item("Vendedor") = dr.Item("vendedor")
        dr_aux.Item("Numero_Pedido") = dr.Item("numero_pedido")
        dr_aux.Item("Numero_PedidoWM") = dr.Item("numero_pedidoWM")
        dr_aux.Item("TipoDoctoOrigen") = dr.Item("TipoDoctoOrigen")
        dr_aux.Item("forma_pago") = dr.Item("codigoPago")
        dr_aux.Item("ComentarioFace") = dr.Item("ComentarioFACE")
        dr_aux.Item("LisPrecio") = dr.Item("ListaPrecio")

        'Cuando la facturacion sea en dolares
        '(c) 20180117
        If dr.Item("moneda").ToString = "1" Then
            dr_aux.Item("total") = dr.Item("total")
        Else
            dr_aux.Item("total") = dr.Item("totalIngreso")
        End If

        Try
            If dr.Item("FACE").ToString.Trim.Length > 0 Then
                dr_aux.Item("serieFACE") = dr.Item("FACE").ToString.Split(" ")(0).Trim
                dr_aux.Item("numeroFACE") = dr.Item("FACE").ToString.Split(" ")(1)
            End If
        Catch ex As Exception

        End Try
        dr_aux.Item("procesado") = 0
        Try
            If dr.Item("TipoDocto").ToString.ToUpper = "PEDIDO FACE" Or dr.Item("TipoDocto").ToString.ToUpper = "PEDIDO WALMART" Then
                dr_aux.Item("MaquinaFACE") = 1
            ElseIf dr.Item("TipoDocto").ToString.ToUpper = "PEDIDO FACE RE" Then
                dr_aux.Item("MaquinaFACE") = 2
            End If
        Catch ex As Exception

        End Try
        dr_aux.Item("ImpresoraFace") = dr.Item("impresora")
        dr_aux.Item("comuna") = dr.Item("comuna")
        dr_aux.Item("estado") = dr.Item("estado")

        Try
            dr_aux.Item("Numero_Recepcion_Walmart") = dr.Item("numero_recepcion_walmart").ToString
        Catch ex As Exception

        End Try

        '(c) 20180105 Tipo de Venta
        Try
            dr_aux.Item("tipoVenta") = dr.Item("tipoVenta").ToString
        Catch ex As Exception

        End Try

        '(c) 20180105 Tipo de Venta
        ''aqui
        Try
            dr_aux.Item("moneda") = dr.Item("moneda").ToString
            dr_aux.Item("tasa") = dr.Item("paridad").ToString
        Catch ex As Exception

        End Try

        ''Debo llamar al SP para que calcule el impuesto de distribucion
        '(c) 20150911
        Try
            Dim lsSQL As String
            Dim clsgen As New ClasesGenerales.General
            lsSQL = "spa_AddImptoDistribDetalle '" & dr_aux.Item("empresa").ToString & "','" & dr_aux.Item("TipoDocto") & "'," & dr_aux.Item("correlativo")
            '  clsgen.insertQuery("FlexLine", lsSQL)
            clsgen = Nothing
        Catch ex As Exception

        End Try


        'Llenar UsuarioModif
        '(c) 20190117
        Try
            dr_aux.Item("usuarioModif") = dr.Item("UsuarioModif").ToString

        Catch ex As Exception

        End Try

        Try

            If dr.Table.Columns.Contains("Listaprecio") = True Then

                If dr.Item("Listaprecio") IsNot DBNull.Value Then

                    dr_aux.Item("LisPrecio") = dr.Item("Listaprecio")

                Else

                    dr_aux.Item("LisPrecio") = ""

                End If

            End If

            If dr.Table.Columns.Contains("F_FLETE") = True Then

                If dr.Item("F_FLETE") IsNot DBNull.Value Then

                    dr_aux.Item("F_FLETE") = dr.Item("F_FLETE")
                    dr_aux.Item("F_SEGURO") = dr.Item("F_SEGURO")
                    dr_aux.Item("FLETE") = dr.Item("FLETE")
                    dr_aux.Item("SEGURO") = dr.Item("SEGURO")

                End If

            End If

            If dr.Item("SerieFace") IsNot DBNull.Value Then

                dr_aux.Item("Serie") = "Credito"
                dr_aux.Item("SerieFace") = dr.Item("SerieFace")
                dr_aux.Item("NumeroAutFace") = dr.Item("NumeroAutFace")
                dr_aux.Item("FechaFace") = dr.Item("FechaFace")
                dr_aux.Item("NoAutFel") = dr.Item("NoAutFel")
                dr_aux.Item("NoSerieFel") = dr.Item("NoSerieFel")

            End If

        Catch ex As Exception

        End Try

        odsFACE.Tables("pedidos").Rows.Add(dr_aux)

    End Sub


    Private Sub frmRecepcionRechazosFinanzas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos()
    End Sub

    Private Sub dgvListado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellContentClick

    End Sub

    Private Sub dgvListado_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvListado.RowsRemoved

    End Sub

    Private Sub dgvListado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvListado.DataError

    End Sub
End Class