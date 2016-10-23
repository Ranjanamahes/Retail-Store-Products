using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RetailStore.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RetailStore.DataAccess.Product;
using RetailStore.Model;
using MSTestExtensions;
using System.Runtime.Serialization;
using RetailStore.CommonLibrary;

namespace UnitTest.RetailStore.EntityDB
{
    [TestClass]
    public class ProductEntityUnitTest : BaseTest
    {

        [TestMethod]
        public void GetProductByIdNegativeEnityTesting()
        {
            ProductModel dataTesting = null;
            ProductRepository ObjProductList = new ProductRepository();
            ProductModel ObjProductData = ObjProductList.GetProductByID(1);
            Assert.AreEqual(ObjProductData, dataTesting);
        }

        [TestMethod]
        public void GetProductByIdNegativeEnityTestingThrowException()
        {
            ProductRepository ObjProductList = new ProductRepository();
            AppAssert.Throws<SerializationException>(() => ObjProductList.GetProductByID(1));
       }


         [TestMethod]
        public void GetProductByIdPostiveEntityTesting()
        {
            ProductModel dataTesting = new ProductModel();
            dataTesting.ProductId = 5555;


            ProductRepository ObjProductList = new ProductRepository();
            ProductModel ObjProductData = ObjProductList.GetProductByID(dataTesting.ProductId);
            Assert.AreEqual(dataTesting.ProductId, ObjProductData.ProductId);


        }
    }

   
}
