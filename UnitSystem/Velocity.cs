using System;
using System.Runtime.InteropServices;
using static UnitSystem.Length.Unit;
using static UnitSystem.Time.Unit;
using static UnitSystem.Velocity.Unit;

namespace UnitSystem
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Velocity : IComposedDimension<Velocity, Velocity.Unit, Length, Length.Unit, Time, Time.Unit>, IFormattable, IComparable<Velocity>, IEquatable<Velocity>
    {
        public double Value { get; }

        public enum Unit : short
        {
            [Unit("meter/second", "m/s")] MeterPerSecond = 0
        }

        private Velocity(double value)
        {
            Value = value;
        }

        public Velocity(double value, Length.Unit lUnit = Meter, Time.Unit tUnit = Second)
        {
            var lFactor = UnitHelper.GetFactor<Length.Unit>((byte)lUnit);
            var tFactor = UnitHelper.GetFactor<Time.Unit>((byte)tUnit);
            Value = value * lFactor / tFactor;
        }

        public Velocity(double value, Unit unit = MeterPerSecond)
        {
            Value = value * UnitHelper.GetFactor<Unit>((byte)unit);
        }

        #region operators

        public static Velocity operator +(Velocity left, Velocity right)
        {
            return new Velocity(left.Value + right.Value);
        }

        public static Velocity operator -(Velocity length)
        {
            return new Velocity(-length.Value);
        }

        public static Velocity operator -(Velocity left, Velocity right)
        {
            return new Velocity(left.Value - right.Value);
        }

        public static Velocity operator *(Velocity left, double right)
        {
            return new Velocity(left.Value * right);
        }

        public static Velocity operator *(double left, Velocity right)
        {
            return new Velocity(left * right.Value);
        }

        public static Velocity operator /(Velocity left, double right)
        {
            return new Velocity(left.Value / right);
        }

        public static double operator /(Velocity left, Velocity right)
        {
            return left.Value / right.Value;
        }

        public static bool operator ==(Velocity left, Velocity right)
        {
            return left.Value == right.Value;
        }

        public static bool operator !=(Velocity left, Velocity right)
        {
            return left.Value != right.Value;
        }

        public static bool operator <(Velocity left, Velocity right)
        {
            return left.Value < right.Value;
        }

        public static bool operator >(Velocity left, Velocity right)
        {
            return left.Value > right.Value;
        }

        public static bool operator <=(Velocity left, Velocity right)
        {
            return left.Value <= right.Value;
        }

        public static bool operator >=(Velocity left, Velocity right)
        {
            return left.Value >= right.Value;
        }

        #endregion

        #region strings

        public static implicit operator Velocity(string s)
        {
            return new Velocity(UnitHelper.Parse<Velocity, Unit>(s));
        }

        public override string ToString()
        {
            return this.Value.ToString() + " m/s";
        }

        public string ToString(string format)
        {
            UnitHelper.VerifyFormat(format);
            return this.Value.ToString(format) + " m/s";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            UnitHelper.VerifyFormat(format);
            return this.Value.ToString(format, formatProvider) + " m/s";
        }

        public string ToString(Unit unit, string format = null, IFormatProvider provider = null)
        {
            return UnitHelper.ToString<Unit>(Value, (byte)unit, format, provider);
        }

        public string ToString(Length.Unit unit1, Time.Unit unit2, string format, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region comparison

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Velocity other && Equals(other);
        }

        public bool Equals(Velocity other)
        {
            return this.Value == other.Value;
        }

        public bool Equals(Velocity other, double epsilon)
        {
            return Math.Abs(this.Value - other.Value) < epsilon;
        }

        public int CompareTo(Velocity other)
        {
            return this.Value.CompareTo(other.Value);
        }

        #endregion
    }
}
