using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

using Microsoft.AspNetCore.Http;
using AutoMapper;
using BAL;

namespace WebAPI.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService CustomerService;
        private readonly IMapper Mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            CustomerService = customerService;
            Mapper = mapper;
        }

        #region  customer
        [HttpPost]

        public async Task SaveCustomerAsync([FromBody] CustomerInputModel model)
        {
            try
            {
                var result = await CustomerService.SaveAsync(Mapper.Map<Customer>(model));

                Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut]
        public async Task UpdateCustomerAsync([FromBody] CustomerInputModel model)
        {
            try
            {
                var result = await CustomerService.UpdateAsync(Mapper.Map<Customer>(model));

                Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id:int}")]
        public async Task DeleteCustomerAsync(int id)
        {
            try
            {
                await CustomerService.DeleteAsync(id);
                Ok();
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
                var result = await CustomerService.FindByIdAsync(id);
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
                return Ok(await CustomerService.GetAsyc());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from Database");
            }

        }
    }
    #endregion



    


}
    
