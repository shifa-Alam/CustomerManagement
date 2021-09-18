using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface ICustomerAddressService
    {
        Task<CustomerAddress> SaveAsync(CustomerAddress entity);
        Task<CustomerAddress> UpdateAsync(CustomerAddress entity);
        Task DeleteAsync(int id);
        Task<CustomerAddress> FindByIdAsync(int id);
        Task<IEnumerable<CustomerAddress>> GetAsyc();
        //void OnCustomerDelete(Customer customer);
    }
}
