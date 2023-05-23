using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThis.Bll
{
    public interface IDish : IProduct
    {
        public IEnumerable<IProduct> GetComposition();
    }
}
