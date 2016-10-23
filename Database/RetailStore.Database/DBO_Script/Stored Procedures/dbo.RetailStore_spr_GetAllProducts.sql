
CREATE PROC [dbo].[RetailStore_spr_GetAllProducts]
/***********************************************************************  
**  Title:          [dbo].RetailStore_spr_GetAllProducts

**  Creation Date:    10/22/2016
**
**  Author:  Maheswari Rangaraj
			 
**
**  Description:  Retrieve all products 
**  
**  Parameters: 
**     
**         
**  Object Dependency:      **                     
**
**     Tables: 
**                   RetailStore_Product                              
**
**     Stored Procdures:
**                   None
**
**     Views:
**                   None   
**

**
**Revision History:  
**           
***********************************************************************/
AS 
	

BEGIN TRY  

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

SELECT prod.ProductId, prod.Name, prod.SKU, prod.Category, price.Price, prod.Last_Updated FROM RetailStore_Product  prod (NOLOCK)  LEFT JOIN RetailStore_ProductPrice price (NOLOCK) on prod.ProductId = price.ProductId 

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