using ITHelpdeskTicketSystem.Models.Enums;

namespace ITHelpdeskTicketSystem.Models
{
    public class HardwareTicket : Ticket
    {
        public string AssetTag { get; private set; }

        public HardwareTicket(string assetTag, string title, string description, TicketPriority priority) : base(title, description, priority)
        {
            if (string.IsNullOrWhiteSpace(assetTag))
                throw new ArgumentException("Asset tag is required.", nameof(assetTag));
            AssetTag = assetTag;
        }

        public override string GetDetails()
        {
            return $"Asset: {AssetTag}";
        }
    }
}
