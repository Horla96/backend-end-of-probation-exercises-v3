using customer_support_api.Enums;
using customer_support_api.Models;
using customer_support_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace customer_support_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;


        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tickets = _ticketRepository.GetAll();
            return Ok(tickets);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var ticket = _ticketRepository.GetById(id);
            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }
        [HttpGet("filter")]
        public IActionResult filter([FromQuery] TicketStatus? status, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var tickets = _ticketRepository.FilterTickets(status, startDate, endDate);
            return Ok(tickets);
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ticket == null)
                return BadRequest("Ticket cannot be null");

            _ticketRepository.Add(ticket);
            return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Ticket ticket)
        {
            var existingTicket = _ticketRepository.GetById(id);
            if (existingTicket == null)
                return NotFound();

            existingTicket.Subject = ticket.Subject;
            existingTicket.Status = ticket.Status;
            existingTicket.Description = ticket.Description;

            _ticketRepository.Update(existingTicket);

            return Ok(existingTicket);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var existingTicket = _ticketRepository.GetById(id);
            if (existingTicket == null)
                return NotFound();

            _ticketRepository.Delete(id);
            return Ok("Ticket Deleted");
        }




    }
}

