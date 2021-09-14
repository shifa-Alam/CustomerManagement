using BAL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TEST
{
    [TestClass]
    public class CountryUnitTest
    {

        private ICountryService _countryService;

        [TestMethod]
        public async Task SaveCountryAsync()
        {
            try
            {
                List<Country> countries = new List<Country>();
                countries.Add(new Country { CountryName = "Bangladesh" });
                countries.Add(new Country { CountryName = "Germany" });
                countries.Add(new Country { CountryName = "India" });
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
