using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EmployeeManagementSystem.Authorization;

namespace EmployeeManagementSystem
{
    [DependsOn(
        typeof(EmployeeManagementSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class EmployeeManagementSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<EmployeeManagementSystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(EmployeeManagementSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
