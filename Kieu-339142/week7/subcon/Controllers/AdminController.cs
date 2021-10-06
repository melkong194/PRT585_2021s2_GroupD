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
    public class AdminController : Controller
    {
        private IAdmin_Serv _Admin_Serv;
        
        public AdminController(IAdmin_Serv x)
        {
            _Admin_Serv = x;
        }        

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Create(string fname, string lname, string username, string password)
        {
            var result = await _Admin_Serv.Add( fname,  lname,  username,  password);
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
            var result = await _Admin_Serv.GetAll();
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
            var result = await _Admin_Serv.Authenticate(username, password);
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
            var result = await _Admin_Serv.Update(id, fname, lname, username, password);
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
            var result = await _Admin_Serv.Delete(id);
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
            var result = await _Admin_Serv.Read(id);
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
