using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThis.Bll
{
    public interface IDiet
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<IDish> GetDishes();
    }
}
