using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringDevice
{
    internal interface IEventEnabledMeasuringDevice : IMeasuringDevice
    {
        event EventHandler NewMeasurementTaken;
        //Event that fires every heartbeat.
        event HeartBeatEventHandler HeartBeat;
        //Read only heartbeat interval - set in constructor.
        public int HeartBeatInterval { get; set; }

    }
}
