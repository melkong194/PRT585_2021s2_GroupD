using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskA.Models;

namespace TaskA.Data
{
    public class TaskAContext : DbContext
    {
        public TaskAContext (DbContextOptions<TaskAContext> options)
            : base(options)
        {
        }

        public DbSet<TaskA.Models.Movie> Movie { get; set; }
    }
}
