using ITHelpdeskTicketSystem.Data;
using ITHelpdeskTicketSystem.Models;
using ITHelpdeskTicketSystem.Models.Enums;
using ITHelpdeskTicketSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public Ticket? GetTicket(int id)
        {
            var row = _db.Tickets.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (row == null)
            {
                return null;
            }
            return ToModel(row);
        }

        public bool DeleteTicket(int id)
        {
            var row = _db.Tickets.FirstOrDefault(x => x.Id == id);
            if (row == null)
            {
                return false;
            }
            _db.Tickets.Remove(row);
            _db.SaveChanges();
            return true;
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

        public List<Ticket> Search(string? searchText, TicketPriority? priority) 
        {
            IQueryable<TicketEntity> tickets = _db.Tickets.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                tickets = tickets.Where(t => t.Title.Contains(searchText));
            }
            if (priority.HasValue)
            {

                tickets = tickets.Where(t => t.Priority == (int)priority.Value);
            }

            tickets = tickets.OrderByDescending(t => t.CreatedOn);
            return tickets.ToList().Select(ToModel).ToList();
        }
    }
}
