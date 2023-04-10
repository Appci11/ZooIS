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

            _context.Species.Add(species);
            await _context.SaveChangesAsync();

            foreach (var item in addSpeciesDto.TagsIs)
            {
                species.TagsIs.Add(new SpeciesTagIs { SpeciesId = species.Id, TagId = item });
            }
            foreach (var item in addSpeciesDto.TagsRequire)
            {
                species.TagsRequire.Add(new SpeciesTagRequire { SpeciesId = species.Id, TagId = item });
            }
            foreach (var item in addSpeciesDto.TagsAvoid)
            {
                species.TagsAvoid.Add(new SpeciesTagAvoid { SpeciesId = species.Id, TagId = item });
            }
            await _context.SaveChangesAsync();

            return species;
        }

        public async Task<List<Species>> GetAllSpecies(bool addTags)
        {
            if (addTags)
            {
                return await _context.Species
                                    .Include(s => s.TagsIs)
                                    .Include(s => s.TagsRequire)
                                    .Include(s => s.TagsAvoid)
                                    .Include(s => s.Animals)
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
                                .Include(s => s.TagsIs)
                                .Include(s => s.TagsRequire)
                                .Include(s => s.TagsAvoid)
                                .FirstOrDefaultAsync();
            }
            return await _context.Species.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Species> UpdateSpecies(UpdateSpeciesDto updateSpeciesDto, int id)
        {
            //Species species = await _context.Species.FirstOrDefaultAsync(s => s.Id == id);
            Species species = await _context.Species
                                    .Where(s => s.Id == id)
                                    .Include(s => s.TagsIs)
                                    .Include(s => s.TagsRequire)
                                    .Include(s => s.TagsAvoid)
                                    .FirstOrDefaultAsync();
            if (species == null) { return null; }
            species.Name = updateSpeciesDto.Name;
            species.TagsAvoid = new();
            species.TagsIs.Clear();
            species.TagsRequire.Clear();
            foreach (var item in updateSpeciesDto.TagsIs)
            {
                species.TagsIs.Add(new SpeciesTagIs { SpeciesId = species.Id, TagId = item });
            }
            foreach (var item in updateSpeciesDto.TagsRequire)
            {
                species.TagsRequire.Add(new SpeciesTagRequire { SpeciesId = species.Id, TagId = item });
            }
            foreach (var item in updateSpeciesDto.TagsAvoid)
            {
                species.TagsAvoid.Add(new SpeciesTagAvoid { SpeciesId = species.Id, TagId = item });
            }

            await _context.SaveChangesAsync();

            return species;
        }

        public async Task<Species> DeleteSpecies(int id)
        {
            Species species = await _context.Species.FirstOrDefaultAsync(s => s.Id == id);
            if (species == null)
            {
                return null;
            }
            _context.Species.Remove(species);
            await _context.SaveChangesAsync();
            return species;
        }
    }
}
