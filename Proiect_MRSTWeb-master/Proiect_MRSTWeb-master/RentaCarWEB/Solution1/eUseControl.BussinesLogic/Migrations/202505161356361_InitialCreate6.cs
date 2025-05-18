namespace eUseControl.BussinesLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AnuceDBTables", newName: "PostTables");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PostTables", newName: "AnuceDBTables");
        }
    }
}
