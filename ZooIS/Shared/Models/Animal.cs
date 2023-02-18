using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZooIS.Shared.Enums;

namespace ZooIS.Shared.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //insert current state here
        public DateTime? DateAquired { get; set; }
        public DateTime? DateOfDeparture { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string State { get; set; } = AnimalState.Healthy.ToString();

        //relationships
        //with Tag
        public List<AnimalTagRequire> TagsRequire { get; set; } = new List<AnimalTagRequire>();
        public List<AnimalTagAvoid> TagsAvoid { get; set; } = new List<AnimalTagAvoid>();
        //with habitat
        [JsonIgnore]
        public Habitat? Habitat { get; set; }
        public int HabitatId { get; set; }
    }
}
