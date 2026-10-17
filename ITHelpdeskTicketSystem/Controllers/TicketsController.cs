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
                    Title = "Laptop not working",
                    Description = "Laptop showing black screen.",
                    Priority = TicketPriority.Critical,
                    Status = TicketStatus.Open,
                    CreatedOn = DateTime.Now.AddDays(-3)
                },
                new Ticket
                {
                    Id = 2,
                    Title = "Update issue",
                    Description = "Unable to update OS of laptop.",
                    Priority = TicketPriority.High,
                    Status = TicketStatus.InProgress,
                    CreatedOn = DateTime.Now.AddMinutes(-190)
                },
                new Ticket
                {
                    Id = 3,
                    Title = "Display resolution issue",
                    Description = "Not able maximius or minimize the display resolution through settings.",
                    Priority = TicketPriority.Low,
                    Status = TicketStatus.Resolved,
                    CreatedOn = DateTime.Now.AddSeconds(-60)
                }
            };
            return View(ticketList);
        }
    }
}
