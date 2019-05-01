namespace TicketTrackingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserEmail = c.String(),
                        Password = c.String(),
                        UserRole = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
