using ITHelpdeskTicketSystem.Models.Enums;

namespace ITHelpdeskTicketSystem.Models
{
    public class SoftwareTicket : Ticket
    {
        public string ApplicationName { get; private set; }

        public SoftwareTicket(string applicationName, string title, string description, TicketPriority priority) : base(title, description, priority)
        {
            if (string.IsNullOrWhiteSpace(applicationName))
                throw new ArgumentException("Application name is required.", nameof(applicationName));

            ApplicationName = applicationName;
        }

        public override string GetDetails()
        {
            return $"App: {ApplicationName}";
        }
    }
}
