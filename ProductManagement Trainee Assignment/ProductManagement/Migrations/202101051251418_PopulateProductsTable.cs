namespace ProductManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProductsTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            SET IDENTITY_INSERT [dbo].[Products] ON
                    INSERT INTO [dbo].[Products] ([Id], [Name], [CategoryId], [Price], [Quantity], [ShortDescription], [LongDescription]) VALUES (4, N'Resistance Band', 4, 700, 40, N'Take care of yourself . Be fit and stay healty by excercising with this band', N'')
                    INSERT INTO [dbo].[Products] ([Id], [Name], [CategoryId], [Price], [Quantity], [ShortDescription], [LongDescription]) VALUES (5, N'Mi note 9 pro max', 2, 14000, 20, N'Latest Smartphone by Xiomi to speed up your life', NULL)
                    INSERT INTO [dbo].[Products] ([Id], [Name], [CategoryId], [Price], [Quantity], [ShortDescription], [LongDescription]) VALUES (6, N'Realme Buds', 3, 400, 60, N'Feel the sound of quality with Earphones especially designed for you', NULL)
            SET IDENTITY_INSERT [dbo].[Products] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
