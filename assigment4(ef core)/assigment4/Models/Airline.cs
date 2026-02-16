namespace assigment4.Models
{
    public class Airline
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        // Navigation Properties
        public ICollection<Aircraft> Aircrafts { get; set; } = new List<Aircraft>();
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Phone> Phones { get; set; } = new List<Phone>();
    }
}
