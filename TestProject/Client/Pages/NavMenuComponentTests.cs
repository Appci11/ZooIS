using Blazored.LocalStorage;
using Bunit.TestDoubles;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using ZooIS.Client.Pages;
using ZooIS.Client.Shared;
using ZooIS.Shared.Dto;

namespace TestProject.Client.Pages
{
    public class NavMenuComponentTests : TestContext
    {
        [Fact]
        public void NavMenuComponentShouldRender()
        {
            // Arrange
            this.AddTestAuthorization();
            Services.AddBlazoredLocalStorage();
            Services.AddAuthorizationCore();
            // Act
            var cut = RenderComponent<NavMenu>();
            // Assert
            cut.Find("div");
        }
    }
}
