using System.ComponentModel.DataAnnotations;

namespace ZooIS.Shared.Dto
{
    public class UserUpdateInfoDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
