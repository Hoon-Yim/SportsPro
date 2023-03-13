namespace COMP2139_KRN_GENIUS.Models.ViewModels
{
    public class RegistrationViewModel
    {
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }

        public string? CustomerName { get; set; }
        public string? ProductName { get; set; }

        public Registration? Registration { get; set; }

        public List<Customer>? Customers { get; set; }
        public List<Product>? Products { get; set; }
        public List<Registration>? Registrations { get; set; }
    }
}
