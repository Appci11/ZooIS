using System;
using System.Collections.Generic;
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
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
