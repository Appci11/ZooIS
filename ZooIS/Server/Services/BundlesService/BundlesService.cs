using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
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

            bundle.RegisteredUserId = addBundleDto.RegisteredUserId;

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

        public async Task<List<Bundle>> GetAllBundles(bool includeRelated)
        {
            List<Bundle> bundles;
            if (!includeRelated)
            {
                bundles = await _context.Bundles
                                           .Include(t => t.BundleTickets)
                                           .ToListAsync();
                return bundles;
            }
            bundles = await _context.Bundles
                           .Include(b => b.BundleTickets)
                           .ThenInclude(t => t.Ticket)
                           .ToListAsync();
            return bundles;
        }

        public async Task<Bundle> GetLatestUserBundle(int userId, bool includeRelated)
        {
            List<Bundle> bundles;
            if (!includeRelated)
            {
                bundles = await _context.Bundles
                                           .Include(t => t.BundleTickets)
                                           .ToListAsync();
            }
            bundles = await _context.Bundles
                           .Include(b => b.BundleTickets)
                           .ThenInclude(t => t.Ticket)
                           .ToListAsync();

            DateTime dt = DateTime.MinValue;
            foreach(var bundle in bundles)
            {
                if (bundle.DateOfUse > dt)
                {
                    dt = bundle.DateOfUse;
                }
            }
            Bundle returnValue = bundles.FirstOrDefault(b => b.DateOfUse == dt);
            if(returnValue.DateOfUse.DayOfYear >= DateTime.Today.DayOfYear)
            {
                return returnValue;
            }
            return null;
        }

        public async Task<Bundle> GetBundle(int id, bool includeRelated)
        {
            Bundle bundle;
            if (!includeRelated)
            {
                bundle = await _context.Bundles
                                            .Where(t => t.Id == id)
                                            .Include(b => b.BundleTickets)
                                            .FirstOrDefaultAsync();
                return bundle;
            }
            bundle = await _context.Bundles
                              .Where(t => t.Id == id)
                              .Include(b => b.BundleTickets)
                              .ThenInclude(t => t.Ticket)
                              .FirstOrDefaultAsync();
            return bundle;
        }

        public async Task<Bundle> GetBundleByUserId(int id, bool includeRelated)
        {
            Bundle bundle;
            if (!includeRelated)
            {
                bundle = await _context.Bundles
                                            .Where(t => t.RegisteredUserId == id)
                                            .Include(b => b.BundleTickets)
                                            .FirstOrDefaultAsync();
                return bundle;
            }
            bundle = await _context.Bundles
                              .Where(t => t.RegisteredUserId == id)
                              .Include(b => b.BundleTickets)
                              .ThenInclude(t => t.Ticket)
                              .FirstOrDefaultAsync();
            return bundle;
        }

        public async Task<Bundle> UpdateBundle(AddBundleDto addBundleDto, int id)
        {
            Bundle bundle = await _context.Bundles.FirstOrDefaultAsync(i => i.Id == id);
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
