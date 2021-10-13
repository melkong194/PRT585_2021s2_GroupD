using ElmahCore;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.User;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser_Service _User_Service;
        private readonly ILogger<UserController> _logger;

        public UserController(IUser_Service User_Service, ILogger<UserController> logger)
        {
            _User_Service = User_Service;
            _logger = logger;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddUser(string name, string account, string password, string role, string status, string hour)
        {
            _logger.LogInformation("Create user start");
            var result = await _User_Service.AddUser(name, account, password, role, status, hour);

            _logger.LogCritical(new Exception("ExceptionText"), "This is returned user {result}", result);
            _logger.LogTrace("User is created!");
            _logger.LogInformation("Create user end");

            //throw new Exception("ExceptionText testing");

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
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _User_Service.GetAllUsers();

            _logger.LogCritical(new Exception("ExceptionText"), "This is returned all users {result}", result);
            _logger.LogTrace("getting all users!");

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
        public async Task<IActionResult> UpdateUser(User_Pass_Object user)
        {
            var result = await _User_Service.UpdateUser(user.id, user.name, user.account, user.password, user.role, user.status, user.hour);
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
        public async Task<IActionResult> DeleteUser(User_Pass_Object user)
        {
            var result = await _User_Service.DeleteUser(user.id);
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
