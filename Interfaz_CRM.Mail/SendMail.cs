using Interfaz_CRM.Mail.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO; 



namespace Interfaz_CRM.Mail
{
    public class SendMail
    {

        // (c) 20231110 Se agrego el servicio TLS 1.2

        public void EnviarCorreo(string pUsuario, string pCorreo, List<mov_pedidos_encabezado_mercaderistas> pPedidos, string pUsermail, 
                string pPwdmail, string psorigen, string psMoneda)
        {
            try
            {
                String slCultura = "es-GT";

                try
                {
                    if (psMoneda=="L")
                                   slCultura = "es-HN";


                    if (psMoneda == "$")
                        slCultura = "es-SV";

                }
                catch (Exception ex)
                {

                }
                string lssaludo = "Buen Dia "; 

                int horaActual = DateTime.Now.Hour;

                // Verifica si es mañana o tarde
                if (horaActual > 12)
                {
                    
                                    lssaludo = "Buena Tarde ";
                }

                StringBuilder sb_mbody = new StringBuilder();
            SmtpClient l_srv_salida = new SmtpClient();
            MailMessage l_email = new MailMessage();
            decimal l_total_pedidos = Convert.ToDecimal(pPedidos.Sum(x => x.total_pedido));

                System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;
                //'TLS 1.2


                //List<DTO.credenciales_notificacion> credenciales;

                //using (Mdl.SCMEntities dbContext = new Mdl.SCMEntities())
                //{

                //     credenciales =
                //        dbContext.pa_var_um_credenciales_notificacion().Select(x => new DTO.credenciales_notificacion
                //        {
                //            correo1 = x.mail,
                //            clave1 = x.pwd
                //        }).ToList();

                //}

                //pCorreo = pCorreo + ",carlos.oscal@umbralcorp.com";
                l_email.From = new System.Net.Mail.MailAddress("umbralcorp@umbralcorp.com", "Notificaciones", System.Text.Encoding.UTF8);
            l_email.To.Add(pCorreo);

            l_email.Subject = "Pedido recibido correctamente desde "+ psorigen;

                //l_srv_salida.Credentials = new System.Net.NetworkCredential(credenciales[0].correo1, credenciales[0].clave1);
                l_srv_salida.Credentials = new System.Net.NetworkCredential(pUsermail, pPwdmail);

                l_srv_salida.Port = 587;
            l_srv_salida.Host = "smtp.office365.com";
            l_srv_salida.EnableSsl = true;

            if (!System.IO.Directory.Exists("C:/Media/Images"))
            {
                System.IO.Directory.CreateDirectory("C:/Media/Images");
                Properties.Resources.umbral.Save("C:/Media/Images/umbral.jpg");
            }

            LinkedResource l_lnkres = new LinkedResource("C:/Media/Images/Umbral.jpg", MediaTypeNames.Image.Jpeg);
            l_lnkres.ContentId = Guid.NewGuid().ToString();

            sb_mbody.AppendLine("<table style=\"width:100%; cellpadding:0px; cellspacing:0px;\">");
            sb_mbody.AppendLine("<tr>");
            sb_mbody.AppendLine("<td colspan=\"7\"><img src=\"cid:" + l_lnkres.ContentId + "\"/></td>");
            sb_mbody.AppendLine("</tr>");
            sb_mbody.AppendLine("<tr>");
            sb_mbody.AppendLine("<td colspan=\"7\"></td>");
            sb_mbody.AppendLine("</tr>");
            sb_mbody.AppendLine("<tr>");
            sb_mbody.AppendLine("<td colspan=\"7\"><b>" + lssaludo + pUsuario + "</ b ></ td > ");
            sb_mbody.AppendLine("</tr>");
            sb_mbody.AppendLine("<tr>");
            sb_mbody.AppendLine("<td colspan=\"7\"></td>");
            sb_mbody.AppendLine("</tr>");
            sb_mbody.AppendLine("<tr>");
            sb_mbody.AppendLine("<td colspan=\"7\">Se le informa que a la fecha " + DateTime.Now.ToString("dd/MM/yyyy") + " siendo las "
                + DateTime.Now.ToString("hh:mm:ss") + ", a enviado un total de " + pPedidos.Count().ToString("00#") + " pedidos.");
            sb_mbody.AppendLine("</tr>");
            sb_mbody.AppendLine("<tr>");
            sb_mbody.AppendLine("<td colspan=\"7\"></td>");
            sb_mbody.AppendLine("</tr>");
            sb_mbody.AppendLine("<tr>");
            sb_mbody.AppendLine("<td colspan=\"7\">Detalle:</td>");
            sb_mbody.AppendLine("</tr>");

            foreach (DTO.mov_pedidos_encabezado_mercaderistas l_ped in pPedidos)
            {
                
                sb_mbody.AppendLine("<tr><td colspan=\"7\" style=\"heigth: 20px;\"></td></tr>");
                sb_mbody.AppendLine("<tr>");
                sb_mbody.AppendLine("<td><strong>Cliente</strong></td>");
                sb_mbody.AppendLine("<td <td colspan=\"6\" style=\"text-align:left;\">" + l_ped.empresa + "-" + l_ped.ctacte + "-" + l_ped.nombre_cliente + "</td>");
                //sb_mbody.AppendLine("<td><strong>Cliente</strong></td>");
                //sb_mbody.AppendLine("<td colspan=\"4\" style=\"text-align:left;\">" + l_ped.ctacte + "-" + l_ped.nombre_cliente + "</td>");
                //sb_mbody.AppendLine("<td><strong>Nombre</strong></td>");
                //sb_mbody.AppendLine("<td colspan=\"2\" style=\"text-align:left;\">" + l_ped.nombre_cliente + "</td>");
                sb_mbody.AppendLine("</tr>");
                                    sb_mbody.AppendLine("<tr>");
                                    sb_mbody.AppendLine("<td><strong>Comentarios</strong></td>");
                                    sb_mbody.AppendLine("<td colspan=\"6\" style=\"text-align:left;\">" + l_ped.comentarios + "</td>");
                sb_mbody.AppendLine("</tr>");


                    try
                    {
                        sb_mbody.AppendLine("<tr>");
                        sb_mbody.AppendLine("<td><strong>Direccion Entrega</strong></td>");
                        sb_mbody.AppendLine("<td colspan=\"6\" style=\"text-align:left;\">" + l_ped.direccion_entrega + "</td>");
                        sb_mbody.AppendLine("</tr>");

                    }
                    catch (Exception ex)
                    { 
                    }
                                    try
                    {
                        sb_mbody.AppendLine("<tr>");
                        sb_mbody.AppendLine("<td><strong>Referencia PDV</strong></td>");
                        sb_mbody.AppendLine("<td colspan=\"6\" style=\"text-align:left;\">" + l_ped.referencia_pdv + "</td>");
                        sb_mbody.AppendLine("</tr>");

                    }
                    catch (Exception ex)
                    { 
                    }
                    try
                    {
                        sb_mbody.AppendLine("<tr>");
                        sb_mbody.AppendLine("<td><strong>Horario Entrega</strong></td>");
                        sb_mbody.AppendLine("<td colspan=\"6\" style=\"text-align:left;\">" + l_ped.dias_entrega + " Horas " + l_ped.horas_entrega + "</td>");
                        sb_mbody.AppendLine("</tr>");

                    }
                    catch (Exception ex)
                    {
                    }


                    try
                    {                        
                        if ((l_ped.path_pdf != "") && (l_ped.path_pdf != null))
                        {
                            sb_mbody.AppendLine("<tr>");
                            sb_mbody.AppendLine("<td><strong>OC Adjunta</strong></td>");
                            if (l_ped.adjunto_correcto == "SI")
                            {
                                sb_mbody.AppendLine("<td colspan=\"6\" style=\"text-align:left;\">SI</td>");
                            }
                            else
                            {
                                sb_mbody.AppendLine("<td colspan=\"6\" style=\"text-align:left;\">NO Asociada</td>");
                            }
                            
                            sb_mbody.AppendLine("</tr>");
                        }

                    }
                    catch (Exception ex)
                    {
                    }

                    //try
                    //{
                    //    if ((l_ped.bodega != "") && (l_ped.bodega != null))
                    //    {
                    //        sb_mbody.AppendLine("<tr>");
                    //        sb_mbody.AppendLine("<td><strong>Bodega </strong></td>");
                    //        sb_mbody.AppendLine("<td colspan=\"6\" style=\"text-align:left;\">" + l_ped.bodega + "</td>");
                    //        sb_mbody.AppendLine("</tr>");

                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //}

                    //(c) 20250710 Comentario retenido

                    try
                    {
                        if ((l_ped.motivo_retenido != ""))
                        {
                            sb_mbody.AppendLine("<tr>");
                            sb_mbody.AppendLine("<td><strong>Retenido:</strong></td>");
                            sb_mbody.AppendLine("<td colspan=\"6\" style=\"text-align:left;\">" + l_ped.motivo_retenido+ "</td>");
                            sb_mbody.AppendLine("</tr>");
                        }

                    }
                    catch (Exception ex)
                    {
                    }




                    sb_mbody.AppendLine("<tr>");
                sb_mbody.AppendLine("<td><strong>Pedido No</strong></td>");
                sb_mbody.AppendLine("<td colspan=\"6\" style=\"text-align:left;\">" + l_ped.tipo_docto_flex + "-" + l_ped.numero_pedido + "</td>");
               //sb_mbody.AppendLine("<td colspan=\"4\"></td>");
                sb_mbody.AppendLine("</tr>");

                    




                    sb_mbody.AppendLine("<tr><td colspan=\"7\" style=\"heigth: 20px;\"></td></tr>");
                sb_mbody.AppendLine("<tr>");
                sb_mbody.AppendLine("<td colspan=\"7\" style=\"background-color:#F8F8F8;\"><strong>Detalle del pedido</strong></td>");
                sb_mbody.AppendLine("</tr>");
                sb_mbody.AppendLine("<tr><td colspan=\"7\" style=\"heigth: 20px;\"></td></tr>");
                sb_mbody.AppendLine("<tr>");
                sb_mbody.AppendLine("<th align='left' style=\"width:35px;\">No</th>");
                sb_mbody.AppendLine("<th align='left'>Producto</th>");
                sb_mbody.AppendLine("<th colspan=\"2\" align='left'>Nombre</th>");
                sb_mbody.AppendLine("<th align='left'>Cantidad</th>");
                sb_mbody.AppendLine("<th align='left'>Precio(" + psMoneda + ") </th>");
                sb_mbody.AppendLine("<th align='left'>Total linea(" + psMoneda + ")</th>");
                sb_mbody.AppendLine("</tr>");

                foreach(mov_pedidos_detalle_ps det in l_ped.DetallePedido)
                {
                    sb_mbody.AppendLine("<tr>");
                    sb_mbody.AppendLine("<td style=\"width:20px;\">" + det.linea.ToString() + "</td>");
                    sb_mbody.AppendLine("<td>" + det.cod_producto_flex + "</td>");
                    sb_mbody.AppendLine("<td colspan=\"2\">" + det.nombre_producto + "</td>");
                    sb_mbody.AppendLine("<td>" + det.cantidad.ToString() + "</td>");
                    sb_mbody.AppendLine("<td>" + Convert.ToDecimal(det.precio).ToString("C3", CultureInfo.CreateSpecificCulture(slCultura)) + "</td>");
                    sb_mbody.AppendLine("<td>" + Convert.ToDecimal(det.total_linea).ToString("C3", CultureInfo.CreateSpecificCulture(slCultura)) + "</td>");
                    sb_mbody.AppendLine("</tr>");
                }

                sb_mbody.AppendLine("<tr style=\"border-top: 1px; border-top-style:solid;\">");
                sb_mbody.AppendLine("<td colspan=\"5\" style=\"border-top:1px; border-top-style:solid;\"></td>");
                sb_mbody.AppendLine("<td colspan=\"2\" style=\"text-align:right; border-top:1px; border-top-style:solid;\"><b>Total     " + l_total_pedidos.ToString("C3", CultureInfo.CreateSpecificCulture(slCultura)) + "</b></td>");
                sb_mbody.AppendLine("</tr>");

            }
            
            sb_mbody.AppendLine("</table><br /><br />");

            AlternateView l_altview = AlternateView.CreateAlternateViewFromString(sb_mbody.ToString(), null, MediaTypeNames.Text.Html);
            l_altview.LinkedResources.Add(l_lnkres);

            l_email.IsBodyHtml = true;
            l_email.AlternateViews.Add(l_altview);

            l_srv_salida.Send(l_email);
            }
            catch (Exception ex)
            { }
        }
    }




public class RechazoEntrega
    {
        public string tipoDocto { get; set; }
        public string Numero { get; set; }
        public string controlTransporte { get; set; }
        public DateTime fecha { get; set; }
        public string EstadoCliente { get; set; }
        public string motivo { get; set; }
        public string CodigoCliente { get; set; }
        public string pdf_pod { get; set; }
        public string tracking_url { get; set; }
        public string empresa { get; set; }
        public string comentario_piloto { get; set; }
        public DateTime fecha_rechazo { get; set; }
    }

    public static class MailRechazos
    {
        // -------- API pública --------

        // Enviar desde List<RechazoEntrega>
        public static void EnviarCorreoRechazos(
            string pUsuario,
            string pCorreo,
            List<RechazoEntrega> lista,
            string pUsermail,
            string pPwdmail,
            string psOrigen,
            string rutaLogo = @"C:\Media\Images\umbral.jpg")
        {
            if (lista == null || lista.Count == 0) throw new ArgumentException("No hay registros para notificar.", nameof(lista));
            string html = ConstruirHtml(lista, pUsuario, rutaLogo);
            Enviar(pCorreo, pUsermail, pPwdmail, "Rechazos de entrega desde " + psOrigen, html, rutaLogo);
        }

        // Enviar desde DataTable con las mismas columnas
        public static void EnviarCorreoRechazos(
            string pUsuario,
            string pCorreo,
            DataTable tabla,
            string pUsermail,
            string pPwdmail,
            string psOrigen,
            string rutaLogo = @"C:\Media\Images\umbral.jpg")
        {
            if (tabla == null || tabla.Rows.Count == 0) throw new ArgumentException("No hay registros para notificar.", nameof(tabla));
            var lista = Convertir(tabla);
            string html = ConstruirHtml(lista, pUsuario, rutaLogo);
            Enviar(pCorreo, pUsermail, pPwdmail, "Rechazos de entrega desde " + psOrigen, html, rutaLogo);
        }

        // -------- Construcción HTML --------

        private static string ConstruirHtml(List<RechazoEntrega> lista, string pUsuario, string rutaLogo)
        {
            // Hora local Guatemala
            DateTime ahoraGt;
            try
            {
                var tz = TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time");
                ahoraGt = TimeZoneInfo.ConvertTime(DateTime.UtcNow, tz);
            }
            catch
            {
                ahoraGt = DateTime.Now;
            }
            string saludo = ahoraGt.Hour < 12 ? "Buenos días" : (ahoraGt.Hour < 19 ? "Buenas tardes" : "Buenas noches");

            // Resúmenes (conteos)
            var porMotivo = lista
                .GroupBy(x => x.motivo)
                .Select(g => new { Motivo = g.Key, Cantidad = g.Count() })
                .OrderByDescending(x => x.Cantidad).ThenBy(x => x.Motivo)
                .ToList();

            var porEmpresa = lista
                .GroupBy(x => x.empresa)
                .Select(g => new { Empresa = g.Key, Cantidad = g.Count() })
                .OrderByDescending(x => x.Cantidad).ThenBy(x => x.Empresa)
                .ToList();

            var sb = new StringBuilder();
            sb.AppendLine("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-family:Segoe UI,Arial,sans-serif;font-size:13px;line-height:1.45;color:#222;\">");

            if (File.Exists(rutaLogo))
            {
                sb.AppendLine("<tr><td colspan=\"2\" style=\"padding-bottom:8px;\"><img src=\"cid:logo-umbral\" alt=\"Umbral\" style=\"max-width:240px;height:auto;\"/></td></tr>");
            }

            sb.AppendLine("<tr><td colspan=\"2\" style=\"height:8px;\"></td></tr>");
            sb.AppendLine("<tr><td colspan=\"2\"><strong>" + H(saludo) + " " + H(pUsuario) + "</strong></td></tr>");
            sb.AppendLine("<tr><td colspan=\"2\" style=\"height:8px;\"></td></tr>");
            sb.AppendLine("<tr><td colspan=\"2\">A la fecha " + ahoraGt.ToString("dd/MM/yyyy") + " a las " + ahoraGt.ToString("HH:mm:ss") + ", se detallan <strong>" + lista.Count + "</strong> registros de entregas rechazadas.</td></tr>");

            // --- Resumen por motivo ---
            sb.AppendLine("<tr><td colspan=\"2\" style=\"height:12px;\"></td></tr>");
            sb.AppendLine("<tr><td colspan=\"2\"><strong>Resumen por motivo</strong></td></tr>");
            sb.AppendLine("<tr><td colspan=\"2\">");
            sb.AppendLine("<table cellspacing=\"0\" cellpadding=\"6\" style=\"border-collapse:collapse;width:100%;border:1px solid #ddd;\">");
            sb.AppendLine("<tr style=\"background:#F8F8F8;\"><th align=\"left\">Motivo</th><th align=\"right\">Cantidad</th></tr>");
            foreach (var r in porMotivo)
                sb.AppendLine("<tr><td>" + H(r.Motivo) + "</td><td align=\"right\">" + r.Cantidad + "</td></tr>");
            sb.AppendLine("</table>");
            sb.AppendLine("</td></tr>");

            // --- Resumen por empresa ---
            sb.AppendLine("<tr><td colspan=\"2\" style=\"height:12px;\"></td></tr>");
            sb.AppendLine("<tr><td colspan=\"2\"><strong>Resumen por empresa</strong></td></tr>");
            sb.AppendLine("<tr><td colspan=\"2\">");
            sb.AppendLine("<table cellspacing=\"0\" cellpadding=\"6\" style=\"border-collapse:collapse;width:100%;border:1px solid #ddd;\">");
            sb.AppendLine("<tr style=\"background:#F8F8F8;\"><th align=\"left\">Empresa</th><th align=\"right\">Cantidad</th></tr>");
            foreach (var r in porEmpresa)
                sb.AppendLine("<tr><td>" + H(r.Empresa) + "</td><td align=\"right\">" + r.Cantidad + "</td></tr>");
            sb.AppendLine("</table>");
            sb.AppendLine("</td></tr>");

            // --- Detalle ---
            sb.AppendLine("<tr><td colspan=\"2\" style=\"height:16px;\"></td></tr>");
            sb.AppendLine("<tr><td colspan=\"2\" style=\"background:#F8F8F8;padding:6px 4px;\"><strong>Detalle</strong></td></tr>");
            sb.AppendLine("<tr><td colspan=\"2\">");
            sb.AppendLine("<table cellspacing=\"0\" cellpadding=\"6\" style=\"border-collapse:collapse;width:100%;border:1px solid #ddd;\">");

            // Encabezados
            sb.AppendLine("<tr style=\"background:#F8F8F8;\">" +
                          "<th align=\"left\">Empresa</th>" +
                          "<th align=\"left\">Tipo</th>" +
                          "<th align=\"left\">Número</th>" +
                          "<th align=\"left\">Fecha Fc</th>" +
                          "<th align=\"left\">Cliente</th>" +
                          "<th align=\"left\">Transporte</th>" +
                          "<th align=\"left\">Fecha Rechazo</th>" +
                          "<th align=\"left\">Motivo Rechazo</th>" +
                          "<th align=\"left\">Comentarios Piloto</th>" +
                          "<th align=\"left\">POD</th></tr>");

            var ciGT = CultureInfo.CreateSpecificCulture("es-GT");

            foreach (var x in lista)
            {
                string estadoHtml = string.Equals(x.EstadoCliente, "rejected", StringComparison.OrdinalIgnoreCase)
                    ? "<span style=\"color:#b00020;font-weight:600;\">rejected</span>"
                    : H(x.EstadoCliente);

                string fechaTxt = x.fecha == DateTime.MinValue ? "" : x.fecha.ToString("dd/MM/yyyy", ciGT);
                string fechaRechazoTxt = x.fecha_rechazo == DateTime.MinValue ? "" : x.fecha_rechazo.ToString("dd/MM/yyyy HH:mm", ciGT);
                string podLink = string.IsNullOrWhiteSpace(x.pdf_pod) ? "" : "<a href=\"" + H(x.pdf_pod) + "\" target=\"_blank\">POD</a>";
                string trackingLink = string.IsNullOrWhiteSpace(x.tracking_url) ? "" : "<a href=\"" + H(x.tracking_url) + "\" target=\"_blank\">Tracking</a>";

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + H(x.empresa) + "</td>");
                sb.AppendLine("<td>" + H(x.tipoDocto) + "</td>");
                sb.AppendLine("<td>" + H(x.Numero) + "</td>");
                sb.AppendLine("<td>" + H(fechaTxt) + "</td>");
                sb.AppendLine("<td>" + H(x.CodigoCliente) + "</td>");
                sb.AppendLine("<td>" + H(x.controlTransporte) + "</td>");
                sb.AppendLine("<td>" + H(fechaRechazoTxt) + "</td>");
                sb.AppendLine("<td>" + H(x.motivo) + "</td>");
                sb.AppendLine("<td>" + H(x.comentario_piloto) + "</td>");
                sb.AppendLine("<td>" + podLink + "</td>");
                
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table>");
            sb.AppendLine("</td></tr>");
            sb.AppendLine("</table>");

            return sb.ToString();
        }

        // -------- SMTP + helpers --------

        private static void Enviar(string pCorreo, string pUsermail, string pPwdmail, string asunto, string htmlBody, string rutaLogo)
        {
            if (string.IsNullOrWhiteSpace(pCorreo)) throw new ArgumentException("Destinatario vacío.", nameof(pCorreo));

            string plain = StripHtmlForPlain(htmlBody);

            using (var smtp = new SmtpClient("smtp.office365.com", 587))
            {
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(pUsermail, pPwdmail);
                smtp.Timeout = 60000;

                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress("umbralcorp@umbralcorp.com", "Notificaciones", Encoding.UTF8);
                    foreach (var addr in pCorreo.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
                        mail.To.Add(addr.Trim());

                    mail.Subject = asunto;
                    mail.SubjectEncoding = Encoding.UTF8;
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.IsBodyHtml = true;

                    var textView = AlternateView.CreateAlternateViewFromString(plain, Encoding.UTF8, MediaTypeNames.Text.Plain);
                    var htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, Encoding.UTF8, MediaTypeNames.Text.Html);

                    if (File.Exists(rutaLogo))
                    {
                        var logo = new LinkedResource(rutaLogo, MediaTypeNames.Image.Jpeg);
                        logo.ContentId = "logo-umbral";
                        logo.TransferEncoding = TransferEncoding.Base64;
                        htmlView.LinkedResources.Add(logo);
                    }

                    mail.AlternateViews.Add(textView);
                    mail.AlternateViews.Add(htmlView);

                    smtp.Send(mail);
                }
            }
        }

        private static string H(string s)
        {
            return WebUtility.HtmlEncode(s ?? string.Empty);
        }

        private static string StripHtmlForPlain(string html)
        {
            if (string.IsNullOrWhiteSpace(html)) return string.Empty;
            var noTags = Regex.Replace(html, "<[^>]+>", " ");
            noTags = WebUtility.HtmlDecode(noTags);
            return Regex.Replace(noTags, "\\s{2,}", " ").Trim();
        }

        // -------- Conversión DataTable -> Lista --------

        private static List<RechazoEntrega> Convertir(DataTable tabla)
        {
            var l = new List<RechazoEntrega>();
            foreach (DataRow r in tabla.Rows)
            {
                var x = new RechazoEntrega
                {
                    tipoDocto = SafeStr(r, "tipoDocto"),
                    Numero = SafeStr(r, "Numero"),
                    controlTransporte = SafeStr(r, "controlTransporte"),
                    EstadoCliente = SafeStr(r, "EstadoCliente"),
                    motivo = SafeStr(r, "motivo"),
                    CodigoCliente = SafeStr(r, "CodigoCliente"),
                    pdf_pod = SafeStr(r, "pdf_pod"),
                    tracking_url = SafeStr(r, "tracking_url"),
                    empresa = SafeStr(r, "empresa"),
                    comentario_piloto = SafeStr(r, "comentario_piloto"),
                    fecha = SafeDate(r, "fecha")
                };
                l.Add(x);
            }
            return l;
        }

        private static string SafeStr(DataRow r, string col)
        {
            if (!r.Table.Columns.Contains(col) || r.IsNull(col)) return null;
            return Convert.ToString(r[col]);
        }

        private static DateTime SafeDate(DataRow r, string col)
        {
            if (!r.Table.Columns.Contains(col) || r.IsNull(col)) return DateTime.MinValue;
            var s = Convert.ToString(r[col]);
            DateTime dt;
            if (DateTime.TryParse(s, out dt)) return dt;

            var formats = new[] { "yyyy-MM-dd HH:mm:ss.fff", "yyyy-MM-dd HH:mm:ss" };
            if (DateTime.TryParseExact(s, formats, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out dt))
                return dt;

            return DateTime.MinValue;
        }
    }




public class ReservaProducto
    {
        public string empresa { get; set; }
        public string no_orden { get; set; }
        public string bodega { get; set; }
        public DateTime fecha { get; set; }
        public string dua { get; set; }
        public string proveedor { get; set; }
        public string usuario { get; set; }
        public DateTime fecha_hora_grabo { get; set; }
        public string estatus { get; set; }
        public string producto { get; set; }
        public string glosa { get; set; }
        public decimal cantidad { get; set; }
        public decimal bultos { get; set; }
        public string lote { get; set; }
    }

    public static class MailReservas
    {
        public static void EnviarCorreoReservas(
            string pUsuario,
            string pCorreo,
            List<ReservaProducto> reservas,
            string pUsermail,
            string pPwdmail,
            string psOrigen,
            string rutaLogo = @"C:\Media\Images\umbral.jpg")
        {
            if (reservas == null || reservas.Count == 0)
                throw new ArgumentException("No hay registros de reservas para enviar.");

            string html = ConstruirHtml(reservas, pUsuario, rutaLogo);
            Enviar(pCorreo, pUsermail, pPwdmail, "Listado de Reservas de Producto desde " + psOrigen, html, rutaLogo);
        }

        private static string ConstruirHtml(List<ReservaProducto> reservas, string pUsuario, string rutaLogo)
        {
            DateTime ahora = DateTime.Now;
            string saludo = ahora.Hour < 12 ? "Buenos días" : (ahora.Hour < 19 ? "Buenas tardes" : "Buenas noches");

            var sb = new StringBuilder();
            sb.AppendLine("<table width='100%' cellspacing='0' cellpadding='0' style='font-family:Segoe UI,Arial,sans-serif;font-size:13px;line-height:1.4;color:#222;'>");

            // Logo superior
            if (File.Exists(rutaLogo))
                sb.AppendLine("<tr><td colspan='11' style='padding-bottom:8px;'><img src='cid:logo-umbral' alt='Umbral' style='max-width:240px;height:auto;'/></td></tr>");

            sb.AppendLine("<tr><td colspan='11'><strong>" + saludo + " " + H(pUsuario) + "</strong></td></tr>");
            sb.AppendLine("<tr><td colspan='11'>A la fecha " + ahora.ToString("dd/MM/yyyy HH:mm:ss") + " se reportan <strong>" + reservas.Count + "</strong> reservas de producto.</td></tr>");
            sb.AppendLine("<tr><td colspan='11' style='height:12px;'></td></tr>");

            // Agrupar por usuario y empresa
            var grupos = reservas
                .OrderBy(r => r.fecha)
                .GroupBy(r => r.usuario)
                .OrderBy(g => g.Key);

            foreach (var usuarioGrupo in grupos)
            {
                sb.AppendLine("<tr><td colspan='11' style='background:#e6f0ff;padding:6px;border:1px solid #ccc;'><strong>Usuario: " + H(usuarioGrupo.Key) + "</strong></td></tr>");

                var empresas = usuarioGrupo
                    .GroupBy(r => r.empresa)
                    .OrderBy(e => e.Key);

                foreach (var empresaGrupo in empresas)
                {
                    sb.AppendLine("<tr><td colspan='11' style='background:#f2f2f2;padding:4px;border:1px solid #ccc;'><strong>Empresa: " + H(empresaGrupo.Key) + "</strong></td></tr>");
                    sb.AppendLine("<tr><td colspan='11'>");
                    sb.AppendLine("<table cellspacing='0' cellpadding='5' style='border-collapse:collapse;width:100%;border:1px solid #ddd;font-size:12px;'>");

                    // Encabezado de tabla
                    sb.AppendLine("<tr style='background:#f8f8f8;font-weight:bold;'>" +
                        "<th align='left'>No Orden</th>" +
                        "<th align='left'>Bodega</th>" +
                        "<th align='left'>Fecha</th>" +
                        "<th align='left'>DUA</th>" +
                        "<th align='left'>Proveedor</th>" +
                        "<th align='left'>Estatus</th>" +
                        "<th align='left'>Producto</th>" +
                        "<th align='left'>Glosa</th>" +
                        "<th align='right'>Cantidad</th>" +
                        "<th align='right'>Bultos</th>" +
                        "<th align='left'>Lote</th>" +
                        "</tr>");

                    // Filas
                    foreach (var r in empresaGrupo.OrderBy(r => r.fecha))
                    {
                        sb.AppendLine("<tr>");
                        sb.AppendLine("<td>" + H(r.no_orden) + "</td>");
                        sb.AppendLine("<td>" + H(r.bodega) + "</td>");
                        sb.AppendLine("<td>" + r.fecha.ToString("dd/MM/yyyy") + "</td>");
                        sb.AppendLine("<td>" + H(r.dua) + "</td>");
                        sb.AppendLine("<td>" + H(r.proveedor) + "</td>");
                        sb.AppendLine("<td>" + H(r.estatus) + "</td>");
                        sb.AppendLine("<td>" + H(r.producto) + "</td>");
                        sb.AppendLine("<td>" + H(r.glosa) + "</td>");
                        sb.AppendLine("<td align='right'>" + r.cantidad.ToString("N0", CultureInfo.InvariantCulture) + "</td>");
                        sb.AppendLine("<td align='right'>" + r.bultos.ToString("N0", CultureInfo.InvariantCulture) + "</td>");
                        sb.AppendLine("<td>" + H(r.lote) + "</td>");
                        sb.AppendLine("</tr>");
                    }

                    sb.AppendLine("</table>");
                    sb.AppendLine("</td></tr>");
                    sb.AppendLine("<tr><td colspan='11' style='height:10px;'></td></tr>");
                }
            }

            sb.AppendLine("</table>");
            return sb.ToString();
        }

        private static void Enviar(string pCorreo, string pUsermail, string pPwdmail, string asunto, string htmlBody, string rutaLogo)
        {
            string plain = StripHtml(htmlBody);

            using (var smtp = new SmtpClient("smtp.office365.com", 587))
            {
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(pUsermail, pPwdmail);
                smtp.Timeout = 60000;

                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress("umbralcorp@umbralcorp.com", "Notificaciones", Encoding.UTF8);
                    foreach (var addr in pCorreo.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
                        mail.To.Add(addr.Trim());

                    mail.Subject = asunto;
                    mail.SubjectEncoding = Encoding.UTF8;
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.IsBodyHtml = true;

                    var textView = AlternateView.CreateAlternateViewFromString(plain, Encoding.UTF8, MediaTypeNames.Text.Plain);
                    var htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, Encoding.UTF8, MediaTypeNames.Text.Html);

                    if (File.Exists(rutaLogo))
                    {
                        var logo = new LinkedResource(rutaLogo, MediaTypeNames.Image.Jpeg);
                        logo.ContentId = "logo-umbral";
                        logo.TransferEncoding = TransferEncoding.Base64;
                        htmlView.LinkedResources.Add(logo);
                    }

                    mail.AlternateViews.Add(textView);
                    mail.AlternateViews.Add(htmlView);

                    smtp.Send(mail);
                }
            }
        }

        private static string H(string s) => WebUtility.HtmlEncode(s ?? string.Empty);

        private static string StripHtml(string html)
        {
            if (string.IsNullOrWhiteSpace(html)) return string.Empty;
            string noTags = Regex.Replace(html, "<[^>]+>", " ");
            noTags = WebUtility.HtmlDecode(noTags);
            return Regex.Replace(noTags, "\\s{2,}", " ").Trim();
        }
    }


}
