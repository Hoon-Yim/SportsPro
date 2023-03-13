using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2139_KRN_GENIUS.Models
{
    public class Incident
    {
        [Key]
        public int IncidentId { get; set; }

        [Required(ErrorMessage = "Please select a customer")]
        [ForeignKey("CustomerId")]
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        [Required(ErrorMessage = "Please select a product")]
        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }

        [ForeignKey("TechnicianId")]
        public int? TechnicianId { get; set; }
        public virtual Technician? Technician { get; set; }

        [Required(ErrorMessage = "Please enter the title")]
        public string? Title { get; set; }
        
        [Required(ErrorMessage = "Please enter the description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Please select the date opened")]
        public DateTime? DateOpened { get; set; }

        public DateTime? DateClosed { get; set; }
    }
}
