using ITHelpdeskTicketSystem.Models;
using ITHelpdeskTicketSystem.Models.Enums;

namespace ITHelpdeskTicketSystem.Services.Interfaces
{
    public interface ITicketRepository
    {
        List<Ticket> GetAll();
        List<Ticket> Search(string? searchText, TicketPriority? priority);
    }
}
