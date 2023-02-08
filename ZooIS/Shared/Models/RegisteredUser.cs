using System.ComponentModel.DataAnnotations;
using ZooIS.Shared.Enums;

namespace ZooIS.Shared.Models
{
    public class RegisteredUser
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        // using BCrypt.net-Next for PasswordHash, turi hash + salt sudeta i viena
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime LastLoginDate { get; set; } = DateTime.Now;
        public bool RequestPasswordReset { get; set; } = false;
        public bool DeletionRequested { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public string Role { get; set; } = UserRoles.Visitor.ToString();
    }
}