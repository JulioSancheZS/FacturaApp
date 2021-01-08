using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturaApp.Models.ViewModel
{
    public class FacturaViewModel
    {
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleFacturaViewModel> DetalleFacturaViewModels { get; set; }
    }

    public class DetalleFacturaViewModel
    {
        public int ProductoId { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        
      
    }

}