using System.Text.Json.Serialization;

namespace ZooIS.Shared.Models
{
    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //relationships
        //with Tag
        public List<SpeciesTagRequire> TagsRequire { get; set; } = new List<SpeciesTagRequire>();

        public List<SpeciesTagAvoid>? TagsAvoid { get; set; } = new List<SpeciesTagAvoid>();
        //with animal
        [JsonIgnore]
        public List<Animal>? Animals { get; set; } = new List<Animal>();
    }
}
