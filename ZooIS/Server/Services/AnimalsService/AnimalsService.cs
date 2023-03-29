using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.AnimalsService
{
    public class AnimalsService : IAnimalsService
    {
        private readonly DataContext _context;

        public AnimalsService(DataContext context)
        {
            _context = context;
        }
        public async Task<Animal> AddAnimal(AddAnimalDto addAnimalDto)
        {
            Animal animal = new Animal();

            animal.Name= addAnimalDto.Name;
            animal.DateAquired = addAnimalDto.DateAquired;
            animal.DateOfDeparture = addAnimalDto.DateOfDeparture;
            animal.DateOfBirth= addAnimalDto.DateOfBirth;
            animal.State= addAnimalDto.State;
            animal.HabitatId = addAnimalDto.HabitatId;
            animal.SpeciesId = addAnimalDto.SpeciesId;

            _context.Add(animal);
            await _context.SaveChangesAsync();

            return animal;
        }

        public async Task<Animal> DeleteAnimal(int id)
        {
            Animal animal = await _context.Animals.FirstOrDefaultAsync(x => x.Id == id);
            if(animal == null)
            {
                return null;
            }
            _context.Remove(animal);
            await _context.SaveChangesAsync();
            return animal;
        }

        public async Task<List<Animal>> GetAllAnimals(bool includeRelated)
        {
            if(includeRelated)
                return await _context.Animals
                .Include(a => a.Species)
                .Include(a => a.Habitat)
                .ToListAsync();
            return await _context.Animals.ToListAsync();
        }

        public async Task<Animal> GetAnimal(int id)
        {
            return await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Animal> UdateAnimal(UpdateAnimalDto updateAnimalDto, int id)
        {
            Animal animal = _context.Animals.FirstOrDefault(a => a.Id == id);
            if(animal == null)
            {
                return null;
            }
            animal.Name = updateAnimalDto.Name;
            animal.DateAquired = updateAnimalDto.DateAquired;
            animal.DateOfDeparture = updateAnimalDto.DateOfDeparture;
            animal.DateOfBirth = updateAnimalDto.DateOfBirth;
            animal.State = updateAnimalDto.State;
            animal.HabitatId = updateAnimalDto.HabitatId;
            animal.SpeciesId = updateAnimalDto.SpeciesId;

            await _context.SaveChangesAsync();

            return animal;
        }

        public async Task<Animal> UdateAnimalState(UpdateAnimalStateDto updateAnimalStateDto, int id)
        {
            Animal animal = _context.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return null;
            }
            animal.State = updateAnimalStateDto.State;

            await _context.SaveChangesAsync();

            return animal;
        }
    }
}
