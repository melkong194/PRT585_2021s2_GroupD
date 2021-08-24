using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LearnCoreMVC.Models;

namespace LearnCoreMVC.Data
{
    public class LearnCoreMVCContext : DbContext
    {
        public LearnCoreMVCContext (DbContextOptions<LearnCoreMVCContext> options)
            : base(options)
        {
        }

        public DbSet<LearnCoreMVC.Models.Movie> Movie { get; set; }
    }
}
