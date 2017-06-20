namespace WebApiZombieResources.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCampoValidacaoSobrevivente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SOBR_SOBREVIVENTES", "SOBR_HASH", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SOBR_SOBREVIVENTES", "SOBR_HASH");
        }
    }
}
