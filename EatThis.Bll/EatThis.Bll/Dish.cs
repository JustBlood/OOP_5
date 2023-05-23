using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThis.Bll
{
    public class Dish : IDish
    {
        public IEnumerable<IProduct>? Composition { get; set; }
        public decimal? Price { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Nutrients? Nutrients { get; set; }
        public double Calories { get; set; }

        public IEnumerable<IProduct> GetComposition()
        {
            return Composition?.ToList() ?? throw new NullReferenceException("Список продуктов для блюда не определен.");
        }
    }
}
