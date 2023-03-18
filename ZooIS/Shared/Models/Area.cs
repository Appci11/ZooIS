using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZooIS.Shared.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //gal dar koki tipa ar dar ka pridesiu
        //kol kas bus naudojama tik zemelapio sudaryme

        //relationship        
        public List<Habitat>? Habitats { get; set; } = new List<Habitat>();
    }
}
