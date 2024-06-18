using System.Threading.Tasks;
using EmployeeManagementSystem.Models.TokenAuth;
using EmployeeManagementSystem.Web.Controllers;
using Shouldly;
using Xunit;

namespace EmployeeManagementSystem.Web.Tests.Controllers
{
    public class HomeController_Tests: EmployeeManagementSystemWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}