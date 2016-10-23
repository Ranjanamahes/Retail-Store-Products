CREATE TABLE [dbo].[RetailStore_ProductPrice]
(
	[ProductId] INT NOT NULL PRIMARY KEY, 
    [Price] DECIMAL(18, 2) NULL, 
    CONSTRAINT [FK_RetailStore_ProductPrice_ToTable] FOREIGN KEY ([ProductId]) REFERENCES [RetailStore_Product](ProductId)
)
