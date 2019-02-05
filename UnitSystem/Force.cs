using System;
using static UnitSystem.Force.Unit;

namespace UnitSystem
{
    public readonly partial struct Force : IComposedDimension<Force, Force.Unit, Mass, Mass.Unit, Length, Length.Unit, Time, Time.Unit>, IEquatable<Force>
    {
        public double Value { get; }

        public enum Unit : short
        {
            [Unit("newton", "N")] Newton = 0,
            [Unit("millinewton", "mN")] MilliNewton = 1,
            [Unit("kilonewton", "kN")] KiloNewton = 2,
            [Unit("meganewton", "MN")] MegaNewton = 3,
        }

        private Force(double value)
        {
            Value = value;
        }

        public Force(double value, Unit unit = Newton)
        {
            Value = value * UnitHelper.GetFactor<Unit>((byte)unit);
        }

        #region operators

        public static Force operator +(Force force1, Force force2)
        {
            return new Force(force1.Value + force2.Value);
        }

        public static Force operator -(Force force)
        {
            return new Force(-force.Value);
        }

        public static Force operator -(Force force1, Force force2)
        {
            return new Force(force1.Value - force2.Value);
        }

        public static Force operator *(Force force, double factor)
        {
            return new Force(force.Value * factor);
        }

        public static Force operator *(double factor, Force force)
        {
            return new Force(force.Value * factor);
        }

        public static Force operator /(Force divident, double divisor)
        {
            return new Force(divident.Value / divisor);
        }

        public static double operator /(Force divident, Force divisor)
        {
            return divident.Value / divisor.Value;
        }

        public static bool operator ==(Force force1, Force force2)
        {
            return force1.Value == force2.Value;
        }

        public static bool operator !=(Force force1, Force force2)
        {
            return force1.Value != force2.Value;
        }

        #endregion

        #region strings

        public static implicit operator Force(string input)
        {
            return new Force(UnitHelper.Parse<Force, Unit>(input));
        }

        public override string ToString()
        {
            return this.Value.ToString() + " N";
        }

        public string ToString(Unit unit = Newton, string format = null, IFormatProvider provider = null)
        {
            return UnitHelper.ToString<Unit>(Value, (byte)unit, format, provider);
        }

        #endregion

        #region constructors        

        #endregion

        #region comparison

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Force other && Equals(other);
        }

        public bool Equals(Force other)
        {
            return this.Value.Equals(other.Value);
        }

        public bool Equals(Force other, double epsilon)
        {
            return Math.Abs(this.Value - other.Value) < epsilon;
        }

        #endregion
    }
}
