namespace WebApiZombieResources.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoMuitosxMuitos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.REC_RECURSOS", "IdSobrevivente", "dbo.SOBR_SOBREVIVENTES");
            DropIndex("dbo.REC_RECURSOS", new[] { "IdSobrevivente" });
            CreateTable(
                "dbo.INV_INVENTARIO",
                c => new
                    {
                        INVENTARIO_ID = c.Int(nullable: false, identity: true),
                        REC_ID = c.Int(nullable: false),
                        SOBR_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.INVENTARIO_ID)
                .ForeignKey("dbo.REC_RECURSOS", t => t.REC_ID, cascadeDelete: true)
                .ForeignKey("dbo.SOBR_SOBREVIVENTES", t => t.SOBR_ID, cascadeDelete: true)
                .Index(t => t.REC_ID)
                .Index(t => t.SOBR_ID);
            
            CreateTable(
                "dbo.SobreviventeRecursos",
                c => new
                    {
                        Sobrevivente_Id = c.Int(nullable: false),
                        Recursos_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sobrevivente_Id, t.Recursos_Id })
                .ForeignKey("dbo.SOBR_SOBREVIVENTES", t => t.Sobrevivente_Id, cascadeDelete: true)
                .ForeignKey("dbo.REC_RECURSOS", t => t.Recursos_Id, cascadeDelete: true)
                .Index(t => t.Sobrevivente_Id)
                .Index(t => t.Recursos_Id);
            
            DropColumn("dbo.REC_RECURSOS", "IdSobrevivente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.REC_RECURSOS", "IdSobrevivente", c => c.Int(nullable: false));
            DropForeignKey("dbo.INV_INVENTARIO", "SOBR_ID", "dbo.SOBR_SOBREVIVENTES");
            DropForeignKey("dbo.INV_INVENTARIO", "REC_ID", "dbo.REC_RECURSOS");
            DropForeignKey("dbo.SobreviventeRecursos", "Recursos_Id", "dbo.REC_RECURSOS");
            DropForeignKey("dbo.SobreviventeRecursos", "Sobrevivente_Id", "dbo.SOBR_SOBREVIVENTES");
            DropIndex("dbo.SobreviventeRecursos", new[] { "Recursos_Id" });
            DropIndex("dbo.SobreviventeRecursos", new[] { "Sobrevivente_Id" });
            DropIndex("dbo.INV_INVENTARIO", new[] { "SOBR_ID" });
            DropIndex("dbo.INV_INVENTARIO", new[] { "REC_ID" });
            DropTable("dbo.SobreviventeRecursos");
            DropTable("dbo.INV_INVENTARIO");
            CreateIndex("dbo.REC_RECURSOS", "IdSobrevivente");
            AddForeignKey("dbo.REC_RECURSOS", "IdSobrevivente", "dbo.SOBR_SOBREVIVENTES", "SOBR_ID", cascadeDelete: true);
        }
    }
}
