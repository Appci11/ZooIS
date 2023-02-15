using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Server.Services.TicketsService;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService _ticketsService;

        public TicketsController(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket(AddTicketDto request)
        {
            Ticket response = await _ticketsService.AddTicket(request);
            if (response == null) return NotFound(new { message = "Ticket was not created" });
            return Created($"/api/tickets/{response.Id}", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            List<Ticket> response = await _ticketsService.GetAllTickets();
            if (response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound(new { message = "No tickets were found..." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            Ticket response = await _ticketsService.GetTicket(id);
            if (response == null) return NotFound(new { message = "Ticket no found" });
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ticket>> TicketUpdate(int id, UpdateTicketDto updateTicketDto)
        {
            Ticket response = await _ticketsService.UpdateTicket(id, updateTicketDto);
            if (response == null)
            {
                return NotFound(new { message = "Ticket was not updated" });
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            Ticket response = await _ticketsService.DeleteTicket(id);
            if(response == null)
            {
                return NotFound(new { message = "Ticket was not deleted" });
            }
            return Ok(response);
        }
    }
}
