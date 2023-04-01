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

            foreach (var item in addSpeciesDto.TagsRequire)
            {
                species.TagsRequire.Add(new SpeciesTagRequire { SpeciesId = species.Id, TagId = item });
            }
            foreach (var item in addSpeciesDto.TagsAvoid)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                species.TagsAvoid.Add(new SpeciesTagAvoid { SpeciesId = species.Id, TagId = item });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
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
                                    .Include(s => s.Animals)
                                    .ToListAsync();
            }
            return await _context.Species.ToListAsync();
        }

        public async Task<Species> GetSpecies(int id, bool addTags)
        {
            if (addTags)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return await _context.Species
                                .Where(s => s.Id == id)
                                .Include(s => s.TagsRequire)
                                .Include(s => s.TagsAvoid)
                                .FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
            }
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Species.FirstOrDefaultAsync(s => s.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Species> UpdateSpecies(UpdateSpeciesDto updateSpeciesDto, int id)
        {
            //Species species = await _context.Species.FirstOrDefaultAsync(s => s.Id == id);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Species species = await _context.Species
                                    .Where(s => s.Id == id)
                                    .Include(s => s.TagsRequire)
                                    .Include(s => s.TagsAvoid)
                                    .FirstOrDefaultAsync();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8603 // Possible null reference return.
            if (species == null) { return null; }
#pragma warning restore CS8603 // Possible null reference return.
            species.Name = updateSpeciesDto.Name;
            species.TagsAvoid = new();
            species.TagsRequire.Clear();
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
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Species species = await _context.Species.FirstOrDefaultAsync(s => s.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (species == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            _context.Species.Remove(species);
            await _context.SaveChangesAsync();
            return species;
        }
    }
}
