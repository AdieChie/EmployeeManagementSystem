using Abp.Domain.Entities.Auditing;
using EmployeeManagementSystem.Domain.Addresses;
using EmployeeManagementSystem.Domain.Skills;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Employees
{
    public class Employee : FullAuditedEntity<String>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public virtual Address Address { get; set; }
        public ICollection<Skill> Skills { get; set; }
        
    }
}
