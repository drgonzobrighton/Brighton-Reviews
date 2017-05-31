namespace BrightonReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Annotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "ReviewBody", c => c.String(nullable: false));
            AlterColumn("dbo.Reviews", "ReviewerName", c => c.String(nullable: false));
            AlterColumn("dbo.Venues", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Venues", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Venues", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Venues", "Description", c => c.String());
            AlterColumn("dbo.Venues", "Address", c => c.String());
            AlterColumn("dbo.Venues", "Name", c => c.String());
            AlterColumn("dbo.Reviews", "ReviewerName", c => c.String());
            AlterColumn("dbo.Reviews", "ReviewBody", c => c.String());
        }
    }
}
