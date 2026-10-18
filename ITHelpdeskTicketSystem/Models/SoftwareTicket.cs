using ITHelpdeskTicketSystem.Models.Enums;

namespace ITHelpdeskTicketSystem.Models
{
    public class SoftwareTicket : Ticket
    {
        public string ApplicationName { get; private set; }

        public SoftwareTicket(string applicationm,string title, string description, TicketPriority priority) : base(title, description, priority)
        {
            ApplicationName = applicationm;
        }
    }
}
