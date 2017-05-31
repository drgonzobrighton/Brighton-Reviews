namespace BrightonReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class titleadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "ReviewTitle", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "ReviewTitle");
        }
    }
}
