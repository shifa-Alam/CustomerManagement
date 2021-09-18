using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   public  class CountryService : ICountryService
    {
        private readonly AppDbContext _appDbContext;
   

        public CountryService(AppDbContext appDbContext )
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            }

        public async Task<Country> SaveAsync(Country entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                ApplyValidationBl(entity);

                var result = await _appDbContext.Countries.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Country> UpdateAsync(Country entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));
                var existingEntity = await _appDbContext.Countries.FindAsync(entity.Id);
                if (existingEntity is null) throw new Exception("Country Not Found!");

                existingEntity.CountryName = entity.CountryName;
                ApplyCountryIdBl(existingEntity);
                ApplyValidationBl(existingEntity);

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

        public async Task<Country> FindByIdAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentNullException(nameof(id));

                var result = await _appDbContext.Countries.FirstOrDefaultAsync(c => c.Id == id);
                if (result == null)
                {
                    throw new Exception($"Country not Found with id= {id}");
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Country>> GetAsyc()
        {
            try
            {
                return await _appDbContext.Countries.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }



        #region Business Logic

        private void ApplyValidationBl(Country entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));
              
                entity.CountryName = string.IsNullOrWhiteSpace(entity.CountryName) ? throw new Exception("Name is Required") : entity.CountryName.Trim();
              
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ApplyCountryIdBl(Country entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                if (entity.Id <= 0) throw new Exception("Invalid Country");
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
