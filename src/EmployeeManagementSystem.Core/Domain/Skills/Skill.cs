using Abp.Domain.Entities.Auditing;
using EmployeeManagementSystem.Domain.Employees;
using EmployeeManagementSystem.Domain.Reflists;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Skills
{
    public class Skill : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual int YearsOfExpirience { get; set; }
        public virtual RatingReflist Rating { get; set; }
        public virtual string EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}
