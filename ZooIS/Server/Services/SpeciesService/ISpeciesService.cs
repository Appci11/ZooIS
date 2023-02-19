using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.SpeciesService
{
    public interface ISpeciesService
    {
        Task<Species> AddSpecies(AddSpeciesDto addSpeciesDto);
        Task<List<Species>> GetAllSpecies(bool addTags);
        Task<Species> GetSpecies(int id, bool addTags);
        Task<Species> UpdateSpecies(UpdateSpeciesDto updateSpeciesDto, int id);
        Task<Species> DeleteSpecies(int id);
    }
}
