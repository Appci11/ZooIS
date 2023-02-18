using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooIS.Shared.Models
{
    public class AnimalTagRequire
    {
        //pritdet severity prop??
        //relationship
        public int AnimalId { get; set; }
        public int TagId { get; set; }
        public Animal Animal { get; set; }
        public Tag Tag { get; set; }
    }
}
