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
                    Priority = TicketPriority.Critical
                },
                new Ticket
                {
                    Id = 2,
                    Title = "Update issue",
                    Description = "Unable to update OS of laptop.",
                    Priority = TicketPriority.High
                },
                new Ticket
                {
                    Id = 3,
                    Title = "Display resolution issue",
                    Description = "Not able maximius or minimize the display resolution through settings.",
                    Priority = TicketPriority.Low
                }
            };

            ticketList.ForEach(ticket => {
                if (ticket.Id != 0)
                {
                    switch (ticket.Id)
                    {
                        case 1:
                            ticket.StartWork();
                            break;
                        case 2:
                            ticket.StartWork();
                            ticket.Resolve();
                            break;
                        case 3:
                            ticket.StartWork();
                            ticket.Resolve();
                            ticket.Close();
                            break;
                        default:
                            break;
                    }
                }
            });
            return View(ticketList);
        }
    }
}
