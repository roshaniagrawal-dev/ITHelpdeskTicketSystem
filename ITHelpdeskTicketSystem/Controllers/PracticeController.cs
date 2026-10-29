using Microsoft.AspNetCore.Mvc;

namespace ITHelpdeskTicketSystem.Controllers
{
    public class PracticeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Hello()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Hello(string name)
        {
            ViewBag.GreetingMessage = $"Hello {name}, Good Morning ....!";
            return View();
        }
    }
}
