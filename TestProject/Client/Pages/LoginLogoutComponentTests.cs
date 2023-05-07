using Blazored.LocalStorage;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using ZooIS.Client.Services.AuthService;
using ZooIS.Client.Shared;

namespace TestProject.Client.Pages
{
    public class LoginLogoutComponentTests : TestContext
    {
        [Fact]
        public void LoginLogoutComponentShouldNotRender()
        {
            // Arrange
            //var navMan = Services.GetRequiredService<FakeNavigationManager>();
            var authContext = this.AddTestAuthorization();
            authContext.SetAuthorizing();
            Services.AddAuthorizationCore();
            Services.AddSingleton<IAuthService, TestProject.Client.Pages.MockAuth>();
            Services.AddBlazoredLocalStorage();
            // Act
            var cut = RenderComponent<LoginLogout>();
            // Assert
            cut.MarkupMatches("");
        }
    }
}
