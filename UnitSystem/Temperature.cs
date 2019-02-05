using System;
using System.Runtime.InteropServices;
using static UnitSystem.Temperature.Unit;

namespace UnitSystem
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Temperature : IBaseDimension<Temperature, Temperature.Unit>, IFormattable, IComparable<Temperature>, IEquatable<Temperature>
    {
        public double Value { get; }

        public enum Unit
        {
            [Unit("Kelvin", "K")] Kelvin = 0,
            [Unit("Celsius", 1, "°C")] Celsius,
            [Unit("Fahrenheit", 0.27, "°F")] Fahrenheit
        }

        private static double FahrenheitToKelvin(double temp)
        {
            return temp * 0.5555555555555555 + 255.372222222222222222;
            //  ( °F − 32) × 5 / 9 + 273,15 = K
        }

        private static double KelvinToFahrenheit(double temp)
        {
            return temp * 1.8000 - 533.67;
        }

        private static double CelsiusToKelvin(double temp)
        {
            return temp + 273.15;
        }

        private static double KelvinToCelsius(double temp)
        {
            return temp - 273.15;
        }

        private static double CelsiusToFahrenheit(double temp)
        {
            return (temp * 1.8) + 32;
        }

        private static double FahrenheitToCelsius(double temp)
        {
            return (temp - 32) * 0.555555555555;

        }

        private Temperature(double value)
        {
            Value = value;
        }

        public Temperature(double value, Unit unit = Kelvin)
        {
            switch (unit)
            {
                case Celsius:
                    value = CelsiusToKelvin(value);
                    break;
                case Fahrenheit:
                    value = FahrenheitToKelvin(value);
                    break;
                default:
                    break;
            }
            if (value < 0) throw new ArgumentOutOfRangeException("Temperature can't be under 0K.");
            Value = value;
        }

        #region operators 

        public static Temperature operator +(Temperature left, TemperatureDifference right)
        {
            return new Temperature(left.Value + right.Value);
        }

        public static Temperature operator +(TemperatureDifference left, Temperature right)
        {
            return new Temperature(left.Value + right.Value);
        }

        public static Temperature operator -(Temperature left, TemperatureDifference right)
        {
            return new Temperature(left.Value - right.Value);
        }

        public static TemperatureDifference operator -(Temperature left, Temperature right)
        {
            return new TemperatureDifference(left.Value - right.Value);
        }       

        public static bool operator ==(Temperature left, Temperature right)
        {
            return left.Value == right.Value;
        }

        public static bool operator !=(Temperature left, Temperature right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Temperature left, Temperature right)
        {
            return left.Value < right.Value;
        }

        public static bool operator >(Temperature left, Temperature right)
        {
            return left.Value > right.Value;
        }

        public static bool operator <=(Temperature left, Temperature right)
        {
            return left.Value <= right.Value;
        }

        public static bool operator >=(Temperature left, Temperature right)
        {
            return left.Value >= right.Value;
        }

        #endregion

        #region strings

        public static implicit operator Temperature(string s)
        {
            return new Temperature(UnitHelper.Parse<Temperature, Unit>(s));
        }

        public override string ToString()
        {
            return this.Value.ToString() + " K";
        }

        public string ToString(string format)
        {
            UnitHelper.VerifyFormat(format);
            return this.Value.ToString(format) + " K";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            UnitHelper.VerifyFormat(format);
            return this.Value.ToString(format, formatProvider) + " K";
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
            return obj is Temperature other && Equals(other);
        }

        public bool Equals(Temperature other)
        {
            return this.Value == other.Value;
        }

        public bool Equals(Temperature other, double epsilon)
        {
            return Math.Abs(this.Value - other.Value) < epsilon;
        }

        public int CompareTo(Temperature other)
        {
            return this.Value.CompareTo(other.Value);
        }

        #endregion
    }
}
