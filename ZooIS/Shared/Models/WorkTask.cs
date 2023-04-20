using System.ComponentModel.DataAnnotations;

namespace ZooIS.Shared.Models
{
    //Noretusi "Task" vadint, bet daug kur yra naudojama to paties pavadinimo
    //sistemine klase, tai patogumo delei kuriam WorkTask klase(modeli)
    public class WorkTask : IComparable<WorkTask>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Reikalinga")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Reikalinga")]
        public string Description { get; set; } = string.Empty;
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public int CreatorId { get; set; }
        public bool IsCompleted { get; set; }
        public int Severity { get; set; }
        public int Subject { get; set; }
        public int AreaId { get; set; }

        public int CompareTo(WorkTask? other)
        {
            if(other == null) return 1;
            if(Severity > other.Severity) return 1;
            if (Severity == other.Severity) return 0;
            return -1;
        }
    }
}
