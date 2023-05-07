using FakeItEasy;
using ZooIS.Server.Controllers;
using ZooIS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Shared.Dto;
using ZooIS.Server.Services.AuthService;

namespace TestProject.Server.Controllers
{
    public class AuthControllerTests
    {
        private readonly IAuthService _authService;
        public AuthControllerTests()
        {
            _authService = A.Fake<IAuthService>();
        }

        [Fact]
        public async Task Register_ReturnsCorrectValue()
        {
            // Arrange
            int fakeId = 1;
            string fakeUsername = "Vardas";
            var fakeResponseDto = new AuthResponseDto { Username = fakeUsername };
            var fakeDto = new RegisterUserDto { Username = fakeUsername };
            A.CallTo(() => _authService.RegisterUser(fakeDto)).Returns(Task.FromResult(fakeResponseDto));
            var controller = new AuthController(_authService);

            // Act
            var actionResult = await controller.Register(fakeDto);

            // Assert
            var result = actionResult as ObjectResult;
            var returnedDto = result.Value as AuthResponseDto;
            Assert.Equal(fakeResponseDto, returnedDto);
        }

        [Fact]
        public async Task Login_ReturnsCorrectValue()
        {
            // Arrange
            string fakeUsername = "Vardas";
            var fakeResponseDto = new AuthResponseDto { Username = fakeUsername };
            var fakeDto = new AuthUserDto { Username = fakeUsername };
            A.CallTo(() => _authService.LoginUser(fakeDto)).Returns(Task.FromResult(fakeResponseDto));
            var controller = new AuthController(_authService);

            // Act
            var actionResult = await controller.Login(fakeDto);

            // Assert
            var result = actionResult as OkObjectResult;
            var returnedDto = result.Value as AuthResponseDto;
            Assert.Equal(fakeResponseDto, returnedDto);
        }
    }
}
