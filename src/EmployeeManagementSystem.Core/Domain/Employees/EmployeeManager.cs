using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using EmployeeManagementSystem.Domain.Addresses;
using EmployeeManagementSystem.Domain.Skills;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Employees
{
    public class EmployeeManager : DomainService, IEmployeeManager
    {
        private readonly IRepository<Employee, string> _employeeRepository;
        private readonly IRepository<Address, Guid> _addressRepository;
        private readonly IRepository<Skill, Guid> _employeeSkillRepository;
        public EmployeeManager(IRepository<Employee, string> employeeRepository, IRepository<Address, Guid> addressRepository, IRepository<Skill, Guid> employeeSkillRepository)
        {
            _employeeRepository = employeeRepository;
            _addressRepository = addressRepository;
            _employeeSkillRepository = employeeSkillRepository;
        }
        public async Task<Employee> CreateAsync(Employee input)
        {
            try
            {
               input.Id = await GenerateUniqueEmployeeIdAsync();
               var employee = ObjectMapper.Map<Employee>(input);
               await _employeeRepository.InsertAsync(employee);

                // create skills for the employee by mapping skills from the input
                var skills = ObjectMapper.Map<List<Skill>>(input.Skills);
                foreach (var skill in skills)
                {
                    await _employeeSkillRepository.InsertAsync(skill);
                };
                await CurrentUnitOfWork.SaveChangesAsync();
                return ObjectMapper.Map<Employee>(employee);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error creating employee: {ex.Message}", ex);
                throw new UserFriendlyException("An error occurred while creating the employee.", ex);
            }

        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                // Retrieve the employee and include related entities
                var employee = await _employeeRepository.GetAllIncluding(e => e.Address, e => e.Skills)
                                                           .FirstOrDefaultAsync(e => e.Id == id);
                if (employee == null)
                    throw new UserFriendlyException($"Employee with ID {id} not found.");

                // bulk deleting the skills
                var skillIds = employee.Skills.Select(s => s.Id).ToList();
                if (skillIds.Any())
                {
                    await _employeeSkillRepository.DeleteAsync(s => skillIds.Contains(s.Id));
                }

                // Delete the employee
                await _employeeRepository.DeleteAsync(employee);

                // Delete the address
                await _addressRepository.DeleteAsync(employee.Address);

                await CurrentUnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Logger.Error($"Error deleting employee with ID {id}: {ex.Message}", ex);
                throw new UserFriendlyException($"An error occurred while deleting the employee with ID {id}.", ex);
            }
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            try
            {
                return await _employeeRepository.GetAllIncluding(e => e.Address, e => e.Skills)
                                                .Where(e => !e.IsDeleted)
                                                .ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.Error($"Error retrieving all employees: {ex.Message}", ex);
                throw new UserFriendlyException("An error occurred while retrieving all employees.", ex);
            }
        }

        public async Task<Employee> GetAsync(string id)
        {
            try
            {
                var employee = await _employeeRepository.GetAllIncluding(e => e.Address, e => e.Skills)
                                                        .FirstOrDefaultAsync(e => e.Id == id);

                if (employee == null)
                    throw new UserFriendlyException($"Employee with ID {id} not found.");

                return employee;
            }
            catch (Exception ex)
            {
                Logger.Error($"Error retrieving employee with ID {id}: {ex.Message}", ex);
                throw new UserFriendlyException($"An error occurred while retrieving the employee with ID {id}.", ex);
            }
        }

        public async Task<Employee> UpdateAsync(Employee input)
        {
            try
            {
                return await _employeeRepository.UpdateAsync(input);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error updating employee with ID {input.Id}: {ex.Message}", ex);
                throw new UserFriendlyException($"An error occurred while updating the employee with ID {input.Id}.", ex);
            }
        }

        private async Task<string> GenerateUniqueEmployeeIdAsync()
        {
            string employeeId;
            do
            {
                employeeId = GenerateID();
            } while (await _employeeRepository.FirstOrDefaultAsync(e => e.Id == employeeId) != null);

            return employeeId;
        }
        private string GenerateID()
        {
            Random random = new Random();
            string Id = "";
            for (int i = 0; i < 2; i++)
            {
                char letter = (char)random.Next(65, 91);
                Id += letter;
            }
            for (int i = 0; i < 4; i++)
            {
                Id += random.Next(0, 10);
            }
            return Id;
        }


    }
}
