using MsSqlAccessLayer.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Dtos.Orders
{
    public class OrderCreateDto
    {  
        public int Product_ID { get; set; }
        public int Quantity { get; set; }
    }
}
