using System;

namespace UnitSystem
{
    public readonly struct ElectricCurrent : IBaseDimension<ElectricCurrent, ElectricCurrent.Unit>, IEquatable<ElectricCurrent>
    {
        public double Value { get; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public bool Equals(ElectricCurrent other)
        {
            throw new NotImplementedException();
        }

        public string ToString(Unit unit, string format, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public enum Unit
        {
            [Unit("ampere", "A")] Ampere = 0,
        }
    }
}
