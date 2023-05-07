using FakeItEasy;
using ZooIS.Server.Controllers;
using ZooIS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Shared.Dto;
using ZooIS.Server.Services.BundlesService;

namespace TestProject.Server.Controllers
{
    public class BundlesControllerTests
    {
        private readonly IBundlesService _bundlesService;
        public BundlesControllerTests()
        {
            _bundlesService = A.Fake<IBundlesService>();
        }

        [Fact]
        public async Task GetAllBundles_ReturnsCorrectAmmount()
        {
            // Arrange
            int count = 10;
            var BundlesList = A.CollectionOfDummy<Bundle>(count).ToList();
            A.CallTo(() => _bundlesService.GetAllBundles(true)).Returns(BundlesList);
            var controller = new BundlesController(_bundlesService);

            // Act
            var actionResult = await controller.GetAllBundles();

            // Assert
            var result = actionResult as OkObjectResult;
            var returnedBundles = result.Value as List<Bundle>;
            Assert.Equal(count, returnedBundles.Count);
        }

        [Fact]
        public async Task GetBundle_ReturnsCorrectValue()
        {
            // Arrange
            var fakeId = 1;
            var fakeBundle = new Bundle { Id = fakeId };
            A.CallTo(() => _bundlesService.GetBundle(fakeId, true)).Returns(Task.FromResult(fakeBundle));
            var controller = new BundlesController(_bundlesService);

            // Act
            var actionResult = await controller.GetBundle(fakeId);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var actualValue = result.Value as Bundle;
            Assert.Equal(fakeBundle, actualValue);
        }

        [Fact]
        public async Task GetBundleByUserId_ReturnsCorrectValue()
        {
            // Arrange
            var fakeId = 1;
            var fakeBundle = new Bundle { Id = fakeId };
            A.CallTo(() => _bundlesService.GetBundleByUserId(fakeId, true)).Returns(Task.FromResult(fakeBundle));
            var controller = new BundlesController(_bundlesService);

            // Act
            var actionResult = await controller.GetBundleByUserId(fakeId);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var actualValue = result.Value as Bundle;
            Assert.Equal(fakeBundle, actualValue);
        }

        [Fact]
        public async Task GetLatestUserBundle_ReturnsCorrectValue()
        {
            // Arrange
            var fakeId = 1;
            var fakeBundle = new Bundle { Id = fakeId };
            A.CallTo(() => _bundlesService.GetLatestUserBundle(fakeId, true)).Returns(Task.FromResult(fakeBundle));
            var controller = new BundlesController(_bundlesService);

            // Act
            var actionResult = await controller.GetLatestUserBundle(fakeId);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var actualValue = result.Value as Bundle;
            Assert.Equal(fakeBundle, actualValue);
        }

        [Fact]
        public async Task AddBundle_ReturnsCorrectValue()
        {
            // Arrange
            int fakeId = 1;
            var fakeBundle = new Bundle { Id= fakeId };
            var fakeDto = new AddBundleDto();
            A.CallTo(() => _bundlesService.AddBundle(fakeDto)).Returns(Task.FromResult(fakeBundle));
            var controller = new BundlesController(_bundlesService);

            // Act
            var actionResult = await controller.Addbundle(fakeDto);

            // Assert
            var result = actionResult as ObjectResult;
            var actualValue = result.Value as Bundle;
            Assert.Equal(fakeBundle, actualValue);
        }

        [Fact]
        public async Task UpdateBundle_ReturnsCorrectValue()
        {
            // Arrange
            int fakeId = 1;
            var fakeBundle = new Bundle { Id = fakeId };
            var fakeDto = new UpdateBundleDto();
            A.CallTo(() => _bundlesService.UpdateBundle(fakeDto, fakeId)).Returns(Task.FromResult(fakeBundle));
            var controller = new BundlesController(_bundlesService);

            // Act
            var actionResult = await controller.UpdateBundle(fakeDto, fakeId);

            // Assert
            var result = actionResult as OkObjectResult;
            var actualValue = result.Value as Bundle;
            Assert.Equal(fakeBundle, actualValue);
        }

        [Fact]
        public async Task DeleteBundle_ReturnsOk()
        {
            // Arrange
            int fakeId = 1;
            A.CallTo( () => _bundlesService.DeleteBundle(fakeId)).Returns(Task.FromResult(new Bundle()));
            var controller = new BundlesController(_bundlesService);

            // Act
            var actionResult = await controller.DeleteBundle(fakeId);

            // Assert
            var result = actionResult as ObjectResult;
            Assert.Equal(result.StatusCode, 200);
        }
    }
}
