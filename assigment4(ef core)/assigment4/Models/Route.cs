namespace assigment4.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public int Distance { get; set; }
        public int AircraftId { get; set; }

        // Navigation Property
        public Aircraft Aircraft { get; set; } = null!;
    }
}
