namespace eUseControl.BussinesLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Favorites", "ad_id", c => c.Int(nullable: false));
            DropColumn("dbo.Favorites", "Title");
            DropColumn("dbo.Favorites", "img_1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Favorites", "img_1", c => c.String());
            AddColumn("dbo.Favorites", "Title", c => c.String());
            DropColumn("dbo.Favorites", "ad_id");
        }
    }
}
