namespace eUseControl.BussinesLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostTables", "img_1", c => c.String());
            AddColumn("dbo.PostTables", "img_2", c => c.String());
            AddColumn("dbo.PostTables", "img_3", c => c.String());
            AddColumn("dbo.PostTables", "img_4", c => c.String());
            AddColumn("dbo.PostTables", "img_5", c => c.String());
            DropColumn("dbo.PostTables", "img");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostTables", "img", c => c.String());
            DropColumn("dbo.PostTables", "img_5");
            DropColumn("dbo.PostTables", "img_4");
            DropColumn("dbo.PostTables", "img_3");
            DropColumn("dbo.PostTables", "img_2");
            DropColumn("dbo.PostTables", "img_1");
        }
    }
}
