using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Transaccional;
using Umbral.FelInFile;

namespace Umbral.FelInFileCreditos
{
    public class AnularFel
    {

        Conexion oFlex = new Conexion("Flexline");

        public bool AnularDoctoInFile(
            DataSet pDsDatosFel,
            string pMotivo,
            string pDirectorioFel)
        {

            bool lResultado = false;
            apifel4.RequestAnulacionFel requestv1;
            conectorfelv2.RequestAnulacionFel request;

            try
            {

                oFlex.open();

                foreach (DataRow dr in pDsDatosFel.Tables["pedidos"].Rows)
                {

                    string strQry = $"pa_sel_um_gen_tabcod NULL, 'FEL_EMISOR', {dr["empresa"].ToString()}";
                    DataTable dtDatosEmisor = oFlex.Obtiene(strQry);
                    Dictionary<string, Tuple<string, string, string>> dicDatosEmisor =
                        new Dictionary<string, Tuple<string, string, string>>();

                    foreach (DataRow dato in dtDatosEmisor.Rows)
                    {

                        dicDatosEmisor.Add(
                            dato["CODIGO"].ToString(),
                            new Tuple<string, string, string>(
                                dato["DESCRIPCION"].ToString(),
                                dato["TEXTO"].ToString(),
                                dato["TEXTO1"].ToString()));

                    }

                    string strQuery =
                        $"pa_sel_empresa_fel {dr["empresa"].ToString()}";

                    DataTable tblDatosEmpresa = oFlex.Obtiene(strQuery);

                    request = new conectorfelv2.RequestAnulacionFel();

                    request.Datos_anulacion(
                        DateTime.Now.ToString("yyyy-MM-dd"),
                        dr["FechaAutFel"].ToString(),
                        dr["NitFactFel"].ToString().Replace("-", "").Replace("CUI","").Replace("EXT",""),
                        tblDatosEmpresa.Rows[0]["RUT"].ToString().Replace("-", ""),
                        pMotivo,
                        dr["AutFel"].ToString());

                    string response = request.enviar_anulacion_fel(
                        dicDatosEmisor["PREFIJO"].Item1,
                        dicDatosEmisor["LLAVE"].Item1,
                        $"{dr["empresa"].ToString()}{dr["tipodocto"].ToString()}{dr["correlativo"].ToString()}",
                        dicDatosEmisor["EMAIL_COPIA"].Item1,
                        dicDatosEmisor["ALIAS_PFX"].Item1,
                        dicDatosEmisor["LLAVE_PFX"].Item1,
                        true);

                    Dictionary<string, string> dictResponse = null;

                    if (response != null)
                    {

                        dictResponse =
                            response.ParseResponse(pDirectorioFel);

                    }

                    if (dictResponse != null)
                    {

                        if (dictResponse.ContainsKey("ERR_1") == false)
                        {

                            lResultado = true;

                        }

                    }
                
                }

            }
            catch(Exception ex)
            {

                oFlex.Escribir_Log($"Error al anular el documento. Err: {ex.Message}");

            }
                       
            return lResultado;

        }

    }
}
