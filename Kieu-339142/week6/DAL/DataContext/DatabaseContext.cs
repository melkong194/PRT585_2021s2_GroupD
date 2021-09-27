using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataContext
{
    public class DatabaseContext: DbContext
    {
        public class OptionsBuild
        {
            //CONSTRUCTOR
            public OptionsBuild()
            {
                Settings = new AppConfiguration();
                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();    
                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);   
                DatabaseOptions = OptionsBuilder.Options;
            }
            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> DatabaseOptions { get; set; }
            private AppConfiguration Settings { get; set; }
        }


        public static OptionsBuild Options = new OptionsBuild();


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
