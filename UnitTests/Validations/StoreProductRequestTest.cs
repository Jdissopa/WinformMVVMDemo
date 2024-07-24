using System;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMDemo.Interfaces;
using MVVMDemo.Models;
using MVVMDemo.Validations;
using UnitTests.Utils;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Validations
{
    [TestClass]
    public class StoreProductRequestTest
    {

        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void Test_Number_Greater_Than_Negative()
        {
            StoreProductRequest _productStore = new StoreProductRequest(); 
            Product product = new Product { Name = "ทดสอบ", Price = -1 };
            Product validatedProduct = _productStore.Validated(product);
            Assert.IsNull(validatedProduct);
            Assert.AreEqual("ราคาไม่สามารถติดลบได้", _productStore.GetNotifications().ErrorMessages[0]);

            _productStore = new StoreProductRequest();
            product = new Product { Name = "ทดสอบ", Price = 5 };
            validatedProduct = _productStore.Validated(product);
            Assert.IsNotNull(validatedProduct);
            Assert.AreEqual(product.Name, validatedProduct.Name);
            Assert.AreEqual(product.Price, validatedProduct.Price);
            Assert.IsTrue(_productStore.GetNotifications().ErrorMessages.Count == 0);
        }

        [TestMethod]
        public void Test_Require_Product_Name()
        {
            StoreProductRequest _productStore = new StoreProductRequest();
            Product product = new Product { Name = "", Price = 5 };
            Product validatedProduct = _productStore.Validated(product);
            Assert.IsNull(validatedProduct);
            Assert.AreEqual("ชื่อผลิตภัณฑ์จะต้องไม่เป็นช่องว่าง", _productStore.GetNotifications().ErrorMessages[0]);

            _productStore = new StoreProductRequest();
            product = new Product { Name = "   ", Price = 5 };
            validatedProduct = _productStore.Validated(product);
            Assert.IsNull(validatedProduct);
            Assert.AreEqual("ชื่อผลิตภัณฑ์จะต้องไม่เป็นช่องว่าง", _productStore.GetNotifications().ErrorMessages[0]);

            _productStore = new StoreProductRequest();
            product = new Product { Name = "ทดสอบ", Price = 5 };
            validatedProduct = _productStore.Validated(product);
            Assert.IsNotNull(validatedProduct);
            Assert.AreEqual(product.Name, validatedProduct.Name);
            Assert.AreEqual(product.Price, validatedProduct.Price);
            Assert.IsTrue(_productStore.GetNotifications().ErrorMessages.Count == 0);
        }

        [TestMethod]
        public void Test_Product_Name_No_More_Than_255()
        {
            StoreProductRequest _productStore = new StoreProductRequest();
            Product product = new Product { Name = RandomStringGenerator.GenerateRandomString(700), Price = 5 };
            Product validatedProduct = _productStore.Validated(product);
            Assert.IsNull(validatedProduct);
            Assert.AreEqual("ชื่อผลิตภัณฑ์จะต้องมีขนาดน้อยกว่า 255 ตัว", _productStore.GetNotifications().ErrorMessages[0]);

            _productStore = new StoreProductRequest();
            product = new Product { Name = RandomStringGenerator.GenerateRandomString(255), Price = 5 };
            validatedProduct = _productStore.Validated(product);
            Assert.IsNotNull(validatedProduct);
            Assert.AreEqual(product.Name, validatedProduct.Name);
            Assert.AreEqual(product.Price, validatedProduct.Price);
            Assert.IsTrue(_productStore.GetNotifications().ErrorMessages.Count == 0);
        }
    }
}
