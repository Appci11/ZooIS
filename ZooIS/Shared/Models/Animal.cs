using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZooIS.Shared.Enums;

namespace ZooIS.Shared.Models
{
    public  class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? DateAquired { get; set; }
        public DateTime? DateOfDeparture { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string State { get; set; } = SpeciesState.Healthy.ToString();

        //relationships
        //with habitat
        [JsonIgnore]
        public Habitat? Habitat { get; set; }
        public int? HabitatId { get; set; }
        //with species
        [JsonIgnore]
        public Species Species { get; set; }
        public int SpeciesId { get; set; }

    }
}
