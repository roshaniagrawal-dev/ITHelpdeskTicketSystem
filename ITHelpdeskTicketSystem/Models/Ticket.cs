using ITHelpdeskTicketSystem.Models.Enums;

namespace ITHelpdeskTicketSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; set; }
        public TicketPriority Priority { get; private set; }
        public TicketStatus Status { get; private set; } = TicketStatus.Open;
        public DateTime CreatedOn { get; private set; }

        public Ticket(string title, string description, TicketPriority priority, DateTime createdOn)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"{nameof(Title)} can't be null or empty");
            }
            
            Title = title;
            Description = description;
            Priority = priority;
            CreatedOn = createdOn;
        }

        public Ticket(string title, string description, TicketPriority priority) : this(title, description, priority, DateTime.Now) { }

        public Ticket(Ticket ticket) : this(ticket.Title, ticket.Description, ticket.Priority) { }

        public string GetSummary()
        {
            return $"#{Id} - {Title} [{Priority}] - {Status}";
        }
        public string GetSummary(bool includeDate)
        {
            return includeDate
                ? $"{GetSummary()} - {CreatedOn:dd MMM yyyy}"
                : GetSummary();
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

        public virtual string GetDetails()
        {
            return "No details";
        }
    }
}
