namespace BrightonReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgURL2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Venues", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Venues", "ImageURL", c => c.String(nullable: false));
        }
    }
}
