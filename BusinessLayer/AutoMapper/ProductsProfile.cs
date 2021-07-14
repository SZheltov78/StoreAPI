using AutoMapper;
using BusinessLayer.Dtos.Products;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Utils.AutoMapper
{
    public class ProductsProfile: Profile
    {
        public ProductsProfile()
        {          
            CreateMap<Products, ProductReadDto>();          
            CreateMap<Products, IEnumerable<ProductReadDto>>();          
        }
    }
}
