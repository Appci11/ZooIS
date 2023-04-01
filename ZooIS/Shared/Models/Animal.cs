﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ZooIS.Shared.Enums;

namespace ZooIS.Shared.Models
{
    public  class Animal
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Reikalinga")]
        public string Name { get; set; } = string.Empty;
        public DateTime? DateAquired { get; set; }
        public DateTime? DateOfDeparture { get; set; }
        public DateTime? DateOfBirth { get; set; } = DateTime.Now;
        public string State { get; set; } = SpeciesState.Healthy.ToString();

        //relationships
        //with habitat
        //[JsonIgnore]  //Sutvarkyt patikrint ir jei EFcore nemess err - istrint
        public Habitat? Habitat { get; set; }

        public int? HabitatId { get; set; }
        //with species
        //[JsonIgnore]  //Sutvarkyt patikrint ir jei EFcore nemess err - istrint
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Species Species { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Required(ErrorMessage = "Reikalinga")]
        [Range(1, int.MaxValue, ErrorMessage = "Nenurodyta rūšis")]

        public int SpeciesId { get; set; } 

    }
}
