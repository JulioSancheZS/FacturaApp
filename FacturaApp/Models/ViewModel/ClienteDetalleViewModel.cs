using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaApp.Models.ViewModel
{
    public class ClienteDetalleViewModel
    {
        public int IDFactura { get; set; }
        public int ClienteId { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; } 

    }
}