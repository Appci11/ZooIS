using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.SpeciesService
{
    public interface ISpeciesService
    {
        Task<SpeciesService> AddSpecies(AddSpeciesDto addSpeciesDto);
        Task<List<SpeciesService>> GetAllSpecies(bool addTags);
        Task<SpeciesService> GetSpecies(int id, bool addTags);
        Task<SpeciesService> UpdateSpecies(UpdateSpeciesDto updateSpeciesDto);
        Task<SpeciesService> DeleteSpecies(int id);
    }
}
