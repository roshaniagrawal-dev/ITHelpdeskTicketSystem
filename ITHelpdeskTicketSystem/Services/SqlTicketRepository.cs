using ITHelpdeskTicketSystem.Data;
using ITHelpdeskTicketSystem.Models;
using ITHelpdeskTicketSystem.Models.Enums;
using ITHelpdeskTicketSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

using TicketEntity = ITHelpdeskTicketSystem.Data.Entities.Ticket;

namespace ITHelpdeskTicketSystem.Services
{
    public class SqlTicketRepository : ITicketRepository
    {
        private readonly AppDbContext _db;

        public SqlTicketRepository(AppDbContext db) {
            _db = db;
        }

        public List<Ticket> GetAll()
        {
            var rows = _db.Tickets.AsNoTracking().ToList();
            return rows.Select(ToModel).ToList();
        }

        private static Ticket ToModel(TicketEntity row)
        {
            var priority =  (TicketPriority)row.Priority;
            var description = row.Description ?? string.Empty;
            Ticket ticket = row.TicketType switch
            {
                "Hardware" => new HardwareTicket(row.AssetTag!, row.Title, description, priority),
                "Software" => new SoftwareTicket(row.ApplicationName!, row.Title, description, priority),
                "Access" => new AccessRequestTicket(row.SystemName!, row.Title, description, priority, row.CreatedOn),
                _ => throw new InvalidOperationException($"Unknown ticket type: {row.TicketType}")
            };

            ticket.LoadFromDatabase(row.Id, (TicketStatus)row.Status, row.CreatedOn);
            return ticket;
        }
    }
}
