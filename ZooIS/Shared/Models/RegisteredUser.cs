using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using ZooIS.Shared.Enums;

namespace ZooIS.Shared.Models
{
    public class RegisteredUser
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Reikalinga")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Reikalinga")]
        public string Email { get; set; } = string.Empty;
        // using BCrypt.net-Next for PasswordHash, turi hash + salt sudeta i viena
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = UserRoles.Lankytojas.ToString();
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime LastLoginDate { get; set; } = DateTime.Now;
        public DateTime PassChangeTime { get; set; } = DateTime.MinValue;
        public bool RequestPasswordReset { get; set; } = false;
        public bool DeletionRequested { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        //relationships
        //With Bundles
        public List<Bundle> Bundles { get; set; } = new List<Bundle> ();

        public override string ToString()
        {
            return $"Petras";
        }
    }
}