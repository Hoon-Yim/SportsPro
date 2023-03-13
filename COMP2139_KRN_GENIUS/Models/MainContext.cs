using Microsoft.EntityFrameworkCore;

namespace COMP2139_KRN_GENIUS.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData
            (
                new Product { ProductId = 1, Name = "Tournament Master 1.0", Code = "TRNY10", YearlyPrice = 4.99, Date = new DateTime(2020, 3, 1, 8, 23, 00) },
                new Product { ProductId = 2, Name = "League Scheduler 1.0", Code = "LEAG10", YearlyPrice = 4.99, Date = new DateTime(2020, 7, 26, 15, 28, 00) },
                new Product { ProductId = 3, Name = "League Scheduler Deluxe 1.0", Code = "LEAGD10", YearlyPrice = 6.99, Date = new DateTime(2020, 8, 3, 12, 30, 00) },
                new Product { ProductId = 4, Name = "Draft Manager 1.0", Code = "DRAFT10", YearlyPrice = 4.99, Date = new DateTime(2020, 8, 15, 9, 15, 00) },
                new Product { ProductId = 5, Name = "Team Manager 1.0", Code = "TEAM10", YearlyPrice = 4.99, Date = new DateTime(2020, 9, 3, 11, 42, 00) },
                new Product { ProductId = 6, Name = "Tournament Manager 2.0", Code = "TRNY20", YearlyPrice = 7.99, Date = new DateTime(2020, 10, 30, 9, 43, 00) },
                new Product { ProductId = 7, Name = "Draft Manager 2.0", Code = "DRAFT20", YearlyPrice = 5.99, Date = new DateTime(2020, 11, 5, 14, 3, 00) },
                new Product { ProductId = 8, Name = "League Scheduler Deluxe 2.0", Code = "LEAGD20", YearlyPrice = 5.99, Date = new DateTime(2020, 11, 10, 9, 35, 00) },
                new Product { ProductId = 9, Name = "Draft Manager 3.0", Code = "DRAFT30", YearlyPrice = 5.99, Date = new DateTime(2020, 11, 20, 16, 49, 00) },
                new Product { ProductId = 10, Name = "Team Manager 2.0", Code = "TEAM20", YearlyPrice = 6.99, Date = new DateTime(2020, 12, 15, 17, 42, 00) }
            );
            
            modelBuilder.Entity<Technician>().HasData
            (
                new Technician { TechnicianId = 1, Name = "Seunghun Yim", Email = "yimsh4507@gmail.com", Phone = "(647) 551-3087" },
                new Technician { TechnicianId = 2, Name = "Yoonhee Kim", Email = "aayuooh233@gmail.com", Phone = "(647) 551-1233" },
                new Technician { TechnicianId = 3, Name = "JooYoung Song", Email = "jysong304@gmail.com", Phone = "(432) 132-1404" },
                new Technician { TechnicianId = 4, Name = "Anthony Edward Stark", Email = "tony99@gmail.com", Phone = "(232) 932-3921" },
                new Technician { TechnicianId = 5, Name = "Natasha Romanoff", Email = "russia23@gmail.com", Phone = "(432) 132-1404" },
                new Technician { TechnicianId = 6, Name = "Clint Barton", Email = "hawki99@gmail.com", Phone = "(432) 882-0231" },
                new Technician { TechnicianId = 7, Name = "James Rhodes", Email = "warmachine34@gmail.com", Phone = "(842) 949-0100" }
            );
            
            modelBuilder.Entity<Country>().HasData
            (
                new Country { CountryId = 1, Name = "South Korea" },
                new Country { CountryId = 2, Name = "North Korea" },
                new Country { CountryId = 3, Name = "United States" },
                new Country { CountryId = 4, Name = "Canada" },
                new Country { CountryId = 5, Name = "England" },
                new Country { CountryId = 6, Name = "Russia" },
                new Country { CountryId = 7, Name = "Japan" },
                new Country { CountryId = 8, Name = "France" },
                new Country { CountryId = 9, Name = "Italy" },
                new Country { CountryId = 10, Name = "China" },
                new Country { CountryId = 11, Name = "Ukraine" },
                new Country { CountryId = 12, Name = "Australia" },
                new Country { CountryId = 13, Name = "Argentina" },
                new Country { CountryId = 14, Name = "Vietnam" },
                new Country { CountryId = 15, Name = "Thailand" },
                new Country { CountryId = 16, Name = "Brazil" },
                new Country { CountryId = 17, Name = "Syria" },
                new Country { CountryId = 18, Name = "Nepal" },
                new Country { CountryId = 19, Name = "Mexico" },
                new Country { CountryId = 20, Name = "Malaysia" }
            );

            modelBuilder.Entity<Customer>().HasData
            (
                new Customer { CustomerId = 1, FirstName = "Steve", LastName = "Rogers", Address = "13 Asrahi ave", City = "Vaughan", PostalCode = "K2E 4B3", Province = "Ontario", Email = "evans34@gmail.com", Phone = "(415) 222-9723", CountryId = 3 },
                new Customer { CustomerId = 2, FirstName = "Bucky", LastName = "Barnes", Address = "99 Glass st", City = "Toronto", PostalCode = "M6M 4B5", Province = "Ontario", Email = "metalarm@gmail.com", Phone = "(423) 523-1233", CountryId = 1 },
                new Customer { CustomerId = 3, FirstName = "Wanda", LastName = "Maximoff", Address = "14 Maximum ct", City = "Richmond", PostalCode = "M3M 1B1", Province = "Ontario", Email = "vision34@gmail.com", Phone = "(953) 992-3111", CountryId = 4 },
                new Customer { CustomerId = 4, FirstName = "Sam", LastName = "Wilson", Address = "53 Vern st", City = "Toronto", PostalCode = "V34 4K6", Province = "Ontario", Email = "metalarm@gmail.com", Phone = "(423) 523-1233", CountryId = 6 },
                new Customer { CustomerId = 5, FirstName = "Stan", LastName = "Lee", Address = "3 Marvel ct", City = "Toronto", PostalCode = "VE3 M5A", Province = "Ontario", Email = "mfather01@gmail.com", Phone = "(932) 032-9234", CountryId = 3 },
                new Customer { CustomerId = 6, FirstName = "Bruce", LastName = "Banner", Address = "19 Green ave", City = "Toronto", PostalCode = "S0M A2S", Province = "Ontario", Email = "hulk19000@gmail.com", Phone = "(752) 922-1211", CountryId = 16 },
                new Customer { CustomerId = 7, FirstName = "Carol", LastName = "Danvers", Address = "277 Kree dong", City = "Toronto", PostalCode = "K1R FU4", Province = "Ontario", Email = "furylover99@gmail.com", Phone = "(989) 231-2133", CountryId = 20 },
                new Customer { CustomerId = 8, FirstName = "Peter", LastName = "Parker", Address = "6 Web ct", City = "Quenes", PostalCode = "M62 K43", Province = "Ontario", Email = "spidey@gmail.com", Phone = "(112) 911-9824", CountryId = 9 },
                new Customer { CustomerId = 9, FirstName = "Nick", LastName = "Fury", Address = "199 Shield ave", City = "Toronto", PostalCode = "A23 F25", Province = "Ontario", Email = "carollover@gmail.com", Phone = "(538) 423-8421", CountryId = 14 },
                new Customer { CustomerId = 10, FirstName = "Peter", LastName = "Quill", Address = "1012 Celest st", City = "Toronto", PostalCode = "A23 F25", Province = "Ontario", Email = "starlord23@gmail.com", Phone = "(932) 244-4423", CountryId = 15 }
            );

            modelBuilder.Entity<Incident>().HasData
            (
                new Incident { IncidentId = 1, CustomerId = 8, ProductId = 10, TechnicianId = 3, Title = "Could not install", Description = "Install fails with error code 410", DateOpened = DateTime.Now },
                new Incident { IncidentId = 2, CustomerId = 2, ProductId = 3, Title = "Error launching program", Description = "Program fails with error code 510, unable to open database", DateOpened = DateTime.Now },
                new Incident { IncidentId = 3, CustomerId = 3, ProductId = 4, Title = "Could not install", Description = "Install fails with error code 410", DateOpened = DateTime.Now, DateClosed = DateTime.Now.AddMonths(20).AddHours(24).AddMinutes(12) },
                new Incident { IncidentId = 4, CustomerId = 1, ProductId = 9, Title = "Could not load data", Description = "Reading data from DB fails with error code 120", DateOpened = DateTime.Now },
                new Incident { IncidentId = 5, CustomerId = 5, ProductId = 5, TechnicianId = 6, Title = "Could not open the DB", Description = "Opening the DB fails with error code 300", DateOpened = DateTime.Now, DateClosed = DateTime.Now.AddMonths(13).AddHours(16).AddMinutes(23) },
                new Incident { IncidentId = 6, CustomerId = 10, ProductId = 1, TechnicianId = 7, Title = "Fail to upgrade", Description = "Upgrading fails with error code 230", DateOpened = DateTime.Now }
            );

            modelBuilder.Entity<Registration>().HasKey(e => new { e.CustomerId, e.ProductId });
            modelBuilder.Entity<Registration>().HasData
            (
                new Registration { CustomerId = 1, ProductId = 4 },
                new Registration { CustomerId = 1, ProductId = 3 },
                new Registration { CustomerId = 1, ProductId = 7 },

                new Registration { CustomerId = 2, ProductId = 2 },
                new Registration { CustomerId = 2, ProductId = 4 },
                new Registration { CustomerId = 2, ProductId = 9 },

                new Registration { CustomerId = 3, ProductId = 10 },
                new Registration { CustomerId = 3, ProductId = 2 },
                new Registration { CustomerId = 3, ProductId = 1 },

                new Registration { CustomerId = 4, ProductId = 4 },
                new Registration { CustomerId = 4, ProductId = 6 },
                new Registration { CustomerId = 4, ProductId = 2 },

                new Registration { CustomerId = 5, ProductId = 1 },
                new Registration { CustomerId = 5, ProductId = 2 },
                new Registration { CustomerId = 5, ProductId = 3 },

                new Registration { CustomerId = 5, ProductId = 10 },
                new Registration { CustomerId = 5, ProductId = 5 },
                new Registration { CustomerId = 5, ProductId = 6 },

                new Registration { CustomerId = 6, ProductId = 2 },
                new Registration { CustomerId = 6, ProductId = 5 },
                new Registration { CustomerId = 6, ProductId = 7 },

                new Registration { CustomerId = 7, ProductId = 8 },
                new Registration { CustomerId = 7, ProductId = 2 },
                new Registration { CustomerId = 7, ProductId = 3 },
                
                new Registration { CustomerId = 8, ProductId = 1 },
                new Registration { CustomerId = 8, ProductId = 3 },
                new Registration { CustomerId = 8, ProductId = 6 },

                new Registration { CustomerId = 9, ProductId = 4 },
                new Registration { CustomerId = 9, ProductId = 7 },
                new Registration { CustomerId = 9, ProductId = 10 },

                new Registration { CustomerId = 10, ProductId = 2 },
                new Registration { CustomerId = 10, ProductId = 1 },
                new Registration { CustomerId = 10, ProductId = 6 }
            );
        }
    }
}
