using ITHelpdeskTicketSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ITHelpdeskTicketSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets => Set<Ticket>();
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HardwareTicket>();
            modelBuilder.Entity<SoftwareTicket>();
            modelBuilder.Entity<AccessRequestTicket>();
            modelBuilder.Entity<Ticket>().Property(x=> x.Title).HasMaxLength(200).IsRequired();
        }
    }
}
