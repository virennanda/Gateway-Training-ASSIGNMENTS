namespace ProductManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class DeleteAllProducts : DbMigration
    {
        public override void Up()
        {
            //delete all records from product

            Sql("delete from Products");
        }

        public override void Down()
        {

        }
    }
}
