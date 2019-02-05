using System;
using System.Runtime.InteropServices;
using static UnitSystem.Angle;
using static UnitSystem.Angle.Unit;

namespace UnitSystem
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct AngularDifference : IComposedDimension<AngularDifference, Unit, Angle, Unit>, 
        IEquatable<AngularDifference>, IFormattable, IComparable<AngularDifference>
    {
        public double Value { get; }

        private AngularDifference(double value)
        {
            this.Value = value;
        }

        public AngularDifference(double value, Unit unit = Radian)
        {
            Value = value * UnitHelper.GetFactor<Unit>((byte)unit);
        }

        public Angle ToAngle()
        {
            return new Angle(this.Value);
        }

        #region operators

        public static AngularDifference operator +(AngularDifference angle1, AngularDifference angle2)
        {
            return new AngularDifference(angle1.Value + angle2.Value);
        }

        public static Angle operator +(AngularDifference angle1, Angle angle2)
        {
            return new Angle(angle1.Value + angle2.Value);
        }

        public static Angle operator +(Angle angle1, AngularDifference angle2)
        {
            return new Angle(angle1.Value + angle2.Value);
        }

        public static AngularDifference operator -(AngularDifference angle)
        {
            return new AngularDifference(-angle.Value);
        }

        public static AngularDifference operator -(AngularDifference angle1, AngularDifference angle2)
        {
            return new AngularDifference(angle1.Value - angle2.Value);
        }

        public static AngularDifference operator *(AngularDifference angle, double factor)
        {
            return new AngularDifference(angle.Value * factor);
        }

        public static AngularDifference operator *(double factor, AngularDifference area)
        {
            return new AngularDifference(area.Value * factor);
        }

        public static AngularDifference operator /(AngularDifference divident, double divisor)
        {
            return new AngularDifference(divident.Value / divisor);
        }

        public static bool operator ==(AngularDifference angle1, AngularDifference angle2)
        {
            return angle1.Value == angle2.Value;
        }

        public static bool operator !=(AngularDifference angle1, AngularDifference angle2)
        {
            return angle1.Value != angle2.Value;
        }

        public static explicit operator AngularDifference(double value)
        {
            return new AngularDifference(value);
        }

        public static explicit operator double(AngularDifference angle)
        {
            return angle.Value;
        }

        #endregion

        #region strings

        public static implicit operator AngularDifference(string input)
        {
            return new AngularDifference(UnitHelper.Parse<AngularDifference, Unit>(input));
        }

        public override string ToString()
        {
            return this.ToString(Radian);
        }

        public string ToString(Unit unit = Radian, string format = null, IFormatProvider provider = null)
        {
            var enumValue = (byte)unit;
            var factor = UnitHelper.GetFactor<Unit>(enumValue);
            var symbol = UnitHelper.GetSymbol<Unit>(enumValue);
            return ConvertValue(Value * factor, format, provider) + " " + symbol;
        }

        private static string ConvertValue(double value, string format, IFormatProvider provider)
        {
            if (format != null && format.Length > 0 && (format[0] == 'C' || format[0] == 'P'))
                throw new FormatException(nameof(format));

            return value.ToString(format, provider);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return this.Value.ToString(format, provider);
        }

        #endregion

        #region comparison

        public override bool Equals(object obj)
        {
            return obj is AngularDifference other && Equals(other);
        }

        public bool Equals(object obj, double epsilon)
        {
            return obj is AngularDifference other && Equals(other, epsilon);
        }

        public bool Equals(AngularDifference other)
        {
            return this.Value.Equals(other.Value);
        }

        public bool Equals(AngularDifference other, double epsilon)
        {
            return Math.Abs(this.Value - other.Value) < epsilon;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public int CompareTo(AngularDifference other)
        {
            return this.Value.CompareTo(other.Value);
        }

        #endregion
    }
}
