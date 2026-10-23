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
        private readonly INotifier _notifier;
        public TicketsController(ITicketRepository ticketRepository, INotifier notifier)
        {
            _ticketRepository = ticketRepository;
            _notifier = notifier;
        }

        public IActionResult Index()
        {
            var ticketList = _ticketRepository.GetAll();
            ViewBag.Message = _notifier.Send($"{ticketList.Count} tickets loaded");
            return View(ticketList);
        }
    }
}
