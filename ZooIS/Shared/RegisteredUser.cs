using System.ComponentModel.DataAnnotations;

namespace ZooIS.Shared
{
    public class RegisteredUser
    {
        public int Id { get; set; }
        [Required]
        public string? Username { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; } = null;
        public byte[]? PasswordSalt { get; set; } = null;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool RequestPasswordReset { get; set; } = false;
        public bool DeletionRequested { get; set; } = false;
        public bool isDeleted { get; set; } = false;
        public string Role { get; set; } = "RegisteredUser";    //nepamirst pakeist i enum UserRoles...
    }
}