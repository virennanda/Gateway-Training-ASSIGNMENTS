using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement.Controllers;

namespace ProductManagement.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //create instance
            ProductsController controller = new ProductsController();
            
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void New()
        {
            //create instance
            ProductsController controller = new ProductsController();
            
            // Act
            ViewResult result = controller.New() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void edit()
        {
            //create instance
            ProductsController controller = new ProductsController();
            
            // Act
            ViewResult result = controller.edit(100) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
        
    }
}
