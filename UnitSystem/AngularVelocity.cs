using System;
using System.Runtime.InteropServices;
using static UnitSystem.Angle.Unit;
using static UnitSystem.Time.Unit;
using static UnitSystem.AngularVelocity.Unit;

namespace UnitSystem
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct AngularVelocity : IComposedDimension<AngularVelocity, AngularVelocity.Unit, Angle, Angle.Unit, Time, Time.Unit>, IFormattable, IComparable<AngularVelocity>, IEquatable<AngularVelocity>
    {
        public double Value { get; }

        public enum Unit : short
        {
            [Unit("radian/second", "m/s")] RadianrPerSecond = 0
        }

        private AngularVelocity(double value)
        {
            Value = value;
        }

        public AngularVelocity(double value, Angle.Unit lUnit = Radian, Time.Unit tUnit = Second)
        {
            var lFactor = UnitHelper.GetFactor<Angle.Unit>((byte)lUnit);
            var tFactor = UnitHelper.GetFactor<Time.Unit>((byte)tUnit);
            Value = value * lFactor / tFactor;
        }

        public AngularVelocity(double value, Unit unit = RadianrPerSecond)
        {
            Value = value * UnitHelper.GetFactor<Unit>((byte)unit);
        }

        #region operators

        public static AngularVelocity operator +(AngularVelocity left, AngularVelocity right)
        {
            return new AngularVelocity(left.Value + right.Value);
        }

        public static AngularVelocity operator -(AngularVelocity length)
        {
            return new AngularVelocity(-length.Value);
        }

        public static AngularVelocity operator -(AngularVelocity left, AngularVelocity right)
        {
            return new AngularVelocity(left.Value - right.Value);
        }

        public static AngularVelocity operator *(AngularVelocity left, double right)
        {
            return new AngularVelocity(left.Value * right);
        }

        public static AngularVelocity operator *(double left, AngularVelocity right)
        {
            return new AngularVelocity(left * right.Value);
        }

        public static AngularVelocity operator /(AngularVelocity left, double right)
        {
            return new AngularVelocity(left.Value / right);
        }

        public static double operator /(AngularVelocity left, AngularVelocity right)
        {
            return left.Value / right.Value;
        }

        public static bool operator ==(AngularVelocity left, AngularVelocity right)
        {
            return left.Value == right.Value;
        }

        public static bool operator !=(AngularVelocity left, AngularVelocity right)
        {
            return left.Value != right.Value;
        }

        public static bool operator <(AngularVelocity left, AngularVelocity right)
        {
            return left.Value < right.Value;
        }

        public static bool operator >(AngularVelocity left, AngularVelocity right)
        {
            return left.Value > right.Value;
        }

        public static bool operator <=(AngularVelocity left, AngularVelocity right)
        {
            return left.Value <= right.Value;
        }

        public static bool operator >=(AngularVelocity left, AngularVelocity right)
        {
            return left.Value >= right.Value;
        }

        #endregion

        #region strings

        public static implicit operator AngularVelocity(string s)
        {
            return new AngularVelocity(UnitHelper.Parse<AngularVelocity, Unit>(s));
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

        public string ToString(Angle.Unit unit1, Time.Unit unit2, string format, IFormatProvider provider)
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
            return obj is AngularVelocity other && Equals(other);
        }

        public bool Equals(AngularVelocity other)
        {
            return this.Value == other.Value;
        }

        public bool Equals(AngularVelocity other, double epsilon)
        {
            return Math.Abs(this.Value - other.Value) < epsilon;
        }

        public int CompareTo(AngularVelocity other)
        {
            return this.Value.CompareTo(other.Value);
        }

        #endregion
    }
}
