using event_scheduler_and_conflict_detector_api.Dtos;
using event_scheduler_and_conflict_detector_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace event_scheduler_and_conflict_detector_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("Get all Events")]
        public IActionResult GetAllEvents()
        {
            try
            {
                var events = _eventService.GetAllEvents();
                return Ok(events);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("id")]
        public IActionResult GetEventsById(Guid id)
        {
            try
            {
                var events = _eventService.GetEventById(id);
                return Ok(events);

            }
            catch (KeyNotFoundException ex) 
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Get Event by Range")]
        public ActionResult GetEventsInRange(DateTime start,  DateTime end)
        {
            var events = _eventService.GetEventsInRange(start, end);

            if ( !events.Any())
            {
                return NotFound("No Events found in the range");
            }
            return Ok(events);
        }

        [HttpPost("Add An Event")]
        public IActionResult AddEvent(CreateEventDto dto)
        {
            try
            {
                _eventService.AddEvent(dto);
                return Ok("Event Added Successfully");
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEvent(Guid id, UpdateEventDto dto)
        {
            try
            {
                _eventService.UpdateEvent(id, dto);
                return Ok("Events Updated Successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public ActionResult DeleteEvent(Guid id)
        {
            var deleted = _eventService.DeleteEvent(id);
            if (!deleted)
            {
                return NotFound($"Event with ID: {id} Not Found");
            }
            return Ok("Events Deleted");
        }
        
    }
}
