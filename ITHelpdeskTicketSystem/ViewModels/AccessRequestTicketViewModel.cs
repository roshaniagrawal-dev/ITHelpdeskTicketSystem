using ITHelpdeskTicketSystem.Models.Enums;
using ITHelpdeskTicketSystem.ViewModels;

namespace ITHelpdeskTicketSystem.ViewModels
{
    public class AccessRequestTicketViewModel : CreateTicketViewModel
    {
        public string SystemName { get; private set; }
    }
}
