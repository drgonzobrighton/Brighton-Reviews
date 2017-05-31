namespace BrightonReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagerequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Venues", "ImgURL", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Venues", "ImgURL", c => c.String());
        }
    }
}
