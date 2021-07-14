using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Common
{
    public class CustomerController: ControllerBase
    {
        public Customers CurrentCustomer
        {
            get
            {                
                return (Customers)HttpContext.Items["Customer"];
            }
        }
    }
}
