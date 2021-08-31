using System;
using System.ComponentModel.DataAnnotations;
using Task2WebAppAdmin.Models;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public string ContactEmail { get; set; }
        public enum LanguageEnum
        {
            English,
            Japanese,
            Chinese
        }
        public LanguageEnum Language { get; set; }
        public Category Category { get; set; }
    }
}