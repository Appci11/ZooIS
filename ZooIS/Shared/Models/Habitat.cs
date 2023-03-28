using System.Text.Json.Serialization;

namespace ZooIS.Shared.Models
{
    public class Habitat
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        //relationship
        //with tags
        public List<Tag> Tags { get; set; } = new List<Tag>();
        //with animal
        //[JsonIgnore]
        public List<Animal>? Animals { get; set; } = new List<Animal>();
        //with area
        [JsonIgnore]
        public Area Area { get; set; }
        public int AreaId { get; set; }
    }
}
