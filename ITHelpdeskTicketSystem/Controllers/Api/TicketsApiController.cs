using ITHelpdeskTicketSystem.Dtos;
using ITHelpdeskTicketSystem.Models;
using ITHelpdeskTicketSystem.Models.Enums;
using ITHelpdeskTicketSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ITHelpdeskTicketSystem.Controllers.Api
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketsApiController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketsApiController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string? search, [FromQuery] TicketPriority? ticketPriority)
        {
            var results = _ticketRepository.Search(search, ticketPriority);
            return Ok(results);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetTicket(int id)
        {
            var result = _ticketRepository.GetTicket(id);
            if(result == null) return NotFound();
            return Ok(new TicketDto(result.Id, result.Title, result.Status, result.Priority));
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteTicket(int id)
        {
            bool result = _ticketRepository.DeleteTicket(id);
            if (result == false) return NotFound();
            return NoContent();
        }

        [HttpPost("echo/{id:int}")]
        public IActionResult Echo([FromRoute] int id, [FromQuery] string source, [FromHeader(Name = "x-client")] string client, [FromBody] EchoDto echoDto)
        {
            return Ok(new {id, source, client, echoDto});
        }
    }
}
