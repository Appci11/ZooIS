using System.Text.Json.Serialization;

namespace ZooIS.Server.TutorialClasses
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RpgClass { get; set; } = "Knight";

        //for 1 to n relationship with user
        //needed for FK
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        
        //for 1 to 1 relationship with weapon
        public Weapon Weapon{ get; set; }

        //for n to n relationship with skill
        public List<Skill> Skills { get; set; }
    }
}
