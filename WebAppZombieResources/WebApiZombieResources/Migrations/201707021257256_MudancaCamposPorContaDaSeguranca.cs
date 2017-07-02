namespace WebApiZombieResources.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudancaCamposPorContaDaSeguranca : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SOBR_SOBREVIVENTES", "SOBR_GENERO", c => c.String(maxLength: 1));
            AlterColumn("dbo.SOBR_SOBREVIVENTES", "SOBR_LOGIN", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.SOBR_SOBREVIVENTES", "SOBR_ISADMIN", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SOBR_SOBREVIVENTES", "SOBR_ISADMIN", c => c.Boolean());
            AlterColumn("dbo.SOBR_SOBREVIVENTES", "SOBR_LOGIN", c => c.String(maxLength: 100));
            AlterColumn("dbo.SOBR_SOBREVIVENTES", "SOBR_GENERO", c => c.String(maxLength: 2));
        }
    }
}
