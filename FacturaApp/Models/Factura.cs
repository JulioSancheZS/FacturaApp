using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturaApp.Models
{
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public List<DetalleFactura>  DetalleFacturas {get;set;}
    }
}