namespace eUseControl.BussinesLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostTables", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostTables", "Title");
        }
    }
}
