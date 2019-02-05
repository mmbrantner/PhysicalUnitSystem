using System;
using System.Runtime.InteropServices;

namespace UnitSystem
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Length : IBaseDimension<Length, Length.Unit>, IFormattable, IComparable<Length>, IEquatable<Length>
    {       
        public double Value { get; }

        public enum Unit : byte
        {
            //metric
            [Unit("meter", 1, "m")] Meter = 0,
            [Unit("kilometer", 1000, "km")] Kilometer = 1,
            [Unit("decimeter", 0.1, "dm")] Decimeter = 2,
            [Unit("centimeter", 0.01, "cm")] Centimeter = 3,
            [Unit("millimeter", 0.001, "mm")] Millimeter = 4,
            [Unit("micrometer", 0.00000_1, "µm")] Micrometer = 5,
            [Unit("nanometer", 0.00000_0001, "nm")] Nanometer = 6,

            // imperial
            [Unit("foot", 0.3048, "ft", "ft.")] Foot = 7,
            [Unit("inch", 0.0254, "in", "in.")] Inch = 8,
            [Unit("yard", 0.9144, "yd", "yd")] Yard = 9,
            [Unit("mile", 1609.344, "mi", "mi.")] Mile = 10,
        }       

        private Length(double value)
        {
            Value = value;
        }

        public Length(double value, Unit unit = Unit.Meter)
        {
            Value = value * UnitHelper.GetFactor<Unit>((byte)unit);
        }

        #region operators

        public static Length operator +(Length left, Length right)
        {
            return new Length(left.Value + right.Value);
        }

        public static Length operator -(Length length)
        {            
            return new Length(-length.Value);
        }

        public static Length operator -(Length left, Length right)
        {          
            return new Length(left.Value - right.Value);
        }

        public static Length operator *(Length left, double right)
        {
            return new Length(left.Value * right);
        }

        public static Length operator *(double left, Length right)
        {
            return new Length(left * right.Value);
        }

        public static Length operator /(Length left, double right)
        {
            return new Length(left.Value / right);
        }

        public static double operator /(Length left, Length right)
        {
            return left.Value / right.Value;
        }

        public static bool operator ==(Length left, Length right)
        {
            return left.Value == right.Value;
        }

        public static bool operator !=(Length left, Length right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Length left, Length right)
        {
            return left.Value < right.Value;
        }

        public static bool operator >(Length left, Length right)
        {
            return left.Value > right.Value;
        }

        public static bool operator <=(Length left, Length right)
        {
            return left.Value <= right.Value;
        }

        public static bool operator >=(Length left, Length right)
        {
            return left.Value >= right.Value;
        }

        #endregion

        #region strings

        public static implicit operator Length(string s)
        {
            return new Length(UnitHelper.Parse<Length, Unit>(s));
        }

        public override string ToString()
        {
            return this.ToString(Unit.Meter);
        }

        public string ToString(string format)
        {
            UnitHelper.VerifyFormat(format);
            return this.Value.ToString(format) + " m";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            UnitHelper.VerifyFormat(format);
            return this.Value.ToString(format, formatProvider) + " m";
        }

        public string ToString(Unit unit = Unit.Meter, string format = null, IFormatProvider provider = null)
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
            return obj is Length other && Equals(other);
        }

        public bool Equals(Length other)
        {
            return this.Value == other.Value;
        }

        public bool Equals(Length other, double epsilon)
        {
            return Math.Abs(this.Value - other.Value) < epsilon;
        }

        public int CompareTo(Length other)
        {
            return this.Value.CompareTo(other.Value);
        }

        #endregion
    }
}
