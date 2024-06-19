using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Addresses
{
    public interface IAddressManager :IDomainService
    {
        Task<Address> CreateAsync(Address input);
        Task<Address> UpdateAsync(Address input);
        Task<List<Address>> GetAllAsync();
        Task<Address> GetAsync(string id);
        Task DeleteAsync(string id);
    }
}
