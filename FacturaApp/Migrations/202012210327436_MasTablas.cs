namespace FacturaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MasTablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalleFacturas",
                c => new
                    {
                        DetalleFacturaId = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        FacturaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetalleFacturaId)
                .ForeignKey("dbo.Productos", t => t.ProductoId, cascadeDelete: true)
                .ForeignKey("dbo.Facturas", t => t.FacturaId, cascadeDelete: true)
                .Index(t => t.ProductoId)
                .Index(t => t.FacturaId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Edad = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        FacturaId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FacturaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.DetalleFacturas", "FacturaId", "dbo.Facturas");
            DropForeignKey("dbo.DetalleFacturas", "ProductoId", "dbo.Productos");
            DropIndex("dbo.Facturas", new[] { "ClienteId" });
            DropIndex("dbo.DetalleFacturas", new[] { "FacturaId" });
            DropIndex("dbo.DetalleFacturas", new[] { "ProductoId" });
            DropTable("dbo.Facturas");
            DropTable("dbo.Clientes");
            DropTable("dbo.DetalleFacturas");
        }
    }
}
