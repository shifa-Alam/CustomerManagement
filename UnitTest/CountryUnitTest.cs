using BAL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTest
{
    [TestClass]
    public class CountryUnitTest
    {

        private readonly ICountryService _countryService;

        


        [TestMethod]
        public async Task SaveCountryAsync()
        {
            try
            {
                List<Country> countries = new List<Country>
                {
                    new Country {CountryName = "Bangladesh"},
                    new Country {CountryName = "Germany"},
                    new Country {CountryName = "India"}
                };
                foreach (var country in countries)
                {
                    await _countryService.SaveAsync(country);
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
