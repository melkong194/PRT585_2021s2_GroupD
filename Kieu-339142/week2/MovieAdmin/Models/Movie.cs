using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAdmin.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public string ContactEmail { get; set; }
        public Language Language { get; set; }

        [Required]
        public int Category { get; set; }
    }
}
