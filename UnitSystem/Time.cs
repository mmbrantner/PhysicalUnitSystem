using System;
using static UnitSystem.Time.Unit;

namespace UnitSystem
{
    public readonly partial struct Time : IBaseDimension<Time, Time.Unit>, IEquatable<Time>
    {
        public double Value { get; }

        public enum Unit : byte
        {
            //metric
            [Unit("second", 1, "s", "sec")] Second = 0,
            [Unit("minute", 60, "m", "min")] Minute,
            [Unit("hour", 3600, "h")] Hour,
            [Unit("day", 86400, "d")] Day,
            [Unit("millisecond", 0.001, "ms")] Millisecond,
            [Unit("microsecond", 0.000001, "µs")] Microsecond,
            [Unit("nanosecond", 0.000000001, "ns")] Nanosecond,
        }

        private Time(double value)
        {
            this.Value = value;
        }

        public Time(double value, Unit unit)
        {
            this.Value = value * UnitHelper.GetFactor<Unit>((byte)unit);
        }

        public Time(TimeSpan value)
        {
            this.Value = value.TotalSeconds;
        }

        #region operators

        public static Time operator +(Time left, Time right)
        {
            return new Time(left.Value + right.Value);
        }

        public static Time operator -(Time time)
        {
            return new Time(-time.Value);
        }

        public static Time operator -(Time left, Time right)
        {
            return new Time(left.Value - right.Value);
        }

        public static bool operator ==(Time left, Time right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Time left, Time right)
        {
            return !left.Equals(right);
        }

        #endregion

        #region strings

        public static implicit operator Time(string input)
        {
            return new Time(UnitHelper.Parse<Time, Unit>(input));
        }

        public override string ToString()
        {
            return this.ToString(Second);
        }

        public string ToString(Unit unit = Second, string format = null, IFormatProvider provider = null)
        {
            return ConvertValue(Value * UnitHelper.GetFactor<Unit>((byte)unit), format, provider);
        }

        private static string ConvertValue(double value, string format = null, IFormatProvider provider = null)
        {
            if (format != null && format.Length > 0 && (format[0] == 'C' || format[0] == 'P'))
            {
                throw new FormatException(nameof(format));
            }

            return value.ToString(format, provider);
        }

        #endregion

        #region comparison

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Time other && Equals(other);
        }

        public bool Equals(Time other)
        {
            return this.Value == other.Value;
        }

        public bool Equals(Time other, double epsilon)
        {
            return Math.Abs(this.Value - other.Value) < epsilon;
        }

        #endregion
    }
}
