using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZooIS.Shared.Enums;

namespace ZooIS.Shared.Models
{
    public class Employee : RegisteredUser
    {
        // gali pirkti bilietus kaip ir bet kuris lankytojas
        // totally planned feature
        public DateTime? DateOfEmployment { get; set; }
        public DateTime? DateOfDismissal { get; set; }
        new public string Role { get; set; } = UserRoles.Employee.ToString();
    }
}
