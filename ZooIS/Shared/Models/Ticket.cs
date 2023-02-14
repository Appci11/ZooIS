using System.Text.Json.Serialization;

namespace ZooIS.Shared.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }

        //relationships
        [JsonIgnore]
        public ICollection<TBundleTicket>? TBundleTickets { get; set; }
    }
}
