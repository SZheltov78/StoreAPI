using BusinessLayer.Dtos.Orders;
using BusinessLayer.Dtos.Products;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Entities;
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
    public class OrdersController : CustomerController
    {
        IOrderService OrderService;
        public OrdersController(IOrderService OrderService)
        {
            this.OrderService = OrderService;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderReadDto>> Get()
        {            
            return await OrderService.Get(CurrentCustomer.Customer_ID);
        }

        [HttpGet("{Order_ID}")]
        public async Task<ActionResult<OrderReadDto>> Get(int Order_ID)
        {            
            var result = await OrderService.Get(CurrentCustomer.Customer_ID, Order_ID);
            if (result == null) return NotFound();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Create(OrderCreateDto order)
        {
            var newOrder = await OrderService.Create(CurrentCustomer.Customer_ID, order);
            return CreatedAtAction(nameof(Get), new { Order_ID = newOrder.Order_ID }, newOrder);
        }

        [HttpPut("{Order_ID}")]
        public async Task<ActionResult> Update(int Order_ID, [FromBody] OrderUpdateDto order)
        {
            await OrderService.Update(Order_ID, CurrentCustomer.Customer_ID, order);            
            return NoContent();
        }

    }
}
