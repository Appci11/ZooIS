using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using ZooIS.Client.Pages;
using ZooIS.Client.Services.AuthService;
using ZooIS.Client.Services.UsersService;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace TestProject.Client.Pages
{
    public class LoginPageTests : TestContext
    {
        [Fact]
        public void LoginPageShouldRender()
        {
            // Arrange
            Services.AddSingleton<IAuthService, MockAuth>();
            Services.AddSingleton<IUsersService, MockUsersService>();
            Services.AddBlazoredLocalStorage();
            JSInterop.SetupVoid("mudElementRef.select", _ => true);
            // Act
            var cut = RenderComponent<LoginPage>();
            // Assert
            cut.Find("br").MarkupMatches("<br  >"); // jei sitiek matom, tai psl uzsikrove
        }
    }

    public class MockAuth : IAuthService
    {
        public Task<int> Login(AuthUserDto authUserDto, bool stayLoggedIn)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RefreshTokens()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(RegisterUserDto registerUserDto)
        {
            throw new NotImplementedException();
        }
    }
    public class MockUsersService : IUsersService
    {
        public List<RegisteredUser> Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<bool> CreateUser(RegisteredUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RegisteredUser> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePassword(UpdatePasswordDto updatePasswordDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(RegisteredUser user)
        {
            throw new NotImplementedException();
        }
    }
}
