using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using PM.WebAPI.Controllers;
using PM.WebAPI.Models;

namespace PM.WebAPI.Tests.Controllers
{
    [TestClass]
    class ProductsControllerTest
    {
        public void GetProducts()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            IEnumerable<Product> result = controller.GetProducts();

            // Assert
            Assert.IsNotNull(result);

        }
        
        public void GetProduct()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            var result = controller.GetProduct(17);

            // Assert
            Assert.IsNotNull(result);
        }
    }
    
}
