using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZooIS.Shared.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Reikalinga")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0.00, double.MaxValue, ErrorMessage = "Kaina negali būti neigiama")]
        public double Price { get; set; }

        //relationships
        [JsonIgnore]
        public ICollection<BundleTicket>? BundleTickets { get; set; }
    }
}
