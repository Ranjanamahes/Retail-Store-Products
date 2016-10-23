using RetailStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RetailStore.DataAccess.Product;
using RetailStore.WebAPI.Common;

namespace RetailStore.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/Products
        /// <summary>
        /// Get all product available
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetAllProducts()
        {
            ProductRepository ObjProductList = new ProductRepository();
            ProductModel[] ObjProductData = ObjProductList.GetAllProducts();
            return ObjProductData;
        }

        /// <summary>
        /// Get product info for given ID
        /// </summary>
        /// <returns></returns>
         // GET api/Products/5
        public  IHttpActionResult Get(int id)
        {
            ProductRepository ObjProductList = new ProductRepository();
            ProductModel ObjProductData = ObjProductList.GetProductByID(id);

            if (ObjProductData == null)
            {
                return NotFound();

            }
            return Ok(ObjProductData);
            
        }

        // POST api/Products
        public IHttpActionResult Post(ProductModel productData)
        {
            if (productData == null)
                return BadRequest("Invalid Product");
            ProductRepository ObjProductList = new ProductRepository();
            int? resultId = ObjProductList.SaveProduct(productData);
            if (resultId == null)
            {
                return NotFound();
            }
            productData.ProductId = resultId.Value;
            return CreatedAtRoute(RetailStore.CommonLibrary.AppConfig.RetailStoreWebAPI, new { id = productData.ProductId }, productData);
        }

        // PUT api/Products/5
        public IHttpActionResult Put(int? id, ProductModel productData)
        {
            if (productData == null)
                return BadRequest("Invalid Product");

            ProductRepository ObjProductList = new ProductRepository();
            int? resultId = ObjProductList.SaveProduct(productData);
            if (resultId == null)
            {
                return NotFound();
            }
            productData.ProductId = resultId.Value;
            return Content(HttpStatusCode.Accepted, productData);
        }

        // DELETE api/Products/5
        public void Delete(int id)
        {
            throw new NotImplementedException("This method is not implemented");
        }
    }
}