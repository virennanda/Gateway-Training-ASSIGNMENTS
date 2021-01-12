namespace ProductManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateProductsTable1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"

            SET IDENTITY_INSERT [dbo].[Products] ON
                    INSERT INTO [dbo].[Products] ([Id], [Name], [CategoryId], [Price], [Quantity], [ShortDescription], [LongDescription], [SmallImage], [LargeImage]) VALUES (24, N'Shoes', 9, 1300, 45, N'Wear good Feel comfortable', N'A pair of navy blue aqua shoes, has regular styling, slip-on detail
                    Synthetic upper
                    Cushioned footbed
                    Textured and patterned outsole
                    Warranty: 2 years
                    Warranty provided by brand/manufacturer', N'~/ProductImages/shoes211506400.jpg', N'~/ProductImages/shoes211506407.jpg')
                    INSERT INTO [dbo].[Products] ([Id], [Name], [CategoryId], [Price], [Quantity], [ShortDescription], [LongDescription], [SmallImage], [LargeImage]) VALUES (25, N'Coconut Oil', 11, 45, 60, N'100% pure coconut oil', N'    Made from 100% pure coconut oil

                        Made with the finest hand-picked and naturally sun-dried coconuts

                        Untouched by hand- goes through 27 quality tests and 5 stage purification process – for 100% purity every time

                        Unique tamper-proof seal- the seal of trust

                        Contains no added preservatives or chemicals', N'~/ProductImages/coconut_oil211729698.jpg', N'~/ProductImages/coconut_oil211729704.jpg')
                    INSERT INTO [dbo].[Products] ([Id], [Name], [CategoryId], [Price], [Quantity], [ShortDescription], [LongDescription], [SmallImage], [LargeImage]) VALUES (26, N'goggles', 12, 999, 30, N'Black Grey Full Rim Round Vincent Chase SHIRELLES VC S10657-C12 Polarized Sunglasses ', N'

                        ✓Round faces have features that make a gentle impression.
                        ✓The forehead and cheeks tend to have a similar width, while the chin is round.
                        ✓Square or rectangular glasses will help sharpen facial contours.
                        ✓Butterfly shape or asymmetrical forms with narrower bottoms enhances facial features.

                    ', N'~/ProductImages/goggles212220669.jpg', N'~/ProductImages/goggles212220674.jpg')
                    INSERT INTO [dbo].[Products] ([Id], [Name], [CategoryId], [Price], [Quantity], [ShortDescription], [LongDescription], [SmallImage], [LargeImage]) VALUES (27, N'HeadPhones', 3, 1999, 60, N'boAt Rockerz 450 Online - Bluetooth Headphones at Best Price', N' ✓ Immersive, wireless audio experience ✓ Comfort with ergonomic earcups ✓ 8H of uninterrupted audio ', N'~/ProductImages/headphones212516493.jpg', N'~/ProductImages/headphones212516591.jpg')
                    INSERT INTO [dbo].[Products] ([Id], [Name], [CategoryId], [Price], [Quantity], [ShortDescription], [LongDescription], [SmallImage], [LargeImage]) VALUES (28, N'Iphone Red Limited edition', 2, 51900, 12, N'This colour makes a difference. Choose (RED). Save lives.', N' Country Of Origin: India & China
                    6.1-inch (15.5 cm) Liquid Retina HD LCD display
                    Water and dust resistant (1 meter for up to 30 minutes, IP67)
                    Single 12MP Wide camera with Portrait mode, Portrait Lighting, Depth Control, Smart HDR, and 4K video up to 60fps
                    7MP TrueDepth front camera system with Portrait mode, Portrait Lighting, Depth Control, and 1080p video ', N'~/ProductImages/IphoneRed212750014.png', N'~/ProductImages/IphoneRed212750020.png')
                    INSERT INTO [dbo].[Products] ([Id], [Name], [CategoryId], [Price], [Quantity], [ShortDescription], [LongDescription], [SmallImage], [LargeImage]) VALUES (29, N'Fruit Juice combo', 5, 150, 50, N'Tropicana 100% Mixed Fruit Juice (200 ml)', N'Complete your daily breakfast routine with a glass of this Tropicana juice which comes with all the benefits of a mixed fruit juice. ... This healthy juice comes with nine different nutrients that revitalise your body and make you feel fresh.', N'~/ProductImages/Juice_pack212958039.jpg', N'~/ProductImages/Juice_pack212958046.jpg')
                    INSERT INTO [dbo].[Products] ([Id], [Name], [CategoryId], [Price], [Quantity], [ShortDescription], [LongDescription], [SmallImage], [LargeImage]) VALUES (30, N'MacBookAir', 7, 91300, 10, N'Apple MGND3HNA MacBook Air (Apple M1 Chip/8GB/256GB SSD/macOS Big Sur/Retina), 33.78 cm (13.3 inch)', N'Our thinnest, lightest notebook, completely transformed by the Apple M1 chip. CPU speeds up to 3.5x faster. GPU speeds up to 5x faster. Our most advanced Neural Engine for up to 9x faster machine learning. The longest battery life ever in a MacBook Air. And a silent, fanless design. This much power has never been this ready to go.', N'~/ProductImages/MacBookAir213149479.png', N'~/ProductImages/MacBookAir213149485.png')
                    INSERT INTO [dbo].[Products] ([Id], [Name], [CategoryId], [Price], [Quantity], [ShortDescription], [LongDescription], [SmallImage], [LargeImage]) VALUES (31, N'Whey Potein', 8, 1800, 25, N'ON (Optimum Nutrition) Gold Standard 100% Whey Protein 2Lbs ( Near Exp )', N'Our unique protein blend delivers 25g protein, 3g leucine, and over 5g of naturally occurring glutamine per serving — all with less than 2g carbs and 1g fat — for the greatest everyday shake. Created using expert filtration systems and the finest ingredients, THE Whey™ has been specially developed to give you the protein you need, to grow and maintain important muscle.2', N'~/ProductImages/Protein_suppliment213345826.png', N'~/ProductImages/Protein_suppliment213345837.png')
                    INSERT INTO [dbo].[Products] ([Id], [Name], [CategoryId], [Price], [Quantity], [ShortDescription], [LongDescription], [SmallImage], [LargeImage]) VALUES (32, N'Samsung Galaxy note 20', 2, 73000, 15, N'One of the flagship tech smartphone.', N'Samsung Galaxy Note 20 smartphone was launched on 5th August 2020. The phone comes with a 6.70-inch touchscreen display with a resolution of 1080x2400 pixels and an aspect ratio of 20:9. Samsung Galaxy Note 20 is powered by a 2.4GHz octa-core Samsung Exynos 990 processor that features 4 cores clocked at 2.4GHz and 4 cores clocked at 1.8GHz. It comes with 8GB of RAM. The Samsung Galaxy Note 20 runs Android 10 and is powered by a 4300mAh non-removable battery', N'~/ProductImages/Samsung_galaxy_note213631334.jpg', N'~/ProductImages/Samsung_galaxy_note213631343.jpg')
                    INSERT INTO [dbo].[Products] ([Id], [Name], [CategoryId], [Price], [Quantity], [ShortDescription], [LongDescription], [SmallImage], [LargeImage]) VALUES (33, N'Camera', 13, 25000, 30, N'Canon PowerShot SX540HS 20.3MP Digital Camera with 50x Optical Zoom (Black) + Memory Card + Camera Case ', N' Sensor: APS-C CMOS sensor with 20.3 MP (high resolution for large prints and image cropping)
                    ISO: 80-3200 sensitivity range (critical for obtaining grain-free pictures, especially in low light)
                    Image Processor: DIGIC 6 with 1 autofocus points (important for speed and accuracy of autofocus and burst photography) ', N'~/ProductImages/Camera213803784.jpg', N'~/ProductImages/Camera213804254.jpg')
                    INSERT INTO [dbo].[Products] ([Id], [Name], [CategoryId], [Price], [Quantity], [ShortDescription], [LongDescription], [SmallImage], [LargeImage]) VALUES (34, N'Britex Analog watch', 3, 600, 35, N'Britex Casino Black Fox Series Analog Watch for Men/Boys - BT6080 ', N'
                        Type - Analog, Dial Shape - Round, Quartz - Movement
                        Strap Type - Belt
                        Strap Color - Black, Dial Color - Black''
                        Occasion - Casual,Formal,Party-wedding
                        Japanese Quartz and Japanese Battery Powered

                    Share
                    Currently unavailable.
                    We don''t know when or if this item will be back in stock.
                    Select delivery location
                    Add to Wish List
                    ', N'~/ProductImages/Watch214056131.jpg', N'~/ProductImages/Watch214227613.jpg')
            SET IDENTITY_INSERT [dbo].[Products] OFF

                ");
        }

        public override void Down()
        {
        }
    }
}
