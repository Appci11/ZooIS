using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooIS.Shared.Enums;

namespace ZooIS.Shared.Dto
{
    public class AddAnimalDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime? DateAquired { get; set; } = DateTime.MinValue;
        public DateTime? DateOfDeparture { get; set; } = DateTime.MinValue;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string State { get; set; } = SpeciesState.Healthy.ToString();
        public int? HabitatId { get; set; }
        public int SpeciesId { get; set; }
    }
}
