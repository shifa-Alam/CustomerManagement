using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace WebAPI.Controllers
{
   
   
    [ApiController]
    [Route("[controller]")]
    
    public class CustomerController : ControllerBase
    {
        
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
           //using(var contect = new CustomerManagementDbContext())
           // {
           //     //get all customers
           //     return contect.Customers.ToList();
           // }
           
           List<Customer> customers= new List<Customer>();
           for (int i = 1; i < 10; i++)
           {
               Customer customer = new Customer
               {
                   Id = i+1,
                   CustomerName = $"shifa {i}",
                   FatherName = $"zakir {i}",
                   MaritalStatus = 2

               };
               customers.Add(customer);
            }

           return customers;

        }
    }
}
