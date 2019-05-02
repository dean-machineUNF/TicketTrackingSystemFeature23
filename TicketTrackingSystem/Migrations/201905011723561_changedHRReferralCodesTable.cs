namespace TicketTrackingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedHRReferralCodesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HRReferralCodes",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HRReferralCodes");
        }
    }
}
