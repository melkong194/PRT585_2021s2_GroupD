﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Api.Respositories;

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

            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Entities.Task task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tasks = await _taskRepository.Create(task);
            return CreatedAtAction(nameof(GetById), new { id= task.Id}, tasks);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, Entities.Task task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var taskFromDb = _taskRepository.GetById(id);

            if (taskFromDb == null) return NotFound($"{id} is not found");
            
            var tasks = await _taskRepository.Update(task);

            return Ok(task);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = await _taskRepository.GetById(id);
            if (task == null) return NotFound($"{id} is not found");
            return Ok(task);
        }

    }
}