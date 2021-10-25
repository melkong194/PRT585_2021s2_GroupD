using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Act;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class ActController : ControllerBase
    {
        private IAct_Service _Act_Service;

        public ActController(IAct_Service Act_Service)
        {
            _Act_Service = Act_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddAct(string desc, string time, string date, Int64 user_id, string user_name, string lat, string lng)
        {
            var result = await _Act_Service.AddAct(desc, time, date, user_id, user_name,  lat,  lng);
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
        public async Task<IActionResult> GetAllActs()
        {
            var result = await _Act_Service.GetAllActs();
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
        public async Task<IActionResult> UpdateAct(Act_Pass_Object act)
        {
            var result = await _Act_Service.UpdateAct(act.id, act.desc, act.time, act.date, act.user_id, act.user_name, act.lat,  act.lng);
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
        public async Task<IActionResult> DeleteAct(Act_Pass_Object act)
        {
            var result = await _Act_Service.DeleteAct(act.id);
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
