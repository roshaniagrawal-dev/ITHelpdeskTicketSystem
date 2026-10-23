using ITHelpdeskTicketSystem.Data;
using ITHelpdeskTicketSystem.Models;
using ITHelpdeskTicketSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return _db.Tickets.AsNoTracking().ToList();
        }
    }
}
