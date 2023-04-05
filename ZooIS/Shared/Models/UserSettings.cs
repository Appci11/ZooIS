using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZooIS.Shared.Models
{
    public class UserSettings
    {
        [ForeignKey("RegisteredUser")]
        public int Id { get; set; }
        public string Language { get; set; } = "en";
        public bool DarkMode { get; set; } = false;

        //relationships
        [JsonIgnore]
        public RegisteredUser RegisteredUser { get; set; }
    }
}
