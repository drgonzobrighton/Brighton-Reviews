namespace BrightonReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Req : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VenueTypes", "Cathegory", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VenueTypes", "Cathegory", c => c.String());
        }
    }
}
