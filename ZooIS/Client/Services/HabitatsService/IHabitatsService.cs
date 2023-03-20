using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.HabitatsService
{
    public interface IHabitatsService
    {
        List<Habitat> Habitats { get; set; }

        public Task GetHabitats();
        public Task<Habitat> GetHabitat(int id);
        public Task<bool> CreateHabitat(Habitat habitat);
        public Task<bool> UpdataHabitat(Habitat habitat);
        public Task<bool> DeleteHabitat(int id);
    }
}
