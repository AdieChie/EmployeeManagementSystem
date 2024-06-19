using AutoMapper;
using EmployeeManagementSystem.Domain.Addresses;
using EmployeeManagementSystem.Services.Employees.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.Addresses
{
    public class AddressMappingProfile: Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
