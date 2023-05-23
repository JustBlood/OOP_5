using Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FifthPractice
{
    public class MainViewModel
    {
        public DeviceController Controller { get; set; }
        public List<int> Measurements { get; set; }
    }
}
