using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.HabitatsService
{
    public interface IHabitatsService
    {
        Task<Habitat> AddHabitat(AddHabitatDto addHabitatDto);
        Task<List<Habitat>> GetAllHabitats(bool tags);
        Task<Habitat> GetHabitat(int id, bool addTags);
        Task<Habitat> UpdateHabitat(UpdateHabitatDto updateHabitatDto, int id);
        Task<Habitat> DeleteHabitat(int id);
    }
}
