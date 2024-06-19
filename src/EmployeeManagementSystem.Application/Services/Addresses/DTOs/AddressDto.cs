using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.Addresses.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public class AddressDto:FullAuditedEntityDto<Guid>
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
}
