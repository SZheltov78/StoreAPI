using MsSqlAccessLayer.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Orders
    {
        [Key]
        public int Order_ID { get; set; }
        public OrderStatusCodes Status { get; set; }
        
        public int Customer_ID { get; set; }
        public Customers Customer { get; set; }

        public int Product_ID { get; set; }
        public Products Product { get; set; }

        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime AcceptedDate { get; set; }
        public DateTime СompletedDate { get; set; }
    }
}
