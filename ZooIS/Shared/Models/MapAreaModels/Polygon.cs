using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooIS.Shared.Models.MapAreaModels
{
    public class Polygon
    {
        public int Nr { get; set; }
        public List<Coordinates> Coordinates { get; set; } = new List<Coordinates>();
    }
}
