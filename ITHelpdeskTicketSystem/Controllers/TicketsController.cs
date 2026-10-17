using ITHelpdeskTicketSystem.Models;
using ITHelpdeskTicketSystem.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ITHelpdeskTicketSystem.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            List<Ticket> ticketList = new List<Ticket>()
            {
                new Ticket
                {
                    Id = 1,
                    Title = "Test",
                    Description = "Test",
                    Priority = TicketPriority.High,
                    Status = TicketStatus.Open,
                    CreatedOn = DateTime.Now.AddDays(-3)
                },
                new Ticket
                {
                    Id = 2,
                    Title = "Test",
                    Description = "Test",
                    Priority = TicketPriority.High,
                    Status = TicketStatus.InProgress,
                    CreatedOn = DateTime.Now.AddMinutes(-190)
                },
                new Ticket
                {
                    Id = 3,
                    Title = "Test",
                    Description = "Test",
                    Priority = TicketPriority.High,
                    Status = TicketStatus.Resolved,
                    CreatedOn = DateTime.Now.AddSeconds(-60)
                }
            };
            return View(ticketList);
        }
    }
}
