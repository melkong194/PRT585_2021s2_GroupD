using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoListServer.Services
{
    public interface ITaskApiClient
    {
        Task<List<TaskDto>> GetTaskList();
    }
}
