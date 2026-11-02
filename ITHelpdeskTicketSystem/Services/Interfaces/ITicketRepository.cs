using ITHelpdeskTicketSystem.Models;
using ITHelpdeskTicketSystem.Models.Enums;
using ITHelpdeskTicketSystem.ViewModels;

namespace ITHelpdeskTicketSystem.Services.Interfaces
{
    public interface ITicketRepository
    {
        List<Ticket> GetAll();
        Ticket? GetTicket(int id);
        bool DeleteTicket(int id);
        int AddTicket(CreateTicketViewModel createTicketViewModel);
        List<Ticket> Search(string? searchText, TicketPriority? priority);
    }
}
