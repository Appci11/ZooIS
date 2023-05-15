﻿using Microsoft.Extensions.DependencyInjection;
using ZooIS.Client.Pages;
using ZooIS.Client.Services.AuthService;

namespace TestProject.Client.Pages
{
    public class UsersPage : TestContext
    {
        [Fact]
        public void UsersPageShouldRender()
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
