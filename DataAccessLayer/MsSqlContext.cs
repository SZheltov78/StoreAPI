using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace MsSqlAccessLayer
{
    public class MsSqlContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }

        public MsSqlContext(DbContextOptions<MsSqlContext> options) : base(options)
        {
            Database.EnsureCreated(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customers>().HasData(new Customers[] {
                new Customers
                {
                    Customer_ID = 1,
                    Name = "Магазин Ромашка",
                    INN = "003841823784193413",
                    Token = "111"
                },
                new Customers
                {
                    Customer_ID = 2,
                    Name = "Магазин Весна",
                    INN = "001348120934912834",
                    Token = "222"
                }
           });

            modelBuilder.Entity<Products>().HasData(new Products[]{
                new Products
                {
                    Product_ID = 1,
                    Name = "картофель",
                    Price = 5000,
                    Quantity = 5000,
                    IsActiv = true
                },
                new Products
                {
                    Product_ID = 2,
                    Name = "морковь",
                    Price = 7000,
                    Quantity = 15000,
                    IsActiv = true

                },new Products
                {
                    Product_ID = 3,
                    Name = "свекла",
                    Price = 4000,
                    Quantity = 10000,
                    IsActiv = false
                },
            });
        }
    }
}
