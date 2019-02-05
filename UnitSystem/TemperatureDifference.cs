using System;
using System.Runtime.InteropServices;
using static UnitSystem.Temperature;
using static UnitSystem.Temperature.Unit;

namespace UnitSystem
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct TemperatureDifference : IComposedDimension<TemperatureDifference, Unit, Temperature, Unit>,
        IFormattable, IComparable<TemperatureDifference>, IEquatable<TemperatureDifference>
    {
        public double Value { get; }

        public TemperatureDifference(double value, Unit unit = Kelvin)
        {
            if (unit == Fahrenheit) value *= 1.8;
            Value = value;
        }

        #region operators

        public static TemperatureDifference operator +(TemperatureDifference left, TemperatureDifference right)
        {
            return new TemperatureDifference(left.Value + right.Value);
        }

        public static TemperatureDifference operator -(TemperatureDifference diff)
        {
            return new TemperatureDifference(-diff.Value);
        }

        public static TemperatureDifference operator -(TemperatureDifference left, TemperatureDifference right)
        {
            return new TemperatureDifference(left.Value - right.Value);
        }

        public static TemperatureDifference operator *(TemperatureDifference left, double right)
        {
            return new TemperatureDifference(left.Value * right);
        }

        public static TemperatureDifference operator *(double left, TemperatureDifference right)
        {
            return new TemperatureDifference(left * right.Value);
        }

        public static TemperatureDifference operator /(TemperatureDifference left, double right)
        {
            return new TemperatureDifference(left.Value / right);
        }

        public static double operator /(TemperatureDifference left, TemperatureDifference right)
        {
            return left.Value / right.Value;
        }

        public static bool operator ==(TemperatureDifference left, TemperatureDifference right)
        {
            return left.Value == right.Value;
        }

        public static bool operator !=(TemperatureDifference left, TemperatureDifference right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(TemperatureDifference left, TemperatureDifference right)
        {
            return left.Value < right.Value;
        }

        public static bool operator >(TemperatureDifference left, TemperatureDifference right)
        {
            return left.Value > right.Value;
        }

        public static bool operator <=(TemperatureDifference left, TemperatureDifference right)
        {
            return left.Value <= right.Value;
        }

        public static bool operator >=(TemperatureDifference left, TemperatureDifference right)
        {
            return left.Value >= right.Value;
        }

        #endregion

        #region strings

        public static implicit operator TemperatureDifference(string s)
        {
            return new TemperatureDifference(UnitHelper.Parse<TemperatureDifference, Unit>(s));
        }

        public override string ToString()
        {
            return this.ToString(Kelvin);
        }

        public string ToString(string format)
        {
            UnitHelper.VerifyFormat(format);
            return this.Value.ToString(format) + " K";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            UnitHelper.VerifyFormat(format);
            return this.Value.ToString(format, formatProvider) + " m";
        }

        public string ToString(Unit unit = Kelvin, string format = null, IFormatProvider provider = null)
        {
            return UnitHelper.ToString<Unit>(Value, (byte)unit, format, provider);
        }

        #endregion

        #region comparison

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is TemperatureDifference other && Equals(other);
        }

        public bool Equals(TemperatureDifference other)
        {
            return this.Value == other.Value;
        }

        public bool Equals(TemperatureDifference other, double epsilon)
        {
            return Math.Abs(this.Value - other.Value) < epsilon;
        }

        public int CompareTo(TemperatureDifference other)
        {
            return this.Value.CompareTo(other.Value);
        }

        #endregion
    }
}
