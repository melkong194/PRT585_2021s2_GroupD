using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskB.Models;

namespace Task1.Data
{
    public class Task1Context : DbContext
    {
        public Task1Context (DbContextOptions<Task1Context> options)
            : base(options)
        {
        }

        public DbSet<TaskB.Models.Movie> Movie { get; set; }

        public DbSet<TaskB.Models.Category> Category { get; set; }
    }
}
