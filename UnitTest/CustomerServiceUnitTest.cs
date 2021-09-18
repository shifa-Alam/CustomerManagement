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

        private readonly ICustomerService _customerService;

        public CustomerServiceUnitTest()
        {
            AppDbContext dbContext = new AppDbContext();
            ICustomerAddressService customerAddressService = new CustomerAddressService();

            _customerService = new CustomerService(dbContext,customerAddressService);
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
                   var entity = await _customerService.SaveAsync(customer);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        [TestMethod]
        public async Task UpdateCustomerAsync()
        {
            try
            {


                var customer = new Customer
                {
                    Id = 24,
                    CustomerName = $"Shifa ",
                    CountryId = 1,
                    FatherName = $"xyz ",
                    MaritalStatus = 2,
                    MotherName = $"Abc  ",

                };
                var entity= await _customerService.UpdateAsync(customer);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [TestMethod]
        public async Task DeleteCustomerAsync()
        {
            try
            {
                await _customerService.DeleteAsync(24);
            }
            catch (Exception e)
            {

                throw;
            }

        }
        [TestMethod]
        public async Task FindCustomerAsync()
        {
            try
            {
                var entity = await _customerService.FindByIdAsync(24);

            }
            catch (Exception)
            {

                throw;
            }

        }
        [TestMethod]
        public async Task GetCustomersAsync()
        {
            try
            {
                var entity = await _customerService.GetAsyc();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
