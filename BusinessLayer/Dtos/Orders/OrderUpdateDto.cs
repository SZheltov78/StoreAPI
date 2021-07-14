using MsSqlAccessLayer.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Dtos.Orders
{
    public class OrderUpdateDto
    {
        public int Order_ID { get; set; }
        public int Customer_ID { get; set; }
        public OrderStatusCodes Status { get; set; }             
        public int Product_ID { get; set; }
        public int Quantity { get; set; }       
    }
}
