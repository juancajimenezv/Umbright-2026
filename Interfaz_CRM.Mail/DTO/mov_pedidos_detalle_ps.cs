using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaz_CRM.Mail.DTO
{
    public class mov_pedidos_detalle_ps
    {

        public int Id { get; set; }
        public int cod_pedido { get; set; }
        public int linea { get; set; }
        public string cod_producto_flex { get; set; }
        public string nombre_producto { get; set; }
        public double cantidad { get; set; }
        public double precio { get; set; }
        public double total_linea { get; set; }
        public string marca { get; set; }
        public string centro_costo { get; set; }
        public string gasto { get; set; }
        public string rubro { get; set; }
        public string comentario { get; set; }
        public string gtin { get; set; }
        public string idbuyer { get; set; }
        public string idu12 { get; set; }
        public string idu13 { get; set; }
        public string idsupplier { get; set; }
        public string unitofMesure { get; set; }
        public string empresa { get; set; }

    }
}
