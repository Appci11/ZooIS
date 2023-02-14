namespace ZooIS.Server.TutorialClasses
{
    public class Au
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AuMeu> AuMeus { get; set; }

    }
}
