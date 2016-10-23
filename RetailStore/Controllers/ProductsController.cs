using RetailStore.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RetailStore.DataAccess.Product;
using RetailStore.DataAccess.DataModel;
using AutoMapper;

namespace RetailStore.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/Products
        /// <summary>
        /// Get all product available
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductInfo> GetAllProducts()
        {
             ProductService ObjProductList = new ProductService();
            Mapper.CreateMap<ProductInfoData, ProductInfo>();

            ProductInfoData[] ObjProductData = ObjProductList.GetAllProducts();

            return Mapper.Map<ProductInfoData[], ProductInfo[]>(ObjProductData);
        }
        /// <summary>
        /// Get product info for given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetProduct(int id)
        {
            var product = GetAllProducts().FirstOrDefault((p) => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // GET api/Products/5
        public string Get(int id)
        {
            return "product";
        }

        // POST api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Products/5
        public void Delete(int id)
        {
        }
    }
}