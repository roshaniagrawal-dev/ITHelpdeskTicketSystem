using ITHelpdeskTicketSystem.Models.Enums;

namespace ITHelpdeskTicketSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TicketPriority Priority { get; set; } = TicketPriority.Low;
        public TicketStatus Status { get; set; } = TicketStatus.Open;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string GetSummary()
        {
            return $"#{Id} - {Title} [{Priority}] - {Status}";
        }
    }
}
