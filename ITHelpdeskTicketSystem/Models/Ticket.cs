using ITHelpdeskTicketSystem.Models.Enums;

namespace ITHelpdeskTicketSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TicketPriority Priority { get; set; } = TicketPriority.Low;
        public TicketStatus Status { get; private set; } = TicketStatus.Open;
        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        public string GetSummary()
        {
            return $"#{Id} - {Title} [{Priority}] - {Status}";
        }

        public void StartWork()
        {
            Status = Status == TicketStatus.Open ? TicketStatus.InProgress : throw new InvalidOperationException($"Only {TicketStatus.Open} tickets can be started. Current status: {Status}");
        }
        public void Resolve()
        {
            Status = Status == TicketStatus.InProgress ? TicketStatus.Resolved : throw new InvalidOperationException($"Only {TicketStatus.InProgress} tickets can be resolved. Current status: {Status}");
        }
        public void Close()
        {
            Status = Status == TicketStatus.Resolved ? TicketStatus.Closed : throw new InvalidOperationException($"Only {TicketStatus.Resolved} tickets can be closed. Current status: {Status}");
        }
        public void Reopen()
        {
            Status = Status == TicketStatus.Resolved ? TicketStatus.InProgress : throw new InvalidOperationException($"Only {TicketStatus.Resolved} tickets can be reopened. Current status: {Status}");
        }
    }
}
