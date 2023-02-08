using System.ComponentModel.DataAnnotations;

namespace ZooIS.Shared.Dto
{
    public class UserUpdateInfoVisitorDto
    {
        public required string? Username { get; set; }
        public required string? Email { get; set; }
    }
}
