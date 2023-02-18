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
                double price = tickets.FirstOrDefault(p => p.Id == item.TicketId).Price;
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
            //BundleTicket tarp = new BundleTicket();
            //tarp.TicketId = 1;
            //tarp.Quantity = 3;
            //bundle.BundleTickets.Add(tarp);
            foreach (var item in addBundleDto.BundleTickets)
            {
                BundleTicket toAdd = new BundleTicket();
                toAdd.TicketId = item.TicketId;
                toAdd.Quantity = item.Quantity;
                bundle.BundleTickets.Add(toAdd);
            }
            _context.Bundles.Add(bundle);
            await _context.SaveChangesAsync();

            //List<Ticket> tickets = await _context.Tickets.ToListAsync();
            //if (tickets == null)
            //{
            //    // paieskot kaip ismest error'a, kad nepavyko prie ticket'u prieit
            //    return null;
            //}
            //double totalPrice = 0;
            //foreach(var item in bundle.BundleTickets)
            //{
            //    double price = tickets.FirstOrDefault(p => p.Id == item.TicketId).Price;
            //    if(price != 0) //siek tiek sumazinam rizika
            //    {
            //        totalPrice += price * item.Quantity;
            //    }

            //}

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
            return bundle;
        }

        public async Task<Bundle> GetBundleWithTickets(int id)
        {
            Bundle? bundle = await _context.Bundles
                              .Where(t => t.Id == id)
                              .Include(b => b.BundleTickets)
                              .ThenInclude(t => t.Ticket)
                              .FirstOrDefaultAsync();
            return bundle;
        }

        public async Task<Bundle> UpdateBundle(AddBundleDto addBundleDto, int id)
        {
            Bundle bundle = await GetBundle(id);

            // kol bilietu rusiu nedaug(taip kol kas tikimasi)
            // tol turetu buti greiciau senuosius saraso irasus pasalinti
            // ir uzpildyti naujais
            bundle.BundleTickets.Clear();
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
            Bundle bundle = await _context.Bundles.FirstOrDefaultAsync(i => i.Id == id);
            if (bundle == null)
            {
                return null;
            }
            _context.Bundles.Remove(bundle);
            await _context.SaveChangesAsync();
            return bundle;
        }
    }
}
