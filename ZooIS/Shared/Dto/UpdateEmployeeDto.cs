using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooIS.Shared.Dto
{
    public class UpdateEmployeeDto
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required bool RequestPasswordReset { get; set; }
        public required bool DeletionRequested { get; set; }
        public required bool IsDeleted { get; set; }
        public required string Role { get; set; }
        // Potencialus Ooooooops.... Sutvarkyt kai UI client'e bus.
        public DateTime DateOfEmployment { get; set; } = DateTime.Now;
        public DateTime? DateOfDismissal { get; set; }
    }
}
