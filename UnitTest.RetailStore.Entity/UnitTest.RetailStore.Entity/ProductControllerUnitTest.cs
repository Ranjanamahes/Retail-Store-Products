using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using RetailStore.WebAPI.Common;
using RetailStore.Model;
using RetailStore.WebAPI.Controllers;
using System.Web.Http;
using System.Net;

namespace UnitTest.RetailStore.WebApi
{
    [TestClass]
    public class ProductControllerUnitTest
    {
        [TestMethod]
        public void TestProductNegativeTesting()
        {
            var productController = new ProductsController();
            IHttpActionResult actionResult = productController.Get(1);
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void TestProductPositive()
        {
            var productController = new ProductsController();
            var response = productController.Get(5555);
            var prod = response as OkNegotiatedContentResult<ProductModel>;
            Assert.AreEqual(5555, prod.Content.ProductId);
        }

        [TestMethod]
        public void TestProductPutPositive()
        {
            var productController = new ProductsController();
            ProductModel productUpdate = new ProductModel();
            productUpdate.ProductId = 5555;
            productUpdate.Name = "Stroller12";
            productUpdate.Category = "baby";
            productUpdate.Last_Updated = DateTime.Now;
            productUpdate.SKU = "AEX123";
            var response = productController.Put(productUpdate.ProductId,productUpdate);

            var prod = response as NegotiatedContentResult<ProductModel>;

            Assert.IsNotNull(prod);
            Assert.AreEqual(HttpStatusCode.Accepted, prod.StatusCode);
            Assert.IsNotNull(prod.Content);
            Assert.AreEqual(5555, prod.Content.ProductId);
            Assert.AreEqual(productUpdate.Name, prod.Content.Name);
        }

        [TestMethod]
        public void TestProductPutNegative()
        {
            var productController = new ProductsController();
            ProductModel productUpdate = new ProductModel();
            productUpdate.ProductId = 7000;
            productUpdate.Name = "Thin Bed2";
            productUpdate.Category = "baby";
            productUpdate.Last_Updated = DateTime.Now;
            productUpdate.SKU = "MAH709";
            var response = productController.Put(productUpdate.ProductId, productUpdate);
            var prod = response as NegotiatedContentResult<ProductModel>;
            Assert.IsNull(prod);
            Assert.IsInstanceOfType(response, typeof(NotFoundResult));
        }

        [TestMethod]
        public void TestProductPostPositive()
        {
            var productController = new ProductsController();
            ProductModel productUpdate = new ProductModel();
            productUpdate.Name = "Stroller7003";
            productUpdate.Category = "baby";
            productUpdate.Last_Updated = DateTime.Now;
            productUpdate.SKU = "AEX734";
            var response = productController.Post(productUpdate);

            var prod = response as CreatedAtRouteNegotiatedContentResult<ProductModel>;
            Assert.AreEqual(productUpdate.Name, prod.Content.Name);
        }

        [TestMethod]
        public void TestProductByCategoryNamePositive()
        {
            var categoryController = new CategoryController();
            var response =categoryController.GetByName("baby");
            var prod = response as OkNegotiatedContentResult<ProductModel[]>;
            Assert.IsNotNull(prod);
            Assert.AreEqual(prod.Content[0].Category, "baby");
        }

    }
}
