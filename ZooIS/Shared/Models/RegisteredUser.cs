﻿using System.ComponentModel.DataAnnotations;
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
        public string Role { get; set; } = UserRoles.Visitor.ToString();
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime LastLoginDate { get; set; } = DateTime.Now;
        public DateTime PassChangeTime { get; set; } = DateTime.MinValue;
        public bool RequestPasswordReset { get; set; } = false;
        public bool DeletionRequested { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        //relationships
        //With Settings
        [JsonIgnore]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public UserSettings UserSettings { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        //With Bundles
        public Bundle? Bundle { get; set; }

        public override string ToString()
        {
            return $"Petras";
        }
    }
}