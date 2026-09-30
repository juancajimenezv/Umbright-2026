using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Transaccional;
using ClasesGenerales;
using ZedGraph;
using System.Drawing;
using System.Globalization;

namespace Compras
{
    public class SCM
    {
        DataSet ds_preparacion;
        string scm_empresa = string.Empty;
        string scm_region = string.Empty;
        string scm_area = string.Empty;
        string scm_origen = string.Empty;
        string scm_producto_limite = string.Empty;
        string scm_proveedor = string.Empty;
        string scm_puerto = string.Empty;
        Boolean scm_proyeccion = false;
        private int cantidad;
        Boolean scm_minimo_compra_standard = false; // Cuando este marcada la opcion debe tomar el campo minimo_compra_standard en lugar de minimo de compra

        public SCM()
        {
        }

        public SCM(ref DataSet ds)
        {
            ds_preparacion = ds;
        }

        public Boolean minimo_standard
        {
            get
            {
                return scm_minimo_compra_standard;
            }
            set
            {
                scm_minimo_compra_standard = value;
            }
        }


        public Boolean proyeccion
        {
            get
            {
                return scm_proyeccion;
            }
            set
            {
                scm_proyeccion = value;
            }
        }


        public string Empresa
        {
            get
            {
                return scm_empresa;
            }
            set
            {
                scm_empresa = value;
            }
        }

        public string Region
        {
            get
            {
                return scm_region;
            }
            set
            {
                scm_region = value;
            }
        }

        public string Puerto
        {
            get
            {
                return scm_puerto;
            }
            set
            {
                scm_puerto = value;
            }
        }

        public void SetArea(string area)
        {
            scm_area = area;
        }

        public void SetOrigen(string origen)
        {
            scm_origen = origen;
        }

        public void SetProductoLimite(string productolimite)
        {
            scm_producto_limite = productolimite;
        }

        public string Proveedor
        {
            get
            {
                return scm_proveedor;
            }
            set
            {
                scm_proveedor = value;
            }
        }


        //Generar Minimos y Maximos

        public void Minimos_Maximos(int isemanaactual, bool brecalcular_maximo)
        {


            decimal icount, imaximo, ifrecuencia_compra, ilead_time, daux, isemana, iseguridad;
            string lsnombrecampo;

            ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter = "";

            try
            {


                foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
                {


                    ilead_time = decimal.Parse(dr["pv_lead_time_total"].ToString());
                    ifrecuencia_compra = decimal.Parse(dr["pv_ciclo_compra"].ToString());
                    // dmargen_seguridad = 1 + (decimal.Parse(dr["pv_margen_seguridad"].ToString())/100);
                    imaximo = decimal.Parse(dr["pv_inv_maximo"].ToString());
                    iseguridad = decimal.Parse(dr["pv_inv_seguridad"].ToString());
                    //ireorden = decimal.Parse(dr["pv_inv_reorden"].ToString());
                    //imaximo = imaximo * dmargen_seguridad;

                    //Establecer para que sirven el Margen de Seguridad

                    isemana = -1;
                    isemana += isemanaactual;
                    icount = ilead_time + iseguridad;  //Debo Sumarle en Inventario de Seguidad al LeadTime
                    // icount -= isemanaactual; //si el lt = 14 y empieza en la semana 1 debe terminar en la 15 para hacer siempre 14
                    //    imaximo += iseguridad; //Debo Sumarle el Inventario de Seguridad al Inventario Maximo (c)231107 Solo se le Agrega el Maximo al lead time
                    if (dr["producto"].ToString() == "0200020002")
                        dr["producto"] = "0200020002";

                    daux = 0;
                    while (icount > 0)
                    {
                        isemana += 1;
                        lsnombrecampo = "ppto";
                        if (isemana > 0)
                            lsnombrecampo += "+" + isemana.ToString("00");

                        if (icount >= 1)
                            daux += decimal.Parse(dr[lsnombrecampo].ToString());
                        else
                            daux += decimal.Parse(dr[lsnombrecampo].ToString()) * icount;

                        icount -= 1;

                    }
                    //    daux *= dmargen_seguridad;
                    dr["min_cajas"] = daux;


                    if (!brecalcular_maximo)
                        continue;
                    else
                    {
                        //Maximos Cuanto
                        daux = 0;
                        icount = ilead_time - 1; //se le quita uno para q cuando comienza a calcular se lo vuelve a sumar y empieza en la semana de ingreso

                        while (imaximo > 0)
                        {
                            icount += 1;
                            lsnombrecampo = "ppto";
                            if (icount > 0)
                                lsnombrecampo += "+" + icount.ToString("00");

                            if (imaximo >= 1)
                                daux += decimal.Parse(dr[lsnombrecampo].ToString());
                            else
                                daux += decimal.Parse(dr[lsnombrecampo].ToString()) * imaximo;

                            imaximo -= 1;
                        }
                        dr["max_cajas"] = daux;
                    }
                }
            }
            catch (Exception ex)
            {
                ClasesGenerales.General clsGen = new ClasesGenerales.General();
                clsGen.Escribir_Log(ex.Message);
                clsGen.Escribir_Log(ex.ToString());
                clsGen = null;
            }
        }

        public void Minimos_MaximosSemana(int ifactorsemana, bool brecalcular_maximo)
        {


            decimal icount, imaximo, ifrecuencia_compra, ilead_time, daux, isemana, iseguridad;
            string lsnombrecampo;

            ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter = "";

            try
            {
                foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
                {
                    ilead_time = decimal.Parse(dr["pv_lead_time_total"].ToString());
                    ifrecuencia_compra = decimal.Parse(dr["pv_ciclo_compra"].ToString());
                    // dmargen_seguridad = 1 + (decimal.Parse(dr["pv_margen_seguridad"].ToString())/100);
                    imaximo = decimal.Parse(dr["pv_inv_maximo"].ToString());
                    iseguridad = decimal.Parse(dr["pv_inv_seguridad"].ToString());
                    //ireorden = decimal.Parse(dr["pv_inv_reorden"].ToString());
                    //imaximo = imaximo * dmargen_seguridad;

                    //Establecer para que sirven el Margen de Seguridad

                    isemana = -1;
                    //isemana += isemanaactual;
                    isemana += ifrecuencia_compra * ifactorsemana;
                    icount = ilead_time + iseguridad;  //Debo Sumarle en Inventario de Seguidad al LeadTime
                    // icount -= isemanaactual; //si el lt = 14 y empieza en la semana 1 debe terminar en la 15 para hacer siempre 14
                    //    imaximo += iseguridad; //Debo Sumarle el Inventario de Seguridad al Inventario Maximo (c)231107 Solo se le Agrega el Maximo al lead time
                    if (dr["producto"].ToString() == "0011012032")
                          dr["producto"] = "0011012032";
                    
                    daux = 0;
                    while (icount > 0)
                    {
                        isemana += 1;
                        lsnombrecampo = "ppto";
                        if (isemana > 0)
                            lsnombrecampo += "+" + isemana.ToString("00");

                        if (icount >= 1)
                            daux += decimal.Parse(dr[lsnombrecampo].ToString());
                        else
                            daux += decimal.Parse(dr[lsnombrecampo].ToString()) * icount;

                        icount -= 1;

                    }
                    //    daux *= dmargen_seguridad;
                    dr["min_cajas"] = daux;


                    if (!brecalcular_maximo)
                        continue;
                    else
                    {
                        //Maximos Cuanto
                        daux = 0;
                        icount = ilead_time - 1; //se le quita uno para q cuando comienza a calcular se lo vuelve a sumar y empieza en la semana de ingreso

                        while (imaximo > 0)
                        {
                            icount += 1;
                            lsnombrecampo = "ppto";
                            if (icount > 0)
                                lsnombrecampo += "+" + icount.ToString("00");

                            if (imaximo >= 1)
                                daux += decimal.Parse(dr[lsnombrecampo].ToString());
                            else
                                daux += decimal.Parse(dr[lsnombrecampo].ToString()) * imaximo;

                            imaximo -= 1;
                        }
                        dr["max_cajas"] = daux;
                    }
                }
            }
            catch (Exception ex)
            {
                ClasesGenerales.General clsGen = new ClasesGenerales.General();
                clsGen.Escribir_Log(ex.Message);
                clsGen.Escribir_Log(ex.ToString());
                clsGen = null;
            }
        }

        public void Minimos_MaximosProducto(String psEmpresa, String psProducto, int isemanaactual, bool brecalcular_maximo)
        {

            // DataRow dr;
            // string ls_filtro;

            decimal icount, imaximo, ifrecuencia_compra, ilead_time, daux, isemana, iseguridad, ireorden;
            string lsnombrecampo;
            try
            {


                foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
                {
                    if ((dr["empresa"].ToString().ToLower().Equals(psEmpresa.ToLower())) &&
                            (dr["producto"].ToString().ToLower().Equals(psProducto.ToLower())))
                    {

                        ilead_time = decimal.Parse(dr["pv_lead_time_total"].ToString());
                        ifrecuencia_compra = decimal.Parse(dr["pv_ciclo_compra"].ToString());
                        imaximo = decimal.Parse(dr["pv_inv_maximo"].ToString());
                        iseguridad = decimal.Parse(dr["pv_inv_seguridad"].ToString());
                        ireorden = decimal.Parse(dr["pv_inv_reorden"].ToString());

                        isemana = -1;
                        isemana += isemanaactual;
                        icount = ilead_time + iseguridad;  //Debo Sumarle en Inventario de Seguidad al LeadTime

                        daux = 0;
                        while (icount > 0)
                        {
                            isemana += 1;
                            lsnombrecampo = "ppto";
                            if (isemana > 0)
                                lsnombrecampo += "+" + isemana.ToString("00");

                            if (icount >= 1)
                                daux += decimal.Parse(dr[lsnombrecampo].ToString());
                            else
                                daux += decimal.Parse(dr[lsnombrecampo].ToString()) * icount;

                            icount -= 1;

                        }
                        //    daux *= dmargen_seguridad;
                        dr["min_cajas"] = daux;


                        if (!brecalcular_maximo)
                            continue;
                        else
                        {
                            //Maximos Cuanto
                            daux = 0;
                            icount = ilead_time - 1; //se le quita uno para q cuando comienza a calcular se lo vuelve a sumar y empieza en la semana de ingreso

                            while (imaximo > 0)
                            {
                                icount += 1;
                                lsnombrecampo = "ppto";
                                if (icount > 0)
                                    lsnombrecampo += "+" + icount.ToString("00");

                                if (imaximo >= 1)
                                    daux += decimal.Parse(dr[lsnombrecampo].ToString());
                                else
                                    daux += decimal.Parse(dr[lsnombrecampo].ToString()) * imaximo;

                                imaximo -= 1;
                            }
                            dr["max_cajas"] = daux;
                        }
                        break;
                    }

                }//For Each
            }
            catch (Exception ex)
            {
                ClasesGenerales.General clsGen = new ClasesGenerales.General();
                clsGen.Escribir_Log(ex.Message);
                clsGen.Escribir_Log(ex.ToString());
                clsGen = null;
            }
        }

        public void Generar_Pedido_Sugerido(int nsemanaactual, bool brecalculartodos)
        {
            double ipedido_sugerido, ileadtime;

            string snombrecampo, steoricocalculo;
            string scoberturacalculo;
            bool bcalcular = false;

            try
            {
                foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
                {
                    try
                    {

                        if (dr["producto"].ToString() == "0100010740")
                            dr["producto"] = "0100010740";



                        bcalcular = true;
                        for (int i = 0; i <= nsemanaactual; i++)
                        {
                            snombrecampo = "sugerido";
                            if (i > 0)
                                snombrecampo += "+" + i.ToString("00");
                            if (int.Parse(dr[snombrecampo].ToString()) > 0)
                            {
                                bcalcular = false;
                                break;
                            }
                        }

                        snombrecampo = "sugerido";
                        if (nsemanaactual > 0)
                            snombrecampo += "+" + nsemanaactual.ToString("00");

                        dr[snombrecampo] = 0; //(c) Inicializo el sugerido con 0

                        if (brecalculartodos)
                            bcalcular = true;

                        if (bcalcular)
                        {
                            ipedido_sugerido = 0;
                            dr["pedido"] = 0;
                            snombrecampo = "teorico";
                            steoricocalculo = "teorico";
                            scoberturacalculo = "cobertura";
                            ileadtime = System.Convert.ToInt32(dr["pv_lead_time_total"]);

                            //if (Double.Parse(dr["pv_lead_time_total"].ToString()) > 0)
                            if (ileadtime > 0)
                                snombrecampo += "+" + double.Parse(dr["pv_lead_time_total"].ToString()).ToString("00");

                            if (nsemanaactual > 0)
                                ileadtime += nsemanaactual;

                            steoricocalculo += "+" + ileadtime.ToString("00");
                            scoberturacalculo += "+" + ileadtime.ToString("00");
                            //if (double.Parse(dr["min_cajas"].ToString()) > double.Parse(dr[steoricocalculo].ToString()))
                            //    ipedido_sugerido = double.Parse(dr["max_cajas"].ToString());

                            //Si las semanas de cobertura Son Menor o Igual a las Semanas Reorden Se Pide el Maximo
                            if (double.Parse(dr[scoberturacalculo].ToString()) <= double.Parse(dr["pv_inv_reorden"].ToString()))
                                ipedido_sugerido = double.Parse(dr["max_cajas"].ToString());

                            if (double.Parse(dr[steoricocalculo].ToString()) > 0 && ipedido_sugerido > 0)   //le tiene que restar el inventario que tenga cuando ingrese en la semana del LT
                                ipedido_sugerido -= int.Parse(double.Parse(dr[steoricocalculo].ToString()).ToString("0000000"));


                            if (ipedido_sugerido < 0)
                                ipedido_sugerido = 0;


                            if (ipedido_sugerido > 0)
                            {
                                snombrecampo = "sugerido";
                                if (nsemanaactual > 0)
                                    snombrecampo += "+" + nsemanaactual.ToString("00");

                                dr[snombrecampo] = ipedido_sugerido;
                                dr["tiene_compra"] = true;
                                if (dr["producto"].ToString().Equals("0300030003"))
                                    dr["producto"] = "0300030003";

                                if (dr["full"].ToString().ToLower() == "pallet")
                                {
                                    int ipallet = 0, icajasxpallet;
                                    double dpallet;
                                    icajasxpallet = int.Parse(dr["cajasxpallet"].ToString());
                                    icajasxpallet = icajasxpallet * int.Parse(dr["minimo_compra"].ToString());
                                    if (icajasxpallet < 1)
                                        icajasxpallet = 1;
                                    dpallet = ipedido_sugerido / icajasxpallet;
                                    ipallet = System.Convert.ToInt32(dpallet);

                                    if (ipallet - dpallet > 0.5)
                                        ipallet += 1;

                                    dr["pedido"] = ipallet * icajasxpallet; //ipedido_sugerido;
                                }
                                else

                                    if ((dr["full"].ToString().ToLower() == "layer")) // || (dr["full"].ToString().ToLower() == "cajas"))
                                    {
                                        int ilayer = 0, icajasxlayer;
                                        double dlayer;
                                        icajasxlayer = int.Parse(dr["cajasxlayer"].ToString());
                                        icajasxlayer = icajasxlayer * int.Parse(dr["minimo_compra"].ToString());
                                        if (icajasxlayer < 1) //Cuando trae 0, por q la division por 0 da error 130110 (c)
                                            icajasxlayer = 1;
                                        dlayer = ipedido_sugerido / icajasxlayer;
                                        ilayer = System.Convert.ToInt32(dlayer);
                                        if (ilayer - ilayer > 0.5)
                                            ilayer += 1;

                                        dr["pedido"] = ilayer * icajasxlayer; //ipedido_sugerido;
                                    }
                                    else
                                    {
                                        int iminimo_compra = int.Parse(dr["minimo_compra"].ToString());
                                        if (iminimo_compra > 0)
                                        {
                                            //if (ipedido_sugerido >= iminimo_compra)
                                            //{
                                            //    dr["pedido"] = ipedido_sugerido;
                                            //}
                                            //else
                                            //{
                                            int ilayer = 0, icajaslayer;
                                            double dlayer;
                                            if (iminimo_compra < 1) //Cuando trae 0, por q la division por 0 da error 130110 (c)
                                                iminimo_compra = 1;

                                            dlayer = ipedido_sugerido / iminimo_compra;
                                            ilayer = System.Convert.ToInt32(dlayer);

                                            if (ilayer > 0)
                                                dr["pedido"] = ilayer * iminimo_compra;


                                            //}

                                        }
                                        else
                                        {
                                            dr["pedido"] = ipedido_sugerido;
                                        }
                                    }



                                double dpedido = double.Parse(dr["pedido"].ToString());
                                int lpedido = System.Convert.ToInt32(dpedido);
                                if (lpedido > 0)
                                    dr["valor_sugerido"] = lpedido * double.Parse(dr["fob"].ToString());
                            }
                            //dr["sugerido_anterior"] = 0;
                            //dr["calculos"] = int.Parse(dr["calculos"].ToString()) + 1;
                        }
                        bcalcular = false;

                    
                                }
            catch (Exception ex)
            {
                ClasesGenerales.General clsGen = new ClasesGenerales.General();
                clsGen.Escribir_Log(ex.Message);
                clsGen.Escribir_Log(ex.ToString());
                clsGen = null;
            }


                }


            }
            catch (Exception ex)
            {
                ClasesGenerales.General clsGen = new ClasesGenerales.General();
                clsGen.Escribir_Log(ex.Message);
                clsGen.Escribir_Log(ex.ToString());
                clsGen = null;
            }
        }

        public void Generar_Pedido_Sugerido_Semana(int ifactorsemana, bool brecalculartodos)
        {
            double ipedido_sugerido, ileadtime, ifrecuencia_compra, isemanaproceso;

            string snombrecampo, steoricocalculo, spagocalculo;
            string scoberturacalculo;
            string stransitocalculo;
            bool bcalcular = false;

            //saux = "valor_transito+" + iaux.ToString("00");
            //dr_aux[saux] = 0;

            try
            {
                foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
                {
                    if (dr["producto"].ToString() == "0200020002")
                        dr["producto"] = "0200020002";

                    ifrecuencia_compra = double.Parse(dr["pv_ciclo_compra"].ToString());
                    
                    isemanaproceso = ifrecuencia_compra * ifactorsemana;

                    bcalcular = true;
                   
                    snombrecampo = "sugerido";
                    if (isemanaproceso > 0)
                        snombrecampo += "+" + isemanaproceso.ToString("00");

                    dr[snombrecampo] = 0; //(c) Inicializo el sugerido con 0

                    if (brecalculartodos)
                        bcalcular = true;

                    if (bcalcular)
                    {
                        ipedido_sugerido = 0;
                        dr["pedido"] = 0;
                        snombrecampo = "teorico";
                        steoricocalculo = "teorico";
                        scoberturacalculo = "cobertura";
                        stransitocalculo = "transito";
                        ileadtime = System.Convert.ToInt32(dr["pv_lead_time_total"]);
                        

                        //if (Double.Parse(dr["pv_lead_time_total"].ToString()) > 0)
                        if (ileadtime > 0)
                            snombrecampo += "+" + double.Parse(dr["pv_lead_time_total"].ToString()).ToString("00");

                        if (isemanaproceso > 0)
                            ileadtime += isemanaproceso;
                            
                        
                         

                        steoricocalculo += "+" + ileadtime.ToString("00");
                        scoberturacalculo += "+" + ileadtime.ToString("00");
                        stransitocalculo += "+" + ileadtime.ToString("00");
                        //if (double.Parse(dr["min_cajas"].ToString()) > double.Parse(dr[steoricocalculo].ToString()))
                        //    ipedido_sugerido = double.Parse(dr["max_cajas"].ToString());

                        //Si las semanas de cobertura Son Menor o Igual a las Semanas Reorden Se Pide el Maximo
                        if (double.Parse(dr[scoberturacalculo].ToString()) <= double.Parse(dr["pv_inv_reorden"].ToString()))
                            ipedido_sugerido = double.Parse(dr["max_cajas"].ToString());

                        if (double.Parse(dr[steoricocalculo].ToString()) > 0 && ipedido_sugerido > 0)   //le tiene que restar el inventario que tenga cuando ingrese en la semana del LT
                            ipedido_sugerido -= int.Parse(double.Parse(dr[steoricocalculo].ToString()).ToString("0000000"));


                        if (ipedido_sugerido < 0)
                            ipedido_sugerido = 0;


                        if (ipedido_sugerido > 0)
                        {
                            snombrecampo = "sugerido";
                            if (isemanaproceso > 0)
                                snombrecampo += "+" + isemanaproceso.ToString("00");

                            dr[snombrecampo] = ipedido_sugerido;
                            dr["tiene_compra"] = true;
                            if (dr["producto"].ToString().Equals("0300030003"))
                                dr["producto"] = "0300030003";

                            if (dr["full"].ToString().ToLower() == "pallet")
                            {
                                int ipallet = 0, icajasxpallet;
                                double dpallet;
                                icajasxpallet = int.Parse(dr["cajasxpallet"].ToString());
                                icajasxpallet = icajasxpallet * int.Parse(dr["minimo_compra"].ToString());
                                if (icajasxpallet < 1)
                                    icajasxpallet = 1;
                                dpallet = ipedido_sugerido / icajasxpallet;
                                ipallet = System.Convert.ToInt32(dpallet);

                                if (ipallet - dpallet > 0.5)
                                    ipallet += 1;

                                dr["pedido"] = ipallet * icajasxpallet; //ipedido_sugerido;
                            }
                            else if ((dr["full"].ToString().ToLower() == "layer")) // || (dr["full"].ToString().ToLower() == "cajas"))
                                {
                                    int ilayer = 0, icajasxlayer;
                                    double dlayer;
                                    icajasxlayer = int.Parse(dr["cajasxlayer"].ToString());
                                    icajasxlayer = icajasxlayer * int.Parse(dr["minimo_compra"].ToString());
                                    if (icajasxlayer < 1) //Cuando trae 0, por q la division por 0 da error 130110 (c)
                                        icajasxlayer = 1;
                                    dlayer = ipedido_sugerido / icajasxlayer;
                                    ilayer = System.Convert.ToInt32(dlayer);
                                    if (ilayer - ilayer > 0.5)
                                        ilayer += 1;

                                    dr["pedido"] = ilayer * icajasxlayer; //ipedido_sugerido;
                                }
                                else
                                {
                                    int iminimo_compra = int.Parse(dr["minimo_compra"].ToString());
                                    if (iminimo_compra > 0)
                                    {
                                        //if (ipedido_sugerido >= iminimo_compra)
                                        //{
                                        //    dr["pedido"] = ipedido_sugerido;
                                        //}
                                        //else
                                        //{
                                        int ilayer = 0, icajaslayer;
                                        double dlayer;
                                        if (iminimo_compra < 1) //Cuando trae 0, por q la division por 0 da error 130110 (c)
                                            iminimo_compra = 1;

                                        dlayer = ipedido_sugerido / iminimo_compra;
                                        ilayer = System.Convert.ToInt32(dlayer);

                                        if (ilayer > 0)
                                            dr["pedido"] = ilayer * iminimo_compra;


                                        //}

                                    }
                                    else
                                    {
                                        dr["pedido"] = ipedido_sugerido;
                                    }
                                }



                            double dpedido = double.Parse(dr["pedido"].ToString());
                            int lpedido = System.Convert.ToInt32(dpedido);
                            if (lpedido > 0)
                                dr["valor_sugerido"] = lpedido * double.Parse(dr["fob"].ToString());
                        }
                        //dr["sugerido_anterior"] = 0;
                        //dr["calculos"] = int.Parse(dr["calculos"].ToString()) + 1;
                    }
                    bcalcular = false;
                }

            }
            catch (Exception ex)
            {
                ClasesGenerales.General clsGen = new ClasesGenerales.General();
                clsGen.Escribir_Log(ex.Message);
                clsGen.Escribir_Log(ex.ToString());
                clsGen = null;
            }
        }

        public void generarPedidoSugeridoProducto(String psEmpresa, String psProducto, int nsemanaactual, bool brecalculartodos)
        {
            double ipedido_sugerido, ileadtime;

            string snombrecampo, steoricocalculo;
            string scoberturacalculo;
            bool bcalcular = false;

            try
            {
                foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
                {
                    if ((dr["empresa"].ToString().ToLower().Equals(psEmpresa.ToLower())) &&
                           (dr["producto"].ToString().ToLower().Equals(psProducto.ToLower())))
                    {


                        bcalcular = true;
                        for (int i = 0; i <= nsemanaactual; i++)
                        {
                            snombrecampo = "sugerido";
                            if (i > 0)
                                snombrecampo += "+" + i.ToString("00");
                            if (int.Parse(dr[snombrecampo].ToString()) > 0)
                            {
                                bcalcular = false;
                                break;
                            }
                        }

                        snombrecampo = "sugerido";
                        if (nsemanaactual > 0)
                            snombrecampo += "+" + nsemanaactual.ToString("00");

                        dr[snombrecampo] = 0; //(c) Inicializo el sugerido con 0

                        if (brecalculartodos)
                            bcalcular = true;

                        if (bcalcular)
                        {
                            ipedido_sugerido = 0;
                            snombrecampo = "teorico";
                            steoricocalculo = "teorico";
                            scoberturacalculo = "cobertura";
                            ileadtime = System.Convert.ToInt32(dr["pv_lead_time_total"]);
                            dr["pedido"] = 0;

                            if (ileadtime > 0)
                                snombrecampo += "+" + double.Parse(dr["pv_lead_time_total"].ToString()).ToString("00");

                            if (nsemanaactual > 0)
                                ileadtime += nsemanaactual;

                            steoricocalculo += "+" + ileadtime.ToString("00");
                            scoberturacalculo += "+" + ileadtime.ToString("00");
                            if (double.Parse(dr[scoberturacalculo].ToString()) <= double.Parse(dr["pv_inv_reorden"].ToString()))
                                ipedido_sugerido = double.Parse(dr["max_cajas"].ToString());

                            if (double.Parse(dr[steoricocalculo].ToString()) > 0 && ipedido_sugerido > 0)   //le tiene que restar el inventario que tenga cuando ingrese en la semana del LT
                                ipedido_sugerido -= int.Parse(double.Parse(dr[steoricocalculo].ToString()).ToString("0000000"));


                            if (ipedido_sugerido < 0)
                                ipedido_sugerido = 0;


                            if (ipedido_sugerido > 0)
                            {
                                snombrecampo = "sugerido";
                                if (nsemanaactual > 0)
                                    snombrecampo += "+" + nsemanaactual.ToString("00");

                                dr[snombrecampo] = ipedido_sugerido;
                                dr["tiene_compra"] = true;

                                if (dr["full"].ToString().ToLower() == "pallet")
                                {
                                    int ipallet = 0, icajasxpallet;
                                    double dpallet;
                                    icajasxpallet = int.Parse(dr["cajasxpallet"].ToString());
                                    if (icajasxpallet < 1)
                                        icajasxpallet = 1;
                                    dpallet = ipedido_sugerido / icajasxpallet;
                                    ipallet = System.Convert.ToInt32(dpallet);

                                    if (ipallet - dpallet > 0.5)
                                        ipallet += 1;


                                    dr["pedido"] = ipallet * icajasxpallet; //ipedido_sugerido;
                                }
                                else

                                    if ((dr["full"].ToString().ToLower() == "layer") || (dr["full"].ToString().ToLower() == "cajas"))
                                    {
                                        int ilayer = 0, icajasxlayer;
                                        double dlayer;
                                        icajasxlayer = int.Parse(dr["cajasxlayer"].ToString());
                                        if (icajasxlayer < 1) //Cuando trae 0, por q la division por 0 da error 130110 (c)
                                            icajasxlayer = 1;
                                        dlayer = ipedido_sugerido / icajasxlayer;
                                        ilayer = System.Convert.ToInt32(dlayer);

                                        if (ilayer - ilayer > 0.5)
                                            ilayer += 1;

                                        dr["pedido"] = ilayer * icajasxlayer; //ipedido_sugerido;
                                    }
                                    else
                                    {
                                        int iminimo_compra = int.Parse(dr["minimo_compra"].ToString());
                                        if (iminimo_compra > 0)
                                        {
                                            //if (ipedido_sugerido >= iminimo_compra)
                                            //{
                                            //    dr["pedido"] = ipedido_sugerido;
                                            //}
                                            //else
                                            //{
                                            int ilayer = 0, icajaslayer;
                                            double dlayer;
                                            if (iminimo_compra < 1) //Cuando trae 0, por q la division por 0 da error 130110 (c)
                                                iminimo_compra = 1;

                                            dlayer = ipedido_sugerido / iminimo_compra;
                                            ilayer = System.Convert.ToInt32(dlayer);

                                            if (ilayer > 0)
                                                dr["pedido"] = ilayer * iminimo_compra;

                                            else
                                            {
                                                dr["pedido"] = ipedido_sugerido;
                                            }
                                        }
                                    }


                                double dpedido = double.Parse(dr["pedido"].ToString());
                                int lpedido = System.Convert.ToInt32(dpedido);
                                if (lpedido > 0)
                                    dr["valor_sugerido"] = lpedido * double.Parse(dr["fob"].ToString());
                            }
                        }
                        bcalcular = false;
                        break;
                    }
                }//For Each
            }
            catch (Exception ex)
            {
                ClasesGenerales.General clsGen = new ClasesGenerales.General();
                clsGen.Escribir_Log(ex.Message);
                clsGen.Escribir_Log(ex.ToString());
                clsGen = null;
            }
        }


        public void generarPedidoSugeridoEmpresa(String psEmpresa, String psProducto, int nsemanaactual, bool brecalculartodos)
        {
            double ipedido_sugerido, ileadtime;

            string snombrecampo, steoricocalculo;
            string scoberturacalculo;
            bool bcalcular = false;

            try
            {
                foreach (DataRow dr in ds_preparacion.Tables["resumenEmpresa"].Rows)
                {
                    //if ((dr["empresa"].ToString().ToLower().Equals(psEmpresa.ToLower())) &&
                    //       (dr["producto"].ToString().ToLower().Equals(psProducto.ToLower())))
                    //{


                        bcalcular = true;
                        for (int i = 0; i <= nsemanaactual; i++)
                        {
                            snombrecampo = "sugerido";
                            if (i > 0)
                                snombrecampo += "+" + i.ToString("00");
                            if (int.Parse(dr[snombrecampo].ToString()) > 0)
                            {
                                bcalcular = false;
                                break;
                            }
                        }

                        snombrecampo = "sugerido";
                        if (nsemanaactual > 0)
                            snombrecampo += "+" + nsemanaactual.ToString("00");

                        dr[snombrecampo] = 0; //(c) Inicializo el sugerido con 0

                        if (brecalculartodos)
                            bcalcular = true;

                        if (bcalcular)
                        {
                            ipedido_sugerido = 0;
                            snombrecampo = "teorico";
                            steoricocalculo = "teorico";
                            scoberturacalculo = "cobertura";
                            ileadtime = System.Convert.ToInt32(dr["pv_lead_time_total"]);
                            dr["pedido"] = 0;

                            if (ileadtime > 0)
                                snombrecampo += "+" + double.Parse(dr["pv_lead_time_total"].ToString()).ToString("00");

                            if (nsemanaactual > 0)
                                ileadtime += nsemanaactual;

                            steoricocalculo += "+" + ileadtime.ToString("00");
                            scoberturacalculo += "+" + ileadtime.ToString("00");
                            if (double.Parse(dr[scoberturacalculo].ToString()) <= double.Parse(dr["pv_inv_reorden"].ToString()))
                                ipedido_sugerido = double.Parse(dr["max_cajas"].ToString());

                            if (double.Parse(dr[steoricocalculo].ToString()) > 0 && ipedido_sugerido > 0)   //le tiene que restar el inventario que tenga cuando ingrese en la semana del LT
                                ipedido_sugerido -= int.Parse(double.Parse(dr[steoricocalculo].ToString()).ToString("0000000"));


                            if (ipedido_sugerido < 0)
                                ipedido_sugerido = 0;


                            if (ipedido_sugerido > 0)
                            {
                                snombrecampo = "sugerido";
                                if (nsemanaactual > 0)
                                    snombrecampo += "+" + nsemanaactual.ToString("00");

                                dr[snombrecampo] = ipedido_sugerido;
                                dr["tiene_compra"] = true;

                                if (dr["full"].ToString().ToLower() == "pallet")
                                {
                                    int ipallet = 0, icajasxpallet;
                                    double dpallet;
                                    icajasxpallet = int.Parse(dr["cajasxpallet"].ToString());
                                    if (icajasxpallet < 1)
                                        icajasxpallet = 1;
                                    dpallet = ipedido_sugerido / icajasxpallet;
                                    ipallet = System.Convert.ToInt32(dpallet);

                                    if (ipallet - dpallet > 0.5)
                                        ipallet += 1;


                                    dr["pedido"] = ipallet * icajasxpallet; //ipedido_sugerido;
                                }
                                else

                                    if ((dr["full"].ToString().ToLower() == "layer") || (dr["full"].ToString().ToLower() == "cajas"))
                                    {
                                        int ilayer = 0, icajasxlayer;
                                        double dlayer;
                                        icajasxlayer = int.Parse(dr["cajasxlayer"].ToString());
                                        if (icajasxlayer < 1) //Cuando trae 0, por q la division por 0 da error 130110 (c)
                                            icajasxlayer = 1;
                                        dlayer = ipedido_sugerido / icajasxlayer;
                                        ilayer = System.Convert.ToInt32(dlayer);

                                        if (ilayer - ilayer > 0.5)
                                            ilayer += 1;

                                        dr["pedido"] = ilayer * icajasxlayer; //ipedido_sugerido;
                                    }
                                    else
                                    {
                                        int iminimo_compra = int.Parse(dr["minimo_compra"].ToString());
                                        if (iminimo_compra > 0)
                                        {
                                            //if (ipedido_sugerido >= iminimo_compra)
                                            //{
                                            //    dr["pedido"] = ipedido_sugerido;
                                            //}
                                            //else
                                            //{
                                            int ilayer = 0, icajaslayer;
                                            double dlayer;
                                            if (iminimo_compra < 1) //Cuando trae 0, por q la division por 0 da error 130110 (c)
                                                iminimo_compra = 1;

                                            dlayer = ipedido_sugerido / iminimo_compra;
                                            ilayer = System.Convert.ToInt32(dlayer);

                                            if (ilayer > 0)
                                                dr["pedido"] = ilayer * iminimo_compra;

                                            else
                                            {
                                                dr["pedido"] = ipedido_sugerido;
                                            }
                                        }
                                    }


                                double dpedido = double.Parse(dr["pedido"].ToString());
                                int lpedido = System.Convert.ToInt32(dpedido);
                                if (lpedido > 0)
                                    dr["valor_sugerido"] = lpedido * double.Parse(dr["fob"].ToString());
                            }
                        }
                        bcalcular = false;
                        break;
                    //}
                }//For Each
            }
            catch (Exception ex)
            {
                ClasesGenerales.General clsGen = new ClasesGenerales.General();
                clsGen.Escribir_Log(ex.Message);
                clsGen.Escribir_Log(ex.ToString());
                clsGen = null;
            }
        }


        public void Inicializar_Productos(bool generar_informacion_global, bool generar_region, bool generar_procedencia_individual, bool productos_compra)
        {

            string ls_sql = "pa_sel_um_inv_producto ";
            Transaccional.Conexion oTrans = new Transaccional.Conexion("SCM");
            DataTable dt;
            DataRow dr_aux;
            int iaux;
            string saux;

            try
            {
                oTrans.open();

                // Empresa
                //if (generar_informacion_global)
                if (scm_empresa.Length == 0)
                    ls_sql += "NULL,";
                else
                    ls_sql += "'" + scm_empresa + "',";

                // Proveedor
                if (generar_region)
                    ls_sql += "NULL,";
                else if (generar_informacion_global)
                    ls_sql += "NULL,";
                else if (scm_proveedor.Length > 0)
                    ls_sql += "'" + scm_proveedor + "',";
                else
                    ls_sql += "NULL,";

                //Procedencia
                if (generar_procedencia_individual)
                    ls_sql += "'" + scm_origen + "',";
                else
                    ls_sql += "NULL,";


                //Region
                if (generar_region)
                    ls_sql += "'" + scm_region + "',";
                else
                    ls_sql += "NULL,";

                if (scm_puerto.ToString().Length > 0)
                    ls_sql += "'" + scm_puerto + "',";
                else
                    ls_sql += "NULL,";

                ls_sql += "'" + scm_producto_limite + "'";

                if (productos_compra)
                    ls_sql += ",1";
                dt = oTrans.Obtiene(ls_sql);

                ds_preparacion.Tables["detalle_productos"].Rows.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    dr_aux = ds_preparacion.Tables["detalle_productos"].NewRow();
                    dr_aux["empresa"] = dr["empresa"].ToString();
                    dr_aux["bu"] = dr["bu"].ToString();
                    dr_aux["familia"] = dr["familia"].ToString();
                    dr_aux["proveedor"] = dr["subfamilia"].ToString();
                    dr_aux["procedencia"] = dr["procedencia"].ToString();
                    dr_aux["region"] = dr["region"].ToString();
                    dr_aux["marca"] = dr["marca"].ToString();
                    dr_aux["producto"] = dr["producto"].ToString();
                    dr_aux["glosa"] = dr["glosa"].ToString();
                    dr_aux["uxc"] = dr["uxc"].ToString();
                    dr_aux["full"] = dr["tipo_manejo"].ToString();
                    dr_aux["cajasxlayer"] = int.Parse(dr["cajas_por_layer"].ToString());
                    dr_aux["agregar"] = false;
                    dr_aux["tiene_compra"] = false;


                    //try
                    //{
                    //    iaux = int.Parse(dr["cajas_por_layer"].ToString()) * int.Parse(dr["layer_por_pallet"].ToString());
                    //}
                    //catch (Exception ex)
                    //{
                    //    iaux = 0;
                    //}
                    dr_aux["cajasxpallet"] = int.Parse(dr["cajas_por_pallet"].ToString());
                    if (minimo_standard == true)
                    {
                        dr_aux["minimo_compra"] = int.Parse(dr["minimo_compra_standard"].ToString());
                    }
                    else
                    {
                        dr_aux["minimo_compra"] = int.Parse(dr["minimo_compra"].ToString());
                    }
                    

                    //  dr_aux["diario_cajas"] = 0;
                    dr_aux["pareto"] = dr["pareto"].ToString();
                    dr_aux["pedido"] = 0;
                    dr_aux["sugerido"] = 0;
                    dr_aux["porcentaje_ajuste"] = 0;
                    for (int icount = 1; icount <= 62; icount++)
                    {
                        saux = "sugerido+" + icount.ToString("00");
                        dr_aux[saux] = 0;
                    }
                    dr_aux["sugerido_proveedor"] = 0;
                    dr_aux["valor_sugerido"] = 0;
                    //dr_aux["valor_pedido"] = 0;
                    dr_aux["min_cajas"] = 0;
                    dr_aux["max_cajas"] = 0;
                    dr_aux["internacion"] = 0;
                    dr_aux["cd_cajas"] = 0;
                    dr_aux["cdx_cajas"] = 0;
                    dr_aux["cdag_cajas"] = 0;
                    dr_aux["cdor_cajas"] = 0;
                    dr_aux["inco_cajas"] = 0;
                    dr_aux["da_cajas"] = 0;
                    dr_aux["bodegas"] = 0;
                    dr_aux["consignaciones"] = 0;
                    dr_aux["existencia"] = 0;

                    dr_aux["reservas"] = 0;

                    dr_aux["transito"] = 0;
                    dr_aux["ppto"] = 0;
                    dr_aux["saldo"] = 0;
                    dr_aux["cobertura"] = 0;
                    dr_aux["fob"] = 0;
                    dr_aux["teorico"] = 0;
                    dr_aux["calculos"] = 0;
                    dr_aux["pv_lead_time_total"] = dr["pv_lead_time_total"];
                    dr_aux["pv_ciclo_compra"] = dr["pv_ciclo_compra"];
                    dr_aux["pv_ciclo_pago"] = dr["pv_ciclo_pago"];
                    dr_aux["pv_margen_seguridad"] = dr["pv_margen_seguridad"];
                    dr_aux["pv_inv_maximo"] = dr["pv_inv_maximo"];
                    dr_aux["pv_inv_reorden"] = dr["pv_inv_reorden"];
                    dr_aux["pv_inv_seguridad"] = dr["pv_inv_seguridad"];
                    dr_aux["pv_modificar_transito"] = dr["pv_Semanas_Maximo_Cambio_OC"];

                    for (iaux = 1; iaux <= 62; iaux++)
                    {
                        saux = "transito+" + iaux.ToString("00");
                        dr_aux[saux] = 0;
                        saux = "ppto+" + iaux.ToString("00");
                        dr_aux[saux] = 0;
                        saux = "saldo+" + iaux.ToString("00");
                        dr_aux[saux] = 0;
                        saux = "cobertura+" + iaux.ToString("00");
                        dr_aux[saux] = 0;
                        saux = "teorico+" + iaux.ToString("00");
                        dr_aux[saux] = 0;
                        saux = "valor_transito+" + iaux.ToString("00");
                        dr_aux[saux] = 0;
                    }
                    try
                    {

                        dr_aux["peso"] = dr["peso_bruto_caja"];
                        dr_aux["volumen"] = dr["volumen_cubico_caja"];
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        dr_aux["costo_unitario"] = double.Parse(dr["costo"].ToString()) * double.Parse(dr["uxc"].ToString());
                    }
                    catch (Exception ex)
                    {
                    }
                    dr_aux["peso_total"] = 0;
                    dr_aux["volumen_total"] = 0;

                    try
                    {

                        dr_aux["numero_registro"] = dr["Numero_Registro_Sanitario"].ToString();
                        dr_aux["fecha_registro"] = DateTime.Parse(dr["Fecha_Registro_Sanitario"].ToString());
                    }
                    catch (Exception ex)
                    {
                        oTrans.Escribir_Log(ex.ToString());
                        oTrans.Escribir_Log(ex.Message);
                    }

                    ds_preparacion.Tables["detalle_productos"].Rows.Add(dr_aux);
                }


                ClasesGenerales.General ClsGen = new ClasesGenerales.General();
                string[] campos = new string[1];
                campos[0] = "pv_lead_time_total";

                dt = ClsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], campos);
                if (dt.Rows.Count > 0)
                {
                    double maxlt = double.Parse(dt.Compute("max(pv_lead_time_total)", "pv_lead_time_total > 0").ToString());
                    foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
                        dr["pv_lead_time_total"] = maxlt;

                }

                ClsGen = null;


            }
            catch (Exception ex)
            {
                oTrans.Escribir_Log(ex.ToString());
                oTrans.Escribir_Log(ex.Message);
            }
            finally
            {
                oTrans.close();
                oTrans = null;
            }

        }

        public void Inicializar_ProductosCosto(bool generar_informacion_global, bool generar_region, bool generar_procedencia_individual, bool productos_compra)
        {

            string ls_sql = "pa_sel_um_inv_producto ";
            Transaccional.Conexion oTrans = new Transaccional.Conexion("SCM");
            DataTable dt;
            DataRow dr_aux;
            int iaux;
            string saux;

            try
            {
                oTrans.open();

                // Empresa
                //if (generar_informacion_global)
                if (scm_empresa.Length == 0)
                    ls_sql += "NULL,";
                else
                    ls_sql += "'" + scm_empresa + "',";

                // Proveedor
                if (generar_region)
                    ls_sql += "NULL,";
                else if (generar_informacion_global)
                    ls_sql += "NULL,";
                else if (scm_proveedor.Length > 0)
                    ls_sql += "'" + scm_proveedor + "',";
                else
                    ls_sql += "NULL,";

                //Procedencia
                if (generar_procedencia_individual)
                    ls_sql += "'" + scm_origen + "',";
                else
                    ls_sql += "NULL,";


                //Region
                if (generar_region)
                    ls_sql += "'" + scm_region + "',";
                else
                    ls_sql += "NULL,";

                if (scm_puerto.ToString().Length > 0)
                    ls_sql += "'" + scm_puerto + "',";
                else
                    ls_sql += "NULL,";

                ls_sql += "'" + scm_producto_limite + "'";

                if (productos_compra)
                    ls_sql += ",1";
                dt = oTrans.Obtiene(ls_sql);

                ds_preparacion.Tables["detalle_productos"].Rows.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    dr_aux = ds_preparacion.Tables["detalle_productos"].NewRow();
                    dr_aux["empresa"] = dr["empresa"].ToString();
                    dr_aux["familia"] = dr["familia"].ToString();
                    dr_aux["proveedor"] = dr["subfamilia"].ToString();
                    dr_aux["procedencia"] = dr["procedencia"].ToString();
                    dr_aux["marca"] = dr["marca"].ToString();
                    dr_aux["producto"] = dr["producto"].ToString();
                    dr_aux["glosa"] = dr["glosa"].ToString();
                    dr_aux["uxc"] = dr["uxc"].ToString();
                    dr_aux["full"] = dr["tipo_manejo"].ToString();
                    dr_aux["cajasxlayer"] = int.Parse(dr["cajas_por_layer"].ToString());
                    dr_aux["agregar"] = false;
                    dr_aux["tiene_compra"] = false;


                    //try
                    //{
                    //    iaux = int.Parse(dr["cajas_por_layer"].ToString()) * int.Parse(dr["layer_por_pallet"].ToString());
                    //}
                    //catch (Exception ex)
                    //{
                    //    iaux = 0;
                    //}
                    dr_aux["cajasxpallet"] = int.Parse(dr["cajas_por_pallet"].ToString());
                    dr_aux["minimo_compra"] = int.Parse(dr["minimo_compra"].ToString());

                    //  dr_aux["diario_cajas"] = 0;
                    dr_aux["pareto"] = dr["pareto"].ToString();
                    dr_aux["pedido"] = 0;
                    dr_aux["sugerido"] = 0;
                    dr_aux["porcentaje_ajuste"] = 0;
                    for (int icount = 1; icount < 12; icount++)
                    {
                        saux = "sugerido+" + icount.ToString("00");
                        dr_aux[saux] = 0;
                    }
                    dr_aux["sugerido_proveedor"] = 0;
                    dr_aux["valor_sugerido"] = 0;
                    dr_aux["min_cajas"] = 0;
                    dr_aux["max_cajas"] = 0;
                    dr_aux["internacion"] = 0;
                    dr_aux["cd_cajas"] = 0;
                    dr_aux["cdx_cajas"] = 0;

                    dr_aux["da_cajas"] = 0;
                    dr_aux["bodegas"] = 0;
                    dr_aux["existencia"] = 0;

                    dr_aux["reservas"] = 0;

                    dr_aux["transito"] = 0;
                    dr_aux["ppto"] = 0;
                    dr_aux["saldo"] = 0;
                    dr_aux["cobertura"] = 0;
                    dr_aux["fob"] = 0;
                    dr_aux["teorico"] = 0;
                    dr_aux["calculos"] = 0;
                    dr_aux["pv_lead_time_total"] = dr["pv_lead_time_total"];
                    dr_aux["pv_ciclo_compra"] = dr["pv_ciclo_compra"];
                    dr_aux["pv_margen_seguridad"] = dr["pv_margen_seguridad"];
                    dr_aux["pv_inv_maximo"] = dr["pv_inv_maximo"];
                    dr_aux["pv_inv_reorden"] = dr["pv_inv_reorden"];
                    dr_aux["pv_inv_seguridad"] = dr["pv_inv_seguridad"];
                    dr_aux["pv_modificar_transito"] = dr["pv_Semanas_Maximo_Cambio_OC"];

                    for (iaux = 1; iaux <= 52; iaux++)
                    {
                        saux = "transito+" + iaux.ToString("00");
                        dr_aux[saux] = 0;
                        saux = "ppto+" + iaux.ToString("00");
                        dr_aux[saux] = 0;
                        saux = "saldo+" + iaux.ToString("00");
                        dr_aux[saux] = 0;
                        saux = "cobertura+" + iaux.ToString("00");
                        dr_aux[saux] = 0;
                        saux = "teorico+" + iaux.ToString("00");
                        dr_aux[saux] = 0;
                    }
                    try
                    {

                        dr_aux["peso"] = dr["peso_bruto_caja"];
                        dr_aux["volumen"] = dr["volumen_cubico_caja"];
                    }
                    catch (Exception ex)
                    {
                    }
                    dr_aux["peso_total"] = 0;
                    dr_aux["volumen_total"] = 0;
                    dr_aux["costo_unitario"] = dr["costo"];


                    ds_preparacion.Tables["detalle_productos"].Rows.Add(dr_aux);
                }
                ClasesGenerales.General ClsGen = new ClasesGenerales.General();
                string[] campos = new string[1];
                campos[0] = "pv_lead_time_total";

                dt = ClsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], campos);
                if (dt.Rows.Count > 0)
                {
                    double maxlt = double.Parse(dt.Compute("max(pv_lead_time_total)", "pv_lead_time_total > 0").ToString());
                    foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
                        dr["pv_lead_time_total"] = maxlt;

                }

                ClsGen = null;


            }
            catch (Exception ex)
            {
            }
            finally
            {
                oTrans.close();
                oTrans = null;
            }

        }


        public void Revisar_productoDerivados(string nombretablaProducto)
        {
            Transaccional.Conexion oTrans = new Transaccional.Conexion("umbralsa");
            ClasesGenerales.General clsGen = new ClasesGenerales.General();
            DataTable dt;
            string lsSql, sfiltro;
            string[] campos = new string[2];
            campos[0] = "empresa";
            campos[1] = "producto_padre";




            try
            {
                oTrans.open();
                lsSql = "pa_sel_um_producto_derivado ";

                if (scm_empresa.Length == 0)
                    lsSql += "NULL";
                else
                    lsSql += "'" + scm_empresa + "'";

                dt = oTrans.Obtiene(lsSql);
                dt.TableName = "derivados";
                if (ds_preparacion.Tables.Contains("derivados"))
                    ds_preparacion.Tables.Remove("derivados");

                ds_preparacion.Tables.Add(dt.Copy());

                dt = clsGen.ValoresDistinto(dt, campos);

                foreach (DataRow dr in dt.Rows)
                {
                    sfiltro = "empresa = '" + dr["empresa"].ToString() + "' and producto = '" + dr["producto_padre"].ToString() + "'";
                    ds_preparacion.Tables[nombretablaProducto].DefaultView.RowFilter = sfiltro;
                    foreach (DataRowView drv in ds_preparacion.Tables[nombretablaProducto].DefaultView)
                    {
                        if (!drv["glosa"].ToString().StartsWith("**"))
                        {
                            lsSql = "**" + drv["glosa"].ToString();
                            drv["glosa"] = lsSql;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                oTrans.close();
                oTrans = null;
            }
        }

        public void Generar_SaldosyCoberturas(Boolean bValorizado)
        {
            string smes_actual, smes_pasado, stransito, sppto, steorico, scobertura;

            double dsaldo, dtransito, dsaldomespasado;
            ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter = "";

            foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
            {
                //dr["saldo"] = dr["cd_cajas"] + dr["cdx_cajas"] + dr["da_cajas"] + dr["transito"] - dr["ppto"];

                if (bValorizado)
                {
                    dsaldo = Double.Parse(dr["cd_cajas"].ToString()) + Double.Parse(dr["cdx_cajas"].ToString()) +
                        Double.Parse(dr["da_cajas"].ToString()) + Double.Parse(dr["bodegas"].ToString()) + Double.Parse(dr["internacion"].ToString());
                    try
                    {
                        dsaldo = dsaldo * (Double.Parse(dr["costo_unitario"].ToString()));
                    }
                    catch (Exception ex)
                    {
                    }

                    dsaldo = dsaldo + Double.Parse(dr["transito"].ToString()) - Double.Parse(dr["ppto"].ToString());

                    //dsaldo = int.Parse(dr["cd_cajas"].ToString()) + int.Parse(dr["cdx_cajas"].ToString()) +
                    //    int.Parse(dr["da_cajas"].ToString()) + double.Parse(dr["transito"].ToString()) -
                    //    Double.Parse(dr["ppto"].ToString()) + Double.Parse(dr["internacion"].ToString());
                }
                else
                {
                    dsaldo = Double.Parse(dr["cd_cajas"].ToString()) + Double.Parse(dr["cdx_cajas"].ToString()) +
                            Double.Parse(dr["cdag_cajas"].ToString()) + Double.Parse(dr["cdor_cajas"].ToString()) +
                            Double.Parse(dr["da_cajas"].ToString()) + Double.Parse(dr["transito"].ToString()) -
                                       Double.Parse(dr["ppto"].ToString()) + Double.Parse(dr["internacion"].ToString());
                }
                if (dsaldo < 0)
                    dsaldo = 0;

                dr["saldo"] = dsaldo;
                dr["teorico"] = dr["saldo"];



                //Saldos y teoricos 1-53
                for (int i = 1; i < 53; i++)
                {
                    smes_actual = "saldo+" + i.ToString("00");
                    smes_pasado = "saldo";
                    stransito = "transito+" + i.ToString("00");
                    sppto = "ppto+" + i.ToString("00");

                    if (i > 1)
                        smes_pasado += "+" + (i - 1).ToString("00");
                    if (dr["producto"].ToString() == "0200071222" && i == 1)
                    {
                        dr["producto"] = "0200071222";
                    }

                    dsaldo = double.Parse(dr[smes_pasado].ToString()) + double.Parse(dr[stransito].ToString()) -
                             double.Parse(double.Parse(dr[sppto].ToString()).ToString());


                    //dr[smes_actual] = dsaldo;
                    if (dsaldo < 0)
                        dsaldo = 0;

                    dr[smes_actual] = dsaldo;

                    dr["teorico+" + i.ToString("00")] = dr[smes_actual];
                    dtransito = double.Parse(dr[stransito].ToString());
                    if (dtransito > 0)
                    {
                        for (int icount = 0; icount < i; icount++)
                        {
                            steorico = "teorico";
                            if (icount > 0)
                                steorico += "+" + icount.ToString("00");

                            dr[steorico] = double.Parse(dr[steorico].ToString()) + dtransito;
                        }
                    }
                }




                //Cobertura mes actual
                dsaldo = double.Parse(dr["saldo"].ToString());
                dr["cobertura"] = 0;
                if (dsaldo > 0)
                    //{
                    for (int iaux = 1; iaux < 53; iaux++)
                    {
                        if (dsaldo > 0)
                        {
                            if (dsaldo - double.Parse(dr["ppto+" + iaux.ToString("00")].ToString()) >= 0)
                            {
                                dr["cobertura"] = double.Parse(dr["cobertura"].ToString()) + 1;
                                dsaldo -= double.Parse(dr["ppto+" + iaux.ToString("00")].ToString());
                            }
                            else
                            {
                                dr["cobertura"] = double.Parse(dr["cobertura"].ToString()) + (dsaldo / double.Parse(dr["ppto+" + iaux.ToString("00")].ToString()));
                                dsaldo = 0;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                //}
                //else
                //{
                //    dr["cobertura"] = 0;
                //}



                //Coberturas 1-52
                for (int iaux = 1; iaux < 53; iaux++)
                {
                    scobertura = "cobertura+" + iaux.ToString("00");
                    smes_actual = "saldo+" + iaux.ToString("00");


                    if ((dr["producto"].ToString() == "0010208002") && (iaux == 12))
                    {
                        dr["producto"] = "0010208002";
                    }

                    dsaldo = 0;
                    //icobertura = 0;
                    dr[scobertura] = 0;
                    dsaldo = double.Parse(dr[smes_actual].ToString());
                    smes_pasado = "saldo";
                    if (iaux > 1)
                        smes_pasado += "+" + (iaux - 1).ToString("00");

                    dsaldomespasado = double.Parse(dr[smes_pasado].ToString());
                    //if (dsaldo > 0)
                    //if (dsaldomespasado - double.Parse(dr["ppto+" + iaux.ToString("00")].ToString()) >= 0)
                    //{
                    //    //tengo que establecer cuando ya se haya hecho resta del ppto y q tenga cobertura
                    //    //saldo_mespasado - ppto
                    //    dr[scobertura] = 1;
                    //    // dsaldo -= double.Parse(dr["ppto+" + iaux.ToString("00")].ToString());
                    //}
                    if (dsaldo > 0)
                        for (int iaux2 = iaux + 1; iaux2 < 53; iaux2++)
                        {
                            if (dsaldo <= 0)
                            {
                                break;
                            }
                            else
                            {
                                if (dsaldo - double.Parse(dr["ppto+" + iaux2.ToString("00")].ToString()) >= 0)
                                {
                                    dr[scobertura] = int.Parse(dr[scobertura].ToString()) + 1;
                                    dsaldo -= double.Parse(dr["ppto+" + iaux2.ToString("00")].ToString());
                                }
                                else
                                {
                                    dr[scobertura] = double.Parse(dr[scobertura].ToString()) + (dsaldo / (double.Parse(dr["ppto+" + iaux2.ToString("00")].ToString())));
                                    dsaldo = 0;
                                    break;
                                }
                            }
                        }
                }
            }

        }

        public void Generar_SaldosyCoberturasResumenTotal(string nombreTabla)
        {

            string smes_actual, smes_pasado, stransito, sppto, steorico, scobertura;

            double dsaldo, dtransito, dsaldomespasado;
            ds_preparacion.Tables[nombreTabla].DefaultView.RowFilter = "";

            foreach (DataRow dr in ds_preparacion.Tables[nombreTabla].Rows)
            {
                //dr["saldo"] = dr["cd_cajas"] + dr["cdx_cajas"] + dr["da_cajas"] + dr["transito"] - dr["ppto"];
                try
                {

                    dsaldo = Double.Parse(dr["cd_cajas"].ToString()) + Double.Parse(dr["cdx_cajas"].ToString()) +
                             Double.Parse(dr["cdag_cajas"].ToString()) + Double.Parse(dr["cdor_cajas"].ToString()) +
                            Double.Parse(dr["da_cajas"].ToString()) + Double.Parse(dr["transito"].ToString()) +
                            Double.Parse(dr["bodegas"].ToString()) -
                            Double.Parse(dr["ppto"].ToString()) + Double.Parse(dr["internacion"].ToString());
                }
                finally
                { }
                if (dsaldo < 0)
                    dsaldo = 0;

                dr["saldo"] = dsaldo;
                dr["teorico"] = dr["saldo"];



                //Saldos y teoricos 1-53
                for (int i = 1; i < 53; i++)
                {
                    smes_actual = "saldo+" + i.ToString("00");
                    smes_pasado = "saldo";
                    stransito = "transito+" + i.ToString("00");
                    sppto = "ppto+" + i.ToString("00");

                    if (i > 1)
                        smes_pasado += "+" + (i - 1).ToString("00");
                    if (dr["producto"].ToString() == "0011012032" && i == 12)
                        dr["producto"] = "0011012032";


                    dsaldo = double.Parse(dr[smes_pasado].ToString()) + double.Parse(dr[stransito].ToString()) -
                             double.Parse(double.Parse(dr[sppto].ToString()).ToString());


                    //dr[smes_actual] = dsaldo;
                    if (dsaldo < 0)
                        dsaldo = 0;

                    dr[smes_actual] = dsaldo;

                    dr["teorico+" + i.ToString("00")] = dr[smes_actual];
                    dtransito = double.Parse(dr[stransito].ToString());
                    if (dtransito > 0)
                    {
                        for (int icount = 0; icount < i; icount++)
                        {
                            steorico = "teorico";
                            if (icount > 0)
                                steorico += "+" + icount.ToString("00");

                            dr[steorico] = double.Parse(dr[steorico].ToString()) + dtransito;
                        }
                    }
                }




                //Cobertura mes actual
                dsaldo = double.Parse(dr["saldo"].ToString());
                dr["cobertura"] = 0;
                if (dsaldo > 0)
                    //{
                    for (int iaux = 1; iaux < 53; iaux++)
                    {
                        if (dsaldo > 0)
                        {
                            if (dsaldo - double.Parse(dr["ppto+" + iaux.ToString("00")].ToString()) >= 0)
                            {
                                dr["cobertura"] = double.Parse(dr["cobertura"].ToString()) + 1;
                                dsaldo -= double.Parse(dr["ppto+" + iaux.ToString("00")].ToString());
                            }
                            else
                            {
                                dr["cobertura"] = double.Parse(dr["cobertura"].ToString()) + (dsaldo / double.Parse(dr["ppto+" + iaux.ToString("00")].ToString()));
                                dsaldo = 0;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                //}
                //else
                //{
                //    dr["cobertura"] = 0;
                //}



                //Coberturas 1-52
                for (int iaux = 1; iaux < 53; iaux++)
                {
                    scobertura = "cobertura+" + iaux.ToString("00");
                    smes_actual = "saldo+" + iaux.ToString("00");


                    if ((dr["producto"].ToString() == "0010208002") && (iaux == 12))
                        dr["producto"] = "0010208002";


                    dsaldo = 0;
                    //icobertura = 0;
                    dr[scobertura] = 0;
                    dsaldo = double.Parse(dr[smes_actual].ToString());
                    smes_pasado = "saldo";
                    if (iaux > 1)
                        smes_pasado += "+" + (iaux - 1).ToString("00");

                    dsaldomespasado = double.Parse(dr[smes_pasado].ToString());
                    //if (dsaldo > 0)
                    //if (dsaldomespasado - double.Parse(dr["ppto+" + iaux.ToString("00")].ToString()) >= 0)
                    //{
                    //    //tengo que establecer cuando ya se haya hecho resta del ppto y q tenga cobertura
                    //    //saldo_mespasado - ppto
                    //    dr[scobertura] = 1;
                    //    // dsaldo -= double.Parse(dr["ppto+" + iaux.ToString("00")].ToString());
                    //}
                    if (dsaldo > 0)
                        for (int iaux2 = iaux + 1; iaux2 < 53; iaux2++)
                        {
                            if (dsaldo <= 0)
                            {
                                break;
                            }
                            else
                            {
                                if (dsaldo - double.Parse(dr["ppto+" + iaux2.ToString("00")].ToString()) >= 0)
                                {
                                    dr[scobertura] = int.Parse(dr[scobertura].ToString()) + 1;
                                    dsaldo -= double.Parse(dr["ppto+" + iaux2.ToString("00")].ToString());
                                }
                                else
                                {
                                    dr[scobertura] = double.Parse(dr[scobertura].ToString()) + (dsaldo / (double.Parse(dr["ppto+" + iaux2.ToString("00")].ToString())));
                                    dsaldo = 0;
                                    break;
                                }
                            }
                        }
                }
            }

        }

        public void Generar_SaldosyCoberturasProducto(String pproducto)
        {
            string smes_actual, smes_pasado, stransito, sppto, steorico, scobertura;
            double dsaldo, dtransito, dsaldomespasado;

            foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
            {
                try
                {
                
                if (dr["producto"].ToString().Equals(pproducto))
                {

                    dsaldo = Double.Parse(dr["cd_cajas"].ToString()) + Double.Parse(dr["cdx_cajas"].ToString()) +
                            Double.Parse(dr["cdag_cajas"].ToString()) + Double.Parse(dr["cdor_cajas"].ToString()) +
                            Double.Parse(dr["da_cajas"].ToString()) + double.Parse(dr["transito"].ToString()) -
                            Double.Parse(dr["ppto"].ToString()) + Double.Parse(dr["internacion"].ToString());

                    if (dsaldo < 0)
                        dsaldo = 0;

                    dr["saldo"] = dsaldo;
                    dr["teorico"] = dr["saldo"];

                    //Saldos y teoricos 1-53
                    for (int i = 1; i < 53; i++)
                    {
                        smes_actual = "saldo+" + i.ToString("00");
                        smes_pasado = "saldo";
                        stransito = "transito+" + i.ToString("00");
                        sppto = "ppto+" + i.ToString("00");

                        if (i > 1)
                            smes_pasado += "+" + (i - 1).ToString("00");

                        dsaldo = double.Parse(dr[smes_pasado].ToString()) + double.Parse(dr[stransito].ToString()) -
                                 double.Parse(double.Parse(dr[sppto].ToString()).ToString());

                        if (dsaldo < 0)
                            dsaldo = 0;

                        dr[smes_actual] = dsaldo;

                        dr["teorico+" + i.ToString("00")] = dr[smes_actual];
                        dtransito = double.Parse(dr[stransito].ToString());
                        if (dtransito > 0)
                        {
                            for (int icount = 0; icount < i; icount++)
                            {
                                steorico = "teorico";
                                if (icount > 0)
                                    steorico += "+" + icount.ToString("00");

                                dr[steorico] = double.Parse(dr[steorico].ToString()) + dtransito;
                            }
                        }
                    } //Saldos y Teoricos 1-53

                    //Cobertura mes actual
                    dsaldo = double.Parse(dr["saldo"].ToString());
                    dr["cobertura"] = 0;
                    if (dsaldo > 0)
                        for (int iaux = 1; iaux < 53; iaux++)
                        {
                            if (dsaldo > 0)
                            {
                                if (dsaldo - double.Parse(dr["ppto+" + iaux.ToString("00")].ToString()) >= 0)
                                {
                                    dr["cobertura"] = double.Parse(dr["cobertura"].ToString()) + 1;
                                    dsaldo -= double.Parse(dr["ppto+" + iaux.ToString("00")].ToString());
                                }
                                else
                                {
                                    dr["cobertura"] = double.Parse(dr["cobertura"].ToString()) + (dsaldo / double.Parse(dr["ppto+" + iaux.ToString("00")].ToString()));
                                    dsaldo = 0;
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }//Cobertura mes actual


                    //Coberturas 1-52
                    for (int iaux = 1; iaux < 53; iaux++)
                    {
                        scobertura = "cobertura+" + iaux.ToString("00");
                        smes_actual = "saldo+" + iaux.ToString("00");

                        dsaldo = 0;
                        dr[scobertura] = 0;
                        dsaldo = double.Parse(dr[smes_actual].ToString());
                        smes_pasado = "saldo";
                        if (iaux > 1)
                            smes_pasado += "+" + (iaux - 1).ToString("00");

                        dsaldomespasado = double.Parse(dr[smes_pasado].ToString());
                        if (dsaldo > 0)
                            if (dsaldo > 0)
                                for (int iaux2 = iaux + 1; iaux2 < 63; iaux2++)
                                {
                                    if (dsaldo <= 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        if (dsaldo - double.Parse(dr["ppto+" + iaux2.ToString("00")].ToString()) >= 0)
                                        {
                                            dr[scobertura] = int.Parse(dr[scobertura].ToString()) + 1;
                                            dsaldo -= double.Parse(dr["ppto+" + iaux2.ToString("00")].ToString());
                                        }
                                        else
                                        {
                                            dr[scobertura] = double.Parse(dr[scobertura].ToString()) + (dsaldo / (double.Parse(dr["ppto+" + iaux2.ToString("00")].ToString())));
                                            dsaldo = 0;
                                            break;
                                        }
                                    }
                                }
                    }//Coberturas 1-52
                    break;
                }
            }


                

                                        
        
                            catch (Exception ex)
                            {
                            }
        }

        }

        public void CopiarProducto()
        {

        }

        public void generarResumenEmpresa()
        {
            String sfiltro, saux;
            Int32 iaux;
            DataRow drnew;

            //(c) 20160914 Se quito la limpieza de  la tabla por que genera en otra opcion

            //foreach (DataRow dr_aux in ds_preparacion.Tables["resumen"].Rows)
            //{
            //    dr_aux["pedido"] = 0;
            //    dr_aux["sugerido"] = 0;
            //    for (int icount = 1; icount < 12; icount++)
            //    {
            //        saux = "sugerido+" + icount.ToString("00");
            //        dr_aux[saux] = 0;
            //    }
            //    dr_aux["sugerido_proveedor"] = 0;
            //    dr_aux["valor_sugerido"] = 0;
            //    dr_aux["min_cajas"] = 0;
            //    dr_aux["max_cajas"] = 0;
            //    dr_aux["cd_cajas"] = 0;
            //    dr_aux["cdx_cajas"] = 0;
            //    dr_aux["da_cajas"] = 0;
            //    dr_aux["internacion"] = 0;
            //    dr_aux["existencia"] = 0;
            //    dr_aux["transito"] = 0;
            //    dr_aux["ppto"] = 0;
            //    dr_aux["saldo"] = 0;
            //    dr_aux["cobertura"] = 0;
            //    dr_aux["fob"] = 0;
            //    dr_aux["teorico"] = 0;
            //    dr_aux["calculos"] = 0;
            //    dr_aux["pv_lead_time_total"] = 0;
            //    dr_aux["pv_ciclo_compra"] = 0;
            //    dr_aux["pv_margen_seguridad"] = 0;
            //    dr_aux["pv_inv_maximo"] = 0;
            //    dr_aux["pv_inv_seguridad"] = 0;

            //    for (iaux = 1; iaux <= 62; iaux++)
            //    {
            //        saux = "transito+" + iaux.ToString("00");
            //        dr_aux[saux] = 0;
            //        saux = "ppto+" + iaux.ToString("00");
            //        dr_aux[saux] = 0;
            //        saux = "saldo+" + iaux.ToString("00");
            //        dr_aux[saux] = 0;
            //        saux = "cobertura+" + iaux.ToString("00");
            //        dr_aux[saux] = 0;
            //        saux = "teorico+" + iaux.ToString("00");
            //        dr_aux[saux] = 0;
            //    }
            //    dr_aux["peso"] = 0;
            //    dr_aux["volumen"] = 0;

            //}

            if (ds_preparacion.Tables.Contains("ResumenEmpresa"))
                ds_preparacion.Tables.Remove("ResumenEmpresa");

            if (ds_preparacion.Tables.Contains("ResumenEmpresaPareto"))
                ds_preparacion.Tables.Remove("ResumenEmpresaPareto");

            if (ds_preparacion.Tables.Contains("ResumenPareto"))
                ds_preparacion.Tables.Remove("ResumenPareto");

            DataTable dt = ds_preparacion.Tables["Resumen"].Copy();
            dt.Rows.Clear();
            dt.TableName = "ResumenEmpresa";
            ds_preparacion.Tables.Add(dt.Copy());
            dt.TableName = "ResumenEmpresaPareto";
            ds_preparacion.Tables.Add(dt.Copy());
            dt.TableName = "ResumenPareto";
            ds_preparacion.Tables.Add(dt.Copy());




            foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
            {

                sfiltro = "empresa = '" + dr["empresa"].ToString() + "'";
                ds_preparacion.Tables["ResumenEmpresa"].DefaultView.RowFilter = sfiltro;

                try
                {
                    if (ds_preparacion.Tables["ResumenEmpresa"].DefaultView.Count == 0)
                    {
                        drnew = ds_preparacion.Tables["ResumenEmpresa"].NewRow();
                        foreach (DataColumn dc in ds_preparacion.Tables["ResumenEmpresa"].Columns)
                        {
                            try
                            {
                                drnew[dc.ColumnName] = dr[dc.ColumnName];
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        drnew["pedido"] = 0;
                        drnew["valor_sugerido"] = 0;
                        drnew["peso"] = 0;
                        drnew["volumen"] = 0;
                        ds_preparacion.Tables["ResumenEmpresa"].Rows.Add(drnew);
                    }

                    ds_preparacion.Tables["ResumenEmpresa"].DefaultView.RowFilter = sfiltro;
                    if (ds_preparacion.Tables["ResumenEmpresa"].DefaultView.Count > 0)
                    {
                        Boolean bagregar = Boolean.Parse(dr["agregar"].ToString());
                        if (bagregar)
                        {
                            ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["pedido"] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["pedido"].ToString()) + double.Parse(dr["pedido"].ToString());
                            ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["valor_sugerido"] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["valor_sugerido"].ToString()) + double.Parse(dr["valor_sugerido"].ToString());
                            ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["peso"] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["peso"].ToString()) + (double.Parse(dr["peso"].ToString()) * double.Parse(dr["pedido"].ToString()));
                            ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["volumen"] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["volumen"].ToString()) + (double.Parse(dr["volumen"].ToString()) * double.Parse(dr["pedido"].ToString()));
                        }
                        ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["sugerido"] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["sugerido"].ToString()) + double.Parse(dr["sugerido"].ToString());
                        for (int icount = 1; icount < 12; icount++)
                        {
                            saux = "sugerido+" + icount.ToString("00");
                            ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                        }



                        ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["cd_cajas"] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["cd_cajas"].ToString()) +
            (double.Parse(dr["cd_cajas"].ToString()));
                        ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["cdx_cajas"] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["cdx_cajas"].ToString()) +
                                        (double.Parse(dr["cdx_cajas"].ToString()));

                        ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["da_cajas"] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["da_cajas"].ToString()) +
                                        (double.Parse(dr["da_cajas"].ToString()));

                        ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["bodegas"] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["bodegas"].ToString()) +
                                        (double.Parse(dr["bodegas"].ToString()));

                        ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["internacion"] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["internacion"].ToString()) + double.Parse(dr["internacion"].ToString());



                        //ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["cd_cajas"] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["cd_cajas"].ToString()) +
                        //            (double.Parse(dr["cd_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));
                        //ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["cdx_cajas"] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["cdx_cajas"].ToString()) +
                        //                (double.Parse(dr["cdx_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));

                        //ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["da_cajas"] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["da_cajas"].ToString()) +
                        //                (double.Parse(dr["da_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));

                        //ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["bodegas"] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["bodegas"].ToString()) +
                        //                (double.Parse(dr["bodegas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));

                        //ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["internacion"] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0]["internacion"].ToString()) + double.Parse(dr["internacion"].ToString());


                        saux = "transito";
                        ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                        //dr_aux[saux] = 0;
                        saux = "ppto";
                        ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());


                        for (iaux = 1; iaux <= 62; iaux++)
                        {
                            saux = "transito+" + iaux.ToString("00");
                            ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                            saux = "ppto+" + iaux.ToString("00");
                            ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["ResumenEmpresa"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                        }

                    }
                }
                catch (Exception ex)
                {
                }

                // Empresa Pareto
                sfiltro = "empresa = '" + dr["empresa"].ToString() + "' and pareto = '" + dr["pareto"].ToString() + "'";
                ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView.RowFilter = sfiltro;

                try
                {
                    if (ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView.Count == 0)
                    {
                        drnew = ds_preparacion.Tables["ResumenEmpresaPareto"].NewRow();
                        foreach (DataColumn dc in ds_preparacion.Tables["ResumenEmpresaPareto"].Columns)
                        {
                            try
                            {
                                drnew[dc.ColumnName] = dr[dc.ColumnName];
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        drnew["pedido"] = 0;
                        drnew["valor_sugerido"] = 0;
                        drnew["peso"] = 0;
                        drnew["volumen"] = 0;
                        ds_preparacion.Tables["ResumenEmpresaPareto"].Rows.Add(drnew);
                    }

                    ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView.RowFilter = sfiltro;
                    if (ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView.Count > 0)
                    {
                        Boolean bagregar = Boolean.Parse(dr["agregar"].ToString());
                        if (bagregar)
                        {
                            ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["pedido"] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["pedido"].ToString()) + double.Parse(dr["pedido"].ToString());
                            ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["valor_sugerido"] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["valor_sugerido"].ToString()) + double.Parse(dr["valor_sugerido"].ToString());
                            ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["peso"] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["peso"].ToString()) + (double.Parse(dr["peso"].ToString()) * double.Parse(dr["pedido"].ToString()));
                            ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["volumen"] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["volumen"].ToString()) + (double.Parse(dr["volumen"].ToString()) * double.Parse(dr["pedido"].ToString()));
                        }
                        ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["sugerido"] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["sugerido"].ToString()) + double.Parse(dr["sugerido"].ToString());
                        for (int icount = 1; icount < 12; icount++)
                        {
                            saux = "sugerido+" + icount.ToString("00");
                            ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                        }

                        ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["cd_cajas"] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["cd_cajas"].ToString()) +
                                (double.Parse(dr["cd_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));
                        ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["cdx_cajas"] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["cdx_cajas"].ToString()) +
                                        (double.Parse(dr["cdx_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));
                        ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["cdag_cajas"] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["cdag_cajas"].ToString()) +
                                        (double.Parse(dr["cdag_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));
                        ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["cdor_cajas"] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["cdor_cajas"].ToString()) +
                                        (double.Parse(dr["cdor_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));

                        ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["da_cajas"] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["da_cajas"].ToString()) +
                                        (double.Parse(dr["da_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));

                        ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["bodegas"] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["bodegas"].ToString()) +
                                        (double.Parse(dr["bodegas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));

                        ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["internacion"] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0]["internacion"].ToString()) +
                                        double.Parse(dr["internacion"].ToString());


                        saux = "transito";
                        ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                        //dr_aux[saux] = 0;
                        saux = "ppto";
                        ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());


                        for (iaux = 1; iaux <= 62; iaux++)
                        {
                            saux = "transito+" + iaux.ToString("00");
                            ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                            saux = "ppto+" + iaux.ToString("00");
                            ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["ResumenEmpresaPareto"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                        }



                    }
                }
                catch (Exception ex)
                {
                }


                // solo pareto
                sfiltro = "pareto = '" + dr["pareto"].ToString() + "'";
                ds_preparacion.Tables["ResumenPareto"].DefaultView.RowFilter = sfiltro;

                try
                {
                    if (ds_preparacion.Tables["ResumenPareto"].DefaultView.Count == 0)
                    {
                        drnew = ds_preparacion.Tables["ResumenPareto"].NewRow();
                        foreach (DataColumn dc in ds_preparacion.Tables["ResumenPareto"].Columns)
                        {
                            try
                            {
                                drnew[dc.ColumnName] = dr[dc.ColumnName];
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        drnew["pedido"] = 0;
                        drnew["valor_sugerido"] = 0;
                        drnew["peso"] = 0;
                        drnew["volumen"] = 0;
                        ds_preparacion.Tables["ResumenPareto"].Rows.Add(drnew);
                    }

                    ds_preparacion.Tables["ResumenPareto"].DefaultView.RowFilter = sfiltro;
                    if (ds_preparacion.Tables["ResumenPareto"].DefaultView.Count > 0)
                    {


                        Boolean bagregar = Boolean.Parse(dr["agregar"].ToString());
                        if (bagregar)
                        {
                            ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["pedido"] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["pedido"].ToString()) + double.Parse(dr["pedido"].ToString());
                            ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["valor_sugerido"] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["valor_sugerido"].ToString()) + double.Parse(dr["valor_sugerido"].ToString());
                            ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["peso"] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["peso"].ToString()) + (double.Parse(dr["peso"].ToString()) * double.Parse(dr["pedido"].ToString()));
                            ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["volumen"] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["volumen"].ToString()) + (double.Parse(dr["volumen"].ToString()) * double.Parse(dr["pedido"].ToString()));
                        }
                        ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["sugerido"] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["sugerido"].ToString()) + double.Parse(dr["sugerido"].ToString());
                        for (int icount = 1; icount < 12; icount++)
                        {
                            saux = "sugerido+" + icount.ToString("00");
                            ds_preparacion.Tables["ResumenPareto"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                        }

                        ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["cd_cajas"] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["cd_cajas"].ToString()) +
                                        (double.Parse(dr["cd_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));
                        ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["cdx_cajas"] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["cdx_cajas"].ToString()) +
                                        (double.Parse(dr["cdx_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));
                        ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["cdag_cajas"] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["cdag_cajas"].ToString()) +
                                        (double.Parse(dr["cdag_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));
                        ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["cdor_cajas"] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["cdor_cajas"].ToString()) +
                                        (double.Parse(dr["cdor_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));


                        ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["da_cajas"] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["da_cajas"].ToString()) +
                                        (double.Parse(dr["da_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));

                        ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["bodegas"] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["bodegas"].ToString()) +
                                        (double.Parse(dr["bodegas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));

                        ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["internacion"] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0]["internacion"].ToString()) + double.Parse(dr["internacion"].ToString());


                        saux = "transito";
                        ds_preparacion.Tables["ResumenPareto"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                        //dr_aux[saux] = 0;
                        saux = "ppto";
                        ds_preparacion.Tables["ResumenPareto"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());


                        for (iaux = 1; iaux <= 62; iaux++)
                        {
                            saux = "transito+" + iaux.ToString("00");
                            ds_preparacion.Tables["ResumenPareto"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                            saux = "ppto+" + iaux.ToString("00");
                            ds_preparacion.Tables["ResumenPareto"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["ResumenPareto"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                        }

                    }
                }
                catch (Exception ex)
                {
                }



            }

        }


        public void generarResumen()
        {
            String sfiltro, saux;
            Int32 iaux;
            DataRow drnew;

            foreach (DataRow dr_aux in ds_preparacion.Tables["resumen"].Rows)
            {
                dr_aux["pedido"] = 0;
                dr_aux["sugerido"] = 0;
                for (int icount = 1; icount <= 62; icount++)
                {
                    saux = "sugerido+" + icount.ToString("00");
                    dr_aux[saux] = 0;
                }
                dr_aux["sugerido_proveedor"] = 0;
                dr_aux["valor_sugerido"] = 0;
                dr_aux["min_cajas"] = 0;
                dr_aux["max_cajas"] = 0;
                dr_aux["cd_cajas"] = 0;
                dr_aux["cdx_cajas"] = 0;
                dr_aux["cdag_cajas"] = 0;
                dr_aux["cdor_cajas"] = 0;
                dr_aux["da_cajas"] = 0;
                dr_aux["internacion"] = 0;
                dr_aux["existencia"] = 0;

                dr_aux["reservas"] = 0;

                dr_aux["transito"] = 0;
                dr_aux["ppto"] = 0;
                dr_aux["saldo"] = 0;
                dr_aux["cobertura"] = 0;
                dr_aux["fob"] = 0;
                dr_aux["teorico"] = 0;
                dr_aux["calculos"] = 0;
                dr_aux["pv_lead_time_total"] = 0;
                dr_aux["pv_ciclo_compra"] = 0;
                dr_aux["pv_margen_seguridad"] = 0;
                dr_aux["pv_inv_maximo"] = 0;
                dr_aux["pv_inv_seguridad"] = 0;

                for (iaux = 1; iaux <= 62; iaux++)
                {
                    saux = "transito+" + iaux.ToString("00");
                    dr_aux[saux] = 0;
                    saux = "ppto+" + iaux.ToString("00");
                    dr_aux[saux] = 0;
                    saux = "saldo+" + iaux.ToString("00");
                    dr_aux[saux] = 0;
                    saux = "cobertura+" + iaux.ToString("00");
                    dr_aux[saux] = 0;
                    saux = "teorico+" + iaux.ToString("00");
                    dr_aux[saux] = 0;
                    saux = "valor_transito+" + iaux.ToString("00");
                    dr_aux[saux] = 0;
                }
                dr_aux["peso"] = 0;
                dr_aux["volumen"] = 0;

            }


            foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
            {
                if (dr["procedencia"].ToString().ToLower().Equals("irlanda"))
                    dr["procedencia"] = "IRLANDA";

                sfiltro = "procedencia = '" + dr["procedencia"].ToString() + "' and proveedor = '" + dr["proveedor"].ToString() + "'";
                ds_preparacion.Tables["Resumen"].DefaultView.RowFilter = sfiltro;

                try
                {
                    if (ds_preparacion.Tables["Resumen"].DefaultView.Count == 0)
                    {
                        drnew = ds_preparacion.Tables["Resumen"].NewRow();
                        foreach (DataColumn dc in ds_preparacion.Tables["Resumen"].Columns)
                        {
                            try
                            {
                                drnew[dc.ColumnName] = dr[dc.ColumnName];
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        drnew["pedido"] = 0;
                        drnew["valor_sugerido"] = 0;
                        drnew["peso"] = 0;
                        drnew["volumen"] = 0;
                        drnew["cd_cajas"] = 0;
                        drnew["cdx_cajas"] = 0;
                        drnew["cdag_cajas"] = 0;
                        drnew["bodegas"] = 0;
                        drnew["internacion"] = 0;



                        ds_preparacion.Tables["Resumen"].Rows.Add(drnew);
                    }

                    ds_preparacion.Tables["Resumen"].DefaultView.RowFilter = sfiltro;
                    if (ds_preparacion.Tables["Resumen"].DefaultView.Count > 0)
                    {
                        Boolean bagregar = Boolean.Parse(dr["agregar"].ToString());
                        if (bagregar)
                        {
                            ds_preparacion.Tables["Resumen"].DefaultView[0]["pedido"] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0]["pedido"].ToString()) + double.Parse(dr["pedido"].ToString());
                            ds_preparacion.Tables["Resumen"].DefaultView[0]["valor_sugerido"] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0]["valor_sugerido"].ToString()) + double.Parse(dr["valor_sugerido"].ToString());
                            ds_preparacion.Tables["Resumen"].DefaultView[0]["peso"] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0]["peso"].ToString()) + (double.Parse(dr["peso"].ToString()) * double.Parse(dr["pedido"].ToString()));
                            ds_preparacion.Tables["Resumen"].DefaultView[0]["volumen"] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0]["volumen"].ToString()) + (double.Parse(dr["volumen"].ToString()) * double.Parse(dr["pedido"].ToString()));

                        }

                            ds_preparacion.Tables["Resumen"].DefaultView[0]["cd_cajas"] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0]["cd_cajas"].ToString()) +
                                       (double.Parse(dr["cd_cajas"].ToString()));
                            ds_preparacion.Tables["Resumen"].DefaultView[0]["cdx_cajas"] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0]["cdx_cajas"].ToString()) +
                                            (double.Parse(dr["cdx_cajas"].ToString()));

                            ds_preparacion.Tables["Resumen"].DefaultView[0]["cdag_cajas"] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0]["cdag_cajas"].ToString()) +
                                            (double.Parse(dr["cdag_cajas"].ToString()));
                            
                            ds_preparacion.Tables["Resumen"].DefaultView[0]["cdor_cajas"] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0]["cdor_cajas"].ToString()) +
                                            (double.Parse(dr["cdor_cajas"].ToString()));


                        ds_preparacion.Tables["Resumen"].DefaultView[0]["da_cajas"] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0]["da_cajas"].ToString()) +
                                            (double.Parse(dr["da_cajas"].ToString()));

                            ds_preparacion.Tables["Resumen"].DefaultView[0]["bodegas"] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0]["bodegas"].ToString()) +
                                            (double.Parse(dr["bodegas"].ToString()));

                            ds_preparacion.Tables["Resumen"].DefaultView[0]["internacion"] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0]["internacion"].ToString()) + double.Parse(dr["internacion"].ToString());

                        saux = "reservas";
                        ds_preparacion.Tables["Resumen"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());


                        saux = "transito";
                            ds_preparacion.Tables["Resumen"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                            //dr_aux[saux] = 0;
                            saux = "ppto";
                            ds_preparacion.Tables["Resumen"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());


                      
                        ds_preparacion.Tables["Resumen"].DefaultView[0]["sugerido"] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0]["sugerido"].ToString()) + double.Parse(dr["sugerido"].ToString());
                        for (int icount = 1; icount <= 62; icount++)
                        {
                            saux = "sugerido+" + icount.ToString("00");
                            ds_preparacion.Tables["Resumen"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());

                            saux = "transito+" + icount.ToString("00");
                            ds_preparacion.Tables["Resumen"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());

                            saux = "ppto+" + icount.ToString("00");
                            ds_preparacion.Tables["Resumen"].DefaultView[0][saux] = double.Parse(ds_preparacion.Tables["Resumen"].DefaultView[0][saux].ToString()) + double.Parse(dr[saux].ToString());

                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

        }

        public void generarResumenTotal()
        {
            String sfiltro, saux;
            Int32 iaux;
            DataRow drnew;

            ds_preparacion.Tables["resumenTotal"].Rows.Clear();
            foreach (DataRow dr_aux in ds_preparacion.Tables["resumenTotal"].Rows)
            {
                dr_aux["pedido"] = 0;
                dr_aux["sugerido"] = 0;
                for (int icount = 1; icount < 12; icount++)
                {
                    saux = "sugerido+" + icount.ToString("00");
                    dr_aux[saux] = 0;
                }
                dr_aux["sugerido_proveedor"] = 0;
                dr_aux["valor_sugerido"] = 0;
                dr_aux["min_cajas"] = 0;
                dr_aux["max_cajas"] = 0;
                dr_aux["cd_cajas"] = 0;
                dr_aux["cdx_cajas"] = 0;
                dr_aux["cdag_cajas"] = 0;
                dr_aux["cdor_cajas"] = 0;
                dr_aux["da_cajas"] = 0;
                dr_aux["internacion"] = 0;
                dr_aux["existencia"] = 0;
                dr_aux["transito"] = 0;
                dr_aux["ppto"] = 0;
                dr_aux["saldo"] = 0;
                dr_aux["cobertura"] = 0;
                dr_aux["fob"] = 0;
                dr_aux["teorico"] = 0;
                dr_aux["calculos"] = 0;
                dr_aux["pv_lead_time_total"] = 0;
                dr_aux["pv_ciclo_compra"] = 0;
                dr_aux["pv_margen_seguridad"] = 0;
                dr_aux["pv_inv_maximo"] = 0;
                dr_aux["pv_inv_seguridad"] = 0;

                for (iaux = 1; iaux <= 62; iaux++)
                {
                    saux = "transito+" + iaux.ToString("00");
                    dr_aux[saux] = 0;
                    saux = "ppto+" + iaux.ToString("00");
                    dr_aux[saux] = 0;
                    saux = "saldo+" + iaux.ToString("00");
                    dr_aux[saux] = 0;
                    saux = "cobertura+" + iaux.ToString("00");
                    dr_aux[saux] = 0;
                    saux = "teorico+" + iaux.ToString("00");
                    dr_aux[saux] = 0;
                    saux = "valor_transito+" + iaux.ToString("00");
                    dr_aux[saux] = 0;
                }
                dr_aux["peso"] = 0;
                dr_aux["volumen"] = 0;

            }


            foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
            {

                try
                {
                    if (ds_preparacion.Tables["ResumenTotal"].Rows.Count == 0)
                    {
                        drnew = ds_preparacion.Tables["ResumenTotal"].NewRow();
                        foreach (DataColumn dc in ds_preparacion.Tables["ResumenTotal"].Columns)
                        {
                            try
                            {
                                drnew[dc.ColumnName] = dr[dc.ColumnName];
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        drnew["pedido"] = 0;
                        drnew["valor_sugerido"] = 0;
                        drnew["peso"] = 0;
                        drnew["volumen"] = 0;
                        ds_preparacion.Tables["ResumenTotal"].Rows.Add(drnew);
                    }

                    //ds_preparacion.Tables["Resumen"].DefaultView.RowFilter = sfiltro;
                    if (ds_preparacion.Tables["ResumenTotal"].Rows.Count > 0)
                    {
                        Boolean bagregar = Boolean.Parse(dr["agregar"].ToString());
                        if (bagregar)
                        {
                            ds_preparacion.Tables["Resumentotal"].Rows[0]["pedido"] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0]["pedido"].ToString()) + double.Parse(dr["pedido"].ToString());
                            ds_preparacion.Tables["Resumentotal"].Rows[0]["valor_sugerido"] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0]["valor_sugerido"].ToString()) + double.Parse(dr["valor_sugerido"].ToString());
                            ds_preparacion.Tables["Resumentotal"].Rows[0]["peso"] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0]["peso"].ToString()) + (double.Parse(dr["peso"].ToString()) * double.Parse(dr["pedido"].ToString()));
                            ds_preparacion.Tables["Resumentotal"].Rows[0]["volumen"] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0]["volumen"].ToString()) + (double.Parse(dr["volumen"].ToString()) * double.Parse(dr["pedido"].ToString()));
                        }
                        ds_preparacion.Tables["Resumentotal"].Rows[0]["sugerido"] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0]["sugerido"].ToString()) + double.Parse(dr["sugerido"].ToString());
                        for (int icount = 1; icount < 12; icount++)
                        {
                            saux = "sugerido+" + icount.ToString("00");
                            ds_preparacion.Tables["Resumentotal"].Rows[0][saux] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                        }

                        ds_preparacion.Tables["Resumentotal"].Rows[0]["cd_cajas"] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0]["cd_cajas"].ToString()) +
                                        (double.Parse(dr["cd_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));
                        ds_preparacion.Tables["Resumentotal"].Rows[0]["cdx_cajas"] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0]["cdx_cajas"].ToString()) +
                                        (double.Parse(dr["cdx_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));
                        ds_preparacion.Tables["Resumentotal"].Rows[0]["cdag_cajas"] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0]["cdag_cajas"].ToString()) +
                                        (double.Parse(dr["cdag_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));
                        ds_preparacion.Tables["Resumentotal"].Rows[0]["cdor_cajas"] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0]["cdor_cajas"].ToString()) +
                                        (double.Parse(dr["cdor_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));


                        ds_preparacion.Tables["Resumentotal"].Rows[0]["da_cajas"] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0]["da_cajas"].ToString()) +
                                        (double.Parse(dr["da_cajas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));

                        ds_preparacion.Tables["Resumentotal"].Rows[0]["bodegas"] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0]["bodegas"].ToString()) +
                                        (double.Parse(dr["bodegas"].ToString()) * double.Parse(dr["costo_unitario"].ToString()));

                        ds_preparacion.Tables["Resumentotal"].Rows[0]["internacion"] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0]["internacion"].ToString()) + double.Parse(dr["internacion"].ToString());


                        saux = "transito";
                        ds_preparacion.Tables["Resumentotal"].Rows[0][saux] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                        //dr_aux[saux] = 0;
                        saux = "ppto";
                        ds_preparacion.Tables["Resumentotal"].Rows[0][saux] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0][saux].ToString()) + double.Parse(dr[saux].ToString());


                        for (iaux = 1; iaux <= 62; iaux++)
                        {
                            saux = "transito+" + iaux.ToString("00");
                            ds_preparacion.Tables["Resumentotal"].Rows[0][saux] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                            saux = "ppto+" + iaux.ToString("00");
                            ds_preparacion.Tables["Resumentotal"].Rows[0][saux] = double.Parse(ds_preparacion.Tables["Resumentotal"].Rows[0][saux].ToString()) + double.Parse(dr[saux].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

        }

        public void generarResumenProyeccion()
        {
            String sfiltro, saux = "", sname, sname2="", sfiltro2 = "";
            Int32 iaux;
            DataRow drnew;

            ds_preparacion.Tables["resumenProyeccion"].Rows.Clear();

            foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
            {

                sfiltro = "procedencia = '" + dr["procedencia"].ToString() + "' and proveedor = '" + dr["proveedor"].ToString() + "'";
                ds_preparacion.Tables["resumenProyeccion"].DefaultView.RowFilter = sfiltro;
                try
                {
                    if (ds_preparacion.Tables["resumenProyeccion"].DefaultView.Count == 0)
                    {
                        for (int icont = 1; icont < 6; icont++) {
                            drnew = ds_preparacion.Tables["resumenProyeccion"].NewRow();
                            if (icont == 1)
                                drnew["item"] = "transito";
                            else if (icont == 2)
                                drnew["item"] = "presupuesto";
                            else if (icont == 3)
                                drnew["item"] = "saldo";
                            else if (icont == 4)
                                drnew["item"] = "cobertura";
                            else if (icont == 5)
                                drnew["item"] = "valor_transito";

                            //   drnew = ds_preparacion.Tables["resumenProyeccion"].NewRow();
                            drnew["empresa"] = dr["empresa"];
                            drnew["procedencia"] = dr["procedencia"];
                            drnew["proveedor"] = dr["proveedor"];

                            for (int icount = 1; icount <= 62; icount++)
                            {
                                sname = "semana+" + icount.ToString("00");
                                drnew[sname] = 0;
                            }

                            ds_preparacion.Tables["resumenProyeccion"].Rows.Add(drnew);
                        }
                    }

                    ds_preparacion.Tables["resumenProyeccion"].DefaultView.RowFilter = sfiltro;
                    if (ds_preparacion.Tables["resumenProyeccion"].DefaultView.Count > 0)
                    {
                        for (int icont = 1; icont < 6; icont++)
                        {
                            ds_preparacion.Tables["resumenProyeccion"].DefaultView.RowFilter = sfiltro;

                            if (icont == 1)
                                sfiltro2 = " and item = 'transito'";
                            else if (icont == 2)
                                sfiltro2 = " and item = 'presupuesto'";
                            else if (icont == 3)
                                sfiltro2 = " and item = 'saldo'";
                            else if (icont == 4)
                                sfiltro2 = " and item = 'cobertura'";
                            else if (icont == 5)
                                sfiltro2 = " and item = 'valor_transito'";

                            if (icont == 1)
                                saux = "transito+";
                            else if (icont == 2)
                                saux = "ppto+";
                            else if (icont == 3)
                                saux = "saldo+";
                            else if (icont == 4)
                                saux = "cobertura+";
                            else if (icont == 5)
                                saux = "valor_transito+";

                            sfiltro2 = sfiltro + sfiltro2;
                            ds_preparacion.Tables["resumenProyeccion"].DefaultView.RowFilter = sfiltro2;

                            foreach (DataRowView drv in ds_preparacion.Tables["resumenProyeccion"].DefaultView)
                            {
                                try
                                {
                                    for (int icount = 1; icount <= 62; icount++)
                                    {
                                        sname = "semana+" + icount.ToString("00");
                                        sname2 = saux + icount.ToString("00");
                                        drv[sname] = Double.Parse(drv[sname].ToString()) + Double.Parse(dr[sname2].ToString());
                                    }
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                }

            }



        }

        public void Crear_Estructura()
        {
            string sname;
            DataTable dt = new DataTable("detalle_productos");

            dt.Columns.Add(new DataColumn("empresa", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("bu", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("familia", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("proveedor", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("procedencia", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("region", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("marca", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("producto", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("glosa", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("pareto", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("estatus", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("uxc", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("fob", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("pedido", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("cobertura_pedido", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("sugerido_proveedor", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("valor_sugerido", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("agregar", System.Type.GetType("System.Boolean")));
            dt.Columns.Add(new DataColumn("minimo_compra", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("sugerido", System.Type.GetType("System.Int32")));
            for (int icount = 1; icount <= 62; icount++)
            {
                sname = "sugerido+" + icount.ToString("00");
                dt.Columns.Add(new DataColumn(sname, System.Type.GetType("System.Int32")));
            }
            dt.Columns.Add(new DataColumn("porcentaje_ajuste", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("pv_lead_time_total", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("internacion", System.Type.GetType("System.Decimal")));
            
            //(c) 20160831 Se Cambio a Decimales
            dt.Columns.Add(new DataColumn("cd_cajas", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("cdx_cajas", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("cdag_cajas", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("cdor_cajas", System.Type.GetType("System.Decimal")));
            
            
            //dt.Columns.Add(new DataColumn("cdag_cajas", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("da_cajas", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("bodegas", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("consignaciones", System.Type.GetType("System.Decimal")));

            dt.Columns.Add(new DataColumn("existencia", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("inco_cajas", System.Type.GetType("System.Decimal"))); //(c) 20250921 Se agrega costo de incondicional

            dt.Columns.Add(new DataColumn("min_cajas", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("max_cajas", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("costo_unitario", System.Type.GetType("System.Decimal")));

            //(c) 20210518 Se Agregan las Reservas
            dt.Columns.Add(new DataColumn("reservas", System.Type.GetType("System.Decimal")));

            dt.Columns.Add(new DataColumn("ppto", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("transito", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("saldo", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("cobertura", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("teorico", System.Type.GetType("System.Decimal"))); //''Saldo Teorico al saldo se le suma el transito
            dt.Columns.Add(new DataColumn("valor_transito", System.Type.GetType("System.Decimal"))); //''Saldo Teorico al saldo se le suma el transito

            for (int icount = 1; icount <= 62; icount++)
            {
                sname = "ppto+" + icount.ToString("00");
                dt.Columns.Add(new DataColumn(sname, System.Type.GetType("System.Decimal")));
                sname = "transito+" + icount.ToString("00");
                dt.Columns.Add(new DataColumn(sname, System.Type.GetType("System.Decimal")));
                sname = "saldo+" + icount.ToString("00");
                dt.Columns.Add(new DataColumn(sname, System.Type.GetType("System.Decimal")));
                sname = "cobertura+" + icount.ToString("00");
                dt.Columns.Add(new DataColumn(sname, System.Type.GetType("System.Decimal")));
                sname = "teorico+" + icount.ToString("00");
                dt.Columns.Add(new DataColumn(sname, System.Type.GetType("System.Decimal")));
                sname = "valor_transito+" + icount.ToString("00");
                dt.Columns.Add(new DataColumn(sname, System.Type.GetType("System.Decimal")));

            }
            dt.Columns.Add(new DataColumn("full", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("cajasxlayer", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("cajasxpallet", System.Type.GetType("System.Int32")));
            //dt.Columns.Add(new DataColumn("minimo_compra", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("sugerido_anterior", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("pv_ciclo_compra", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("pv_ciclo_pago", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("pv_margen_seguridad", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("pv_inv_maximo", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("pv_inv_seguridad", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("pv_inv_reorden", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("pv_modificar_transito", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("calculos", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("tiene_compra", System.Type.GetType("System.Boolean")));
            dt.Columns.Add(new DataColumn("peso", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("volumen", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("peso_total", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("volumen_total", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("numero_registro", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("fecha_registro", System.Type.GetType("System.DateTime")));

            


            if (ds_preparacion.Tables.Contains(dt.TableName))
                ds_preparacion.Tables.Remove(dt.TableName);

            ds_preparacion.Tables.Add(dt.Copy());

            dt.TableName = "Resumen";

            if (ds_preparacion.Tables.Contains(dt.TableName))
                ds_preparacion.Tables.Remove(dt.TableName);
            ds_preparacion.Tables.Add(dt.Copy());

            dt.TableName = "ResumenTotal";

            if (ds_preparacion.Tables.Contains(dt.TableName))
                ds_preparacion.Tables.Remove(dt.TableName);
            ds_preparacion.Tables.Add(dt.Copy());


            dt = new DataTable("resumenProyeccion");

            dt.Columns.Add(new DataColumn("empresa", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("proveedor", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("procedencia", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("item", System.Type.GetType("System.String")));

            for (int icount = 1; icount <= 62; icount++)
            {
                sname = "semana+" + icount.ToString("00");
                dt.Columns.Add(new DataColumn(sname, System.Type.GetType("System.Decimal")));
            }

            if (ds_preparacion.Tables.Contains(dt.TableName))
                ds_preparacion.Tables.Remove(dt.TableName);
            ds_preparacion.Tables.Add(dt.Copy());

        }

        public void generarExistencia(Boolean pbempresa, Boolean pbincluirBodegasExtras)
        {

            double iaux;
            double uxc;
            DataTable dtunicos, dt, dtInternacion;
            ClasesGenerales.General clsGen = new ClasesGenerales.General();
            Transaccional.Conexion Otrans = new Transaccional.Conexion("SCM");
            bool lbgeneradoVinoteca = false;
            try
            {

                Otrans.abrir();

                char[] delimiters = new char[] { ',' };
                string lsSQL = "";

                if (pbempresa)
                    dtunicos = clsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], "empresa".Split(delimiters));
                else
                    dtunicos = clsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], "empresa,proveedor".Split(delimiters));



                foreach (DataRow dr_aux in dtunicos.Rows)
                {
                    lsSQL = "pa_var_um_existencias_producto '" + dr_aux["empresa"].ToString() + "',";

                    if (pbempresa)
                        lsSQL = lsSQL + "NULL,NULL,NULL";
                    else
                        lsSQL = lsSQL + "'" + dr_aux["proveedor"].ToString() + "',NULL,NULL";


                    dt = Otrans.Obtiene(lsSQL);
                    dt.Columns.Add(new DataColumn("cajas", System.Type.GetType("System.Decimal")));
                    dt.DefaultView.RowFilter = "bodega = 'CD_CENTRAL'";
                    try
                    {
                        foreach (DataRowView drv2 in dt.DefaultView)
                        {
                            ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                               = "producto = '" + drv2["producto"].ToString() + "' and empresa = '" + drv2["empresa"].ToString() + "'";

                            if (drv2["producto"] == "0100010017")
                                drv2["producto"] = "0100010017";

                            foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                            {
                                try
                                {
                                    uxc = 1;
                                    if (double.Parse(drv["uxc"].ToString()) > 0)
                                        uxc = double.Parse(drv["uxc"].ToString());
                                    iaux = double.Parse(drv2["Existencia"].ToString()) / uxc;
                                }
                                catch (Exception ex) { iaux = 0; }

                                drv["cd_cajas"] = double.Parse(drv["cd_cajas"].ToString()) + iaux;
                                drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                            }


                            ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + drv2["empresa"].ToString() + "' and " +
                                          "producto = '" + drv2["producto"].ToString() + "'";

                            if (ds_preparacion.Tables["derivados"].DefaultView.Count > 0)
                            {

                                foreach (DataRowView drvauxDerivado in ds_preparacion.Tables["derivados"].DefaultView)
                                {
                                    try
                                    {
                                        drvauxDerivado["existencia"] = double.Parse(drvauxDerivado["existencia"].ToString()) + double.Parse(drv2["Existencia"].ToString()); //(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")
                                                                                                                                                                            // (c) 
                                        drvauxDerivado["existencia_total"] = double.Parse(drvauxDerivado["existencia_total"].ToString()) + double.Parse(drvauxDerivado["existencia"].ToString());
                                    }
                                    catch (Exception ex) { }

                                    ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                                = "producto = '" + drvauxDerivado["producto_padre"].ToString() + "' and empresa = '" + drvauxDerivado["empresa"].ToString() + "'";

                                    foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                                    {
                                        try
                                        {
                                            uxc = 1;
                                            if (double.Parse(drv["uxc"].ToString()) > 0)
                                                uxc = double.Parse(drv["uxc"].ToString());

                                            iaux = (double.Parse(drv2["Existencia"].ToString()) * double.Parse(drvauxDerivado["unidades"].ToString())) / uxc;
                                        }
                                        catch (Exception ex) { iaux = 0; }

                                        drv["cd_cajas"] = double.Parse(drv["cd_cajas"].ToString()) + iaux;
                                        drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                                    }
                                }
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        clsGen.Escribir_Log(ex.Message);
                    }
                    //dt.DefaultView.RowFilter = "bodega = 'CDX_CENTRAL'";
                    //(c) 20191213 Se Cambio por bodega CD_ANTIGUA

                    dt.DefaultView.RowFilter = "bodega = 'CDR_XELA' ";
                    foreach (DataRowView drv2 in dt.DefaultView)
                    {
                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                           = "producto = '" + drv2["producto"].ToString() + "' and empresa = '" + drv2["empresa"].ToString() + "'";

                        foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                        {
                            try
                            {
                                uxc = 1;
                                if (double.Parse(drv["uxc"].ToString()) > 0)
                                    uxc = double.Parse(drv["uxc"].ToString());

                                iaux = double.Parse(drv2["Existencia"].ToString()) / uxc;
                            }
                            catch (Exception ex) { iaux = 0; }

                            drv["cdx_cajas"] = double.Parse(drv["cdx_cajas"].ToString()) + iaux;
                            drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                        }


                        ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + drv2["empresa"].ToString() + "' and " +
                                      "producto = '" + drv2["producto"].ToString() + "'";

                        if (ds_preparacion.Tables["derivados"].DefaultView.Count > 0)
                        {

                            foreach (DataRowView drvauxDerivado in ds_preparacion.Tables["derivados"].DefaultView)
                            {
                                try
                                {
                                    drvauxDerivado["existencia"] = double.Parse(drvauxDerivado["existencia"].ToString()) + double.Parse(drv2["Existencia"].ToString()); //(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")
                                    drvauxDerivado["existencia_total"] = double.Parse(drvauxDerivado["existencia_total"].ToString()) + double.Parse(drvauxDerivado["existencia"].ToString());
                                }
                                catch (Exception ex) { }

                                ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                            = "producto = '" + drvauxDerivado["producto_padre"].ToString() + "' and empresa = '" + drvauxDerivado["empresa"].ToString() + "'";

                                foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                                {
                                    try
                                    {
                                        uxc = 1;
                                        if (double.Parse(drv["uxc"].ToString()) > 0)
                                            uxc = double.Parse(drv["uxc"].ToString());

                                        iaux = (double.Parse(drv2["Existencia"].ToString()) * double.Parse(drvauxDerivado["unidades"].ToString())) / uxc;
                                    }
                                    catch (Exception ex) { iaux = 0; }

                                    drv["cdx_cajas"] = double.Parse(drv["cdx_cajas"].ToString()) + iaux;
                                    drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                                }

                            }
                        }

                    }



                    //(c) 20220922 se agrega cdag bodega de antigua

                    dt.DefaultView.RowFilter = "bodega = 'CDR_ANTIGUA' ";
                    foreach (DataRowView drv2 in dt.DefaultView)
                    {
                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                           = "producto = '" + drv2["producto"].ToString() + "' and empresa = '" + drv2["empresa"].ToString() + "'";

                        foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                        {
                            try
                            {
                                uxc = 1;
                                if (double.Parse(drv["uxc"].ToString()) > 0)
                                    uxc = double.Parse(drv["uxc"].ToString());

                                iaux = double.Parse(drv2["Existencia"].ToString()) / uxc;
                            }
                            catch (Exception ex) { iaux = 0; }

                            drv["cdag_cajas"] = double.Parse(drv["cdag_cajas"].ToString()) + iaux;
                            drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                        }


                        ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + drv2["empresa"].ToString() + "' and " +
                                      "producto = '" + drv2["producto"].ToString() + "'";

                        if (ds_preparacion.Tables["derivados"].DefaultView.Count > 0)
                        {

                            foreach (DataRowView drvaux in ds_preparacion.Tables["derivados"].DefaultView)
                            {
                                try
                                {
                                    drvaux["existencia"] = double.Parse(drvaux["existencia"].ToString()) + double.Parse(drv2["Existencia"].ToString()); //(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")

                                }
                                catch (Exception ex) { }

                                ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                            = "producto = '" + drvaux["producto_padre"].ToString() + "' and empresa = '" + drvaux["empresa"].ToString() + "'";

                                foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                                {
                                    try
                                    {
                                        uxc = 1;
                                        if (double.Parse(drv["uxc"].ToString()) > 0)
                                            uxc = double.Parse(drv["uxc"].ToString());

                                        iaux = (double.Parse(drv2["Existencia"].ToString()) * double.Parse(drvaux["unidades"].ToString())) / uxc;
                                    }
                                    catch (Exception ex) { iaux = 0; }

                                    drv["cdag_cajas"] = double.Parse(drv["cdag_cajas"].ToString()) + iaux;
                                    drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                                }

                            }
                        }

                    }

                    //(c) 20240827 se agrega cdag bodega de Oriente

                    dt.DefaultView.RowFilter = "bodega = 'CDR_ORIENTE' ";
                    foreach (DataRowView drv2 in dt.DefaultView)
                    {
                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                           = "producto = '" + drv2["producto"].ToString() + "' and empresa = '" + drv2["empresa"].ToString() + "'";

                        foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                        {
                            try
                            {
                                uxc = 1;
                                if (double.Parse(drv["uxc"].ToString()) > 0)
                                    uxc = double.Parse(drv["uxc"].ToString());

                                iaux = double.Parse(drv2["Existencia"].ToString()) / uxc;
                            }
                            catch (Exception ex) { iaux = 0; }

                            drv["cdor_cajas"] = double.Parse(drv["cdor_cajas"].ToString()) + iaux;
                            drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                        }


                        ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + drv2["empresa"].ToString() + "' and " +
                                      "producto = '" + drv2["producto"].ToString() + "'";

                        if (ds_preparacion.Tables["derivados"].DefaultView.Count > 0)
                        {

                            foreach (DataRowView drvauxDerivado in ds_preparacion.Tables["derivados"].DefaultView)
                            {
                                try
                                {
                                    drvauxDerivado["existencia"] = double.Parse(drvauxDerivado["existencia"].ToString()) + double.Parse(drv2["Existencia"].ToString()); //(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")
                                    drvauxDerivado["existencia_total"] = double.Parse(drvauxDerivado["existencia_total"].ToString()) + double.Parse(drvauxDerivado["existencia"].ToString());
                                }
                                catch (Exception ex) { }

                                ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                            = "producto = '" + drvauxDerivado["producto_padre"].ToString() + "' and empresa = '" + drvauxDerivado["empresa"].ToString() + "'";

                                foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                                {
                                    try
                                    {
                                        uxc = 1;
                                        if (double.Parse(drv["uxc"].ToString()) > 0)
                                            uxc = double.Parse(drv["uxc"].ToString());

                                        iaux = (double.Parse(drv2["Existencia"].ToString()) * double.Parse(drvauxDerivado["unidades"].ToString())) / uxc;
                                    }
                                    catch (Exception ex) { iaux = 0; }

                                    drv["cdor_cajas"] = double.Parse(drv["cdor_cajas"].ToString()) + iaux;
                                    drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                                }

                            }
                        }

                    }


                    //DA CENTRAL
                    dt.DefaultView.RowFilter = "bodega = 'DA_CENTRAL'";
                    foreach (DataRowView drv2 in dt.DefaultView)
                    {
                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                           = "producto = '" + drv2["producto"].ToString() + "' and empresa = '" + drv2["empresa"].ToString() + "'";

                        foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                        {
                            try
                            {
                                uxc = 1;
                                if (double.Parse(drv["uxc"].ToString()) > 0)
                                    uxc = double.Parse(drv["uxc"].ToString());
                                iaux = double.Parse(drv2["Existencia"].ToString()) / uxc;
                            }
                            catch (Exception ex) { iaux = 0; }

                            drv["da_cajas"] = double.Parse(drv["da_cajas"].ToString()) + iaux;
                            drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                        }


                        ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + drv2["empresa"].ToString() + "' and " +
                                      "producto = '" + drv2["producto"].ToString() + "'";

                        if (ds_preparacion.Tables["derivados"].DefaultView.Count > 0)
                        {

                            foreach (DataRowView drvauxDerivado in ds_preparacion.Tables["derivados"].DefaultView)
                            {
                                try
                                {
                                    drvauxDerivado["existencia"] = double.Parse(drvauxDerivado["existencia"].ToString()) + double.Parse(drv2["Existencia"].ToString()); //(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")
                                    drvauxDerivado["existencia_total"] = double.Parse(drvauxDerivado["existencia_total"].ToString()) + double.Parse(drvauxDerivado["existencia"].ToString());
                                }
                                catch (Exception ex) { }

                                ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                            = "producto = '" + drvauxDerivado["producto_padre"].ToString() + "' and empresa = '" + drvauxDerivado["empresa"].ToString() + "'";

                                foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                                {
                                    try
                                    {
                                        uxc = 1;
                                        if (double.Parse(drv["uxc"].ToString()) > 0)
                                            uxc = double.Parse(drv["uxc"].ToString());
                                        iaux = (double.Parse(drv2["Existencia"].ToString()) * double.Parse(drvauxDerivado["unidades"].ToString())) / uxc;
                                    }
                                    catch (Exception ex) { iaux = 0; }

                                    drv["da_cajas"] = double.Parse(drv["da_cajas"].ToString()) + iaux;
                                    drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                                }
                            }
                        }
                    }



                    //dt.DefaultView.RowFilter = "bodega <> 'CDX_CENTRAL' and bodega <> 'CD_CENTRAL' and bodega <> 'DA_CENTRAL'";
                    dt.DefaultView.RowFilter = "bodega <> 'CDR_ANTIGUA' and bodega <> 'CD_CENTRAL' and bodega <> 'DA_CENTRAL' and bodega <> 'CDR_XELA' and bodega <> 'CDR_ORIENTE'";
                    foreach (DataRowView drv2 in dt.DefaultView)
                    {

                        if (drv2["bodega"].ToString().ToLower().IndexOf("liqu") > 0 ||
                                 drv2["bodega"].ToString().ToLower().IndexOf("estado") > 0 ||
                                 drv2["bodega"].ToString().ToLower().IndexOf("promo") > 0 ||
                                     drv2["bodega"].ToString().ToLower().IndexOf("liqu") > 0)
                        {

                        }
                        else
                        {


                            if (drv2["producto"].ToString() == "0300020205")
                            {
                                drv2["cajas"] = 0;
                            }

                            drv2["cajas"] = 0;
                            ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                               = "producto = '" + drv2["producto"].ToString() + "' and empresa = '" + drv2["empresa"].ToString() + "'";

                            foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                            {
                                try
                                {
                                    uxc = 1;
                                    if (double.Parse(drv["uxc"].ToString()) > 0)
                                        uxc = double.Parse(drv["uxc"].ToString());
                                    iaux = double.Parse(drv2["Existencia"].ToString()) / uxc;

                                }
                                catch (Exception ex) { iaux = 0; }


                                //Validar Bodega de Consignaciones
                                if (drv2["bodega"].ToString().ToLower().IndexOf("cons") >= 0)
                                {
                                    drv["consignaciones"] = double.Parse(drv["consignaciones"].ToString()) + iaux;
                                }
                                drv["bodegas"] = double.Parse(drv["bodegas"].ToString()) + iaux;
                                drv2["cajas"] = double.Parse(drv2["cajas"].ToString()) + iaux;
                                drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                            }


                            ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + drv2["empresa"].ToString() + "' and " +
                                          "producto = '" + drv2["producto"].ToString() + "'";

                            if (ds_preparacion.Tables["derivados"].DefaultView.Count > 0)
                            {

                                foreach (DataRowView drvauxDerivado in ds_preparacion.Tables["derivados"].DefaultView)
                                {
                                    try
                                    {
                                        drvauxDerivado["existencia"] = double.Parse(drvauxDerivado["existencia"].ToString()) + double.Parse(drv2["Existencia"].ToString()); //(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")
                                        drvauxDerivado["existencia_total"] = double.Parse(drvauxDerivado["existencia_total"].ToString()) + double.Parse(drvauxDerivado["existencia"].ToString());
                                    }
                                    catch (Exception ex) { }

                                    ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                                = "producto = '" + drvauxDerivado["producto_padre"].ToString() + "' and empresa = '" + drvauxDerivado["empresa"].ToString() + "'";

                                    foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                                    {
                                        try
                                        {
                                            uxc = 1;
                                            if (double.Parse(drv["uxc"].ToString()) > 0)
                                                uxc = double.Parse(drv["uxc"].ToString());
                                            iaux = (double.Parse(drv2["Existencia"].ToString()) * double.Parse(drvauxDerivado["unidades"].ToString())) / uxc;
                                        }
                                        catch (Exception ex) { iaux = 0; }

                                        //Validar Bodega de Consignaciones
                                        if (drv2["bodega"].ToString().ToLower().IndexOf("cons") >= 0)
                                        {
                                            drv["consignaciones"] = double.Parse(drv["consignaciones"].ToString()) + iaux;
                                        }
                                        drv["bodegas"] = double.Parse(drv["bodegas"].ToString()) + iaux;
                                        drv2["cajas"] = double.Parse(drv2["cajas"].ToString()) + iaux;
                                    }
                                }
                            }
                        }
                    }

                    //(c) 31072014 Solicitado MMEZA
                    //Cuando se este verificando diuva y este indicado la opcion de obtener inventario de VINOTECA
                    //if (dr_aux["empresa"].ToString().ToLower() == "diuva" && pbincluirBodegasExtras && !lbgeneradoVinoteca)
                    //(c) 20161016 Solicitado SARANA, en cualquier empresa que solicite Dataserver
                    if (pbincluirBodegasExtras && !lbgeneradoVinoteca)
                    {

                        lbgeneradoVinoteca = true;
                        DataTable dt2;

                        lsSQL = "pa_var_um_existencias_producto 'VINOTECA',NULL,NULL,NULL";


                        //(c) 31082014 Modificacion por falta de utilizacion de filtro
                        //if (pbempresa)
                        //    lsSQL = lsSQL + "NULL,NULL,NULL";
                        //else
                        //    lsSQL = lsSQL + "'" + dr_aux["proveedor"].ToString() + "',NULL,NULL";

                        dt2 = Otrans.Obtiene(lsSQL);
                        dt2.Columns.Add(new DataColumn("cajas", System.Type.GetType("System.Decimal")));

                        foreach (DataRowView drvProductosVinoteca in dt2.DefaultView)
                        {
                            ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                               = "producto = '" + drvProductosVinoteca["producto"].ToString() + "'";
                            // and empresa = '" + drv2["empresa"].ToString() + "'";


                            if (drvProductosVinoteca["producto"].ToString() == "0300020205")
                            {
                                drvProductosVinoteca["cajas"] = 0;
                            }

                            drvProductosVinoteca["cajas"] = 0;
                            foreach (DataRowView drvProductosDetalle in ds_preparacion.Tables["detalle_productos"].DefaultView)
                            {
                                try
                                {
                                    uxc = 1;
                                    if (double.Parse(drvProductosDetalle["uxc"].ToString()) > 0)
                                        uxc = double.Parse(drvProductosDetalle["uxc"].ToString());
                                    iaux = double.Parse(drvProductosVinoteca["Existencia"].ToString()) / uxc;
                                }
                                catch (Exception ex) { iaux = 0; }


                                //8c) 20181217 Si esta generando solo vinoteca no se debe tomar en cuenta da y cd
                                //

                                if ((drvProductosVinoteca["bodega"].ToString().ToLower().IndexOf("cd_central") >= 0) || (drvProductosVinoteca["bodega"].ToString().ToLower().IndexOf("da_central") >= 0))
                                {
                                    if (scm_empresa.ToLower() == "vinoteca")
                                    break;
                                }
                                    //Validar Bodega de Consignaciones
                                    if (drvProductosVinoteca["bodega"].ToString().ToLower().IndexOf("cons") >= 0)
                                {
                                    drvProductosDetalle["consignaciones"] = double.Parse(drvProductosDetalle["consignaciones"].ToString()) + iaux;
                                }
                                drvProductosDetalle["bodegas"] = double.Parse(drvProductosDetalle["bodegas"].ToString()) + iaux;
                                drvProductosDetalle["existencia"] = double.Parse(drvProductosDetalle["existencia"].ToString()) + iaux;
                                drvProductosVinoteca["cajas"] = double.Parse(drvProductosVinoteca["cajas"].ToString()) + iaux;

                                try
                                {
                                    DataRow dr3;
                                    //dr3 = drv2.DataView.t;



                                    dr3 = dt.NewRow();
                                    foreach (DataColumn dc2 in dt.Columns)
                                    {
                                        dr3[dc2.ColumnName] = drvProductosVinoteca[dc2.ColumnName];

                                    }
                                    dt.Rows.Add(dr3);
                                }
                                catch (Exception ex)
                                {
                                    clsGen.Escribir_Log(ex.Message);
                                }
                            }


                        }

                    } // Empresa == diuva

                    // (c) 20251021 Calcular el inventario de la Incondicional por inventario en esa empresa
                    
                    DataTable dtExistenciaIncondiconal;

                    lsSQL = "pa_var_um_existencias_producto 'LAINCONDI',NULL,NULL,NULL";


                    dtExistenciaIncondiconal = Otrans.Obtiene(lsSQL);
                    dtExistenciaIncondiconal.Columns.Add(new DataColumn("cajas", System.Type.GetType("System.Decimal")));

                    foreach (DataRowView drvProductosLaIncondicional in dtExistenciaIncondiconal.DefaultView)
                    {
                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                           = "producto = '" + drvProductosLaIncondicional["producto"].ToString() + "'";


                        if (drvProductosLaIncondicional["producto"].ToString() == "0300020205")
                        {
                            drvProductosLaIncondicional["cajas"] = 0;
                        }

                        drvProductosLaIncondicional["cajas"] = 0;
                        foreach (DataRowView drvProductosDetalle in ds_preparacion.Tables["detalle_productos"].DefaultView)
                        {
                            try
                            {
                                uxc = 1;
                                if (double.Parse(drvProductosDetalle["uxc"].ToString()) > 0)
                                    uxc = double.Parse(drvProductosDetalle["uxc"].ToString());
                                iaux = double.Parse(drvProductosLaIncondicional["Existencia"].ToString()) / uxc;
                            }
                            catch (Exception ex) { iaux = 0; }



                            if ((drvProductosLaIncondicional["bodega"].ToString().ToLower().IndexOf("cd_central") >= 0) || (drvProductosLaIncondicional["bodega"].ToString().ToLower().IndexOf("da_central") >= 0))
                            {
                                if (scm_empresa.ToLower() == "vinoteca")
                                    break;
                            }
                            //Validar Bodega de Consignaciones
                            if (drvProductosLaIncondicional["bodega"].ToString().ToLower().IndexOf("cons") >= 0)
                            {
                                drvProductosDetalle["consignaciones"] = double.Parse(drvProductosDetalle["consignaciones"].ToString()) + iaux;
                            }
                            drvProductosDetalle["inco_cajas"] = double.Parse(drvProductosDetalle["inco_cajas"].ToString()) + iaux;
                            drvProductosDetalle["existencia"] = double.Parse(drvProductosDetalle["existencia"].ToString()) + iaux;
                            drvProductosLaIncondicional["cajas"] = double.Parse(drvProductosLaIncondicional["cajas"].ToString()) + iaux;

                            try
                            {
                                DataRow dr3;

                                dr3 = dt.NewRow();
                                foreach (DataColumn dc2 in dt.Columns)
                                {
                                    dr3[dc2.ColumnName] = drvProductosLaIncondicional[dc2.ColumnName];

                                }
                                dt.Rows.Add(dr3);
                            }
                            catch (Exception ex)
                            {
                                clsGen.Escribir_Log(ex.Message);
                            }
                        }


                    }


                    dt.TableName = "existencias";
                    try
                    {
                        dt.DefaultView.ToTable().Copy();
                        ds_preparacion.Tables.Add(dt.Copy());
                    }
                    catch { }

                } // empresa


                dtunicos = clsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], "empresa".Split(delimiters));

                foreach (DataRow dr_aux in dtunicos.Rows)
                {
                    lsSQL = "pa_var_um_producto_transito_internacion '" + dr_aux["empresa"].ToString() + "'";
                    dtInternacion = Otrans.Obtiene(lsSQL);

                    foreach (DataRow dr in dtInternacion.Rows)
                    {

                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                      = "producto = '" + dr["producto"].ToString() + "' and empresa = '" + dr["empresa"].ToString() + "'";
                        foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                        {

                            try
                            {
                                uxc = 1;
                                if (double.Parse(drv["uxc"].ToString()) > 0)
                                    uxc = double.Parse(drv["uxc"].ToString());
                                iaux = double.Parse(dr["cantidad"].ToString()) / uxc;

                            }
                            catch (Exception ex) { iaux = 0; }

                            drv["internacion"] = double.Parse(drv["internacion"].ToString()) + iaux;
                            drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;

                        }
                    }


                }

                ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter = "";


                foreach (DataRow dr_aux in ds_preparacion.Tables["detalle_productos"].Rows)
                {
                      dr_aux["bodegas"] = double.Parse(dr_aux["bodegas"].ToString()) - double.Parse(dr_aux["consignaciones"].ToString());
                }
                
                
                }
            catch (Exception ex)
            { }
            finally
            {
                Otrans.cerrar();
                Otrans = null;
                clsGen = null;
            }



        }

        public void generarExistenciaSerie_pendiente(Boolean pbempresa, Boolean pbincluirBodegasExtras)
        {

            double iaux;
            double uxc;
            DataTable dtunicos, dt, dtInternacion;
            ClasesGenerales.General clsGen = new ClasesGenerales.General();
            Transaccional.Conexion Otrans = new Transaccional.Conexion("SCM");
            bool lbgeneradoVinoteca = false;
            try
            {

                Otrans.abrir();

                char[] delimiters = new char[] { ',' };
                string lsSQL = "";

                if (pbempresa)
                    dtunicos = clsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], "empresa".Split(delimiters));
                else
                    dtunicos = clsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], "empresa,proveedor".Split(delimiters));



                foreach (DataRow dr_aux in dtunicos.Rows)
                {
                    lsSQL = "pa_var_um_existencias_producto '" + dr_aux["empresa"].ToString() + "',";

                    if (pbempresa)
                        lsSQL = lsSQL + "NULL,NULL,NULL";
                    else
                        lsSQL = lsSQL + "'" + dr_aux["proveedor"].ToString() + "',NULL,NULL";


                    dt = Otrans.Obtiene(lsSQL);
                    dt.Columns.Add(new DataColumn("cajas", System.Type.GetType("System.Decimal")));
                    dt.DefaultView.RowFilter = "bodega = 'CD_CENTRAL'";
                    try
                    {
                        foreach (DataRowView drv2 in dt.DefaultView)
                        {
                            ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                               = "producto = '" + drv2["producto"].ToString() + "' and empresa = '" + drv2["empresa"].ToString() + "'";

                            if (drv2["producto"] == "0100010017")
                                drv2["producto"] = "0100010017";

                            foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                            {
                                try
                                {
                                    uxc = 1;
                                    if (double.Parse(drv["uxc"].ToString()) > 0)
                                        uxc = double.Parse(drv["uxc"].ToString());
                                    iaux = double.Parse(drv2["Existencia"].ToString()) / uxc;
                                }
                                catch (Exception ex) { iaux = 0; }

                                drv["cd_cajas"] = double.Parse(drv["cd_cajas"].ToString()) + iaux;
                                drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                            }


                            ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + drv2["empresa"].ToString() + "' and " +
                                          "producto = '" + drv2["producto"].ToString() + "'";

                            if (ds_preparacion.Tables["derivados"].DefaultView.Count > 0)
                            {

                                foreach (DataRowView drvaux in ds_preparacion.Tables["derivados"].DefaultView)
                                {
                                    try
                                    {
                                        drvaux["existencia"] = double.Parse(drvaux["existencia"].ToString()) + double.Parse(drv2["Existencia"].ToString()); //(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")
                                    }
                                    catch (Exception ex) { }

                                    ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                                = "producto = '" + drvaux["producto_padre"].ToString() + "' and empresa = '" + drvaux["empresa"].ToString() + "'";

                                    foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                                    {
                                        try
                                        {
                                            uxc = 1;
                                            if (double.Parse(drv["uxc"].ToString()) > 0)
                                                uxc = double.Parse(drv["uxc"].ToString());

                                            iaux = (double.Parse(drv2["Existencia"].ToString()) * double.Parse(drvaux["unidades"].ToString())) / uxc;
                                        }
                                        catch (Exception ex) { iaux = 0; }

                                        drv["cd_cajas"] = double.Parse(drv["cd_cajas"].ToString()) + iaux;
                                        drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                                    }
                                }
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        clsGen.Escribir_Log(ex.Message);
                    }
                    //dt.DefaultView.RowFilter = "bodega = 'CDX_CENTRAL'";
                    //(c) 20191213 Se Cambio por bodega CD_ANTIGUA

                    dt.DefaultView.RowFilter = "bodega = 'CDR_XELA' ";
                    foreach (DataRowView drv2 in dt.DefaultView)
                    {
                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                           = "producto = '" + drv2["producto"].ToString() + "' and empresa = '" + drv2["empresa"].ToString() + "'";

                        foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                        {
                            try
                            {
                                uxc = 1;
                                if (double.Parse(drv["uxc"].ToString()) > 0)
                                    uxc = double.Parse(drv["uxc"].ToString());

                                iaux = double.Parse(drv2["Existencia"].ToString()) / uxc;
                            }
                            catch (Exception ex) { iaux = 0; }

                            drv["cdx_cajas"] = double.Parse(drv["cdx_cajas"].ToString()) + iaux;
                            drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                        }


                        ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + drv2["empresa"].ToString() + "' and " +
                                      "producto = '" + drv2["producto"].ToString() + "'";

                        if (ds_preparacion.Tables["derivados"].DefaultView.Count > 0)
                        {

                            foreach (DataRowView drvaux in ds_preparacion.Tables["derivados"].DefaultView)
                            {
                                try
                                {
                                    drvaux["existencia"] = double.Parse(drvaux["existencia"].ToString()) + double.Parse(drv2["Existencia"].ToString()); //(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")

                                }
                                catch (Exception ex) { }

                                ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                            = "producto = '" + drvaux["producto_padre"].ToString() + "' and empresa = '" + drvaux["empresa"].ToString() + "'";

                                foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                                {
                                    try
                                    {
                                        uxc = 1;
                                        if (double.Parse(drv["uxc"].ToString()) > 0)
                                            uxc = double.Parse(drv["uxc"].ToString());

                                        iaux = (double.Parse(drv2["Existencia"].ToString()) * double.Parse(drvaux["unidades"].ToString())) / uxc;
                                    }
                                    catch (Exception ex) { iaux = 0; }

                                    drv["cdx_cajas"] = double.Parse(drv["cdx_cajas"].ToString()) + iaux;
                                    drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                                }

                            }
                        }

                    }



                    //(c) 20220922 se agrega cdag bodega de antigua

                    dt.DefaultView.RowFilter = "bodega = 'CDR_ANTIGUA' ";
                    foreach (DataRowView drv2 in dt.DefaultView)
                    {
                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                           = "producto = '" + drv2["producto"].ToString() + "' and empresa = '" + drv2["empresa"].ToString() + "'";

                        foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                        {
                            try
                            {
                                uxc = 1;
                                if (double.Parse(drv["uxc"].ToString()) > 0)
                                    uxc = double.Parse(drv["uxc"].ToString());

                                iaux = double.Parse(drv2["Existencia"].ToString()) / uxc;
                            }
                            catch (Exception ex) { iaux = 0; }

                            drv["cdag_cajas"] = double.Parse(drv["cdag_cajas"].ToString()) + iaux;
                            drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                        }


                        ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + drv2["empresa"].ToString() + "' and " +
                                      "producto = '" + drv2["producto"].ToString() + "'";

                        if (ds_preparacion.Tables["derivados"].DefaultView.Count > 0)
                        {

                            foreach (DataRowView drvaux in ds_preparacion.Tables["derivados"].DefaultView)
                            {
                                try
                                {
                                    drvaux["existencia"] = double.Parse(drvaux["existencia"].ToString()) + double.Parse(drv2["Existencia"].ToString()); //(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")

                                }
                                catch (Exception ex) { }

                                ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                            = "producto = '" + drvaux["producto_padre"].ToString() + "' and empresa = '" + drvaux["empresa"].ToString() + "'";

                                foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                                {
                                    try
                                    {
                                        uxc = 1;
                                        if (double.Parse(drv["uxc"].ToString()) > 0)
                                            uxc = double.Parse(drv["uxc"].ToString());

                                        iaux = (double.Parse(drv2["Existencia"].ToString()) * double.Parse(drvaux["unidades"].ToString())) / uxc;
                                    }
                                    catch (Exception ex) { iaux = 0; }

                                    drv["cdag_cajas"] = double.Parse(drv["cdag_cajas"].ToString()) + iaux;
                                    drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                                }

                            }
                        }

                    }

                    //(c) 20240827 se agrega cdag bodega de Oriente

                    dt.DefaultView.RowFilter = "bodega = 'CDR_ORIENTE' ";
                    foreach (DataRowView drv2 in dt.DefaultView)
                    {
                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                           = "producto = '" + drv2["producto"].ToString() + "' and empresa = '" + drv2["empresa"].ToString() + "'";

                        foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                        {
                            try
                            {
                                uxc = 1;
                                if (double.Parse(drv["uxc"].ToString()) > 0)
                                    uxc = double.Parse(drv["uxc"].ToString());

                                iaux = double.Parse(drv2["Existencia"].ToString()) / uxc;
                            }
                            catch (Exception ex) { iaux = 0; }

                            drv["cdor_cajas"] = double.Parse(drv["cdor_cajas"].ToString()) + iaux;
                            drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                        }


                        ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + drv2["empresa"].ToString() + "' and " +
                                      "producto = '" + drv2["producto"].ToString() + "'";

                        if (ds_preparacion.Tables["derivados"].DefaultView.Count > 0)
                        {

                            foreach (DataRowView drvaux in ds_preparacion.Tables["derivados"].DefaultView)
                            {
                                try
                                {
                                    drvaux["existencia"] = double.Parse(drvaux["existencia"].ToString()) + double.Parse(drv2["Existencia"].ToString()); //(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")

                                }
                                catch (Exception ex) { }

                                ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                            = "producto = '" + drvaux["producto_padre"].ToString() + "' and empresa = '" + drvaux["empresa"].ToString() + "'";

                                foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                                {
                                    try
                                    {
                                        uxc = 1;
                                        if (double.Parse(drv["uxc"].ToString()) > 0)
                                            uxc = double.Parse(drv["uxc"].ToString());

                                        iaux = (double.Parse(drv2["Existencia"].ToString()) * double.Parse(drvaux["unidades"].ToString())) / uxc;
                                    }
                                    catch (Exception ex) { iaux = 0; }

                                    drv["cdor_cajas"] = double.Parse(drv["cdor_cajas"].ToString()) + iaux;
                                    drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                                }

                            }
                        }

                    }


                    //DA CENTRAL
                    dt.DefaultView.RowFilter = "bodega = 'DA_CENTRAL'";
                    foreach (DataRowView drv2 in dt.DefaultView)
                    {
                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                           = "producto = '" + drv2["producto"].ToString() + "' and empresa = '" + drv2["empresa"].ToString() + "'";

                        foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                        {
                            try
                            {
                                uxc = 1;
                                if (double.Parse(drv["uxc"].ToString()) > 0)
                                    uxc = double.Parse(drv["uxc"].ToString());
                                iaux = double.Parse(drv2["Existencia"].ToString()) / uxc;
                            }
                            catch (Exception ex) { iaux = 0; }

                            drv["da_cajas"] = double.Parse(drv["da_cajas"].ToString()) + iaux;
                            drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                        }


                        ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + drv2["empresa"].ToString() + "' and " +
                                      "producto = '" + drv2["producto"].ToString() + "'";

                        if (ds_preparacion.Tables["derivados"].DefaultView.Count > 0)
                        {

                            foreach (DataRowView drvaux in ds_preparacion.Tables["derivados"].DefaultView)
                            {
                                try
                                {
                                    drvaux["existencia"] = drv2["Existencia"]; //(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")
                                }
                                catch (Exception ex) { }

                                ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                            = "producto = '" + drvaux["producto_padre"].ToString() + "' and empresa = '" + drvaux["empresa"].ToString() + "'";

                                foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                                {
                                    try
                                    {
                                        uxc = 1;
                                        if (double.Parse(drv["uxc"].ToString()) > 0)
                                            uxc = double.Parse(drv["uxc"].ToString());
                                        iaux = (double.Parse(drv2["Existencia"].ToString()) * double.Parse(drvaux["unidades"].ToString())) / uxc;
                                    }
                                    catch (Exception ex) { iaux = 0; }

                                    drv["da_cajas"] = double.Parse(drv["da_cajas"].ToString()) + iaux;
                                    drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                                }
                            }
                        }
                    }



                    //dt.DefaultView.RowFilter = "bodega <> 'CDX_CENTRAL' and bodega <> 'CD_CENTRAL' and bodega <> 'DA_CENTRAL'";
                    dt.DefaultView.RowFilter = "bodega <> 'CDR_ANTIGUA' and bodega <> 'CD_CENTRAL' and bodega <> 'DA_CENTRAL' and bodega <> 'CDR_XELA' and bodega <> 'CDR_ORIENTE'";
                    foreach (DataRowView drv2 in dt.DefaultView)
                    {

                        if (drv2["bodega"].ToString().ToLower().IndexOf("liqu") > 0 ||
                                 drv2["bodega"].ToString().ToLower().IndexOf("estado") > 0 ||
                                 drv2["bodega"].ToString().ToLower().IndexOf("promo") > 0 ||
                                     drv2["bodega"].ToString().ToLower().IndexOf("liqu") > 0)
                        {

                        }
                        else
                        {


                            if (drv2["producto"].ToString() == "0300020205")
                            {
                                drv2["cajas"] = 0;
                            }

                            drv2["cajas"] = 0;
                            ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                               = "producto = '" + drv2["producto"].ToString() + "' and empresa = '" + drv2["empresa"].ToString() + "'";

                            foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                            {
                                try
                                {
                                    uxc = 1;
                                    if (double.Parse(drv["uxc"].ToString()) > 0)
                                        uxc = double.Parse(drv["uxc"].ToString());
                                    iaux = double.Parse(drv2["Existencia"].ToString()) / uxc;

                                }
                                catch (Exception ex) { iaux = 0; }


                                //Validar Bodega de Consignaciones
                                if (drv2["bodega"].ToString().ToLower().IndexOf("cons") >= 0)
                                {
                                    drv["consignaciones"] = double.Parse(drv["consignaciones"].ToString()) + iaux;
                                }
                                drv["bodegas"] = double.Parse(drv["bodegas"].ToString()) + iaux;
                                drv2["cajas"] = double.Parse(drv2["cajas"].ToString()) + iaux;
                                drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;
                            }


                            ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + drv2["empresa"].ToString() + "' and " +
                                          "producto = '" + drv2["producto"].ToString() + "'";

                            if (ds_preparacion.Tables["derivados"].DefaultView.Count > 0)
                            {

                                foreach (DataRowView drvaux in ds_preparacion.Tables["derivados"].DefaultView)
                                {
                                    try
                                    {
                                        drvaux["existencia"] = double.Parse(drvaux["existencia"].ToString()) + double.Parse(drv2["Existencia"].ToString()); //(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")
                                    }
                                    catch (Exception ex) { }

                                    ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                                = "producto = '" + drvaux["producto_padre"].ToString() + "' and empresa = '" + drvaux["empresa"].ToString() + "'";

                                    foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                                    {
                                        try
                                        {
                                            uxc = 1;
                                            if (double.Parse(drv["uxc"].ToString()) > 0)
                                                uxc = double.Parse(drv["uxc"].ToString());
                                            iaux = (double.Parse(drv2["Existencia"].ToString()) * double.Parse(drvaux["unidades"].ToString())) / uxc;
                                        }
                                        catch (Exception ex) { iaux = 0; }

                                        //Validar Bodega de Consignaciones
                                        if (drv2["bodega"].ToString().ToLower().IndexOf("cons") >= 0)
                                        {
                                            drv["consignaciones"] = double.Parse(drv["consignaciones"].ToString()) + iaux;
                                        }
                                        drv["bodegas"] = double.Parse(drv["bodegas"].ToString()) + iaux;
                                        drv2["cajas"] = double.Parse(drv2["cajas"].ToString()) + iaux;
                                    }
                                }
                            }
                        }
                    }

                    //(c) 31072014 Solicitado MMEZA
                    //Cuando se este verificando diuva y este indicado la opcion de obtener inventario de VINOTECA
                    //if (dr_aux["empresa"].ToString().ToLower() == "diuva" && pbincluirBodegasExtras && !lbgeneradoVinoteca)
                    //(c) 20161016 Solicitado SARANA, en cualquier empresa que solicite Dataserver
                    if (pbincluirBodegasExtras && !lbgeneradoVinoteca)
                    {

                        lbgeneradoVinoteca = true;
                        DataTable dt2;

                        lsSQL = "pa_var_um_existencias_producto 'VINOTECA',NULL,NULL,NULL";


                        //(c) 31082014 Modificacion por falta de utilizacion de filtro
                        //if (pbempresa)
                        //    lsSQL = lsSQL + "NULL,NULL,NULL";
                        //else
                        //    lsSQL = lsSQL + "'" + dr_aux["proveedor"].ToString() + "',NULL,NULL";

                        dt2 = Otrans.Obtiene(lsSQL);
                        dt2.Columns.Add(new DataColumn("cajas", System.Type.GetType("System.Decimal")));

                        foreach (DataRowView drvProductosVinoteca in dt2.DefaultView)
                        {
                            ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                               = "producto = '" + drvProductosVinoteca["producto"].ToString() + "'";
                            // and empresa = '" + drv2["empresa"].ToString() + "'";


                            if (drvProductosVinoteca["producto"].ToString() == "0300020205")
                            {
                                drvProductosVinoteca["cajas"] = 0;
                            }

                            drvProductosVinoteca["cajas"] = 0;
                            foreach (DataRowView drvProductosDetalle in ds_preparacion.Tables["detalle_productos"].DefaultView)
                            {
                                try
                                {
                                    uxc = 1;
                                    if (double.Parse(drvProductosDetalle["uxc"].ToString()) > 0)
                                        uxc = double.Parse(drvProductosDetalle["uxc"].ToString());
                                    iaux = double.Parse(drvProductosVinoteca["Existencia"].ToString()) / uxc;
                                }
                                catch (Exception ex) { iaux = 0; }


                                //8c) 20181217 Si esta generando solo vinoteca no se debe tomar en cuenta da y cd
                                //

                                if ((drvProductosVinoteca["bodega"].ToString().ToLower().IndexOf("cd_central") >= 0) || (drvProductosVinoteca["bodega"].ToString().ToLower().IndexOf("da_central") >= 0))
                                {
                                    if (scm_empresa.ToLower() == "vinoteca")
                                        break;
                                }
                                //Validar Bodega de Consignaciones
                                if (drvProductosVinoteca["bodega"].ToString().ToLower().IndexOf("cons") >= 0)
                                {
                                    drvProductosDetalle["consignaciones"] = double.Parse(drvProductosDetalle["consignaciones"].ToString()) + iaux;
                                }
                                drvProductosDetalle["bodegas"] = double.Parse(drvProductosDetalle["bodegas"].ToString()) + iaux;
                                drvProductosDetalle["existencia"] = double.Parse(drvProductosDetalle["existencia"].ToString()) + iaux;
                                drvProductosVinoteca["cajas"] = double.Parse(drvProductosVinoteca["cajas"].ToString()) + iaux;

                                try
                                {
                                    DataRow dr3;
                                    //dr3 = drv2.DataView.t;



                                    dr3 = dt.NewRow();
                                    foreach (DataColumn dc2 in dt.Columns)
                                    {
                                        dr3[dc2.ColumnName] = drvProductosVinoteca[dc2.ColumnName];

                                    }
                                    dt.Rows.Add(dr3);
                                }
                                catch (Exception ex)
                                {
                                    clsGen.Escribir_Log(ex.Message);
                                }
                            }


                        }

                    } // Empresa == diuva

                    dt.TableName = "existencias";
                    try
                    {
                        dt.DefaultView.ToTable().Copy();
                        ds_preparacion.Tables.Add(dt.Copy());
                    }
                    catch { }

                } // empresa


                dtunicos = clsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], "empresa".Split(delimiters));

                foreach (DataRow dr_aux in dtunicos.Rows)
                {
                    lsSQL = "pa_var_um_producto_transito_internacion '" + dr_aux["empresa"].ToString() + "'";
                    dtInternacion = Otrans.Obtiene(lsSQL);

                    foreach (DataRow dr in dtInternacion.Rows)
                    {

                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                      = "producto = '" + dr["producto"].ToString() + "' and empresa = '" + dr["empresa"].ToString() + "'";
                        foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                        {

                            try
                            {
                                uxc = 1;
                                if (double.Parse(drv["uxc"].ToString()) > 0)
                                    uxc = double.Parse(drv["uxc"].ToString());
                                iaux = double.Parse(dr["cantidad"].ToString()) / uxc;

                            }
                            catch (Exception ex) { iaux = 0; }

                            drv["internacion"] = double.Parse(drv["internacion"].ToString()) + iaux;
                            drv["existencia"] = double.Parse(drv["existencia"].ToString()) + iaux;

                        }
                    }


                }

                ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter = "";


                foreach (DataRow dr_aux in ds_preparacion.Tables["detalle_productos"].Rows)
                {
                    dr_aux["bodegas"] = double.Parse(dr_aux["bodegas"].ToString()) - double.Parse(dr_aux["consignaciones"].ToString());
                }


            }
            catch (Exception ex)
            { }
            finally
            {
                Otrans.cerrar();
                Otrans = null;
                clsGen = null;
            }



        }

        public void generarExistenciaLote(Boolean pbempresa, Boolean pbincluirBodegasExtras)
        {

            double iaux;
            double uxc;
            DataTable dtunicos, dt, dtInternacion;
            ClasesGenerales.General clsGen = new ClasesGenerales.General();
            Transaccional.Conexion Otrans = new Transaccional.Conexion("flexline");
            bool lbgeneradoVinoteca = false;
            DataRow dr3;

            try
            {

                Otrans.abrir();

                char[] delimiters = new char[] { ',' };
                string lsSQL = "";

                //if (pbempresa)
                    dtunicos = clsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], "empresa".Split(delimiters));
                //else
                    //dtunicos = clsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], "empresa,proveedor".Split(delimiters));



                foreach (DataRow dr_aux in dtunicos.Rows)
                {
                    lsSQL = "pa_var_um_existencias_producto_lote '" + dr_aux["empresa"].ToString() + "',";

                   lsSQL = lsSQL + "NULL,NULL";


                    dt = Otrans.Obtiene(lsSQL);
                    dt.Columns.Add(new DataColumn("cajas", System.Type.GetType("System.Decimal")));

                   

                    dt.TableName = "existenciasLote";
                    try
                    {
                        if (!ds_preparacion.Tables.Contains(dt.TableName))
                        
                        {
                            ds_preparacion.Tables.Add(dt.Copy());
                            ds_preparacion.Tables["existenciasLote"].Rows.Clear();

                        }
                        
                    }
                    catch { }
                    dt.TableName = "existenciasLoteOld";



                    try
                    {
                    foreach (DataRow drv2 in dt.Rows)
                    {
                            //if (!(drv2["bodega"].ToString() == "CD_MAL_ESTADO" || drv2["bodega"].ToString() == "CD_LIQUIDACION"
                            //    || drv2["bodega"].ToString() == "CD_LIQUIDAR_FACTURAS" || drv2["bodega"].ToString() == "CD_MAL_ESTADO_ORIGEN"
                            //    || drv2["bodega"].ToString() == "CD_TRANSITO" || drv2["bodega"].ToString() == "FIN_TRANSITO"))
                                if (!(drv2["bodega"].ToString() == "CD_MAL_ESTADO" || drv2["bodega"].ToString() == "CD_LIQUIDACION"
                                    || drv2["bodega"].ToString() == "CD_LIQUIDAR_FACTURAS" || drv2["bodega"].ToString() == "CD_MAL_ESTADO_ORIGEN"
                                    || drv2["bodega"].ToString() == "FIN_TRANSITO"))

                                { 
                            drv2["cajas"] = 0;

                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                           = "producto = '" + drv2["producto"].ToString() + "' and empresa = '" + drv2["empresa"].ToString() + "'";

                        foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                        {
                            try
                            {
                                uxc = 1;
                                if (double.Parse(drv["uxc"].ToString()) > 0)
                                    uxc = double.Parse(drv["uxc"].ToString());
                                iaux = double.Parse(drv2["Existencia"].ToString()) / uxc;

                                        drv2["cajas"] = iaux;
                                }
                            catch (Exception ex) { iaux = 0; }

                        }

                            }
                        }

                        dt.DefaultView.RowFilter = "cajas <> 0";
                        foreach (DataRowView drv2 in dt.DefaultView)
                        {
                            dr3 = ds_preparacion.Tables["existenciasLote"].NewRow();
                            foreach (DataColumn dc2 in dt.Columns)
                            {
                                dr3[dc2.ColumnName] = drv2[dc2.ColumnName];

                            }
                            ds_preparacion.Tables["existenciasLote"].Rows.Add(dr3);
                        }

                    }
                    catch (Exception ex)
                    {
                        clsGen.Escribir_Log(ex.Message);
                    }
   


              


                    dt.TableName = "existenciasLote";
                    try
                    {
                        dt.DefaultView.ToTable().Copy();
                        ds_preparacion.Tables.Add(dt.Copy());
                    }
                    catch { }

                } // empresa


               


            }
            catch (Exception ex)
            { }
            finally
            {
                Otrans.cerrar();
                Otrans = null;
                clsGen = null;
            }



        }

        public void generarExistenciaSerie(Boolean pbempresa, Boolean pbincluirBodegasExtras)
        {

            double iaux;
            double uxc;
            DataTable dtunicos, dt;
            ClasesGenerales.General clsGen = new ClasesGenerales.General();
            Transaccional.Conexion Otrans = new Transaccional.Conexion("flexline");
            
            DataRow dr3;

            try
            {

                Otrans.abrir();

                char[] delimiters = new char[] { ',' };
                string lsSQL = "";

                //if (pbempresa)
                dtunicos = clsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], "empresa".Split(delimiters));
                //else
                //dtunicos = clsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], "empresa,proveedor".Split(delimiters));



                foreach (DataRow dr_aux in dtunicos.Rows)
                {
                    lsSQL = "pa_var_um_existencias_producto_serie '" + dr_aux["empresa"].ToString() + "',";

                    lsSQL = lsSQL + "NULL,NULL";


                    dt = Otrans.Obtiene(lsSQL);
                    dt.Columns.Add(new DataColumn("cajas", System.Type.GetType("System.Decimal")));



                    dt.TableName = "existenciasSerie";
                    try
                    {
                        if (!ds_preparacion.Tables.Contains(dt.TableName))

                        {
                            ds_preparacion.Tables.Add(dt.Copy());
                            ds_preparacion.Tables["existenciasSerie"].Rows.Clear();

                        }

                    }
                    catch { }
                    dt.TableName = "existenciasSerieOld";



                    try
                    {

                        foreach (DataRow drvSerie in dt.Rows)
                        {
                            if (!(drvSerie["bodega"].ToString() == "CD_MAL_ESTADO" || drvSerie["bodega"].ToString() == "CD_LIQUIDACION"
                                || drvSerie["bodega"].ToString() == "CD_LIQUIDAR_FACTURAS" || drvSerie["bodega"].ToString() == "CD_MAL_ESTADO_ORIGEN"
                                || drvSerie["bodega"].ToString() == "CD_TRANSITO" || drvSerie["bodega"].ToString() == "FIN_TRANSITO"))
                            {
                                drvSerie["cajas"] = 0;

                                ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                                   = "producto = '" + drvSerie["producto"].ToString() + "' and empresa = '" + drvSerie["empresa"].ToString() + "'";

                                foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                                {
                                    try
                                    {
                                        uxc = 1;
                                        if (double.Parse(drv["uxc"].ToString()) > 0)
                                            uxc = double.Parse(drv["uxc"].ToString());
                                        iaux = double.Parse(drvSerie["Existencia"].ToString()) / uxc;

                                        drvSerie["cajas"] = iaux;
                                    }
                                    catch (Exception ex) { iaux = 0; }

                                }

                            }
                        }

                        dt.DefaultView.RowFilter = "cajas <> 0";
                        foreach (DataRowView drv2 in dt.DefaultView)
                        {
                            dr3 = ds_preparacion.Tables["existenciasSerie"].NewRow();
                            foreach (DataColumn dc2 in dt.Columns)
                            {
                                dr3[dc2.ColumnName] = drv2[dc2.ColumnName];

                            }
                            ds_preparacion.Tables["existenciasSerie"].Rows.Add(dr3);
                        }






                    }
                    catch (Exception ex)
                    {
                        clsGen.Escribir_Log(ex.Message);
                    }






                    dt.TableName = "existenciasSerie";
                    try
                    {
                        dt.DefaultView.ToTable().Copy();
                        ds_preparacion.Tables.Add(dt.Copy());
                    }
                    catch { }

                } // empresa





            }
            catch (Exception ex)
            { }
            finally
            {
                Otrans.cerrar();
                Otrans = null;
                clsGen = null;
            }



        }


        public void generarTransitos(int psemanaActual, string sOrigen, Boolean bprecios)
        {
            DataTable dt, dtunicos, dtransitos;

            DataRowView drv;
            Transaccional.Conexion otrans = new Transaccional.Conexion("scm");
            ClasesGenerales.General ClsGen = new ClasesGenerales.General();


            string lsSQL, ls_mes, lsSemanaValorTransito;
            int nsemana, ntotalSemanas, iCount;
            Double ntransito, ldValorTransito;


            try
            {
                iCount = 0;
                otrans.open();
                char[] delimiters = new char[] { ',' };
                dtunicos = ClsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], "empresa,proveedor".Split(delimiters));

                foreach (DataRow dr_aux in dtunicos.Rows)
                {
                    iCount++;
                    lsSQL = "pa_var_um_transito_productos '" + dr_aux["empresa"].ToString() + "','" +
                             dr_aux["proveedor"].ToString() + "',";
                    lsSQL += "NULL";

                    dt = otrans.Obtiene(lsSQL);
                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            // busco el producto
                          ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                        = "producto = '" + dr["producto"].ToString() + "' and empresa = '" + dr["empresa"].ToString() + "'";

                            //si lo encuentro
                          if (ds_preparacion.Tables["detalle_productos"].DefaultView.Count > 0)
                          {
                              drv = ds_preparacion.Tables["detalle_productos"].DefaultView[0];

                              if (double.Parse(dr["semana"].ToString()) < psemanaActual && DateTime.Parse(dr["fecha_vencimiento"].ToString()).Year == DateTime.Today.Year)
                                  nsemana = 0;
                              else
                                  nsemana = int.Parse(dr["semana"].ToString()) - psemanaActual;

                              if (DateTime.Parse(dr["fecha_vencimiento"].ToString()).Year == DateTime.Today.Year)
                                  ntotalSemanas = CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(DateTime.Parse("01/01/" + DateTime.Today.Year).AddYears(1).AddDays(-1), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                              else
                                  ntotalSemanas = 52; //sigue siendo semanas del año no semanas de calculo

                              if (nsemana < 0)
                                  nsemana += ntotalSemanas;
                              ls_mes = "transito";
                              lsSemanaValorTransito = "valor_transito";

                              if (nsemana > 0)
                              {
                                  ls_mes = ls_mes + "+" + nsemana.ToString("00");
                                  lsSemanaValorTransito += "+" + nsemana.ToString("00");
                              }

                              if (dr["CantidadArriboPuerto"].ToString().Length == 0)
                                  ntransito = double.Parse(dr["cajas_pedidas"].ToString());
                              else
                              {
                                  ntransito = double.Parse(dr["CantidadArriboPuerto"].ToString());
                                  if (!dr["unidadingreso"].ToString().ToLower().StartsWith("caj"))
                                  {
                                      double uxc = 1;
                                      if (double.Parse(dr["factoralt"].ToString()) > 0)
                                          uxc = double.Parse(dr["factoralt"].ToString());

                                      ntransito = ntransito / uxc; // double.Parse(dr["factoralt"].ToString());
                                  }
                              }

                              try
                              {
                                  if (bprecios)
                                      ntransito = ntransito * Double.Parse(dr["costo_caja"].ToString());

                                  if (scm_proyeccion)
                                  {
                                      ldValorTransito = ntransito * Double.Parse(dr["costo_caja"].ToString());
                                      drv[lsSemanaValorTransito] = Double.Parse(drv[lsSemanaValorTransito].ToString()) + ldValorTransito;
                                  }
                              }
                              catch (Exception ex)
                              {
                              }
                              //ntransito = IIf(dr.Item("CantidadArriboPuerto") Is System.DBNull.Value, dr.Item("cajas_pedidas"), dr.Item("cantidadArriboPuerto"))\
                              try
                              {
                                  drv[ls_mes] = int.Parse(drv[ls_mes].ToString()) + ntransito;
                              }
                              catch (Exception ex) { }

                          }
                          //si no lo encuentro lo puedo ir a buscar a los derivados
                          else
                          {
                              if (dr["producto"].ToString() == "0100011085")
                              {
                                  nsemana = 0;
                              }
                              ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "producto = '" + dr["producto"].ToString() + "'";
                                  if (ds_preparacion.Tables["derivados"].DefaultView.Count > 0)
                                  {

                                      ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                      = "producto = '" + ds_preparacion.Tables["derivados"].DefaultView[0]["producto_padre"].ToString()  +
                                      "' and empresa = '" + ds_preparacion.Tables["derivados"].DefaultView[0]["empresa"].ToString() + "'";


                                      //si lo encuentro
                                      if (ds_preparacion.Tables["detalle_productos"].DefaultView.Count > 0)
                                      {
                                          //Factor del derivado
                                          double dDerivadoUnidades = 0;
                                          dDerivadoUnidades = Double.Parse(ds_preparacion.Tables["derivados"].DefaultView[0]["unidades"].ToString());

                                          //iaux = (double.Parse(drv2["Existencia"].ToString()) * double.Parse(drvaux["unidades"].ToString())) / uxc;

                                          drv = ds_preparacion.Tables["detalle_productos"].DefaultView[0];

                                          //20170927 (c)
                                          // en transitos siempre debo llevar la uxc del producto padre 
                                          
                                          
                                              double uxcPadre = 1;
                                              if (double.Parse(drv["uxc"].ToString()) > 0)
                                                  uxcPadre = double.Parse(drv["uxc"].ToString());

                                              //dDerivadoUnidades = Double.Parse(ds_preparacion.Tables["derivados"].DefaultView[0]["unidades"].ToString()) / uxcPadre;
                                              dDerivadoUnidades = Double.Parse(dr["factoralt"].ToString()) / uxcPadre;


                                          if (double.Parse(dr["semana"].ToString()) < psemanaActual && DateTime.Parse(dr["fecha_vencimiento"].ToString()).Year == DateTime.Today.Year)
                                              nsemana = 0;
                                          else
                                              nsemana = int.Parse(dr["semana"].ToString()) - psemanaActual;

                                          if (DateTime.Parse(dr["fecha_vencimiento"].ToString()).Year == DateTime.Today.Year)
                                              ntotalSemanas = CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(DateTime.Parse("01/01/" + DateTime.Today.Year).AddYears(1).AddDays(-1), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                                          else
                                              ntotalSemanas = 52; //sigue siendo semanas del año no semanas de calculo

                                          if (nsemana < 0)
                                              nsemana += ntotalSemanas;
                                          ls_mes = "transito";
                                          lsSemanaValorTransito = "valor_transito";

                                          if (nsemana > 0)
                                          {
                                              ls_mes = ls_mes + "+" + nsemana.ToString("00");
                                              lsSemanaValorTransito += "+" + nsemana.ToString("00");
                                          }

                                          if (dr["CantidadArriboPuerto"].ToString().Length == 0)
                                              ntransito = double.Parse(dr["cajas_pedidas"].ToString()) * dDerivadoUnidades;
                                          else
                                          {
                                              ntransito = double.Parse(dr["CantidadArriboPuerto"].ToString()) * dDerivadoUnidades;
                                              if (!dr["unidadingreso"].ToString().ToLower().StartsWith("caj"))
                                              {
                                                  double uxc = 1;
                                                  if (double.Parse(dr["factoralt"].ToString()) > 0)
                                                      uxc = double.Parse(dr["factoralt"].ToString());

                                                  ntransito = ntransito / uxc; // double.Parse(dr["factoralt"].ToString());
                                              }
                                          }

                                          try
                                          {
                                              if (bprecios)
                                                  ntransito = ntransito * Double.Parse(dr["costo_caja"].ToString());

                                              if (scm_proyeccion)
                                              {
                                                  ldValorTransito = ntransito * Double.Parse(dr["costo_caja"].ToString());
                                                  drv[lsSemanaValorTransito] = Double.Parse(drv[lsSemanaValorTransito].ToString()) + ldValorTransito;
                                              }
                                          }
                                          catch (Exception ex)
                                          {
                                          }
                                          //ntransito = IIf(dr.Item("CantidadArriboPuerto") Is System.DBNull.Value, dr.Item("cajas_pedidas"), dr.Item("cantidadArriboPuerto"))\
                                          try
                                          {
                                              drv[ls_mes] = int.Parse(drv[ls_mes].ToString()) + ntransito;
                                          }
                                          catch (Exception ex) { }

                                      }





                                  }

                          }


                        }

                        catch (Exception ex)
                        {
                        }
                        //Buscar el producto derivado

                    }

                    try
                    {

                            //20210518 "Validar
                            if (iCount > 1)
                            {

                            
                                DataRow dr3;
                            //dr3 = drv2.DataView.t;

                            foreach (DataRow dr2 in dt.Rows)

                            {
                                dr3 = ds_preparacion.Tables["transitos"].NewRow();
                                foreach (DataColumn dc2 in dt.Columns)
                                {
                                    dr3[dc2.ColumnName] = dr2[dc2.ColumnName];

                                }
                                ds_preparacion.Tables["transitos"].Rows.Add(dr3);
                            }

                                

                            }
                            else
                            {
                                dt.TableName = "transitos";
                                ds_preparacion.Tables.Add(dt.Copy());
                            }



                    }
                    catch (Exception ex)
                    {
                    }

                    // Agregar Transitos de Derivados


                }
            }


            catch (Exception ex)
            {
                otrans.Escribir_Log("genera transitos " + ex.ToString());
            }
            finally
            {
                otrans.close();
                otrans = null;
            }

        }

        public void generarPresupuestos(int psemanaActual, string sOrigen, Boolean bPrecios)
        {
            String lsSQL, ls_mes;
            DataRowView drv;
            DataTable dt, dtunicos;
            double npresupuesto = 0;
            Transaccional.Conexion otrans = new Transaccional.Conexion("umbral");
            ClasesGenerales.General clsGen = new ClasesGenerales.General();
            int nsemana;

            try
            {
                otrans.open();
                char[] delimiters = new char[] { ',' };
                string scampos = "empresa,proveedor";
                if (bPrecios)
                    scampos = "empresa";

                dtunicos = clsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], scampos.Split(delimiters));

                foreach (DataRow dr_aux in dtunicos.Rows)
                {


                    try
                    {
                        lsSQL = "pa_sel_um_producto_presupuesto_mensual 0,'" + dr_aux["empresa"] + "',";
                        if ((bPrecios) || (sOrigen == ""))
                            lsSQL += "NULL";
                        else
                            lsSQL += "'" + dr_aux["proveedor"].ToString() + "'";
                        dt = otrans.Obtiene(lsSQL);
                        dt.TableName = "presupuesto_mensual";
                        ds_preparacion.Tables.Add(dt.Copy());
                    }
                    catch (Exception ex)
                    { }
                    finally
                    {
                    }

                    lsSQL = "pa_sel_um_producto_presupuesto 0,'" + dr_aux["empresa"] + "',";
                    if (bPrecios)
                        lsSQL += "NULL";
                    else
                        lsSQL += "'" + dr_aux["proveedor"].ToString() + "'";

                    lsSQL += ",NULL";

                    dt = otrans.Obtiene(lsSQL);

                    //Debo Almacenar una copia del Presupuesto Actual
                    try
                    {
                        dt.TableName = "presupuesto";
                        ds_preparacion.Tables.Add(dt.Copy());

                    }
                    catch (Exception ex)
                    {
                        clsGen.Escribir_Log(ex.Message);
                    }


                    finally
                    {
                    }

                    foreach (DataRow dr in dt.Rows)
                    {

                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                                             = "producto = '" + dr["producto"].ToString() + "' and empresa = '" + dr["empresa"].ToString() + "'";


                        if (ds_preparacion.Tables["detalle_productos"].DefaultView.Count > 0)
                        {
                            drv = ds_preparacion.Tables["detalle_productos"].DefaultView[0];

                            nsemana = int.Parse(dr["semana"].ToString()) - psemanaActual;

                            if (nsemana < 0)
                                nsemana += 52; //52 semanas del año, no del calculo

                            ls_mes = "ppto";
                            if (nsemana > 0)
                                ls_mes = ls_mes + "+" + nsemana.ToString("00");

                            npresupuesto = double.Parse(dr["ppto_semanal"].ToString());



                            if (bPrecios)
                                try
                                {
                                    npresupuesto = npresupuesto * double.Parse(drv["costo_unitario"].ToString());
                                }
                                catch (Exception ex)
                                { }
                            drv[ls_mes] = double.Parse(drv[ls_mes].ToString()) + npresupuesto;

                        }
                    }




                    lsSQL = "pa_sel_um_producto_presupuestoDerivados 0,'" + dr_aux["empresa"] + "',";
                    if (bPrecios)
                        lsSQL += "NULL";
                    else
                        lsSQL += "'" + dr_aux["proveedor"].ToString() + "'";
                    lsSQL += ",NULL";
                    dt = otrans.Obtiene(lsSQL);

                    //Debo Almacenar una copia del Presupuesto Actual
                    try
                    {
                        dt.TableName = "presupuesto_derivado";
                        ds_preparacion.Tables.Add(dt.Copy());

                    }
                    catch (Exception ex)
                    { }


                    finally
                    {
                    }


                    foreach (DataRow dr in dt.Rows)
                    {

                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                                             = "producto = '" + dr["producto"].ToString() + "' and empresa = '" + dr["empresa"].ToString() + "'";
                        if (ds_preparacion.Tables["detalle_productos"].DefaultView.Count > 0)
                        {
                            drv = ds_preparacion.Tables["detalle_productos"].DefaultView[0];
                            nsemana = int.Parse(dr["semana"].ToString()) - psemanaActual;

                            if (nsemana < 0) nsemana += 52; //Semanas del Año no del Calculo

                            ls_mes = "ppto";
                            if (nsemana > 0) ls_mes = ls_mes + "+" + nsemana.ToString("00");

                            npresupuesto = double.Parse(dr["ppto_semanal"].ToString());

                            if (bPrecios)
                                try
                                {
                                    npresupuesto = npresupuesto * double.Parse(drv["costo_unitario"].ToString());
                                }
                                catch (Exception ex)
                                { }
                            drv[ls_mes] = double.Parse(drv[ls_mes].ToString()) + npresupuesto;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                clsGen.Escribir_Log(ex.Message);
            }


            finally
            {
                otrans.close();
                otrans = null;
            }
        }

        public void generarPresupuestosAlterno(int psemanaActual, string sOrigen, Boolean bPrecios)
        {
            String lsSQL, ls_mes;
            DataRowView drv;
            DataTable dt, dtunicos;
            double npresupuesto = 0;
            Transaccional.Conexion otrans = new Transaccional.Conexion("umbral");
            ClasesGenerales.General clsGen = new ClasesGenerales.General();
            int nsemana;

            try
            {
                otrans.open();
                char[] delimiters = new char[] { ',' };
                string scampos = "empresa,proveedor";
                if (bPrecios)
                    scampos = "empresa";

                dtunicos = clsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], scampos.Split(delimiters));

                foreach (DataRow dr_aux in dtunicos.Rows)
                {

                    
                    try
                    {
                        lsSQL = "pa_sel_um_producto_presupuesto_mensual_alterno 0,'" + dr_aux["empresa"] + "',";
                        if ((bPrecios) || (sOrigen==""))
                            lsSQL += "NULL";
                        else
                            lsSQL += "'" + dr_aux["proveedor"].ToString() + "'";
                        dt = otrans.Obtiene(lsSQL);
                        dt.TableName = "presupuesto_mensual";
                        ds_preparacion.Tables.Add(dt.Copy());
                    }
                    catch (Exception ex)
                    { }
                    finally
                    {
                    }

                    lsSQL = "pa_sel_um_producto_presupuesto_alterno 0,'" + dr_aux["empresa"] + "',";
                    if (bPrecios)
                        lsSQL += "NULL";
                    else
                        lsSQL += "'" + dr_aux["proveedor"].ToString() + "'";

                    lsSQL += ",NULL";

                    dt = otrans.Obtiene(lsSQL);

             //Debo Almacenar una copia del Presupuesto Actual
                    try
            {
                dt.TableName = "presupuesto";
                ds_preparacion.Tables.Add(dt.Copy());

                    }
            catch (Exception ex)
            {
                clsGen.Escribir_Log(ex.Message);
            }


            finally
            {
            }

                    foreach (DataRow dr in dt.Rows)
                    {

                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                                             = "producto = '" + dr["producto"].ToString() + "' and empresa = '" + dr["empresa"].ToString() + "'";


                        if (ds_preparacion.Tables["detalle_productos"].DefaultView.Count > 0)
                        {
                            drv = ds_preparacion.Tables["detalle_productos"].DefaultView[0];

                            nsemana = int.Parse(dr["semana"].ToString()) - psemanaActual;

                            if (nsemana < 0)
                                nsemana += 52; //52 semanas del año, no del calculo

                            ls_mes = "ppto";
                            if (nsemana > 0)
                                ls_mes = ls_mes + "+" + nsemana.ToString("00");

                            npresupuesto = double.Parse(dr["ppto_semanal"].ToString());



                            if (bPrecios)
                                try
                                {
                                    npresupuesto = npresupuesto * double.Parse(drv["costo_unitario"].ToString());
                                }
                                catch (Exception ex)
                                { }
                            drv[ls_mes] = double.Parse(drv[ls_mes].ToString()) + npresupuesto;

                        }
                    }




                    lsSQL = "pa_sel_um_producto_presupuestoDerivados_alterno 0,'" + dr_aux["empresa"] + "',";
                    if (bPrecios)
                        lsSQL += "NULL";
                    else
                        lsSQL += "'" + dr_aux["proveedor"].ToString() + "'";
                    lsSQL += ",NULL";
                    dt = otrans.Obtiene(lsSQL);

                    //Debo Almacenar una copia del Presupuesto Actual
                    try
                    {
                        dt.TableName = "presupuesto_derivado";
                        ds_preparacion.Tables.Add(dt.Copy());

                    }
                    catch (Exception ex)
                    { }


                    finally
                    {
                    }


                    foreach (DataRow dr in dt.Rows)
                    {

                        ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                                             = "producto = '" + dr["producto"].ToString() + "' and empresa = '" + dr["empresa"].ToString() + "'";
                        if (ds_preparacion.Tables["detalle_productos"].DefaultView.Count > 0)
                        {
                            drv = ds_preparacion.Tables["detalle_productos"].DefaultView[0];
                            nsemana = int.Parse(dr["semana"].ToString()) - psemanaActual;

                            if (nsemana < 0) nsemana += 52; //Semanas del Año no del Calculo

                            ls_mes = "ppto";
                            if (nsemana > 0) ls_mes = ls_mes + "+" + nsemana.ToString("00");

                            npresupuesto = double.Parse(dr["ppto_semanal"].ToString());

                            if (bPrecios)
                                try
                                {
                                    npresupuesto = npresupuesto * double.Parse(drv["costo_unitario"].ToString());
                                }
                                catch (Exception ex)
                                { }
                            drv[ls_mes] = double.Parse(drv[ls_mes].ToString()) + npresupuesto;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                clsGen.Escribir_Log(ex.Message);
            }


            finally
            {
                otrans.close();
                otrans = null;
            }
        }


        public void mostrarDerivados(string psproducto, string psglosa)
        {

            ClasesGenerales.frm_resultado oform = new ClasesGenerales.frm_resultado();
            ClasesGenerales.General clsGen = new ClasesGenerales.General();
            string lcolumnasmostrar = ",empresa,producto,glosa,unidades,existencia,";

            try
            {
                ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + scm_empresa + "' and producto_padre = '" + psproducto + "'";


                oform.Text = "Productos Derivados de " + psproducto + " " + psglosa;
                oform.dgv_resultado.DataSource = ds_preparacion.Tables["derivados"];

                clsGen.Alinear_GridViewEnteros = "unidades";
                clsGen.Alinear_GridView(ds_preparacion.Tables["derivados"], oform.dgv_resultado, lcolumnasmostrar, "", "", "", ",existencia=existencia_unidades,", "", ",empresa,producto,glosa,unidades,", true, true, 250, 0);



                oform.ShowDialog();
                oform.Dispose();
                oform = null;

            }
            catch (Exception ex)
            {
                lcolumnasmostrar = ex.ToString();
            }
            finally
            {
                clsGen = null;
            }




            //Try
            //    oform.Text = "Productos Derivados de " + dgv_detalle.Item("producto", Me.dgv_detalle.CurrentRow.Index).Value + "--" + dgv_detalle.Item("glosa", dgv_detalle.CurrentRow.Index).Value


            //    ds_informacion_productos.Tables("derivados").DefaultView.RowFilter = "producto_padre = '" & dgv_detalle.Item("producto", dgv_detalle.CurrentRow.Index).Value & "'"
            //    oform.dgv_resultado.DataSource = ds_informacion_productos.Tables("derivados")


            //    clsGen.Alinear_GridView(ds_informacion_productos.Tables("derivados"), oform.dgv_resultado, lcolumnasmostrar, "", "", "", ",existencia=existencia_unidades,", "", ",empresa,producto,glosa,unidades,", True, True, 250, 0)

            //    For Each dc As DataGridViewColumn In oform.dgv_resultado.Columns
            //        If dc.Name.ToLower = "unidades" Then
            //            dc.DefaultCellStyle.Format = "n4"
            //        End If
            //    Next
            //    With oform.dgv_resultado
            //        .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            //    End With
            //    oform.ShowDialog()
            //    oform.Dispose()
            //    oform = Nothing


        }

        public void mostrarPresupuesto(string psproducto, Boolean pbderivados)
        {

            Transaccional.Conexion Otrans = new Transaccional.Conexion("Umbralsa");
            DataTable dt, dt3;
            dt3 = null;
            string lsSQL;

            try
            {
                Otrans.open();
                lsSQL = "pa_sel_um_ppt_presupuesto_general '" + scm_empresa + "',null,'" + psproducto + "'";
                dt = Otrans.Obtiene(lsSQL);




                if (dt.DefaultView.Count > 0)
                {
                    if (pbderivados)
                    {
                        ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + scm_empresa + "' and producto_padre = '" + psproducto + "'";
                        foreach (DataRowView drv in ds_preparacion.Tables["derivados"].DefaultView)
                        {
                            lsSQL = "pa_sel_um_ppt_presupuesto_general '" + scm_empresa + "',null,'" +
                                 drv["producto"].ToString() + "'";


                            dt3 = Otrans.Obtiene(lsSQL);

                            foreach (DataRow dr3 in dt3.Rows)
                            {
                                DataRow dr = dt.NewRow();
                                foreach (DataColumn dc in dt.Columns)
                                    dr[dc.ColumnName] = dr3[dc.ColumnName];
                                dt.Rows.Add(dr);
                            }

                        }

                    } //pbderivados


                    dt.DefaultView.RowFilter = "periodo >= '" + DateTime.Today.ToString("yyyyMM") + "'";
                    dt.DefaultView.Sort = "periodo";
                    dt.Columns.Add(new DataColumn("cajas", System.Type.GetType("System.Decimal")));
                    foreach (DataRowView drv in dt.DefaultView)
                        drv["cajas"] = double.Parse(drv["cantidad"].ToString()) / double.Parse(drv["factoralt"].ToString());

                    ClasesGenerales.frm_resultado oform = new ClasesGenerales.frm_resultado();
                    ClasesGenerales.General clsGen = new ClasesGenerales.General();

                    oform.Text = ":: Presupuesto Mensual ::";
                    string lcolumnasmostrar = ",periodo,producto,glosa,cajas,factoralt,";
                    oform.dgv_resultado.DataSource = dt.DefaultView;

                    //clsGen.Alinear_GridViewEnteros = "cajas";
                    clsGen.Alinear_GridView(dt, oform.dgv_resultado, lcolumnasmostrar, "", "", "", "", "", ",empresa,producto,glosa,periodo,cajas,", true, true, 250, 0);
                    oform.ShowDialog();
                    oform.Dispose();
                    oform = null;
                    clsGen = null;

                }


                //foreach (DataColumn dc in ds_preparacion.Tables["Resumen"].Columns)
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Otrans.close();
                Otrans = null;
            }



        }

        public void mostrarVentas(string psproducto, string psglosa, Boolean pbderivados)
        {

            string lsSQL;
            DataTable dt, dt3;
            dt3 = null;
            Transaccional.Conexion Otrans = new Transaccional.Conexion("Umbralsa");
            try
            {
                Otrans.open();
                lsSQL = "pa_var_um_ventas_presupuesto_producto_periodo '" + scm_empresa + "','" +
                    psproducto + "','" + DateTime.Today.AddYears(-1).ToString("yyyyMM") + "'";
                dt = Otrans.Obtiene(lsSQL);

                if (pbderivados)
                {
                    ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + scm_empresa + "' and producto_padre = '" + psproducto + "'";
                    foreach (DataRowView drv in ds_preparacion.Tables["derivados"].DefaultView)
                    {
                        lsSQL = "pa_var_um_ventas_presupuesto_producto_periodo '" + scm_empresa + "','" +
                             drv["producto"].ToString() + "','" + DateTime.Today.AddYears(-1).ToString("yyyyMM") + "'";


                        dt3 = Otrans.Obtiene(lsSQL);

                        foreach (DataRow dr3 in dt3.Rows)
                        {
                            DataRow dr = dt.NewRow();
                            foreach (DataColumn dc in dt.Columns)
                                dr[dc.ColumnName] = dr3[dc.ColumnName];
                            dt.Rows.Add(dr);
                        }

                    }

                } //pbderivados

                if (dt.Rows.Count > 0)
                {
                    ClasesGenerales.frm_resultado oform = new ClasesGenerales.frm_resultado();
                    ClasesGenerales.General ClsGen = new ClasesGenerales.General();

                    oform.Text = "Ventas " + psproducto + " - " + psglosa;

                    dt.DefaultView.Sort = "periodo DESC";
                    oform.dgv_resultado.DataSource = dt;
                    string lcolumnasmostrar = ",periodo,ventas_cajas,pptocom,pptomer,";
                    if (dt3 != null)
                        lcolumnasmostrar += "producto,glosa,";


                    ClsGen.Alinear_GridView(dt, oform.dgv_resultado, lcolumnasmostrar, "", "", "", "", "", "", true, true, 190, 0);

                    //With oform.dgv_resultado
                    //    .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
                    //End With
                    oform.ShowDialog();
                    oform.Dispose();
                    oform = null;
                    ClsGen = null;




                }


            }
            finally
            {
                Otrans.close();
                Otrans = null;
            }
        }

        public void mostrarGrafica(int filasSeleccionadas, double[,] pcobertura, double[,] psaldos,
                    string[] pnombres, string[] periodos, string sTituloY, string sTituloX, int iSemanasGraficar)
        {

            ClasesGenerales.frm_graficar oform = new ClasesGenerales.frm_graficar();

            GraphPane mypane = oform.zgc1.GraphPane;
            mypane.CurveList.Clear();
            mypane.Title.Text = "";
            mypane.YAxis.Title.Text = sTituloY; // "Cobertura Semanas";
            mypane.YAxis.MajorGrid.IsVisible = true;
            mypane.YAxis.MinorTic.IsAllTics = false;

            Double[] xx, yy;

            xx = null;

            Color c = default(Color);
            Color c2 = default(Color);

            Double[] coberturaGraficar = new double[iSemanasGraficar+1];
            Double[] saldosGraficar = new double[iSemanasGraficar+1];


            for (int i = 0; i < filasSeleccionadas; i++)
            {
                for (int icount = 0; icount < iSemanasGraficar+1; icount++)
                {
                    coberturaGraficar[icount] = pcobertura[i, icount];
                    saldosGraficar[icount] = psaldos[i, icount];
                }

                c = new Color();
                c2 = new Color();


                switch (i)
                {
                    case 0:

                        c = Color.Blue;
                        c2 = Color.Red;

                        break;
                    case 1:
                        c = Color.Blue;
                        c2 = Color.DarkBlue;
                        break;
                    case 2:
                        c = Color.DarkOrange;
                        c2 = Color.DarkOrange;
                        break;
                    case 3:
                        c = Color.Purple;
                        c2 = Color.Purple;
                        break;
                    case 4:
                        c = Color.DarkGreen;
                        c2 = Color.DarkGreen;
                        break;
                    case 5:
                        c = Color.DarkCyan;
                        c2 = Color.DarkCyan;
                        break;
                }



                //LineItem myCurve = mypane.AddCurve("Cobertura " + pnombres[i], xx, coberturaGraficar, c, SymbolType.Circle);
                LineItem myCurve = mypane.AddCurve("Saldos " + pnombres[i], xx, saldosGraficar, c, SymbolType.Circle);
                myCurve.IsY2Axis = true;
                myCurve.Line.Width = 2;
                myCurve.Symbol.Fill.Color = c;
                myCurve.Symbol.Size = 3;

                //BarItem myBarra = mypane.AddBar("Saldos " + pnombres[i], xx, saldosGraficar, c2);
                BarItem myBarra = mypane.AddBar("Cobertura " + pnombres[i], xx, coberturaGraficar, c2);
                //myBarra.IsY2Axis = true;


            }


            for (int icount = 0; icount < iSemanasGraficar+1; icount++)
                saldosGraficar[icount] = psaldos[7, icount];

            LineItem myCurve3 = mypane.AddCurve("", xx, saldosGraficar, Color.DarkOliveGreen, SymbolType.None);
            myCurve3.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            myCurve3.Line.Width = 2;


            for (int icount = 0; icount < iSemanasGraficar+1; icount++)
                saldosGraficar[icount] = psaldos[6, icount];

            LineItem myCurve4 = mypane.AddCurve("", xx, saldosGraficar, Color.DarkOliveGreen, SymbolType.None);
            myCurve4.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            myCurve4.Line.Width = 2;


            mypane.XAxis.Title.Text = "";
            mypane.XAxis.Type = AxisType.Text;
            mypane.XAxis.Scale.Align = AlignP.Center;
            mypane.XAxis.Scale.FontSpec.Angle = 90;
            mypane.XAxis.Scale.FontSpec.Size = 8;
            mypane.Legend.FontSpec.Size = 8;

            mypane.XAxis.Scale.TextLabels = periodos;




            mypane.Y2Axis.IsVisible = true;
            mypane.Y2Axis.Title.Text = sTituloX; //"Existencias Cajas";
            mypane.Y2Axis.MajorGrid.Color = Color.Silver;
            mypane.Y2Axis.Title.FontSpec.Size = 9;
            mypane.YAxis.Title.FontSpec.Size = 9;
            mypane.Y2Axis.Scale.TextLabels = periodos;

            Color colorUmbral = Color.FromArgb(233, 234, 204);
            mypane.Chart.Fill = new Fill(Color.White, colorUmbral, 45);
            mypane.Fill = new Fill(Color.White, colorUmbral, 45);

            //oform.zgc1.ContextMenu.MenuItems.
            oform.zgc1.IsShowPointValues = true;
            oform.zgc1.AxisChange();
            oform.zgc1.Refresh();
            //oform.zgc1.IsShowCursorValues = true;

            oform.Show();



        }


        public void mostrarGraficaComparativa(int filasSeleccionadas, double[,] pcobertura, double[,] psaldos,
                string[] pnombres, string[] periodos, string sTituloY, string sTituloX, double[,] psaldosComparar)
        {

            ClasesGenerales.frm_graficar oform = new ClasesGenerales.frm_graficar();

            GraphPane mypane = oform.zgc1.GraphPane;
            mypane.CurveList.Clear();
            mypane.Title.Text = "";
            mypane.YAxis.Title.Text = sTituloY; // "Cobertura Semanas";
            mypane.YAxis.MajorGrid.IsVisible = true;
            mypane.YAxis.MinorTic.IsAllTics = false;

            Double[] xx, yy;

            xx = null;

            Color c = default(Color);
            Color c2 = default(Color);

            Double[] coberturaGraficar = new double[21];
            Double[] saldosGraficar = new double[21];
            Double[] saldosComparativosGraficar = new double[21];


            for (int i = 0; i < filasSeleccionadas; i++)
            {
                for (int icount = 0; icount < 21; icount++)
                {
                    coberturaGraficar[icount] = pcobertura[i, icount];
                    saldosGraficar[icount] = psaldos[i, icount];
                    saldosComparativosGraficar[icount] = psaldosComparar[i, icount];
                }

                c = new Color();
                c2 = new Color();


                switch (i)
                {
                    case 0:

                        c = Color.Blue;
                        c2 = Color.Red;

                        break;
                    case 1:
                        c = Color.Blue;
                        c2 = Color.DarkBlue;
                        break;
                    case 2:
                        c = Color.DarkOrange;
                        c2 = Color.DarkOrange;
                        break;
                    case 3:
                        c = Color.Purple;
                        c2 = Color.Purple;
                        break;
                    case 4:
                        c = Color.DarkGreen;
                        c2 = Color.DarkGreen;
                        break;
                    case 5:
                        c = Color.DarkCyan;
                        c2 = Color.DarkCyan;
                        break;
                }



                //LineItem myCurve = mypane.AddCurve("Cobertura " + pnombres[i], xx, coberturaGraficar, c, SymbolType.Circle);
                LineItem myCurve = mypane.AddCurve("Saldos " + pnombres[i], xx, saldosGraficar, c, SymbolType.Circle);
                myCurve.IsY2Axis = true;
                myCurve.Line.Width = 2;
                myCurve.Symbol.Fill.Color = c;
                myCurve.Symbol.Size = 3;


                c = new Color();

                c = Color.Green;

                LineItem myCurveComparativo = mypane.AddCurve("Saldos Sem Ant ", xx, saldosComparativosGraficar, c, SymbolType.Circle);
                myCurveComparativo.IsY2Axis = true;
                myCurveComparativo.Line.Width = 2;
                myCurveComparativo.Symbol.Fill.Color = c;
                myCurveComparativo.Symbol.Size = 3;





                //BarItem myBarra = mypane.AddBar("Saldos " + pnombres[i], xx, saldosGraficar, c2);
                BarItem myBarra = mypane.AddBar("Cobertura " + pnombres[i], xx, coberturaGraficar, c2);
                //myBarra.IsY2Axis = true;


            }


            for (int icount = 0; icount < 21; icount++)
                saldosGraficar[icount] = psaldos[7, icount];

            LineItem myCurve3 = mypane.AddCurve("", xx, saldosGraficar, Color.DarkOliveGreen, SymbolType.None);
            myCurve3.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            myCurve3.Line.Width = 2;


            for (int icount = 0; icount < 21; icount++)
                saldosGraficar[icount] = psaldos[6, icount];

            LineItem myCurve4 = mypane.AddCurve("", xx, saldosGraficar, Color.DarkOliveGreen, SymbolType.None);
            myCurve4.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            myCurve4.Line.Width = 2;


            mypane.XAxis.Title.Text = "";
            mypane.XAxis.Type = AxisType.Text;
            mypane.XAxis.Scale.Align = AlignP.Center;
            mypane.XAxis.Scale.FontSpec.Angle = 90;
            mypane.XAxis.Scale.FontSpec.Size = 8;
            mypane.Legend.FontSpec.Size = 8;

            mypane.XAxis.Scale.TextLabels = periodos;




            mypane.Y2Axis.IsVisible = true;
            mypane.Y2Axis.Title.Text = sTituloX; //"Existencias Cajas";
            mypane.Y2Axis.MajorGrid.Color = Color.Silver;
            mypane.Y2Axis.Title.FontSpec.Size = 9;
            mypane.YAxis.Title.FontSpec.Size = 9;
            mypane.Y2Axis.Scale.TextLabels = periodos;

            Color colorUmbral = Color.FromArgb(233, 234, 204);
            mypane.Chart.Fill = new Fill(Color.White, colorUmbral, 45);
            mypane.Fill = new Fill(Color.White, colorUmbral, 45);

            //oform.zgc1.ContextMenu.MenuItems.
            oform.zgc1.IsShowPointValues = true;
            oform.zgc1.AxisChange();
            oform.zgc1.Refresh();
            oform.Text = "Cobertura " + pnombres[0];
            //oform.zgc1.IsShowCursorValues = true;

            oform.Show();



        }


        public void mostrarGraficaComparativaABC(int filasSeleccionadas, double[,] pcobertura, double[,] psaldosA,
             string[] pnombres, string[] periodos, string sTituloY, string sTituloX, double[,] psaldosB, double[,] psaldosC, double[,] psaldosD)
        {

            ClasesGenerales.frm_graficar oform = new ClasesGenerales.frm_graficar();

            GraphPane mypane = oform.zgc1.GraphPane;
            mypane.CurveList.Clear();
            mypane.Title.Text = "";
            mypane.YAxis.Title.Text = sTituloY; // "Cobertura Semanas";
            mypane.YAxis.MajorGrid.IsVisible = true;
            mypane.YAxis.MinorTic.IsAllTics = false;

            Double[] xx, yy;

            xx = null;

            Color c = default(Color);
            Color c2 = default(Color);

            Double[] coberturaGraficar = new double[21];
            Double[] saldosGraficar = new double[21];
            Double[] saldosA = new double[21];
            Double[] saldosB = new double[21];
            Double[] saldosC = new double[21];
            Double[] saldosD = new double[21];


            for (int i = 0; i < filasSeleccionadas; i++)
            {
                for (int icount = 0; icount < 21; icount++)
                {
                    coberturaGraficar[icount] = pcobertura[i, icount];
                    saldosA[icount] = psaldosA[i, icount];
                    saldosB[icount] = psaldosB[i, icount];
                    saldosC[icount] = psaldosC[i, icount];
                    saldosD[icount] = psaldosD[i, icount];
                }

                c = new Color();
                c2 = new Color();


                switch (i)
                {
                    case 0:

                        c = Color.Blue;
                        c2 = Color.Red;

                        break;
                    case 1:
                        c = Color.Blue;
                        c2 = Color.DarkBlue;
                        break;
                    case 2:
                        c = Color.DarkOrange;
                        c2 = Color.DarkOrange;
                        break;
                    case 3:
                        c = Color.Purple;
                        c2 = Color.Purple;
                        break;
                    case 4:
                        c = Color.DarkGreen;
                        c2 = Color.DarkGreen;
                        break;
                    case 5:
                        c = Color.DarkCyan;
                        c2 = Color.DarkCyan;
                        break;
                }



                //LineItem myCurve = mypane.AddCurve("Cobertura " + pnombres[i], xx, coberturaGraficar, c, SymbolType.Circle);
                LineItem myCurve = mypane.AddCurve("Saldos A", xx, saldosA, c, SymbolType.Circle);
                myCurve.IsY2Axis = true;
                myCurve.Line.Width = 2;
                myCurve.Symbol.Fill.Color = c;
                myCurve.Symbol.Size = 3;


                c = new Color();

                c = Color.Red;

                LineItem myCurveComparativo = mypane.AddCurve("Saldos B", xx, saldosB, c, SymbolType.Circle);
                myCurveComparativo.IsY2Axis = true;
                myCurveComparativo.Line.Width = 2;
                myCurveComparativo.Symbol.Fill.Color = c;
                myCurveComparativo.Symbol.Size = 3;


                c = new Color();

                c = Color.Green;

                LineItem myCurveC = mypane.AddCurve("Saldos C", xx, saldosC, c, SymbolType.Circle);
                myCurveC.IsY2Axis = true;
                myCurveC.Line.Width = 2;
                myCurveC.Symbol.Fill.Color = c;
                myCurveC.Symbol.Size = 3;


                c = new Color();

                c = Color.Cyan;

                LineItem myCurveD = mypane.AddCurve("Saldos D", xx, saldosD, c, SymbolType.Circle);
                myCurveD.IsY2Axis = true;
                myCurveD.Line.Width = 2;
                myCurveD.Symbol.Fill.Color = c;
                myCurveD.Symbol.Size = 3;










                //BarItem myBarra = mypane.AddBar("Saldos " + pnombres[i], xx, saldosGraficar, c2);
                BarItem myBarra = mypane.AddBar("Cobertura " + pnombres[i], xx, coberturaGraficar, c2);
                //myBarra.IsY2Axis = true;


            }


            for (int icount = 0; icount < 21; icount++)
                saldosGraficar[icount] = psaldosA[7, icount];

            LineItem myCurve3 = mypane.AddCurve("", xx, saldosGraficar, Color.DarkOliveGreen, SymbolType.None);
            myCurve3.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            myCurve3.Line.Width = 2;


            for (int icount = 0; icount < 21; icount++)
                saldosGraficar[icount] = psaldosA[6, icount];

            LineItem myCurve4 = mypane.AddCurve("", xx, saldosGraficar, Color.DarkOliveGreen, SymbolType.None);
            myCurve4.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            myCurve4.Line.Width = 2;


            mypane.XAxis.Title.Text = "";
            mypane.XAxis.Type = AxisType.Text;
            mypane.XAxis.Scale.Align = AlignP.Center;
            mypane.XAxis.Scale.FontSpec.Angle = 90;
            mypane.XAxis.Scale.FontSpec.Size = 8;
            mypane.Legend.FontSpec.Size = 8;

            mypane.XAxis.Scale.TextLabels = periodos;




            mypane.Y2Axis.IsVisible = true;
            mypane.Y2Axis.Title.Text = sTituloX; //"Existencias Cajas";
            mypane.Y2Axis.MajorGrid.Color = Color.Silver;
            mypane.Y2Axis.Title.FontSpec.Size = 9;
            mypane.YAxis.Title.FontSpec.Size = 9;
            mypane.Y2Axis.Scale.TextLabels = periodos;

            Color colorUmbral = Color.FromArgb(233, 234, 204);
            mypane.Chart.Fill = new Fill(Color.White, colorUmbral, 45);
            mypane.Fill = new Fill(Color.White, colorUmbral, 45);

            //oform.zgc1.ContextMenu.MenuItems.
            oform.zgc1.IsShowPointValues = true;
            oform.zgc1.AxisChange();
            oform.zgc1.Refresh();
            oform.Text = "Cobertura ABC " + pnombres[0];
            //oform.zgc1.IsShowCursorValues = true;

            oform.Show();



        }

    }




    public class Internaciones
    {

        //El No fallará, Confia en el Señor
        //No te Dejará, Su Amor te sustentará
        //El No fallará, 
        //Si Confias en El y dejas el temor
        //El No fallará
        //Con su Mano de Amor El te sostendrá

        DataSet ds_preparacion;
        string scm_empresa = string.Empty;
        string scm_region = string.Empty;
        string scm_area = string.Empty;
        string scm_origen = string.Empty;
        string scm_producto_limite = string.Empty;
        string scm_proveedor = string.Empty;
        string scm_puerto = string.Empty;

        public string Empresa
        {
            get
            {
                return scm_empresa;
            }
            set
            {
                scm_empresa = value;
            }
        }

        public string Proveedor
        {
            get
            {
                return scm_proveedor;
            }
            set
            {
                scm_proveedor = value;
            }
        }

        public string productoLimite
        {
            get
            {
                return scm_producto_limite;
            }
            set
            {
                scm_producto_limite = value;
            }
        }


        public Internaciones(ref DataSet ds)
        {
            ds_preparacion = ds;
        }


        public void inicializarProductos(bool generar_informacion_global, bool generar_region, bool generar_procedencia_individual, bool productos_compra)
        {

            string ls_sql = "pa_sel_um_inv_producto_dia ";
            Transaccional.Conexion oTrans = new Transaccional.Conexion("SCM");
            DataTable dt;
            DataRow dr_aux;
            int iaux;
            string saux;
            Double dinv_maximo = 0;

            try
            {
                oTrans.open();

                // Empresa
                //if (generar_informacion_global)
                if (scm_empresa.Length == 0)
                    ls_sql += "NULL,";
                else
                    ls_sql += "'" + scm_empresa + "',";

                // Proveedor
                if (generar_region)
                    ls_sql += "NULL,";
                else if (generar_informacion_global)
                    ls_sql += "NULL,";
                else if (scm_proveedor.Length > 0)
                    ls_sql += "'" + scm_proveedor + "',";
                else
                    ls_sql += "NULL,";

                //Procedencia
                if (generar_procedencia_individual)
                    ls_sql += "'" + scm_origen + "',";
                else
                    ls_sql += "NULL,";


                //Region
                if (generar_region)
                    ls_sql += "'" + scm_region + "',";
                else
                    ls_sql += "NULL,";

                if (scm_puerto.ToString().Length > 0)
                    ls_sql += "'" + scm_puerto + "',";
                else
                    ls_sql += "NULL,";

                ls_sql += "'" + scm_producto_limite + "'";

                if (productos_compra)
                    ls_sql += ",1";
                dt = oTrans.Obtiene(ls_sql);

                ds_preparacion.Tables["detalle_productos"].Rows.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {

                        if (dr["producto"].ToString() == "0100010903")
                        {
                            dr["producto"] = "0100010903";
                        }

                        dr_aux = ds_preparacion.Tables["detalle_productos"].NewRow();
                        dr_aux["empresa"] = dr["empresa"].ToString();
                        dr_aux["proveedor"] = dr["subfamilia"].ToString();
                        dr_aux["procedencia"] = dr["procedencia"].ToString();
                        dr_aux["marca"] = dr["marca"].ToString();
                        dr_aux["producto"] = dr["producto"].ToString();
                        dr_aux["glosa"] = dr["glosa"].ToString();
                        dr_aux["uxc"] = dr["uxc"].ToString();
                        dr_aux["full"] = dr["tipo_manejo"].ToString();
                        dr_aux["cajasxlayer"] = int.Parse(dr["cajas_por_layer"].ToString());
                        dr_aux["agregar"] = false;
                        dr_aux["tiene_compra"] = false;


                        try
                        {
                            iaux = int.Parse(dr["cajas_por_layer"].ToString()) * int.Parse(dr["layer_por_pallet"].ToString());
                        }
                        catch (Exception ex)
                        {
                            iaux = 0;
                        }
                        dr_aux["cajasxpallet"] = iaux;
                        //  dr_aux["diario_cajas"] = 0;
                        dr_aux["pareto"] = dr["pareto"].ToString();
                        dr_aux["pedido"] = 0;
                        dr_aux["sugerido"] = 0;
                        for (int icount = 1; icount < 5; icount++)
                        {
                            saux = "sugerido+" + icount.ToString("00");
                            dr_aux[saux] = 0;
                        }
                        dr_aux["cobertura_pedido"] = 0;
                        dr_aux["existencia_pedido"] = 0;
                        dr_aux["sugerido_proveedor"] = 0;
                        dr_aux["valor_sugerido"] = 0;
                        dr_aux["min_cajas"] = 0;
                        dr_aux["max_cajas"] = 0;
                        dr_aux["internacion"] = 0;
                        dr_aux["cd_cajas"] = 0;
                        dr_aux["cdx_cajas"] = 0;
                        dr_aux["da_cajas"] = 0;
                        dr_aux["existencia"] = 0;
                        dr_aux["transito"] = 0;
                        dr_aux["pptosem"] = 0;
                        dr_aux["ppto"] = 0;
                        dr_aux["saldo"] = 0;
                        dr_aux["cobertura"] = 0;
                        dr_aux["fob"] = 0;
                        dr_aux["dai"] = 0;
                        dr_aux["iva"] = 0;
                        dr_aux["teorico"] = 0;
                        dr_aux["calculos"] = 0;

                        try
                        {
                            dr_aux["pv_lead_time_total"] = Double.Parse(ds_preparacion.Tables["parametros"].DefaultView[0]["lead_time"].ToString()); ; //dr["pv_lead_time_total"];
                        }
                        catch (Exception ex)
                        {
                            oTrans.Escribir_Log(ex.ToString());
                        }
                        //El lead Time en Internaciones es de 3 dias es un parametro que lo pueden cambiar


                        try
                        {
                            ds_preparacion.Tables["pareto"].DefaultView.RowFilter = "pareto = '" + dr_aux["pareto"] + "'";
                            if (ds_preparacion.Tables["pareto"].DefaultView.Count > 0)
                            {
                                dinv_maximo = Double.Parse(ds_preparacion.Tables["pareto"].DefaultView[0]["dias_maximo_cd"].ToString());
                            }

                        }
                        finally
                        {
                        }
                        dr_aux["pv_ciclo_compra"] = dr["pv_ciclo_compra"];
                        dr_aux["pv_margen_seguridad"] = dr["pv_margen_seguridad"];

                        //El Inventario Maximo esta Dado de Acuerdo al Pareto del Producto
                        dr_aux["pv_inv_reorden"] = dr["pv_inv_reorden"];
                        dr_aux["pv_inv_maximo"] = dinv_maximo; //dr["pv_inv_maximo"];
                        dr_aux["pv_inv_seguridad"] = dr["pv_inv_seguridad"];
                        dr_aux["bloqueado_internacion"] = 0; //1 Bloqueo de Internaciones, 2 Registro Sanitario

                        for (iaux = 1; iaux <= 52; iaux++)
                        {
                            saux = "transito+" + iaux.ToString("00");
                            dr_aux[saux] = 0;
                            saux = "ppto+" + iaux.ToString("00");
                            dr_aux[saux] = 0;
                            saux = "saldo+" + iaux.ToString("00");
                            dr_aux[saux] = 0;
                            saux = "cobertura+" + iaux.ToString("00");
                            dr_aux[saux] = 0;
                            saux = "teorico+" + iaux.ToString("00");
                            dr_aux[saux] = 0;
                            if (iaux < 63)
                            {
                                saux = "pptoSem+" + iaux.ToString("00");
                                dr_aux[saux] = 0;
                            }

                        }
                        try
                        {

                            dr_aux["peso"] = dr["peso_bruto_caja"];
                            dr_aux["volumen"] = dr["volumen_cubico_caja"];
                        }
                        catch (Exception ex)
                        { }
                        dr_aux["peso_total"] = 0;
                        dr_aux["ppto_total"] = 0;

                        try
                        {
                            dr_aux["numero_registro_sanitario"] = dr["registro"].ToString();
                            if (dr_aux["numero_registro_sanitario"].ToString() != "")
                             {
                                dr_aux["fecha_vencimiento_registro"] = DateTime.Parse(dr["fecha_vencimiento"].ToString());
                            }
                        }
                        catch (Exception ex)
                        { }

                        try
                        {
                            dr_aux["valida_registro"] = false;

                            if (double.Parse(dr["valida_registro"].ToString()) == 1)
                                dr_aux["valida_registro"] = true;

                        }
                        catch (Exception ex)
                        { }



                        ds_preparacion.Tables["detalle_productos"].Rows.Add(dr_aux);
                    }
                    catch (Exception ex)
                    {

                    }

                }
                ClasesGenerales.General ClsGen = new ClasesGenerales.General();
                string[] campos = new string[1];
                campos[0] = "pv_lead_time_total";

                dt = ClsGen.ValoresDistinto(ds_preparacion.Tables["detalle_productos"], campos);
                if (dt.Rows.Count > 0)
                {
                    double maxlt = double.Parse(dt.Compute("max(pv_lead_time_total)", "pv_lead_time_total > 0").ToString());
                    foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
                        dr["pv_lead_time_total"] = maxlt;

                }

                ClsGen = null;


            }
            catch (Exception ex)
            {
            }
            finally
            {
                oTrans.close();
                oTrans = null;
            }

        }

        public void revisarProductosDerivados()
        {
            Transaccional.Conexion oTrans = new Transaccional.Conexion("umbralsa");
            ClasesGenerales.General clsGen = new ClasesGenerales.General();
            DataTable dt;
            string lsSql, sfiltro;
            string[] campos = new string[2];
            campos[0] = "empresa";
            campos[1] = "producto_padre";




            try
            {
                oTrans.open();
                lsSql = "pa_sel_um_producto_derivado '" + scm_empresa + "'";
                dt = oTrans.Obtiene(lsSql);
                dt.TableName = "derivados";
                if (ds_preparacion.Tables.Contains("derivados"))
                    ds_preparacion.Tables.Remove("derivados");

                ds_preparacion.Tables.Add(dt.Copy());

                dt = clsGen.ValoresDistinto(dt, campos);

                foreach (DataRow dr in dt.Rows)
                {
                    sfiltro = "empresa = '" + dr["empresa"].ToString() + "' and producto = '" + dr["producto_padre"].ToString() + "'";
                    ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter = sfiltro;
                    foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                    {
                        lsSql = "**" + drv["glosa"].ToString();
                        drv["glosa"] = lsSql;
                    }
                }

            }
            finally
            {
                oTrans.close();
                oTrans = null;
            }
        }

        public void generarSaldosyCoberturas(Int32 nLimite)
        {
            string smes_actual, smes_pasado, stransito, sppto, steorico, scobertura;
            //  int ippto, isaldo, itransito, iteorico, icobertura;
            double dsaldo, dtransito, dsaldomespasado;
            ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter = "";

            foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
            {
                try
                {

                    dr["existencia"] = int.Parse(dr["cd_cajas"].ToString()) + int.Parse(dr["cdx_cajas"].ToString()) + int.Parse(dr["da_cajas"].ToString());
                    dsaldo = int.Parse(dr["cd_cajas"].ToString()) + int.Parse(dr["cdx_cajas"].ToString()) +
                           Double.Parse(dr["transito"].ToString()) -
                           Double.Parse(dr["ppto"].ToString()) + Double.Parse(dr["internacion"].ToString());
                    //int.Parse(dr["da_cajas"].ToString()) + double.Parse(dr["transito"].ToString()) -
                    //Double.Parse(dr["ppto"].ToString());

                    if (dsaldo < 0)
                        dsaldo = 0;

                    dr["saldo"] = dsaldo;
                    dr["teorico"] = dr["saldo"];



                    //Saldos y teoricos 1-53
                    for (int i = 1; i < nLimite; i++)
                    {
                        smes_actual = "saldo+" + i.ToString("00");
                        smes_pasado = "saldo";
                        stransito = "transito+" + i.ToString("00");
                        sppto = "ppto+" + i.ToString("00");

                        if (i > 1)
                            smes_pasado += "+" + (i - 1).ToString("00");
                        if (dr["producto"].ToString() == "0011012032" && i == 12)
                        {
                            dr["producto"] = "0011012032";
                        }

                        dsaldo = double.Parse(dr[smes_pasado].ToString()) + double.Parse(dr[stransito].ToString()) -
                                 double.Parse(double.Parse(dr[sppto].ToString()).ToString());


                        //dr[smes_actual] = dsaldo;
                        if (dsaldo < 0)
                            dsaldo = 0;

                        dr[smes_actual] = dsaldo;

                        dr["teorico+" + i.ToString("00")] = dr[smes_actual];
                        dtransito = double.Parse(dr[stransito].ToString());
                        if (dtransito > 0)
                        {
                            for (int icount = 0; icount < i; icount++)
                            {
                                steorico = "teorico";
                                if (icount > 0)
                                    steorico += "+" + icount.ToString("00");

                                dr[steorico] = double.Parse(dr[steorico].ToString()) + dtransito;
                            }
                        }
                    }

                    //Cobertura mes actual
                    dsaldo = double.Parse(dr["saldo"].ToString());
                    if (dsaldo > 0)
                    {
                        for (int iaux = 1; iaux < nLimite + 1; iaux++)
                        {
                            if (dsaldo > 0)
                            {
                                if (dsaldo - double.Parse(dr["ppto+" + iaux.ToString("00")].ToString()) >= 0)
                                {
                                    dr["cobertura"] = double.Parse(dr["cobertura"].ToString()) + 1;
                                    dsaldo -= double.Parse(dr["ppto+" + iaux.ToString("00")].ToString());
                                }
                                else
                                {
                                    dr["cobertura"] = double.Parse(dr["cobertura"].ToString()) + (dsaldo / double.Parse(dr["ppto+" + iaux.ToString("00")].ToString()));
                                    dsaldo = 0;
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        dr["cobertura"] = 0;
                    }



                    ////Coberturas 1-52
                    for (int iaux = 1; iaux < nLimite; iaux++)
                    {
                        scobertura = "cobertura+" + iaux.ToString("00");
                        smes_actual = "saldo+" + iaux.ToString("00");


                        if ((dr["producto"].ToString() == "0010208002") && (iaux == 12))
                        {
                            dr["producto"] = "0010208002";
                        }

                        dsaldo = 0;
                        //icobertura = 0;
                        dr[scobertura] = 0;
                        dsaldo = double.Parse(dr[smes_actual].ToString());
                        smes_pasado = "saldo";
                        if (iaux > 1)
                            smes_pasado += "+" + (iaux - 1).ToString("00");

                        dsaldomespasado = double.Parse(dr[smes_pasado].ToString());
                        //if (dsaldo > 0)
                        //   if (dsaldomespasado - double.Parse(dr["ppto+" + iaux.ToString("00")].ToString()) >= 0)
                        //  {
                        //tengo que establecer cuando ya se haya hecho resta del ppto y q tenga cobertura
                        //saldo_mespasado - ppto
                        //      dr[scobertura] = 1;
                        // dsaldo -= double.Parse(dr["ppto+" + iaux.ToString("00")].ToString());
                        //  }
                        //}

                        if (dsaldo > 0)
                            for (int iaux2 = iaux + 1; iaux2 < nLimite + 1; iaux2++)
                            {
                                if (dsaldo <= 0)
                                {
                                    break;
                                }
                                else
                                {
                                    if (dsaldo - double.Parse(dr["ppto+" + iaux2.ToString("00")].ToString()) >= 0)
                                    {
                                        dr[scobertura] = int.Parse(dr[scobertura].ToString()) + 1;
                                        dsaldo -= double.Parse(dr["ppto+" + iaux2.ToString("00")].ToString());
                                    }
                                    else
                                    {
                                        dr[scobertura] = double.Parse(dr[scobertura].ToString()) + (dsaldo / (double.Parse(dr["ppto+" + iaux2.ToString("00")].ToString())));
                                        dsaldo = 0;
                                        break;
                                    }
                                }
                            }
                    }
                }
            
            catch (Exception ex)
            {
            }

        }
        }

        //Generar Minimos y Maximos

        public void generarMinimosyMaximos(int isemanaactual, bool brecalcular_maximo)
        {



            decimal icount, imaximo, ilead_time, daux, isemana, iseguridad, ireorden;
            string lsnombrecampo;

            ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter = "";

            foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
            {
                try
                {
                    if (dr["producto"].ToString() == "0200070400")
                        dr["producto"] = "0200070400";

                    // dmargen_seguridad = 1 + (decimal.Parse(dr["pv_margen_seguridad"].ToString())/100);
                    ireorden = decimal.Parse(dr["pv_inv_reorden"].ToString());


                    ilead_time = decimal.Parse(dr["pv_lead_time_total"].ToString());
                    //ifrecuencia_compra2 = decimal.Parse(dr["pv_ciclo_compra"].ToString());
                    // dmargen_seguridad = 1 + (decimal.Parse(dr["pv_margen_seguridad"].ToString())/100);
                    imaximo = decimal.Parse(dr["pv_inv_maximo"].ToString());
                    iseguridad = decimal.Parse(dr["pv_inv_seguridad"].ToString());
                    //imaximo = imaximo * dmargen_seguridad;

                    //Establecer para que sirven el Margen de Seguridad

                    isemana = -1;
                    isemana += isemanaactual;
                    icount = ireorden; //(c) 29022012 el ireorden es el minimo para internaciones
                    //icount = ilead_time + iseguridad;  //Debo Sumarle en Inventario de Seguidad al LeadTime
                    // icount -= isemanaactual; //si el lt = 14 y empieza en la semana 1 debe terminar en la 15 para hacer siempre 14
                    //    imaximo += iseguridad; //Debo Sumarle el Inventario de Seguridad al Inventario Maximo (c)231107 Solo se le Agrega el Maximo al lead time
                    if (dr["producto"].ToString() == "0300030007")
                        dr["producto"] = "0300030007";


                    daux = 0;
                    isemana = ilead_time - 1;
                    while (icount > 0)
                    {
                        isemana += 1;
                        lsnombrecampo = "ppto";
                        if (isemana > 0)
                            lsnombrecampo += "+" + isemana.ToString("00");

                        if (icount >= 1)
                            daux += decimal.Parse(dr[lsnombrecampo].ToString());
                        else
                            daux += decimal.Parse(dr[lsnombrecampo].ToString()) * icount;

                        icount -= 1;

                    }
                    //    daux *= dmargen_seguridad;
                    dr["min_cajas"] = daux;


                    if (!brecalcular_maximo)
                        continue;
                    else
                    {
                        //Maximos Cuanto
                        daux = 0;
                        icount = ilead_time - 1; //se le quita uno para q cuando comienza a calcular se lo vuelve a sumar y empieza en la semana de ingreso

                        while (imaximo > 0)
                        {
                            icount += 1;
                            lsnombrecampo = "ppto";
                            if (icount > 0)
                                lsnombrecampo += "+" + icount.ToString("00");

                            if (imaximo >= 1)
                                daux += decimal.Parse(dr[lsnombrecampo].ToString());
                            else
                                daux += decimal.Parse(dr[lsnombrecampo].ToString()) * imaximo;

                            imaximo -= 1;
                        }
                        dr["max_cajas"] = daux;
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void generarPedidoSugerido(int nsemanaactual, bool brecalculartodos)
        {
            double ipedido_sugerido, ileadtime;

            string snombrecampo, steoricocalculo, scobertura, scoberturacalculo;
            bool bcalcular = false;

            foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
            {
                try
                {
                if (dr["producto"].ToString() == "0100020305")
                    dr["producto"] = "0100020305";

                bcalcular = true;
                for (int i = 0; i <= nsemanaactual; i++)
                {
                    snombrecampo = "sugerido";
                    if (i > 0)
                        snombrecampo += "+" + i.ToString("00");
                    if (int.Parse(dr[snombrecampo].ToString()) > 0)
                    {
                        bcalcular = false;
                        continue;
                    }


                }

                if (brecalculartodos)
                    bcalcular = true;

                if (bcalcular)
                {


                    ipedido_sugerido = 0;
                    //nsemanaingreso = int.Parse(dr["pv_lead_time_total"].ToString("00"))
                    snombrecampo = "teorico";
                    steoricocalculo = "teorico";
                    scoberturacalculo = "cobertura";
                    ileadtime = System.Convert.ToInt32(dr["pv_lead_time_total"]);

                    if (Double.Parse(dr["pv_lead_time_total"].ToString()) > 0)
                        snombrecampo += "+" + double.Parse(dr["pv_lead_time_total"].ToString()).ToString("00");

                    if (nsemanaactual > 0)
                        ileadtime += nsemanaactual;
                    steoricocalculo += "+" + ileadtime.ToString("00");
                    scoberturacalculo += "+" + ileadtime.ToString("00");

                    /*                    
                     * 
                     * 
                     * 
                     *                             scoberturacalculo = "cobertura";
                                                ileadtime = System.Convert.ToInt32(dr["pv_lead_time_total"]);
                                                dr["pedido"] = 0;
                            
                                                if (ileadtime > 0)
                                                    snombrecampo += "+" + double.Parse(dr["pv_lead_time_total"].ToString()).ToString("00");

                                                if (nsemanaactual > 0)
                                                    ileadtime += nsemanaactual;

                                                steoricocalculo += "+" + ileadtime.ToString("00");
                                                scoberturacalculo += "+" + ileadtime.ToString("00");
                                                if (double.Parse(dr[scoberturacalculo].ToString()) <= double.Parse(dr["pv_inv_reorden"].ToString()))
                                                    ipedido_sugerido = double.Parse(dr["max_cajas"].ToString());

                                                if (double.Parse(dr[steoricocalculo].ToString()) > 0 && ipedido_sugerido > 0)   //le tiene que restar el inventario que tenga cuando ingrese en la semana del LT
                                                    ipedido_sugerido -= int.Parse(double.Parse(dr[steoricocalculo].ToString()).ToString("0000000"));

                     * steoricocalculo += "+" + ileadtime.ToString("00");
                                         scoberturacalculo += "+" + ileadtime.ToString("00");
                                         //if (double.Parse(dr["min_cajas"].ToString()) > double.Parse(dr[steoricocalculo].ToString()))
                                         //    ipedido_sugerido = double.Parse(dr["max_cajas"].ToString());

                                         //Si las semanas de cobertura Son Menor o Igual a las Semanas Reorden Se Pide el Maximo
                                         if (double.Parse(dr[scoberturacalculo].ToString()) <= double.Parse(dr["pv_inv_reorden"].ToString()))
                                             ipedido_sugerido = double.Parse(dr["max_cajas"].ToString());

                                         if (double.Parse(dr[steoricocalculo].ToString()) > 0 && ipedido_sugerido > 0)   //le tiene que restar el inventario que tenga cuando ingrese en la semana del LT
                                             ipedido_sugerido -= int.Parse(double.Parse(dr[steoricocalculo].ToString()).ToString("0000000"));

                    */
                    //if (double.Parse(dr[scoberturacalculo].ToString()) <= double.Parse(dr["pv_inv_reorden"].ToString()))

                    if (double.Parse(dr[scoberturacalculo].ToString()) <= double.Parse(dr["pv_inv_seguridad"].ToString()))
                        ipedido_sugerido = double.Parse(dr["max_cajas"].ToString());

                    if (double.Parse(dr[steoricocalculo].ToString()) > 0 && ipedido_sugerido > 0)   //le tiene que restar el inventario que tenga cuando ingrese en la semana del LT
                        ipedido_sugerido -= int.Parse(double.Parse(dr[steoricocalculo].ToString()).ToString("0000000"));


                    //if (double.Parse(dr["min_cajas"].ToString()) > double.Parse(dr[steoricocalculo].ToString()))
                    //    ipedido_sugerido = double.Parse(dr["max_cajas"].ToString());

                    //if (double.Parse(dr[steoricocalculo].ToString()) > 0 && ipedido_sugerido > 0)   //le tiene que restar el inventario que tenga cuando ingrese en la semana del LT
                    //    ipedido_sugerido -= int.Parse(double.Parse(dr[steoricocalculo].ToString()).ToString("0000000"));


                    if (ipedido_sugerido < 0)
                        ipedido_sugerido = 0;



                    if (ipedido_sugerido > 0)
                    {

                        snombrecampo = "sugerido";
                        if (nsemanaactual > 0)
                            snombrecampo += "+" + nsemanaactual.ToString("00");

                        dr[snombrecampo] = ipedido_sugerido;
                        dr["tiene_compra"] = true;

                        int existenciaDA = int.Parse(dr["da_cajas"].ToString());
                        if (existenciaDA >= ipedido_sugerido)
                        {
                            dr["pedido"] = ipedido_sugerido;
                        }
                        else
                        {
                            dr["pedido"] = existenciaDA;
                        }


                        //if (dr["full"].ToString().ToLower() == "pallet")
                        //{
                        //    int ipallet = 0, icajasxpallet;
                        //    double dpallet;
                        //    icajasxpallet = int.Parse(dr["cajasxpallet"].ToString());
                        //    dpallet = ipedido_sugerido / icajasxpallet;
                        //    ipallet = System.Convert.ToInt32(dpallet);

                        //    if (ipallet - dpallet > 0.5)
                        //    {
                        //        ipallet += 1;
                        //    }
                        //    dr["pedido"] = ipallet * icajasxpallet; //ipedido_sugerido;
                        //}
                        //else
                        //    if ((dr["full"].ToString().ToLower() == "layer") || (dr["full"].ToString().ToLower() == "cajas"))
                        //    {
                        //        int ilayer = 0, icajasxlayer;
                        //        double dlayer;
                        //        icajasxlayer = int.Parse(dr["cajasxlayer"].ToString());
                        //        dlayer = ipedido_sugerido / icajasxlayer;
                        //        ilayer = System.Convert.ToInt32(dlayer);

                        //        if (ilayer - ilayer > 0.5)
                        //            ilayer += 1;

                        //        dr["pedido"] = ilayer * icajasxlayer; //ipedido_sugerido;
                        //    }
                        //    else
                        //    {
                        //        dr["pedido"] = ipedido_sugerido;
                        //    }



                        //double dpedido = double.Parse(dr["pedido"].ToString());
                        //int lpedido = System.Convert.ToInt32(dpedido);
                        //if (lpedido > 0)
                        //    dr["valor_sugerido"] = lpedido * double.Parse(dr["fob"].ToString());
                    }
                    //dr["sugerido_anterior"] = 0;
                    //dr["calculos"] = int.Parse(dr["calculos"].ToString()) + 1;
                }
                bcalcular = false;

            
            }
                catch (Exception ex)
                {
                }
            }

        }

        public void obtenerExistenciasDA(string psVigente)
        {
            DataRowView drv;
            DataRow dr;
            String lsSQL;
            DataTable dt;
            Transaccional.Conexion otrans = new Transaccional.Conexion("scm");

            try
            {
                otrans.open();

                lsSQL = "pa_sel_um_vs_detalle_dua '" + scm_empresa + "',null," +psVigente;

                dt = otrans.Obtiene(lsSQL);

                foreach (DataRow dr_aux in dt.Rows)
                {

                    dr = ds_preparacion.Tables["detalle_dua"].NewRow();

                    dr["producto"] = dr_aux["producto"];
                    dr["glosa"] = dr_aux["glosa"];
                    dr["dua"] = dr_aux["no_dua"];
                    dr["asociar"] = false;
                    dr["saldo_cajas"] = dr_aux["saldo_bultos"];
                    dr["saldo_unidades"] = dr_aux["saldo_unidades"];


                    try
                    {
                        dr["factor_ingreso"] = dr_aux["factor_ingreso"];
                    }
                    catch (Exception ex)
                    {
                        otrans.Escribir_Log(ex.ToString());
                    }

                    finally
                    {
                    }



                    dr["observaciones"] = dr_aux["observaciones"];
                    dr["lote"] = dr_aux["lote"].ToString();
                    dr["fecha_vencimiento_dua"] = dr_aux["fecha_vence_dua"];
                    dr["fecha_vencimiento_producto"] = dr_aux["fecha_vence_prod"];
                    dr["fob"] = 0;
                    dr["dai"] = 0;
                    dr["iva"] = 0;
                    dr["lote"] = dr_aux["lote"];

                    ds_preparacion.Tables["detalle_dua"].Rows.Add(dr);

                }



            }
            catch (Exception ex)
            {
                otrans.Escribir_Log(ex.ToString());
            }

            finally
            {
                otrans.close();
                otrans = null;
            }

            //  LlenarFOB()

        }

        public void llenarExistenciasCD()
        {
            Transaccional.Conexion Otrans = new Transaccional.Conexion("scm");
            string lsSQL;
            DataTable dt;
            Double iaux;



            try
            {
                Otrans.open();


                lsSQL = "pa_var_um_existencias_producto '" + scm_empresa + "',NULL,NULL" +
                                              ",'CD_CENTRAL','0090000000'";
                dt = Otrans.Obtiene(lsSQL);

                foreach (DataRow dr in dt.Rows)
                {
                    ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter = "producto = '" + dr["producto"].ToString() + "'";
                    foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                    {
                        try
                        {
                            iaux = Double.Parse(dr["Existencia"].ToString()) / Double.Parse(drv["uxc"].ToString());
                        }
                        catch (Exception ex)
                        {
                            iaux = 0;
                        }
                        try
                        {
                            drv["cd_cajas"] = iaux;
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    ds_preparacion.Tables["derivados"].DefaultView.RowFilter = "empresa = '" + dr["empresa"].ToString() + "' and " +
                        "producto = '" + dr["producto"].ToString() + "'";
                    if (ds_preparacion.Tables["derivados"].DefaultView.Count > 0)
                        foreach (DataRowView drvaux in ds_preparacion.Tables["derivados"].DefaultView)
                        {
                            try
                            {
                                drvaux["existencia"] = dr["Existencia"]; // '(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")
                            }
                            finally
                            {
                            }

                            ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                        = "producto = '" + drvaux["producto_padre"].ToString() + "' and empresa = '" + drvaux["empresa"].ToString() + "'";

                            foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                            {
                                try
                                {
                                    iaux = (Double.Parse(dr["Existencia"].ToString()) * Double.Parse(drvaux["unidades"].ToString())) / Double.Parse(drv["uxc"].ToString());
                                }
                                catch (Exception ex)
                                {
                                    iaux = 0;
                                }
                                drv["cd_cajas"] = Double.Parse(drv["cd_cajas"].ToString()) + iaux;
                            }
                        }
                }
            }
            catch (Exception ex)
            { }
        }

        public void llenarExistenciasDA()
        {
            Transaccional.Conexion Otrans = new Transaccional.Conexion("scm");
            String lsSQL;
            DataTable dt;
            Double iaux;

            try
            {
                Otrans.open();
                //Existencias DA


                lsSQL = "pa_var_um_existencias_producto '" + scm_empresa + "',NULL,NULL" +
                        ",'DA_CENTRAL','0090000000'";
                dt = Otrans.Obtiene(lsSQL);

                foreach (DataRow dr in dt.Rows)
                {
                    ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter = "producto = '" + dr["producto"].ToString() + "'";
                    foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                    {
                        try
                        {
                            iaux = Double.Parse(dr["Existencia"].ToString()) / Double.Parse(drv["uxc"].ToString());
                        }
                        catch (Exception ex)
                        {
                            iaux = 0;
                        }
                        try
                        {
                            drv["da_cajas"] = iaux;
                        }
                        catch (Exception ex)
                        {
                            Otrans.Escribir_Log(drv["producto"].ToString());
                            Otrans.Escribir_Log(ex.ToString());
                        }
                    }
                }


                //'Resta Las Reservas
                lsSQL = "pa_var_um_da_saldo_reservas '" + scm_empresa + "'";
                dt = Otrans.Obtiene(lsSQL);

                foreach (DataRow dr in dt.Rows)
                {
                    ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter
                                         = "producto = '" + dr["producto"].ToString() +
                                         "' and empresa = '" + dr["empresa"].ToString() + "'";
                    foreach (DataRowView drv in ds_preparacion.Tables["detalle_productos"].DefaultView)
                    {

                        try
                        {
                            iaux = Double.Parse(dr["unidades"].ToString()) / Double.Parse(drv["uxc"].ToString());
                        }
                        catch (Exception ex)
                        {
                            iaux = 0;
                        }

                        try
                        {
                            drv["da_cajas"] = Double.Parse(drv["da_cajas"].ToString()) - iaux;

                            if (Double.Parse(drv["da_cajas"].ToString()) < 0)
                                drv["da_cajas"] = 0;

                        }
                        catch (Exception ex)
                        {
                            Otrans.Escribir_Log(ex.ToString());
                        }

                    }
                }
            }
            catch ( Exception ex)
            {
                Otrans.Escribir_Log(ex.ToString());
            }
            finally
            {
                Otrans.close();
                Otrans = null;
            }
        }

        public void verificarProductosRegistroSanitario()
        {
            ClasesGenerales.General clsGen = new ClasesGenerales.General();
            DataTable dt = clsGen.Fecha_Servidor("FlexLine");
           DateTime dfechaRegistro, hoy = DateTime.Parse(dt.Rows[0][0].ToString());
            int idiferencia;

            ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter = "";

            foreach (DataRow dr in ds_preparacion.Tables["detalle_productos"].Rows)
            {
                if (dr["valida_registro"].ToString().ToLower().Equals("true") )

                    if (dr["numero_registro_sanitario"].ToString().Trim().Length > 0)
                    {
                        dfechaRegistro = DateTime.Parse(dr["fecha_vencimiento_registro"].ToString());
                        idiferencia = ((TimeSpan)(dfechaRegistro - hoy)).Days;

                        if (idiferencia < 2)
                            dr["bloqueado_internacion"] = 2;

                    }
                    else
                    {
                        dr["bloqueado_internacion"] = 2;
                    }
            }
        }
        
        public void verificarProductosBloqueados()
        {
            Transaccional.Conexion otrans = new Transaccional.Conexion("scm");
            DataTable dt;

            try
            {
                otrans.open();
                dt = otrans.Obtiene("pa_sel_um_int_producto_bloqueado '" + scm_empresa + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    ds_preparacion.Tables["detalle_productos"].DefaultView.RowFilter = "producto = '" + dr["producto"].ToString() + "'";
                    if (ds_preparacion.Tables["detalle_productos"].DefaultView.Count > 0)
                        ds_preparacion.Tables["detalle_productos"].DefaultView[0]["bloqueado_internacion"] = 1;

                }

            }
            finally
            {
                otrans.close();
                otrans = null;
            }
        }


        public void agregarParametros()
        {
            Transaccional.Conexion Otrans = new Transaccional.Conexion("SCM");
            DataTable dt;

            try
            {
                Otrans.open();
                dt = Otrans.Obtiene("pa_sel_um_int_pareto '" + scm_empresa + "'");
                dt.TableName = "pareto";
                if (ds_preparacion.Tables.Contains(dt.TableName))
                    ds_preparacion.Tables.Remove(dt.TableName);

                ds_preparacion.Tables.Add(dt.Copy());


                dt = Otrans.Obtiene("pa_sel_um_int_parametros_generales '" + scm_empresa + "'");
                dt.TableName = "parametros";

                if (ds_preparacion.Tables.Contains(dt.TableName))
                    ds_preparacion.Tables.Remove(dt.TableName);

                ds_preparacion.Tables.Add(dt.Copy());

            }
            finally
            {
                Otrans.close();
                Otrans = null;

            }


        }

        public void crearEstructura()
        {


            string sname;
            DataTable dt = new DataTable("detalle_productos");

            dt.Columns.Add(new DataColumn("empresa", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("proveedor", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("procedencia", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("marca", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("producto", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("glosa", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("pareto", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("estatus", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("uxc", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("pedido", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("fob", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("dai", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("iva", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("sugerido_proveedor", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("valor_sugerido", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("agregar", System.Type.GetType("System.Boolean")));
            dt.Columns.Add(new DataColumn("sugerido", System.Type.GetType("System.Int32")));
            for (int icount = 1; icount < 5; icount++)
            {
                sname = "sugerido+" + icount.ToString("00");
                dt.Columns.Add(new DataColumn(sname, System.Type.GetType("System.Int32")));
            }

            dt.Columns.Add(new DataColumn("min_cajas", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("max_cajas", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("internacion", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("existencia_pedido", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("cobertura_pedido", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("cd_cajas", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("cdx_cajas", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("da_cajas", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("existencia", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("pptosem", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("ppto", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("transito", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("saldo", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("cobertura", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("teorico", System.Type.GetType("System.Decimal"))); //''Saldo Teorico al saldo se le suma el transito

            for (int icount = 1; icount <= 52; icount++)
            {
                sname = "ppto+" + icount.ToString("00");
                dt.Columns.Add(new DataColumn(sname, System.Type.GetType("System.Decimal")));
                sname = "transito+" + icount.ToString("00");
                dt.Columns.Add(new DataColumn(sname, System.Type.GetType("System.Decimal")));
                sname = "saldo+" + icount.ToString("00");
                dt.Columns.Add(new DataColumn(sname, System.Type.GetType("System.Decimal")));
                sname = "cobertura+" + icount.ToString("00");
                dt.Columns.Add(new DataColumn(sname, System.Type.GetType("System.Decimal")));
                sname = "teorico+" + icount.ToString("00");
                dt.Columns.Add(new DataColumn(sname, System.Type.GetType("System.Decimal")));
                if (icount < 53)
                {
                    sname = "pptoSem+" + icount.ToString("00");
                    dt.Columns.Add(new DataColumn(sname, System.Type.GetType("System.Decimal")));
                }
            }

            dt.Columns.Add(new DataColumn("full", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("cajasxlayer", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("cajasxpallet", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("sugerido_anterior", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("pv_lead_time_total", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("pv_ciclo_compra", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("pv_margen_seguridad", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("pv_inv_maximo", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("pv_inv_seguridad", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("pv_inv_reorden", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("calculos", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("tiene_compra", System.Type.GetType("System.Boolean")));
            dt.Columns.Add(new DataColumn("peso", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("volumen", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("peso_total", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("ppto_total", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("bloqueado_internacion", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("numero_registro_sanitario", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("fecha_vencimiento_registro", System.Type.GetType("System.DateTime")));
            dt.Columns.Add(new DataColumn("valida_registro", System.Type.GetType("System.Boolean")));


            if (ds_preparacion.Tables.Contains(dt.TableName))
                ds_preparacion.Tables.Remove(dt.TableName);

            ds_preparacion.Tables.Add(dt.Copy());

            /*  En Internaciones no se utiliza la tabla resumen
            dt.TableName = "Resumen";

            if (ds_preparacion.Tables.Contains(dt.TableName))
                ds_preparacion.Tables.Remove(dt.TableName);
            ds_preparacion.Tables.Add(dt.Copy());
            */

            dt = new DataTable("detalle_dua");

            dt.Columns.Add(new DataColumn("producto", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("glosa", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("dua", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("fecha", System.Type.GetType("System.DateTime")));
            dt.Columns.Add(new DataColumn("cantidad_trasladar", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("asociar", System.Type.GetType("System.Boolean")));
            dt.Columns.Add(new DataColumn("saldo_cajas", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("saldo_unidades", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("factor_ingreso", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("fecha_vencimiento_dua", System.Type.GetType("System.DateTime")));
            dt.Columns.Add(new DataColumn("fecha_vencimiento_producto", System.Type.GetType("System.DateTime")));
            dt.Columns.Add(new DataColumn("observaciones", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("fob", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("dai", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("iva", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("fobunitario", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("daiunitario", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("lote", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("comentarios", System.Type.GetType("System.String")));

            if (ds_preparacion.Tables.Contains(dt.TableName))
                ds_preparacion.Tables.Remove(dt.TableName);

            ds_preparacion.Tables.Add(dt.Copy());

            dt = new DataTable("detalle_seleccion");
            dt.Columns.Add(new DataColumn("producto", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("glosa", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Cantidad", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("uxc", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("dua", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Lote", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("comentarios", System.Type.GetType("System.String")));

            

            

            if (ds_preparacion.Tables.Contains(dt.TableName))
                ds_preparacion.Tables.Remove(dt.TableName);

            ds_preparacion.Tables.Add(dt.Copy());

        }

    }
}
