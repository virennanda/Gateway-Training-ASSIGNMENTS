namespace ProductManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
        SET IDENTITY_INSERT [dbo].[Categories] ON
            INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Home Appliances')
            INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Smart Phones')
            INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Accessories')
            INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Fitness')
            INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (5, N'food and Beverage')
            INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (6, N'Books')
            INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (7, N'Computers')
            INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (8, N'Suppliments')
            INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (9, N'Footware')
            INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (10, N'Clothing')
            INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (11, N'beauty products')
            INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (12, N'glasses')
            INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (13, N'other')
        SET IDENTITY_INSERT [dbo].[Categories] OFF
");
        }

        public override void Down()
        {
        }
    }
}
