using ITHelpdeskTicketSystem.Models;
using ITHelpdeskTicketSystem.Models.Enums;

namespace ITHelpdeskTicketSystem.Services.Interfaces
{
    public interface ITicketRepository
    {
        List<Ticket> GetAll();
        Ticket? GetTicket(int id);
        bool DeleteTicket(int id);
        List<Ticket> Search(string? searchText, TicketPriority? priority);
    }
}
