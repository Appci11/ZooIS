using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.TicketsService
{
    public interface ITicketsService
    {
        Task<Ticket> AddTicket(AddTicketDto ticketDto);
        Task<List<Ticket>> GetAllTickets();
        Task<Ticket> GetTicket(int id);
        Task<Ticket> UpdateTicket(int id, UpdateTicketDto updateTicketDto);
        Task<Ticket> DeleteTicket(int id);
    }
}
