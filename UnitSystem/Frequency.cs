using System;

namespace UnitSystem
{
    public readonly partial struct Frequency : IComposedDimension<Frequency, Frequency.Unit, Time, Time.Unit>
    {
        public double Value { get; }

        public enum Unit
        {
            [Unit("hertz", "Hz")] Hertz = 0,
        }

        public Frequency(double value)
        {
            Value = value;
        }

        public string ToString(Unit unit, string format, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
