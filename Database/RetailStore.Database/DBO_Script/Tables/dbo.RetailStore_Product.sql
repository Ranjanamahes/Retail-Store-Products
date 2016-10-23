CREATE TABLE [dbo].[RetailStore_Product] (
    [ProductId]    INT            NOT NULL,
    [SKU]          NVARCHAR (100) NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    [Category]     NVARCHAR (50)  NULL,
    [Last_Updated] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC)
);
