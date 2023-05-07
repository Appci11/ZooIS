using FakeItEasy;
using ZooIS.Server.Controllers;
using ZooIS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Shared.Dto;
using ZooIS.Server.Services.MapsService;

namespace TestProject.Server.Controllers
{
    public class MapsControllerTests
    {
        private readonly IMapsService _mapsService;
        public MapsControllerTests()
        {
            _mapsService = A.Fake<IMapsService>();
        }

        [Fact]
        public async Task GetMap_ReturnsCorrectValue()
        {
            // Arrange
            var fakeId = 1;
            var fakeMap = new Map{ Id = fakeId};
            A.CallTo(() => _mapsService.GetMap()).Returns(Task.FromResult(fakeMap));
            var controller = new MapsController(_mapsService);

            // Act
            var actionResult = await controller.GetMap();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var actualValue = result.Value as Map;
            Assert.Equal(fakeMap, actualValue);
        }

        [Fact]
        public async Task AddMap_ReturnsCorrectValue()
        {
            //Arrange
            int fakeId = 1;
            var fakeMap = new Map{ Id = fakeId };
            A.CallTo(() => _mapsService.AddMap(fakeMap)).Returns(Task.FromResult(fakeMap));
            var controller = new MapsController(_mapsService);

            // Act
            var actionResult = await controller.AddMap(fakeMap);

            // Assert
            var result = actionResult as ObjectResult;
            var returnedValue = result.Value as Map;
            Assert.Equal(fakeMap, returnedValue);
        }
    }
}
