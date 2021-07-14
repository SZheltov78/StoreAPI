using BusinessLayer.Dtos.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IOrderService
    {        
        Task<IEnumerable<OrderReadDto>> Get(int Customer_ID);
        Task<OrderReadDto> Get(int Customer_ID, int Order_ID);
        
        Task Update(int Order_ID, int Customer_ID, OrderUpdateDto order);        
        Task<OrderReadDto> Create(int Customer_ID, OrderCreateDto order);          
    }
}
