
CREATE PROCEDURE [dbo].[RetailStore_spUpsert_Product]

/***********************************************************************  
**  Title:          [dbo].[RetailStore_spUpsert_Product]
**
**  Creation Date:    
**
**  Author:			Maheswari Rangaraj
**
**  Description:	Store procedure to save the data 
**  
**  Parameters:  
**	
**	@ProductId INT = NULL,
	@delete BIT = NULL,
	@SKU NVARCHAR(100)
	@Name NVARCHAR(250) = NULL,
	@Category NVARCHAR(250) = NULL,
    @Last_Updated Datetime=NULL
**         
**  Object Dependency:      **                     
**
**     Tables: 
**                   [dbo].[RetailStore_Product]
**
**     Stored Procdures:
**                   None
**
**     Views:
**                   None   
**
**
**	Revision History:  
***********************************************************************/

	@ProductId INT = NULL,
	@delete BIT = NULL,
	@SKU NVARCHAR(100),
	@Name NVARCHAR(250) = NULL,
	@Category NVARCHAR(250) = NULL

	AS

BEGIN

DECLARE @InsertedRow TABLE(ProductId INT);
DECLARE @EntityPrimaryKey VARCHAR(256) = CONVERT(VARCHAR, @ProductId)

BEGIN TRY  
		SET @delete = ISNULL(@delete,0);
		DECLARE @ERROR_MESSAGE VARCHAR(500)

	IF @delete = 0 
			AND EXISTS(SELECT TOP 1 ProductId  FROM [RetailStore_Product] 
									WHERE Name = @Name AND ProductId<>@ProductId )
			BEGIN
				SET @ERROR_MESSAGE = 'Duplicate entry, record already exists'
				RAISERROR(70000,16,1,@ERROR_MESSAGE)
			END

BEGIN TRANSACTION

		MERGE [dbo].[RetailStore_Product] AS target
		USING  (SELECT @ProductId,@SKU,@Name,@Category,GETDATE())  AS source 
		(ProductId,SKU,Name,Category,Last_Updated)
		ON (target.ProductId = @ProductId)
		WHEN MATCHED AND @delete = 1 THEN DELETE 
		WHEN MATCHED AND @delete = 0 THEN   
			UPDATE
			SET 
			[SKU] = source.SKU,
			[Name] = source.Name,
			[Category] = source.Category,
			[Last_Updated] = source.Last_Updated
		WHEN NOT MATCHED AND @delete = 0 THEN  
			INSERT 
				(SKU,Name,Category,Last_Updated)
			VALUES
				(source.SKU, source.Name,source.Category, GETDATE())

		OUTPUT inserted.ProductId into @InsertedRow;
		SELECT ProductId from @InsertedRow
	
	
	COMMIT TRANSACTION
 END TRY

BEGIN CATCH
	DECLARE @Error VARCHAR(4000) = ERROR_MESSAGE(),
			@Error_Number INT = ERROR_NUMBER()

	IF (@@TRANCOUNT>0) ROLLBACK TRANSACTION
	IF (@Error_Number>50000)
		RAISERROR (@Error_Number, 16, 1,@Error)
	ELSE
		RAISERROR (@Error, 16, 1)
END CATCH
END

