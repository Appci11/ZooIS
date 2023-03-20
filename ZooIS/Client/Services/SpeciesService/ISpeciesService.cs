using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.SpeciesService
{
    public interface ISpeciesService
    {
        List<Species> AllSpecies { get; set; }

        public Task GetAllSpecies();
        public Task<Species> GetSingleSpecies(int id);
        public Task<bool> CreateSingleSpecies(Species species);
        public Task<bool> UpdateSingleSpecies(Species species);
        public Task<bool> DeleteSingleSpecies(int id);
    }
}
