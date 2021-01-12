using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Dtos
{
    public class CategoryDto
    {
         public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}