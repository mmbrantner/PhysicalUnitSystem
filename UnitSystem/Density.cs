using System;
using static UnitSystem.Length.Unit;
using static UnitSystem.Mass.Unit;
using static UnitSystem.Density.Unit;

namespace UnitSystem
{
    public readonly partial struct Density : IComposedDimension<Density, Density.Unit, Mass, Mass.Unit, Volume, Volume.Unit>, IEquatable<Density>
    {
        public double Value { get; }

        public enum Unit
        {
            [Unit("kilogram/cubic meter", "kg/m³", "kg/m^3")]
            KilogramPerCubicMeter = Kilogram << 4 | Meter
        }

        private Density(double value)
        {
            this.Value = value;
        }

        public Density(double value, Unit unit = KilogramPerCubicMeter)
        {
            var factor = UnitHelper.GetFactor<Unit>((byte)unit);
            Value = value * factor;
        }

        #region operators

        public static Density operator +(Density density1, Density density2)
        {
            return new Density(density1.Value + density2.Value);
        }

        public static Density operator -(Density density)
        {
            return new Density(-density.Value);
        }

        public static Density operator -(Density density1, Density density2)
        {
            return new Density(density1.Value - density2.Value);
        }

        public static Density operator *(Density density, double factor)
        {
            return new Density(density.Value * factor);
        }

        public static Density operator *(double factor, Density density)
        {
            return new Density(density.Value * factor);
        }

        public static Density operator /(Density divident, double divisor)
        {
            return new Density(divident.Value / divisor);
        }

        public static double operator /(Density divident, Density divisor)
        {
            return divident.Value / divisor.Value;
        }

        public static bool operator ==(Density density1, Density density2)
        {
            return density1.Value == density2.Value;
        }

        public static bool operator !=(Density density1, Density density2)
        {
            return density1.Value != density2.Value;
        }

        public static implicit operator Density(string input)
        {
            return new Density(UnitHelper.Parse<Density, Unit>(input));
        }

        #endregion

        public override string ToString()
        {
            return this.ToString(KilogramPerCubicMeter);
        }

        public string ToString(Unit unit = KilogramPerCubicMeter, string format = null, IFormatProvider provider = null)
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

        public override bool Equals(object obj)
        {
            return obj is Density other && Equals(other);
        }

        public bool Equals(object obj, double epsilon)
        {
            return obj is Density other && Equals(other, epsilon);
        }

        public bool Equals(Density other)
        {
            return this.Value.Equals(other.Value);
        }

        public bool Equals(Density other, double epsilon)
        {
            return Math.Abs(this.Value - other.Value) < epsilon;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
