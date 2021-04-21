namespace SailorWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusToBlogCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogCategory_TBL", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogCategory_TBL", "Status");
        }
    }
}
