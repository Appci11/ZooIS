namespace ZooIS.Client.Models
{
    public class Polygon
    {
        public int Nr { get; set; }
        public List<Coordinates> Coordinates { get; set; } = new List<Coordinates>();
    }
}
