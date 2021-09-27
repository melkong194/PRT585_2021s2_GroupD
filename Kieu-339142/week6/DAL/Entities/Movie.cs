using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Movie
    {
        [Key]
        public Int64 ID { get; set; }
        [Required]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; }

        public string ContactEmail { get; set; }
       
        [Required]
        public Language Language { get; set; }

        [Required]
        public Int64 CategoryId { get; set; }
    }
}
