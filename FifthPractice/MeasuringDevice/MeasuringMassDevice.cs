using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringDevice
{
    public class MeasuringMassDevice
        : MeasureDataDevice
    {
        public MeasuringMassDevice(Units unitsToUse) : base(unitsToUse)
        {
            MeasurementType = DeviceType.MASS;
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
