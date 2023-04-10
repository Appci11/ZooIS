using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.AreasService
{
    public interface IAreasService
    {
        List<Area> Areas { get; set; }

        Task GetAreas();
        Task<Area> GetArea(int id);
        Task<bool> CreateArea(Area area);
        Task<bool> UpdateArea(Area area);
        Task<bool> DeleteArea(int id);
        Task<bool> DeleteAreaByNr(int nr);
        Task<List<int>> GetExistingTagIds(int id);
        Task<List<int>> GetToAvoidTagIds(int id);

        Task<Dictionary<int, string>> GetAreaNames();
    }
}
