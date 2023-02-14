using Microsoft.AspNetCore.Http.HttpResults;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.TBundlesService
{
    public class TBundlesService : ITBundlesService
    {
        private readonly DataContext _context;

        public TBundlesService(DataContext context)
        {
            _context = context;
        }

        public async Task<TBundle> AddTBundle(AddTBundleDto addTBundleDto)
        {
            TBundle bundle = new TBundle();
            //TBundleTicket tarp = new TBundleTicket();
            //tarp.TicketId = 1;
            //tarp.Quantity = 3;
            //bundle.TBundleTickets.Add(tarp);
            foreach (var item in addTBundleDto.TBundleTickets)
            {
                TBundleTicket toAdd = new TBundleTicket();
                toAdd.TicketId = item.TicketId;
                toAdd.Quantity = item.Quantity;
                bundle.TBundleTickets.Add(toAdd);
            }
            _context.TBundles.Add(bundle);
            await _context.SaveChangesAsync();
            return bundle;
        }

        public async Task<List<TBundle>> GetAllTBundles()
        {
            //var bundles = await _context.TBundles.ToListAsync();
            var bundles = await _context.TBundles
                                        .Include(t => t.TBundleTickets)
                                        .ToListAsync();

            return bundles;
        }
    }
}
