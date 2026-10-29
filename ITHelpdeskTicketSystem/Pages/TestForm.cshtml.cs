using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITHelpdeskTicketSystem.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; } = "";
        public void OnPost(string name)
        {
            Message = $"Hello {name}";
        }
    }
}
