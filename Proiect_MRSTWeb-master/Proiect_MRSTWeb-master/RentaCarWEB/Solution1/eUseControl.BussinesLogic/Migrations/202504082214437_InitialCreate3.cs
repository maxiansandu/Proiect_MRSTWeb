namespace eUseControl.BussinesLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UDBTables", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UDBTables", "email");
        }
    }
}
