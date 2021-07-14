using BusinessLayer.Dtos.Orders;
using DataAccessLayer.Extensions;
using FluentValidation;
using MsSqlAccessLayer;
using MsSqlAccessLayer.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Validation
{
    public class OrderUpdateDtoValidate : AbstractValidator<OrderUpdateDto>
    {
        MsSqlContext context;
        public OrderUpdateDtoValidate(MsSqlContext context)
        {
            this.context = context;

            RuleFor(x => new { x.Order_ID, x.Customer_ID }).Must( o =>
            {
                var exists = context.Orders
                .Where(x => x.Customer_ID == o.Customer_ID)
                .Where(x => x.Order_ID == o.Order_ID)
                .Where(x => x.Status == OrderStatusCodes.Created || x.Status == OrderStatusCodes.Canceled)
                .Any();
                return exists;
            })
                .WithMessage("Заказ не найден");

            RuleFor(x => x.Product_ID)
                .Must(Product_ID => context.Products.ActualProduct(Product_ID).Any())
                .WithMessage("Продукт не найден");

            RuleFor(x => x.Status).Must(x=>x.Equals(OrderStatusCodes.Created) || x.Equals(OrderStatusCodes.Canceled)).WithMessage("Статус может быть 0(создан) или 3(отменен)");

            RuleFor(x => x.Quantity).InclusiveBetween(10, 1000);
        }        
    }
}
