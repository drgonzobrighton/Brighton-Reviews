namespace BrightonReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Venues", "URLImg");
            DropColumn("dbo.Venues", "ImageURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venues", "ImageURL", c => c.String());
            AddColumn("dbo.Venues", "URLImg", c => c.String());
        }
    }
}
