using Abp.Authorization;
using EmployeeManagementSystem.Authorization.Roles;
using EmployeeManagementSystem.Authorization.Users;

namespace EmployeeManagementSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
