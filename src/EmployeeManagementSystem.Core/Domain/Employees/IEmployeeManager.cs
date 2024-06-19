using Abp.Application.Services.Dto;
using Abp.Domain.Services;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Employees
{
    public interface IEmployeeManager : IDomainService
    {
        Task<Employee> CreateAsync(Employee input);
        Task<Employee> UpdateAsync(Employee input);
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetAsync(string id);
        Task DeleteAsync(string id);
        Task<List<Employee>> FilterByDateOfBirth(DateTime dateOfBirth);
    }
}
