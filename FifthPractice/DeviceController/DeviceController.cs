

using MeasuringDevice;

namespace Controllers
{
    public class DeviceController : IDisposable
    {
        public MeasureDataDevice Device { get; }

        private DeviceController(MeasureDataDevice device)
        {
            Device = device;
        }

        /// <summary>
        /// A factory method to create a new controller for special device
        /// </summary>
        /// <param name="MeasurementType">Specifies which type of device to start. Must be MASS or LENGTH.</param>
        /// <returns>An instance of the DeviceController class with the controlled device in the started state.</returns>
        public static DeviceController CreateController(MeasureDataDevice device)
        {
            DeviceController controller = new DeviceController(device);
            return controller;
        }

        public static DeviceController CreateController(DeviceType measurementType, Units unitsToUse)
        {
            return new DeviceController(DeviceFactory.CreateMeasureDataDevice(measurementType, unitsToUse));
        }

        /// <summary>
        /// Start the controlled device
        /// </summary>
        public void StartDevice()
        {
            Device.StartCollecting();
        }

        /// <summary>
        /// Stops the controlled device.
        /// </summary>
        public void StopDevice()
        {
            Device.StopCollecting();
        }

        /// <summary>
        /// Forces the controlled device to record a measurement.
        /// </summary>
        /// <returns>The measurement taken by the device.</returns>
        public decimal TakeMeasurement(Units units)
        {
            if (units == Units.Imperial)
            {
                return Device.ImperialValue();
            }
            return Device.MetricValue();
        }

        public decimal TakeMeasurement()
        {
            if (Device.UnitsToUse == Units.Imperial)
            {
                return Device.ImperialValue();
            }
            return Device.MetricValue();
        }

        /// <summary>
        /// Disposes the device.
        /// </summary>
        public void Dispose() { }
    }

}
