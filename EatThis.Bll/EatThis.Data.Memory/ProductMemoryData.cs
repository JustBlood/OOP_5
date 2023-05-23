using EatThis.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThis.Data.Memory
{
    public class ProductMemoryData : IData<IProduct>
    {
        List<IProduct> _products;
        public void Add(IProduct item)
        {
            _products.Add(item);
        }

        public IProduct GetValue(string name)
        {
            return _products.Find(x => x.Name.Equals(name)) ?? throw new KeyNotFoundException("Продукт не найден.");
        }

        public IEnumerable<IProduct> ReadAll()
        {
            return _products.ToList();
        }

        public void Remove(IProduct item)
        {
            _products.Remove(item);
        }
    }
}
