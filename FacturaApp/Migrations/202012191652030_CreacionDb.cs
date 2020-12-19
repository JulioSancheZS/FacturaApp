namespace FacturaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Descripción = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(),
                        PrecioVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Productoes", new[] { "CategoriaId" });
            DropTable("dbo.Productoes");
            DropTable("dbo.Categorias");
        }
    }
}
