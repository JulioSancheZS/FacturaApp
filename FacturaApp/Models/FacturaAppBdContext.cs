using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FacturaApp.Models
{
    public class FacturaAppBdContext : DbContext
    {
        public FacturaAppBdContext() : base("name=FacturaAppDB")
        {
            Database.SetInitializer<FacturaAppBdContext>
                (new CreateDatabaseIfNotExists<FacturaAppBdContext>());
        }

        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
    }
}