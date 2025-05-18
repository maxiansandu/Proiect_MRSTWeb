namespace eUseControl.BussinesLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostTables", "description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostTables", "description");
        }
    }
}
