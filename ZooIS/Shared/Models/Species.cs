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
    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //relationships
        //with Tag
        public List<SpeciesTagRequire> TagsRequire { get; set; } = new List<SpeciesTagRequire>();
        public List<SpeciesTagAvoid>? TagsAvoid { get; set; } = new List<SpeciesTagAvoid>();
        //with animal
        public List<Animal>? Animals { get; set; } = new List<Animal>();
    }
}
