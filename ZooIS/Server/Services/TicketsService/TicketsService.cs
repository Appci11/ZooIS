using SQLitePCL;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.TicketsService
{
    public class TicketsService : ITicketsService
    {
        private readonly DataContext _context;

        public TicketsService(DataContext context)
        {
            _context = context;
        }
        public async Task<Ticket> AddTicket(AddTicketDto ticketDto)
        {
            Ticket ticket = new Ticket();

            ticket.Name = ticketDto.Name;
            ticket.Price = ticketDto.Price;

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        public async Task<Ticket> DeleteTicket(int id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Ticket ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if(ticket == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetTicket(int id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Ticket ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8603 // Possible null reference return.
            return ticket;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Ticket> UpdateTicket(int id, UpdateTicketDto updateTicketDto)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Ticket dbTicket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (dbTicket == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            dbTicket.Price = updateTicketDto.Price;
            dbTicket.Name = updateTicketDto.Name;
            await _context.SaveChangesAsync();

            return dbTicket;
        }
    }
}
