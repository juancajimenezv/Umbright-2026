using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umbral.FelInFile
{
    public static class Tools
    {

        public static bool GuardarXmlFirmadoWM(
            string pArchivoEncriptado,
            string pDirectorioLocal,
            string pDirectorioWalmart,
            string pEmpresa,
            string pNumero)
        {

            bool lResultado = false;
            Transaccional.Conexion oFlex = new Transaccional.Conexion("Flexline");

            try
            {

                string strXmlCertificado =
                     Encoding.UTF8.GetString(Convert.FromBase64String(pArchivoEncriptado));

                System.IO.File.WriteAllText(System.IO.Path.Combine(pDirectorioLocal, $"{pEmpresa.ToUpper()}_FEL RE_{pNumero}_DTE.xml"), strXmlCertificado);

                try
                {

                    System.IO.File.WriteAllText(System.IO.Path.Combine(pDirectorioWalmart, $"{pEmpresa.ToUpper()}_FEL RE_{pNumero}_DTE.xml"), strXmlCertificado);

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

                lResultado = true;

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

            return lResultado;

        }

    }

}
