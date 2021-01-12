using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductManagement.Models;

namespace ProductManagement.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}