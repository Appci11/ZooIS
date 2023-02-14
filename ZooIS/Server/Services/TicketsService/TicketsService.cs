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
            Ticket ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if(ticket == null)
            {
                return null;
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
            Ticket ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            return ticket;
        }

        public async Task<Ticket> UpdateTicket(int id, UpdateTicketDto updateTicketDto)
        {
            Ticket dbTicket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            if (dbTicket == null)
            {
                return null;
            }
            dbTicket.Price = updateTicketDto.Price;
            dbTicket.Name = updateTicketDto.Name;
            await _context.SaveChangesAsync();

            return dbTicket;
        }
    }
}
