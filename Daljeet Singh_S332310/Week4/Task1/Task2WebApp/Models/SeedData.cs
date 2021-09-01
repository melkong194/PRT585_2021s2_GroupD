using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Models;
using System;
using System.Linq;
using Task2WebAppAdmin.Data;

namespace Task2WebAppAdmin.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Task2WebAppAdminContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Task2WebAppAdminContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Name = "How To Train Your Dragon 2",
                        ReleaseDate = DateTime.Parse("2009-4-11"),
                        Director = "Animated",
                        ContactEmail = "xyz@gmail.com",
                        Language = Movie.LanguageEnum.English,
                        Category= new Task2WebAppAdmin.Models.Category { Name="Comedy",Code=110}

                    }, new Movie
                    {
                        Name = "The Girl On the Train",
                        ReleaseDate = DateTime.Parse("2009-3-11"),
                        Director = "Science Fiction",
                        ContactEmail = "xyz@gmail.com",
                        Language = Movie.LanguageEnum.English,
                        Category = new Task2WebAppAdmin.Models.Category {  Name = "Action", Code = 111 }

                    }, 
                    new Movie
                    {
                        Name = "How To Train Your Dragon",
                        ReleaseDate = DateTime.Parse("2004-1-10"),
                        Director = "Animated",
                        ContactEmail = "xyz@gmail.com",
                        Language = Movie.LanguageEnum.English,
                        Category = new Task2WebAppAdmin.Models.Category { Name = "Thriller", Code = 112 }

                    },

                     new Movie
                     {
                         Name = "The Girl On the Train 2",
                         ReleaseDate = DateTime.Parse("2011-2-12"),
                         Director = "Science Fiction",
                         ContactEmail = "xyz@gmail.com",
                         Language = Movie.LanguageEnum.English,
                         Category = new Task2WebAppAdmin.Models.Category { Name = "Comedy", Code = 113 }

                     }
                );
                context.SaveChanges();
            }
        }
    }
}