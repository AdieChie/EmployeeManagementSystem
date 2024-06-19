using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Addresses
{
    public class Address : FullAuditedEntity<Guid>
    {
        public virtual string StreetAddress { get; set; }
        public virtual string City { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
    }
    
}
