using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.ViewModels
{
    public class ProductFormViewModel
    {
        public string Title { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}