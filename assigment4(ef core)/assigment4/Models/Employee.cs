namespace assigment4.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int AirlineId { get; set; }

        // Navigation Properties
        public Airline Airline { get; set; } = null!;
        public ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();
    }
}
