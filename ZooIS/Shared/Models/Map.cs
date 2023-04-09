using System.Reflection.Metadata;
using ZooIS.Shared.Models.MapAreaModels;

namespace ZooIS.Shared.Models
{
    public class Map
    {
        public int Id { get; set; }
        public int PictureId { get; set; }
        public List<AreaDrawData> AreasData { get; set; } = new List<AreaDrawData>();
    }
}
