using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZooIS.Shared.Models
{
    /// <summary>
    /// "Tarpine" klase tarp Bundle ir Ticket
    /// </summary>
    public class BundleTicket
    {
        public int Quantity { get; set; }

        
        public int BundleId { get; set; }
        public int TicketId { get; set; }
        [JsonIgnore]
        public Bundle Bundle { get; set; }
        
        public Ticket Ticket { get; set; }
    }
}
