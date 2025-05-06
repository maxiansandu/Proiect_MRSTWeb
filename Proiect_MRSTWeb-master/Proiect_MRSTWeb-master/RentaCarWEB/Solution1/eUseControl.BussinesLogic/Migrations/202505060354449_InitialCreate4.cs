namespace eUseControl.BussinesLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        SessionToken = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiresAt = c.DateTime(),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserSessions");
        }
    }
}
