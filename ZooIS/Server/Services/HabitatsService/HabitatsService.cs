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

            habitat.Name = addHabitatDto.Name;
            habitat.Description = addHabitatDto.Description;
            habitat.AreaId = addHabitatDto.AreaId;
            List<Tag> dbTags = await _context.Tags.ToListAsync();
            foreach (var item in addHabitatDto.Tags)
            {
                Tag dbTag = dbTags.FirstOrDefault(t => t.Id == item.Id);
                if (dbTag != null)
                {
                    habitat.Tags.Add(dbTag);
                }
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
                return await _context.Habitats
                                    .Where(h => h.Id == id)
                                    .Include(h => h.Tags)
                                    .FirstOrDefaultAsync();
            }
            return await _context.Habitats.FirstOrDefaultAsync();
        }

        public async Task<Habitat> UpdateHabitat(UpdateHabitatDto updateHabitatDto, int id)
        {
            Habitat habitat = await _context.Habitats
                                    .Where(h => h.Id == id)
                                    .Include(h => h.Tags)
                                    .FirstOrDefaultAsync();

            habitat.Name = updateHabitatDto.Name;
            habitat.Description = updateHabitatDto.Description;
            habitat.AreaId = updateHabitatDto.AreaId;
            habitat.Tags.Clear();
            List<Tag> dbTags = await _context.Tags.ToListAsync();
            foreach (var item in updateHabitatDto.Tags)
            {
                Tag dbTag = dbTags.FirstOrDefault(t => t.Id == item.Id);
                if (dbTag != null)
                {
                    habitat.Tags.Add(dbTag);
                }
            }
            await _context.SaveChangesAsync();

            return habitat;
        }

        public async Task<Habitat> DeleteHabitat(int id)
        {
            Habitat habitat = await _context.Habitats.FirstOrDefaultAsync(h => h.Id == id);
            if(habitat == null)
            {
                return null;
            }
            _context.Remove(habitat);
            await _context.SaveChangesAsync();
            return habitat;
        }
    }
}
