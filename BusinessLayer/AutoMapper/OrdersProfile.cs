using DataAccessLayer.Entities;
using AutoMapper;
using BusinessLayer.Dtos.Orders;

namespace BusinessLayer.Utils.AutoMapper
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {            
            CreateMap<Orders, OrderReadDto>();
            CreateMap<OrderCreateDto, Orders>();
            CreateMap<OrderUpdateDto, Orders>();
        }
    }
}
