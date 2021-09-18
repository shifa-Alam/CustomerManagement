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
using System.IO;

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


        #endregion


        [HttpPost("Upload")]
        [Consumes("multipart/form-data")]
        public async  Task<ActionResult<Customer>> Upload([FromForm] FileModel file)
        {
            try
            {
                var customerPhote = file.MyFile;
                var custommerId = file.CustomerId;

                var customer = new Customer();

                if (customerPhote.Length > 0)
                {
                    byte[] fileBytes;

                    using (var ms = new MemoryStream())
                    {
                        customerPhote.CopyTo(ms);
                        fileBytes = ms.ToArray();
                        string s = Convert.ToBase64String(fileBytes);
                        // act on the Base64 data
                    }

                    customer.Id = Convert.ToInt32(custommerId);
                    customer.CustomerPhoto = fileBytes;
                }


                var result = await CustomerService.UploadPhotoAsync(customer);

                return Ok(result);

            }
            catch (Exception e)
            {

                throw;
            }
        }
    }


}

