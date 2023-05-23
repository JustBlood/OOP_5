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

        private void StartMeasurements()
        {
            DataCaptured = new List<int>();
            Thread thread = new Thread(() =>
            {
                Random timer = new Random();

                while (IsCollecting)
                {
                    Thread.Sleep(timer.Next(1000, 5000));
                    DataCaptured.Add(timer.Next(0, 100));
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

    }
}
