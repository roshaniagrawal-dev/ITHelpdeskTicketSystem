using ITHelpdeskTicketSystem.Models;
using ITHelpdeskTicketSystem.Models.Enums;
using ITHelpdeskTicketSystem.Services;
using ITHelpdeskTicketSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITHelpdeskTicketSystem.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public IActionResult Index()
        {
            var ticketList = _ticketRepository.GetAll();
            INotifier notifier = new SmsNotifier();
            ViewBag.Message = notifier.Send($"{ticketList.Count} tickets loaded");
            return View(ticketList);
        }
    }
}
