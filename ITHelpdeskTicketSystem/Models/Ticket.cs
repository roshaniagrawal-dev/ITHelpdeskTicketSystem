namespace ITHelpdeskTicketSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = "Open";
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string GetSummary()
        {
            return $"#{Id} - {Title} [{Priority}] - {Status}";
        }
    }
}
