using ITHelpdeskTicketSystem.Models.Enums;

namespace ITHelpdeskTicketSystem.Models
{
    public class AccessRequestTicket : Ticket
    {
        public string SystemName { get; private set; }

        public AccessRequestTicket(string systemName, string title, string description, TicketPriority priority, DateTime createdOn) : base(title, description, priority, createdOn)
        {
            if (string.IsNullOrWhiteSpace(systemName))
                throw new ArgumentException("System name is required.", nameof(systemName));
            SystemName = systemName;
        }

        public override string GetDetails()
        {
            return $"System: {SystemName}";
        }
    }
}
