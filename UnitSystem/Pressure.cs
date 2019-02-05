using System;
using static UnitSystem.Force.Unit;
using static UnitSystem.Area.Unit;
using static UnitSystem.Pressure.Unit;

namespace UnitSystem
{
    public readonly partial struct Pressure : IComposedDimension<Pressure, Pressure.Unit, Mass, Mass.Unit, Length, Length.Unit, Time, Time.Unit>, IEquatable<Pressure>
    {
        public double Value { get; }

        public enum Unit : short
        {
            //metric
            [Unit("pascal", "Pa")] Pascal = Newton << 8 | SquareMeter,            
        }

        private Pressure(double value)
        {
            this.Value = value;
        }

        public Pressure(double value, Unit unit = Pascal)
        {
            Value = value * UnitHelper.GetFactor<Unit>((byte)unit);
        }

        #region operators

        public static Pressure operator +(Pressure pressure1, Pressure pressure2)
        {
            return new Pressure(pressure1.Value + pressure2.Value);
        }

        public static Pressure operator -(Pressure pressure)
        {
            return new Pressure(-pressure.Value);
        }

        public static Pressure operator -(Pressure pressure1, Pressure pressure2)
        {
            return new Pressure(pressure1.Value - pressure2.Value);
        }

        public static Pressure operator *(Pressure pressure, double factor)
        {
            return new Pressure(pressure.Value * factor);
        }

        public static Pressure operator *(double factor, Pressure pressure)
        {
            return new Pressure(pressure.Value * factor);
        }

        public static Pressure operator /(Pressure divident, double divisor)
        {
            return new Pressure(divident.Value / divisor);
        }

        public static double operator /(Pressure divident, Pressure divisor)
        {
            return divident.Value / divisor.Value;
        }

        public static bool operator ==(Pressure pressure1, Pressure pressure2)
        {
            return pressure1.Value == pressure2.Value;
        }

        public static bool operator !=(Pressure pressure1, Pressure pressure2)
        {
            return pressure1.Value != pressure2.Value;
        }

        #endregion

        #region strings

        public static implicit operator Pressure(string input)
        {
            return new Pressure(UnitHelper.Parse<Pressure, Unit>(input));
        }

        public override string ToString()
        {
            return this.Value.ToString() + " Pa";
        }

        public string ToString(Unit unit = Pascal, string format = null, IFormatProvider provider = null)
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
            return obj is Pressure other && Equals(other);
        }

        public bool Equals(Pressure other)
        {
            return this.Value.Equals(other.Value);
        }

        public bool Equals(Pressure other, double epsilon)
        {
            return Math.Abs(this.Value - other.Value) < epsilon;
        }

        #endregion
    }
}
