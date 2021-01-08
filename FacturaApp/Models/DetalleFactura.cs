using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturaApp.Models
{
    public class DetalleFactura
    {
        [Key]
        public int DetalleFacturaId { get; set; }
        [Required(ErrorMessage ="Campo Requerido")]
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public int FacturaId { get; set; }

        public decimal Total { get; set; }
    }
}