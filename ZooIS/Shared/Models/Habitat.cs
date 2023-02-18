using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZooIS.Shared.Models
{
    public class Habitat
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //relationship
        //with tags
        public List<Tag> Tags { get; set; } = new List<Tag>();
        //with habitat
        public List<Animal>? Animals { get; set; } = new List<Animal>();
        //with area
        [JsonIgnore]
        public Area Area { get; set; }
        public int AreaId { get; set; }

    }
}
