using ITHelpdeskTicketSystem.Models;
using ITHelpdeskTicketSystem.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ITHelpdeskTicketSystem.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            List<Ticket> ticketList = new()
            {
                new SoftwareTicket("VS2022", "Laptop not working",  "Laptop showing black screen.", TicketPriority.Medium)
                {
                    Id = 1
                },
                new HardwareTicket("LPU001", "Update issue", "Unable to update OS of laptop.", TicketPriority.High)
                {
                    Id = 2
                },
                new AccessRequestTicket("VPN", "Black screen", "Black screen of laptop.", TicketPriority.Low, DateTime.Now.AddDays(-1))
                {
                    Id = 3
                }
            };

            //Copy the object using copy constructor 
            Ticket ticket = ticketList.First();
            Ticket copyT = new Ticket(ticket); 
            ticketList.Add(copyT);

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
