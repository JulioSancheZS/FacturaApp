using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturaApp.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required]
        public decimal PrecioVenta { get; set; }
        public int CategoriaId { get; set; }
    }
}