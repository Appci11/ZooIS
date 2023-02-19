using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooIS.Shared.Models;

namespace ZooIS.Shared.Dto
{
    public class UpdateSpeciesDto
    {
        public string Name { get; set; } = string.Empty;
        public List<Tag> TagsRequire { get; set; }
        public List<Tag> TagsAvoid { get; set; }
    }
}
