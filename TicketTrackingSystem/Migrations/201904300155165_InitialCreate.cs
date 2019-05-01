namespace TicketTrackingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        TicketDescription = c.String(),
                        TicketComment = c.String(),
                        TicketSeverity = c.String(),
                        TicketDateCreated = c.DateTime(nullable: false),
                        TicketIsResolved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TicketID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tickets");
        }
    }
}
