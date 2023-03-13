using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2139_KRN_GENIUS.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter customer's first name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please enter alphabets only for the first name")]
        [StringLength(51, ErrorMessage = "You need minimum of 1 character to maximum of 51 characters for first name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter customer's last name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please enter alphabets only for the last name")]
        [StringLength(51, ErrorMessage = "You need minimum of 1 character to maximum of 51 characters for last name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter customer's address")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Only numbers and letters. No special characters for address")]
        [StringLength(51, ErrorMessage = "You need minimum of 1 character to maximum of 51 characters for the address")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Please enter the city")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only letters for city")]
        [StringLength(51, ErrorMessage = "You need minimum of 1 character to maximum of 51 characters for the city")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Please enter the province")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only letters for province")]
        [StringLength(51, ErrorMessage = "You need minimum of 1 character to maximum of 51 characters for the province")]
        public string? Province { get; set; }

        [Required(ErrorMessage = "Please enter the postal code")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Only numbers and letters. No special characters for postal code")]
        [StringLength(21, ErrorMessage = "You need minimum of 1 character to maximum of 51 characters for postal code")]
        public string? PostalCode { get; set; }

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Invalid email address format")]
        public string? Email { get; set; }

        [RegularExpression(@"^([\(]{1}[0-9]{3}[\)]{1}[ ]{1}[0-9]{3}[\-]{1}[0-9]{4})$", ErrorMessage = "Invalid phone number format")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Please select a country")]
        [ForeignKey("CountryId")]
        public int? CountryId { get; set; }
        public virtual Country? Country { get; set; }

    }
}
