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
    public class CustomerServiceUnitTest
    {

        private readonly ICustomerService _countryService;

        public CustomerServiceUnitTest()
        {
            AppDbContext dbContext = new AppDbContext();
            _countryService = new CustomerService(dbContext);
        }


        [TestMethod]
        public async Task SaveCustomerAsync()
        {
            try
            {

                for (int i = 1; i < 10; i++)
                {
                    var customer = new Customer
                    {
                        CustomerName = $"Shifa  {i}",
                        CountryId = 1,
                        FatherName = $"xyz {i}",
                        MaritalStatus = 2,
                        MotherName = $"Abc {i} ",


                    };
                    customer.CustomerAddresses.Add(new CustomerAddress
                    {
                        Address = $"141/2 west shewrapara Mirpur {i}"
                    });
                    await _countryService.SaveAsync(customer);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
