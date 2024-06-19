using Abp.Application.Services.Dto;
using Abp.AutoMapper;
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
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(Employee))]
    public class EmployeeDto :EntityDto<string>
    {
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContactNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AddressDto Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SkillDto> Skills { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(Address))]
    public class AddressDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string StreetAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Country { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(Skill))]
    public class SkillDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int YearsOfExperience { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Rating { get; set; }
    }

}
