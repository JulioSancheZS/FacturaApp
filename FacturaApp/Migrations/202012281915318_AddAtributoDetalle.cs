namespace FacturaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAtributoDetalle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetalleFacturas", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetalleFacturas", "Total");
        }
    }
}
