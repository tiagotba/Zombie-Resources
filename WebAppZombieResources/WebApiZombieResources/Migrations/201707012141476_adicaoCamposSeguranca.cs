namespace WebApiZombieResources.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicaoCamposSeguranca : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SOBR_SOBREVIVENTES", "SOBR_LOGIN", c => c.String(maxLength: 100));
            AddColumn("dbo.SOBR_SOBREVIVENTES", "SOBR_ISADMIN", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SOBR_SOBREVIVENTES", "SOBR_ISADMIN");
            DropColumn("dbo.SOBR_SOBREVIVENTES", "SOBR_LOGIN");
        }
    }
}
