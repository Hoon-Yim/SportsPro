using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2139_KRN_GENIUS.Models
{
    public class Registration
    {
        [Key, Column(Order = 1)]
        public int CustomerId { get; set; }
        [Key, Column(Order = 2)]
        public int ProductId { get; set; }

        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
