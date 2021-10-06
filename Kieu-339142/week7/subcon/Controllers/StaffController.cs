using business.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace subcon.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : Controller
    {
        private IStaff_Serv _Staff_Serv;

        public StaffController(IStaff_Serv x)
        {
            _Staff_Serv = x;
        }

        // POST: AdminController/Create
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Create(string fname, string lname, string username, string password, int adminId)
        {
            var result = await _Staff_Serv.Add(fname, lname, username, password, adminId);
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
        public async Task<IActionResult> GetAll()
        {
            var result = await _Staff_Serv.GetAll();
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
        public async Task<IActionResult> GetStaffsByAdmin(int adminId)
        {
            var result = await _Staff_Serv.GetStaffsByAdmin(adminId);
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
        public async Task<IActionResult> Authenticate(string username, string password)
        {
            var result = await _Staff_Serv.Authenticate(username, password);
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
        public async Task<IActionResult> Update(int id, string fname, string lname, string username, string password)
        {
            var result = await _Staff_Serv.Update(id, fname, lname, username, password);
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
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _Staff_Serv.Delete(id);
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
        public async Task<IActionResult> Read(int id)
        {
            var result = await _Staff_Serv.Read(id);
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
