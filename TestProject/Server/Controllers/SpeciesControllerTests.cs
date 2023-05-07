using FakeItEasy;
using ZooIS.Server.Controllers;
using ZooIS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Shared.Dto;
using ZooIS.Server.Services.SpeciesService;

namespace TestProject.Server.Controllers
{
    public class SpeciesControllerTests
    {
        private readonly ISpeciesService _speciesService;
        public SpeciesControllerTests()
        {
            _speciesService = A.Fake<ISpeciesService>();
        }

        [Fact]
        public async void GetAllSpecies_ReturnsCorrectAmmount()
        {
            // Arrange
            int count = 2;
            var SpeciesList = A.CollectionOfDummy<Species>(count).ToList();
            A.CallTo(() => _speciesService.GetAllSpecies(true)).Returns(SpeciesList);
            var controller = new SpeciesController(_speciesService);

            // Act
            var actionResult = await controller.GetAllSpecies();

            // Assert
            var result = actionResult as OkObjectResult;
            var returnedSpecies = result.Value as List<Species>;
            Assert.Equal(count, returnedSpecies.Count);
        }

        [Fact]
        public async Task GetAnimal_ReturnsCorrectValue()
        {
            // Arrange
            var fakeId = 1;
            var fakeName = "Pavadinimas";
            var fakeSpecies = new Species { Id = fakeId, Name = fakeName };
            A.CallTo(() => _speciesService.GetSpecies(fakeId, true)).Returns(Task.FromResult(fakeSpecies));
            var controller = new SpeciesController(_speciesService);

            // Act
            var actionResult = await controller.GetSpecies(fakeId);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var actualValue = result.Value as Species;
            Assert.Equal(fakeSpecies, actualValue);
        }

        [Fact]
        public async Task AddSpecies_ReturnsCorrectValue()
        {
            //Arrange
            int fakeId = 1;
            string fakeName = "Pavadinimas";
            var fakeSpecies = new Species { Id = fakeId, Name = fakeName };
            var fakeDto = new AddSpeciesDto { Name = fakeName };
            A.CallTo(() => _speciesService.AddSpecies(fakeDto)).Returns(Task.FromResult(fakeSpecies));
            var controller = new SpeciesController(_speciesService);

            // Act
            var actionResult = await controller.AddSpecies(fakeDto);

            // Assert
            var result = actionResult as ObjectResult;
            var returnedValue = result.Value as Species;
            Assert.Equal(fakeSpecies, returnedValue);
        }

        [Fact]
        public async Task UpdateSpecies_ReturnsCorrectValue()
        {
            //Arrange
            int fakeId = 1;
            string fakeName = "Pavadinimas";
            var fakeSpecies = new Species { Id = fakeId, Name = fakeName };
            var fakeDto = new UpdateSpeciesDto { Name = fakeName };
            A.CallTo(() => _speciesService.UpdateSpecies(fakeDto, fakeId)).Returns(Task.FromResult(fakeSpecies));
            var controller = new SpeciesController(_speciesService);

            // Act
            var actionResult = await controller.UpdateSpecies(fakeDto, fakeId);

            // Assert
            var result = actionResult as ObjectResult;
            var returnedValue = result.Value as Species;
            Assert.Equal(fakeSpecies, returnedValue);
        }

        [Fact]
        public async Task DeleteSpecies_ReturnsOk()
        {
            // Arrange
            int fakeId = 1;
            A.CallTo(() => _speciesService.DeleteSpecies(fakeId)).Returns(Task.FromResult(new Species()));
            var controller = new SpeciesController(_speciesService);

            // Act
            var actionResult = await controller.DeleteSpecies(fakeId);

            // Assert
            var result = actionResult as ObjectResult;
            Assert.Equal(result.StatusCode, 200);
        }
    }
}
