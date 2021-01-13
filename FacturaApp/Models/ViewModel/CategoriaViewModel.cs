using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturaApp.Models.ViewModel
{
    public class CategoriaViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Descripcion { get; set; }
    }
}