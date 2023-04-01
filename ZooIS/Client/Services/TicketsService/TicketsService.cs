using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.TicketsService
{
    public class TicketsService : ITicketsService
    {
        private readonly HttpClient _http;

        public List<Ticket> Tickets { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public TicketsService(HttpClient http)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _http = http;
        }

        public Task<bool> CreateTicket(Ticket tag)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTicket(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetTicket(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetTickets()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTicket(Ticket tag)
        {
            throw new NotImplementedException();
        }
    }
}
