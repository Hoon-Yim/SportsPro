using System.ComponentModel.DataAnnotations;

namespace COMP2139_KRN_GENIUS.Models
{
    public class Technician
    {
        [Key]
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Please enter the name of the technician")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Please enter alphabets only for the name of the technician")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter the email")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Invalid email address format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter the phone number")]
        [RegularExpression(@"^([\(]{1}[0-9]{3}[\)]{1}[ ]{1}[0-9]{3}[\-]{1}[0-9]{4})$", ErrorMessage = "Invalid phone number format")]
        public string? Phone { get; set; }
    }
}
