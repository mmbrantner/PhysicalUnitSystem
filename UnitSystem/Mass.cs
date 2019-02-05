using System;

namespace UnitSystem
{
    public readonly partial struct Mass : IBaseDimension<Mass, Mass.Unit>, IEquatable<Mass>
    {
        public double Value { get; }

        public enum Unit : byte
        {
            [Unit("kilogram", "kg")] Kilogram = 0,
            [Unit("tonne", 1000, "t")] Tonne = 1,
            [Unit("gram", 0.001, "g")] Gram = 2,
            [Unit("milligram", 0.000001, "mg")] Milligram = 3,
            [Unit("microgram", 0.000000001, "µg")] Microgram = 4,
        }

        private Mass(double value)
        {
            Value = value;
        }

        public Mass(double value, Unit unit = Unit.Kilogram)
        {
            Value = value * UnitHelper.GetFactor<Unit>((byte)unit);
        }

        #region operators

        public static Mass operator +(Mass left, Mass right)
        {
            return new Mass(left.Value + right.Value);
        }

        public static Mass operator -(Mass mass)
        {
            return new Mass(-mass.Value);
        }

        public static Mass operator -(Mass left, Mass right)
        {
            return new Mass(left.Value - right.Value);
        }

        public static Mass operator *(Mass mass, double factor)
        {
            return new Mass(mass.Value * factor);
        }

        public static Mass operator *(double factor, Mass mass)
        {
            return new Mass(mass.Value * factor);
        }

        public static Mass operator /(Mass left, double factor)
        {
            return new Mass(left.Value / factor);
        }

        public static double operator /(Mass left, Mass right)
        {
            return left.Value / right.Value;
        }

        public static bool operator ==(Mass left, Mass right)
        {
            return left.Value == right.Value;
        }

        public static bool operator !=(Mass left, Mass right)
        {
            return left.Value != right.Value;
        }

        #endregion

        #region strings

        public static implicit operator Mass(string input)
        {
            return new Mass(UnitHelper.Parse<Mass, Unit>(input));
        }

        public override string ToString()
        {
            return this.ToString(Unit.Kilogram);
        }

        public string ToString(Unit unit = Unit.Kilogram, string format = null, IFormatProvider provider = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region comparison

        public override bool Equals(object obj)
        {
            return obj is Mass other && this.Equals(other);
        }

        public bool Equals(Mass other)
        {
            return this.Value == other.Value;
        }

        public bool Equals(Mass other, double epsilon)
        {
            return Math.Abs(this.Value - other.Value) < epsilon;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        #endregion
    }
}
