using Abp.Application.Services;
using EmployeeManagementSystem.MultiTenancy.Dto;

namespace EmployeeManagementSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

