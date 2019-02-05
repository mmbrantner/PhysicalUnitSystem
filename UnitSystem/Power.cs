using System;

namespace UnitSystem
{
    public readonly partial struct Power : IComposedDimension<Power, Power.Unit, Mass, Mass.Unit, Length, Length.Unit, Time, Time.Unit>
    {
        public double Value { get; }

        public enum Unit : short
        {
            [Unit("watt", "W")] Watt = 0
        }

        public Power(double value)
        {
            Value = value;
        }

        public string ToString(Unit unit, string format, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
