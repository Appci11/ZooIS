using System.Net.Http.Json;
using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.TicketsService
{
    public class TicketsService : ITicketsService
    {
        private readonly HttpClient _http;

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();

        public TicketsService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CreateTicket(Ticket ticket)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync($"/api/tickets", ticket);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTicket(int id)
        {
            var response = await _http.DeleteAsync($"/api/tickets/{id}");
            if(response.IsSuccessStatusCode)
            {
                Ticket ticket = Tickets.FirstOrDefault(t => t.Id == id);
                if(ticket != null)
                {
                    Tickets.Remove(ticket);
                    return true;
                }
            }
            return false;
        }

        public async Task<Ticket> GetTicket(int id)
        {
            var result = await _http.GetFromJsonAsync<Ticket>($"/api/users/{id}");
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task GetTickets()
        {
            List<Ticket> result = new List<Ticket>();
            try
            {
                result = await _http.GetFromJsonAsync<List<Ticket>>("/api/tickets");

            }
            catch { }
            if(result != null && result.Count > 0)
            {
                Tickets = result;
            }
        }

        public async Task<bool> UpdateTicket(Ticket tag)
        {
            HttpResponseMessage response = await _http.PutAsJsonAsync($"/api/users/{tag.Id}", tag);
            return response.IsSuccessStatusCode;
        }
    }
}
