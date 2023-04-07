namespace ZooIS.Client.Models
{
    public class AreaDrawData
    {
        public int Nr { get; set; }
        public List<Coordinates> PolyCoordinates { get; set; } = new List<Coordinates>();
        public Coordinates TextCoordinates { get; set; }
    }
}
