using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZooIS.Shared.Models
{
    /// <summary>
    /// "Tarpine" klase tarp TBundle ir Ticket
    /// </summary>
    public class TBundleTicket
    {
        public int Quantity { get; set; }

        public int TBundleId { get; set; }
        public int TicketId { get; set; }
        [JsonIgnore]
        public TBundle TBundle { get; set; }
        [JsonIgnore]
        public Ticket Ticket { get; set; }
    }
}
