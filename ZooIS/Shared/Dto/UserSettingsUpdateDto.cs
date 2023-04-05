using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooIS.Shared.Dto
{
    public class UserSettingsUpdateDto
    {
        [Required]
        public string Language { get; set; }
        [Required]
        public bool DarkMode { get; set; }
    }
}
