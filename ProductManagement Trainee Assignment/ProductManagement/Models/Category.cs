using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}