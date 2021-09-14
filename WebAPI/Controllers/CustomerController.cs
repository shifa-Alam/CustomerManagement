using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using BAL;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> SaveCustomerAsync(Customer customer)
        {
            try
            {
                var result = await _customerService.SaveAsync(customer);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Customer>> FindCustomerByIdAsync(int id)
        {
            try
            {
                var result = await _customerService.FindByIdAsync(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {


            try
            {
                return Ok(await _customerService.GetAsyc());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from Database");
            }

        }
    }
}
