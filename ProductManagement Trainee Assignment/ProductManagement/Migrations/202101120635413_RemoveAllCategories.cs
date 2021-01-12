namespace ProductManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAllCategories : DbMigration
    {
        public override void Up()
        {
            Sql("delete from categories");
        }
        
        public override void Down()
        {
        }
    }
}
