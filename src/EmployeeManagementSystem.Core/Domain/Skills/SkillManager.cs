using Abp.Domain.Repositories;
using Abp.Domain.Services;
using EmployeeManagementSystem.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Skills
{
    public class SkillManager: DomainService, ISkillManager
    {
        private readonly IRepository<Skill, Guid> _skillRepository;
        private readonly IRepository<Employee, string> _employeeRepository;

        public SkillManager(IRepository<Skill, Guid> skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<Skill> CreateAsync(Skill input)
        {
            await _skillRepository.InsertAsync(input);
            await CurrentUnitOfWork.SaveChangesAsync();
            return input;
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Skill>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Skill> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Skill> UpdateAsync(Skill input)
        {
                var existingSkill = await _skillRepository.FirstOrDefaultAsync(s => s.Id == input.Id);
                if (existingSkill != null)
                {
                    existingSkill.Name = input.Name;
                    existingSkill.YearsOfExpirience = input.YearsOfExpirience;
                    existingSkill.Rating = input.Rating;
                    await _skillRepository.UpdateAsync(existingSkill);
                }
                else
                {
                    await _skillRepository.InsertAsync(input);
                }

            await CurrentUnitOfWork.SaveChangesAsync();
            return input;
        }
    }
}
