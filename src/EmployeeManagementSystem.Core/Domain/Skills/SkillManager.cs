using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
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
            try
            {
                await _skillRepository.InsertAsync(input);
                await CurrentUnitOfWork.SaveChangesAsync();
                return input;
            }
            catch (Exception ex)
            {
                Logger.Error($"Error creating skill: {ex.Message}", ex);
                throw new UserFriendlyException("An error occurred while creating the skill.", ex);
            }
        }


        public async Task<Skill> UpdateAsync(Skill input)
        {
            try
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
            catch (Exception ex)
            {
                Logger.Error($"Error updating or creating skill with ID {input.Id}: {ex.Message}", ex);
                throw new UserFriendlyException($"An error occurred while updating or creating the skill with ID {input.Id}.", ex);
            }
        }
    }
}
