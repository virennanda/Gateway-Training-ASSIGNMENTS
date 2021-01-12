using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
       
        [Required]
        [StringLength(255,ErrorMessage ="Product Name should be within 255 characters")]
        public string Name { get; set; }
        
        public Category Category{ get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        
        [Required]
        [Range(1,Int64.MaxValue,ErrorMessage ="Price of product should be a positive Value")]
        public int Price { get; set; }

        [Required]
        [Range(1,Int16.MaxValue,ErrorMessage ="Product Quantity should be a positive Value")]
        public int Quantity { get; set; }

        [Required]
        [StringLength(500,ErrorMessage="We require a Short Description. Maximum 500 characters only")]
        public string ShortDescription { get; set; }
 
        public string LongDescription { get; set; }

        public string SmallImage { get; set; }

        public string LargeImage { get; set; }
        
        

      }
}