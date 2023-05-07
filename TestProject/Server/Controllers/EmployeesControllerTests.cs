using FakeItEasy;
using ZooIS.Server.Controllers;
using ZooIS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Shared.Dto;
using ZooIS.Server.Services.EmployeesService;

namespace TestProject.Server.Controllers
{
    public class EmployeesControllerTests
    {
        public readonly IEmployeesService _employeesService;
        public EmployeesControllerTests()
        {
            _employeesService = A.Fake<IEmployeesService>();
        }

        [Fact]
        public async void GetAllEmployees_ReturnsCorrectAmmount()
        {
            // Arrange
            int count = 20;
            var EmployeesList = A.CollectionOfDummy<Employee>(count).ToList();
            A.CallTo(() => _employeesService.GetAllEmployees()).Returns(EmployeesList);
            var controller = new EmployeesController(_employeesService);

            // Act
            var actionResult = await controller.GetAllEmployees();

            //Assert
            var result = actionResult as OkObjectResult;
            var returnedEmployees = result.Value as List<Employee>;
            Assert.Equal(count, returnedEmployees.Count);
        }

        [Fact]
        public async Task GetEmployee_ReturnsCorrectValue()
        {
            // Arrange
            int fakeId = 1;
            var fakeUsername = "Vardas";
            var fakeEmployee = new Employee { Id = fakeId, Username = fakeUsername };
            A.CallTo(() => _employeesService.GetEmployee(fakeId)).Returns(Task.FromResult(fakeEmployee));
            var controller = new EmployeesController(_employeesService);

            // Act
            var actionResult = await controller.GetEmployee(fakeId);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var actualValue = result.Value as Employee;
            Assert.Equal(fakeEmployee, actualValue);
        }

        [Fact]
        public async Task AddEmployee_ReturnsCorrectValue()
        {
            // Arrange
            int fakeId = 1;
            string fakeUsername = "vardas";
            var fakeEmployee = new Employee { Id = fakeId, Username = fakeUsername };
            var fakeDto = new AddEmployeeDto { Username = fakeUsername };
            A.CallTo(() => _employeesService.AddEmployee(fakeDto)).Returns(Task.FromResult(fakeEmployee));
            var controller = new EmployeesController(_employeesService);

            // Act
            var actionResult = await controller.AddEmployee(fakeDto);

            // Assert
            var result = actionResult as ObjectResult;
            var returnedEmployee = result.Value as Employee;
            Assert.Equal(fakeEmployee, returnedEmployee);
        }

        [Fact]
        public async Task UpdateEmployee_ReturnsCorrectValue()
        {
            // Arrange
            int fakeId = 1;
            string fakeUsername = "vardas";
            var fakeEmployee = new Employee { Id = fakeId, Username = fakeUsername };
            var fakeDto = new UpdateEmployeeDto { Username = fakeUsername,
                Email = "Pastas", DateOfDismissal = DateTime.Now, DeletionRequested = false,
                IsDeleted = false, DateOfEmployment = DateTime.Now, RequestPasswordReset = false,
                Role = "kazkas" };
            A.CallTo(() => _employeesService.UpdateEmployee(fakeDto, fakeId)).Returns(Task.FromResult(fakeEmployee));
            var controller = new EmployeesController(_employeesService);

            // Act
            var actionResult = await controller.UpdateEmployee(fakeDto, fakeId);

            // Assert
            var result = actionResult.Result as ObjectResult;
            var returnedEmployee = result.Value as Employee;
            Assert.Equal(fakeEmployee, returnedEmployee);
        }

        [Fact]
        public async Task DeleteEmployee_ReturnsOk()
        {
            // Arrange
            int fakeId = 1;
            A.CallTo(() => _employeesService.DeleteEmployee(fakeId)).Returns(Task.FromResult(new Employee()));
            var controller = new EmployeesController(_employeesService);

            // Act
            var actionResult = await controller.DeleteEmployee(fakeId);

            // Assert
            var result = actionResult as ObjectResult;
            Assert.Equal(result.StatusCode, 200);
        }
    }
}
