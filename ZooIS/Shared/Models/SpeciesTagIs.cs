﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZooIS.Shared.Models
{
    public class SpeciesTagIs
    {
        //relationship
        public int SpeciesId { get; set; }
        public int TagId { get; set; }
        [JsonIgnore]
        public Species Species { get; set; }
        [JsonIgnore]
        public Tag Tag { get; set; }
    }
}
