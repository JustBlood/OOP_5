using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeventhPractice
{
    public class ColorChangedArgs : EventArgs
    {
        public TrafficLightState Color { get; set; }
        public ColorChangedArgs(TrafficLightState color)
        {
            Color = color;
        }
    }
    public delegate void ColorChangedEventHandler(object sender, ColorChangedArgs args);
}
