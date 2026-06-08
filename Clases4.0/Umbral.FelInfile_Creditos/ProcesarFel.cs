using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Transaccional;
using Newtonsoft;
using Newtonsoft.Json;
using Umbral.FelInFile.Extension;
using System.Net;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace Umbral.FelInFile
{
    public class ProcesarFel
    {

        public string DirectorioWalmart { get; set; }

        Conexion oFlex = new Conexion("Flexline");
        Conexion oCorp = new Conexion("corporativo");

        V2 oCorporativo = new V2("prueba");
        apifel4.RequestCertificacionFel requestv1;
        conectorfelv2.RequestCertificacionFel request;


        public bool EnviarDteInfile(
            DataSet pDsDatosFel,
            string pDirectorioFel)
        {

            bool lRespuesta = false;

            try
            {

                oFlex.open();

            }
            catch (Exception ex)
            {

                string lErr = "";

                lErr = $"{ex.Source}, {ex.TargetSite.Name}\r\n" +
                    $"\tEn: {ex.StackTrace}\r\n";

                if (ex.InnerException == null)
                {

                    lErr = $"{lErr}\tExcepcion: {ex.Message}\r\n";

                }
                else
                {

                    lErr = $"{lErr}\tExcepcion: {ex.InnerException.Message}\r\n";

                }

                oFlex.Escribir_Log(lErr);
                return false;

            }

            foreach (DataRow dr in pDsDatosFel.Tables["pedidos"].Rows)
            {

                try
                {

                    request = new conectorfelv2.RequestCertificacionFel();

                    int noLinea = 0;
                    string response;
                    bool Datos_generales;
                    bool Datos_emisor;
                    bool Datos_receptor;
                    bool Frases;
                    bool Item_un_impuesto;
                    bool Total_impuestos;
                    bool Totales;
                    bool Adenda;
                    bool Agregar_adenda;
                    bool Factura_cambiaria;
                    bool Abonos_factura_cambiaria;
                    bool Complemento_exportacion;
                    bool Complemento_NotaCredito;

                    string strQry = $"pa_sel_um_gen_tabcod NULL, 'FEL_EMISOR', {dr["empresa"].ToString()}";
                    DataTable dtDatosEmisor = oFlex.Obtiene(strQry);
                    Dictionary<string, Tuple<string, string, string>> dicDatosEmisor =
                        new Dictionary<string, Tuple<string, string, string>>();

                    try
                    {

                        foreach (DataRow dato in dtDatosEmisor.Rows)
                        {

                            dicDatosEmisor.Add(
                                dato["CODIGO"].ToString(),
                                new Tuple<string, string, string>(
                                    dato["DESCRIPCION"].ToString(),
                                    dato["TEXTO"].ToString(),
                                    dato["TEXTO1"].ToString()));

                        }

                    }
                    catch (Exception ex)
                    {

                        string lErr = "";

                        lErr = $"{ex.Source}, {ex.TargetSite.Name}\r\n" +
                            $"\tEn: {ex.StackTrace}\r\n";

                        if (ex.InnerException == null)
                        {

                            lErr = $"{lErr}\tExcepcion: {ex.Message}\r\n";

                        }
                        else
                        {

                            lErr = $"{lErr}\tExcepcion: {ex.InnerException.Message}\r\n";

                        }

                        oFlex.Escribir_Log(lErr);

                    }

                    /* +--------------------------------------
                     * |           FACTURA NORMAL
                     * +--------------------------------------*/

                    if (dr["documento"].ToString() == "Factura")
                    {

                        //if(dr["correlativo"].ToString() != "3128")
                        //{
                        //    continue;
                        //}

                        if (dr["serie"].ToString() == "")
                        {
                            if (dr["vigencia"].ToString() != "S")
                            {
                                //continue;
                            }
                        }
                        else
                        {
                            continue;
                        }

                        if (dr["exento"].ToString() == "Si")
                        {
                            Datos_generales =
                                request.Datos_generales(
                                    "USD",
                                    Convert.ToDateTime(dr["fecha"].ToString(), new System.Globalization.CultureInfo("es-GT")).ToString("yyyy-MM-dd"),
                                    "FCAM",
                                    "SI",
                                    "", "");
                        }
                        else if (dr["Exento"].ToString() == "No")
                        {
                            Datos_generales =
                                request.Datos_generales(
                                    "GTQ",
                                    Convert.ToDateTime(dr["fecha"].ToString(), new System.Globalization.CultureInfo("es-GT")).ToString("yyyy-MM-dd"),
                                    "FCAM",
                                    "",
                                    "", "");
                        }

                        string strQuery =
                            $"pa_sel_empresa_fel {dr["empresa"].ToString()}";

                        DataTable tblDatosEmpresa = oFlex.Obtiene(strQuery);

                        /* +----------------------------------
                         * |     ENCABEZADO DE LA FACTURA
                         * +----------------------------------*/

                        if (tblDatosEmpresa != null)
                        {

                            if (tblDatosEmpresa.Rows.Count > 0)
                            {

                                Datos_emisor = request.Datos_emisor(
                                    dicDatosEmisor["TIPO_IVA"].Item1,//TipoAfiliacionIVA
                                    Convert.ToInt32(
                                        dicDatosEmisor["ESTABLECIMIENTO"].Item2),
                                    dicDatosEmisor["ESTABLECIMIENTO"].Item3,//CodigoPostal
                                    dicDatosEmisor["EMAIL"].Item1,
                                    "GT",
                                    tblDatosEmpresa.Rows[0]["PAIS"].ToString(),
                                    tblDatosEmpresa.Rows[0]["CIUDAD"].ToString(),
                                    dicDatosEmisor["DIRECCION_RTU"].Item1,//tblDatosEmpresa.Rows[0]["COMUNA"].ToString(),
                                    tblDatosEmpresa.Rows[0]["RUT"].ToString().Replace("-", ""),
                                    dicDatosEmisor["NOMBRE_FISCAL"].Item1,//tblDatosEmpresa.Rows[0]["NOMBRE"].ToString(),
                                    dicDatosEmisor["NOMBRE_COMERCIAL"].Item1);

                            }

                        }

                        string TipoCodLegal = "";

                        if (dr["codlegal"].ToString().Length >= 3)
                        {
                            if (dr["codlegal"].ToString().Substring(0, 3) == "CUI" || dr["codlegal"].ToString().Substring(0, 3) == "DPI")
                            {
                                TipoCodLegal = "CUI";
                            }
                            else if (dr["codlegal"].ToString().Substring(0, 3) == "EXT")
                            {
                                TipoCodLegal = "EXT";
                            }
                            else
                            {
                                TipoCodLegal = "";
                            }
                        }

                        if (dr["exento"].ToString() == "Si")
                        {
                            Datos_receptor = request.Datos_receptor(
                                dr["codlegal"].ToString().Replace("-", "") == "C/F" ? "CF" : dr["codlegal"].ToString().Replace("-", "").Replace("CUI", "").Replace("EXT", ""),
                                dr["nombre_cliente"].ToString().Replace("'", "").Replace("\"", "").Replace("&", "&amp;"),
                                "01001",
                                dicDatosEmisor["EMAIL"].Item1,
                                "GT",
                                "GUATEMALA",
                                "GUATEMALA",
                                dr["direccion"].ToString() == "" ? "CIUDAD" : dr["direccion"].ToString(),
                                TipoCodLegal);
                        }
                        else
                        {
                            Datos_receptor = request.Datos_receptor(
                                dr["codlegal"].ToString().Replace("-", "") == "C/F" ? "CF" : dr["codlegal"].ToString().Replace("-", "").Replace("CUI", "").Replace("EXT", ""),
                                dr["nombre_cliente"].ToString().Replace("'", "").Replace("\"", "").Replace("&", "&amp;"),
                                "01001",
                                dicDatosEmisor["EMAIL"].Item1,
                                "GT",
                                "GUATEMALA",
                                "GUATEMALA",
                                dr["direccion"].ToString() == "" ? "CIUDAD" : dr["direccion"].ToString(),
                                TipoCodLegal);

                        }

                        /* +----------------------------------
                            * |     DETALLE DE LA FACTURA
                            * +----------------------------------*/


                        List<string> lstFrases = new List<string>(dicDatosEmisor["CODIGO_FRASE"].Item1.Split(';'));

                        foreach (string frase in lstFrases)
                        {
                            Frases = request.Frases(
                                Convert.ToInt32(frase.Split(',')[0]),
                                Convert.ToInt32(frase.Split(',')[1]), "", "");
                        }

                        if (dr["exento"].ToString() == "Si")
                        {
                            Frases = request.Frases(4, 1, "", "");
                        }

                        decimal TotalFactura = 0;
                        decimal TotalIva = 0;
                        int TotalSkus = 0;
                        decimal TotalUnidades = 0;
                        decimal dTotalDescuento = 0;
                        decimal dTotalFactura = 0;

                        pDsDatosFel.Tables["detalle_pedidos"].DefaultView.RowFilter =
                            $"empresa='{dr["empresa"].ToString()}' and " +
                            $"tipodocto='{dr["tipodocto"].ToString()}' and " +
                            $"numero='{dr["numero"].ToString()}'";

                        try
                        {
                            if (Convert.ToDecimal(dr["PorcDescuento"].ToString()) > 0)
                            {

                                foreach (DataRowView det in pDsDatosFel.Tables["detalle_pedidos"].DefaultView)
                                {

                                    dTotalFactura +=
                                        Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString());

                                }

                                dTotalDescuento = dTotalFactura * (Convert.ToDecimal(dr["PorcDescuento"].ToString()) / 100);

                            }
                        }
                        catch (Exception ex)
                        {

                            oFlex.Escribir_Log("FEL: El porcentaje de descuento viene vacio.");

                            string lErr = "";

                            lErr = $"{ex.Source}, {ex.TargetSite.Name}\r\n" +
                                $"\tEn: {ex.StackTrace}\r\n";

                            if (ex.InnerException == null)
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.Message}\r\n";

                            }
                            else
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.InnerException.Message}\r\n";

                            }

                            oFlex.Escribir_Log(lErr);

                        }

                        decimal dTotalSumaDetalle = 0;

                        foreach (DataRowView det in pDsDatosFel.Tables["detalle_pedidos"].DefaultView)
                        {

                            noLinea++;

                            TotalFactura += Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6);
                            TotalUnidades += Convert.ToDecimal(det["Cantidad"].ToString());
                            TotalSkus = pDsDatosFel.Tables["detalle_pedidos"].DefaultView.Count;

                            if (dTotalDescuento > 0)
                            {

                                /**+-----------------------------------------
                                 * |              TOTAL DE LINEA
                                 * +-----------------------------------------*/

                                decimal lTotal =
                                        decimal.Parse(det["Cantidad"].ToString()) * Convert.ToDecimal(det["Precio"].ToString());

                                /**+---------------------------------------------------------
                                 * |  CALCULA EL DESCUENTO PROPORCIONAL AL TOTAL DE LINEA
                                 * +---------------------------------------------------------*/

                                decimal dPorcDescPorItem = (lTotal * 100) / dTotalFactura;
                                decimal dDescuentoPorItem = dTotalDescuento * (dPorcDescPorItem / 100);
                                decimal dMontoGravable =
                                    (lTotal - dDescuentoPorItem) / Convert.ToDecimal("1.12");
                                decimal dIvaTotalSinDesc =
                                    ((lTotal - dDescuentoPorItem) / Convert.ToDecimal("1.12")) * Convert.ToDecimal("0.12");
                                TotalIva += dIvaTotalSinDesc;

                                dTotalSumaDetalle += Math.Round((lTotal - dDescuentoPorItem), 6);

                                /**+-----------------------------------------
                                 * |         AGREGA DETALLE DE LINEA
                                 * +-----------------------------------------*/

                                Item_un_impuesto = request.Item_un_impuesto(
                                    "B",
                                    "UND",
                                    det["Cantidad"].ToString(),
                                    $"{det["Producto"].ToString()}|" +
                                    $"{det["UNIDAD"].ToString()}|" +
                                    $"{det["GLOSA"].ToString().Replace("&", "&amp;")}|" +
                                    $"{det["volumen"].ToString()}|" +
                                    $"{det["psugerido"].ToString()}|" +
                                    $"{det["Impdist"].ToString()}",
                                    noLinea,
                                    Math.Round(Convert.ToDecimal(det["Precio"].ToString()), 6).ToString(),
                                    lTotal.ToString(),
                                    dDescuentoPorItem.ToString(),
                                    Math.Round((lTotal - dDescuentoPorItem), 6).ToString(),
                                    "IVA",
                                    dr["exento"].ToString() == "Si" ? 2 : 1,
                                    "",
                                    Math.Round(dMontoGravable, 6).ToString(),
                                    Math.Round(dIvaTotalSinDesc, 6).ToString()
                                );

                            }
                            else
                            {

                                decimal lIvaLinea = ((Math.Round(Convert.ToDecimal(det["Cantidad"].ToString()), 6) * Math.Round(Convert.ToDecimal(det["Precio"].ToString()), 6)) / 1.12M) * 0.12M;
                                //TotalIva += Math.Round(Convert.ToDecimal(det["Impuesto"].ToString()), 6);
                                TotalIva += lIvaLinea;

                                Item_un_impuesto = request.Item_un_impuesto(
                                    "B",
                                    "UND",
                                    det["Cantidad"].ToString(),
                                    $"{det["Producto"].ToString()}|" +
                                    $"{det["UNIDAD"].ToString()}|" +
                                    $"{det["GLOSA"].ToString().Replace("&", "&amp;")}|" +
                                    $"{det["volumen"].ToString()}|" +
                                    $"{det["psugerido"].ToString()}|" +
                                    $"{det["Impdist"].ToString()}",
                                    noLinea,
                                    Math.Round(Convert.ToDecimal(det["Precio"].ToString()), 6).ToString(),
                                    Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6).ToString(),
                                    "0",
                                    Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6).ToString(),
                                    "IVA",
                                    dr["exento"].ToString() == "Si" ? 2 : 1,
                                    "",
                                    dr["exento"].ToString() == "No" ?
                                    Math.Round(Convert.ToDecimal(det["IMPORTE_NETO_INGRESO"].ToString()), 6).ToString() :
                                    Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6).ToString(),
                                    Math.Round(lIvaLinea, 6).ToString()//Math.Round(Convert.ToDecimal(det["Impuesto"].ToString()), 6).ToString()
                                );

                            }

                        }

                        if (dr["exento"].ToString() == "No")
                        {
                            Total_impuestos = request.total_impuestos("IVA", Math.Round(TotalIva, 2).ToString());
                        }
                        else if (dr["exento"].ToString() == "Si")
                        {
                            Total_impuestos = request.total_impuestos("IVA", "0");
                        }

                        Totales = request.Totales((TotalFactura - dTotalDescuento).ToString());

                        Factura_cambiaria = request.Complemento_cambiaria("Cambiaria", "Cambiaria", "http://www.sat.gob.gt/fel/cambiaria.xsd");

                        Abonos_factura_cambiaria =
                            request.Abonos_factura_cambiaria(DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd"), 1, "0.00");

                        if (dr["exento"].ToString() == "Si")
                        {

                            Complemento_exportacion = request.Complemento_exportacion(
                                "Exportacion",
                                "Exportacion",
                                "http:////www.sat.gob.gt//fel//exportacion.xsd",
                                "40050",
                                "40051",
                                dicDatosEmisor["CODIGO_EXPORTADOR"].Item1,//oCorporativo.Datos.Tables["Table"].Rows[0]["CodigoExportador"].ToString(),
                                dr["direccion"].ToString(),
                                dr["direccion"].ToString(),
                                "FOB",
                                dr["nombre_cliente"].ToString().Replace("&", "&amp;"),
                                dr["nombre_cliente"].ToString().Replace("&", "&amp;"),
                                dicDatosEmisor["NOMBRE_COMERCIAL"].Item1,
                                dicDatosEmisor["REFERENCIA_EXENTA"].Item1);

                        }

                        /* +--------------------------------
                            * |      INFORMACION ADICIONAL
                            * +--------------------------------*/

                        try
                        {

                            Adenda = request.Adendas("Observaciones", dr["comentario"].ToString());
                            Adenda = request.Adendas("Codigo", dr["ctacte"].ToString());
                            Adenda = request.Adendas("Bodega", dr["Bodega"].ToString());
                            Adenda = request.Adendas("Ejecutivo", dr["Vendedor"].ToString());
                            Adenda = request.Adendas("Ref", dr["direccion"].ToString());
                            Adenda = request.Adendas("Pedido", dr["numero"].ToString());
                            Adenda = request.Adendas("Condiciones", dr["forma_pago"].ToString());
                            Adenda = request.Adendas("LPrecios", dr["LisPrecio"].ToString());
                            Adenda = request.Adendas("TDocto", dr["tipodocto"].ToString());
                            Adenda = request.Adendas("TSkus", TotalSkus.ToString());
                            Adenda = request.Adendas("TUnidades", TotalUnidades.ToString());
                            Adenda = request.Adendas("valor1", "");
                            Adenda = request.Adendas("valor2", "");

                            if (dr["exento"].ToString() == "Si")
                            {

                                decimal dValorFlete = 0;
                                decimal dValorSeguro = 0;
                                decimal dValorCIF = 0;

                                if (dr["F_FLETE"].ToString() != "")
                                {
                                    dValorFlete = Convert.ToDecimal(dr["F_FLETE"].ToString());
                                    dValorCIF += dValorFlete;
                                }

                                if (dr["F_SEGURO"].ToString() != "")
                                {
                                    dValorSeguro = Convert.ToDecimal(dr["F_SEGURO"].ToString());
                                    dValorCIF += dValorSeguro;
                                }

                                if (dr["FLETE"].ToString() != "")
                                {
                                    dValorFlete = Convert.ToDecimal(dr["FLETE"].ToString());
                                    dValorCIF += dValorFlete;
                                }

                                if (dr["SEGURO"].ToString() != "")
                                {
                                    dValorSeguro = Convert.ToDecimal(dr["SEGURO"].ToString());
                                    dValorCIF += dValorSeguro;
                                }

                                Adenda = request.Adendas("Seguro", Math.Round(dValorSeguro, 2).ToString());
                                Adenda = request.Adendas("Flete", Math.Round(dValorSeguro, 2).ToString());
                                Adenda = request.Adendas("CIF", Math.Round(dValorSeguro, 2).ToString());

                            }

                        }
                        catch (Exception ex)
                        {

                            string lErr = "";

                            lErr = $"{ex.Source}, {ex.TargetSite.Name}\r\n" +
                                $"\tEn: {ex.StackTrace}\r\n";

                            if (ex.InnerException == null)
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.Message}\r\n";

                            }
                            else
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.InnerException.Message}\r\n";

                            }

                            oFlex.Escribir_Log(lErr);

                        }

                        Agregar_adenda = request.Agregar_adendas();

                        Dictionary<string, string> dictResponse = null;
                        response = null;

                        /* +--------------------------------
                            * |           ENVIO FEL
                            * +--------------------------------*/

                        try
                        {

                            response = request.enviar_peticion_fel(
                                dicDatosEmisor["PREFIJO"].Item1,
                                dicDatosEmisor["LLAVE"].Item1,
                                $"{dr["empresa"].ToString()}{dr["tipodocto"].ToString()}{dr["correlativo"].ToString()}",
                                dicDatosEmisor["EMAIL_COPIA"].Item1,
                                dicDatosEmisor["ALIAS_PFX"].Item1,
                                dicDatosEmisor["LLAVE_PFX"].Item1,
                                true);

                            /*+-------------------------------
                               |     PARSE JSON RESPUESTA
                               +-------------------------------*/

                            string jsonString = "";
                            if (response != null)
                            {
                                jsonString =
                               ExtractJsonObject(response);
                                //dictResponse =
                                //    response.ParseResponse(pDirectorioFel);

                            }
                            var jsonRespuestaObject = JsonConvert.DeserializeObject<respuestaFel>(jsonString);

                            if (true)
                            {

                                if (jsonRespuestaObject.resultado)
                                {

                                    string lsSQL =
                                        $"pa_ins_um_gen_log_documento_fel_v2 " +
                                        $"'{dr["empresa"].ToString()}', " +
                                        $"'{dr["tipodocto"].ToString()}', " +
                                        $"'{dr["numero"].ToString()}', " +
                                        $"'{DateTime.Now.ToString("HHmmss")}', " +
                                        $"NULL, " +
                                        $"{TotalFactura}, " +
                                        $"{noLinea.ToString()}";

                                    oFlex.Ingresa(lsSQL);
                                    if (oFlex.Codigo_error > 0)
                                        oFlex.Escribir_Log("No se pudo ingresar el log.");

                                    lsSQL =
                                        $"pa_ins_fel_docto_cert " +
                                        $"'{dr["empresa"].ToString()}', " +
                                        $"'{dr["tipodocto"].ToString()}', " +
                                        $"{dr["correlativo"].ToString()}, " +
                                        $"'{dr["numero"].ToString()}', " +
                                        $"'{DateTime.Now.ToString("yyyy-MM-dd")}', " +
                                        $"'{jsonRespuestaObject.uuid}', " +
                                        $"'{jsonRespuestaObject.serie}', " +
                                        $"'{jsonRespuestaObject.numero}', " +
                                        $"'{jsonRespuestaObject.fecha.ToString("yyyy-MM-dd HH:mm")}'";

                                    oFlex.Ingresa(lsSQL);
                                    if (oFlex.Codigo_error > 0)
                                        oFlex.Escribir_Log("No se pudo ingresar el log.");

                                    Tuple<string, string, string, string> tpPedidoEnviado =
                                        new Tuple<string, string, string, string>(
                                            dr["empresa"].ToString(),
                                            dr["tipodocto"].ToString(),
                                            dr["correlativo"].ToString(),
                                            dr["numero"].ToString());

                                    lRespuesta = CrearDoctoFelFlexline(
                                        pDsDatosFel,
                                        jsonRespuestaObject.uuid,
                                        jsonRespuestaObject.serie,
                                        jsonRespuestaObject.numero,
                                        jsonRespuestaObject.fecha.ToString("yyyy-MM-dd HH:mm"),
                                        tpPedidoEnviado,
                                        Convert.ToDateTime(dr["fecha"].ToString(), new System.Globalization.CultureInfo("es-GT")));

                                    if (lRespuesta)
                                    {
                                        lsSQL = $"pa_upd_um_gen_log_documento_face_proceso_comentario " +
                                            $"'{dr["empresa"].ToString()}', " +
                                            $"'{dr["tipodocto"].ToString()}', " +
                                            $"'{dr["numero"].ToString()}', " +
                                            $"''";

                                        oFlex.Actualiza(lsSQL);
                                        if (oFlex.Codigo_error > 0)
                                            oFlex.Escribir_Log("No se pudo ingresar el log.");
                                    }

                                }
                                else
                                {

                                    string lsSQL =
                                        $"pa_ins_um_gen_log_documento_face " +
                                        $"'{dr["empresa"].ToString()}', " +
                                        $"'{dr["tipodocto"].ToString()}', " +
                                        $"'{dr["numero"].ToString()}', " +
                                        $"'{DateTime.Now.ToString("HHmmss")}', " +
                                        $"NULL, " +
                                        $"{TotalFactura}, " +
                                        $"{noLinea.ToString()}";

                                    oFlex.Ingresa(lsSQL);
                                    if (oFlex.Codigo_error > 0)
                                        oFlex.Escribir_Log("No se pudo ingresar el log.");

                                    var jo = JObject.Parse(jsonString);

                                    string MensajeInfile = jo["descripcion_errores"][0]["mensaje_error"].ToString();
                                    oFlex.Escribir_Log(MensajeInfile);

                                    lsSQL =
                                         $"pa_upd_um_gen_log_documento_face_proceso_comentario" +
                                         $"'{dr["empresa"].ToString()}'," +
                                         $"'{dr["tipodocto"].ToString()}', " +
                                         $"'{dr["numero"].ToString()}', " +
                                         $"'{MensajeInfile}'";

                                    oFlex.Actualiza(lsSQL);

                                    //foreach (var k in dictResponse.Keys)
                                    //{

                                    //    lsSQL =
                                    //         $"pa_upd_um_gen_log_documento_face_proceso_comentario" +
                                    //         $"'{dr["empresa"].ToString()}'," +
                                    //         $"'{dr["tipodocto"].ToString()}', " +
                                    //         $"'{dr["numero"].ToString()}', " +
                                    //         $"'{dictResponse[k]}'";

                                    //    oFlex.Actualiza(lsSQL);

                                    //}

                                }

                            }

                        }
                        catch (Exception ex)
                        {

                            string lErr = "";

                            lErr = $"{ex.Source}, {ex.TargetSite.Name}\r\n" +
                                $"\tEn: {ex.StackTrace}\r\n";

                            if (ex.InnerException == null)
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.Message}\r\n";

                            }
                            else
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.InnerException.Message}\r\n";

                            }

                            oFlex.Escribir_Log(lErr);

                        }

                    }
                    else if (
                        dr["documento"].ToString().Contains("Credito") &&
                        (dr["tipodocto"].ToString().Contains("NOTA DE ABONO") ||
                        dr["tipodocto"].ToString().Contains("NOTA DE ABONO CTE") ||
                        dr["tipodocto"].ToString().Contains("NOTA ABONO CTE DOLAR")))
                    {

                        Datos_generales =
                            request.Datos_generales(
                                "GTQ",
                                Convert.ToDateTime(dr["fecha"].ToString(), new System.Globalization.CultureInfo("es-GT")).ToString("yyyy-MM-dd"),//DateTime.Now.ToString("yyyy-MM-dd"),
                                "NABN",
                                "",
                                "", "");

                        string strQuery =
                            $"pa_sel_empresa_fel {dr["empresa"].ToString()}";

                        DataTable tblDatosEmpresa = oFlex.Obtiene(strQuery);

                        /* +----------------------------------
                         * |     ENCABEZADO DE LA NOTA
                         * +----------------------------------*/

                        if (tblDatosEmpresa != null)
                        {

                            if (tblDatosEmpresa.Rows.Count > 0)
                            {

                                Datos_emisor = request.Datos_emisor(
                                    dicDatosEmisor["TIPO_IVA"].Item1,//TipoAfiliacionIVA
                                    Convert.ToInt32(
                                        dicDatosEmisor["ESTABLECIMIENTO"].Item2),
                                    dicDatosEmisor["ESTABLECIMIENTO"].Item3,//CodigoPostal
                                    dicDatosEmisor["EMAIL"].Item1,
                                    "GT",
                                    tblDatosEmpresa.Rows[0]["PAIS"].ToString(),
                                    tblDatosEmpresa.Rows[0]["CIUDAD"].ToString(),
                                    dicDatosEmisor["DIRECCION_RTU"].Item1,
                                    tblDatosEmpresa.Rows[0]["RUT"].ToString().Replace("-", ""),
                                    dicDatosEmisor["NOMBRE_FISCAL"].Item1,
                                    dicDatosEmisor["NOMBRE_COMERCIAL"].Item1);

                            }

                        }

                        string TipoCodLegal = "";

                        if (dr["codlegal"].ToString().Length >= 3)
                        {
                            if (dr["codlegal"].ToString().Substring(0, 3) == "CUI" || dr["codlegal"].ToString().Substring(0, 3) == "DPI")
                            {
                                TipoCodLegal = "CUI";
                            }
                            else if (dr["codlegal"].ToString().Substring(0, 3) == "EXT")
                            {
                                TipoCodLegal = "EXT";
                            }
                            else
                            {
                                TipoCodLegal = "";
                            }
                        }

                        Datos_receptor = request.Datos_receptor(
                            dr["codlegal"].ToString().Replace("-", "") == "C/F" ? "CF" : dr["codlegal"].ToString().Replace("-", "").Replace("CUI", "").Replace("EXT", ""),
                            dr["nombre_cliente"].ToString().Replace("'", "").Replace("\"", "").Replace("&", "&amp;"),
                            "01001",
                            dicDatosEmisor["EMAIL"].Item1,
                            "GT",
                            "GUATEMALA",
                            "GUATEMALA",
                            dr["direccion"].ToString() == "" ? "CIUDAD" : dr["direccion"].ToString(),
                            TipoCodLegal);

                        /* +----------------------------------
                         * |     DETALLE DE LA NOTA
                         * +----------------------------------*/

                        List<string> lstFrases = new List<string>(dicDatosEmisor["CODIGO_FRASE"].Item1.Split(';'));

                        //foreach (string frase in lstFrases)
                        //{
                        //    Frases = request.Frases(
                        //        Convert.ToInt32(frase.Split(',')[0]),
                        //        Convert.ToInt32(frase.Split(',')[1]), "", "");
                        //}

                        if (dr["exento"].ToString() == "Si")
                        {
                            Frases = request.Frases(4, 1, "", "");
                        }

                        /* +----------------------------------
                        * |     Definir porcentaje de encabezado
                        * +----------------------------------*/
                        decimal TotalFactura = 0;
                        decimal TotalIva = 0;
                        int TotalSkus = 0;
                        decimal TotalUnidades = 0;
                        decimal dTotalDescuento = 0;
                        decimal dTotalFactura = 0;


                        pDsDatosFel.Tables["detalle_pedidos"].DefaultView.RowFilter =
                        $"empresa='{dr["empresa"].ToString()}' and " +
                        $"tipodocto='{dr["tipodocto"].ToString()}' and " +
                        $"numero='{dr["numero"].ToString()}'";

                        try
                        {
                            if (Convert.ToDecimal(dr["PorcDescuento"].ToString()) > 0)
                            {

                                foreach (DataRowView det in pDsDatosFel.Tables["detalle_pedidos"].DefaultView)
                                {

                                    dTotalFactura +=
                                        Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString());

                                }

                                dTotalDescuento = dTotalFactura * (Convert.ToDecimal(dr["PorcDescuento"].ToString()) / 100);

                            }
                        }
                        catch (Exception ex)
                        {

                            oFlex.Escribir_Log("FEL: El porcentaje de descuento viene vacio.");

                            string lErr = "";

                            lErr = $"{ex.Source}, {ex.TargetSite.Name}\r\n" +
                                $"\tEn: {ex.StackTrace}\r\n";

                            if (ex.InnerException == null)
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.Message}\r\n";

                            }
                            else
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.InnerException.Message}\r\n";

                            }

                            oFlex.Escribir_Log(lErr);

                        }




                        foreach (DataRowView det in pDsDatosFel.Tables["detalle_pedidos"].DefaultView)
                        {

                            noLinea++;

                            /**+---------------------------------------------------------
                             * |  CALCULA EL DESCUENTO PROPORCIONAL AL TOTAL DE LINEA
                             * +---------------------------------------------------------*/
                            //decimal lTotal =Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString());
                            //decimal dPorcDescPorItem = (lTotal * 100) / dTotalFactura;
                            //decimal dDescuentoPorItem = dTotalDescuento * (dPorcDescPorItem / 100);
                            //decimal dMontoGravable =
                            //    (lTotal - dDescuentoPorItem) / Convert.ToDecimal("1.12");
                            //decimal dIvaTotalSinDesc =
                            //    ((lTotal - dDescuentoPorItem) / Convert.ToDecimal("1.12")) * Convert.ToDecimal("0.12");
                            //TotalIva += dIvaTotalSinDesc;




                            //decimal lDescuento = Convert.ToDecimal(det["ValPorcentajeDR1"].ToString()) > 0M ? Convert.ToDecimal(det["ValPorcentajeDR1"].ToString()) * -1M : 0M;

                            TotalFactura += Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6);
                            TotalUnidades += Convert.ToDecimal(det["Cantidad"].ToString());
                            TotalSkus = pDsDatosFel.Tables["detalle_pedidos"].DefaultView.Count;

                            decimal lTotalLinea = Convert.ToDecimal(det["Cantidad"].ToString()) * Convert.ToDecimal(det["Precio"].ToString());

                            TotalIva += (lTotalLinea / 1.12M) * 0.12M;
                            //TotalIva += Math.Round(Convert.ToDecimal(det["Impuesto"].ToString()), 6);

                            Item_un_impuesto = request.Item_sin_impuesto(
                                "B",
                                "UND",
                                det["Cantidad"].ToString(),
                                $"{det["Producto"].ToString()}|" +
                                $"{det["UNIDAD"].ToString()}|" +
                                $"{det["GLOSA"].ToString().Replace("&", "&amp;")}|" +
                                $"{det["volumen"].ToString()}|" +
                                $"{det["psugerido"].ToString()}|" +
                                $"{det["Impdist"].ToString()}",
                                noLinea,
                                Math.Round(((Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString())) / 1.12M) / Convert.ToDecimal(det["Cantidad"].ToString()), 6).ToString(),
                                Math.Round((Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString())) / 1.12M, 6).ToString(),
                                "0",
                                Math.Round((Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString())) / 1.12M, 6).ToString());

                        }

                        Totales = request.Totales((TotalFactura - TotalIva).ToString());

                        try
                        {
                            Adenda = request.Adendas("Observaciones", dr["comentario"].ToString().Replace("&", "&amp;"));
                            Adenda = request.Adendas("Codigo", dr["ctacte"].ToString());
                            Adenda = request.Adendas("Bodega", dr["Bodega"].ToString());
                            Adenda = request.Adendas("Ejecutivo", dr["Vendedor"].ToString());
                            Adenda = request.Adendas("Ref", dr["direccion"].ToString());
                            Adenda = request.Adendas("Pedido", dr["numero"].ToString());
                            Adenda = request.Adendas("Condiciones", dr["forma_pago"].ToString());
                            Adenda = request.Adendas("LPrecios", dr["LisPrecio"].ToString());
                            Adenda = request.Adendas("TDocto", dr["tipodocto"].ToString().Replace("&", "&amp;"));
                            Adenda = request.Adendas("TSkus", TotalSkus.ToString());
                            Adenda = request.Adendas("TUnidades", TotalUnidades.ToString());
                        }
                        catch (Exception ex)
                        {

                            string lErr = "";

                            lErr = $"{ex.Source}, {ex.TargetSite.Name}\r\n" +
                                $"\tEn: {ex.StackTrace}\r\n";

                            if (ex.InnerException == null)
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.Message}\r\n";

                            }
                            else
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.InnerException.Message}\r\n";

                            }

                            oFlex.Escribir_Log(lErr);

                        }

                        Dictionary<string, string> dictResponse = null;
                        response = null;

                        Agregar_adenda = request.Agregar_adendas();

                        response = request.enviar_peticion_fel(
                            dicDatosEmisor["PREFIJO"].Item1,
                            dicDatosEmisor["LLAVE"].Item1,
                            $"{dr["empresa"].ToString()}{dr["tipodocto"].ToString().Replace("&", "&amp;")}{dr["correlativo"].ToString()}",
                            dicDatosEmisor["EMAIL_COPIA"].Item1,
                            dicDatosEmisor["ALIAS_PFX"].Item1,
                            dicDatosEmisor["LLAVE_PFX"].Item1,
                            true);

                        /*+-------------------------------
                          |     PARSE JSON RESPUESTA
                          +-------------------------------*/
                        string jsonString = "";
                        if (response != null)
                        {
                            jsonString =
                           ExtractJsonObject(response);
                            //dictResponse =
                            //    response.ParseResponse(pDirectorioFel);

                        }
                        var jsonRespuestaObject = JsonConvert.DeserializeObject<respuestaFel>(jsonString);

                        if (true)
                        {

                            if (jsonRespuestaObject.resultado)
                            {

                                string lsSQL =
                                    $"pa_ins_um_gen_log_documento_face " +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"'{DateTime.Now.ToString("HHmmss")}', " +
                                    $"NULL, " +
                                    $"{TotalFactura}, " +
                                    $"{noLinea.ToString()}";

                                oFlex.Ingresa(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                lsSQL =
                                      $"pa_ins_fel_docto_cert " +
                                      $"'{dr["empresa"].ToString()}', " +
                                      $"'{dr["tipodocto"].ToString()}', " +
                                      $"{dr["correlativo"].ToString()}, " +
                                      $"'{dr["numero"].ToString()}', " +
                                      $"'{DateTime.Now.ToString("yyyy-MM-dd")}', " +
                                      $"'{jsonRespuestaObject.uuid}', " +
                                      $"'{jsonRespuestaObject.serie}', " +
                                      $"'{jsonRespuestaObject.numero}', " +
                                      $"'{jsonRespuestaObject.fecha.ToString("yyyy-MM-dd HH:mm")}'";

                                oFlex.Ingresa(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                //pa_upd_fel_factura
                                lsSQL = $"pa_upd_fel_nota_credito" +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"'{jsonRespuestaObject.uuid}', " +
                                    $"'{jsonRespuestaObject.serie}', " +
                                    $"'{jsonRespuestaObject.numero}'";

                                oFlex.Actualiza(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                lsSQL = $"pa_upd_um_gen_log_documento_face_proceso_comentario " +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"''";

                                oFlex.Actualiza(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                            }
                            else
                            {

                                string lsSQL =
                                           $"pa_ins_um_gen_log_documento_face " +
                                           $"'{dr["empresa"].ToString()}', " +
                                           $"'{dr["tipodocto"].ToString()}', " +
                                           $"'{dr["numero"].ToString()}', " +
                                           $"'{DateTime.Now.ToString("HHmmss")}', " +
                                           $"NULL, " +
                                           $"{TotalFactura}, " +
                                           $"{noLinea.ToString()}";

                                oFlex.Ingresa(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                var jo = JObject.Parse(jsonString);

                                string MensajeInfile = jo["descripcion_errores"][0]["mensaje_error"].ToString();
                                oFlex.Escribir_Log(MensajeInfile);

                                lsSQL =
                                     $"pa_upd_um_gen_log_documento_face_proceso_comentario" +
                                     $"'{dr["empresa"].ToString()}'," +
                                     $"'{dr["tipodocto"].ToString()}', " +
                                     $"'{dr["numero"].ToString()}', " +
                                     $"'{MensajeInfile}'";

                                oFlex.Actualiza(lsSQL);

                                //foreach (var k in dictResponse.Keys)
                                //{

                                //    lsSQL =
                                //         $"pa_upd_um_gen_log_documento_face_proceso_comentario" +
                                //         $"'{dr["empresa"].ToString()}'," +
                                //         $"'{dr["tipodocto"].ToString()}', " +
                                //         $"'{dr["numero"].ToString()}', " +
                                //         $"'{dictResponse[k]}'";

                                //    oFlex.Actualiza(lsSQL);

                                //}

                            }

                        }

                    }
                    else if (dr["documento"].ToString() == "Credito")
                    {

                        Datos_generales =
                            request.Datos_generales(
                                "GTQ",
                                Convert.ToDateTime(dr["fecha"].ToString(), new System.Globalization.CultureInfo("es-GT")).ToString("yyyy-MM-dd"),//DateTime.Now.ToString("yyyy-MM-dd"),
                                "NCRE",
                                "",
                                "", "");

                        string strQuery =
                            $"pa_sel_empresa_fel {dr["empresa"].ToString()}";

                        DataTable tblDatosEmpresa = oFlex.Obtiene(strQuery);

                        /* +----------------------------------
                         * |     ENCABEZADO DE LA NOTA
                         * +----------------------------------*/

                        if (tblDatosEmpresa != null)
                        {

                            if (tblDatosEmpresa.Rows.Count > 0)
                            {

                                Datos_emisor = request.Datos_emisor(
                                    dicDatosEmisor["TIPO_IVA"].Item1,//TipoAfiliacionIVA
                                    Convert.ToInt32(
                                        dicDatosEmisor["ESTABLECIMIENTO"].Item2),
                                    dicDatosEmisor["ESTABLECIMIENTO"].Item3,//CodigoPostal
                                    dicDatosEmisor["EMAIL"].Item1,
                                    "GT",
                                    tblDatosEmpresa.Rows[0]["PAIS"].ToString(),
                                    tblDatosEmpresa.Rows[0]["CIUDAD"].ToString(),
                                    dicDatosEmisor["DIRECCION_RTU"].Item1,//tblDatosEmpresa.Rows[0]["COMUNA"].ToString(),
                                    tblDatosEmpresa.Rows[0]["RUT"].ToString().Replace("-", ""),
                                    dicDatosEmisor["NOMBRE_FISCAL"].Item1,//tblDatosEmpresa.Rows[0]["NOMBRE"].ToString(),
                                    dicDatosEmisor["NOMBRE_COMERCIAL"].Item1);

                            }

                        }

                        string TipoCodLegal = "";

                        if (dr["codlegal"].ToString().Length >= 3)
                        {
                            if (dr["codlegal"].ToString().Substring(0, 3) == "CUI" || dr["codlegal"].ToString().Substring(0, 3) == "DPI")
                            {
                                TipoCodLegal = "CUI";
                            }
                            else if (dr["codlegal"].ToString().Substring(0, 3) == "EXT")
                            {
                                TipoCodLegal = "EXT";
                            }
                            else
                            {
                                TipoCodLegal = "";
                            }
                        }




                        Datos_receptor = request.Datos_receptor(
                            dr["codlegal"].ToString().Replace("-", "") == "C/F" ? "CF" : dr["codlegal"].ToString().Replace("-", "").Replace("CUI", "").Replace("EXT", ""),
                            dr["nombre_cliente"].ToString().Replace("'", "").Replace("\"", "").Replace("&", "&amp;"),
                            "01001",
                            dicDatosEmisor["EMAIL"].Item1,
                            "GT",
                            "GUATEMALA",
                            "GUATEMALA",
                            dr["direccion"].ToString() == "" ? "CIUDAD" : dr["direccion"].ToString(),
                            TipoCodLegal);


                        /* +----------------------------------
                         * |     DETALLE DE LA NOTA
                         * +----------------------------------*/

                        List<string> lstFrases = new List<string>(dicDatosEmisor["CODIGO_FRASE"].Item1.Split(';'));

                        foreach (string frase in lstFrases)
                        {
                            Frases = request.Frases(
                                Convert.ToInt32(frase.Split(',')[0]),
                                Convert.ToInt32(frase.Split(',')[1]), "", "");
                        }

                        if (dr["exento"].ToString() == "Si")
                        {
                            Frases = request.Frases(4, 1, "", "");
                        }

                        decimal TotalFactura = 0;
                        decimal TotalIva = 0;
                        int TotalSkus = 0;
                        decimal TotalUnidades = 0;
                        decimal dTotalDescuento = 0;
                        decimal dTotalFactura = 0;

                        pDsDatosFel.Tables["detalle_pedidos"].DefaultView.RowFilter =
                            $"empresa='{dr["empresa"].ToString()}' and " +
                            $"tipodocto='{dr["tipodocto"].ToString()}' and " +
                            $"numero='{dr["numero"].ToString()}'";

                        try
                        {
                            if (Convert.ToDecimal(dr["PorcDescuento"].ToString()) > 0)
                            {

                                foreach (DataRowView det in pDsDatosFel.Tables["detalle_pedidos"].DefaultView)
                                {

                                    dTotalFactura +=
                                        Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString());

                                }

                                dTotalDescuento = dTotalFactura * (Convert.ToDecimal(dr["PorcDescuento"].ToString()) / 100);

                            }
                        }
                        catch (Exception ex)
                        {

                            oFlex.Escribir_Log("FEL: El porcentaje de descuento viene vacio.");

                            string lErr = "";

                            lErr = $"{ex.Source}, {ex.TargetSite.Name}\r\n" +
                                $"\tEn: {ex.StackTrace}\r\n";

                            if (ex.InnerException == null)
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.Message}\r\n";

                            }
                            else
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.InnerException.Message}\r\n";

                            }

                            oFlex.Escribir_Log(lErr);

                        }

                        decimal dTotalSumaDetalle = 0;

                        foreach (DataRowView det in pDsDatosFel.Tables["detalle_pedidos"].DefaultView)
                        {

                            noLinea++;

                            TotalFactura += Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6);
                            TotalUnidades += Convert.ToDecimal(det["Cantidad"].ToString());
                            TotalSkus = pDsDatosFel.Tables["detalle_pedidos"].DefaultView.Count;

                            if (dTotalDescuento > 0)
                            {

                                /**+-----------------------------------------
                                 * |              TOTAL DE LINEA
                                 * +-----------------------------------------*/

                                decimal lTotal =
                                        decimal.Parse(det["Cantidad"].ToString()) * Convert.ToDecimal(det["Precio"].ToString());

                                /**+---------------------------------------------------------
                                 * |  CALCULA EL DESCUENTO PROPORCIONAL AL TOTAL DE LINEA
                                 * +---------------------------------------------------------*/

                                decimal dPorcDescPorItem = (lTotal * 100) / dTotalFactura;
                                decimal dDescuentoPorItem = dTotalDescuento * (dPorcDescPorItem / 100);
                                decimal dMontoGravable =
                                    (lTotal - dDescuentoPorItem) / Convert.ToDecimal("1.12");
                                decimal dIvaTotalSinDesc =
                                    ((lTotal - dDescuentoPorItem) / Convert.ToDecimal("1.12")) * Convert.ToDecimal("0.12");
                                TotalIva += dIvaTotalSinDesc;

                                dTotalSumaDetalle += Math.Round((lTotal - dDescuentoPorItem), 6);

                                /**+-----------------------------------------
                                 * |         AGREGA DETALLE DE LINEA
                                 * +-----------------------------------------*/

                                Item_un_impuesto = request.Item_un_impuesto(
                                    "B",
                                    "UND",
                                    det["Cantidad"].ToString(),
                                    $"{det["Producto"].ToString()}|" +
                                    $"{det["UNIDAD"].ToString()}|" +
                                    $"{det["GLOSA"].ToString().Replace("&", "&amp;")}|" +
                                    $"{det["volumen"].ToString()}|" +
                                    $"{det["psugerido"].ToString()}|" +
                                    $"{det["Impdist"].ToString()}",
                                    noLinea,
                                    Math.Round(Convert.ToDecimal(det["Precio"].ToString()), 6).ToString(),
                                    lTotal.ToString(),
                                    dDescuentoPorItem.ToString(),
                                    Math.Round((lTotal - dDescuentoPorItem), 6).ToString(),
                                    "IVA",
                                    dr["exento"].ToString() == "Si" ? 2 : 1,
                                    "",
                                    Math.Round(dMontoGravable, 6).ToString(),
                                    Math.Round(dIvaTotalSinDesc, 6).ToString()
                                );

                            }
                            else
                            {

                                decimal lValDesc = Convert.ToDecimal(det["ValPorcentajeDR1"].ToString()) * -1M;
                                decimal lValGrav = Math.Round((Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()) - lValDesc), 6) / 1.12M;
                                decimal lIvaGrav = (Math.Round((Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()) - lValDesc), 6) / 1.12M) * 0.12M;

                                dTotalDescuento += lValDesc;
                                TotalIva += Math.Round(lIvaGrav, 6);

                                Item_un_impuesto = request.Item_un_impuesto(
                                    "B",
                                    "UND",
                                    det["Cantidad"].ToString(),
                                    $"{det["Producto"].ToString()}|" +
                                    $"{det["UNIDAD"].ToString()}|" +
                                    $"{det["GLOSA"].ToString().Replace("&", "&amp;")}|" +
                                    $"{det["volumen"].ToString()}|" +
                                    $"{det["psugerido"].ToString()}|" +
                                    $"{det["Impdist"].ToString()}",
                                    noLinea,
                                    Math.Round(Convert.ToDecimal(det["Precio"].ToString()), 6).ToString(),
                                    Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6).ToString(),
                                    lValDesc.ToString(),
                                    Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()) - lValDesc, 6).ToString(),
                                    "IVA",
                                    dr["exento"].ToString() == "Si" ? 2 : 1,
                                    "",
                                    Math.Round(lValGrav, 6).ToString(),
                                    Math.Round(lIvaGrav, 6).ToString()
                                );

                            }

                        }

                        Total_impuestos = request.total_impuestos("IVA", Math.Round(TotalIva, 2).ToString()); //regresar a dos dec.

                        Totales = request.Totales(Math.Round((TotalFactura - dTotalDescuento), 2).ToString()); //regresar a dos dec.

                        /*
                         +---------------------------------------------------------
                         |  SE OBTIENEN LAS SERIES VALIDAS PARA APLICAR NOTAS
                         |  DE CREDITO
                         +---------------------------------------------------------
                         */

                        List<string> lSeries = new List<string>();
                        strQry = $"pa_sel_um_gen_tabcod NULL, 'FEL_SERIES_CREDITO', '{dr["empresa"].ToString()}'";
                        DataTable dtSeries = oFlex.Obtiene(strQry);

                        foreach (DataRow drs in dtSeries.Rows)
                        {

                            lSeries.Add(drs["DESCRIPCION"].ToString());

                        }

                        if (dr["SerieFace"].ToString().Contains("FECAM") == true)
                        {

                            if (dr["empresa"].ToString() == "DMARTE1")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString().Replace("&", "&amp;"),
                                        "2014-5-10000-1477",
                                        "Antiguo",
                                        "FECAM",
                                        dr["NumeroAutFace"].ToString());

                            }
                            else if (dr["empresa"].ToString() == "CODICASA")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString(),
                                        "2014-5-10000-1478",
                                        "Antiguo",
                                        "FECAM",
                                        dr["NumeroAutFace"].ToString());

                            }
                            else if (dr["empresa"].ToString() == "DIUVA")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString(),
                                        "2014-5-10000-1479",
                                        "Antiguo",
                                        "FECAM",
                                        dr["NumeroAutFace"].ToString());

                            }

                        }
                        else if (lSeries.Contains(dr["SerieFace"].ToString()))
                        {
                            request.Complemento_notas(
                                "Notas",
                                "Notas",
                                "http://www.sat.gob.gt/fel/notas.xsd",
                                Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString().Replace("&", "&amp;"),
                                dr["NoAutFel"].ToString(),
                                "",
                                dr["NoSerieFel"].ToString(),
                                dr["NumeroAutFace"].ToString());
                        }
                        else if (dr["SerieFace"].ToString() == "FACTURA AL COSTO" || dr["SerieFace"].ToString() == "FACTURA SERIE A")
                        {

                            if (dr["empresa"].ToString() == "DMARTE1")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString(),
                                        "2018-1-61-364915",
                                        "Antiguo",
                                        "A",
                                        dr["NumeroAutFace"].ToString());

                            }
                            else if (dr["empresa"].ToString() == "CODICASA")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString(),
                                        "2018-1-61-358882",
                                        "Antiguo",
                                        "A-1",
                                        dr["NumeroAutFace"].ToString());

                            }
                            else if (dr["empresa"].ToString() == "DIMAEXSA")
                            {

                                Complemento_NotaCredito =
                                         request.Complemento_notas(
                                             "Notas",
                                             "Notas",
                                             "http://www.sat.gob.gt/fel/notas.xsd",
                                             Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                             dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString(),
                                             "2020-1-61-1244339",
                                             "Antiguo",
                                             "A",
                                             dr["NumeroAutFace"].ToString());

                            }

                        }
                        else if (dr["SerieFace"].ToString() == "FACTURA SERIE G")
                        {

                            if (dr["empresa"].ToString() == "VINOTECA")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString(),
                                        "2018-1-61-491081",
                                        "Antiguo",
                                        "A",
                                        dr["NumeroAutFace"].ToString());

                            }

                        }

                        try
                        {
                            Adenda = request.Adendas("Observaciones", dr["comentario"].ToString().Replace("&", "&amp;"));
                            Adenda = request.Adendas("Codigo", dr["ctacte"].ToString());
                            Adenda = request.Adendas("Bodega", dr["Bodega"].ToString());
                            Adenda = request.Adendas("Ejecutivo", dr["Vendedor"].ToString());
                            Adenda = request.Adendas("Ref", dr["direccion"].ToString().Replace("&", "&amp;"));
                            Adenda = request.Adendas("Pedido", dr["numero"].ToString());
                            Adenda = request.Adendas("Condiciones", dr["forma_pago"].ToString());
                            Adenda = request.Adendas("LPrecios", dr["LisPrecio"].ToString());
                            Adenda = request.Adendas("TDocto", dr["tipodocto"].ToString().Replace("&", "&amp;"));
                            Adenda = request.Adendas("TSkus", TotalSkus.ToString());
                            Adenda = request.Adendas("TUnidades", TotalUnidades.ToString());
                        }
                        catch { }

                        Dictionary<string, string> dictResponse = null;
                        response = null;

                        Agregar_adenda = request.Agregar_adendas();

                        response = request.enviar_peticion_fel(
                            dicDatosEmisor["PREFIJO"].Item1,
                            dicDatosEmisor["LLAVE"].Item1,
                            $"{dr["empresa"].ToString()}{dr["tipodocto"].ToString().Replace("&", "&amp;")}{dr["correlativo"].ToString()}",
                            dicDatosEmisor["EMAIL_COPIA"].Item1,
                            dicDatosEmisor["ALIAS_PFX"].Item1,
                            dicDatosEmisor["LLAVE_PFX"].Item1,
                            true);

                        /*+-------------------------------
                          |     PARSE JSON RESPUESTA
                          +-------------------------------*/

                        string jsonString = "";
                        if (response != null)
                        {
                            jsonString =
                           ExtractJsonObject(response);
                            //dictResponse =
                            //    response.ParseResponse(pDirectorioFel);

                        }
                        var jsonRespuestaObject = JsonConvert.DeserializeObject<respuestaFel>(jsonString);

                        if (true)
                        {

                            if (jsonRespuestaObject.resultado)
                            {

                                string lsSQL =
                                    $"pa_ins_um_gen_log_documento_face " +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"'{DateTime.Now.ToString("HHmmss")}', " +
                                    $"NULL, " +
                                    $"{TotalFactura}, " +
                                    $"{noLinea.ToString()}";

                                oFlex.Ingresa(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                lsSQL =
                                    $"pa_ins_fel_docto_cert " +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"{dr["correlativo"].ToString()}, " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"'{DateTime.Now.ToString("yyyy-MM-dd")}', " +
                                    $"'{jsonRespuestaObject.uuid}', " +
                                    $"'{jsonRespuestaObject.serie}', " +
                                    $"'{jsonRespuestaObject.numero}', " +
                                    $"'{jsonRespuestaObject.fecha.ToString("yyyy-MM-dd HH:mm")}'";

                                oFlex.Ingresa(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                lsSQL = $"pa_upd_fel_nota_credito" +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"'{jsonRespuestaObject.uuid}', " +
                                    $"'{jsonRespuestaObject.serie}', " +
                                    $"'{jsonRespuestaObject.numero}'";

                                oFlex.Actualiza(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                lsSQL = $"pa_upd_um_gen_log_documento_face_proceso_comentario " +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"''";

                                oFlex.Actualiza(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                            }
                            else
                            {

                                string lsSQL =
                                          $"pa_ins_um_gen_log_documento_face " +
                                          $"'{dr["empresa"].ToString()}', " +
                                          $"'{dr["tipodocto"].ToString()}', " +
                                          $"'{dr["numero"].ToString()}', " +
                                          $"'{DateTime.Now.ToString("HHmmss")}', " +
                                          $"NULL, " +
                                          $"{TotalFactura}, " +
                                          $"{noLinea.ToString()}";

                                oFlex.Ingresa(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                var jo = JObject.Parse(jsonString);

                                string MensajeInfile = jo["descripcion_errores"][0]["mensaje_error"].ToString();
                                oFlex.Escribir_Log(MensajeInfile);

                                lsSQL =
                                     $"pa_upd_um_gen_log_documento_face_proceso_comentario" +
                                     $"'{dr["empresa"].ToString()}'," +
                                     $"'{dr["tipodocto"].ToString()}', " +
                                     $"'{dr["numero"].ToString()}', " +
                                     $"'{MensajeInfile}'";

                                oFlex.Actualiza(lsSQL);

                                //foreach (var k in dictResponse.Keys)
                                //{

                                //    lsSQL =
                                //         $"pa_upd_um_gen_log_documento_face_proceso_comentario" +
                                //         $"'{dr["empresa"].ToString()}'," +
                                //         $"'{dr["tipodocto"].ToString()}', " +
                                //         $"'{dr["numero"].ToString()}', " +
                                //         $"'{dictResponse[k]}'";

                                //    oFlex.Actualiza(lsSQL);

                                //}
                            }

                        }

                    }
                    else if (dr["documento"].ToString() == "Debito")
                    {

                        Datos_generales =
                            request.Datos_generales(
                                "GTQ",
                                Convert.ToDateTime(dr["fecha"].ToString(), new System.Globalization.CultureInfo("es-GT")).ToString("yyyy-MM-dd"),//DateTime.Now.ToString("yyyy-MM-dd"),
                                "NDEB",
                                "",
                                "", "");

                        string strQuery =
                            $"pa_sel_empresa_fel {dr["empresa"].ToString()}";

                        DataTable tblDatosEmpresa = oFlex.Obtiene(strQuery);

                        /* +----------------------------------
                         * |     ENCABEZADO DE LA NOTA
                         * +----------------------------------*/

                        if (tblDatosEmpresa != null)
                        {

                            if (tblDatosEmpresa.Rows.Count > 0)
                            {

                                Datos_emisor = request.Datos_emisor(
                                    dicDatosEmisor["TIPO_IVA"].Item1,//TipoAfiliacionIVA
                                    Convert.ToInt32(
                                        dicDatosEmisor["ESTABLECIMIENTO"].Item2),
                                    dicDatosEmisor["ESTABLECIMIENTO"].Item3,//CodigoPostal
                                    dicDatosEmisor["EMAIL"].Item1,
                                    "GT",
                                    tblDatosEmpresa.Rows[0]["PAIS"].ToString(),
                                    tblDatosEmpresa.Rows[0]["CIUDAD"].ToString(),
                                    dicDatosEmisor["DIRECCION_RTU"].Item1,//tblDatosEmpresa.Rows[0]["COMUNA"].ToString(),
                                    tblDatosEmpresa.Rows[0]["RUT"].ToString().Replace("-", ""),
                                    dicDatosEmisor["NOMBRE_FISCAL"].Item1,//tblDatosEmpresa.Rows[0]["NOMBRE"].ToString(),
                                    dicDatosEmisor["NOMBRE_COMERCIAL"].Item1);

                            }

                        }

                        string TipoCodLegal = "";


                        if (dr["codlegal"].ToString().Length >= 3)
                        {
                            if (dr["codlegal"].ToString().Substring(0, 3) == "CUI" || dr["codlegal"].ToString().Substring(0, 3) == "DPI")
                            {
                                TipoCodLegal = "CUI";
                            }
                            else if (dr["codlegal"].ToString().Substring(0, 3) == "EXT")
                            {
                                TipoCodLegal = "EXT";
                            }
                            else
                            {
                                TipoCodLegal = "";
                            }
                        }

                        Datos_receptor = request.Datos_receptor(
                            dr["codlegal"].ToString().Replace("-", "") == "C/F" ? "CF" : dr["codlegal"].ToString().Replace("-", "").Replace("CUI", "").Replace("EXT", ""),
                            dr["nombre_cliente"].ToString().Replace("'", "").Replace("\"", "").Replace("&", "&amp;"),
                            "01001",
                            dicDatosEmisor["EMAIL"].Item1,
                            "GT",
                            "GUATEMALA",
                            "GUATEMALA",
                            dr["direccion"].ToString() == "" ? "CIUDAD" : dr["direccion"].ToString(),
                            TipoCodLegal);

                        /* +----------------------------------
                         * |     DETALLE DE LA NOTA
                         * +----------------------------------*/


                        List<string> lstFrases = new List<string>(dicDatosEmisor["CODIGO_FRASE"].Item1.Split(';'));

                        foreach (string frase in lstFrases)
                        {
                            Frases = request.Frases(
                                Convert.ToInt32(frase.Split(',')[0]),
                                Convert.ToInt32(frase.Split(',')[1]), "", "");
                        }

                        if (dr["exento"].ToString() == "Si")
                        {
                            Frases = request.Frases(4, 1, "", "");
                        }




                        decimal TotalFactura = 0;
                        decimal TotalIva = 0;
                        int TotalSkus = 0;
                        decimal TotalUnidades = 0;
                        decimal dTotalDescuento = 0;
                        decimal dTotalFactura = 0;

                        pDsDatosFel.Tables["detalle_pedidos"].DefaultView.RowFilter =
                            $"empresa='{dr["empresa"].ToString()}' and " +
                            $"tipodocto='{dr["tipodocto"].ToString()}' and " +
                            $"numero='{dr["numero"].ToString()}'";

                        try
                        {
                            if (Convert.ToDecimal(dr["PorcDescuento"].ToString()) > 0)
                            {

                                foreach (DataRowView det in pDsDatosFel.Tables["detalle_pedidos"].DefaultView)
                                {

                                    dTotalFactura +=
                                        Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString());

                                }

                                dTotalDescuento = dTotalFactura * (Convert.ToDecimal(dr["PorcDescuento"].ToString()) / 100);

                            }
                        }
                        catch
                        {

                            oFlex.Escribir_Log("FEL: El porcentaje de descuento viene vacio.");

                        }

                        decimal dTotalSumaDetalle = 0;

                        foreach (DataRowView det in pDsDatosFel.Tables["detalle_pedidos"].DefaultView)
                        {

                            noLinea++;

                            TotalFactura += Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6);
                            TotalUnidades += Convert.ToDecimal(det["Cantidad"].ToString());
                            TotalSkus = pDsDatosFel.Tables["detalle_pedidos"].DefaultView.Count;

                            if (dTotalDescuento > 0)
                            {

                                /**+-----------------------------------------
                                 * |              TOTAL DE LINEA
                                 * +-----------------------------------------*/

                                decimal lTotal =
                                        decimal.Parse(det["Cantidad"].ToString()) * Convert.ToDecimal(det["Precio"].ToString());

                                /**+---------------------------------------------------------
                                 * |  CALCULA EL DESCUENTO PROPORCIONAL AL TOTAL DE LINEA
                                 * +---------------------------------------------------------*/

                                decimal dPorcDescPorItem = (lTotal * 100) / dTotalFactura;
                                decimal dDescuentoPorItem = dTotalDescuento * (dPorcDescPorItem / 100);
                                decimal dMontoGravable =
                                    (lTotal - dDescuentoPorItem) / Convert.ToDecimal("1.12");
                                decimal dIvaTotalSinDesc =
                                    ((lTotal - dDescuentoPorItem) / Convert.ToDecimal("1.12")) * Convert.ToDecimal("0.12");
                                TotalIva += dIvaTotalSinDesc;

                                dTotalSumaDetalle += Math.Round((lTotal - dDescuentoPorItem), 6);

                                /**+-----------------------------------------
                                 * |         AGREGA DETALLE DE LINEA
                                 * +-----------------------------------------*/

                                Item_un_impuesto = request.Item_un_impuesto(
                                    "B",
                                    "UND",
                                    det["Cantidad"].ToString(),
                                    $"{det["Producto"].ToString()}|" +
                                    $"{det["UNIDAD"].ToString()}|" +
                                    $"{det["GLOSA"].ToString().Replace("&", "&amp;")}|" +
                                    $"{det["volumen"].ToString()}|" +
                                    $"{det["psugerido"].ToString()}|" +
                                    $"{det["Impdist"].ToString()}",
                                    noLinea,
                                    Math.Round(Convert.ToDecimal(det["Precio"].ToString()), 6).ToString(),
                                    lTotal.ToString(),
                                    dDescuentoPorItem.ToString(),
                                    Math.Round((lTotal - dDescuentoPorItem), 6).ToString(),
                                    "IVA",
                                    dr["exento"].ToString() == "Si" ? 2 : 1,
                                    "",
                                    Math.Round(dMontoGravable, 6).ToString(),
                                    Math.Round(dIvaTotalSinDesc, 6).ToString()
                                );

                            }
                            else
                            {

                                TotalIva += Math.Round(Convert.ToDecimal(det["Impuesto"].ToString()), 6);

                                Item_un_impuesto = request.Item_un_impuesto(
                                    "B",
                                    "UND",
                                    det["Cantidad"].ToString(),
                                    $"{det["Producto"].ToString()}|" +
                                    $"{det["UNIDAD"].ToString()}|" +
                                    $"{det["GLOSA"].ToString().Replace("&", "&amp;")}|" +
                                    $"{det["volumen"].ToString()}|" +
                                    $"{det["psugerido"].ToString()}|" +
                                    $"{det["Impdist"].ToString()}",
                                    noLinea,
                                    Math.Round(Convert.ToDecimal(det["Precio"].ToString()), 6).ToString(),
                                    Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6).ToString(),
                                    "0",
                                    Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6).ToString(),
                                    "IVA",
                                    dr["exento"].ToString() == "Si" ? 2 : 1,
                                    "",
                                    dr["exento"].ToString() == "No" ?
                                    Math.Round(Convert.ToDecimal(det["IMPORTE_NETO_INGRESO"].ToString()), 6).ToString() :
                                    Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6).ToString(),
                                    Math.Round(Convert.ToDecimal(det["Impuesto"].ToString()), 6).ToString()
                                );

                            }

                        }

                        Total_impuestos = request.total_impuestos("IVA", Math.Round(TotalIva, 6).ToString());

                        Totales = request.Totales((TotalFactura - dTotalDescuento).ToString());

                        if (dr["SerieFace"].ToString().Contains("FECAM") == true)
                        {

                            if (dr["empresa"].ToString() == "DMARTE1")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString(),
                                        "2014-5-10000-1477",
                                        "Antiguo",
                                        "FECAM",
                                        dr["NumeroAutFace"].ToString());

                            }
                            else if (dr["empresa"].ToString() == "CODICASA")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString(),
                                        "2014-5-10000-1478",
                                        "Antiguo",
                                        "FECAM",
                                        dr["NumeroAutFace"].ToString());

                            }

                        }
                        else if (dr["SerieFace"].ToString() == "FEL" || dr["SerieFace"].ToString() == "FEL RE" || dr["SerieFace"].ToString() == "FEL AL COSTO")
                        {

                            request.Complemento_notas(
                                "Notas",
                                "Notas",
                                "http://www.sat.gob.gt/fel/notas.xsd",
                                Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"),
                                dr["comentario"].ToString(),
                                dr["NoAutFel"].ToString(),
                                "",
                                dr["NoSerieFel"].ToString(),
                                dr["NumeroAutFace"].ToString());

                        }
                        else if (dr["SerieFace"].ToString() == "FACTURA AL COSTO" || dr["SerieFace"].ToString() == "FACTURA SERIE A")
                        {

                            if (dr["empresa"].ToString() == "DMARTE1")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString().Replace("&", "&amp;"),
                                        "2018-1-61-364915",
                                        "Antiguo",
                                        "A",
                                        dr["NumeroAutFace"].ToString());

                            }
                            else if (dr["empresa"].ToString() == "CODICASA")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString(),
                                        "2018-1-61-358882",
                                        "Antiguo",
                                        "A-1",
                                        dr["NumeroAutFace"].ToString());

                            }

                        }
                        else if (dr["SerieFace"].ToString() == "FACTURA SERIE G")
                        {

                            if (dr["empresa"].ToString() == "VINOTECA")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString(),
                                        "2018-1-61-491081",
                                        "Antiguo",
                                        "A",
                                        dr["NumeroAutFace"].ToString());

                            }

                        }

                        try
                        {
                            Adenda = request.Adendas("Observaciones", dr["comentario"].ToString().Replace("&", "&amp;"));
                            Adenda = request.Adendas("Codigo", dr["ctacte"].ToString());
                            Adenda = request.Adendas("Bodega", dr["Bodega"].ToString());
                            Adenda = request.Adendas("Ejecutivo", dr["Vendedor"].ToString());
                            Adenda = request.Adendas("Ref", dr["direccion"].ToString());
                            Adenda = request.Adendas("Pedido", dr["numero"].ToString());
                            Adenda = request.Adendas("Condiciones", dr["forma_pago"].ToString().Replace("&", "&amp;"));
                            Adenda = request.Adendas("LPrecios", dr["LisPrecio"].ToString().Replace("&", "&amp;"));
                            Adenda = request.Adendas("TDocto", dr["tipodocto"].ToString().Replace("&", "&amp;"));
                            Adenda = request.Adendas("TSkus", TotalSkus.ToString());
                            Adenda = request.Adendas("TUnidades", TotalUnidades.ToString());
                        }
                        catch { }

                        Dictionary<string, string> dictResponse = null;
                        response = null;

                        Agregar_adenda = request.Agregar_adendas();

                        response = request.enviar_peticion_fel(
                            dicDatosEmisor["PREFIJO"].Item1,
                            dicDatosEmisor["LLAVE"].Item1,
                            $"{dr["empresa"].ToString()}{dr["tipodocto"].ToString().Replace("&", "&amp;")}{dr["correlativo"].ToString()}",
                            dicDatosEmisor["EMAIL_COPIA"].Item1,
                            dicDatosEmisor["ALIAS_PFX"].Item1,
                            dicDatosEmisor["LLAVE_PFX"].Item1,
                            true);

                        /*+-------------------------------
                          |     PARSE JSON RESPUESTA
                          +-------------------------------*/

                        if (response != null)
                        {

                            dictResponse =
                                response.ParseResponse(pDirectorioFel);

                        }

                        if (dictResponse != null)
                        {

                            if (dictResponse.ContainsKey("ERR_1") == false)
                            {

                                string lsSQL =
                                    $"pa_ins_um_gen_log_documento_face " +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"'{DateTime.Now.ToString("HHmmss")}', " +
                                    $"NULL, " +
                                    $"{TotalFactura}, " +
                                    $"{noLinea.ToString()}";

                                oFlex.Ingresa(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                lsSQL =
                                    $"pa_ins_fel_docto_cert " +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"{dr["correlativo"].ToString()}, " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"'{DateTime.Now.ToString("yyyy-MM-dd")}', " +
                                    $"'{dictResponse["uuid"]}', " +
                                    $"'{dictResponse["serie"]}', " +
                                    $"'{dictResponse["numero"]}', " +
                                    $"'{dictResponse["fecha_cert"]}'";

                                oFlex.Ingresa(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                lsSQL = $"pa_upd_fel_nota_credito" +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"'{dictResponse["uuid"]}', " +
                                    $"'{dictResponse["serie"]}', " +
                                    $"'{dictResponse["numero"]}'";

                                oFlex.Actualiza(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                lsSQL = $"pa_upd_um_gen_log_documento_face_proceso_comentario " +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"''";

                                oFlex.Actualiza(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                            }
                            else
                            {

                                string lsSQL =
                                    $"pa_ins_um_gen_log_documento_face " +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"'{DateTime.Now.ToString("HHmmss")}', " +
                                    $"NULL, " +
                                    $"{TotalFactura}, " +
                                    $"{noLinea.ToString()}";

                                oFlex.Ingresa(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                foreach (var k in dictResponse.Keys)
                                {

                                    lsSQL =
                                         $"pa_upd_um_gen_log_documento_face_proceso_comentario" +
                                         $"'{dr["empresa"].ToString()}'," +
                                         $"'{dr["tipodocto"].ToString()}', " +
                                         $"'{dr["numero"].ToString()}', " +
                                         $"'{dictResponse[k]}'";

                                    oFlex.Actualiza(lsSQL);

                                }

                            }

                        }

                    }

                }
                catch (Exception ex)
                {

                    oFlex.Escribir_Log("FEL: No se pudo enviar la factura a InFile");
                    oFlex.Escribir_Log($"FEL: {ex.Message}");
                    try
                    {
                        oFlex.Escribir_Log($"FEL: {ex.InnerException.Message}");
                    }
                    catch { }

                    return false;

                }

            }

            return lRespuesta;

        }

        public bool EnviarDteInfileXml(
            DataSet pDsDatosFel,
            string pDirectorioFel)
        {


            request = new conectorfelv2.RequestCertificacionFel();

            int noLinea = 0;
            string response;
            bool Datos_generales;
            bool Datos_emisor;
            bool Datos_receptor;
            bool Frases;
            bool Item_un_impuesto;
            bool Total_impuestos;
            bool Totales;
            bool Adenda;
            bool Agregar_adenda;
            bool Factura_cambiaria;
            bool Abonos_factura_cambiaria;
            bool Complemento_exportacion;
            bool Complemento_NotaCredito;

            bool lRespuesta = false;
            //HttpWebRequest lSolicitudInFile = (HttpWebRequest)WebRequest.Create("https://certificador.feel.com.gt/fel/certificacion/dte/");

            try
            {

                oFlex.open();
                oCorp.open();

            }
            catch (Exception ex)
            {

                oFlex.Escribir_Log("FEL: No se pudo establecer la conexion a BDFlexline");
                oFlex.Escribir_Log($"FEL: {ex.Message}");
                return false;

            }

            XNamespace lNamespace = "http://www.sat.gob.gt/dte/fel/0.2.0";

            foreach (DataRow dr in pDsDatosFel.Tables["pedidos"].Rows)
            {

                HttpWebRequest lSolicitudInFile = (HttpWebRequest)WebRequest.Create("https://certificador.feel.com.gt/fel/certificacion/v2/dte");
                XElement lDte = XElement.Parse(FelInFileCreditos.Properties.Resources.PlantillaWM);

                XPathNavigator XNav = null;
                XNav = lDte.CreateNavigator();

                try
                {


                    //request = new apifel4.RequestCertificacionFel();
                    request = new conectorfelv2.RequestCertificacionFel();


                    string strQry = $"pa_sel_um_gen_tabcod NULL, 'FEL_EMISOR', {dr["empresa"].ToString()}";
                    DataTable dtDatosEmisor = oFlex.Obtiene(strQry);
                    Dictionary<string, Tuple<string, string, string>> dicDatosEmisor =
                        new Dictionary<string, Tuple<string, string, string>>();

                    try
                    {

                        foreach (DataRow dato in dtDatosEmisor.Rows)
                        {

                            dicDatosEmisor.Add(
                                dato["CODIGO"].ToString(),
                                new Tuple<string, string, string>(
                                    dato["DESCRIPCION"].ToString(),
                                    dato["TEXTO"].ToString(),
                                    dato["TEXTO1"].ToString()));

                        }

                    }
                    catch { }

                    /* +--------------------------------------
                     * |           FACTURA NORMAL
                     * +--------------------------------------*/

                    if (dr["documento"].ToString() == "Factura")
                    {

                        if (dr["serie"].ToString() == "")
                        {
                            if (dr["vigencia"].ToString() != "S")
                            {
                                //continue;
                            }
                        }
                        else
                        {
                            continue;
                        }

                        if (dr["exento"].ToString() == "Si")
                        {

                            var lDatosEmisor = lDte.Descendants()?.Elements(lNamespace + "DatosGenerales")?.FirstOrDefault();
                            if (lDatosEmisor != null)
                            {
                                lDatosEmisor.Attribute("CodigoMoneda").Value = "USD";

                                lDatosEmisor.Attribute("FechaHoraEmision").Value =
                                    $"{Convert.ToDateTime(dr["fecha"].ToString(), new System.Globalization.CultureInfo("es-GT")).ToString("yyyy-MM-dd")}T00:00:00-06:00";

                                lDatosEmisor.Attribute("Tipo").Value = "FCAM";

                                lDatosEmisor.Add(new XAttribute("Exp", "SI"));
                            }

                        }
                        else if (dr["Exento"].ToString() == "No")
                        {

                            var lDatosEmisor = lDte.Descendants()?.Elements(lNamespace + "DatosGenerales")?.FirstOrDefault();

                            if (lDatosEmisor != null)
                            {
                                lDatosEmisor.Attribute("CodigoMoneda").Value = "GTQ";

                                lDatosEmisor.Attribute("FechaHoraEmision").Value =
                                    $"{Convert.ToDateTime(dr["fecha"].ToString(), new System.Globalization.CultureInfo("es-GT")).ToString("yyyy-MM-dd")}T00:00:00-06:00";

                                lDatosEmisor.Attribute("Tipo").Value = "FCAM";

                            }

                        }

                        string strQuery =
                            $"pa_sel_empresa_fel {dr["empresa"].ToString()}";

                        DataTable tblDatosEmpresa = oFlex.Obtiene(strQuery);

                        /* +----------------------------------
                         * |     ENCABEZADO DE LA FACTURA
                         * +----------------------------------*/

                        if (tblDatosEmpresa != null)
                        {

                            if (tblDatosEmpresa.Rows.Count > 0)
                            {

                                var lEmisor = lDte.Descendants()?.Elements(lNamespace + "Emisor")?.FirstOrDefault();

                                if (lEmisor != null)
                                {

                                    lEmisor.Attribute("AfiliacionIVA").Value = dicDatosEmisor["TIPO_IVA"].Item1.ToString();
                                    lEmisor.Attribute("CodigoEstablecimiento").Value = dicDatosEmisor["ESTABLECIMIENTO"].Item2.ToString();
                                    lEmisor.Attribute("CorreoEmisor").Value = dicDatosEmisor["EMAIL"].Item1.ToString();
                                    lEmisor.Attribute("NITEmisor").Value = tblDatosEmpresa.Rows[0]["RUT"].ToString().Replace("-", "");
                                    lEmisor.Attribute("NombreComercial").Value = dicDatosEmisor["NOMBRE_COMERCIAL"].Item1.ToString();
                                    lEmisor.Attribute("NombreEmisor").Value = dicDatosEmisor["NOMBRE_FISCAL"].Item1.ToString();

                                    var lDireccion =
                                        lDte.Descendants()?.Elements(lNamespace + "DireccionEmisor")?.First().Elements(lNamespace + "Direccion").First();

                                    if (lDireccion != null)
                                    {
                                        lDireccion.Value = dicDatosEmisor["DIRECCION_RTU"].Item1.ToString();
                                    }

                                    var lCodigoPostal =
                                        lDte.Descendants()?.Elements(lNamespace + "DireccionEmisor")?.First().Elements(lNamespace + "CodigoPostal")?.First();

                                    if (lCodigoPostal != null)
                                    {
                                        lCodigoPostal.Value = dicDatosEmisor["ESTABLECIMIENTO"].Item3.ToString();
                                    }

                                    var lMunicipio =
                                        lDte.Descendants()?.Elements(lNamespace + "DireccionEmisor")?.First().Elements(lNamespace + "Municipio")?.First();

                                    if (lMunicipio != null)
                                    {
                                        lMunicipio.Value = tblDatosEmpresa.Rows[0]["PAIS"].ToString();
                                    }

                                    var lDepartamento =
                                        lDte.Descendants()?.Elements(lNamespace + "DireccionEmisor")?.First().Elements(lNamespace + "Departamento")?.First();

                                    if (lDepartamento != null)
                                    {
                                        lDepartamento.Value = tblDatosEmpresa.Rows[0]["CIUDAD"].ToString();
                                    }

                                    var lPais =
                                        lDte.Descendants()?.Elements(lNamespace + "DireccionEmisor")?.First().Elements(lNamespace + "Pais")?.First();

                                    if (lPais != null)
                                    {
                                        lPais.Value = "GT";
                                    }

                                }

                            }

                        }

                        if (dr["exento"].ToString() == "Si")
                        {

                            var lReceptor = lDte.Descendants()?.Elements(lNamespace + "Receptor")?.FirstOrDefault();

                            if (lReceptor != null)
                            {

                                lReceptor.Attribute("CorreoReceptor").Value = dicDatosEmisor["EMAIL"].Item1.ToString();
                                lReceptor.Attribute("IDReceptor").Value = "CF";
                                lReceptor.Attribute("NombreReceptor").Value = dr["nombre_cliente"].ToString().Replace("'", "").Replace("\"", "");

                                var lDireccion =
                                    lDte.Descendants()?.Elements(lNamespace + "DireccionReceptor")?.FirstOrDefault()?.Descendants()?.Elements(lNamespace + "Direccion").FirstOrDefault();

                                if (lDireccion != null)
                                {
                                    lDireccion.Value = dr["direccion"].ToString();
                                }

                                var lCodigoPostal =
                                    lDte.Descendants()?.Elements(lNamespace + "DireccionReceptor")?.FirstOrDefault()?.Descendants()?.Elements(lNamespace + "CodigoPostal").FirstOrDefault();

                                if (lCodigoPostal != null)
                                {
                                    lCodigoPostal.Value = "01001";
                                }

                                var lDepartamento =
                                    lDte.Descendants()?.Elements(lNamespace + "DireccionReceptor")?.FirstOrDefault()?.Descendants()?.Elements(lNamespace + "Departamento").FirstOrDefault();

                                if (lDepartamento != null)
                                {
                                    lDepartamento.Value = "GUATEMALA";
                                }

                                var lMunicipio =
                                    lDte.Descendants()?.Elements(lNamespace + "DireccionReceptor")?.FirstOrDefault()?.Descendants()?.Elements(lNamespace + "Municipio").FirstOrDefault();

                                if (lMunicipio != null)
                                {
                                    lMunicipio.Value = "GUATEMALA";
                                }

                                var lPais =
                                    lDte.Descendants()?.Elements(lNamespace + "DireccionReceptor")?.FirstOrDefault()?.Descendants()?.Elements(lNamespace + "Pais").FirstOrDefault();

                                if (lPais != null)
                                {
                                    lPais.Value = "GT";
                                }

                            }

                        }
                        else
                        {

                            var lReceptor = lDte.Descendants()?.Elements(lNamespace + "Receptor")?.FirstOrDefault();

                            if (lReceptor != null)
                            {

                                lReceptor.Attribute("CorreoReceptor").Value = dicDatosEmisor["EMAIL"].Item1.ToString();
                                lReceptor.Attribute("IDReceptor").Value = dr["codlegal"].ToString().Replace("-", "") == "C/F" ? "CF" : dr["codlegal"].ToString().Replace("-", "");
                                lReceptor.Attribute("NombreReceptor").Value = dr["nombre_cliente"].ToString().Replace("'", "").Replace("\"", "").Trim();

                                var lDireccion =
                                    lDte.Descendants()?.Elements(lNamespace + "DireccionReceptor")?.First().Elements(lNamespace + "Direccion")?.First();

                                if (lDireccion != null)
                                {
                                    lDireccion.Value = dr["direccion"].ToString().Trim();
                                }

                                var lCodigoPostal =
                                    lDte.Descendants()?.Elements(lNamespace + "DireccionReceptor")?.First().Elements(lNamespace + "CodigoPostal")?.First();

                                if (lCodigoPostal != null)
                                {
                                    lCodigoPostal.Value = "01001";
                                }

                                var lDepartamento =
                                    lDte.Descendants()?.Elements(lNamespace + "DireccionReceptor")?.First().Elements(lNamespace + "Departamento")?.First();

                                if (lDepartamento != null)
                                {
                                    lDepartamento.Value = "GUATEMALA";
                                }

                                var lMunicipio =
                                    lDte.Descendants()?.Elements(lNamespace + "DireccionReceptor")?.First().Elements(lNamespace + "Municipio").First();

                                if (lMunicipio != null)
                                {
                                    lMunicipio.Value = "GUATEMALA";
                                }

                                var lPais =
                                    lDte.Descendants()?.Elements(lNamespace + "DireccionReceptor")?.First().Elements(lNamespace + "Pais").First();

                                if (lPais != null)
                                {
                                    lPais.Value = "GT";
                                }

                            }

                        }

                        /* +----------------------------------
                            * |     DETALLE DE LA FACTURA
                            * +----------------------------------*/


                        List<string> lstFrases = new List<string>(dicDatosEmisor["CODIGO_FRASE"].Item1.Split(';'));

                        var lFrases = lDte.Descendants()?.Elements(lNamespace + "Frases")?.FirstOrDefault();
                        var lFrase = lDte.Descendants()?.Elements(lNamespace + "Frases")?.First().Elements(lNamespace + "Frase")?.First();

                        if (lFrase != null)
                        {
                            var lFraseClone = new XElement(lFrase);

                            if (lFrases != null)
                            {

                                lFrases.RemoveNodes();

                                foreach (string frase in lstFrases)
                                {

                                    var lFraseCopy = new XElement(lFraseClone);

                                    lFraseCopy.SetAttributeValue("CodigoEscenario", frase.Split(',')[1].ToString());
                                    lFraseCopy.SetAttributeValue("TipoFrase", Convert.ToInt32(frase.Split(',')[0].ToString()));

                                    lFraseCopy.RemoveNodes();

                                    lFrases.Add(lFraseCopy);

                                }

                                if (dr["exento"].ToString() == "Si")
                                {

                                    var lFraseCopy = new XElement(lFraseClone);

                                    lFraseCopy.SetAttributeValue("CodigoEscenario", "4");
                                    lFraseCopy.SetAttributeValue("TipoFrase", "1");

                                    lFrases.Add(lFraseCopy);

                                }

                            }

                        }

                        decimal TotalFactura = 0;
                        decimal TotalIva = 0;
                        int TotalSkus = 0;
                        decimal TotalUnidades = 0;
                        decimal dTotalDescuento = 0;
                        decimal dTotalFactura = 0;

                        pDsDatosFel.Tables["detalle_pedidos"].DefaultView.RowFilter =
                            $"empresa='{dr["empresa"].ToString()}' and " +
                            $"tipodocto='{dr["tipodocto"].ToString()}' and " +
                            $"numero='{dr["numero"].ToString()}'";

                        try
                        {
                            if (Convert.ToDecimal(dr["PorcDescuento"].ToString()) > 0)
                            {

                                foreach (DataRowView det in pDsDatosFel.Tables["detalle_pedidos"].DefaultView)
                                {

                                    dTotalFactura +=
                                        Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString());

                                }

                                dTotalDescuento = dTotalFactura * (Convert.ToDecimal(dr["PorcDescuento"].ToString()) / 100);

                            }
                        }
                        catch
                        {

                            oFlex.Escribir_Log("FEL: El porcentaje de descuento viene vacio.");

                        }

                        decimal dTotalSumaDetalle = 0;

                        var lItems = lDte.Descendants()?.Elements(lNamespace + "Items")?.FirstOrDefault();
                        var lItem = lDte.Descendants()?.Elements(lNamespace + "Items")?.First().Elements(lNamespace + "Item")?.First();
                        var lItemCopy = new XElement(lItem);

                        lItems.RemoveNodes();

                        foreach (DataRowView det in pDsDatosFel.Tables["detalle_pedidos"].DefaultView)
                        {

                            noLinea++;

                            TotalFactura += Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6);
                            TotalUnidades += Convert.ToDecimal(det["Cantidad"].ToString());
                            TotalSkus = pDsDatosFel.Tables["detalle_pedidos"].DefaultView.Count;

                            var lItemClone = new XElement(lItemCopy);

                            if (dTotalDescuento > 0)
                            {

                                /**+-----------------------------------------
                                 * |              TOTAL DE LINEA
                                 * +-----------------------------------------*/

                                decimal lTotal =
                                        decimal.Parse(det["Cantidad"].ToString()) * Convert.ToDecimal(det["Precio"].ToString());

                                /**+---------------------------------------------------------
                                 * |  CALCULA EL DESCUENTO PROPORCIONAL AL TOTAL DE LINEA
                                 * +---------------------------------------------------------*/

                                decimal dPorcDescPorItem = (lTotal * 100) / dTotalFactura;
                                decimal dDescuentoPorItem = dTotalDescuento * (dPorcDescPorItem / 100);
                                decimal dMontoGravable =
                                    (lTotal - dDescuentoPorItem) / Convert.ToDecimal("1.12");
                                decimal dIvaTotalSinDesc =
                                    ((lTotal - dDescuentoPorItem) / Convert.ToDecimal("1.12")) * Convert.ToDecimal("0.12");
                                TotalIva += dIvaTotalSinDesc;

                                dTotalSumaDetalle += Math.Round((lTotal - dDescuentoPorItem), 6);

                                /**+-----------------------------------------
                                 * |         AGREGA DETALLE DE LINEA
                                 * +-----------------------------------------*/

                                lItemClone.SetAttributeValue("BienOServicio", "B");
                                lItemClone.SetAttributeValue("NumeroLinea", noLinea.ToString());

                                var lCantidad = lItemClone.Elements(lNamespace + "Cantidad")?.First();
                                lCantidad.SetValue(det["Cantidad"].ToString());

                                var lUnidad = lItemClone.Elements(lNamespace + "UnidadMedida")?.First();
                                lUnidad.SetValue("UND");

                                var lDescripcion = lItemClone.Elements(lNamespace + "Descripcion")?.First();
                                lDescripcion.SetValue(
                                    $"{det["Producto"].ToString()}|" +
                                    $"{det["UNIDAD"].ToString()}|" +
                                    $"{det["GLOSA"].ToString()}|" +
                                    $"{det["volumen"].ToString()}|" +
                                    $"{det["psugerido"].ToString()}|" +
                                    $"{det["Impdist"].ToString()}");

                                var lPrecioUnitario = lItemClone.Elements(lNamespace + "PrecioUnitario")?.First();
                                lPrecioUnitario.SetValue(Math.Round(Convert.ToDecimal(det["Precio"].ToString()), 6).ToString());

                                var lTotalLinea = lItemClone.Elements(lNamespace + "Precio")?.First();
                                lTotalLinea.SetValue(Math.Round(Convert.ToDecimal(lTotal.ToString()), 6).ToString());

                                var lDescuento = lItemClone.Elements(lNamespace + "Descuento")?.First();
                                lDescuento.SetValue(Math.Round(Convert.ToDecimal(dDescuentoPorItem.ToString()), 6).ToString());

                                var lTotalLn = lItemClone.Elements(lNamespace + "Total")?.First();
                                lTotalLn.SetValue(Math.Round((lTotal - dDescuentoPorItem), 6).ToString());

                                var lImpuesto = lItemClone.Elements(lNamespace + "Impuestos")?.First().Elements(lNamespace + "Impuesto")?.First();
                                var lNombreCorto = lImpuesto.Elements(lNamespace + "NombreCorto")?.First();
                                lNombreCorto.SetValue("IVA");

                                var lCodUndGravable = lImpuesto.Elements(lNamespace + "CodigoUnidadGravable")?.First();
                                lCodUndGravable.SetValue(dr["exento"].ToString() == "Si" ? "2" : "1");

                                var lMontoGravable = lImpuesto.Elements(lNamespace + "MontoGravable")?.First();
                                lMontoGravable.SetValue(Math.Round(dMontoGravable, 6).ToString());

                                var lMontoImpuesto = lImpuesto.Elements(lNamespace + "MontoImpuesto")?.First();
                                lMontoImpuesto.SetValue(Math.Round(dIvaTotalSinDesc, 6).ToString());

                                lItems.Add(lItemClone);

                            }
                            else
                            {

                                TotalIva += Math.Round(Convert.ToDecimal(det["Impuesto"].ToString()), 6);

                                lItemClone.SetAttributeValue("BienOServicio", "B");
                                lItemClone.SetAttributeValue("NumeroLinea", noLinea.ToString());

                                var lCantidad = lItemClone.Elements(lNamespace + "Cantidad")?.First();
                                lCantidad.SetValue(det["Cantidad"].ToString());

                                var lUnidad = lItemClone.Elements(lNamespace + "UnidadMedida")?.First();
                                lUnidad.SetValue("UND");

                                var lDescripcion = lItemClone.Elements(lNamespace + "Descripcion")?.First();
                                lDescripcion.SetValue(
                                    $"{det["Producto"].ToString()}|" +
                                    $"{det["UNIDAD"].ToString()}|" +
                                    $"{det["GLOSA"].ToString()}|" +
                                    $"{det["volumen"].ToString()}|" +
                                    $"{det["psugerido"].ToString()}|" +
                                    $"{det["Impdist"].ToString()}");

                                var lPrecioUnitario = lItemClone.Elements(lNamespace + "PrecioUnitario")?.First();
                                lPrecioUnitario.SetValue(Math.Round(Convert.ToDecimal(det["Precio"].ToString()), 6).ToString());

                                var lTotalLinea = lItemClone.Elements(lNamespace + "Precio")?.First();
                                lTotalLinea.SetValue(Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6).ToString());

                                var lDescuento = lItemClone.Elements(lNamespace + "Descuento")?.First();
                                lDescuento.SetValue("0");

                                var lTotalLn = lItemClone.Elements(lNamespace + "Total")?.First();
                                lTotalLn.SetValue(Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6).ToString());

                                var lImpuesto = lItemClone.Elements(lNamespace + "Impuestos")?.First().Elements(lNamespace + "Impuesto")?.First();
                                var lNombreCorto = lImpuesto.Elements(lNamespace + "NombreCorto")?.First();
                                lNombreCorto.SetValue("IVA");

                                var lCodUndGravable = lImpuesto.Elements(lNamespace + "CodigoUnidadGravable")?.First();
                                lCodUndGravable.SetValue(dr["exento"].ToString() == "Si" ? "2" : "1");

                                var lMontoGravable = lImpuesto.Elements(lNamespace + "MontoGravable")?.First();
                                lMontoGravable.SetValue(
                                    dr["exento"].ToString() == "No" ?
                                    Math.Round(Convert.ToDecimal(det["IMPORTE_NETO_INGRESO"].ToString()), 6).ToString() :
                                    Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6).ToString());

                                var lMontoImpuesto = lImpuesto.Elements(lNamespace + "MontoImpuesto")?.First();
                                lMontoImpuesto.SetValue(Math.Round(Convert.ToDecimal(det["Impuesto"].ToString()), 6).ToString());

                                lItems.Add(lItemClone);

                            }

                        }

                        var lTotales = lDte.Descendants()?.Elements(lNamespace + "Totales")?.First();
                        var lTotalImpuesto = lTotales.Elements(lNamespace + "TotalImpuestos")?.Elements(lNamespace + "TotalImpuesto")?.First();

                        if (dr["exento"].ToString() == "No")
                        {
                            lTotalImpuesto.SetAttributeValue("NombreCorto", "IVA");
                            lTotalImpuesto.SetAttributeValue("TotalMontoImpuesto", Math.Round(TotalIva, 2).ToString());

                        }
                        else if (dr["exento"].ToString() == "Si")
                        {

                            lTotalImpuesto.SetAttributeValue("NombreCorto", "IVA");
                            lTotalImpuesto.SetAttributeValue("TotalMontoImpuesto", "0");

                        }

                        lTotales.Elements(lNamespace + "GranTotal")?.First().SetValue((Math.Round(TotalFactura - dTotalDescuento, 6).ToString()));

                        //Factura_cambiaria = request.Complemento_cambiaria("Cambiaria", "Cambiaria", "http://www.sat.gob.gt/fel/cambiaria.xsd");

                        //Abonos_factura_cambiaria =
                        //    request.Abonos_factura_cambiaria(DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd"), 1, "0.00");

                        var lCompCambiaria =
                            lDte.Descendants()?.Elements(lNamespace + "Complementos")?.Elements(lNamespace + "Complemento")?.Where(x => x.Attribute("IDComplemento").Value == "Cambiaria")
                            .First();

                        if (lCompCambiaria != null)
                        {

                            XNamespace lNamespaceComp = "http://www.sat.gob.gt/dte/fel/CompCambiaria/0.1.0";

                            var lAbono =
                                lCompCambiaria.Elements(lNamespaceComp + "AbonosFacturaCambiaria")?.Elements(lNamespaceComp + "Abono")?.First();

                            if (lAbono != null)
                            {

                                var lFechaVencimiento =
                                    lAbono.Elements(lNamespaceComp + "FechaVencimiento")?.First();

                                lFechaVencimiento.SetValue(DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd"));

                            }

                        }

                        if (dr["exento"].ToString() == "Si")
                        {

                            var lCompExenta =
                                lDte.Descendants()?.Elements(lNamespace + "Complementos")?.Elements(lNamespace + "Complemento")?.Where(x => x.Attribute("IDComplemento").Value == "Exportacion")
                                .First();

                            if (lCompExenta != null)
                            {

                                XNamespace lNamespaceComp = "http://www.sat.gob.gt/face2/ComplementoExportaciones/0.1.0";

                                var lExportacion =
                                    lCompExenta.Elements(lNamespaceComp + "Exportacion")?.First();

                                if (lExportacion != null)
                                {

                                    var lNombreConsignatario =
                                        lExportacion.Elements(lNamespaceComp + "NombreConsignatarioODestinatario")?.First();
                                    lNombreConsignatario.SetValue(dr["nombre_cliente"].ToString());

                                    var lDirConsignatario =
                                        lExportacion.Elements(lNamespaceComp + "DireccionConsignatarioODestinatario")?.First();
                                    lDirConsignatario.SetValue(dr["direccion"].ToString());

                                    var lCodConsignatario =
                                        lExportacion.Elements(lNamespaceComp + "CodigoConsignatarioODestinatario")?.First();
                                    lCodConsignatario.SetValue(dr["codlegal"].ToString());

                                    var lNombreComprador =
                                        lExportacion.Elements(lNamespaceComp + "NombreComprador")?.First();
                                    lNombreComprador.SetValue(dr["nombre_cliente"].ToString());

                                    var lDirComprador =
                                        lExportacion.Elements(lNamespaceComp + "DireccionComprador")?.First();
                                    lDirComprador.SetValue(dr["direccion"].ToString());

                                    var lCodComprador =
                                        lExportacion.Elements(lNamespaceComp + "CodigoComprador")?.First();
                                    lCodComprador.SetValue(dr["codlegal"].ToString());

                                    var lReferencia =
                                        lExportacion.Elements(lNamespaceComp + "OtraReferencia")?.First();
                                    lReferencia.SetValue(dicDatosEmisor["REFERENCIA_EXENTA"].Item1);

                                    var lIncoterm =
                                        lExportacion.Elements(lNamespaceComp + "INCOTERM")?.First();
                                    lIncoterm.SetValue("FOB");

                                    var lExportador =
                                        lExportacion.Elements(lNamespaceComp + "CodigoExportador")?.First();
                                    lExportador.SetValue(dicDatosEmisor["CODIGO_EXPORTADOR"].Item1);

                                    var lNombreExportador =
                                        lExportacion.Elements(lNamespaceComp + "CodigoExportador")?.First();
                                    lExportador.SetValue(dicDatosEmisor["NOMBRE_COMERCIAL"].Item1);

                                }

                            }

                        }
                        else
                        {

                            lDte.Descendants()?.Elements(lNamespace + "Complementos")?.First().Elements(lNamespace + "Complemento")?.Where(x => x.Attribute("IDComplemento").Value == "Exportacion")
                            .First().Remove();

                        }

                        /* +--------------------------------
                            * |      INFORMACION ADICIONAL
                            * +--------------------------------*/

                        try
                        {

                            var lAdenda =
                                lDte.Descendants()?.Elements(lNamespace + "Adenda")?.FirstOrDefault();

                            lAdenda.Elements("Observaciones")?.FirstOrDefault()?.SetValue(dr["comentario"].ToString().Substring(0, dr["comentario"].ToString().Length - 24));
                            lAdenda.Elements("Codigo")?.FirstOrDefault()?.SetValue(dr["ctacte"].ToString());
                            lAdenda.Elements("Bodega")?.FirstOrDefault()?.SetValue(dr["Bodega"].ToString());
                            lAdenda.Elements("Ejecutivo")?.FirstOrDefault()?.SetValue(dr["Vendedor"].ToString());
                            lAdenda.Elements("Ref")?.FirstOrDefault()?.SetValue(dr["direccion"].ToString().Trim());
                            lAdenda.Elements("Pedido")?.FirstOrDefault()?.SetValue(dr["numero"].ToString());
                            lAdenda.Elements("Condiciones")?.FirstOrDefault()?.SetValue(dr["forma_pago"].ToString());
                            lAdenda.Elements("LPrecios")?.FirstOrDefault()?.SetValue(dr["LisPrecio"].ToString());
                            lAdenda.Elements("TDocto")?.FirstOrDefault()?.SetValue(dr["tipodocto"].ToString());
                            lAdenda.Elements("TSkus")?.FirstOrDefault()?.SetValue(TotalSkus.ToString());
                            lAdenda.Elements("TUnidades")?.FirstOrDefault()?.SetValue(TotalUnidades.ToString());
                            lAdenda.Elements("valor1")?.FirstOrDefault()?.SetValue("");
                            lAdenda.Elements("valor2")?.FirstOrDefault()?.SetValue("");

                            if (dr["exento"].ToString() == "Si")
                            {

                                decimal dValorFlete = 0;
                                decimal dValorSeguro = 0;
                                decimal dValorCIF = 0;

                                if (dr["F_FLETE"].ToString() != "")
                                {
                                    dValorFlete = Convert.ToDecimal(dr["F_FLETE"].ToString());
                                    dValorCIF += dValorFlete;
                                }

                                if (dr["F_SEGURO"].ToString() != "")
                                {
                                    dValorSeguro = Convert.ToDecimal(dr["F_SEGURO"].ToString());
                                    dValorCIF += dValorSeguro;
                                }

                                if (dr["FLETE"].ToString() != "")
                                {
                                    dValorFlete = Convert.ToDecimal(dr["FLETE"].ToString());
                                    dValorCIF += dValorFlete;
                                }

                                if (dr["SEGURO"].ToString() != "")
                                {
                                    dValorSeguro = Convert.ToDecimal(dr["SEGURO"].ToString());
                                    dValorCIF += dValorSeguro;
                                }


                                lAdenda.Elements("Seguro")?.FirstOrDefault()?.SetValue(Math.Round(dValorSeguro, 2).ToString());
                                lAdenda.Elements("Flete")?.FirstOrDefault()?.SetValue(Math.Round(dValorSeguro, 2).ToString());
                                lAdenda.Elements("CIF")?.FirstOrDefault()?.SetValue(Math.Round(dValorSeguro, 2).ToString());

                            }

                            if (dr["codlegal"].ToString().Replace("-", "") != "7378106")
                            {

                                XNamespace xwalmart = "http://walmart.com.gt/dte";
                                lAdenda.Elements(xwalmart + "walmart")?.First().Remove();

                            }
                            else
                            {

                                XNamespace xwalmart = "http://walmart.com.gt/dte";

                                string lDatosPedido = dr["comentario"].ToString().Substring(dr["comentario"].ToString().IndexOf("["), 23);
                                string lTipoDoctoWM = lDatosPedido.Replace("[", "").Replace("]", "").Split(',')[0].Trim();
                                string lNumeroWM = lDatosPedido.Replace("[", "").Replace("]", "").Split(',')[1].Trim();

                                string lSql = $"pa_sel_datos_wm_fel_creditos '{dr["empresa"].ToString()}', '{lNumeroWM}'";
                                DataTable dtDatosWM = oFlex.Obtiene(lSql);

                                string lSqlBDC = $"pa_sel_datos_wm_fel_bdc '{dtDatosWM.Rows[0]["Empresa"].ToString()}', '{dtDatosWM.Rows[0]["TipoDoctoOrigen"].ToString()}', '{dtDatosWM.Rows[0]["NumeroOrigen"].ToString()}'";
                                DataTable dtDatosWMBDC = oCorp.Obtiene(lSqlBDC);

                                var lWmFact =
                                    lAdenda.Elements(xwalmart + "Walmart")?.First().Elements(xwalmart + "WM-FACT")?.First();

                                var lWmMerc =
                                    lWmFact.Elements(xwalmart + "WMMercaderia")?.First();

                                lWmMerc.Elements(xwalmart + "WMNumeroOrden")?.First().SetValue(dtDatosWM.Rows[0]["WMOrdenCompra"].ToString());
                                lWmMerc.Elements(xwalmart + "WMFechaOrden")?.First().SetValue(Convert.ToDateTime(dtDatosWMBDC.Rows[0]["WMFechaOrden"].ToString(), new System.Globalization.CultureInfo("es-GT")).ToString("yyyy-MM-dd"));
                                lWmMerc.Elements(xwalmart + "WMNumeroVendedor")?.First().SetValue(dtDatosWMBDC.Rows[0]["WMCodVendedor"].ToString());
                                lWmMerc.Elements(xwalmart + "WMEnviarGLN")?.First().SetValue(dtDatosWMBDC.Rows[0]["WMGln"].ToString());
                                lWmMerc.Elements(xwalmart + "WMNumeroRecepcion")?.First().SetValue(dtDatosWM.Rows[0]["WMNumeroRecepcion"].ToString());

                            }

                        }
                        catch (Exception ex)
                        {

                            string lErr = "";

                            lErr = $"{ex.Source}, {ex.TargetSite.Name}\r\n" +
                                $"\tEn: {ex.StackTrace}\r\n";

                            if (ex.InnerException == null)
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.Message}\r\n";

                            }
                            else
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.InnerException.Message}\r\n";

                            }

                            oFlex.Escribir_Log(lErr);

                        }

                        //Agregar_adenda = request.Agregar_adendas();

                        Dictionary<string, string> dictResponse = null;
                        response = null;

                        /* +--------------------------------
                            * |           ENVIO FEL
                            * +--------------------------------*/

                        try
                        {

                            //XML a frimar

                            lSolicitudInFile.ContentType = "application/json";
                            lSolicitudInFile.Method = "POST";
                            lSolicitudInFile.Headers.Add("usuario", dicDatosEmisor["ALIAS_PFX"].Item1);
                            lSolicitudInFile.Headers.Add("llave", dicDatosEmisor["LLAVE"].Item1);
                            lSolicitudInFile.Headers.Add("identificador", $"{dr["empresa"].ToString()}{dr["tipodocto"].ToString()}{dr["correlativo"].ToString()}");

                            MemoryStream mStream = new MemoryStream();
                            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
                            writer.Formatting = System.Xml.Formatting.Indented;

                            lDte.WriteTo(writer);
                            writer.Flush();
                            mStream.Flush();

                            mStream.Position = 0;

                            StreamReader sReader = new StreamReader(mStream);
                            string formattedXml = sReader.ReadToEnd();

                            string lB64Doc = Convert.ToBase64String(Encoding.UTF8.GetBytes(formattedXml));


                            //Firma de XML

                            HttpWebRequest lSolFirmaInFile = (HttpWebRequest)WebRequest.Create("https://signer-emisores.feel.com.gt/sign_solicitud_firmas/firma_xml");
                            lSolFirmaInFile.ContentType = "application/json";
                            lSolFirmaInFile.Method = "POST";

                            DatosInFileFirma lDatosFirma = new DatosInFileFirma
                            {
                                llave = dicDatosEmisor["LLAVE_PFX"].Item1,
                                archivo = lB64Doc,
                                alias = dicDatosEmisor["ALIAS_PFX"].Item1,
                                codigo = "N/A",
                                es_anulacion = "N"
                            };

                            string lDatosFirmaJson = JsonConvert.SerializeObject(lDatosFirma);
                            byte[] lDatosFirmaEnviar = Encoding.UTF8.GetBytes(lDatosFirmaJson);

                            lSolFirmaInFile.ContentLength = lDatosFirmaEnviar.Length;

                            Stream lPostFirma = lSolFirmaInFile.GetRequestStream();
                            lPostFirma.Write(lDatosFirmaEnviar, 0, lDatosFirmaEnviar.Length);

                            HttpWebResponse lRespFirma = (HttpWebResponse)lSolFirmaInFile.GetResponse();
                            StreamReader lSrFirma = new StreamReader(lRespFirma.GetResponseStream());
                            string lRespuestaFirma = lSrFirma.ReadToEnd();

                            Newtonsoft.Json.Linq.JObject lTipo =
                                (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(lRespuestaFirma);

                            //Enviar DTE firmado

                            string xml_firmado = "";

                            if (lTipo.GetValue("resultado").ToString() == "True")
                            {
                                xml_firmado = lTipo.GetValue("archivo").ToString();
                            }
                            else
                            {
                                throw new Exception("El archivo no pudo firmarse");
                            }

                            DatosInFile lDatos = new DatosInFile
                            {
                                nit_emisor = tblDatosEmpresa.Rows[0]["RUT"].ToString().Replace("-", ""),
                                correo_copia = dicDatosEmisor["EMAIL_COPIA"].Item1,
                                xml_dte = xml_firmado
                            };

                            string lDatosJson = JsonConvert.SerializeObject(lDatos);

                            byte[] lDatosEnviar = Encoding.UTF8.GetBytes(lDatosJson);
                            lSolicitudInFile.ContentLength = lDatosEnviar.Length;

                            Stream lPostInFile = lSolicitudInFile.GetRequestStream();
                            lPostInFile.Write(lDatosEnviar, 0, lDatosEnviar.Length);

                            HttpWebResponse lReqResponse = (HttpWebResponse)lSolicitudInFile.GetResponse();
                            StreamReader lSrResponse = new StreamReader(lReqResponse.GetResponseStream());

                            response = lSrResponse.ReadToEnd();

                            /*+-------------------------------
                               |     PARSE JSON RESPUESTA
                               +-------------------------------*/

                            Newtonsoft.Json.Linq.JObject lRespuestaCert = null;

                            //if (response != null)
                            //{

                            //    dictResponse =
                            //        response.ParseResponse(pDirectorioFel);

                            //    lRespuestaCert =
                            //         (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(response);

                            //}
                            string jsonString = "";
                            if (response != null)
                            {
                                jsonString =
                               ExtractJsonObject(response);
                                //dictResponse =
                                //    response.ParseResponse(pDirectorioFel);

                            }
                            var jsonRespuestaObject = JsonConvert.DeserializeObject<respuestaFel>(jsonString);

                            if (true)
                            {

                                if (jsonRespuestaObject.resultado)
                                {

                                    Umbral.FelInFile.Tools.GuardarXmlFirmadoWM(
                                        jsonRespuestaObject.xml_certificado,
                                        pDirectorioFel,
                                        DirectorioWalmart,
                                        dr["empresa"].ToString(),
                                        dr["numero"].ToString());

                                    string lsSQL =
                                        $"pa_ins_um_gen_log_documento_face " +
                                        $"'{dr["empresa"].ToString()}', " +
                                        $"'{dr["tipodocto"].ToString()}', " +
                                        $"'{dr["numero"].ToString()}', " +
                                        $"'{DateTime.Now.ToString("HHmmss")}', " +
                                        $"NULL, " +
                                        $"{TotalFactura}, " +
                                        $"{noLinea.ToString()}";

                                    oFlex.Ingresa(lsSQL);
                                    if (oFlex.Codigo_error > 0)
                                        oFlex.Escribir_Log("No se pudo ingresar el log.");

                                    lsSQL =
                                        $"pa_ins_fel_docto_cert " +
                                        $"'{dr["empresa"].ToString()}', " +
                                        $"'{dr["tipodocto"].ToString()}', " +
                                        $"{dr["correlativo"].ToString()}, " +
                                        $"'{dr["numero"].ToString()}', " +
                                        $"'{DateTime.Now.ToString("yyyy-MM-dd")}', " +
                                        $"'{jsonRespuestaObject.uuid}', " +
                                        $"'{jsonRespuestaObject.serie}', " +
                                        $"'{jsonRespuestaObject.numero}', " +
                                        $"'{jsonRespuestaObject.fecha.ToString("yyyy-MM-dd HH:mm")}'";

                                    oFlex.Ingresa(lsSQL);
                                    if (oFlex.Codigo_error > 0)
                                        oFlex.Escribir_Log("No se pudo ingresar el log.");

                                    Tuple<string, string, string, string> tpPedidoEnviado =
                                        new Tuple<string, string, string, string>(
                                            dr["empresa"].ToString(),
                                            dr["tipodocto"].ToString(),
                                            dr["correlativo"].ToString(),
                                            dr["numero"].ToString());

                                    lRespuesta = CrearDoctoFelFlexline(
                                        pDsDatosFel,
                                        jsonRespuestaObject.uuid,
                                        jsonRespuestaObject.serie,
                                        jsonRespuestaObject.numero,
                                        jsonRespuestaObject.fecha.ToString("yyyy-MM-dd HH:mm"),
                                        tpPedidoEnviado,
                                        Convert.ToDateTime(dr["fecha"].ToString(), new System.Globalization.CultureInfo("es-GT")));

                                    if (lRespuesta)
                                    {
                                        lsSQL = $"pa_upd_um_gen_log_documento_face_proceso_comentario " +
                                            $"'{dr["empresa"].ToString()}', " +
                                            $"'{dr["tipodocto"].ToString()}', " +
                                            $"'{dr["numero"].ToString()}', " +
                                            $"''";

                                        oFlex.Actualiza(lsSQL);
                                        if (oFlex.Codigo_error > 0)
                                            oFlex.Escribir_Log("No se pudo ingresar el log.");
                                    }

                                }
                                else
                                {

                                    string lsSQL =
                                      $"pa_ins_um_gen_log_documento_face " +
                                      $"'{dr["empresa"].ToString()}', " +
                                      $"'{dr["tipodocto"].ToString()}', " +
                                      $"'{dr["numero"].ToString()}', " +
                                      $"'{DateTime.Now.ToString("HHmmss")}', " +
                                      $"NULL, " +
                                      $"{TotalFactura}, " +
                                      $"{noLinea.ToString()}";

                                    oFlex.Ingresa(lsSQL);
                                    if (oFlex.Codigo_error > 0)
                                        oFlex.Escribir_Log("No se pudo ingresar el log.");

                                    var jo = JObject.Parse(jsonString);

                                    string MensajeInfile = jo["descripcion_errores"][0]["mensaje_error"].ToString();
                                    oFlex.Escribir_Log(MensajeInfile);

                                    lsSQL =
                                         $"pa_upd_um_gen_log_documento_face_proceso_comentario" +
                                         $"'{dr["empresa"].ToString()}'," +
                                         $"'{dr["tipodocto"].ToString()}', " +
                                         $"'{dr["numero"].ToString()}', " +
                                         $"'{MensajeInfile}'";

                                    oFlex.Actualiza(lsSQL);

                                    //foreach (var k in dictResponse.Keys)
                                    //{

                                    //    lsSQL =
                                    //         $"pa_upd_um_gen_log_documento_face_proceso_comentario" +
                                    //         $"'{dr["empresa"].ToString()}'," +
                                    //         $"'{dr["tipodocto"].ToString()}', " +
                                    //         $"'{dr["numero"].ToString()}', " +
                                    //         $"'{dictResponse[k]}'";

                                    //    oFlex.Actualiza(lsSQL);

                                    //}

                                }

                            }

                        }
                        catch (Exception ex)
                        {


                            string lErr = "";

                            lErr = $"{ex.Source}, {ex.TargetSite.Name}\r\n" +
                                $"\tEn: {ex.StackTrace}\r\n";

                            if (ex.InnerException == null)
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.Message}\r\n";

                            }
                            else
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.InnerException.Message}\r\n";

                            }

                            oFlex.Escribir_Log(lErr);

                        }

                    }
                    else if (
                        dr["documento"].ToString().Contains("Credito") &&
                        (dr["tipodocto"].ToString().Contains("NOTA DE ABONO") ||
                        dr["tipodocto"].ToString().Contains("NOTA DE ABONO CTE") ||
                        dr["tipodocto"].ToString().Contains("NOTA ABONO CTE DOLAR")))
                    {

                        Datos_generales =
                            request.Datos_generales(
                                "GTQ",
                                Convert.ToDateTime(dr["fecha"].ToString(), new System.Globalization.CultureInfo("es-GT")).ToString("yyyy-MM-dd"),//DateTime.Now.ToString("yyyy-MM-dd"),
                                "NABN",
                                "",
                                "", "");

                        string strQuery =
                            $"pa_sel_empresa_fel {dr["empresa"].ToString()}";

                        DataTable tblDatosEmpresa = oFlex.Obtiene(strQuery);

                        /* +----------------------------------
                         * |     ENCABEZADO DE LA NOTA
                         * +----------------------------------*/

                        if (tblDatosEmpresa != null)
                        {

                            if (tblDatosEmpresa.Rows.Count > 0)
                            {

                                Datos_emisor = request.Datos_emisor(
                                    dicDatosEmisor["TIPO_IVA"].Item1,//TipoAfiliacionIVA
                                    Convert.ToInt32(
                                        dicDatosEmisor["ESTABLECIMIENTO"].Item2),
                                    dicDatosEmisor["ESTABLECIMIENTO"].Item3,//CodigoPostal
                                    dicDatosEmisor["EMAIL"].Item1,
                                    "GT",
                                    tblDatosEmpresa.Rows[0]["PAIS"].ToString(),
                                    tblDatosEmpresa.Rows[0]["CIUDAD"].ToString(),
                                    dicDatosEmisor["DIRECCION_RTU"].Item1,
                                    tblDatosEmpresa.Rows[0]["RUT"].ToString().Replace("-", ""),
                                    dicDatosEmisor["NOMBRE_FISCAL"].Item1,
                                    dicDatosEmisor["NOMBRE_COMERCIAL"].Item1);

                            }

                        }

                        string TipoCodLegal = "";

                        if (dr["codlegal"].ToString().Length >= 3)
                        {
                            if (dr["codlegal"].ToString().Substring(0, 3) == "CUI" || dr["codlegal"].ToString().Substring(0, 3) == "DPI")
                            {
                                TipoCodLegal = "CUI";
                            }
                            else if (dr["codlegal"].ToString().Substring(0, 3) == "EXT")
                            {
                                TipoCodLegal = "EXT";
                            }
                            else
                            {
                                TipoCodLegal = "";
                            }
                        }

                        Datos_receptor = request.Datos_receptor(
                            dr["codlegal"].ToString().Replace("-", "") == "C/F" ? "CF" : dr["codlegal"].ToString().Replace("-", "").Replace("CUI", "").Replace("EXT", ""),
                            dr["nombre_cliente"].ToString().Replace("'", "").Replace("\"", "").Replace("&", "&amp;"),
                            "01001",
                            dicDatosEmisor["EMAIL"].Item1,
                            "GT",
                            "GUATEMALA",
                            "GUATEMALA",
                            dr["direccion"].ToString() == "" ? "CIUDAD" : dr["direccion"].ToString(),
                            TipoCodLegal);

                        /* +----------------------------------
                         * |     DETALLE DE LA NOTA
                         * +----------------------------------*/

                        List<string> lstFrases = new List<string>(dicDatosEmisor["CODIGO_FRASE"].Item1.Split(';'));

                        //foreach (string frase in lstFrases)
                        //{
                        //    Frases = request.Frases(
                        //        Convert.ToInt32(frase.Split(',')[0]),
                        //        Convert.ToInt32(frase.Split(',')[1]), "", "");
                        //}

                        if (dr["exento"].ToString() == "Si")
                        {
                            Frases = request.Frases(4, 1, "", "");
                        }

                        /* +----------------------------------
                        * |     Definir porcentaje de encabezado
                        * +----------------------------------*/
                        decimal TotalFactura = 0;
                        decimal TotalIva = 0;
                        int TotalSkus = 0;
                        decimal TotalUnidades = 0;
                        decimal dTotalDescuento = 0;
                        decimal dTotalFactura = 0;


                        pDsDatosFel.Tables["detalle_pedidos"].DefaultView.RowFilter =
                        $"empresa='{dr["empresa"].ToString()}' and " +
                        $"tipodocto='{dr["tipodocto"].ToString()}' and " +
                        $"numero='{dr["numero"].ToString()}'";

                        try
                        {
                            if (Convert.ToDecimal(dr["PorcDescuento"].ToString()) > 0)
                            {

                                foreach (DataRowView det in pDsDatosFel.Tables["detalle_pedidos"].DefaultView)
                                {

                                    dTotalFactura +=
                                        Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()) / 1.12M;

                                }

                                dTotalDescuento = dTotalFactura * (Convert.ToDecimal(dr["PorcDescuento"].ToString()) / 100);

                            }
                        }
                        catch (Exception ex)
                        {

                            oFlex.Escribir_Log("FEL: El porcentaje de descuento viene vacio.");

                            string lErr = "";

                            lErr = $"{ex.Source}, {ex.TargetSite.Name}\r\n" +
                                $"\tEn: {ex.StackTrace}\r\n";

                            if (ex.InnerException == null)
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.Message}\r\n";

                            }
                            else
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.InnerException.Message}\r\n";

                            }

                            oFlex.Escribir_Log(lErr);

                        }




                        foreach (DataRowView det in pDsDatosFel.Tables["detalle_pedidos"].DefaultView)
                        {

                            noLinea++;



                            /**+---------------------------------------------------------
                             * |  CALCULA EL DESCUENTO PROPORCIONAL AL TOTAL DE LINEA
                             * +---------------------------------------------------------*/
                            //decimal lTotal =Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString());
                            //decimal dPorcDescPorItem = (lTotal * 100) / dTotalFactura;
                            //decimal dDescuentoPorItem = dTotalDescuento * (dPorcDescPorItem / 100);
                            //decimal dMontoGravable =
                            //    (lTotal - dDescuentoPorItem) / Convert.ToDecimal("1.12");
                            //decimal dIvaTotalSinDesc =
                            //    ((lTotal - dDescuentoPorItem) / Convert.ToDecimal("1.12")) * Convert.ToDecimal("0.12");
                            //TotalIva += dIvaTotalSinDesc;





                            //decimal lDescuento = Convert.ToDecimal(det["ValPorcentajeDR1"].ToString()) > 0M ? Convert.ToDecimal(det["ValPorcentajeDR1"].ToString()) * -1M : 0M;


                            ///se realiza cambio para descuento global
                            ///

                            if (Convert.ToDecimal(dr["PorcDescuento"].ToString()) > 0)
                            {
                                decimal PorcDescEncabezado = Convert.ToDecimal(dr["PorcDescuento"].ToString());

                                decimal DetTotal = Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6);
                                decimal DescDet = DetTotal * (PorcDescEncabezado / 100);
                                DetTotal = DetTotal - DescDet;

                                TotalFactura += Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6);
                                TotalUnidades += Convert.ToDecimal(det["Cantidad"].ToString());
                                TotalSkus = pDsDatosFel.Tables["detalle_pedidos"].DefaultView.Count;

                                decimal lTotalLinea = Convert.ToDecimal(det["Cantidad"].ToString()) * Convert.ToDecimal(det["Precio"].ToString());

                                TotalIva += (lTotalLinea / 1.12M) * 0.12M;
                                //TotalIva += Math.Round(Convert.ToDecimal(det["Impuesto"].ToString()), 6);

                                Item_un_impuesto = request.Item_sin_impuesto(
                                    "B",
                                    "UND",
                                    det["Cantidad"].ToString(),
                                    $"{det["Producto"].ToString()}|" +
                                    $"{det["UNIDAD"].ToString()}|" +
                                    $"{det["GLOSA"].ToString().Replace("&", "&amp;")}|" +
                                    $"{det["volumen"].ToString()}|" +
                                    $"{det["psugerido"].ToString()}|" +
                                    $"{det["Impdist"].ToString()}",
                                    noLinea,
                                    Math.Round(((Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString())) / 1.12M) / Convert.ToDecimal(det["Cantidad"].ToString()), 6).ToString(),
                                    Math.Round((Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString())) / 1.12M, 6).ToString(),
                                    Math.Round(DescDet / 1.12M, 6).ToString(),
                                    Math.Round(DetTotal / 1.12M, 6).ToString()
                                    );




                            }
                            else
                            {
                                TotalFactura += Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6);
                                TotalUnidades += Convert.ToDecimal(det["Cantidad"].ToString());
                                TotalSkus = pDsDatosFel.Tables["detalle_pedidos"].DefaultView.Count;

                                decimal lTotalLinea = Convert.ToDecimal(det["Cantidad"].ToString()) * Convert.ToDecimal(det["Precio"].ToString());

                                TotalIva += (lTotalLinea / 1.12M) * 0.12M;
                                //TotalIva += Math.Round(Convert.ToDecimal(det["Impuesto"].ToString()), 6);

                                Item_un_impuesto = request.Item_sin_impuesto(
                                    "B",
                                    "UND",
                                    det["Cantidad"].ToString(),
                                    $"{det["Producto"].ToString()}|" +
                                    $"{det["UNIDAD"].ToString()}|" +
                                    $"{det["GLOSA"].ToString().Replace("&", "&amp;")}|" +
                                    $"{det["volumen"].ToString()}|" +
                                    $"{det["psugerido"].ToString()}|" +
                                    $"{det["Impdist"].ToString()}",
                                    noLinea,
                                    Math.Round(((Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString())) / 1.12M) / Convert.ToDecimal(det["Cantidad"].ToString()), 6).ToString(),
                                    Math.Round((Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString())) / 1.12M, 6).ToString(),
                                    "0",
                                    Math.Round((Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString())) / 1.12M, 6).ToString()
                                    );


                            }

                        }

                        Totales = request.Totales((TotalFactura - TotalIva - dTotalDescuento).ToString());

                        try
                        {
                            Adenda = request.Adendas("Observaciones", dr["comentario"].ToString().Replace("&", "&amp;"));
                            Adenda = request.Adendas("Codigo", dr["ctacte"].ToString());
                            Adenda = request.Adendas("Bodega", dr["Bodega"].ToString());
                            Adenda = request.Adendas("Ejecutivo", dr["Vendedor"].ToString());
                            Adenda = request.Adendas("Ref", dr["direccion"].ToString());
                            Adenda = request.Adendas("Pedido", dr["numero"].ToString());
                            Adenda = request.Adendas("Condiciones", dr["forma_pago"].ToString());
                            Adenda = request.Adendas("LPrecios", dr["LisPrecio"].ToString());
                            Adenda = request.Adendas("TDocto", dr["tipodocto"].ToString().Replace("&", "&amp;"));
                            Adenda = request.Adendas("TSkus", TotalSkus.ToString());
                            Adenda = request.Adendas("TUnidades", TotalUnidades.ToString());
                        }
                        catch (Exception ex)
                        {

                            string lErr = "";

                            lErr = $"{ex.Source}, {ex.TargetSite.Name}\r\n" +
                                $"\tEn: {ex.StackTrace}\r\n";

                            if (ex.InnerException == null)
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.Message}\r\n";

                            }
                            else
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.InnerException.Message}\r\n";

                            }

                            oFlex.Escribir_Log(lErr);

                        }

                        Dictionary<string, string> dictResponse = null;
                        response = null;

                        Agregar_adenda = request.Agregar_adendas();

                        response = request.enviar_peticion_fel(
                            dicDatosEmisor["PREFIJO"].Item1,
                            dicDatosEmisor["LLAVE"].Item1,
                            $"{dr["empresa"].ToString()}{dr["tipodocto"].ToString().Replace("&", "&amp;")}{dr["correlativo"].ToString()}",
                            dicDatosEmisor["EMAIL_COPIA"].Item1,
                            dicDatosEmisor["ALIAS_PFX"].Item1,
                            dicDatosEmisor["LLAVE_PFX"].Item1,
                            true);

                        /*+-------------------------------
                          |     PARSE JSON RESPUESTA
                          +-------------------------------*/
                        string jsonString = "";
                        if (response != null)
                        {
                            jsonString =
                           ExtractJsonObject(response);
                            //dictResponse =
                            //    response.ParseResponse(pDirectorioFel);

                        }
                        var jsonRespuestaObject = JsonConvert.DeserializeObject<respuestaFel>(jsonString);

                        if (true)
                        {

                            if (jsonRespuestaObject.resultado)
                            {

                                string lsSQL =
                                    $"pa_ins_um_gen_log_documento_face " +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"'{DateTime.Now.ToString("HHmmss")}', " +
                                    $"NULL, " +
                                    $"{TotalFactura}, " +
                                    $"{noLinea.ToString()}";

                                oFlex.Ingresa(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                lsSQL =
                                      $"pa_ins_fel_docto_cert " +
                                      $"'{dr["empresa"].ToString()}', " +
                                      $"'{dr["tipodocto"].ToString()}', " +
                                      $"{dr["correlativo"].ToString()}, " +
                                      $"'{dr["numero"].ToString()}', " +
                                      $"'{DateTime.Now.ToString("yyyy-MM-dd")}', " +
                                      $"'{jsonRespuestaObject.uuid}', " +
                                      $"'{jsonRespuestaObject.serie}', " +
                                      $"'{jsonRespuestaObject.numero}', " +
                                      $"'{jsonRespuestaObject.fecha.ToString("yyyy-MM-dd HH:mm")}'";

                                oFlex.Ingresa(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                //pa_upd_fel_factura
                                lsSQL = $"pa_upd_fel_nota_credito" +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"'{jsonRespuestaObject.uuid}', " +
                                    $"'{jsonRespuestaObject.serie}', " +
                                    $"'{jsonRespuestaObject.numero}'";

                                oFlex.Actualiza(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                lsSQL = $"pa_upd_um_gen_log_documento_face_proceso_comentario " +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"''";

                                oFlex.Actualiza(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                            }
                            else
                            {

                                string lsSQL =
                                           $"pa_ins_um_gen_log_documento_face " +
                                           $"'{dr["empresa"].ToString()}', " +
                                           $"'{dr["tipodocto"].ToString()}', " +
                                           $"'{dr["numero"].ToString()}', " +
                                           $"'{DateTime.Now.ToString("HHmmss")}', " +
                                           $"NULL, " +
                                           $"{TotalFactura}, " +
                                           $"{noLinea.ToString()}";

                                oFlex.Ingresa(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                var jo = JObject.Parse(jsonString);

                                string MensajeInfile = jo["descripcion_errores"][0]["mensaje_error"].ToString();
                                oFlex.Escribir_Log(MensajeInfile);

                                lsSQL =
                                     $"pa_upd_um_gen_log_documento_face_proceso_comentario" +
                                     $"'{dr["empresa"].ToString()}'," +
                                     $"'{dr["tipodocto"].ToString()}', " +
                                     $"'{dr["numero"].ToString()}', " +
                                     $"'{MensajeInfile}'";

                                oFlex.Actualiza(lsSQL);

                                //foreach (var k in dictResponse.Keys)
                                //{

                                //    lsSQL =
                                //         $"pa_upd_um_gen_log_documento_face_proceso_comentario" +
                                //         $"'{dr["empresa"].ToString()}'," +
                                //         $"'{dr["tipodocto"].ToString()}', " +
                                //         $"'{dr["numero"].ToString()}', " +
                                //         $"'{dictResponse[k]}'";

                                //    oFlex.Actualiza(lsSQL);

                                //}

                            }

                        }

                    }
                    else if (dr["documento"].ToString() == "Credito")
                    {

                        Datos_generales =
                            request.Datos_generales(
                                "GTQ",
                                Convert.ToDateTime(dr["fecha"].ToString(), new System.Globalization.CultureInfo("es-GT")).ToString("yyyy-MM-dd"),//DateTime.Now.ToString("yyyy-MM-dd"),
                                "NCRE",
                                "",
                                "", "");

                        string strQuery =
                            $"pa_sel_empresa_fel {dr["empresa"].ToString()}";

                        DataTable tblDatosEmpresa = oFlex.Obtiene(strQuery);

                        /* +----------------------------------
                         * |     ENCABEZADO DE LA NOTA
                         * +----------------------------------*/

                        if (tblDatosEmpresa != null)
                        {

                            if (tblDatosEmpresa.Rows.Count > 0)
                            {

                                Datos_emisor = request.Datos_emisor(
                                    dicDatosEmisor["TIPO_IVA"].Item1,//TipoAfiliacionIVA
                                    Convert.ToInt32(
                                        dicDatosEmisor["ESTABLECIMIENTO"].Item2),
                                    dicDatosEmisor["ESTABLECIMIENTO"].Item3,//CodigoPostal
                                    dicDatosEmisor["EMAIL"].Item1,
                                    "GT",
                                    tblDatosEmpresa.Rows[0]["PAIS"].ToString(),
                                    tblDatosEmpresa.Rows[0]["CIUDAD"].ToString(),
                                    dicDatosEmisor["DIRECCION_RTU"].Item1,//tblDatosEmpresa.Rows[0]["COMUNA"].ToString(),
                                    tblDatosEmpresa.Rows[0]["RUT"].ToString().Replace("-", ""),
                                    dicDatosEmisor["NOMBRE_FISCAL"].Item1,//tblDatosEmpresa.Rows[0]["NOMBRE"].ToString(),
                                    dicDatosEmisor["NOMBRE_COMERCIAL"].Item1);

                            }

                        }

                        string TipoCodLegal = "";

                        if (dr["codlegal"].ToString().Length >= 3)
                        {
                            if (dr["codlegal"].ToString().Substring(0, 3) == "CUI" || dr["codlegal"].ToString().Substring(0, 3) == "DPI")
                            {
                                TipoCodLegal = "CUI";
                            }
                            else if (dr["codlegal"].ToString().Substring(0, 3) == "EXT")
                            {
                                TipoCodLegal = "EXT";
                            }
                            else
                            {
                                TipoCodLegal = "";
                            }
                        }

                        Datos_receptor = request.Datos_receptor(
                            dr["codlegal"].ToString().Replace("-", "") == "C/F" ? "CF" : dr["codlegal"].ToString().Replace("-", "").Replace("CUI", "").Replace("EXT", ""),
                            dr["nombre_cliente"].ToString().Replace("'", "").Replace("\"", "").Replace("&", "&amp;"),
                            "01001",
                            dicDatosEmisor["EMAIL"].Item1,
                            "GT",
                            "GUATEMALA",
                            "GUATEMALA",
                            dr["direccion"].ToString() == "" ? "CIUDAD" : dr["direccion"].ToString(),
                            TipoCodLegal);


                        /* +----------------------------------
                         * |     DETALLE DE LA NOTA
                         * +----------------------------------*/

                        List<string> lstFrases = new List<string>(dicDatosEmisor["CODIGO_FRASE"].Item1.Split(';'));

                        foreach (string frase in lstFrases)
                        {
                            Frases = request.Frases(
                                Convert.ToInt32(frase.Split(',')[0]),
                                Convert.ToInt32(frase.Split(',')[1]), "", "");
                        }

                        if (dr["exento"].ToString() == "Si")
                        {
                            Frases = request.Frases(4, 1, "", "");
                        }

                        decimal TotalFactura = 0;
                        decimal TotalIva = 0;
                        int TotalSkus = 0;
                        decimal TotalUnidades = 0;
                        decimal dTotalDescuento = 0;
                        decimal dTotalFactura = 0;

                        pDsDatosFel.Tables["detalle_pedidos"].DefaultView.RowFilter =
                            $"empresa='{dr["empresa"].ToString()}' and " +
                            $"tipodocto='{dr["tipodocto"].ToString()}' and " +
                            $"numero='{dr["numero"].ToString()}'";

                        try
                        {
                            if (Convert.ToDecimal(dr["PorcDescuento"].ToString()) > 0)
                            {

                                foreach (DataRowView det in pDsDatosFel.Tables["detalle_pedidos"].DefaultView)
                                {

                                    dTotalFactura +=
                                        Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString());

                                }

                                dTotalDescuento = dTotalFactura * (Convert.ToDecimal(dr["PorcDescuento"].ToString()) / 100);

                            }
                        }
                        catch (Exception ex)
                        {

                            oFlex.Escribir_Log("FEL: El porcentaje de descuento viene vacio.");

                            string lErr = "";

                            lErr = $"{ex.Source}, {ex.TargetSite.Name}\r\n" +
                                $"\tEn: {ex.StackTrace}\r\n";

                            if (ex.InnerException == null)
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.Message}\r\n";

                            }
                            else
                            {

                                lErr = $"{lErr}\tExcepcion: {ex.InnerException.Message}\r\n";

                            }

                            oFlex.Escribir_Log(lErr);

                        }

                        decimal dTotalSumaDetalle = 0;

                        foreach (DataRowView det in pDsDatosFel.Tables["detalle_pedidos"].DefaultView)
                        {

                            noLinea++;

                            TotalFactura += Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6);
                            TotalUnidades += Convert.ToDecimal(det["Cantidad"].ToString());
                            TotalSkus = pDsDatosFel.Tables["detalle_pedidos"].DefaultView.Count;

                            if (dTotalDescuento > 0)
                            {

                                /**+-----------------------------------------
                                 * |              TOTAL DE LINEA
                                 * +-----------------------------------------*/

                                decimal lTotal =
                                        decimal.Parse(det["Cantidad"].ToString()) * Convert.ToDecimal(det["Precio"].ToString());

                                /**+---------------------------------------------------------
                                 * |  CALCULA EL DESCUENTO PROPORCIONAL AL TOTAL DE LINEA
                                 * +---------------------------------------------------------*/

                                decimal dPorcDescPorItem = (lTotal * 100) / dTotalFactura;
                                decimal dDescuentoPorItem = dTotalDescuento * (dPorcDescPorItem / 100);
                                decimal dMontoGravable =
                                    (lTotal - dDescuentoPorItem) / Convert.ToDecimal("1.12");
                                decimal dIvaTotalSinDesc =
                                    ((lTotal - dDescuentoPorItem) / Convert.ToDecimal("1.12")) * Convert.ToDecimal("0.12");
                                TotalIva += dIvaTotalSinDesc;

                                dTotalSumaDetalle += Math.Round((lTotal - dDescuentoPorItem), 6);

                                /**+-----------------------------------------
                                 * |         AGREGA DETALLE DE LINEA
                                 * +-----------------------------------------*/

                                Item_un_impuesto = request.Item_un_impuesto(
                                    "B",
                                    "UND",
                                    det["Cantidad"].ToString(),
                                    $"{det["Producto"].ToString()}|" +
                                    $"{det["UNIDAD"].ToString()}|" +
                                    $"{det["GLOSA"].ToString().Replace("&", "&amp;")}|" +
                                    $"{det["volumen"].ToString()}|" +
                                    $"{det["psugerido"].ToString()}|" +
                                    $"{det["Impdist"].ToString()}",
                                    noLinea,
                                    Math.Round(Convert.ToDecimal(det["Precio"].ToString()), 6).ToString(),
                                    lTotal.ToString(),
                                    dDescuentoPorItem.ToString(),
                                    Math.Round((lTotal - dDescuentoPorItem), 6).ToString(),
                                    "IVA",
                                    dr["exento"].ToString() == "Si" ? 2 : 1,
                                    "",
                                    Math.Round(dMontoGravable, 6).ToString(),
                                    Math.Round(dIvaTotalSinDesc, 6).ToString()
                                );

                            }
                            else
                            {

                                decimal lValDesc = Convert.ToDecimal(det["ValPorcentajeDR1"].ToString()) * -1M;
                                decimal lValGrav = Math.Round((Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()) - lValDesc), 6) / 1.12M;
                                decimal lIvaGrav = (Math.Round((Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()) - lValDesc), 6) / 1.12M) * 0.12M;

                                dTotalDescuento += lValDesc;
                                TotalIva += Math.Round(lIvaGrav, 6);

                                Item_un_impuesto = request.Item_un_impuesto(
                                    "B",
                                    "UND",
                                    det["Cantidad"].ToString(),
                                    $"{det["Producto"].ToString()}|" +
                                    $"{det["UNIDAD"].ToString()}|" +
                                    $"{det["GLOSA"].ToString().Replace("&", "&amp;")}|" +
                                    $"{det["volumen"].ToString()}|" +
                                    $"{det["psugerido"].ToString()}|" +
                                    $"{det["Impdist"].ToString()}",
                                    noLinea,
                                    Math.Round(Convert.ToDecimal(det["Precio"].ToString()), 6).ToString(),
                                    Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()), 6).ToString(),
                                    lValDesc.ToString(),
                                    Math.Round(Convert.ToDecimal(det["IMPORTE_TOTAL"].ToString()) - lValDesc, 6).ToString(),
                                    "IVA",
                                    dr["exento"].ToString() == "Si" ? 2 : 1,
                                    "",
                                    Math.Round(lValGrav, 6).ToString(),
                                    Math.Round(lIvaGrav, 6).ToString()
                                );

                            }

                        }

                        Total_impuestos = request.total_impuestos("IVA", Math.Round(TotalIva, 6).ToString()); //regresar a 2 

                        Totales = request.Totales(Math.Round((TotalFactura - dTotalDescuento), 6).ToString()); // regresar a 2

                        /*
                         +---------------------------------------------------------
                         |  SE OBTIENEN LAS SERIES VALIDAS PARA APLICAR NOTAS
                         |  DE CREDITO
                         +---------------------------------------------------------
                         */

                        List<string> lSeries = new List<string>();
                        strQry = $"pa_sel_um_gen_tabcod NULL, 'FEL_SERIES_CREDITO', '{dr["empresa"].ToString()}'";
                        DataTable dtSeries = oFlex.Obtiene(strQry);

                        foreach (DataRow drs in dtSeries.Rows)
                        {

                            lSeries.Add(drs["DESCRIPCION"].ToString());

                        }

                        if (dr["SerieFace"].ToString().Contains("FECAM") == true)
                        {

                            if (dr["empresa"].ToString() == "DMARTE1")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString().Replace("&", "&amp;"),
                                        "2014-5-10000-1477",
                                        "Antiguo",
                                        "FECAM",
                                        dr["NumeroAutFace"].ToString());

                            }
                            else if (dr["empresa"].ToString() == "CODICASA")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString(),
                                        "2014-5-10000-1478",
                                        "Antiguo",
                                        "FECAM",
                                        dr["NumeroAutFace"].ToString());

                            }
                            else if (dr["empresa"].ToString() == "DIUVA")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString(),
                                        "2014-5-10000-1479",
                                        "Antiguo",
                                        "FECAM",
                                        dr["NumeroAutFace"].ToString());

                            }

                        }
                        else if (lSeries.Contains(dr["SerieFace"].ToString()))
                        {
                            request.Complemento_notas(
                                "Notas",
                                "Notas",
                                "http://www.sat.gob.gt/fel/notas.xsd",
                                Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString().Replace("&", "&amp;"),
                                dr["NoAutFel"].ToString(),
                                "",
                                dr["NoSerieFel"].ToString(),
                                dr["NumeroAutFace"].ToString());
                        }
                        else if (dr["SerieFace"].ToString() == "FACTURA AL COSTO" || dr["SerieFace"].ToString() == "FACTURA SERIE A")
                        {

                            if (dr["empresa"].ToString() == "DMARTE1")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString(),
                                        "2018-1-61-364915",
                                        "Antiguo",
                                        "A",
                                        dr["NumeroAutFace"].ToString());

                            }
                            else if (dr["empresa"].ToString() == "CODICASA")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString(),
                                        "2018-1-61-358882",
                                        "Antiguo",
                                        "A-1",
                                        dr["NumeroAutFace"].ToString());

                            }
                            else if (dr["empresa"].ToString() == "DIMAEXSA")
                            {

                                Complemento_NotaCredito =
                                         request.Complemento_notas(
                                             "Notas",
                                             "Notas",
                                             "http://www.sat.gob.gt/fel/notas.xsd",
                                             Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                             dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString(),
                                             "2020-1-61-1244339",
                                             "Antiguo",
                                             "A",
                                             dr["NumeroAutFace"].ToString());

                            }

                        }
                        else if (dr["SerieFace"].ToString() == "FACTURA SERIE G")
                        {

                            if (dr["empresa"].ToString() == "VINOTECA")
                            {

                                Complemento_NotaCredito =
                                    request.Complemento_notas(
                                        "Notas",
                                        "Notas",
                                        "http://www.sat.gob.gt/fel/notas.xsd",
                                        Convert.ToDateTime(dr["FechaFace"].ToString()).ToString("yyyy-MM-dd"),
                                        dr["comentario"].ToString() == string.Empty ? "-" : dr["comentario"].ToString(),
                                        "2018-1-61-491081",
                                        "Antiguo",
                                        "A",
                                        dr["NumeroAutFace"].ToString());

                            }

                        }

                        try
                        {
                            Adenda = request.Adendas("Observaciones", dr["comentario"].ToString().Replace("&", "&amp;"));
                            Adenda = request.Adendas("Codigo", dr["ctacte"].ToString());
                            Adenda = request.Adendas("Bodega", dr["Bodega"].ToString());
                            Adenda = request.Adendas("Ejecutivo", dr["Vendedor"].ToString());
                            Adenda = request.Adendas("Ref", dr["direccion"].ToString().Replace("&", "&amp;"));
                            Adenda = request.Adendas("Pedido", dr["numero"].ToString());
                            Adenda = request.Adendas("Condiciones", dr["forma_pago"].ToString());
                            Adenda = request.Adendas("LPrecios", dr["LisPrecio"].ToString());
                            Adenda = request.Adendas("TDocto", dr["tipodocto"].ToString().Replace("&", "&amp;"));
                            Adenda = request.Adendas("TSkus", TotalSkus.ToString());
                            Adenda = request.Adendas("TUnidades", TotalUnidades.ToString());
                        }
                        catch { }

                        Dictionary<string, string> dictResponse = null;
                        response = null;

                        Agregar_adenda = request.Agregar_adendas();

                        response = request.enviar_peticion_fel(
                            dicDatosEmisor["PREFIJO"].Item1,
                            dicDatosEmisor["LLAVE"].Item1,
                            $"{dr["empresa"].ToString()}{dr["tipodocto"].ToString().Replace("&", "&amp;")}{dr["correlativo"].ToString()}",
                            dicDatosEmisor["EMAIL_COPIA"].Item1,
                            dicDatosEmisor["ALIAS_PFX"].Item1,
                            dicDatosEmisor["LLAVE_PFX"].Item1,
                            true);

                        /*+-------------------------------
                          |     PARSE JSON RESPUESTA
                          +-------------------------------*/
                        string jsonString = "";
                        if (response != null)
                        {
                            jsonString =
                           ExtractJsonObject(response);
                            //dictResponse =
                            //    response.ParseResponse(pDirectorioFel);

                        }
                        var jsonRespuestaObject = JsonConvert.DeserializeObject<respuestaFel>(jsonString);


                        if (true)
                        {

                            if (jsonRespuestaObject.resultado)
                            {

                                string lsSQL =
                                    $"pa_ins_um_gen_log_documento_face " +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"'{DateTime.Now.ToString("HHmmss")}', " +
                                    $"NULL, " +
                                    $"{TotalFactura}, " +
                                    $"{noLinea.ToString()}";

                                oFlex.Ingresa(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                lsSQL =
                                    $"pa_ins_fel_docto_cert " +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"{dr["correlativo"].ToString()}, " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"'{DateTime.Now.ToString("yyyy-MM-dd")}', " +
                                    $"'{jsonRespuestaObject.uuid}', " +
                                    $"'{jsonRespuestaObject.serie}', " +
                                    $"'{jsonRespuestaObject.numero}', " +
                                    $"'{jsonRespuestaObject.fecha.ToString("yyyy-MM-dd HH:mm")}'";

                                oFlex.Ingresa(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                lsSQL = $"pa_upd_fel_nota_credito" +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"'{jsonRespuestaObject.uuid}', " +
                                    $"'{jsonRespuestaObject.serie}', " +
                                    $"'{jsonRespuestaObject.numero}'";

                                oFlex.Actualiza(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                lsSQL = $"pa_upd_um_gen_log_documento_face_proceso_comentario " +
                                    $"'{dr["empresa"].ToString()}', " +
                                    $"'{dr["tipodocto"].ToString()}', " +
                                    $"'{dr["numero"].ToString()}', " +
                                    $"''";

                                oFlex.Actualiza(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                            }
                            else
                            {

                                string lsSQL =
                                        $"pa_ins_um_gen_log_documento_face " +
                                        $"'{dr["empresa"].ToString()}', " +
                                        $"'{dr["tipodocto"].ToString()}', " +
                                        $"'{dr["numero"].ToString()}', " +
                                        $"'{DateTime.Now.ToString("HHmmss")}', " +
                                        $"NULL, " +
                                        $"{TotalFactura}, " +
                                        $"{noLinea.ToString()}";

                                oFlex.Ingresa(lsSQL);
                                if (oFlex.Codigo_error > 0)
                                    oFlex.Escribir_Log("No se pudo ingresar el log.");

                                var jo = JObject.Parse(jsonString);

                                string MensajeInfile = jo["descripcion_errores"][0]["mensaje_error"].ToString();
                                oFlex.Escribir_Log(MensajeInfile);

                                lsSQL =
                                     $"pa_upd_um_gen_log_documento_face_proceso_comentario" +
                                     $"'{dr["empresa"].ToString()}'," +
                                     $"'{dr["tipodocto"].ToString()}', " +
                                     $"'{dr["numero"].ToString()}', " +
                                     $"'{MensajeInfile}'";

                                oFlex.Actualiza(lsSQL);

                                //foreach (var k in dictResponse.Keys)
                                //{

                                //    lsSQL =
                                //         $"pa_upd_um_gen_log_documento_face_proceso_comentario" +
                                //         $"'{dr["empresa"].ToString()}'," +
                                //         $"'{dr["tipodocto"].ToString()}', " +
                                //         $"'{dr["numero"].ToString()}', " +
                                //         $"'{dictResponse[k]}'";

                                //    oFlex.Actualiza(lsSQL);

                                //}

                            }

                        }

                    }

                }
                catch (Exception ex)
                {

                    string lErr = "";

                    lErr = $"{ex.Source}, {ex.TargetSite.Name}\r\n" +
                        $"\tEn: {ex.StackTrace}\r\n";

                    if (ex.InnerException == null)
                    {

                        lErr = $"{lErr}\tExcepcion: {ex.Message}\r\n";

                    }
                    else
                    {

                        lErr = $"{lErr}\tExcepcion: {ex.InnerException.Message}\r\n";

                    }

                    oFlex.Escribir_Log(lErr);

                    return false;

                }

            }

            return lRespuesta;

        }

        private bool CrearDoctoFelFlexline(
            DataSet pDsDatosFel,
            string pStrUuid,
            string pStrSerie,
            string pStrNumero,
            string pStrFechaCert,
            Tuple<string, string, string, string> pTpPedidoEnviado,
            DateTime pFechaDocto)
        {

            string strNumero = "";
            bool lRespuesta = false;
            DataTable dtDocumentos = null;
            DataTable dtDocExentos = null;
            DataTable dtValoresNumero = null;
            ClasesGenerales.General oGeneral = new ClasesGenerales.General();
            Transaccional.Conexion oFlex = new Conexion("Flexline");

            try
            {

                oFlex.open();

            }
            catch (Exception ex)
            {

                oFlex.Escribir_Log("FEL: No se pudo establecer la conexion a BDFlexline");
                oFlex.Escribir_Log($"FEL: {ex.Message}");
                return false;

            }

            DataSet odsFel = pDsDatosFel.Copy();
            odsFel.Tables["pedidos"].Rows.Clear();

            //DateTime dFechaProceso = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //dFechaProceso = new DateTime(2019, 10, 9);

            string lsSQL = "";

            if (pTpPedidoEnviado.Item2 == "PEDIDO FEL TMK" || pTpPedidoEnviado.Item2 == "PEDIDO FEL AUTOCONSUMO TMK")
            {
                lsSQL =
                    $"pa_sel_um_tipodocumento_FelPura_tmk '{pTpPedidoEnviado.Item1}'" +
                    $", '{pFechaDocto.ToString("dd/MM/yyyy")}', '{pFechaDocto.ToString("dd/MM/yyyy")}', 0";
            }
            else
            {
                lsSQL =
                    $"pa_sel_um_tipodocto_creditos_FelPura '{pTpPedidoEnviado.Item1}'" +
                    $", '{pFechaDocto.ToString("dd/MM/yyyy")}', '{pFechaDocto.ToString("dd/MM/yyyy")}', 0";
            }

            dtDocumentos = oFlex.Obtiene(lsSQL);

            //string lsSQL =
            //    $"pa_sel_um_tipodocumento_exentas_FelPura '{pTpPedidoEnviado.Item1}'" +
            //    $", '{dFechaProceso.ToString("dd/MM/yyyy")}', '{dFechaProceso.ToString("dd/MM/yyyy")}', 0";

            //dtDocExentos = oFlex.Obtiene(lsSQL);

            dtDocumentos.DefaultView.RowFilter =
                $"tipoDoctoOrigen = '{pTpPedidoEnviado.Item2}' And numero = '{pTpPedidoEnviado.Item4}'";

            //if(dtDocExentos.Rows.Count > 0)
            //{

            //    DataRow rDocExento = dtDocumentos.NewRow();

            //    for(int i = 0; i <= dtDocumentos.Columns.Count - 1; i++)
            //    {

            //        rDocExento[i] = dtDocumentos.Rows[0][i];

            //    }

            //    dtDocumentos.Rows.Add(rDocExento);

            //}

            if (dtDocumentos.DefaultView.Count == 1)
            {

                DataRow drPedidoFel = odsFel.Tables["pedidos"].NewRow();

                drPedidoFel["tipoDoctoOrigen"] = pTpPedidoEnviado.Item2;
                drPedidoFel["numero"] = pTpPedidoEnviado.Item4;
                drPedidoFel["fechaFACE"] = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                switch (pTpPedidoEnviado.Item2)
                {
                    case "PEDIDO FEL RE":
                        drPedidoFel["serieFACE"] = "FEL RE";
                        break;
                    case "PEDIDO FEL RE XE":
                        drPedidoFel["serieFACE"] = "FEL RE XE";
                        break;
                    case "PEDIDO FEL RE AG":
                        drPedidoFel["serieFACE"] = "FEL RE AG";
                        break;
                    case "PEDIDO FEL COSTO":
                        drPedidoFel["serieFACE"] = "FEL AL COSTO";
                        break;
                    case "PEDIDO FEL EXENTO":
                        drPedidoFel["serieFACE"] = "FEL EXENTA";
                        break;
                    case "PEDIDO FEL TMK":
                        drPedidoFel["serieFACE"] = "FEL TMK";
                        break;
                    case "PEDIDO FEL COSTO TMK":
                        drPedidoFel["serieFACE"] = "FEL COSTO TMK";
                        break;
                    case "PEDIDO FEL AUTOCONSUMO TMK":
                        drPedidoFel["serieFACE"] = "FEL AUTOCONSUMO TMK";
                        break;
                }

                lsSQL = $"pa_sel_numero_fel '{pTpPedidoEnviado.Item1}', '{drPedidoFel["serieFACE"]}'";
                dtValoresNumero = oFlex.Obtiene(lsSQL);

                if (dtValoresNumero != null)
                {

                    if (dtValoresNumero.Rows.Count > 0)
                    {

                        //strNumero = dtValoresNumero.Rows[0]["CorrelativoActual"].ToString().PadLeft(
                        //    Convert.ToInt32(dtValoresNumero.Rows[0]["LargoNumero"].ToString()), 
                        //    '0');

                        strNumero = pTpPedidoEnviado.Item4;

                    }

                }

                drPedidoFel["numeroFACE"] = strNumero;
                drPedidoFel["firmaFACE"] = pStrUuid;
                drPedidoFel["nitFACE"] = dtDocumentos.DefaultView[0]["codlegal"].ToString();
                drPedidoFel["nombreFACE"] = dtDocumentos.DefaultView[0]["nombre_cliente"].ToString();
                drPedidoFel["direccionFACE"] = dtDocumentos.DefaultView[0]["direccion"].ToString();
                drPedidoFel["ctacte"] = dtDocumentos.DefaultView[0]["ctacte"].ToString();
                drPedidoFel["ImpresoraFACE"] = dtDocumentos.DefaultView[0]["impresora"].ToString();
                drPedidoFel["BodegaInterEmpresas"] =
                     dtDocumentos.DefaultView[0]["bodegaFacturar"] != null ? dtDocumentos.DefaultView[0]["bodegaFacturar"].ToString() : "";
                drPedidoFel["forma_pago"] =
                    dtDocumentos.DefaultView[0]["codigopago"] != null ? dtDocumentos.DefaultView[0]["codigopago"].ToString() : "";

                odsFel.Tables["pedidos"].Rows.Add(drPedidoFel);

                decimal dTotal =
                    decimal.Parse(
                        dtDocumentos.DefaultView[0]["total"].ToString().TrimEnd(new char[] { '0' }));

                decimal dTotalPrevio =
                    decimal.Parse(
                        dtDocumentos.DefaultView[0]["totalPedidoPrevio"].ToString().TrimEnd(new char[] { '0' }));

                decimal dDifTotales = dTotal - dTotalPrevio;

                if (dDifTotales > decimal.Parse("0.1"))
                {

                    oFlex.Escribir_Log(
                        $"Problemas con los totales en el Documento {pTpPedidoEnviado.Item1} {pTpPedidoEnviado.Item2} {pTpPedidoEnviado.Item4}" +
                        $"{pStrSerie} {pStrUuid}");

                    GuardarAvisoError(
                        $"Problemas con los totales en el Documento  {pTpPedidoEnviado.Item1} {pTpPedidoEnviado.Item2} {pTpPedidoEnviado.Item4}" +
                        $"{pStrSerie} {pStrUuid}",
                        31);

                    lsSQL =
                        $"pa_upd_um_gen_log_documento_face_proceso_comentario '{pTpPedidoEnviado.Item1}', '{pTpPedidoEnviado.Item2}'" +
                        $", '{pTpPedidoEnviado.Item4}', 'Diferencia En Los Totales Flex-FEL'";

                    oFlex.Actualiza(lsSQL);

                }
                else
                {

                    odsFel.Tables["pedidos"].DefaultView.RowFilter = "";

                    foreach (DataRowView drvPedido in odsFel.Tables["pedidos"].DefaultView)
                    {

                        if (drvPedido["numeroFACE"].ToString().Trim().Length > 0)
                        {

                            lsSQL =
                                $"pa_ins_um_documento_FEL " +
                                $"'{pTpPedidoEnviado.Item1}', " +
                                $"'{drvPedido["tipodoctoOrigen"].ToString()}'," +
                                $"'{drvPedido["numero"].ToString()}', " +
                                $"'{drvPedido["serieFACE"].ToString()}', " +
                                $"'{drvPedido["numeroFACE"].ToString()}', " +
                                $"'{drvPedido["firmaFACE"].ToString()}', " +
                                $"'{pTpPedidoEnviado.Item1}', " +
                                $"'{drvPedido["fechaFACE"].ToString()}', " +
                                $"'{pStrSerie}', " +
                                $"'{pStrNumero}'," +
                                $"'{pStrFechaCert}'";

                            if (oFlex.Ingresa(lsSQL) > 0)
                            {

                                lsSQL = $"pa_ins_um_documentod_FACE " +
                                    $"'{pTpPedidoEnviado.Item1}', " +
                                    $"'{drvPedido["tipodoctoOrigen"].ToString()}', " +
                                    $"'{drvPedido["numero"].ToString()}', " +
                                    $"'{drvPedido["serieFACE"]}', " +
                                    $"'{drvPedido["numeroFACE"]}', " +
                                    $"'{DateTime.Parse(drvPedido["fechaFACE"].ToString(), new System.Globalization.CultureInfo("es-GT")).ToString("dd-MM-yyyy")}'";

                                oFlex.Ingresa(lsSQL);

                                if (oFlex.Codigo_error > 0)
                                    GuardarAvisoError(oFlex.descripcion_error, 31);

                                lsSQL = $"pa_ins_um_documentop_FACE " +
                                    $"'{pTpPedidoEnviado.Item1}', " +
                                    $"'{drvPedido["tipodoctoOrigen"].ToString()}', " +
                                    $"'{drvPedido["numero"].ToString()}', " +
                                    $"'{drvPedido["serieFACE"]}', " +
                                    $"'{drvPedido["numeroFACE"]}'";

                                oFlex.Ingresa(lsSQL);

                                if (oFlex.Codigo_error > 0)
                                    GuardarAvisoError(oFlex.descripcion_error, 31);

                                lsSQL = $"pa_ins_um_documentov_FACE " +
                                    $"'{pTpPedidoEnviado.Item1}', " +
                                    $"'{drvPedido["tipodoctoOrigen"].ToString()}', " +
                                    $"'{drvPedido["numero"].ToString()}', " +
                                    $"'{drvPedido["serieFACE"]}', " +
                                    $"'{drvPedido["numeroFACE"]}'";

                                oFlex.Ingresa(lsSQL);

                                if (oFlex.Codigo_error > 0)
                                    GuardarAvisoError(oFlex.descripcion_error, 31);

                                lsSQL = $"pa_upd_um_documento_estado " +
                                    $"'{pTpPedidoEnviado.Item1}', " +
                                    $"'{drvPedido["tipodoctoOrigen"].ToString()}', " +
                                    $"'{drvPedido["numero"].ToString()}', " +
                                    $"NULL," +
                                    $"'A', " +
                                    $"'{drvPedido["UsuarioModif"].ToString()}', " +
                                    $"'{drvPedido["serieFACE"]} {drvPedido["numeroFACE"]}'";

                                oFlex.Ingresa(lsSQL);

                                if (oFlex.Codigo_error > 0)
                                    GuardarAvisoError(oFlex.descripcion_error, 31);

                                lsSQL = $"pa_upd_um_gen_log_documento_face_proceso " +
                                    $"'{pTpPedidoEnviado.Item1}', " +
                                    $"'{drvPedido["tipodoctoOrigen"].ToString()}', " +
                                    $"'{drvPedido["numero"].ToString()}'";

                                oFlex.Actualiza(lsSQL);

                                if (oFlex.Codigo_error > 0)
                                    GuardarAvisoError(oFlex.descripcion_error, 31);

                                lsSQL = $"pa_upd_um_gen_log_documento_face_proceso_comentario " +
                                    $"'{pTpPedidoEnviado.Item1}', " +
                                    $"'{drvPedido["tipodoctoOrigen"].ToString()}', " +
                                    $"'{drvPedido["numero"].ToString()}', " +
                                    $"''";

                                oFlex.Actualiza(lsSQL);

                                if (oFlex.Codigo_error > 0)
                                    GuardarAvisoError(oFlex.descripcion_error, 31);

                            }

                        }

                    }

                }

            }

            return lRespuesta;

        }

        private void GuardarAvisoError(
            string pStrComentario,
            int pIntId)
        {

            ClasesGenerales.General oGeneral = new ClasesGenerales.General();
            DataTable dtAvisos = oGeneral.usuariosAviso(pIntId);

            foreach (DataRow drAviso in dtAvisos.Rows)
            {

                _ = oGeneral.guardarAviso(
                     drAviso["usuario"].ToString(),
                     "Umbright",
                     $"Factura Electronica {pStrComentario}",
                     pIntId);

            }

        }

        private Boolean ImprimirReporteGenerico(
            string pDirReporte,
            string[] pPm_parametros,
            string[] pPm_valores,
            string pServidor,
            string pBaseDatos,
            string pUsuario,
            string pPwd,
            Boolean pExportar,
            Boolean pImprimir,
            string pTipoExportar,
            Boolean pMostrarArchivo,
            string pNombreArchivo,
            Boolean pMostrarError,
            int pNoCopias,
            string pEmpresa,
            string pImpresora)
        {

            Boolean lResultado = true;
            Automatizar.Reportes_CraxDrt oReportes = new Automatizar.Reportes_CraxDrt("CODICASA");

            if (pNombreArchivo.Length > 0)
            {
                oReportes.Archivo_Generado = pNombreArchivo;
            }

            oReportes.pnNumeroCopias = pNoCopias;

            if (pImpresora.Length > 0)
            {
                oReportes.psImpresora = pImpresora.Split(',')[0];
                oReportes.psPort = pImpresora.Split(',')[1];
            }

            oReportes._reporte_generico(
                pDirReporte,
                pPm_parametros,
                pPm_valores,
                pServidor,
                pBaseDatos,
                pUsuario,
                pPwd,
                pExportar,
                pImprimir,
                pTipoExportar,
                pMostrarArchivo);

            if (oReportes.Descripcion_Error.Length > 0)
            {
                lResultado = false;
                if (pMostrarError)
                {
                    GuardarAvisoError(
                        $"Problemas al imprimir " +
                        $"{pPm_valores[1]} {pPm_valores[2]} {oReportes.Descripcion_Error}", 31);
                    oFlex.Escribir_Log(oReportes.Descripcion_Error);
                }
            }

            oReportes.finalizar();
            return lResultado;

        }
        public string ExtractJsonObject(string mixedString)
        {
            for (var i = mixedString.IndexOf('{'); i > -1; i = mixedString.IndexOf('{', i + 1))
            {
                for (var j = mixedString.LastIndexOf('}'); j > -1; j = mixedString.LastIndexOf("}", j - 1))
                {
                    var jsonProbe = mixedString.Substring(i, j - i + 1);
                    try
                    {
                        return jsonProbe.ToString();
                    }
                    catch
                    {

                    }
                }
            }
            return null;
        }

        public string procesaInfileJson(string jsontxt, string correlativo, string fechaped, string TipoCertificado)
        {

            var jsonRespuestaObject = JsonConvert.DeserializeObject<respuestaFel>(jsontxt);


            if (jsonRespuestaObject.resultado)
            {




                string xml_certificadoString;
                var decodebase64XML = System.Convert.FromBase64String(jsonRespuestaObject.xml_certificado);
                xml_certificadoString = System.Text.Encoding.UTF8.GetString(decodebase64XML);

                try
                {
                    return "numero: " + jsonRespuestaObject.numero + " serie: " + jsonRespuestaObject.serie + " uuid: " + jsonRespuestaObject.uuid + " ";
                }
                catch (Exception e)
                {
                    return "Ocurrió un error en el guardado " + e;
                }




            }
            else
            {

                var jo = JObject.Parse(jsontxt);

                var MensajeInfile = jo["descripcion_errores"][0]["mensaje_error"].ToString();

                return "ocurrio un error " + MensajeInfile;
            }

        }
        public string obtenerRutaXMLWalmart(string empresa)
        {
            Conexion oFlex = new Conexion("Flexline");
            string rutaFel = "";
            int lastindex = 0;
            string rutaFelNew;

            try
            {

                oFlex.open();
                DataTable dtGenParSistema = oFlex.Obtiene("pa_sel_um_gen_parametros_sistema");
                rutaFel = dtGenParSistema.Rows[0]["path_fel"].ToString();
                lastindex = rutaFel.IndexOf(@"\", 3);
                rutaFelNew = rutaFel.ToString().Substring(0, lastindex + 1);

                rutaFel = $@"{rutaFelNew}";
                //rutaFel = rutaFel.Replace(@"\\", @"\");



            }
            catch (Exception ex)
            {
                oFlex.Escribir_Log("Ocurrio un error en pa_sel_um_gen_parametros_sistema: " + ex.Message);
            }
            finally
            {
                oFlex.close();
            }

            return rutaFel;
        }


        public class respuestaFel
        {
            public string uuid { get; set; }
            public string serie { get; set; }
            public string numero { get; set; }

            public DateTime fecha { get; set; }
            public string xml_certificado { get; set; }
            public bool resultado { get; set; }

            // public string descripcion_errores { get; set; }
            public IList<string> descripcion_alertas_infile { get; set; }

        }

    }

}
