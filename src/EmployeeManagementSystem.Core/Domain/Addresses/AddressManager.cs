using Abp.Domain.Repositories;
using Abp.Domain.Services;
using EmployeeManagementSystem.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Addresses
{
    public class AddressManager : DomainService, IAddressManager
    {
        private readonly IRepository<Address, Guid> _addressRepository;

        public AddressManager(IRepository<Address, Guid> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<Address> CreateAsync(Address input)
        {
            await _addressRepository.InsertAsync(input);
            await CurrentUnitOfWork.SaveChangesAsync();
            return input;
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Address>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Address> UpdateAsync(Address input)
        {
            var address = await _addressRepository.GetAsync(input.Id);
            if (address == null)
            {
                throw new Exception("Address not found");
            }

            address.Country = input.Country;
            address.City = input.City;
            address.PostalCode = input.PostalCode;
            address.StreetAddress = input.StreetAddress;

            var updatedAddress = await _addressRepository.UpdateAsync(address);

            return ObjectMapper.Map<Address>(updatedAddress);
        }

    }
}
