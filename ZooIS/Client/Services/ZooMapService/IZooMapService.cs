using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.ZooMapService
{
    public interface IZooMapService
    {
        public Map Map { get; set; }

        public Task<bool> AddMap(Map map);
        public Task<bool> GetMap();






        public string[] ZooMapFillColors { get; set; }
        public string[] ZooMapStrokeColors { get; set; }
        
    }
}
