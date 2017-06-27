namespace WebApiZombieResources.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicaoColunaSaldos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.INV_INVENTARIO", "INVENTARIO_QTD", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.INV_INVENTARIO", "INVENTARIO_QTD");
        }
    }
}
