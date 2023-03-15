using System.ComponentModel.DataAnnotations;

namespace ZooIS.Shared.Dto
{
    public class UpdateUserInfoVisitorDto
    {
        public required string? Username { get; set; }
        public required string? Email { get; set; }
    }
}
