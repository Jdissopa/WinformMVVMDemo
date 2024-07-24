using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMDemo;
using MVVMDemo.Validations;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private StoreProductRequest _productStore;

        [TestInitialize]
        public void Setup()
        {
            _productStore = new StoreProductRequest();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }
    }
}
