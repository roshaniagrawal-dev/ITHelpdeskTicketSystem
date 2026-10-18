using ITHelpdeskTicketSystem.Models.Enums;

namespace ITHelpdeskTicketSystem.Models
{
    public class HardwareTicket : Ticket
    {
        public string AssetTag { get; private set; }

        public HardwareTicket(string assetTag, string title, string description, TicketPriority priority) : base(title, description, priority)
        {
            AssetTag = assetTag;
        }
    }
}
