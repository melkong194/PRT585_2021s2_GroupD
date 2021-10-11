using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Api.Data;
using Task = TodoList.Api.Entities.Task;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Api.Respositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoListDbContext _context;

        public TaskRepository(TodoListDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Task>> GetTaskList()
        {
            //return await _context.Tasks.Include(x => x.Assignee).Select(x=> new TaskDto {
            //    Status = x.Status,
            //    Name = x.Name,
            //    AssigneeId = x.AssigneeId,
            //    CreatedDate = x.CreatedDate,
            //    Id= x.Id,
            //    AssigneeName = x.Assignee.FirstName + ' ' + x.Assignee.LastName
            //}).ToListAsync();
            return await _context.Tasks.Include(x => x.Assignee).ToListAsync();

        }

        public async Task<Task> Create(Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Task> Update(Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Task> Delete(Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Task> GetById(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        
    }
}
