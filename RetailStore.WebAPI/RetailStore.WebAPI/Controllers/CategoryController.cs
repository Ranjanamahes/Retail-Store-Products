using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RetailStore.DataAccess.Product;
using RetailStore.Model;
using RetailStore.WebAPI.Common;


namespace RetailStore.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {

        public IHttpActionResult Get(int id)
        {
            return Ok("Valid Mthod");
        }
        // GET api/<controller>/toys
        public IHttpActionResult GetByName(string Name)
        {
            ProductRepository ObjProductList = new ProductRepository();
            ProductModel[] ObjProductData = ObjProductList.GetProductByCategorName(Name);

            if (ObjProductData == null)
            {
                return NotFound();

            }
            return Ok(ObjProductData);

        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException("This method is not implemented");
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException("This method is not implemented");
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            throw new NotImplementedException("This method is not implemented");
        }
    }
}