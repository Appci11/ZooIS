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
        public Character Character { get; set; }
        public int CharacterId { get; set; }
    }
}
