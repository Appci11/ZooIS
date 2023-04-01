using Microsoft.EntityFrameworkCore;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.HabitatsService
{
    public class HabitatsService : IHabitatsService
    {
        private readonly DataContext _context;

        public HabitatsService(DataContext context)
        {
            _context = context;
        }

        public async Task<Habitat> AddHabitat(AddHabitatDto addHabitatDto)
        {
            Habitat habitat = new Habitat();

#pragma warning disable CS8601 // Possible null reference assignment.
            habitat.Name = addHabitatDto.Name;
#pragma warning restore CS8601 // Possible null reference assignment.
            habitat.Description = addHabitatDto.Description;
            habitat.AreaId = addHabitatDto.AreaId;
            foreach (int tagId in addHabitatDto.TagIds)
            {
                Tag foundTag;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                foundTag = await _context.Tags.FirstOrDefaultAsync((t) => t.Id == tagId);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                if (foundTag != null) { habitat.Tags.Add(foundTag); }
            }

            _context.Habitats.Add(habitat);
            await _context.SaveChangesAsync();

            return habitat;
        }

        public async Task<List<Habitat>> GetAllHabitats(bool addTags)
        {
            if (addTags) return await _context.Habitats.Include(h => h.Tags).ToListAsync();
            return await _context.Habitats.ToListAsync();
        }

        public async Task<Habitat> GetHabitat(int id, bool addTags)
        {
            if (addTags)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return await _context.Habitats
                                    .Where(h => h.Id == id)
                                    .Include(h => h.Tags)
                                    .FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
            }
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Habitats.FirstOrDefaultAsync(h => h.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Habitat> UpdateHabitat(UpdateHabitatDto updateHabitatDto, int id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Habitat habitat = await _context.Habitats
                                    .Where(h => h.Id == id)
                                    .Include(h => h.Tags)
                                    .FirstOrDefaultAsync();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            habitat.Name = updateHabitatDto.Name;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8601 // Possible null reference assignment.
            habitat.Description = updateHabitatDto.Description;
            habitat.AreaId = updateHabitatDto.AreaId;
            habitat.Tags.Clear();
            List<Tag> dbTags = await _context.Tags.ToListAsync();
            foreach (int tagId in updateHabitatDto.TagIds)
            {
                Tag foundTag;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                foundTag = await _context.Tags.FirstOrDefaultAsync((t) => t.Id == tagId);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                if (foundTag != null) { habitat.Tags.Add(foundTag); }
            }
            await _context.SaveChangesAsync();

            return habitat;
        }

        public async Task<Habitat> DeleteHabitat(int id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Habitat habitat = await _context.Habitats.FirstOrDefaultAsync(h => h.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if(habitat == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            _context.Remove(habitat);
            await _context.SaveChangesAsync();
            return habitat;
        }
    }
}
