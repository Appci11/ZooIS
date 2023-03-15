using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooIS.Shared.Enums;

namespace ZooIS.Shared.Dto
{
    public class UpdateUserInfoAdminDto
    {
        public required string? Username { get; set; }
        public required string? Email { get; set; }
        public required bool RequestPasswordReset { get; set; }
        public required bool DeletionRequested { get; set; }
        public required bool IsDeleted { get; set; }
        public required string Role { get; set; }
    }
}
