using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskB.Models;

namespace TaskB.Data
{
    public class TaskBContext : DbContext
    {
        public TaskBContext (DbContextOptions<TaskBContext> options)
            : base(options)
        {
        }

        public DbSet<TaskB.Models.Movie> Movie { get; set; }

        public DbSet<TaskB.Models.Category> Category { get; set; }
    }
}
