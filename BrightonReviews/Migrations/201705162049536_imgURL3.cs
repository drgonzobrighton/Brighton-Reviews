namespace BrightonReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgURL3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venues", "URLImg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Venues", "URLImg");
        }
    }
}
