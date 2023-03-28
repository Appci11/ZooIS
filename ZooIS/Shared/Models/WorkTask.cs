using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooIS.Shared.Models
{
    //Noretusi "Task" vadint, bet daug kur yra naudojama to paties pavadinimo
    //sistemine klase, tai patogumo delei kuriam WorkTask klase(modeli)
    public class WorkTask
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Reikalinga")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Reikalinga")]
        public string Description { get; set; } = string.Empty;
    }
}
