using SQLitePCL;
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
        public async Task<SpeciesService> AddSpecies(AddSpeciesDto addSpeciesDto)
        {
            Species species = new Species();

            species.Name = addSpeciesDto.Name;
            List<Tag> dbTags = await _context.Tags.ToListAsync();
            //Adding required tags
            if(addSpeciesDto.TagsRequire != null && addSpeciesDto.TagsRequire.Count> 0)
            {
                foreach(var item in addSpeciesDto.TagsRequire)
                {

                }
            }
        }

        public Task<SpeciesService> DeleteSpecies(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SpeciesService>> GetAllSpecies(bool addTags)
        {
            throw new NotImplementedException();
        }

        public Task<SpeciesService> GetSpecies(int id, bool addTags)
        {
            throw new NotImplementedException();
        }

        public Task<SpeciesService> UpdateSpecies(UpdateSpeciesDto updateSpeciesDto)
        {
            throw new NotImplementedException();
        }
    }
}
