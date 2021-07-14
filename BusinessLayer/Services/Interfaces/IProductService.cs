using BusinessLayer.Dtos.Products;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductReadDto>> Get();
        Task<ProductReadDto> Get(int Product_ID);
    }
}
