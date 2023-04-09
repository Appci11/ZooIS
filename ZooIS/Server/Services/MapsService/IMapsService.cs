using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.MapsService
{
    public interface IMapsService
    {
        Task<Map> AddMap(Map map);
        Task<Map> GetMap();
    }
}
