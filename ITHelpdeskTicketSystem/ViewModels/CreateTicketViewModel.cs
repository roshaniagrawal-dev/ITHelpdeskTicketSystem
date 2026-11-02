using ITHelpdeskTicketSystem.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace ITHelpdeskTicketSystem.ViewModels
{
    using TicketTypeEnum = ITHelpdeskTicketSystem.Models.Enums.TicketType;
    public class CreateTicketViewModel
    {
        [Required, StringLength(100, MinimumLength = 5)]
        public string Title { get; set; } = string.Empty;
        [Required, StringLength(2000, MinimumLength = 25)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public TicketPriority? Priority { get; set; }
        [Required]
        public string TicketType { get; set; } = string.Empty;
        public string? SystemName { get; set; }
        public string? AssetTag { get; set; }
        public string? ApplicationName { get; set; }
        public List<SelectListItem> ticketPriorities { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ticketTypes { get; set; } = new List<SelectListItem>();
        public CreateTicketViewModel()
        {
            ticketPriorities = new List<SelectListItem>
            {
                new SelectListItem { Text = TicketPriority.Critical.ToString(), Value = Convert.ToString((int)TicketPriority.Critical)},
                new SelectListItem { Text = TicketPriority.High.ToString(), Value = Convert.ToString((int)TicketPriority.High)},
                new SelectListItem { Text = TicketPriority.Medium.ToString(), Value = Convert.ToString((int)TicketPriority.Medium)},
                new SelectListItem { Text = TicketPriority.Low.ToString(), Value = Convert.ToString((int)TicketPriority.Low)}
            };
            ticketTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = TicketTypeEnum.Hardware.ToString(), Value = Convert.ToString((int)TicketTypeEnum.Hardware)},
                new SelectListItem { Text = TicketTypeEnum.Software.ToString(), Value = Convert.ToString((int)TicketTypeEnum.Software)},
                new SelectListItem { Text = TicketTypeEnum.AccessRequest.ToString(), Value = Convert.ToString((int)TicketTypeEnum.AccessRequest)}
            };
        }
    }
}