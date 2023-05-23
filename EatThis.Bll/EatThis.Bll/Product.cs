using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThis.Bll
{
    public class Product : IProduct
    {
        public decimal? Price { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Nutrients? Nutrients { get; set; }
        public double Calories { get; set; }

        Product(string name, double calories)
        {
            Name = name;
            Calories = calories;
        }
    }
}
