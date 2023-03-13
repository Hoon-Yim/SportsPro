namespace COMP2139_KRN_GENIUS.Models.ViewModels
{
    public class IncidentViewModel
    {
        public Incident Incident { get; set; }

        public List<Customer>? Customers { get; set; }
        public List<Product>? Products { get; set; }
        public List<Technician>? Technicians { get; set; }

        public Customer? Customer { get; set; }
        public Product? Product { get; set; }
        public Technician? Technician { get; set; }

        public string? CustomerName { get; set; }
        public string? ProductName { get; set; }
        public DateTime? DateOpened { get; set; }

        public string? Action { get; set; }
    }
}
