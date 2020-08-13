USE [MMTShop]
GO

/****** Object: Table [dbo].[ProductCategory] Script Date: 13/08/2020 00:35:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductCategory] (
    [ProductCategoryId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]              VARCHAR (MAX) NOT NULL,
    [FilterSKUFormat]   VARCHAR (MAX) NULL,
    CONSTRAINT [PK_ProductCategory] PRIMARY KEY ([ProductCategoryId])
);


GO

/****** Object: Table [dbo].[Product] Script Date: 13/08/2020 00:38:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product] (
    [ProductId]         INT            IDENTITY (1, 1) NOT NULL,
    [ProductCategoryId] INT            NOT NULL,
    [SKU]               VARCHAR (MAX) NOT NULL,
    [Name]              VARCHAR (MAX) NOT NULL,
    [Description]       VARCHAR (MAX) NULL,
    [Price]             MONEY          NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([ProductId]),
    CONSTRAINT FK_ProductCategoryIdProductCategoryId FOREIGN KEY (ProductCategoryId)
    REFERENCES ProductCategory(ProductCategoryId)
);


GO

/****** Object: Table [dbo].[FeaturedProductSKUFormats] Script Date: 13/08/2020 02:36:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FeaturedProductSKUFormats] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [FilterSKUFormat] VARCHAR (MAX) NOT NULL
);

GO

/****** Object: SqlProcedure [dbo].[spGetProductCategories] Script Date: 13/08/2020 00:39:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Stored procedure to get product categories

CREATE PROCEDURE [dbo].[spGetProductCategories]
	
AS
BEGIN
   
   SET NOCOUNT ON;
   SELECT 
         ProductCategoryId AS ProductCategoryId,
         [Name] AS [Name]
		 FROM ProductCategory;
END

GO

/****** Object: SqlProcedure [dbo].[spGetProductsByCategory] Script Date: 13/08/2020 00:40:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetProductsByCategory]
	@ProductCategoryId int
AS
BEGIN
   
 SELECT
      SKU AS SKU,
      [Name] AS [Name],
      [Description] AS [Description],
      Price AS Price
  FROM [dbo].[Product] 
  WHERE ProductCategoryId = @ProductCategoryId;
END

GO

/****** Object: SqlProcedure [dbo].[spGetFeaturedProducts] Script Date: 13/08/2020 02:38:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Stored procedure to get featured products identified by SKU format filter 
-- Get the products from Product table for categories having filter format listed in the 
-- FeaturedProductSKUFormats table

CREATE PROCEDURE [dbo].[spGetFeaturedProducts]
	
AS
BEGIN
   
   SET NOCOUNT ON;
    SELECT
          p.SKU AS SKU,
          p.[Name] AS [Name],
          p.[Description] AS [Description],
          CAST(p.Price AS DECIMAL(18,2)) AS Price
  FROM [dbo].[Product] p
  INNER JOIN [dbo].[ProductCategory] c
  ON c.ProductCategoryId = p.ProductCategoryId
  WHERE EXISTS 
              (
			     SELECT 
				       f.Id 
				 FROM [dbo].[FeaturedProductSKUFormats] f 
				 WHERE f.FilterSKUFormat = c.FilterSKUFormat 
			  )
END
