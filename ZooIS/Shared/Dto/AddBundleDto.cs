using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooIS.Shared.Models;

namespace ZooIS.Shared.Dto
{
    public class AddBundleDto
    {
        public int UserId { get; set; }
        public List<AddBundleTicketDto> BundleTickets { get; set; } = new List<AddBundleTicketDto> { new AddBundleTicketDto() };
    }
}
