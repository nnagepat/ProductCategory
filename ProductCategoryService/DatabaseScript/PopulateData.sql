USE [MMTShop]
GO

SET IDENTITY_INSERT [dbo].[ProductCategory] ON
INSERT INTO [dbo].[ProductCategory] ([ProductCategoryId], [Name], [FilterSKUFormat]) VALUES (1, N'Home', N'1XXXXX' )
INSERT INTO [dbo].[ProductCategory] ([ProductCategoryId], [Name], [FilterSKUFormat]) VALUES (2, N'Garden',N'2XXXXX')
INSERT INTO [dbo].[ProductCategory] ([ProductCategoryId], [Name], [FilterSKUFormat]) VALUES (3, N'Electronics',N'3XXXXX')
INSERT INTO [dbo].[ProductCategory] ([ProductCategoryId], [Name], [FilterSKUFormat]) VALUES (4, N'Fitness', N'4XXXXX')
INSERT INTO [dbo].[ProductCategory] ([ProductCategoryId], [Name], [FilterSKUFormat]) VALUES (5, N'Toys',N'5XXXXX')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF

GO

SET IDENTITY_INSERT [dbo].[Product] ON
INSERT INTO [dbo].[Product] ([ProductId], [ProductCategoryId], [SKU], [Name], [Description], [Price]) VALUES (2, 1, N'1ABC00', N'sofa', N'test sofa', CAST(20.0000 AS Money))
INSERT INTO [dbo].[Product] ([ProductId], [ProductCategoryId], [SKU], [Name], [Description], [Price]) VALUES (3, 2, N'2abcx', N'plants', N'test plants', CAST(40.0000 AS Money))
INSERT INTO [dbo].[Product] ([ProductId], [ProductCategoryId], [SKU], [Name], [Description], [Price]) VALUES (4, 3, N'3aqdkc', N'TV', N'test Tv', CAST(200.0000 AS Money))
INSERT INTO [dbo].[Product] ([ProductId], [ProductCategoryId], [SKU], [Name], [Description], [Price]) VALUES (5, 3, N'3rehtb', N'Microwave', N'test microwave', CAST(100.0000 AS Money))
INSERT INTO [dbo].[Product] ([ProductId], [ProductCategoryId], [SKU], [Name], [Description], [Price]) VALUES (7, 4, N'4adxcf', N'CrossTrainer', N'test CrossTrainer', CAST(300.0000 AS Money))
INSERT INTO [dbo].[Product] ([ProductId], [ProductCategoryId], [SKU], [Name], [Description], [Price]) VALUES (8, 5, N'5QWEDf', N'Toy Car', N'test Toy car', CAST(30.0000 AS Money))
SET IDENTITY_INSERT [dbo].[Product] OFF

GO

SET IDENTITY_INSERT [dbo].[FeaturedProductSKUFormats] ON
INSERT INTO [dbo].[FeaturedProductSKUFormats] ([Id], [FilterSKUFormat]) VALUES (1, N'3XXXXX');
INSERT INTO [dbo].[FeaturedProductSKUFormats] ([Id], [FilterSKUFormat]) VALUES (2, N'4XXXXX')
SET IDENTITY_INSERT [dbo].[FeaturedProductSKUFormats] OFF

