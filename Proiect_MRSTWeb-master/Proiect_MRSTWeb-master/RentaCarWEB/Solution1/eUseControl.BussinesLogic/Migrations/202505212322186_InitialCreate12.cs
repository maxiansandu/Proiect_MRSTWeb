namespace eUseControl.BussinesLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Favorites", "price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Favorites", "price", c => c.Int(nullable: false));
        }
    }
}
