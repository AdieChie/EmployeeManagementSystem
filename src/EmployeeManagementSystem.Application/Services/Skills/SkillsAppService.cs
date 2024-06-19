using Abp.Application.Services;
using EmployeeManagementSystem.Domain.Skills;
using EmployeeManagementSystem.Services.Employees.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.Skills
{
    public class SkillsAppService : ApplicationService
    {
        private readonly ISkillManager _skillManager;
        public SkillsAppService(ISkillManager skillManager)
        {
            _skillManager = skillManager;
        }

        public async Task<SkillDto> CreateAsync(SkillDto input)
        {
            var skill = ObjectMapper.Map<Skill>(input);
            skill = await _skillManager.CreateAsync(skill);
            return ObjectMapper.Map<SkillDto>(skill);
        }
        public async Task<SkillDto> UpdateAsync(SkillDto input)
        {

            var skill = ObjectMapper.Map<Skill>(input);
            skill.Id = input.Id;
            skill = await _skillManager.UpdateAsync(skill);
            return ObjectMapper.Map<SkillDto>(skill);
        }
    }
}
