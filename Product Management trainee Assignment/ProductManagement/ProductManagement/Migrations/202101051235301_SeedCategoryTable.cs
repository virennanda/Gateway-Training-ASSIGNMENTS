namespace ProductManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[Categories] ON");
            Sql("INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Home Appliances')");
            Sql("INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Smart Phones')");
            Sql("INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Accessories')");
            Sql("INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Fitness')");
            Sql("SET IDENTITY_INSERT [dbo].[Categories] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
