namespace assigment4.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int AirlineId { get; set; }

        // Navigation Property
        public Airline Airline { get; set; } = null!;
    }
}
