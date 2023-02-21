using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.AnimalsService
{
    public interface IAnimalsService
    {
        Task<Animal> AddAnimal(AddAnimalDto addAnimalDto);
        Task<List<Animal>> GetAllAnimals();
        Task<Animal> GetAnimal(int id);
        Task<Animal> UdateAnimal(UpdateAnimalDto updateAnimalDto, int id);
        Task<Animal> UdateAnimalState(UpdateAnimalStateDto updateAnimalStateDto, int id);
        Task<Animal> DeleteAnimal(int id);
    }
}
