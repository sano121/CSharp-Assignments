namespace assigment4.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // e.g., "Office", "Mobile"
        public int AirlineId { get; set; }

        // Navigation Property
        public Airline Airline { get; set; } = null!;
    }
}
