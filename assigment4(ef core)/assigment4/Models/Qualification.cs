namespace assigment4.Models
{
    public class Qualification
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public int EmployeeId { get; set; }

        // Navigation Property
        public Employee Employee { get; set; } = null!;
    }
}
