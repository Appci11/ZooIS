using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooIS.Shared.Enums;

namespace ZooIS.Shared.Dto
{
    public class UserAddDto
    {
        public required string? Username { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = UserRoles.Visitor.ToString();
    }
}
