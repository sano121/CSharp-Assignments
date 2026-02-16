namespace assigment4.Models
{
    public class Aircraft
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int AirlineId { get; set; }

        // Navigation Properties
        public Airline Airline { get; set; } = null!;
        public ICollection<Route> Routes { get; set; } = new List<Route>();
    }
}
