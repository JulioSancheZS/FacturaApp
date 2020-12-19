using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturaApp.Models
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required]
        public string Descripción { get; set; }
        public List<Productos> Productos { get; set; }
    }
}