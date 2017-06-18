namespace WebApiZombieResources.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.REC_RECURSOS",
                c => new
                    {
                        REC_ID = c.Int(nullable: false, identity: true),
                        REC_DESC = c.String(nullable: false, maxLength: 100),
                        REC_QTD = c.Int(nullable: false),
                        REC_OBS = c.String(maxLength: 100),
                        IdSobrevivente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.REC_ID)
                .ForeignKey("dbo.SOBR_SOBREVIVENTES", t => t.IdSobrevivente, cascadeDelete: true)
                .Index(t => t.IdSobrevivente);
            
            CreateTable(
                "dbo.SOBR_SOBREVIVENTES",
                c => new
                    {
                        SOBR_ID = c.Int(nullable: false, identity: true),
                        SOBR_NOME = c.String(nullable: false, maxLength: 100),
                        SOBR_GENERO = c.String(maxLength: 2),
                        SOBR_IDADE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SOBR_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.REC_RECURSOS", "IdSobrevivente", "dbo.SOBR_SOBREVIVENTES");
            DropIndex("dbo.REC_RECURSOS", new[] { "IdSobrevivente" });
            DropTable("dbo.SOBR_SOBREVIVENTES");
            DropTable("dbo.REC_RECURSOS");
        }
    }
}
