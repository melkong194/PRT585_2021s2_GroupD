using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAdmin.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Category Name")]
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
