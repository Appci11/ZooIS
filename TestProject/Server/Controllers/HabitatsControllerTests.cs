using FakeItEasy;
using ZooIS.Server.Controllers;
using ZooIS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Shared.Dto;
using ZooIS.Server.Services.HabitatsService;

namespace TestProject.Server.Controllers
{
    public class HabitatsControllerTests
    {
        private readonly IHabitatsService _habitatsService;
        public HabitatsControllerTests()
        {
            _habitatsService = A.Fake<IHabitatsService>();
        }

        [Fact]
        public async void GetAllHabitats_ReturnsCorrectAmmount()
        {
            // Arrange
            int count = 5;
            var HabitatsList = A.CollectionOfDummy<Habitat>(count).ToList();
            A.CallTo(() => _habitatsService.GetAllHabitats(true)).Returns(HabitatsList);
            var controller = new HabitatsController(_habitatsService);

            // Act
            var actionResult = await controller.GetAllHabitats();

            // Assert
            var result = actionResult as OkObjectResult;
            var returnedHabitats = result.Value as List<Habitat>;
            Assert.Equal(count, returnedHabitats.Count);
        }

        [Fact]
        public async Task GetHabitat_ReturnsCorrectValue()
        {
            // Arrange
            var fakeId = 1;
            var fakeName = "Pavadinimas";
            var fakeHabitat = new Habitat { Id = fakeId, Name = fakeName };
            A.CallTo(() => _habitatsService.GetHabitat(fakeId, true)).Returns(Task.FromResult(fakeHabitat));
            var controller = new HabitatsController(_habitatsService);

            // Act
            var actionResult = await controller.GetHabitat(fakeId);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var actualValue = result.Value as Habitat;
            Assert.Equal(fakeHabitat, actualValue);
        }

        [Fact]
        public async Task AddHabitat_ReturnsCorrectValue()
        {
            //Arrange
            int fakeId = 1;
            string fakeName = "Pavadinimas";
            var fakeHabitat = new Habitat { Id = fakeId, Name = fakeName };
            var fakeDto = new AddHabitatDto { Name = fakeName };
            A.CallTo(() => _habitatsService.AddHabitat(fakeDto)).Returns(Task.FromResult(fakeHabitat));
            var controller = new HabitatsController(_habitatsService);

            // Act
            var actionResult = await controller.AddHabitat(fakeDto);

            // Assert
            var result = actionResult as ObjectResult;
            var actualValue = result.Value as Habitat;
            Assert.Equal(fakeHabitat, actualValue);
        }

        [Fact]
        public async Task UpdateHabitat_ReturnsCorrectValue()
        {
            // Arrange
            int fakeId = 1;
            string fakeName = "Pavadinimas";
            var fakeHabitat = new Habitat { Id = fakeId, Name = fakeName };
            var fakeDto = new UpdateHabitatDto { Name = fakeName };
            A.CallTo(() => _habitatsService.UpdateHabitat(fakeDto, fakeId)).Returns(Task.FromResult(fakeHabitat));
            var controller = new HabitatsController(_habitatsService);

            // Act
            var actionResult = await controller.UpdateHabitat(fakeDto, fakeId);

            // Assert
            var result = actionResult as ObjectResult;
            var returnedValue = result.Value as Habitat;
            Assert.Equal(fakeHabitat, returnedValue);
        }

        [Fact]
        public async Task DeleteHabitat_ReturnsOk()
        {
            // Arrange
            int fakeId = 1;
            A.CallTo(() => _habitatsService.DeleteHabitat(fakeId)).Returns(Task.FromResult(new Habitat()));
            var controller = new HabitatsController(_habitatsService);

            // Act
            var actionResult = await controller.DeleteHabitat(fakeId);

            // Assert
            var result = actionResult as ObjectResult;
            Assert.Equal(result.StatusCode, 200);
        }
    }
}
