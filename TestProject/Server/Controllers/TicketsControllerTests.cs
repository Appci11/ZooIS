using FakeItEasy;
using ZooIS.Server.Controllers;
using ZooIS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Shared.Dto;
using ZooIS.Server.Services.TicketsService;

namespace TestProject.Server.Controllers
{
    public class TicketsControllerTests
    {
        private readonly ITicketsService _ticketsService;
        public TicketsControllerTests()
        {
            _ticketsService = A.Fake<ITicketsService>();
        }

        [Fact]
        public async void GetAllTickets_ReturnsCorrectAmmount()
        {
            // Arrange
            int count = 4;
            var TicketsList = A.CollectionOfDummy<Ticket>(count).ToList();
            A.CallTo(() => _ticketsService.GetAllTickets()).Returns(TicketsList);
            var controller = new TicketsController(_ticketsService);

            // Act
            var actionResult = await controller.GetAllTickets();

            // Assert
            var result = actionResult as OkObjectResult;
            var returnedTickets = result.Value as List<Ticket>;
            Assert.Equal(count, returnedTickets.Count);
        }

        [Fact]
        public async Task GetTicket_ReturnsCorrectValue()
        {
            // Arrange
            var fakeId = 1;
            var fakeName = "Pavadinimas";
            var fakeTicket = new Ticket { Id = fakeId, Name = fakeName };
            A.CallTo(() => _ticketsService.GetTicket(fakeId)).Returns(Task.FromResult(fakeTicket));
            var controller = new TicketsController(_ticketsService);

            // Act
            var actionResult = await controller.GetTicket(fakeId);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var actualValue = result.Value as Ticket;
            Assert.Equal(fakeTicket, actualValue);
        }

        [Fact]
        public async Task AddTicket_ReturnsCorrectValue()
        {
            //Arrange
            int fakeId = 1;
            string fakeName = "Pavadinimas";
            var fakeTicket = new Ticket { Id = fakeId, Name = fakeName };
            var fakeDto = new AddTicketDto { Name = fakeName };
            A.CallTo(() => _ticketsService.AddTicket(fakeDto)).Returns(Task.FromResult(fakeTicket));
            var controller = new TicketsController(_ticketsService);

            // Act
            var actionResult = await controller.AddTicket(fakeDto);

            // Assert
            var result = actionResult as ObjectResult;
            var returnedValue = result.Value as Ticket;
            Assert.Equal(fakeTicket, returnedValue);
        }

        [Fact]
        public async Task UpdateTicket_ReturnsCorrectValue()
        {
            //Arrange
            int fakeId = 1;
            string fakeName = "Pavadinimas";
            var fakeTicket = new Ticket { Id = fakeId, Name = fakeName };
            var fakeDto = new UpdateTicketDto { Name = fakeName };
            A.CallTo(() => _ticketsService.UpdateTicket(fakeId, fakeDto)).Returns(Task.FromResult(fakeTicket));
            var controller = new TicketsController(_ticketsService);

            // Act
            var actionResult = await controller.TicketUpdate(fakeId, fakeDto);

            // Assert
            var result = actionResult.Result as ObjectResult;
            var returnedValue = result.Value as Ticket;
            Assert.Equal(fakeTicket, returnedValue);
        }

        [Fact]
        public async Task DeleteTicket_ReturnsOk()
        {
            // Arrange
            int fakeId = 1;
            A.CallTo(() => _ticketsService.DeleteTicket(fakeId)).Returns(Task.FromResult(new Ticket()));
            var controller = new TicketsController(_ticketsService);

            // Act
            var actionResult = await controller.DeleteTicket(fakeId);

            // Assert
            var result = actionResult as ObjectResult;
            Assert.Equal(result.StatusCode, 200);
        }
    }
}
