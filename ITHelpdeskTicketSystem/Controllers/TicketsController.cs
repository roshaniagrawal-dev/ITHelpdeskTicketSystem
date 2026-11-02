using ITHelpdeskTicketSystem.Models.Enums;
using ITHelpdeskTicketSystem.Services.Interfaces;
using ITHelpdeskTicketSystem.ViewModels;
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


        public IActionResult Index(string? search, TicketPriority? priority)
        {
            var ticketList = _ticketRepository.Search(search, priority);
            ViewBag.Search = search;
            ViewBag.Priority = priority;
            ViewBag.Message = _notifier.Send($"{ticketList.Count} tickets loaded");
            ViewData["PageTitle"] = "Tickets";
            return View(ticketList);
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var result = _ticketRepository.GetTicket(id);
            if (result == null) {
                return NotFound();
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateTicketViewModel());
        }

        [HttpPost]
        public IActionResult Create(CreateTicketViewModel createTicketViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createTicketViewModel);
            }
            var id = _ticketRepository.AddTicket(createTicketViewModel);
            if (id == 0)
            {
                return View(createTicketViewModel);
            }
            TempData["SuccessMessage"] = "Successfully added record..!";
            return RedirectToAction("Details", new { id });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            bool result = _ticketRepository.DeleteTicket(id);
            if (result == false) return NotFound();
            TempData["SuccessMessage"] = "Successfully deleted record..!";
            return RedirectToAction("Index");
        }
    }
}
