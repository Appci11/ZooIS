using System.Text.Json.Serialization;

namespace ZooIS.Shared.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        //relationships
        //[JsonIgnore]
        public List<SpeciesTagRequire>? SpeciesRequire { get; set; }

        //[JsonIgnore]
        public List<SpeciesTagAvoid>? SpeciesAvoid { get; set; }
        //[JsonIgnore]
        public List<Habitat>? Habitats { get; set; } = new List<Habitat>();
    }
}
