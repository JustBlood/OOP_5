using EatThis.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EatThis.Data.Memory
{
    public class DishMemoryData : IData<IDish>
    {
        List<IDish> _dishes;
        public void Add(IDish item)
        {
            _dishes.Add(item);
        }

        public IEnumerable<IDish> ReadAll()
        {
            return _dishes.ToList();
        }

        public void Remove(IDish item)
        {
            _dishes.Remove(item);
        }

        public IDish GetValue(string name)
        {
            return _dishes.Find(x => x.Name.Equals(name)) ?? throw new KeyNotFoundException("Блюдо не найдено");
        }
    }
}
