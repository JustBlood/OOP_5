using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringDevice
{
    public static class DeviceFactory
    {
        public static MeasureDataDevice CreateMeasureDataDevice(DeviceType type, Units unitsToUse)
        {
            switch (type)
            {
                case DeviceType.LENGTH:
                    return new MeasuringLengthDevice(unitsToUse);
                case DeviceType.MASS:
                    return new MeasuringMassDevice(unitsToUse);
            }
            throw new ArgumentException("Неверный тип девайса или измерений");
        }
    }
}
