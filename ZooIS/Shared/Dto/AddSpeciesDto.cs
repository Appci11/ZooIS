using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooIS.Shared.Models;

namespace ZooIS.Shared.Dto
{
    public class AddSpeciesDto
    {
        public string Name { get; set; } = string.Empty;
        public List<SpeciesTagRequire> TagsRequire { get; set; }
        public List<SpeciesTagAvoid> TagsAvoid { get; set; }
    }
}
