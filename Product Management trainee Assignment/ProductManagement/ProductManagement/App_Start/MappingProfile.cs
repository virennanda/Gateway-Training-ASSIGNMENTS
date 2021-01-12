using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  AutoMapper;
using ProductManagement.Dtos;
using ProductManagement.Models;

namespace ProductManagement.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Domain To Data transfer object
            Mapper.CreateMap<Product,ProductDto>();
            Mapper.CreateMap<Category,CategoryDto>();

            //Data transfer object to Domain
            Mapper.CreateMap<ProductDto,Product>();
            Mapper.CreateMap<CategoryDto,Category>();
        }
    }
}