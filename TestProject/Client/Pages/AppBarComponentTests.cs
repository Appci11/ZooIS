using Microsoft.Extensions.DependencyInjection;
using ZooIS.Client.Pages;
using ZooIS.Client.Services.AuthService;
using ZooIS.Client.Shared;

namespace TestProject.Client.Pages
{
    public class AppBarComponentTests : TestContext
    {
        [Fact]
        public void AppBarComponentTestsShouldRender()
        {
            // Arrange
            Services.AddSingleton<IAuthService, MockAuth>();
            JSInterop.SetupVoid("mudElementRef.select", _ => true);
            // Act
            var cut = RenderComponent<RegisterPage>();
            // Assert
            var result = cut.Find("div");   // jei ras bent viena div, puslapis uzsikrove
            Assert.NotNull(result);
        }
    }
}
