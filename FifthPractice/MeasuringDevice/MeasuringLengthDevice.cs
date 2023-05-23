using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeasuringDevice
{
    public class MeasuringLengthDevice
        : MeasureDataDevice
    {
        public MeasuringLengthDevice(Units unitsToUse) : base(unitsToUse)
        {
            MeasurementType = DeviceType.LENGTH;
        }

        public override List<int> GetRawData()
        {
            return DataCaptured;
        }

        public override void StartCollecting()
        {
            IsCollecting = true;
            StartMeasurements();
        }
    }
}
