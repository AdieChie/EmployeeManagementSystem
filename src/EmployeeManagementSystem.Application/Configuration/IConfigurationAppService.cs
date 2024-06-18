using System.Threading.Tasks;
using EmployeeManagementSystem.Configuration.Dto;

namespace EmployeeManagementSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
