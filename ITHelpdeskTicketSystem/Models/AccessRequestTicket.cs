using ITHelpdeskTicketSystem.Models.Enums;

namespace ITHelpdeskTicketSystem.Models
{
    public class AccessRequestTicket : Ticket
    {
        public string SystemName { get; private set; }

        public AccessRequestTicket(string systemName, string title, string description, TicketPriority priority, DateTime createdOn) : base(title, description, priority, createdOn)
        {
            SystemName = systemName;
        }
    }
}
