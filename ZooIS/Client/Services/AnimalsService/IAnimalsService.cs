using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.AnimalsService
{
    public interface IAnimalsService
    {
        List<Animal> Animals { get; set; }

        public Task GetAnimals();
        public Task<Animal> GetAnimal(int id);
        public Task<bool> CreateAnimal(Animal animal);
        public Task<bool> UpdateAnimal(Animal animal);
        public Task<bool> DeleteAnimal(int id);
    }
}
