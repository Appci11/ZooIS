using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooIS.Shared
{
    public class RegisteredUser
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        //public byte[]? PasswordHash { get; set; }
        //public byte[]? PasswordSalt { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool isDeleted { get; set; } = false;
        public string Role { get; set; } = "RegisteredUser";    //nepamirst pakeist i enum UserRoles...

    }
}