using Microsoft.EntityFrameworkCore;
using assigment4.Models;

namespace assigment4.Data
{
    public class AirlineDbContext : DbContext
    {
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Using LocalDB for development
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=AirlineDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Aircraft>()
                .HasOne(a => a.Airline)
                .WithMany(al => al.Aircrafts)
                .HasForeignKey(a => a.AirlineId);

            modelBuilder.Entity<Route>()
                .HasOne(r => r.Aircraft)
                .WithMany(a => a.Routes)
                .HasForeignKey(r => r.AircraftId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Airline)
                .WithMany(al => al.Employees)
                .HasForeignKey(e => e.AirlineId);

            modelBuilder.Entity<Qualification>()
                .HasOne(q => q.Employee)
                .WithMany(e => e.Qualifications)
                .HasForeignKey(q => q.EmployeeId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Airline)
                .WithMany(al => al.Transactions)
                .HasForeignKey(t => t.AirlineId);

            modelBuilder.Entity<Phone>()
                .HasOne(p => p.Airline)
                .WithMany(al => al.Phones)
                .HasForeignKey(p => p.AirlineId);

            // Configure decimal precision for Transaction Amount
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Airlines
            modelBuilder.Entity<Airline>().HasData(
                new Airline { Id = 1, Name = "EgyptAir", Country = "Egypt" },
                new Airline { Id = 2, Name = "Emirates", Country = "UAE" },
                new Airline { Id = 3, Name = "Lufthansa", Country = "Germany" }
            );

            // Seed Phones
            modelBuilder.Entity<Phone>().HasData(
                new Phone { Id = 1, Number = "+20-2-2267-4000", Type = "Office", AirlineId = 1 },
                new Phone { Id = 2, Number = "+20-2-2267-4001", Type = "Support", AirlineId = 1 },
                new Phone { Id = 3, Number = "+971-4-214-4444", Type = "Office", AirlineId = 2 },
                new Phone { Id = 4, Number = "+49-69-86-799-799", Type = "Office", AirlineId = 3 }
            );

            // Seed Aircrafts
            modelBuilder.Entity<Aircraft>().HasData(
                new Aircraft { Id = 1, Model = "Boeing 737", Capacity = 189, AirlineId = 1 },
                new Aircraft { Id = 2, Model = "Airbus A320", Capacity = 180, AirlineId = 1 },
                new Aircraft { Id = 3, Model = "Boeing 777", Capacity = 396, AirlineId = 1 },
                new Aircraft { Id = 4, Model = "Airbus A380", Capacity = 615, AirlineId = 2 },
                new Aircraft { Id = 5, Model = "Boeing 787", Capacity = 330, AirlineId = 2 },
                new Aircraft { Id = 6, Model = "Airbus A350", Capacity = 366, AirlineId = 3 }
            );

            // Seed Routes
            modelBuilder.Entity<Route>().HasData(
                new Route { Id = 1, Origin = "Cairo", Destination = "London", Distance = 3500, AircraftId = 1 },
                new Route { Id = 2, Origin = "Cairo", Destination = "Paris", Distance = 3200, AircraftId = 2 },
                new Route { Id = 3, Origin = "Cairo", Destination = "New York", Distance = 9000, AircraftId = 3 },
                new Route { Id = 4, Origin = "Dubai", Destination = "London", Distance = 5500, AircraftId = 4 },
                new Route { Id = 5, Origin = "Dubai", Destination = "Tokyo", Distance = 8000, AircraftId = 5 },
                new Route { Id = 6, Origin = "Frankfurt", Destination = "Singapore", Distance = 10500, AircraftId = 6 }
            );

            // Seed Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Ahmed Hassan", Position = "Pilot", AirlineId = 1 },
                new Employee { Id = 2, Name = "Fatma Ali", Position = "Flight Attendant", AirlineId = 1 },
                new Employee { Id = 3, Name = "Mohamed Salah", Position = "Engineer", AirlineId = 1 },
                new Employee { Id = 4, Name = "Sarah Johnson", Position = "Pilot", AirlineId = 2 },
                new Employee { Id = 5, Name = "Hans Mueller", Position = "Pilot", AirlineId = 3 }
            );

            // Seed Qualifications
            modelBuilder.Entity<Qualification>().HasData(
                new Qualification { Id = 1, Name = "Commercial Pilot License", Level = "Advanced", EmployeeId = 1 },
                new Qualification { Id = 2, Name = "Type Rating Boeing 737", Level = "Certified", EmployeeId = 1 },
                new Qualification { Id = 3, Name = "Safety Training", Level = "Intermediate", EmployeeId = 2 },
                new Qualification { Id = 4, Name = "First Aid", Level = "Certified", EmployeeId = 2 },
                new Qualification { Id = 5, Name = "Aircraft Maintenance", Level = "Expert", EmployeeId = 3 },
                new Qualification { Id = 6, Name = "Avionics", Level = "Advanced", EmployeeId = 3 },
                new Qualification { Id = 7, Name = "Commercial Pilot License", Level = "Advanced", EmployeeId = 4 },
                new Qualification { Id = 8, Name = "Commercial Pilot License", Level = "Advanced", EmployeeId = 5 }
            );

            // Seed Transactions
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { Id = 1, Amount = 15000, Description = "Aircraft Maintenance", Date = new DateTime(2024, 1, 15), AirlineId = 1 },
                new Transaction { Id = 2, Amount = 25000, Description = "Fuel Purchase", Date = new DateTime(2024, 1, 20), AirlineId = 1 },
                new Transaction { Id = 3, Amount = 8000, Description = "Catering Services", Date = new DateTime(2024, 1, 25), AirlineId = 1 },
                new Transaction { Id = 4, Amount = 50000, Description = "Aircraft Lease Payment", Date = new DateTime(2024, 2, 1), AirlineId = 2 },
                new Transaction { Id = 5, Amount = 30000, Description = "Insurance Premium", Date = new DateTime(2024, 2, 5), AirlineId = 2 },
                new Transaction { Id = 6, Amount = 12000, Description = "Ground Handling", Date = new DateTime(2024, 2, 10), AirlineId = 3 },
                new Transaction { Id = 7, Amount = 22000, Description = "Airport Fees", Date = new DateTime(2024, 2, 15), AirlineId = 3 }
            );
        }
    }
}
