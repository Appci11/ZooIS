using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooIS.Shared.Dto
{
    public class UserAddDto
    {
        [Required]
        public string? Username { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "RegisteredUser";  // susitvarkyt su enum
    }
}
