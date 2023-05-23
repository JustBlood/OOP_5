using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringDevice
{
    public abstract class MeasureDataDevice : IEventEnabledMeasuringDevice, IDisposable
    {
        private BackgroundWorker dataCollector;
        private StreamWriter loggingFileWriter;
        protected bool IsCollecting { get; set; }
        public Units UnitsToUse { get; }
        protected List<int> DataCaptured { get; set; }
        public int MostRecentMeasure { get { return DataCaptured[DataCaptured.Count - 1]; } }
        public DeviceType MeasurementType { get; protected set; }

        public string LoggingFileName { get; set; }

        public event EventHandler NewMeasurementTaken;
        public MeasureDataDevice(Units unitsToUse)
        {
            UnitsToUse = unitsToUse;
            LoggingFileName = "measurements.log";
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
            if (dataCollector is not null)
            {
                dataCollector.CancelAsync();
            }
            if (loggingFileWriter is not null)
            {
                loggingFileWriter.Close();
            }
        }

        public abstract List<int> GetRawData();

        public string GetLoggingFile()
        {
            return string.Join("\n", File.ReadAllLines(LoggingFileName));
        }

        protected virtual void OnNewMeasurementTaken()
        {
            foreach (var subscriber in NewMeasurementTaken.GetInvocationList())
            {
                if (!subscriber.Equals(this))
                {
                    NewMeasurementTaken.Invoke(this, null);
                }
            }
        }

        protected void StartMeasurements()
        {
            DataCaptured = new List<int>();
            loggingFileWriter = new StreamWriter(LoggingFileName);
            dataCollector = new BackgroundWorker();
            dataCollector.WorkerSupportsCancellation = true;
            dataCollector.WorkerReportsProgress = true;
            dataCollector.DoWork += new DoWorkEventHandler(dataCollector_DoWork);
            dataCollector.ProgressChanged += new ProgressChangedEventHandler(dataCollector_ProgressChanged);
            dataCollector.RunWorkerAsync();
        }

        private void dataCollector_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            OnNewMeasurementTaken();
        }

        private void dataCollector_DoWork(object? sender, DoWorkEventArgs e)
        {
            var timer = new Random();
            while (!dataCollector.CancellationPending)
            {

                System.Threading.Thread.Sleep(timer.Next(1000,5000));
                TakeMeasurements();
                if (!IsCollecting) break;
                if (loggingFileWriter is not null)
                {
                    try
                    {
                        loggingFileWriter.WriteLine($"Measurement - {MostRecentMeasure}");
                    } catch (Exception ex) { }
                    
                }
                dataCollector.ReportProgress(0);
            }
        }

        protected virtual void TakeMeasurements()
        {
            if (IsCollecting)
            {
                if (DataCaptured.Count > 100)
                {
                    DataCaptured.Clear();
                }
                DataCaptured.Add(new Random().Next(0, 100));
            }
        }

        public void Dispose()
        {
            if (dataCollector is not null)
            {
                dataCollector.Dispose();
            }
        }
    }
}