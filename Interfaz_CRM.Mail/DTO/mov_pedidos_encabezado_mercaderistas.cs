using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_CRM.Mail.DTO
{
    public class mov_pedidos_encabezado_mercaderistas
    {

        public int cod_pedido { get; set; }
        public string empresa { get; set; }
        public string numero_pedido { get; set; }
        public string ctacte { get; set; }
        public string nombre_cliente { get; set; }
        public string forma_pago { get; set; }
        public double total_pedido { get; set; }
        public int total_lineas { get; set; }
        public System.DateTime fecha_pedido { get; set; }
        public System.DateTime fecha_entrega { get; set; }
        public System.DateTime fecha_modifico { get; set; }
        public string comentarios { get; set; }
        public string usuario_grabo { get; set; }
        public int estado { get; set; }
        public string listaprecios { get; set; }
        public string direccion_entrega { get; set; }
        public string referencia_pdv { get; set; }
        public string dias_entrega { get; set; }
        public string horas_entrega { get; set; }
        public string tipo_docto_flex { get; set; }
        public string numero_flex { get; set; }
        public Nullable<System.DateTime> fecha_proceso { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string gln { get; set; }
        public Nullable<int> cod_cliente { get; set; }
        public Nullable<int> cod_cotizacion { get; set; }
        public string tienda { get; set; }
        public string adjunto_correcto { get; set; }
        public string path_pdf { get; set; }
        public string bodega { get; set; }
        public string motivo_retenido{ get; set; }
        public Nullable<int> sincro { get; set; }
        public List<mov_pedidos_detalle_ps> DetallePedido { get; set; }

    }
}
