using AutoMapper;
using EmployeeManagementSystem.Domain.Addresses;
using EmployeeManagementSystem.Domain.Employees;
using EmployeeManagementSystem.Domain.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.Employees.DTOs
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();

            CreateMap<EmployeeDto, Employee>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Skill, SkillDto>();
            CreateMap<SkillDto, Skill>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
