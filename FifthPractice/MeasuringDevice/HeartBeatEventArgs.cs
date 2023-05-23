using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringDevice
{
    public class HeartBeatEventArgs : EventArgs
    {
        public DateTime TimeStamp { get; set; }
        public HeartBeatEventArgs()
        {
            TimeStamp = DateTime.Now;
        }
    }

    public delegate void HeartBeatEventHandler(object sender, HeartBeatEventArgs args);
}
