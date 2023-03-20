using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.TicketsService
{
    public interface ITicketsService
    {
        List<Ticket> Tickets { get; set; }

        public Task GetTickets();
        public Task<Ticket> GetTicket(int id);
        public Task<bool> CreateTicket(Ticket tag);
        public Task<bool> UpdateTicket(Ticket tag);
        public Task<bool> DeleteTicket(int id);
    }
}
