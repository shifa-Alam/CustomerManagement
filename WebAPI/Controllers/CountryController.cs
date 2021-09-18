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

    public class CountryController : ControllerBase
    {
        private readonly ICountryService CountryService;    
        private readonly IMapper Mapper;

        public CountryController( ICountryService countryService, IMapper mapper)
        {
            CountryService = countryService;
           
            Mapper = mapper;
        }

        #region  country
        [HttpPost]

        //public async Task SaveCountryAsync([FromBody] CountryInputModel model)
        //{
        //    try
        //    {
        //        var result = await CountryService.SaveAsync(Mapper.Map<Country>(model));

        //        Ok();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        //[HttpPut]
        //public async Task UpdateCountryAsync([FromBody] CountryInputModel model)
        //{
        //    try
        //    {
        //        var result = await CountryService.UpdateAsync(Mapper.Map<Country>(model));

        //        Ok();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //[HttpDelete("{id:int}")]
        //public async Task DeleteCountryAsync(int id)
        //{
        //    try
        //    {
        //        await CountryService.DeleteAsync(id);
        //        Ok();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<Country>> FindCountryByIdAsync(int id)
        //{
        //    try
        //    {
        //        var result = await CountryService.FindByIdAsync(id);
        //        if (result == null) return NotFound();
        //        return result;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                return Ok(await CountryService.GetAsyc());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from Database");
            }

        }
    }
    #endregion



    


}
    
