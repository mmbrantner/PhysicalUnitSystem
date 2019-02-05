using System;
using System.Runtime.InteropServices;
using static UnitSystem.Angle;
using static UnitSystem.Angle.Unit;

namespace UnitSystem
{

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Angle : IBaseDimension<Angle, Unit>, IEquatable<Angle>, IFormattable
    {
        public double Value { get; }

        public enum Unit : short
        {
            //metric
            [Unit("radians", 1, "rad")] Radian = 0,            
            [Unit("degree", Math.PI / 180, "deg", "°")] Degree = 1,            
        }

        private Angle(double value)
        {
            value %= 2 * Math.PI;
            if (value > Math.PI)
            {
                value -= Math.PI;
            }
            this.Value = value;
        }

        public Angle(double value, Unit unit = Radian)
        {
            value *= UnitHelper.GetFactor<Unit>((byte)unit);
            value %= 2 * Math.PI;
            if (value > Math.PI)
            {
                value -= Math.PI;
            }
            Value = value;
        }

        public double Sin => Math.Sin(this.Value);
        public double Cos => Math.Cos(this.Value);
        public double Tan => Math.Tan(this.Value);
        public double Sinh => Math.Sinh(this.Value);
        public double Cosh => Math.Cosh(this.Value);
        public double Tanh => Math.Tanh(this.Value);

        #region operators

        public static Angle operator +(Angle angle1, Angle angle2)
        {
            return new Angle(angle1.Value + angle2.Value);
        }

        public static Angle operator -(Angle angle)
        {
            return new Angle(angle.Value);
        }

        public static AngularDifference operator -(Angle angle1, Angle angle2)
        {
            return new AngularDifference(angle1.Value - angle2.Value);
        }

        public static Angle operator *(Angle angle, int factor)
        {
            return new Angle(angle.Value * factor);
        }

        public static Angle operator *(int factor, Angle area)
        {
            return new Angle(area.Value * factor);
        }

        public static bool operator ==(Angle angle1, Angle angle2)
        {
            return angle1.Value == angle2.Value;
        }

        public static bool operator !=(Angle angle1, Angle angle2)
        {
            return angle1.Value != angle2.Value;
        }       

        public static explicit operator Angle(double value)
        {
            return new Angle(value);
        }

        public static explicit operator double(Angle angle)
        {
            return angle.Value;
        }

        #endregion
        #region strings

        public static implicit operator Angle(string input)
        {
            return new Angle(UnitHelper.Parse<Angle, Unit>(input));
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
            return this.Value.ToString(format, provider) + " rad";
        }

        #endregion
        #region constructors        

        public static Angle FromAsin(Length opposite, Length hypothenuse)
        {
            var sin = opposite.Value / hypothenuse.Value;
            if (sin < -1 || sin > 1) throw new ArgumentOutOfRangeException();
            return new Angle(Math.Asin(sin));
        }

        public static Angle FromAcos(Length adjacent, Length hypothenuse)
        {
            var cos = adjacent.Value / hypothenuse.Value;
            if (cos < -1 || cos > 1) throw new ArgumentOutOfRangeException();
            return new Angle(Math.Acos(cos));
        }

        public static Angle FromAtan(Length adjacent, Length opposite)
        {            
            return new Angle(Math.Atan(opposite.Value/adjacent.Value));
        }

        #endregion
        #region comparison

        public override bool Equals(object obj)
        {
            return obj is Angle other && Equals(other);
        }

        public bool Equals(object obj, double epsilon)
        {
            return obj is Angle other && Equals(other, epsilon);
        }

        public bool Equals(Angle other)
        {
            return this.Value.Equals(other.Value);
        }

        public bool Equals(Angle other, double epsilon)
        {
            return Math.Abs(this.Value - other.Value) < epsilon;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        #endregion
    }
}
