using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EmployeeManagementSystem.Configuration;

namespace EmployeeManagementSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(EmployeeManagementSystemWebCoreModule))]
    public class EmployeeManagementSystemWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public EmployeeManagementSystemWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EmployeeManagementSystemWebHostModule).GetAssembly());
        }
    }
}
