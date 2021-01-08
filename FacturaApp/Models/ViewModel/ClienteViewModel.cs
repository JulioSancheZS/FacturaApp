using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturaApp.Models.ViewModel
{
    public class ClienteViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Apellido { get; set; }
        public string Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}