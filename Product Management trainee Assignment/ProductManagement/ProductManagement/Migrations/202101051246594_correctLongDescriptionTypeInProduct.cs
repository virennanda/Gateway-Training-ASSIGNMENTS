namespace ProductManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctLongDescriptionTypeInProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "LongDescription", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "LongDescription", c => c.Int(nullable: false));
        }
    }
}
