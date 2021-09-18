using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   public  class CustomerService : ICustomerService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICustomerAddressService _customerAddressService;

        public CustomerService(AppDbContext appDbContext, ICustomerAddressService customerAddressService)
        {
            _appDbContext = appDbContext;
            _customerAddressService = customerAddressService;
        }

        public async Task<Customer> SaveAsync(Customer entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                ApplyValidationBl(entity);

                var result = await _appDbContext.Customers.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Customer> UpdateAsync(Customer entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));
                var existingEntity = await _appDbContext.Customers.FindAsync(entity.Id);
                if (existingEntity is null) throw new Exception("Customer Not Found!");

                existingEntity.CustomerName = entity.CustomerName;
                existingEntity.FatherName = entity.FatherName;
                existingEntity.MotherName = entity.MotherName;
                existingEntity.CountryId = entity.CountryId;
                existingEntity.MaritalStatus = entity.MaritalStatus;
                existingEntity.CustomerPhoto = entity.CustomerPhoto;

                ApplyCustomerIdBl(existingEntity);
                ApplyValidationBl(existingEntity);

                // chain effect

                var result = await _appDbContext.SaveChangesAsync();
                return entity;



            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task DeleteAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentNullException(nameof(id));

                var result = _appDbContext.Customers.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    foreach (var item in result.CustomerAddresses)
                    {
                        _appDbContext.CustomerAddresses.Remove(item);
                    }
                    _appDbContext.Customers.Remove(result);
                    await _appDbContext.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<Customer> FindByIdAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentNullException(nameof(id));

                var result = await _appDbContext.Customers.Include(c => c.CustomerAddresses).Include(c => c.Country).FirstOrDefaultAsync(c => c.Id == id);
                if (result == null)
                {
                    throw new Exception($"Customer not Found with id= {id}");
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Customer>> GetAsyc()
        {
            try
            {
                return await _appDbContext.Customers.Include(a => a.CustomerAddresses).Include(a=>a.Country).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }



        #region Business Logic

        private void ApplyValidationBl(Customer entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));
                if (entity.CountryId <= 0) throw new Exception("Country Required");
                entity.CustomerName = string.IsNullOrWhiteSpace(entity.CustomerName) ? throw new Exception("Name is Required") : entity.CustomerName.Trim();
                entity.FatherName = string.IsNullOrWhiteSpace(entity.FatherName) ? string.Empty : entity.FatherName.Trim();
                entity.CustomerName = string.IsNullOrWhiteSpace(entity.CustomerName) ? string.Empty : entity.CustomerName.Trim();
                //entity.CustomerPhoto = string.IsNullOrWhiteSpace(entity.CustomerPhoto) ? throw new Exception("Name is Required") : entity.CustomerName.Trim();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ApplyCustomerIdBl(Customer entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                if (entity.Id <= 0) throw new Exception("Invalid Customer");
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
