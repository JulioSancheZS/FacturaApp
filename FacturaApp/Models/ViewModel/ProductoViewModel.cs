using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturaApp.Models.ViewModel
{
    public class ProductoViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public decimal PrecioVenta { get; set; }
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
    }
}