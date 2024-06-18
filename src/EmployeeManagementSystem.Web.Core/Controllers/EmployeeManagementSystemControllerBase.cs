using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementSystem.Controllers
{
    public abstract class EmployeeManagementSystemControllerBase: AbpController
    {
        protected EmployeeManagementSystemControllerBase()
        {
            LocalizationSourceName = EmployeeManagementSystemConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
