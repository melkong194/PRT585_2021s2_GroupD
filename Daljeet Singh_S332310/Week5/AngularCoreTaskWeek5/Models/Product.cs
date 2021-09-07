using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCoreWeek5Task.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
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
