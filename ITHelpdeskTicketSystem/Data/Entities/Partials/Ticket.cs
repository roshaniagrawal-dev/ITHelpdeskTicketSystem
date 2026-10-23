namespace ITHelpdeskTicketSystem.Data.Entities
{
    public partial class Ticket
    {
        public bool IsAssigned => !string.IsNullOrWhiteSpace(AssignedTo);
    }
}
