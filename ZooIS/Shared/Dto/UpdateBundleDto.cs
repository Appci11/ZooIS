using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooIS.Shared.Dto
{
    public class UpdateBundleDto
    {
        public int RegisteredUserId { get; set; }
        public List<AddBundleTicketDto> BundleTickets { get; set; } = new List<AddBundleTicketDto>();
        public bool PurchaseFinalized { get; set; }
    }
}
