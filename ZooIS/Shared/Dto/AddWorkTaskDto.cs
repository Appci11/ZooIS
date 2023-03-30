using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooIS.Shared.Dto
{
    public class AddWorkTaskDto
    {
        [Required(ErrorMessage = "Reikalinga")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Reikalinga")]
        public string Description { get; set; } = string.Empty;
        public int CreatorId { get; set; }  //irgi reikalinga, bet sita, eigoje prides sistema
    }
}
