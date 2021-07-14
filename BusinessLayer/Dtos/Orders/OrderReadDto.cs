using MsSqlAccessLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Dtos.Orders
{
    public class OrderReadDto
    {
        public int Order_ID { get; set; }
        public int Customer_ID { get; set; }
        public OrderStatusCodes Status { get; set; }
        public int Product_ID { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime AcceptedDate { get; set; }
        public DateTime СompletedDate { get; set; }
    }
}
