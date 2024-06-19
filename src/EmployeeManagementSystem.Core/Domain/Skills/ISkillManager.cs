using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Skills
{
    public interface ISkillManager: IDomainService
    {
        Task<Skill> CreateAsync(Skill input);
        Task<Skill> UpdateAsync(Skill input);
    }
}
