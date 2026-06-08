Imports System.Text
Imports System.IO
Imports System.Net.Mime
Imports System.Web
Imports System.Net.Mail
Imports System.Linq
Imports System.Collections.Generic



Public Class movimiento_inventarios


    Public Sub verificarMovimientos()


        Dim dtMovimientos As DataTable
        Dim clsGen As New ClasesGenerales.General()


        Try

            Dim liDias As Integer = 0
            Dim ldFecha As Date = Today.AddDays(liDias)


            Dim sEmpresas() As String = clsGen.Obtener_XMLConfig("empresas_MovimientosInventarios", False).Split(",")  '"dmarte1,codicasa,diuva,vinoteca".Split(",")
            Dim sBodegas() As String = clsGen.Obtener_XMLConfig("bodegas_MovimientosInventarios", False).Split(",") '"CD_LIQUIDACION,CD_PRONTA_ACCION,CD_MAL_ESTADO".Split(",")

            For Each sEmpresa As String In sEmpresas


                For Each sBodega As String In sBodegas

                    clsGen.Escribir_Log("Generando Informacion de :" & sEmpresa & " - " & sBodega & " - " & ldFecha.ToShortDateString)

                    dtMovimientos = clsGen.selectQuery("FlexLine", "pa_rpt_Entradas_Bodega '" + sEmpresa + "','" + ldFecha.ToShortDateString() + "','" + sBodega + "'")

                    If (dtMovimientos.Rows.Count > 0) Then prepararCorreo(dtMovimientos, sEmpresa, sBodega, ldFecha)


                Next
            Next

        Catch ex As Exception
            clsGen.Escribir_Log(ex.Message)
        Finally
            clsGen = Nothing
        End Try




    End Sub

    Private Sub prepararCorreo(dtMovimientos As DataTable, sEmpresa As String, sBodega As String, dFecha As Date)


        Dim dtBU As DataTable
        Dim clsGen As New ClasesGenerales.General()
        Dim scuentas As String = String.Empty
        Try
            dtBU = clsGen.ValoresDistinto(dtMovimientos, "Bu".Split(","))
            For Each dr As DataRow In dtBU.Rows
                '' Se Envia a la lista de distribución de cada BUM
                If (scuentas.ToString().Length > 0) Then scuentas += ","
                scuentas += "informes_" & dr.Item("Bu").ToString().Replace(" ", "").Trim.ToLower & "@logiservicios.com"
            Next



            Dim lsRuta As String = generarPDF(dFecha.ToShortDateString(), sEmpresa, sBodega)
            Dim sSubject As String = String.Empty, sBody = String.Empty


            sSubject = "Ingresos a Bodega " & sBodega & " Del " & dFecha.ToShortDateString()

            'sBody = sBody & "<h3> Adjunto Enviamos detalle de Movimientos hacia la Bodega "
            'sBody = sBody & "<h1>" & sBodega & "</h1>"
            'sBody = sBody & "</h3>"

            'sBody = sBody & "<h2><br></h2>"
            'sBody = sBody & "<h2><br></h2>"
            'sBody = sBody & "<h2><br></h2>"
            'sBody = sBody & "<h2><br></h2>"

            'sBody = sBody & "*** No responda a este correo ***"

            'scuentas = scuentas
            'scuentas = "coscal@umbral.com.gt"
            'scuentasCopia = "hbonilla@logiservicios.com,omonterroso@logiservicios.com,hcambara@logiservicios.com,chernandez@logiservicios.com,mrojas@logiservicios.com,maquila@logiservicios.com,ggonzalez@logiservicios.com,coscal@umbral.com.gt,"
            'scuentasCopia = clsGen.Obtener_XMLConfig("copia_correo_inventarios", False)
            clsGen.Escribir_Log(scuentas)
            'clsGen.Escribir_Log(scuentasCopia)
            'clsGen.enviarcorreo("lgs1@logiservicios.com", "LGS1", scuentas, sSubject, sBody, lsRuta, scuentasCopia)

            Dim sbBody As New StringBuilder
            Dim nMaximo, nColumnas As Integer
            nMaximo = 10
            nColumnas = 10


            Dim drAux As DataRow
            Dim dtNumero As DataTable
            Dim lsNumeros As String = String.Empty

            dtNumero = clsGen.ValoresDistinto(dtMovimientos, "numero".Split(","))

            For Each drAux In dtNumero.Rows
                If lsNumeros.Length > 0 Then
                    lsNumeros += ","
                End If

                lsNumeros += drAux.Item("numero")
            Next




            drAux = dtMovimientos.Rows(0)

            sbBody.AppendLine("<tr><td colspan='7' style='heigth:   20px;'></td></tr>")
            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Empresa</strong></td>")
            sbBody.AppendLine("<td  style='text-align: Left;'>" + drAux.Item("empresa").ToString + "</td></tr>")

            sbBody.AppendLine("<tr><td colspan='7' style='heigth:   20px;'></td></tr>")
            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Documento</strong></td>")
            sbBody.AppendLine("<td  style='text-align: Left;'>" + drAux.Item("tipodocto").ToString & " - " & lsNumeros + "</td></tr>")



            sbBody.AppendLine("<tr><td colspan='7' style='heigth:   20px;'></td></tr>")
            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Fecha</strong></td>")
            sbBody.AppendLine("<td  style='text-align: Left;'>" + drAux.Item("fecha").ToString + "</td></tr>")

            sbBody.AppendLine("<tr><td colspan='7' style='heigth:   20px;'></td></tr>")
            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Bodega</strong></td>")
            sbBody.AppendLine("<td  style='text-align: Left;'>" + drAux.Item("bodega").ToString + "</td></tr>")

            sbBody.AppendLine("<tr><td colspan='7' style='heigth:   20px;'></td></tr>")
            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Comentarios</strong></td>")
            sbBody.AppendLine("<td  style='text-align: Left;'>" + drAux.Item("glosa").ToString + "</td></tr>")





            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td colspan='" & nMaximo + nColumnas & "'>")
            sbBody.AppendLine("")
            sbBody.AppendLine("</td>")
            sbBody.AppendLine("</tr>")






            'sb_mbody.AppendLine("<td><strong>Cliente</strong></td>");
            'sb_mbody.AppendLine("<td style=\"text-align: Left;\">" + l_ped.ctacte + "</td>");
            'sb_mbody.AppendLine("<td><strong>Nombre</strong></td>");
            'sb_mbody.AppendLine("<td colspan=\"2\" style=\"text-align: Left;\">" + l_ped.nombre_cliente + "</td>");
            'sb_mbody.AppendLine("</tr>");
            'sb_mbody.AppendLine("<tr>");
            'sb_mbody.AppendLine("<td><strong>Comentarios</strong></td>");
            'sb_mbody.AppendLine("<td colspan=\"6\" style=\"text-align: Left;\">" + l_ped.comentarios + "</td>");
            'sb_mbody.AppendLine("</tr>");
            'sb_mbody.AppendLine("<tr>");
            'sb_mbody.AppendLine("<td><strong>Pedido No</strong></td>");
            'sb_mbody.AppendLine("<td colspan=\"2\" style=\"text-align: Left;\">" + l_ped.tipo_docto_flex + "-" + l_ped.numero_pedido + "</td>");
            'sb_mbody.AppendLine("<td colspan=\"4\"></td>");
            'sb_mbody.AppendLine("</tr>");
            'sb_mbody.AppendLine("<tr><td colspan=\"7\" style=\"heigth:  20px;\"></td></tr>");
            'sb_mbody.AppendLine("<tr>");
            'sb_mbody.AppendLine("<td colspan=\"7\" style=\"background-color: #F8F8F8;\"><strong>Detalle del pedido</strong></td>");
            'sb_mbody.AppendLine("</tr>");.AppendLine("<tr><td colspan=\"7\" style=\"heigth:  20px;\"></td></tr>");
            'sb_mbody.AppendLine("<tr>");
            'sb_mbody.AppendLine("<td><strong>Empresa</strong></td>");
            'sb_mbody.AppendLine("<td  style=\"text-align: Left;\">" + l_ped.empresa + "</td>");
            'sb_mbody.AppendLine("<td><strong>Cliente</strong></td>");
            'sb_mbody.AppendLine("<td style=\"text-align: Left;\">" + l_ped.ctacte + "</td>");
            'sb_mbody.AppendLine("<td><strong>Nombre</strong></td>");
            'sb_mbody.AppendLine("<td colspan=\"2\" style=\"text-align: Left;\">" + l_ped.nombre_cliente + "</td>");
            'sb_mbody.AppendLine("</tr>");
            'sb_mbody.AppendLine("<tr>");
            'sb_mbody.AppendLine("<td><strong>Comentarios</strong></td>");
            'sb_mbody.AppendLine("<td colspan=\"6\" style=\"text-align: Left;\">" + l_ped.comentarios + "</td>");
            'sb_mbody.AppendLine("</tr>");
            'sb_mbody.AppendLine("<tr>");
            'sb_mbody.AppendLine("<td><strong>Pedido No</strong></td>");
            'sb_mbody.AppendLine("<td colspan=\"2\" style=\"text-align: Left;\">" + l_ped.tipo_docto_flex + "-" + l_ped.numero_pedido + "</td>");
            'sb_mbody.AppendLine("<td colspan=\"4\"></td>");
            'sb_mbody.AppendLine("</tr>");
            'sb_mbody.AppendLine("<tr><td colspan=\"7\" style=\"heigth:  20px;\"></td></tr>");
            'sb_mbody.AppendLine("<tr>");
            'sb_mbody.AppendLine("<td colspan=\"7\" style=\"background-color: #F8F8F8;\"><strong>Detalle del pedido</strong></td>");
            'sb_mbody.AppendLine("</tr>");





            formato_correo_html(dtMovimientos, scuentas, "", sSubject, True, nColumnas, nColumnas, lsRuta, ",producto,descripcion,cantidad", sbBody, ",cantidad,")


            Dim lsRutaServidor As String = "\\" + clsGen.Obtener_XMLConfig("servidor_alterno_" + clsGen.Obtener_XMLConfig("ubicacion", False), False) _
                    + "\flexline$" + "\" + sEmpresa + "\" + DateTime.Today.ToString("yyyyMM")


            Try

                If (Not Directory.Exists(lsRutaServidor)) Then Directory.CreateDirectory(lsRutaServidor)




            Catch ex As Exception


            End Try

            lsRutaServidor += "\" + "Salidas" + sEmpresa + "_" + sBodega + "_" + DateTime.Today.ToString("yyyyMMdd") + ".pdf"

            clsGen.Copiar_Archivo(lsRuta, lsRutaServidor, True)

        Catch ex As Exception
            clsGen.Escribir_Log(ex.Message)
        Finally
            clsGen = Nothing

        End Try



    End Sub

    Private Function generarPDF(psFechaDocto As String, sEmpresa As String, psBodega As String) As String



        Dim lsRutaPDF As String

        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As New Automatizar.Reportes_CraxDrt(sEmpresa)

        Oaut.pnNumeroCopias = 1


        '//El Documento se crea en el Directorio de la fecha de generacion
        '// lsRutaPDF = "\\" & clsGen.Obtener_XMLConfig("servidor_alterno_" & clsGen.Obtener_XMLConfig("ubicacion", False), False) & "\flexline$\" & gs_empresa & "\" & psFechaDocto
        '//Ruta Local
        lsRutaPDF = clsGen.Obtener_XMLConfig("Directorio_Local", False) & ":\temp\" + sEmpresa + "\" + DateTime.Today.ToString("yyyyMM") + "\" + psBodega

        Try


            If (Not Directory.Exists(lsRutaPDF)) Then

                Directory.CreateDirectory(lsRutaPDF)
            End If


        Catch ex As Exception

        End Try






        Try

            'lsRutaPDF = "c:\temp\" & Me.cmbTipoDocto.SelectedValue.ToString.Replace(" ", "_") & "_" & Me.txtNumero.Text & ".pdf"
            lsRutaPDF = lsRutaPDF + "\" + sEmpresa + "_" + psBodega + "_" + psFechaDocto.Replace("/", "").Replace("-", "") + ".pdf"

            clsGen.Escribir_Log("Ruta PDF " + lsRutaPDF)
            Dim pm_valores(3) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String


            Dim pm_parametros2(2) As String
            Dim pm_valores2(2) As String

            pm_conexion = clsGen.Parametros_Conexion("vdataserver")
            Dim ppath_reporte As String = clsGen.Path_Reporte()



            ppath_reporte = clsGen.Path_Reporte()
            ppath_reporte = ppath_reporte & "Logistica\" & "Bodega\" & "Entradas a Bodega por Dia.rpt"



            pm_parametros2(0) = "@Empresa"
            pm_parametros2(1) = "@Fecha"
            pm_parametros2(2) = "@Bodega"


            pm_valores2(0) = sEmpresa
            pm_valores2(1) = psFechaDocto
            pm_valores2(2) = psBodega


            _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2,
                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                True, False, "PDF", False, lsRutaPDF, True, sEmpresa)




        Catch ex As Exception

            clsGen.Escribir_Log("Generar PDF " + ex.ToString())

        Finally

            Oaut = Nothing
            clsGen = Nothing

        End Try


        Return lsRutaPDF
    End Function

    Private Sub _reporte_generico_clase(path_reporte As String, pm_parametros As String(), pm_valores As String(),
      _pServidor As String, _pBase_datos As String, _pUsuario As String, _ppwd As String,
      pexportar As Boolean, imprimir As Boolean, _ptipo_exportar As String, _pmostrar_archivo As Boolean,
          _nombre_archivo As String, mostrarError As Boolean, psEmpresa As String)


        Dim valorRegreso As Boolean = True

        Dim Oaut As New Automatizar.Reportes_CraxDrt(psEmpresa)
        If (_nombre_archivo.Length > 0) Then Oaut.Archivo_Generado = _nombre_archivo


        Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, _pServidor, _pBase_datos, _pUsuario, _ppwd, pexportar, imprimir, _ptipo_exportar, _pmostrar_archivo)

        If Oaut.Descripcion_Error.Length > 0 Then



            If (mostrarError) Then
                'MessageBox.Show("Oaut._Reporte Generico " + Oaut.Descripcion_Error)

                valorRegreso = False
            End If
        End If
        Oaut.finalizar()
        Oaut = Nothing
        GC.Collect()

    End Sub


    Private Sub formato_correo_html(pdtPedidos As DataTable, psCuentaCorreo As String, psUsuarioActual As String, psSubject As String, pmostrarEncabezado As Boolean, pcolumnas As Integer, pmaximo As Integer, psrutaAdjunto As String,
                                  psColumnasMostrar As String, sbBody As StringBuilder, psColumnasDecimal As String)

        System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2



        Dim Message As New System.Net.Mail.MailMessage()
        Dim SMTP1 As New System.Net.Mail.SmtpClient
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try

            Dim sbCorreo As New StringBuilder

            Dim iCount As Integer = 0


            dt = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_simple '" & psUsuarioActual & "'")

            sbCorreo.AppendLine("<table style:'width:100%; cellpadding:0px; cellspacing:0px;'>")
            sbCorreo.AppendLine("<tr>")

            If sbBody.Length > 0 Then
                sbCorreo = sbCorreo.Append(sbBody)
            Else



                sbCorreo.AppendLine("<td colspan='" & pmaximo + pcolumnas & "'>")

                Try
                    'sBody = sBody & StrConv(dt.Rows(0).Item("nombre").ToString, VbStrConv.ProperCase)
                    sbCorreo.AppendLine("Buen Dia " & StrConv(dt.Rows(0).Item("nombre").ToString, VbStrConv.ProperCase))
                Catch ex As Exception
                    sbCorreo.AppendLine("Buenos Dias")
                End Try

                sbCorreo.AppendLine("</td>")
                sbCorreo.AppendLine("</tr>")

                sbCorreo.AppendLine("<tr>")
                sbCorreo.AppendLine("<td colspan='" & pmaximo + pcolumnas & "'>")
                sbCorreo.AppendLine("<b>Detalle Documentos</b>")
                sbCorreo.AppendLine("</td>")
                sbCorreo.AppendLine("</tr>")

                sbCorreo.AppendLine("<tr>")
                sbCorreo.AppendLine("<td colspan='" & pmaximo + pcolumnas & "' style='height:20px;'>")
                sbCorreo.AppendLine("</td>")
                sbCorreo.AppendLine("</tr>")

            End If




            If pmostrarEncabezado = True And pdtPedidos.Rows.Count > 0 Then
                sbCorreo.AppendLine("<tr style='background-color:#560000; color:white;'>")
                For Each dcColumn As DataColumn In pdtPedidos.Columns
                    If psColumnasMostrar.IndexOf(dcColumn.ColumnName.ToLower.ToString) > 0 Then


                        iCount += 1
                        sbCorreo.AppendLine("<td>")
                        sbCorreo.AppendLine(dcColumn.ColumnName.ToString().TrimEnd)
                        sbCorreo.AppendLine("</td>")

                        If iCount > pcolumnas Then

                            If iCount > pmaximo + pcolumnas Then Exit For
                        End If
                    End If
                Next
                sbCorreo.AppendLine("</tr>")

                iCount = 0


                For Each dr As DataRow In pdtPedidos.Rows
                    sbCorreo.AppendLine("<tr>")
                    Try
                        iCount = 0
                        For Each dcColumn As DataColumn In pdtPedidos.Columns
                            If psColumnasMostrar.IndexOf(dcColumn.ColumnName.ToLower.ToString) > 0 Then
                                iCount += 1


                                If psColumnasDecimal.IndexOf(dcColumn.ColumnName.ToLower.ToString) > 0 Then
                                    sbCorreo.AppendLine("<td  style ='text-align: Right;'>")
                                    sbCorreo.AppendLine(Format(Convert.ToDecimal(dr.Item(dcColumn.ColumnName.ToString().TrimEnd)), "###,###,##0").ToString())
                                Else
                                    sbCorreo.AppendLine("<td>")
                                    sbCorreo.AppendLine(dr.Item(dcColumn.ColumnName.ToString().TrimEnd))
                                End If
                                sbCorreo.AppendLine("</td>")
                                If iCount > pcolumnas Then
                                    If iCount > pmaximo + pcolumnas Then Exit For
                                End If
                            End If
                        Next

                    Catch ex As Exception

                    Finally
                    End Try
                    sbCorreo.AppendLine("</tr>")
                Next

            End If

            'sbCorreo.AppendLine("<tr>")
            'sbCorreo.AppendLine("<td></td>")
            'sbCorreo.AppendLine("<td></td>")
            'sbCorreo.AppendLine("<td></td>")
            'sbCorreo.AppendLine("<td>")
            ''sbCorreo.AppendLine("<b>Total</b>")
            'sbCorreo.AppendLine("</td>")
            'sbCorreo.AppendLine("<td><b>")
            ''sbCorreo.AppendLine(Decimal.Round(lDetTraslados.Sum(x >= x.Total), 2).ToString());
            'sbCorreo.AppendLine("</b></td>")

            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td colspan='" & pmaximo + pcolumnas & "'>")
            sbCorreo.AppendLine(" ")
            sbCorreo.AppendLine("</td>")
            sbCorreo.AppendLine("</tr>")

            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td colspan='" & pmaximo + pcolumnas & "'>")
            sbCorreo.AppendLine(" ")
            sbCorreo.AppendLine("</td>")
            sbCorreo.AppendLine("</tr>")

            sbCorreo.AppendLine("<tr>")
            sbCorreo.AppendLine("<td colspan='" & pmaximo + pcolumnas & "'>")
            sbCorreo.AppendLine("*** NO RESPONDA A ESTE CORREO ***")
            sbCorreo.AppendLine("</td>")
            sbCorreo.AppendLine("</tr>")

            sbCorreo.AppendLine("</table>")


            'sendMail(psCuentaCorreo, psSubject, sbCorreo.ToString(), "", psrutaAdjunto, "lgs1@logiservicios.com", "LGS1")
            sendMail(psCuentaCorreo, psSubject, sbCorreo.ToString(), "", psrutaAdjunto, "lgs1@logiservicios.com", "LS1")


        Catch ex As Exception
            clsGen.Escribir_Log(psSubject)
            clsGen.Escribir_Log(ex.ToString)

        Finally
            Message = Nothing
            SMTP1 = Nothing
            clsGen = Nothing
        End Try


    End Sub



    Public Sub sendMail(psCuentaCorreo As String, psSubject As String, sBody As String, psImagen As String, psRutaAdjunto As String,
                         psCuentaCorreoEnvia As String, psNombreCorreoEnvia As String)



        System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2


        Dim clsGen As New ClasesGenerales.General

        Dim Message As New System.Net.Mail.MailMessage()
        Dim SMTP1 As New System.Net.Mail.SmtpClient

        Dim adjuntar As Net.Mail.Attachment

        Dim dt As DataTable



        Try
            Message = New System.Net.Mail.MailMessage()
            'Dim adjuntar As New Net.Mail.Attachment(ruta)
            SMTP1 = New System.Net.Mail.SmtpClient
            'config. para Outlook
            SMTP1.Port = 587
            SMTP1.Host = "smtp.office365.com" 'servidor de correo outlook
            SMTP1.EnableSsl = True


            'Copia para auditoria
            Try
                Dim sCorreoAuditoria As String
                Dim lsCuentasAudtoria As String = String.Empty
                sCorreoAuditoria = clsGen.Obtener_XMLConfig("correo_auditoria", False)
                If sCorreoAuditoria.Length > 0 Then

                    Dim dtCorreo As DataTable




                    For Each scuenta As String In sCorreoAuditoria.Split(",")

                        dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & scuenta & "'")

                        If dtCorreo.Rows.Count > 0 Then
                            If lsCuentasAudtoria.Length > 0 Then lsCuentasAudtoria += ","

                            lsCuentasAudtoria += dtCorreo.Rows(0).Item("correo")
                        End If

                    Next


                    Message.[Bcc].Add(lsCuentasAudtoria)

                End If



            Catch ex As Exception

            End Try


            dt = clsGen.selectQuery("SCM", "pa_var_um_credenciales_notificacion")
            SMTP1.Credentials = New Net.NetworkCredential(dt.Rows(0).Item("mail").ToString, dt.Rows(0).Item("pwd").ToString)

            Message.[To].Add(psCuentaCorreo)


            Message.From = New System.Net.Mail.MailAddress(psCuentaCorreoEnvia, psNombreCorreoEnvia, System.Text.Encoding.UTF8) 'Quien envía el e-mail


            'Dim l_lnkres As LinkedResource
            Dim l_altview As AlternateView
            Try


                Dim l_lnkres As New LinkedResource(psImagen, MediaTypeNames.Image.Jpeg)
                l_lnkres.ContentId = Guid.NewGuid().ToString

                sBody = "<table style='width:100%; cellpadding:0px; cellspacing:0px;'>" +
                        "<tr><td><img src='cid:" + l_lnkres.ContentId + "' /></td></tr>" +
                        "</table><br />" + sBody
                l_altview.LinkedResources.Add(l_lnkres)
            Catch ex As Exception

            End Try


            l_altview = AlternateView.CreateAlternateViewFromString(sBody, Nothing, MediaTypeNames.Text.Html)
            'l_altview = AlternateView.CreateAlternateViewFromString(sBody)



            Message.AlternateViews.Add(l_altview)

            Message.Subject = psSubject
            Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
            Message.Body = sBody

            Message.BodyEncoding = System.Text.Encoding.UTF8
            Message.Priority = System.Net.Mail.MailPriority.Normal
            Message.IsBodyHtml = True



            Try
                If psRutaAdjunto.Trim.Length > 0 Then
                    adjuntar = New Net.Mail.Attachment(psRutaAdjunto)
                End If


                Message.Attachments.Add(adjuntar)
            Catch ex As Exception

            End Try



            SMTP1.Send(Message)

        Catch ex As Exception
            clsGen.Escribir_Log(psSubject)
            clsGen.Escribir_Log(ex.ToString)

            Try
                prepararAvisoErrorEnvioTEAMS(sBody, "", psSubject)
            Catch ex2 As Exception

            End Try

        Finally
            Message = Nothing
            SMTP1 = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub prepararAvisoErrorEnvioTEAMS(psBody As String, psUsuarioActual As String, psOrigen As String)
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL, lsCorreo, lscuentasfacturacion As String
        Dim dtCorreo As DataTable


        Try



            Dim varMotivo As String = "CONFIRMACION DE PEDIDOS"

            Dim varMensajeAEnviar As String




            varMensajeAEnviar = "Problemas para Confirmar Pedidos" & "|" &
                                    "Referencia:  pa_sel_um_sg_usuario_simple" & "|" &
                                        "Origen : " & psOrigen & "|" &
                                        "Mensaje : " & psBody & "|" &
                                                                                "Verificar configuracion de usuario"




            lscuentasfacturacion = clsGen.Obtener_XMLConfig("avisos_helpdesk", False)

            For Each pscuentafacturacion As String In lscuentasfacturacion.Split(",")


                lsSQL = "pa_sel_um_sg_usuario_email '" & pscuentafacturacion & "'"
                dtCorreo = clsGen.selectQuery("FlexLine", lsSQL)
                lsCorreo = dtCorreo.Rows(0).Item("correo").ToString
                If lsCorreo.Length > 0 Then
                    clsGen.enviarMensajeTeams(lsCorreo, varMotivo, varMensajeAEnviar)
                End If
            Next
            ' End If

        Catch ex As Exception

        End Try

    End Sub


End Class

Public Class aprobaciones


    Public Sub solicitarAprobacionRequisicion(pdrRquisicion As DataRow, psNombrePDF As String, psCorreoAprobara As String, psUsuarioAprobara As String, psComentarioSolicitudAprobacion As String)

        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General



        lsSQL = "pa_ins_um_aprobaciones '" & pdrRquisicion.Item("empresa").ToString & "','REQUISICION','" &
            pdrRquisicion.Item("numero") & "','" & Date.Parse(pdrRquisicion.Item("fecha").ToString()).ToString("yyyy-M-dd") & "','" & pdrRquisicion.Item("usuariograbo") & "','" &
            pdrRquisicion.Item("observaciones").ToString & "','" & psNombrePDF & "','0','" &
            pdrRquisicion.Item("correo").ToString & ", compraslocales@umbral.com.gt" &
        "','" & psCorreoAprobara & "','" & psComentarioSolicitudAprobacion & "','" & psUsuarioAprobara & "'"

        clsGen.insertQuery("RegionalDBintOut", lsSQL)
    End Sub



End Class

Public Class sobreStock

    Public Sub generar_sobrestock(psEmpresa As String)


        Dim ods As DataSet
        Dim psemanaActual As Integer = DatePart(DateInterval.WeekOfYear, Today, FirstDayOfWeek.Monday)

        Try

            ods = New DataSet

            Dim oCompras As New Compras.SCM(ods)
            Dim dt As DataTable
            Dim dr As DataRow
            Dim otrans As New Transaccional.Conexion("SCM")
            Dim ClsGen As New ClasesGenerales.General
            Dim ls_sql As String
            Dim iaux As Integer


            Try
                otrans.open()
                oCompras.Empresa = psEmpresa
                oCompras.Crear_Estructura()
                oCompras.SetProductoLimite("0060000000")
                oCompras.Inicializar_Productos(True, False, False, False)
                oCompras.Revisar_productoDerivados("detalle_productos")

                'If Not Me.btnMarcar.Text.ToLower.StartsWith("des") Then

                dt = ods.Tables("detalle_productos").Copy
                dt.Rows.Clear()
                ods.Tables("detalle_productos").DefaultView.RowFilter = ""
                'For ii As Integer = 0 To chk_marcas.Items.Count - 1

                '    If Me.chk_marcas.GetItemChecked(ii) Then
                '        'ods.Tables("detalle_productos").DefaultView.RowFilter = "proveedor = '" & Me.chk_marcas.Items(ii)("codigo") & "'"
                '        ods.Tables("detalle_productos").DefaultView.RowFilter = "familia = '" & Me.chk_marcas.Items(ii)("codigo") & "'"
                For Each drv As DataRowView In ods.Tables("detalle_productos").DefaultView
                    If drv.Item("producto") = "0010101004" Then
                        drv.Item("producto") = "0010101004"
                    End If
                    ods.Tables("derivados").DefaultView.RowFilter = "empresa = '" & drv.Item("empresa") & "' and " &
                            "producto = '" & drv.Item("producto") & "'"


                    If ods.Tables("derivados").DefaultView.Count = 0 Then

                        dr = dt.NewRow
                        For Each dc As DataColumn In dt.Columns
                            dr.Item(dc.ColumnName) = drv.Item(dc.ColumnName)
                        Next
                        dt.Rows.Add(dr)
                    End If
                Next


                '    End If
                'Next
                dt.TableName = "detalle_productos"
                ods.Tables.Remove("detalle_productos")
                ods.Tables.Add(dt.Copy)

                ' End If

                Dim dtunicos As DataTable = ClsGen.ValoresDistinto(ods.Tables("detalle_productos"), "empresa,proveedor".Split(","))

                oCompras.generarExistencia(False, False)



                'producto en internacion
                'dtunicos = ClsGen.ValoresDistinto(ods.Tables("detalle_productos"), "empresa".Split(","))

                'For Each dr_aux As DataRow In dtunicos.Rows

                ls_sql = "pa_var_um_producto_transito_internacion '" & psEmpresa & "'"
                dt = otrans.Obtiene(ls_sql)

                For Each dr In dt.Rows
                    ods.Tables("detalle_productos").DefaultView.RowFilter _
                                       = "producto = '" & dr.Item("producto") & "' and empresa = '" & dr.Item("empresa") & "'"
                    For Each drv As DataRowView In ods.Tables("detalle_productos").DefaultView
                        Try
                            iaux = dr.Item("cantidad") / drv.Item("uxc")
                        Catch ex As Exception
                            iaux = 0
                        End Try
                        drv.Item("internacion") = iaux
                        drv.Item("existencia") += drv.Item("internacion")
                    Next

                Next
                'Next

                '            Generar_Presupuestos()
                '          Generar_Transitos()


                oCompras.generarTransitos(psemanaActual, "", False)

                ''Generando Presupuestos
                '          Me.chk_presupuestos.Checked = True
                '  Generar_Presupuestos()
                oCompras.generarPresupuestos(psemanaActual, "", False)
                oCompras.Generar_SaldosyCoberturas(False)

                'dg_productos.DataSource = ods.Tables("detalle_productos")

                'dt = ClsGen.ValoresDistinto(ods.Tables("detalle_productos"), "marca".Split(","))

                'If dt.Rows.Count > 1 Then
                '    Me.lblMarca.Visible = True
                '    Me.cmbMarca.Visible = True
                '    cmbMarca.Items.Clear()
                '    cmbMarca.Items.Add("-TODOS-")
                '    For Each dr In dt.Rows
                '        cmbMarca.Items.Add(dr.Item("marca"))
                '    Next

                'Else
                '    Me.lblMarca.Visible = False
                '    Me.cmbMarca.Visible = False
                'End If



                ''Agregar Informacion del CUBO 20170327

                'ods.Tables("detalle_productos")
                ods.Tables("detalle_productos").Columns.Add(New DataColumn("costo_inventario", GetType(Double)))
                ods.Tables("detalle_productos").Columns.Add(New DataColumn("unidades_ss", GetType(Double)))
                ods.Tables("detalle_productos").Columns.Add(New DataColumn("costo_ss", GetType(Double)))




                Dim dtss As DataTable

                dtss = otrans.Obtiene("Select * from Sobre_Inventario4 where bodega = 'cd_da'")
                For Each dr2 As DataRow In ods.Tables("detalle_productos").Rows
                    dtss.DefaultView.RowFilter = "empresa = '" & dr2.Item("empresa").ToString & "' and producto = '" & dr2.Item("producto").ToString & "'"
                    Try
                        If dtss.DefaultView.Count > 0 Then
                            dr2.Item("costo_inventario") = dtss.DefaultView(0).Item("costo_inventario")
                            dr2.Item("costo_ss") = dtss.DefaultView(0).Item("costo_sobre_inventario")
                            dr2.Item("unidades_ss") = dtss.DefaultView(0).Item("sobre_inventario")
                        End If
                    Catch ex As Exception
                    End Try
                Next

                dtss.DefaultView.RowFilter = "empresa = '" & psEmpresa & "'"
                For Each drv As DataRowView In dtss.DefaultView

                    Try

                        ods.Tables("detalle_productos").DefaultView.RowFilter = "producto = '" & drv.Item("producto").ToString & "'"
                        If ods.Tables("detalle_productos").DefaultView.Count = 0 Then
                            Dim dr2 As DataRow

                            dr2 = ods.Tables("detalle_productos").NewRow
                            dr2.Item("producto") = drv.Item("producto").ToString
                            dr2.Item("glosa") = drv.Item("glosa").ToString
                            dr2.Item("costo_inventario") = drv.Item("costo_inventario")
                            dr2.Item("costo_ss") = drv.Item("costo_sobre_inventario")
                            dr2.Item("unidades_ss") = drv.Item("sobre_inventario")
                            dr2.Item("pareto") = drv.Item("pareto").ToString

                            ods.Tables("detalle_productos").Rows.Add(dr2)

                        End If
                    Catch ex As Exception

                    End Try

                Next


            Catch ex As Exception
            Finally
                oCompras = Nothing
                otrans.close()
                otrans = Nothing
                oCompras = Nothing
                ods.Tables("detalle_productos").DefaultView.RowFilter = ""

                'ods.WriteXml("c:\aplicaciones\cobertura\" & gs_empresa.Trim & Today.ToString("ddMMMMyy") & ".xml", XmlWriteMode.WriteSchema)


                ''Dim ods As New DataSet

                ''ods.ReadXml("c:\aplicaciones\cobertura\diuva.xml")

                ''''Dim odsnew As New DataSet

                'Dim dt As New DataTable
                dt = ods.Tables("detalle_productos").Copy
                dt.Columns.Add(New DataColumn("fecha_generacion", GetType(String)))
                For Each draux As DataRow In dt.Rows
                    draux.Item("fecha_generacion") = Today.ToString("dd/MM/yyyy")
                Next
                ''Dim clsgen As New ClasesGenerales.General
                ClsGen.dtTableToCSV(dt, "c:\aplicaciones\cobertura\" & psEmpresa & Today.ToString("ddMMMMyy"), True, "|")
                ClsGen = Nothing


                'dt.TableName = "detalle_productos"

                'dt.WriteXml("c:\aplicaciones\cobertura\test.xml", XmlWriteMode.WriteSchema)
            End Try



        Catch ex As Exception

        End Try

    End Sub


End Class