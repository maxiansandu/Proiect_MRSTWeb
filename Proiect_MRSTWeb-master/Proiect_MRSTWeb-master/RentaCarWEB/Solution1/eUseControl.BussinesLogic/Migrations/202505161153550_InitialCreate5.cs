namespace eUseControl.BussinesLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnuceDBTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        author = c.String(),
                        img = c.String(),
                        Marca = c.String(),
                        model = c.String(),
                        an = c.Int(nullable: false),
                        engine = c.Int(nullable: false),
                        fuel = c.String(),
                        price = c.Int(nullable: false),
                        location = c.String(),
                        phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AnuceDBTables");
        }
    }
}
