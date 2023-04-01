using System.Text.Json.Serialization;

namespace ZooIS.Server.TutorialClasses
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; } = 10;

        //for 1 to 1 relationship with weapon
        //needed for FK
        [JsonIgnore]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Character Character { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public int CharacterId { get; set; }
    }
}
