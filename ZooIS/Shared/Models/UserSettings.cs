using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooIS.Shared.Models
{
    public class UserSettings
    {
        public required int Id { get; set; }
        public string Language { get; set; } = "en";
        public bool DarkMode { get; set; } = false;
    }
}
