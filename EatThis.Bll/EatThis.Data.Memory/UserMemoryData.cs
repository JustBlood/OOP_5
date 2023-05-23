using EatThis.Bll;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThis.Data.Memory
{
    public class UserMemoryData : IData<IUser>
    {
        private readonly List<IUser> _users;
        public UserMemoryData()
        {
            _users = new List<IUser>();
        }
        public void Add(IUser item)
        {
            _users.Add(item);
        }

        public IUser GetValue(string name)
        {
            return _users.Find(x => x.Name.Equals(name)) ?? throw new KeyNotFoundException("Пользователь не найден");
        }

        public IEnumerable<IUser> ReadAll()
        {
            return _users.ToList();
        }

        public void Remove(IUser item)
        {
            _users.Remove(item);
        }

        public void Remove(string name)
        {
            _users.RemoveAt(_users.FindIndex(x => x.Name == name));
        }
    }
}
