using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
           using(var contect = new CustomerManagementDbContext())
            {
                //get all customers
                return contect.Customers.ToList();
            }
        }
    }
}
