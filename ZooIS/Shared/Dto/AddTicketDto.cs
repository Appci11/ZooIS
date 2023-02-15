using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooIS.Shared.Dto
{
    public class AddTicketDto
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; } = 0.00;
    }
}
