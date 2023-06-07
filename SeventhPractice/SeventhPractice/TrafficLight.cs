using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeventhPractice
{
    public class TrafficLight
    {
        public event ColorChangedEventHandler ColorChanged;
        public TrafficLightState CurrentLight { get; set; }
        public int[] Intervals { get; set; }
        private int currentLightIndex;
        private bool isWorking;

        public TrafficLight()
        {
            Intervals = new int[] { 4, 2, 2, 1 };
            CurrentLight = TrafficLightState.Red;
        }

        public async Task Start()
        {
            isWorking = true;
            
            while(isWorking)
            {
                if (currentLightIndex == Intervals.Length)
                {
                    currentLightIndex = 0;
                }
                CurrentLight = Enum.GetValues<TrafficLightState>()[currentLightIndex];
                ColorChanged?.Invoke(this, new ColorChangedArgs(CurrentLight));
                await Task.Delay(Intervals[currentLightIndex++]*1000);
            }

        }

        public void Stop()
        {
            isWorking = false;
        }
    }
}
