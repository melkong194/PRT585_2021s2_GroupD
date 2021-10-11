using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Api.Respositories;
using TodoList.Models;
using TodoList.Models.Enums;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        //api/tasks?name=
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskRepository.GetTaskList();
            var taskDto = tasks.Select(x => new TaskDto
            {
                Status = x.Status,
                Priority = x.Priority,
                Name = x.Name,
                AssigneeId = x.AssigneeId,
                CreatedDate = x.CreatedDate,
                Id = x.Id,
                AssigneeName = x.Assignee != null ? x.Assignee.FirstName + ' ' + x.Assignee.LastName : "N/A"
            });

            return Ok(taskDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = await _taskRepository.Create(new Entities.Task()
            {
                Name = request.Name,
                Priority = (Priority)request.Priority,
                Status = Status.Open,
                CreatedDate = DateTime.Now,
                Id = request.Id
            });
            
            return CreatedAtAction(nameof(GetById), new { id= task.Id}, task);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, TaskUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var taskFromDb = await _taskRepository.GetById(id);

            if (taskFromDb == null) return NotFound($"{id} is not found");

            taskFromDb.Name = request.Name;
            taskFromDb.Priority = request.Priority;

            var taskResult = await _taskRepository.Update(taskFromDb);

            return Ok(new TaskDto()
            {
                Name = taskResult.Name,
                Priority = taskResult.Priority,
                Status = taskResult.Status,
                CreatedDate = taskResult.CreatedDate,
                Id = taskResult.Id,
                AssigneeId = taskResult.AssigneeId
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = await _taskRepository.GetById(id);
            if (task == null) return NotFound($"{id} is not found");

            var taskResult = await _taskRepository.Update(task);

            return Ok(new TaskDto()
            {
                Name = taskResult.Name,
                Priority = taskResult.Priority,
                Status = taskResult.Status,
                CreatedDate = taskResult.CreatedDate,
                Id = taskResult.Id,
                AssigneeId = taskResult.AssigneeId
            });
        }

    }
}
