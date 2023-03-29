using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZooIS.Shared.Models
{
    public class Habitat
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Reikalinga")]
        public string Name { get; set; } = string.Empty;
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
        [Required(ErrorMessage = "Reikalinga")]
        [Range(1, int.MaxValue, ErrorMessage = "Nenurodyta zona")]
        public int AreaId { get; set; }
    }
}
