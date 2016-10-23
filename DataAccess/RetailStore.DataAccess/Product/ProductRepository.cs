using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailStore.Entity;
using RetailStore.Model;
using AutoMapper;
using System.Data.Objects;
using RetailStore.CommonLibrary;
using RetailStore.DataAccess.Common;

namespace RetailStore.DataAccess.Product
{
    public class ProductRepository
    {
        public ProductRepository()
        {
            DataAutoMapper.BootStrap();
        }
        public ProductModel[] GetAllProducts()
        {
            try
            {
                RetailStoreEntities productEntity = new RetailStoreEntities();
                ObjectResult<RetailStore_spr_GetAllProducts_Result> spResult = productEntity.RetailStore_spr_GetAllProducts();
                 return DataAutoMapper.mapper.Map<RetailStore_spr_GetAllProducts_Result[], ProductModel[]>(spResult.ToArray());
            }
            catch (Exception ex)
            {
                AppExceptionHandling.LogException("RetailStore/ProductService/GetAllProducts", ex);
                return null; // throw custom exception here.
            }

        }
        public ProductModel GetProductByID(int? product)
        {
            try
            {
                RetailStoreEntities productEntity = new RetailStoreEntities();
                ObjectResult<RetailStore_spr_GetProductByID_Result> spResult = productEntity.RetailStore_spr_GetProductByID(product);
                return DataAutoMapper.mapper.Map<RetailStore_spr_GetProductByID_Result, ProductModel>(spResult.FirstOrDefault());
            }
            catch (Exception ex)
            {
                AppExceptionHandling.LogException("RetailStore/ProductService/GetProductByID", ex);
                return null; // throw custom exception here.
            }
        }

        public ProductModel[] GetProductByCategorName(string CategoryName)
        {
            try
            {
                RetailStoreEntities productEntity = new RetailStoreEntities();
                ObjectResult<RetailStore_spr_GetProductByCategoryName_Result> spResult = productEntity.RetailStore_spr_GetProductByCategoryName(CategoryName);
                return DataAutoMapper.mapper.Map<RetailStore_spr_GetProductByCategoryName_Result[], ProductModel[]>(spResult.ToArray());
            }
            catch (Exception ex)
            {
                AppExceptionHandling.LogException("RetailStore/ProductService/GetProductByCategoryName", ex);
                return null; // throw custom exception here.
            }

        }



        public int? SaveProduct(ProductModel product)
        {
            try
            {
                RetailStoreEntities productEntity = new RetailStoreEntities();
                ObjectResult<int?> spResult = productEntity.RetailStore_spUpsert_Product(product.ProductId, false, product.SKU, product.Name, product.Category);
                return spResult.FirstOrDefault();
            }
            catch (Exception ex)
            {
                AppExceptionHandling.LogException("RetailStore/ProductService/SaveProduct", ex);
                return null; // throw custom exception here.
            }

        }


    }
}
