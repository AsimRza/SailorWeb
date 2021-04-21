namespace SailorWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Team_TBL", "TeamImg",c=>c.String());
            
        }

        public override void Down()
        {
        }
    }
}
