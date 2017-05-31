namespace BrightonReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updimg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venues", "ImgURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Venues", "ImgURL");
        }
    }
}
