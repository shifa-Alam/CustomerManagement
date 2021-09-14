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

        public async Task<CustomerAddress> SaveAsync(CustomerAddress entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

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
                var existingEntity = await _appDbContext.Countries.FindAsync(entity.Id);
                if (existingEntity is null) throw new Exception("CustomerAddress Not Found!");

                //existingEntity.CustomerAddressName = entity.CustomerAddressName;
                //ApplyCustomerAddressIdBl(existingEntity);
                //ApplyValidationBl(existingEntity);

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

                var result = _appDbContext.Countries.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    _appDbContext.Countries.Remove(result);
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
              
                //entity.CustomerAddressName = string.IsNullOrWhiteSpace(entity.CustomerAddressName) ? throw new Exception("Name is Required") : entity.CustomerAddressName.Trim();
              
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
