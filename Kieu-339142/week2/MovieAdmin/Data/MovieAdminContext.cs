using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieAdmin.Models;

namespace MovieAdmin.Data
{
    public class MovieAdminContext : DbContext
    {
        public MovieAdminContext (DbContextOptions<MovieAdminContext> options)
            : base(options)
        {
        }

        public DbSet<MovieAdmin.Models.Movie> Movie { get; set; }

        public DbSet<MovieAdmin.Models.Category> Category { get; set; }
    }
}
