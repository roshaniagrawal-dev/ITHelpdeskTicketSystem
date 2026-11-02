using ITHelpdeskTicketSystem.Data;
using ITHelpdeskTicketSystem.Models;
using ITHelpdeskTicketSystem.Models.Enums;
using ITHelpdeskTicketSystem.Services.Interfaces;
using ITHelpdeskTicketSystem.ViewModels;
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
            var rows = _db.Tickets.Where(x=> x.Status != (int)TicketStatus.InActive).AsNoTracking().ToList();
            return rows.Select(ToModel).ToList();
        }

        public Ticket? GetTicket(int id)
        {
            var row = _db.Tickets.Where(x => x.Status != (int)TicketStatus.InActive).AsNoTracking().FirstOrDefault(x => x.Id == id);
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
            row.Status = (int)TicketStatus.InActive;
            _db.SaveChanges();
            return true;
        }

        private static Ticket ToModel(TicketEntity row)
        {
            var priority =  (TicketPriority)row.Priority;
            var description = row.Description ?? string.Empty;
            Ticket ticket = row.TicketType switch
            {
                "1" => new HardwareTicket(row.AssetTag!, row.Title, description, priority),
                "2" => new SoftwareTicket(row.ApplicationName!, row.Title, description, priority),
                "3" => new AccessRequestTicket(row.SystemName!, row.Title, description, priority, row.CreatedOn),
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

            tickets = tickets.Where(x=> x.Status != (int)TicketStatus.InActive).OrderBy(t => t.Id);
            return tickets.ToList().Select(ToModel).ToList();
        }

        public int AddTicket(CreateTicketViewModel ticket)
        {
            TicketEntity ticket1 = new ()
            {
                Title = ticket.Title,
                CreatedOn = DateTime.Now,
                Description = ticket.Description ?? string.Empty,
                Priority = (int)ticket.Priority,
                Status = (int)TicketStatus.Open,
                TicketType = ticket.TicketType,
                AssignedTo = "Roshani"
            };

            switch (ticket.TicketType)
            {
                case "1" : ticket1.AssetTag = ticket.AssetTag; break;
                case "2" : ticket1.ApplicationName = ticket.ApplicationName; break;
                case "3" : ticket1.SystemName = ticket.SystemName; break;
                default: break;
            }

            _db.Tickets.Add(ticket1);
            _db.SaveChanges();
            return ticket1.Id;
        }
    }
}
