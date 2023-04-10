using Microsoft.EntityFrameworkCore;
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
            area.Nr = areaDto.Nr;

            _context.Areas.Add(area);
            await _context.SaveChangesAsync();

            return area;
        }

        public async Task<Area> DeleteArea(int id)
        {
            Area? area = await _context.Areas.FirstOrDefaultAsync(x => x.Id == id);
            if (area == null)
            {
                return null;
            }
            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();

            return area;
        }

        public async Task<Area> DeleteAreaByNr(int Nr)
        {
            Area? area = await _context.Areas.FirstOrDefaultAsync(x => x.Nr == Nr);
            if (area == null)
            {
                return null;
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
            return area;
        }

        public async Task<Area> UpdateArea(UpdateAreaDto updateAreaDto, int id)
        {
            Area? area = await _context.Areas.FirstOrDefaultAsync(_x => _x.Id == id);
            if (area == null)
            {
                return null;
            }

            area.Name = updateAreaDto.Name;

            await _context.SaveChangesAsync();

            return area;
        }

        public async Task<List<int>> GetExistingAreaTags(int id)
        {
            List<int> ids = _context.Database
                .SqlQuery<int>($"SELECT DISTINCT TagId FROM Areas INNER JOIN Habitats ON Habitats.AreaId = Areas.Id INNER JOIN Animals ON Animals.HabitatId = Habitats.Id INNER JOIN Species ON Animals.SpeciesId = Species.Id INNER JOIN SpeciesTagIs ON Species.Id = SpeciesTagIs.SpeciesId WHERE Areas.Id = {id} UNION ALL SELECT DISTINCT TagsId FROM Areas INNER JOIN Habitats ON Habitats.AreaId = Areas.Id INNER JOIN HabitatTag ON Habitats.Id = HabitatTag.HabitatsId WHERE Areas.Id = {id}")
                .ToList();
            return ids;
        }

        public async Task<List<int>> GetAreaTagsToAvoid(int id)
        {
            List<int> ids = _context.Database
                .SqlQuery<int>($"SELECT DISTINCT TagId FROM Areas INNER JOIN Habitats ON Habitats.AreaId = Areas.Id INNER JOIN Animals ON Animals.HabitatId = Habitats.Id INNER JOIN Species ON Animals.SpeciesId = Species.Id INNER JOIN SpeciesTagAvoid ON Species.Id = SpeciesTagAvoid.SpeciesId WHERE Areas.Id = {id}")
                .ToList();
            return ids;
        }
    }
}
