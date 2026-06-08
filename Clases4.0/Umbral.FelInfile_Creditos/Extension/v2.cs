using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

namespace Umbral.FelInFile.Extension
{
    public class V2 : Transaccional.Conexion
    {

        private string lSentencia = "";

        public string SQL { set => lSentencia = value; }
        public string Error { get; private set; } = "";
        public string CadenaConexion { get; private set; } = "";
        public string Servidor { get; set; } = "";
        public DataSet Datos { get; private set; } = new DataSet();

        public V2(string servidor) : base(servidor)
        {}

        public V2(string tipo_conexion, int codigo_ubicacion) : base(tipo_conexion, codigo_ubicacion)
        {}

        public void ObtieneConexion()
        {

            if(Servidor == string.Empty)
            {
                Error = "No indico el servidor.";
                return;
            }

            Error = "";

            CadenaConexion = ObtieneCadenaConexion();

        }

        public void ObtieneInformacion()
        {

            if(lSentencia == string.Empty)
            {

                Error = "No a especificado una consulta.";
                return;               

            }

            Error = "";

            System.Data.SqlClient.SqlConnection lConn = 
                new System.Data.SqlClient.SqlConnection(ObtieneCadenaConexion());
            System.Data.SqlClient.SqlCommand lComm = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataAdapter lAdapter = new System.Data.SqlClient.SqlDataAdapter();

            Datos.Tables.Clear();

            try
            {
                lConn.Open();

                lComm.Connection = lConn;
                lComm.CommandText = lSentencia;
                lAdapter.SelectCommand = lComm;

                lAdapter.Fill(Datos);

                lConn.Close();

            }
            catch(Exception ex) {

                Error = $"No se pudo realizar la consulta, Ex: {ex.Message}";

                if(lConn.State != ConnectionState.Closed)
                {
                    lConn.Close();
                }

            }

        }

        private string ObtieneCadenaConexion()
        {

            string lCadena = "";
            string lNombreUsuario = "";
            string lPassword = "";
            string lServidor = "";
            string lNombreBD = "";
            System.Data.SqlClient.SqlConnectionStringBuilder lConn = new System.Data.SqlClient.SqlConnectionStringBuilder();

            try
            {

                string Linea1 = string.Empty;
                string Linea2 = string.Empty;
                string lubicacion = System.Configuration.ConfigurationManager.AppSettings.Get("ubicacion");

                Linea1 = System.Configuration.ConfigurationManager.AppSettings.Get($"linea1_{Servidor}_{lubicacion}");
                Linea2 = System.Configuration.ConfigurationManager.AppSettings.Get($"linea2_{Servidor}_{lubicacion}");

                if(Linea1 is null || Linea1 == string.Empty)
                {

                    lNombreUsuario = System.Configuration.ConfigurationManager.AppSettings.Get("usr_sql_");
                    lPassword = System.Configuration.ConfigurationManager.AppSettings.Get("pwd_sql_");
                    lServidor = System.Configuration.ConfigurationManager.AppSettings.Get("servidor_sql_");
                    lNombreBD = System.Configuration.ConfigurationManager.AppSettings.Get("bd_sql_");

                }
                else
                {

                    string Data1 = string.Empty;
                    string svalor = string.Empty;
                    StringBuilder Data2 = new StringBuilder();

                    while (Linea1.Length > 0)
                    {

                        Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Linea1.Substring(0, 2), 16)).ToString();
                        Data2.Append(Data1);
                        Linea1 = Linea1.Substring(2, Linea1.Length - 2);

                    }

                    svalor = Data2.ToString();
                    lServidor = svalor.Split(',')[0];
                    lNombreBD = svalor.Split(',')[1];

                    Data2 = new StringBuilder();

                    while(Linea2.Length > 0)
                    {

                        Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Linea2.Substring(0, 2), 16)).ToString();
                        Data2.Append(Data1);
                        Linea2 = Linea2.Substring(2, Linea2.Length - 2);

                    }

                    svalor = Data2.ToString();
                    lNombreUsuario = svalor.Split(',')[0];
                    lPassword = svalor.Split(',')[1];

                }

                lConn.ApplicationName = "InFile FEL";
                lConn.DataSource = lServidor;
                lConn.InitialCatalog = lNombreBD;
                lConn.Password = lPassword;
                lConn.UserID = lNombreUsuario;

                lCadena = lConn.ToString();

            }
            catch (Exception ex) {

                Error = $"No se pudo obtener la conexion, Ex: {ex.Message}";

            }
                       
            return lCadena;

        }

    }

}