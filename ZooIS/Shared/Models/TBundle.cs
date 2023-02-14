using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooIS.Shared.Models
{
    public class TBundle
    {
        public int Id { get; set; }
        public double Price { get; set; } = 0.00;
        public bool PurchaseFinalized { get; set; } = false;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime DateOfUse { get; set; } = DateTime.Now;  //PAKEIST

        //relationships
        public List<TBundleTicket> TBundleTickets { get; set; } = new List<TBundleTicket>();
    }
}
