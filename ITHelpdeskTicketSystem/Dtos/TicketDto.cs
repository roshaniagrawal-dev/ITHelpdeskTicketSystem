using ITHelpdeskTicketSystem.Models.Enums;

namespace ITHelpdeskTicketSystem.Dtos
{
    public record TicketDto(int Id, string Title, TicketStatus Status, TicketPriority Priority);
}
