using System;
using static UnitSystem.Length.Unit;
using static UnitSystem.Time.Unit;

namespace UnitSystem
{
    //public readonly partial struct Accelaration : IEquatable<Accelaration>,
    //    IComposedDimension<Accelaration, Accelaration.Unit, Length, Length.Unit, Time, Time.Unit>
    //{
    //    public double Value { get; }

    //    public enum Unit : short
    //    {
    //        [Unit("meter per second squared", "m/s²")] MeterPerSecondSquared = 0
    //    }

    //    public Accelaration(double value, Length.Unit lengthUnit = Meter, Time.Unit timeUnit = Second)
    //    {
    //        var factor1 = UnitHelper.GetFactor<Length.Unit>((byte)lengthUnit);
    //        var factor2 = UnitHelper.GetFactor<Time.Unit>((byte)timeUnit);
    //        Value = value * factor1 / (factor2 * factor2);
    //    }

    //    #region operators

    //    public static Accelaration operator +(Accelaration accelaration1, Accelaration accelaration2)
    //    {
    //        return new Accelaration(accelaration1.Value + accelaration2.Value);
    //    }

    //    public static Accelaration operator -(Accelaration accelaration)
    //    {
    //        return new Accelaration(-accelaration.Value);
    //    }

    //    public static Accelaration operator -(Accelaration accelaration1, Accelaration accelaration2)
    //    {
    //        return new Accelaration(accelaration1.Value - accelaration2.Value);
    //    }

    //    public static Accelaration operator *(Accelaration accelaration, double factor)
    //    {
    //        return new Accelaration(accelaration.Value * factor);
    //    }

    //    public static Accelaration operator *(double factor, Accelaration accelaration)
    //    {
    //        return new Accelaration(accelaration.Value * factor);
    //    }

    //    public static Accelaration operator /(Accelaration divident, double divisor)
    //    {
    //        return new Accelaration(divident.Value + divisor);
    //    }

    //    public static double operator /(Accelaration divident, Accelaration divisor)
    //    {
    //        return divident.Value / divisor.Value;
    //    }

    //    public static bool operator ==(Accelaration accelaration1, Accelaration accelaration2)
    //    {
    //        return accelaration1.Value == accelaration2.Value;
    //    }

    //    public static bool operator !=(Accelaration accelaration1, Accelaration accelaration2)
    //    {
    //        return accelaration1.Value != accelaration2.Value;
    //    }

    //    public static implicit operator Accelaration(string input)
    //    {
    //        throw new NotImplementedException();            
    //    }

    //    #endregion

    //    public override string ToString()
    //    {
    //        return this.ToString(Meter, Second);
    //    }

    //    public string ToString(Length.Unit lUnit = Meter, Time.Unit tUnit = Second, string format = null, IFormatProvider provider = null)
    //    {
    //        var factor1 = UnitHelper.GetFactor<Length.Unit>((byte)lUnit);
    //        var factor2 = UnitHelper.GetFactor<Time.Unit>((byte)tUnit);
    //        return ConvertValue(Value * factor1 / (factor2 * factor2), format, provider)
    //            + UnitHelper.GetSymbol<Length.Unit>((byte)lUnit) + "/" 
    //            + UnitHelper.GetSymbol<Time.Unit>((byte)tUnit) + "²";
    //    }

    //    private static string ConvertValue(double value, string format, IFormatProvider provider)
    //    {
    //        if (format != null && format.Length > 0 && (format[0] == 'C' || format[0] == 'P'))
    //            throw new FormatException(nameof(format));

    //        return value.ToString(format, provider);
    //    }        

    //    public Accelaration FromString(string input)
    //    {
    //        return UnitHelper.Parse<Area, Unit>(input);
    //    }

    //    public override bool Equals(object obj)
    //    {
    //        return obj is Area other && Equals(other);
    //    }

    //    public bool Equals(Area other)
    //    {
    //        return this.Value.Equals(other.Value);
    //    }

    //    public bool Equals(Area other, double epsilon)
    //    {
    //        return Math.Abs(this.Value - other.Value) < epsilon;
    //    }

    //    public override int GetHashCode()
    //    {
    //        return Value.GetHashCode();
    //    }
    //}
}
