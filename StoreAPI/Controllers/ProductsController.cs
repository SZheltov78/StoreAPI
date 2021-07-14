using BusinessLayer.Dtos.Products;
using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Attributes;
using StoreAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeCustomer]
    public class ProductsController : CustomerController
    {
        IProductService ProductService;
        public ProductsController(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductReadDto>> Get()
        {
            return await ProductService.Get();
        }

        [HttpGet("{Product_ID}")]
        public async Task<ActionResult<ProductReadDto>> Get(int Product_ID)
        {
            var result = await ProductService.Get(Product_ID);
            if (result == null) return NotFound();
            return result;
        }
    }
}
