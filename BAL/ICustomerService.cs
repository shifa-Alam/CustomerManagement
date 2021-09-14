using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface ICustomerService
    {
        Task<Customer> SaveAsync(Customer entity);
        Task<Customer> UpdateAsync(Customer entity);
        Task DeleteAsync(int id);
        Task<Customer> FindByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAsyc();


    }
}
