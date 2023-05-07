using FakeItEasy;
using ZooIS.Server.Controllers;
using ZooIS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Shared.Dto;
using ZooIS.Server.Services.AreasService;

namespace TestProject.Server.Controllers
{
    public class AreasControllerTests
    {
        private readonly IAreasService _areasService;

        public AreasControllerTests()
        {
            _areasService = A.Fake<IAreasService>();
        }

        [Fact]
        public async void GetAllAreas_ReturnsCorrectAmmount()
        {
            // Arrange
            int count = 3;
            var AreasList = A.CollectionOfDummy<Area>(count).ToList();
            A.CallTo(() => _areasService.GetAllAreas(true)).Returns(AreasList);
            var controller = new AreasController(_areasService);

            // Act
            var actionResult = await controller.GetAllAreas();

            // Assert
            var result = actionResult as OkObjectResult;
            var returnedAreas = result.Value as List<Area>;
            Assert.Equal(count, returnedAreas.Count);
        }

        [Fact]
        public async void GetArea_ReturnsCorrectValue()
        {
            // Arrange
            var fakeId = 1;
            var fakeName = "Pavadinimas";
            var fakeArea = new Area { Id = fakeId, Name = fakeName };
            A.CallTo(() => _areasService.GetArea(fakeId)).Returns(Task.FromResult(fakeArea));
            var controller = new AreasController(_areasService);

            // act
            var actionResult = await controller.GetArea(fakeId);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var actualValue = result.Value as Area;
            Assert.Equal(fakeArea, actualValue);
        }

        [Fact]
        public async void AddArea_ReturnsCorrectValue()
        {
            // Arrange
            var fakeId = 1;
            var fakeName = "Pavadinimas";
            var fakeArea = new Area { Id = fakeId, Name = fakeName };
            var fakeDto = new AddAreaDto { Name = fakeName };
            A.CallTo(() => _areasService.AddArea(fakeDto)).Returns(Task.FromResult(fakeArea));
            var controller = new AreasController(_areasService);

            // Act
            var actionResult = await controller.AddArea(fakeDto);

            // Assert
            var result = actionResult as ObjectResult;
            var returnedArea = result.Value as Area;
            Assert.Equal(fakeArea, returnedArea);
        }

        [Fact]
        public async void UpdateArea_ReturnsCorrectValue()
        {
            // Arrange
            var fakeId = 1;
            var fakeName = "Pavadinimas";
            var fakeArea = new Area { Id = fakeId, Name = fakeName };
            var fakeDto = new UpdateAreaDto { Name = fakeName };
            A.CallTo(() => _areasService.UpdateArea(fakeDto, fakeId)).Returns(Task.FromResult(fakeArea));
            var controller = new AreasController(_areasService);

            // Act
            var actionResult = await controller.UpdateArea(fakeDto, fakeId);

            // Assert
            var result = actionResult.Result as ObjectResult;
            var returnedArea = result.Value as Area;
            Assert.Equal(fakeArea, returnedArea);
        }

        [Fact]
        public async Task DeleteArea_ReturnsOk()
        {
            // Arrange
            int fakeId = 1;
            A.CallTo(() => _areasService.DeleteArea(fakeId)).Returns(Task.FromResult(new Area()));
            var controller = new AreasController(_areasService);

            // Act
            var actionResult = await controller.DeleteArea(fakeId);

            // Assert
            var result = actionResult as ObjectResult;
            Assert.Equal(result.StatusCode, 200);
        }
    }
}

