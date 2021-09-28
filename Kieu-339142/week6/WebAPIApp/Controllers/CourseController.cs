using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Course;


namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourse_Service _Course_Service;

        public CourseController(ICourse_Service Course_Service)
        {
            _Course_Service = Course_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddCourse(string name, string code)
        {
            var result = await _Course_Service.AddCourse(name, code);
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
        public async Task<IActionResult> GetAllCourses()
        {
            var result = await _Course_Service.GetAllCourses();
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
        public async Task<IActionResult> UpdateCourse(Course_Pass_Object course)
        {
            var result = await _Course_Service.UpdateCourse(course.id, course.name, course.code);
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
        public async Task<IActionResult> DeleteCourse(Course_Pass_Object course)
        {
            var result = await _Course_Service.DeleteCourse(course.id);
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
