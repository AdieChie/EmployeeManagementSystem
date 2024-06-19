using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
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
            try
            {
                await _addressRepository.InsertAsync(input);
                await CurrentUnitOfWork.SaveChangesAsync();
                return input;
            }
            catch (Exception ex)
            {
                Logger.Error($"Error creating address: {ex.Message}", ex);
                throw new UserFriendlyException("An error occurred while creating the address.", ex);
            }
        }

        public async Task<Address> UpdateAsync(Address input)
        {
            try
            {
                var address = await _addressRepository.GetAsync(input.Id);
                if (address == null)
                    throw new Exception("Address not found");

                address.Country = input.Country;
                address.City = input.City;
                address.PostalCode = input.PostalCode;
                address.StreetAddress = input.StreetAddress;

                var updatedAddress = await _addressRepository.UpdateAsync(address);

                return ObjectMapper.Map<Address>(updatedAddress);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error updating address: {ex.Message}", ex);
                throw new UserFriendlyException("An error occurred while updating the address.", ex);
            }


        }

    }
}
