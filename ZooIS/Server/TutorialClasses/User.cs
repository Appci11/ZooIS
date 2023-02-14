namespace ZooIS.Server.TutorialClasses
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        //for 1 to n relationship with Character
        public List<Character> Characters { get; set; }
    }
}
