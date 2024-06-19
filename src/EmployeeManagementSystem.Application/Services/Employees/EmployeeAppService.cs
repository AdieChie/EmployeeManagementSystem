using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Repositories;
using EmployeeManagementSystem.Domain.Addresses;
using EmployeeManagementSystem.Domain.Employees;
using EmployeeManagementSystem.Domain.Skills;
using EmployeeManagementSystem.Services.Employees.DTOs;
using EmployeeManagementSystem.Services.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.Employees
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeAppService : ApplicationService
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IAddressManager _addressManager;
        private readonly ISkillManager _skillManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeManager"></param>
        /// <param name="addressManager"></param>
        public EmployeeAppService(IEmployeeManager employeeManager, IAddressManager addressManager, ISkillManager skillManager)
        {
            _employeeManager = employeeManager;
            _addressManager = addressManager;
            _skillManager = skillManager;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<EmployeeDto> CreateAsync(EmployeeDto input)
        {
            //validate input using the employeevalidator
            var employeeValidator = new EmployeeValidator();
            var address = ObjectMapper.Map<Address>(input.Address);
            address = await _addressManager.CreateAsync(address);
            var employee = ObjectMapper.Map<Employee>(input);
            employeeValidator.Validate(employee);
            employee.Address = address;
            employee = await _employeeManager.CreateAsync(employee);
            return ObjectMapper.Map<EmployeeDto>(employee);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployeeDto>> GetEmployees()
        {
            var employees = await _employeeManager.GetAllAsync();
            return ObjectMapper.Map<List<EmployeeDto>>(employees);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<EmployeeDto> UpdateEmployee(EmployeeDto input)
        {
            var employee = await _employeeManager.GetAsync(input.Id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            var updatedAddress = new Address
            {
                Id = employee.Address.Id,
                Country = input.Address.Country,
                City = input.Address.City,
                PostalCode = input.Address.PostalCode,
                StreetAddress = input.Address.StreetAddress
            };

            await _addressManager.UpdateAsync(updatedAddress);

            employee.FirstName = input.FirstName;
            employee.LastName = input.LastName;
            employee.ContactNumber = input.ContactNumber;
            employee.EmailAddress = input.EmailAddress;
            employee.DateOfBirth = input.DateOfBirth;


            //loop through the skills and update them
            foreach (var skill in input.Skills)
            {
               var skillService = IocManager.Instance.Resolve<SkillsAppService>();
               await skillService.UpdateAsync(skill);
            }


            employee = await _employeeManager.UpdateAsync(employee);

            // Map and return the updated employee DTO
            return ObjectMapper.Map<EmployeeDto>(employee);
        }

        public async Task DeleteEmployee(string id)
        {
            await _employeeManager.DeleteAsync(id);
        }

    }
}
