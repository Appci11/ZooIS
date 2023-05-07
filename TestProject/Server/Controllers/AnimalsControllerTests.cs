using FakeItEasy;
using ZooIS.Server.Controllers;
using ZooIS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Shared.Dto;
using ZooIS.Server.Services.AnimalsService;

namespace TestProject.Server.Controllers
{
    public class AnimalsControllerTests
    {
        private readonly IAnimalsService _animalsService;
        public AnimalsControllerTests()
        {
            _animalsService = A.Fake<IAnimalsService>();
        }

        [Fact]
        public async void GetAllAnimals_ReturnsCorrectAmmount()
        {
            // Arrange
            int count = 4;
            var AnimalsList = A.CollectionOfDummy<Animal>(count).ToList();
            A.CallTo(() => _animalsService.GetAllAnimals(true)).Returns(AnimalsList);
            var controller = new AnimalsController(_animalsService);

            // Act
            var actionResult = await controller.GetAllAnimals();

            // Assert
            var result = actionResult as OkObjectResult;
            var returnedValues = result.Value as List<Animal>;
            Assert.Equal(count, returnedValues.Count);
        }

        [Fact]
        public async Task GetAnimal_ReturnsCorrectValue()
        {
            // Arrange
            var fakeId = 2;
            var fakeName = "Vardas";
            var fakeAnimal = new Animal { Id = fakeId, Name = fakeName };
            A.CallTo(() => _animalsService.GetAnimal(fakeId)).Returns(Task.FromResult(fakeAnimal));
            var controller = new AnimalsController(_animalsService);

            // Act
            var actionResult = await controller.GetAnimal(fakeId);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var actualValue = result.Value as Animal;
            Assert.Equal(fakeAnimal, actualValue);
        }

        [Fact]
        public async Task AddAnimal_ReturnsCorrectValue()
        {
            //Arrange
            int fakeId = 1;
            string fakeName = "Vardas";
            var fakeAnimal = new Animal { Id = fakeId, Name = fakeName };
            var fakeDto = new AddAnimalDto { Name = fakeName };
            A.CallTo(() => _animalsService.AddAnimal(fakeDto)).Returns(Task.FromResult(fakeAnimal));
            var controller = new AnimalsController(_animalsService);

            // Act
            var actionResult = await controller.AddAnimal(fakeDto);

            // Assert
            var result = actionResult as ObjectResult;
            var returnedValue = result.Value as Animal;
            Assert.Equal(fakeAnimal, returnedValue);
        }

        [Fact]
        public async Task UpdateAnimal_ReturnsCorrectValue()
        {
            // Arrange
            int fakeId = 3;
            string fakeName = "vardas";
            var fakeAnimal = new Animal { Id = fakeId, Name = fakeName };
            var fakeDto = new UpdateAnimalDto { Name = fakeName };
            A.CallTo(() => _animalsService.UdateAnimal(fakeDto, fakeId)).Returns(Task.FromResult(fakeAnimal));
            var controller = new AnimalsController(_animalsService);

            // Act
            var actionResult = await controller.UpdateAnimal(fakeDto, fakeId);

            // Assert
            var result = actionResult as ObjectResult;
            var returnedAnimal = result.Value as Animal;
            Assert.Equal(fakeAnimal, returnedAnimal);
        }

        [Fact]
        public async Task DeleteAnimal_ReturnsOk()
        {
            // Arrange
            int fakeId = 3;
            A.CallTo(() => _animalsService.DeleteAnimal(fakeId)).Returns(Task.FromResult(new Animal()));
            var controller = new AnimalsController(_animalsService);

            // Act
            var actionResult = await controller.DeleteAnimal(fakeId);

            // Assert
            var result = actionResult as ObjectResult;
            Assert.Equal(result.StatusCode, 200);
        }
    }
}
