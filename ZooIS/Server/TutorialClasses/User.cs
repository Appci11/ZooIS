namespace ZooIS.Server.TutorialClasses
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        //for 1 to n relationship with Character
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public List<Character> Characters { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
