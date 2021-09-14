using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface ICountryService
    {
        Task<Country> SaveAsync(Country entity);
        Task<Country> UpdateAsync(Country entity);
        Task DeleteAsync(int id);
        Task<Country> FindByIdAsync(int id);
        Task<IEnumerable<Country>> GetAsyc();


    }
}
