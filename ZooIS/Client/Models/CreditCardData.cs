using System.ComponentModel.DataAnnotations;

namespace ZooIS.Client.Models
{
    public class CreditCardData
    {
        public int CardType { get; set; }
        [Required(ErrorMessage = "Reikalinga")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Reikalinga")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Reikalinga")]
        public string CardNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Reikalinga")]
        public string MonthYear { get; set; } = string.Empty;
        [Required(ErrorMessage = "Reikalinga")]
        public string CvcNumber { get; set; } = string.Empty;
    }
}
