using EatThis.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThis.DI
{
    public interface ITag
    {
        public IDiet Diet { get; set; }
        public string Tag { get; set; }
    }
}
