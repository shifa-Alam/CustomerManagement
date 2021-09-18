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

    public class CustomerAddressController : ControllerBase
    {
        private readonly ICustomerAddressService CustomerAddressService;     
        private readonly IMapper Mapper;

        public CustomerAddressController(ICustomerAddressService customerAddressService, IMapper mapper)
        {
            CustomerAddressService = customerAddressService;
          
            Mapper = mapper;
        }

        #region  customerAddress
        [HttpPost]

        public async Task SaveCustomerAddressAsync([FromBody]CustomerAddressInputModel model)
        {
            try
            {
                var result = await CustomerAddressService.SaveAsync(Mapper.Map<CustomerAddress>(model));


                Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut]
        public async Task UpdateCustomerAddressAsync([FromBody] CustomerAddressInputModel model)
        {
            try
            {
                var result = await CustomerAddressService.UpdateAsync(Mapper.Map<CustomerAddress>(model));

                Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id:int}")]
        public async Task DeleteCustomerAddressAsync(int id)
        {
            try
            {
                await CustomerAddressService.DeleteAsync(id);
                Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerAddress>> FindCustomerAddressByIdAsync(int id)
        {
            try
            {
                var result = await CustomerAddressService.FindByIdAsync(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerAddresss()
        {
            try
            {
                return Ok(await CustomerAddressService.GetAsyc());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from Database");
            }

        }
    }
    #endregion



    


}
    
