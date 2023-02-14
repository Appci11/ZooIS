using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooIS.Shared.Models;

namespace ZooIS.Shared.Dto
{
    public class AddTBundleDto
    {
        public List<AddTBundleTicketDto> TBundleTickets { get; set; } = new List<AddTBundleTicketDto> { new AddTBundleTicketDto() };
    }
}
