using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.AreasService
{
    public interface IAreasService
    {
        Task<Area> AddArea(AddAreaDto areaDto);
        Task<List<Area>> GetAllAreas();
        Task<Area> GetArea(int id);
        Task<Area> UpdateArea(UpdateAreaDto updateAreaDto, int id);
        Task<Area> DeleteArea(int id);
    }
}
