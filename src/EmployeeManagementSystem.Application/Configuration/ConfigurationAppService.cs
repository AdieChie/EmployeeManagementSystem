using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using EmployeeManagementSystem.Configuration.Dto;

namespace EmployeeManagementSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : EmployeeManagementSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
