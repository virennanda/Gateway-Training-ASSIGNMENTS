namespace ProductManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageFileAttributesAddedToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "SmallImage", c => c.String());
            AddColumn("dbo.Products", "LargeImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "LargeImage");
            DropColumn("dbo.Products", "SmallImage");
        }
    }
}
