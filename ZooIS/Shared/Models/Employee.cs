using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooIS.Shared.Models
{
    public class Employee : RegisteredUser
    {
        public DateTime? EmploymentDate { get; set; }
    }
}
