using EatThis.Bll;

namespace EatThis.Data.Memory
{
    public class DietMemoryData : IData<IDiet>
    {
        HashSet<IDiet> _diets;
        public void Add(IDiet item)
        {
            _diets.Add(item);
        }

        public IEnumerable<IDiet> ReadAll()
        {
            return _diets.ToList();
        }

        public void Remove(IDiet item)
        {
            _diets.Remove(item);
        }

        public IDiet GetValue(string name)
        {
            return _diets.First(diet => diet.Name.Equals(name)) ?? throw new KeyNotFoundException("Диеты не существует");
        }
    }
}