using FakeItEasy;
using ZooIS.Server.Controllers;
using ZooIS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Shared.Dto;
using ZooIS.Server.Services.WorkTasksService;

namespace TestProject.Server.Controllers
{
    public class WorkTasksControllerTests
    {
        readonly IWorkTasksService _workTasksService;
        public WorkTasksControllerTests()
        {
            _workTasksService = A.Fake<IWorkTasksService>();
        }

        [Fact]
        public async void GetAllWorkTasks_ReturnsCorrectAmmount()
        {
            // Arrange
            int count = 4;
            var WorkTasksList = A.CollectionOfDummy<WorkTask>(count).ToList();
            A.CallTo(() => _workTasksService.GetAllWorkTasks()).Returns(WorkTasksList);
            var controller = new WorkTasksController(_workTasksService);

            // Act
            var actionResult = await controller.GetAllWorkTasks();

            // Assert
            var result = actionResult as OkObjectResult;
            var returnedValues = result.Value as List<WorkTask>;
            Assert.Equal(count, returnedValues.Count);
        }

        [Fact]
        public async Task GetWorkTask_ReturnsCorrectValue()
        {
            // Arrange
            var fakeId = 2;
            var fakeName = "Pavadinimas";
            var fakeWorkTask = new WorkTask { Id = fakeId, Name = fakeName };
            A.CallTo(() => _workTasksService.GetWorkTask(fakeId)).Returns(Task.FromResult(fakeWorkTask));
            var controller = new WorkTasksController(_workTasksService);

            // Act
            var actionResult = await controller.GetWorkTask(fakeId);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var actualValue = result.Value as WorkTask;
            Assert.Equal(fakeWorkTask, actualValue);
        }

        [Fact]
        public async Task AddWorkTask_ReturnsCorrectValue()
        {
            //Arrange
            int fakeId = 1;
            string fakeName = "Pavadinimas";
            var fakeWorkTask = new WorkTask { Id = fakeId, Name = fakeName };
            var fakeDto = new AddWorkTaskDto { Name = fakeName };
            A.CallTo(() => _workTasksService.AddWorkTask(fakeDto)).Returns(Task.FromResult(fakeWorkTask));
            var controller = new WorkTasksController(_workTasksService);

            // Act
            var actionResult = await controller.AddWorkTask(fakeDto);

            // Assert
            var result = actionResult as ObjectResult;
            var returnedValue = result.Value as WorkTask;
            Assert.Equal(fakeWorkTask, returnedValue);
        }

        [Fact]
        public async Task UpdateWorkTask_ReturnsCorrectValue()
        {
            //Arrange
            int fakeId = 1;
            string fakeName = "Pavadinimas";
            var fakeWorkTask = new WorkTask { Id = fakeId, Name = fakeName };
            var fakeDto = new UpdateWorkTaskDto { Name = fakeName };
            A.CallTo(() => _workTasksService.UpdateWorkTask(fakeDto, fakeId)).Returns(Task.FromResult(fakeWorkTask));
            var controller = new WorkTasksController(_workTasksService);

            // Act
            var actionResult = await controller.UpdateWorkTask(fakeDto, fakeId);

            // Assert
            var result = actionResult.Result as ObjectResult;
            var returnedValue = result.Value as WorkTask;
            Assert.Equal(fakeWorkTask, returnedValue);
        }

        [Fact]
        public async Task DeleteAnimal_ReturnsOk()
        {
            // Arrange
            int fakeId = 1;
            A.CallTo(() => _workTasksService.DeleteWorkTask(fakeId)).Returns(Task.FromResult(new WorkTask()));
            var controller = new WorkTasksController(_workTasksService);

            // Act
            var actionResult = await controller.DeleteWorkTask(fakeId);

            // Assert
            var result = actionResult as ObjectResult;
            Assert.Equal(result.StatusCode, 200);
        }
    }
}
