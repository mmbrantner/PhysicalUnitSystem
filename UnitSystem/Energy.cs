using System;

namespace UnitSystem
{
    public readonly partial struct Energy : IComposedDimension<Energy, Energy.Unit, Mass, Mass.Unit, Length, Length.Unit, Time, Time.Unit>
    {
        public double Value { get; }

        public enum Unit : short
        {
            [Unit("joule", "J")] Joule = 0
        }

        private Energy(double value)
        {
            Value = value;
        }

        public string ToString(Unit unit, string format, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
