using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThis.Bll
{
    public interface IUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public byte? Age { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public void RenameMe(string newName);
        public void ResetPassword(string newPassword);
        public IEnumerable<IDiet> GetDiets();
    }
}