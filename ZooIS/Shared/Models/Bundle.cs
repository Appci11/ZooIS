using System.Text.Json.Serialization;

namespace ZooIS.Shared.Models
{
    public class Bundle
    {
        public int Id { get; set; }
        public double Price { get; set; } = 0.00;
        public bool PurchaseFinalized { get; set; } = false;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime DateOfUse { get; set; } = DateTime.Now;

        //relationships
        public List<BundleTicket> BundleTickets { get; set; } = new List<BundleTicket>();
        //with RegisteredUsers
        [JsonIgnore]
        public RegisteredUser RegisteredUser { get; set; }
        public int RegisteredUserId { get; set; }
    }
}
