using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooIS.Shared.Models.MapAreaModels
{
    public class AreaDrawData
    {
        public int Id { get; set; }
        public int Nr { get; set; }
        public List<Coordinates> PolyCoordinates { get; set; } = new List<Coordinates>();
        public Coordinates TextCoordinates { get; set; }
        public string FillColor { get; set; } = "ffffff";
        public string StrokeColor { get; set; } = "000000";
    }
}
