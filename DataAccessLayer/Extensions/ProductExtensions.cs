using DataAccessLayer.Entities;
using MsSqlAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Extensions
{
    public static class ProductExtensions
    {
        public static IQueryable<Products> ActualProduct(this IQueryable<Products> products, int Product_ID)
        {
            return products.ActualProducs()
                .Where(x => x.Product_ID == Product_ID);                
        }

        public static IQueryable<Products> ActualProducs(this IQueryable<Products> products)
        {
            return products
                .Where(x => x.IsActiv)
                .Where(x => x.Quantity > 10);
        }
    }
}
