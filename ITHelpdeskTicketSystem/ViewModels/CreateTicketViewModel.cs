using ITHelpdeskTicketSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ITHelpdeskTicketSystem.ViewModels
{
    public class CreateTicketViewModel
    {
        [Required, StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }
        [Required, StringLength(2000, MinimumLength = 25)]
        public string Description { get; set; }
        [Required]
        public TicketPriority? Priority { get; set; }

        [Required]
        public string TicketType { get; set; } = string.Empty;
    }
}