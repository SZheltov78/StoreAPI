using BusinessLayer.Dtos.Orders;
using DataAccessLayer.Extensions;
using FluentValidation;
using MsSqlAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Validation
{
    public class OrderCreateDtoValidate : AbstractValidator<OrderCreateDto>
    {
        MsSqlContext context;
        public OrderCreateDtoValidate(MsSqlContext context)
        {
            this.context = context;

            RuleFor(x => x.Product_ID)
                .Must(Product_ID => context.Products.ActualProduct(Product_ID).Any())
                .WithMessage("Продукт не найден");
            
            RuleFor(x => x.Quantity).InclusiveBetween(10, 1000);

        }
    }
}
