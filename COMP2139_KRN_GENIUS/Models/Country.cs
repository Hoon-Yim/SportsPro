using System.ComponentModel.DataAnnotations;

namespace COMP2139_KRN_GENIUS.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
