using ITHelpdeskTicketSystem.Models;
using ITHelpdeskTicketSystem.Models.Enums;
using ITHelpdeskTicketSystem.Services;
using ITHelpdeskTicketSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITHelpdeskTicketSystem.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            List<Ticket> ticketList = new()
            {
                new SoftwareTicket("VS2022", "Download VS 2022",  "need for .net framework code blocks.", TicketPriority.Medium)
                {
                    Id = 1
                },
                new HardwareTicket("LPU001", "Need new laptop as old not working", "Please issue me new laptop with .... specifications.", TicketPriority.High)
                {
                    Id = 2
                },
                new AccessRequestTicket("VPN", "Share me VPN details", "Please make it priority as without this cant start working.", TicketPriority.High, DateTime.Now.AddDays(-1))
                {
                    Id = 3
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
            INotifier notifier = new SmsNotifier();
            ViewBag.Message = notifier.Send($"{ticketList.Count} tickets loaded");
            return View(ticketList);
        }
    }
}
