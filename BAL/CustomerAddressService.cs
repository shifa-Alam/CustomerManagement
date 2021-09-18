using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   public  class CustomerAddressService : ICustomerAddressService
    {
        private readonly AppDbContext _appDbContext;
   

        public CustomerAddressService(AppDbContext appDbContext )
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            }

        public CustomerAddressService()
        {
        }

        public async Task<CustomerAddress> SaveAsync(CustomerAddress entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                ApplyCustomerIdBl(entity);
                ApplyValidationBl(entity);

                var result = await _appDbContext.CustomerAddresses.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CustomerAddress> UpdateAsync(CustomerAddress entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));
                var existingEntity =  _appDbContext.CustomerAddresses.Find(entity.Id);
                if (existingEntity is null) throw new Exception("CustomerAddress Not Found!");

                existingEntity.Address = entity.Address;
                ApplyCustomerAddressIdBl(existingEntity);
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

                var result = _appDbContext.CustomerAddresses.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    _appDbContext.CustomerAddresses.Remove(result);
                    await _appDbContext.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<CustomerAddress> FindByIdAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentNullException(nameof(id));

                var result = await _appDbContext.CustomerAddresses.FirstOrDefaultAsync(c => c.Id == id);
                if (result == null)
                {
                    throw new Exception($"CustomerAddress not Found with id= {id}");
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CustomerAddress>> GetAsyc()
        {
            try
            {
                return await _appDbContext.CustomerAddresses.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }



        #region Business Logic

        private void ApplyValidationBl(CustomerAddress entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                entity.Address = string.IsNullOrWhiteSpace(entity.Address) ? throw new Exception("Address is Required") : entity.Address.Trim();

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ApplyCustomerIdBl(CustomerAddress entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));
                if (entity.CustomerId <= 0) throw new Exception("Customer Id Required");
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void ApplyCustomerAddressIdBl(CustomerAddress entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                if (entity.Id <= 0) throw new Exception("Invalid CustomerAddress");
            }
            catch (Exception)
            {

                throw;
            }
        }

       
        #endregion
    }
}
