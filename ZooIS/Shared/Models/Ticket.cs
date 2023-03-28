using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZooIS.Shared.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Reikalinga")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Reikalinga")]
        public double Price { get; set; }

        //relationships
        [JsonIgnore]
        public ICollection<BundleTicket>? BundleTickets { get; set; }
    }
}
