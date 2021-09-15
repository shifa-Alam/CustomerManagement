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
    public class CountryServiceUnitTest
    {

        private readonly ICountryService _countryService;

        public CountryServiceUnitTest()
        {
            AppDbContext dbContext = new AppDbContext();
            _countryService = new CountryService(dbContext);
        }

        [TestMethod]
        public async Task SaveCountryAsync()
        {
            try
            {
                List<Country> countries = new List<Country>
                {
                    new Country {CountryName = "Japan"},
                    new Country {CountryName = "USA"},
                    new Country {CountryName = "UK"}
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
