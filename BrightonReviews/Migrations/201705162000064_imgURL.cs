namespace BrightonReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venues", "ImageURL", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Venues", "ImageURL");
        }
    }
}
