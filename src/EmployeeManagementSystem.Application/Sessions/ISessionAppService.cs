using System.Threading.Tasks;
using Abp.Application.Services;
using EmployeeManagementSystem.Sessions.Dto;

namespace EmployeeManagementSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
