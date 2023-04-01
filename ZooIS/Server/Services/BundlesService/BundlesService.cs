using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.BundlesService
{
    public class BundlesService : IBundlesService
    {
        private readonly DataContext _context;

        public BundlesService(DataContext context)
        {
            _context = context;
        }

        private async Task<double> CalculatePrice(Bundle bundle)
        {
            List<Ticket> tickets = await _context.Tickets.ToListAsync();
            if (tickets == null)
            {
                // paieskot kaip ismest error'a, kad nepavyko prie ticket'u prieit
                return -1;
            }
            double totalPrice = 0;
            foreach (var item in bundle.BundleTickets)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                double price = tickets.FirstOrDefault(p => p.Id == item.TicketId).Price;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                if (price != 0) //siek tiek sumazinam rizika
                {
                    totalPrice += price * item.Quantity;
                }

            }
            return totalPrice;
        }

        public async Task<Bundle> AddBundle(AddBundleDto addBundleDto)
        {
            Bundle bundle = new Bundle();

            bundle.RegisteredUserId = addBundleDto.UserId;

            foreach (var item in addBundleDto.BundleTickets)
            {
                BundleTicket toAdd = new BundleTicket();
                toAdd.TicketId = item.TicketId;
                toAdd.Quantity = item.Quantity;
                bundle.BundleTickets.Add(toAdd);
            }
            _context.Bundles.Add(bundle);
            await _context.SaveChangesAsync();

            bundle.Price = await CalculatePrice(bundle);
            await _context.SaveChangesAsync();

            return bundle;
        }

        public async Task<List<Bundle>> GetAllBundles()
        {
            //var bundles = await _context.Bundles.ToListAsync();
            var bundles = await _context.Bundles
                                        .Include(t => t.BundleTickets)
                                        .ToListAsync();

            return bundles;
        }

        public async Task<List<Bundle>> GetAllBundlesWithTickets()
        {
            var bundles = await _context.Bundles
                                        .Include(b => b.BundleTickets)
                                        .ThenInclude(t => t.Ticket)
                                        .ToListAsync();
            return bundles;
        }

        public async Task<Bundle> GetBundle(int id)
        {
            Bundle? bundle = await _context.Bundles
                                        .Where(t => t.Id == id)
                                        .Include(b => b.BundleTickets)
                                        .FirstOrDefaultAsync();
#pragma warning disable CS8603 // Possible null reference return.
            return bundle;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Bundle> GetBundleWithTickets(int id)
        {
            Bundle? bundle = await _context.Bundles
                              .Where(t => t.Id == id)
                              .Include(b => b.BundleTickets)
                              .ThenInclude(t => t.Ticket)
                              .FirstOrDefaultAsync();
#pragma warning disable CS8603 // Possible null reference return.
            return bundle;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Bundle> UpdateBundle(AddBundleDto addBundleDto, int id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Bundle bundle = await _context.Bundles.FirstOrDefaultAsync(i => i.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            // kol bilietu rusiu nedaug(taip kol kas tikimasi)
            // tol turetu buti greiciau senuosius saraso irasus pasalinti
            // ir uzpildyti naujais
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            bundle.BundleTickets.Clear();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            foreach (var item in addBundleDto.BundleTickets)
            {
                BundleTicket toAdd = new BundleTicket();
                toAdd.TicketId = item.TicketId;
                toAdd.Quantity = item.Quantity;
                bundle.BundleTickets.Add(toAdd);
            }
            await _context.SaveChangesAsync();
            bundle.Price = await CalculatePrice(bundle);
            await _context.SaveChangesAsync();

            return bundle;
        }

        public async Task<Bundle> DeleteBundle(int id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Bundle bundle = await _context.Bundles.FirstOrDefaultAsync(i => i.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (bundle == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            _context.Bundles.Remove(bundle);
            await _context.SaveChangesAsync();
            return bundle;
        }
    }
}
