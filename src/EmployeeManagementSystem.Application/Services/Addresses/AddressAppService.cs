//using Abp.Application.Services;
//using EmployeeManagementSystem.Domain.Addresses;
//using EmployeeManagementSystem.Services.Addresses.DTOs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EmployeeManagementSystem.Services.Addresses
//{
//    public class AddressAppService: ApplicationService
//    {
//        private readonly IAddressManager _addressManager;
//        public AddressAppService(IAddressManager addressManager)
//        {
//            _addressManager = addressManager;
//        }
//        public async Task<AddressDto> CreateAsync(AddressDto input)
//        {
//            var address = ObjectMapper.Map<Address>(input);
//            var result = await _addressManager.CreateAsync(address);
//            return ObjectMapper.Map<AddressDto>(result);
//        }
//    }
//}
