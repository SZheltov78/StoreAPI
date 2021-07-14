using AutoMapper;
using BusinessLayer.Dtos.Products;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using MsSqlAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Implementation
{
    public class ProductService : IProductService
    {
        MsSqlContext context;
        IMapper mapper;

        public ProductService(MsSqlContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductReadDto>> Get()
        {
            var products = await context.Products.ActualProducs().ToListAsync();
            var result = mapper.Map<IEnumerable<ProductReadDto>>(products);
            return result;
        }

        public async Task<ProductReadDto> Get(int Product_ID)
        {
            var product = await context.Products.ActualProduct(Product_ID).FirstOrDefaultAsync();
            var result = mapper.Map<ProductReadDto>(product);
            return result;
        }
    }
}
