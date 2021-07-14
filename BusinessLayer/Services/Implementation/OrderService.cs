using AutoMapper;
using BusinessLayer.Dtos.Orders;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Entities;
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
    public class OrderService : IOrderService
    {
        MsSqlContext context;
        IMapper mapper;

        public OrderService(MsSqlContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<OrderReadDto> Create(int Customer_ID, OrderCreateDto orderDto)
        {
            var orderEntity = mapper.Map<Orders>(orderDto);
            orderEntity.Customer_ID = Customer_ID;
            orderEntity.CreatedDate = DateTime.Now;

            context.Orders.Add(orderEntity);
            await context.SaveChangesAsync();                        
                
            var orderReadDto = mapper.Map<OrderReadDto>(orderEntity);
            return orderReadDto;
        }

        public async Task<IEnumerable<OrderReadDto>> Get(int Customer_ID)
        {
            var orders = await context.Orders.Where(x => x.Customer_ID == Customer_ID).ToListAsync();
            var result = mapper.Map<IEnumerable<OrderReadDto>>(orders);
            return result;
        }

        public async Task<OrderReadDto> Get(int Customer_ID, int Order_ID)
        {
            var order = await context.Orders
                .Where(x => x.Customer_ID == Customer_ID)
                .Where(x => x.Order_ID == Order_ID)
                .FirstOrDefaultAsync();
            var result = mapper.Map<OrderReadDto>(order);
            return result;
        }

        public async Task Update(int Order_ID, int Customer_ID, OrderUpdateDto orderDto)
        {
            var orderEntity = await context.Orders
                .Where(x => x.Customer_ID == Customer_ID)
                .Where(x => x.Order_ID == Order_ID)               
                .FirstOrDefaultAsync();

            mapper.Map(orderDto, orderEntity);

            await context.SaveChangesAsync();            
        }
    }
}
