using Abp.MultiTenancy;
using EmployeeManagementSystem.Authorization.Users;

namespace EmployeeManagementSystem.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
