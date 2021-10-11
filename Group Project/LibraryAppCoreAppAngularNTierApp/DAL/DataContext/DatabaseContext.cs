using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using System;

namespace DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            //CONSTRUCTOR
            public OptionsBuild()
            {
                //AppConfiguration class with our connection string.
                Settings = new AppConfiguration();
                //Inits a class which allows us to configure the database connection for a db context.
                //In our case allocate the connection string that our DatabaseContext(Db Sessions) will use.
                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                //Allocates the connection string to be used when connecting to a Microsoft Sql Database
                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
                //Allocates the set options to be used by the DbContext [Eg our connection string it must use when DatabaseContext it is initiated]
                DatabaseOptions = OptionsBuilder.Options;//used for options class for our database context as we specify that online 26 - ref to 32
            }
            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> DatabaseOptions { get; set; }
            private AppConfiguration Settings { get; set; }
        }
        // We want the DatabaseContext to expect to have an DbContextOptions object available when it is created:
        // So We have set a static OptionsBuild Constructor:
        // SO IN  OTHER WORDS: 
        // A static constructor is called automatically to initialize the class before the first instance is created or any static members are referenced
        public static OptionsBuild Options = new OptionsBuild();

        //DatabaseContext CONSTRUCTOR:
        // Initializes a new instance of DbContext (DatabaseContext) but with specified OPTIONS.
        // But we will always simply just use the static OptionsBuild Options, as they are static and ready to go.
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        //Our DbSets [Entities].

        public DbSet<Student> Students { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<Act> Act { get; set; }
        public DbSet<Event> Event { get; set; }


    }
}