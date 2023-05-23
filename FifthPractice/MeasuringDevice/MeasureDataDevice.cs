using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringDevice
{
    public abstract class MeasureDataDevice : IMeasuringDevice
    {
        protected bool IsCollecting { get; set; }
        public Units UnitsToUse { get; }
        protected List<int> DataCaptured { get; set; }
        public int MostRecentMeasure { get { return DataCaptured[DataCaptured.Count - 1]; } }
        public DeviceType MeasurementType { get; protected set; }

        public MeasureDataDevice(Units unitsToUse)
        {
            UnitsToUse = unitsToUse;
        }

        /// <summary>
        /// Converts the raw data collected by the measuring device into a metric value.
        /// </summary>
        /// <returns>The latest measurement from the device converted to metric units.</returns>
        public virtual decimal MetricValue()
        {
            if (DataCaptured == null)
            {
                throw new NullReferenceException("Ещё не собраны данные");
            }
            if (UnitsToUse != Units.Metric)
            {
                return MostRecentMeasure * 0.4536m;
            }
            return MostRecentMeasure;
        }
        /// <summary>
        /// Converts the raw data collected by the measuring device into an imperial value.
        /// </summary>
        ///<returns>The latest measurement from the device converted to imperial units.</returns>
        public virtual decimal ImperialValue()
        {
            if (DataCaptured == null)
            {
                throw new NullReferenceException("Ещё не собраны данные");
            }
            if (UnitsToUse != Units.Imperial)
            {
                return MostRecentMeasure * 2.2046m;
            }
            return MostRecentMeasure;
        }
        /// <summary>
        /// Starts the measuring device.
        /// </summary>
        public abstract void StartCollecting();
        /// <summary>
        /// Stops the measuring device.
        /// </summary>
        public virtual void StopCollecting()
        {
            IsCollecting = false;
        }

        public abstract List<int> GetRawData();
    }
}