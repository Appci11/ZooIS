using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.SpeciesService
{
    public class SpeciesService : ISpeciesService
    {
        private readonly DataContext _context;

        public SpeciesService(DataContext context)
        {
            _context = context;
        }
        public async Task<Species> AddSpecies(AddSpeciesDto addSpeciesDto)
        {
            Species species = new Species();

            species.Name = addSpeciesDto.Name;

            foreach (var item in addSpeciesDto.TagsRequire)
            {
                SpeciesTagRequire toAdd = new SpeciesTagRequire();
                toAdd.TagId = item.Id;
                species.TagsRequire.Add(toAdd);
            }
            foreach (var item in addSpeciesDto.TagsAvoid)
            {
                SpeciesTagAvoid toAdd = new SpeciesTagAvoid();
                toAdd.TagId = item.Id;
                species.TagsAvoid.Add(toAdd);
            }

            _context.Species.Add(species);
            await _context.SaveChangesAsync();

            return species;
        }

        public async Task<List<Species>> GetAllSpecies(bool addTags)
        {
            if (addTags)
            {
                return await _context.Species
                                    .Include(s => s.TagsRequire)
                                    .Include(s => s.TagsAvoid)
                                    .ToListAsync();
            }
            return await _context.Species.ToListAsync();
        }

        public async Task<Species> GetSpecies(int id, bool addTags)
        {
            if (addTags)
            {
                return await _context.Species
                                .Where(s => s.Id == id)
                                .Include(s => s.TagsRequire)
                                .FirstOrDefaultAsync();
            }
            return await _context.Species.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Species> UpdateSpecies(UpdateSpeciesDto updateSpeciesDto, int id)
        {
            Species species = await _context.Species.FirstOrDefaultAsync(s => s.Id == id);

            species.Name = updateSpeciesDto.Name;
            species.TagsRequire.Clear();
            species.TagsAvoid.Clear();
            foreach (var item in updateSpeciesDto.TagsRequire)
            {
                SpeciesTagRequire toAdd = new SpeciesTagRequire();
                toAdd.TagId = item.Id;
                species.TagsRequire.Add(toAdd);
            }
            foreach (var item in updateSpeciesDto.TagsAvoid)
            {
                SpeciesTagAvoid toAdd = new SpeciesTagAvoid();
                toAdd.TagId = item.Id;
                species.TagsAvoid.Add(toAdd);
            }
            await _context.SaveChangesAsync();

            return species;
        }

        public async Task<Species> DeleteSpecies(int id)
        {
            Species species = await _context.Species.FirstOrDefaultAsync(s => s.Id == id);
            if(species == null)
            {
                return null;
            }
            _context.Species.Remove(species);
            await _context.SaveChangesAsync();
            return species;
        }
    }
}
