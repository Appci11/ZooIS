using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZooIS.Shared.Models
{
    /// <summary>
    /// "Tarpine" klase tarp Bundle ir Ticket
    /// </summary>
    public class BundleTicket
    {
        [Required(ErrorMessage = "Reikalinga")]
        public int Quantity { get; set; }

        //relationships
        public int BundleId { get; set; }
        public int TicketId { get; set; }
        [JsonIgnore]
        public Bundle Bundle { get; set; }
        [JsonIgnore]
        public Ticket Ticket { get; set; }
    }
}
