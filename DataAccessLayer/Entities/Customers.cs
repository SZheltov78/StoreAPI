using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Customers
    {
        [Key]
        public int Customer_ID { get; set; }
        public string Name { get; set; }
        public string INN { get; set; }
        public string Token { get; set; }

    }
}
