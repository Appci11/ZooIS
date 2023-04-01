using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.AreasService
{
    public class AreasService : IAreasService
    {
        private readonly DataContext _context;

        public AreasService(DataContext context)
        {
            _context = context;
        }

        public async Task<Area> AddArea(AddAreaDto areaDto)
        {
            Area area = new Area();

            area.Name = areaDto.Name;

            _context.Areas.Add(area);
            await _context.SaveChangesAsync();

            return area;
        }

        public async Task<Area> DeleteArea(int id)
        {
            Area? area = await _context.Areas.FirstOrDefaultAsync(x => x.Id == id);
            if (area == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();

            return area;
        }

        public async Task<List<Area>> GetAllAreas(bool includeReleated)
        {
            if (includeReleated)
            {
                return await _context.Areas
                    .Include(a => a.Habitats)
                    .ToListAsync();
            }
            return await _context.Areas
                .ToListAsync();
        }

        public async Task<Area> GetArea(int id)
        {
            Area? area = await _context.Areas.FirstOrDefaultAsync(_x => _x.Id == id);
#pragma warning disable CS8603 // Possible null reference return.
            return area;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Area> UpdateArea(UpdateAreaDto updateAreaDto, int id)
        {
            Area? area = await _context.Areas.FirstOrDefaultAsync(_x => _x.Id == id);
            if (area == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            
            area.Name = updateAreaDto.Name;

            await _context.SaveChangesAsync();

            return area;
        }
    }
}
