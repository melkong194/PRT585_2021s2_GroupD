using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TodoList.Models;
using TodoListServer.Services;

namespace TodoListServer.Pages
{
    public partial class TodoList
    {
        [Inject] private ITaskApiClient TaskApiClient { get; set; }

        private List<TaskDto> Tasks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Tasks = await TaskApiClient.GetTaskList();
        }
    }
}
