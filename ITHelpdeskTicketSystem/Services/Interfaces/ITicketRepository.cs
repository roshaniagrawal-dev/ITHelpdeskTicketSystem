using ITHelpdeskTicketSystem.Models;

namespace ITHelpdeskTicketSystem.Services.Interfaces
{
    public interface ITicketRepository
    {
        List<Ticket> GetAll();
    }
}
