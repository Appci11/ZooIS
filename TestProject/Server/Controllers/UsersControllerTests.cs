using FakeItEasy;
using ZooIS.Server.Controllers;
using ZooIS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Shared.Dto;
using ZooIS.Server.Services.UsersService;

namespace TestProject.Server.Controllers
{
    public class UsersControllerTests
    {
        readonly IUsersService _usersService;
        public UsersControllerTests()
        {
            _usersService = A.Fake<IUsersService>();
        }

        [Fact]
        public async void GetAllUsers_ReturnsCorrectAmmount()
        {
            // Arrange
            int count = 12;
            var UsersList = A.CollectionOfDummy<RegisteredUser>(count).ToList();
            A.CallTo(() => _usersService.GetAllRegisteredUsers()).Returns(UsersList);
            var controller = new UsersController(_usersService);

            // Act
            var actionResult = await controller.GetAllUsers();

            // Assert
            var result = actionResult as OkObjectResult;
            var returnedValues = result.Value as List<RegisteredUser>;
            Assert.Equal(count, returnedValues.Count);
        }

        [Fact]
        public async Task GetUser_ReturnsCorrectValue()
        {
            // Arrange
            var fakeId = 1;
            var fakeUsername = "Vardas";
            var fakeUser = new RegisteredUser { Username = fakeUsername, Id = fakeId };
            A.CallTo(() => _usersService.GetRegisteredUser(fakeId)).Returns(Task.FromResult(fakeUser));
            var controller = new UsersController(_usersService);

            // Act
            var actionResult = await controller.GetUser(fakeId);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var actualValue = result.Value as RegisteredUser;
            Assert.Equal(fakeUser, actualValue);
        }

        [Fact]
        public async Task AddUser_ReturnsCorrectValue()
        {
            //Arrange
            int fakeId = 1;
            string fakeUsername = "Vardas";
            var fakeUser = new RegisteredUser { Id = fakeId, Username = fakeUsername };
            var fakeDto = new AddRegisteredUserDto { Username = fakeUsername };
            A.CallTo(() => _usersService.AddRegisteredUser(fakeDto)).Returns(Task.FromResult(fakeUser));
            var controller = new UsersController(_usersService);

            // Act
            var actionResult = await controller.AddRegisteredUser(fakeDto);

            // Assert
            var result = actionResult as ObjectResult;
            var returnedValue = result.Value as RegisteredUser;
            Assert.Equal(fakeUser, returnedValue);
        }

        [Fact]
        public async Task UpdateUser_ReturnsCorrectValue()
        {
            //Arrange
            int fakeId = 1;
            string fakeUsername = "Vardas";
            var fakeUser = new RegisteredUser { Id = fakeId, Username = fakeUsername };
            var fakeDto = new UpdateUserInfoAdminDto
            {
                Username = fakeUsername,
                Email = "pastas",
                Role = "kazkas",
                DeletionRequested = false,
                IsDeleted = false,
                RequestPasswordReset = false
            };
            A.CallTo(() => _usersService.UpdateRegisteredUserVAdmin(fakeId, fakeDto)).Returns(Task.FromResult(fakeUser));
            var controller = new UsersController(_usersService);

            // Act
            var actionResult = await controller.UpdateUser(fakeId, fakeDto);

            // Assert
            var result = actionResult.Result as ObjectResult;
            var returnedValue = result.Value as RegisteredUser;
            Assert.Equal(fakeUser, returnedValue);
        }

        [Fact]
        public async Task DeleteUser_ReturnsOk()
        {
            // Arrange
            int fakeId = 3;
            A.CallTo(() => _usersService.DeleteRegisteredUser(fakeId)).Returns(Task.FromResult(new RegisteredUser()));
            var controller = new UsersController(_usersService);

            // Act
            var actionResult = await controller.DeleteUser(fakeId);

            // Assert
            var result = actionResult as ObjectResult;
            Assert.Equal(result.StatusCode, 200);
        }

        [Fact]
        public async Task UpdatePassword_ReturnsNotNull()
        {
            // Arrange
            var fakeDto = new UpdatePasswordDto("Vardas", "slaptazodis");
            A.CallTo(() => _usersService.ChangePassword(fakeDto));
            var controller = new UsersController(_usersService);

            // Act
            var actionResult = await controller.ChangePassword(fakeDto);

            // Assert
            var result = actionResult as ObjectResult;
            Assert.NotNull(result);
        }
    }
}
