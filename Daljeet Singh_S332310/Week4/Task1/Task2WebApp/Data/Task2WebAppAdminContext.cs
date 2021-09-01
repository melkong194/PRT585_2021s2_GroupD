using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace Task2WebAppAdmin.Data
{
    public class Task2WebAppAdminContext : DbContext
    {
        public Task2WebAppAdminContext (DbContextOptions<Task2WebAppAdminContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; }
        public DbSet<Task2WebAppAdmin.Models.Category> Category { get; set; }
    }
}
