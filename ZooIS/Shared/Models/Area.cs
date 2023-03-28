using System.ComponentModel.DataAnnotations;

namespace ZooIS.Shared.Models
{
    public class Area
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Reikalinga")]
        public string Name { get; set; } = string.Empty;
        //gal dar koki tipa ar dar ka pridesiu
        //kol kas bus naudojama tik zemelapio sudaryme

        //relationship        
        public List<Habitat>? Habitats { get; set; } = new List<Habitat>();
    }
}
