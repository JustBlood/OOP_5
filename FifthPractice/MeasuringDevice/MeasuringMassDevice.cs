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

        public void StartMeasurements()
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
