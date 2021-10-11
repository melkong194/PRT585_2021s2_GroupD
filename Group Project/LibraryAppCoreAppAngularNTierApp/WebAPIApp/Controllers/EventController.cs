using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Event;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEvent_Service _Event_Service;

        public EventController(IEvent_Service Event_Service)
        {
            _Event_Service = Event_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddEvent(Int64 user_id, string user_name, string title, string start, string end, string recurrence_rule)
        {
            var result = await _Event_Service.AddEvent(user_id, user_name, title, start, end, recurrence_rule);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllEvents()
        {
            var result = await _Event_Service.GetAllEvents();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateEvent(Event_Pass_Object evnt)
        {
            var result = await _Event_Service.UpdateEvent(evnt.id, evnt.user_id, evnt.user_name, evnt.title, evnt.start, evnt.end, evnt.recurrence_rule);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteEvent(Event_Pass_Object evnt)
        {
            var result = await _Event_Service.DeleteEvent(evnt.id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

    }
}
