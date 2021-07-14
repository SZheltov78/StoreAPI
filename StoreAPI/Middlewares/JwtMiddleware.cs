using Microsoft.AspNetCore.Http;
using MsSqlAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StoreAPI.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate nextMiddleware;
       
        public JwtMiddleware(RequestDelegate nextMiddleware)
        {
            this.nextMiddleware = nextMiddleware;
        }

        public async Task Invoke(HttpContext context, MsSqlContext dbContext)
        {
            //получаем токем
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            //для тестирования не будем проверять токен
            //if (!string.IsNullOrEmpty(token))
            //{
            //    var customer = dbContext.Customers.FirstOrDefault(x => x.Token == token);
            //    if(customer != null)
            //    {
            //        context.Items["Customer"] = customer;
            //    }
            //}

            //для тестирования предтсавляем, что это первый покупатель
            context.Items["Customer"] = dbContext.Customers.FirstOrDefault();           
            
            await nextMiddleware(context);
        }
    }
}
