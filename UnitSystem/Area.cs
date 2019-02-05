using System;
using static UnitSystem.Length.Unit;
using static UnitSystem.Area.Unit;

namespace UnitSystem
{
    public readonly partial struct Area : IComposedDimension<Area, Area.Unit, Length, Length.Unit>, IEquatable<Area>
    {
        public double Value { get; }

        public enum Unit : short
        {
            //metric
            [Unit("square meter", 1, "m²", "m^2")] SquareMeter = Meter << 4 | Meter,
            [Unit("square kilometer", 10_00000, "km²", "km^2")] SquareKilometer = Kilometer << 4 | Kilometer,
            [Unit("square decimeter", 0.01, "dm²", "dm^2")] SquareDecimeter = Decimeter << 4 | Decimeter,
            [Unit("square centimeter", 0.0001, "cm²", "cm^2")] SquareCentimeter = Centimeter << 4 | Centimeter,
            [Unit("square millimeter", 0.00000_1, "mm²", "mm^2")] SquareMillimeter = Millimeter << 4 | Millimeter,
            [Unit("square micrometer", 0.00000_00000_01, "µm²", "µm^2")] SquareMicrometer = Micrometer << 4 | Micrometer,
            [Unit("square nanometer", 0.00000_00000_00000_001, "nm²", "nm^2")] SquareNanometer = Nanometer << 4 | Nanometer,

            // imperial
            [Unit("square foot", 0.09290_304, "ft²", "ft.²", "ft^2", "ft.^2")] SquareFoot = Foot << 4 | Foot,
            [Unit("square inch", 0.00064_516, "in²", "in.²", "in^2", "in.^2")] SquareInch = Inch << 4 | Inch,
            [Unit("square yard", 0.83612_736, "yd²", "yd.²", "yd^2", "yd.^2")] SquareYard = Yard << 4 | Yard,
            [Unit("square mile", 25_89988.11033_6, "mi²", "mi.²", "mi^2", "mi.^2")] SquareMile = Mile << 4 | Mile,
        }

        private Area(double value)
        {
            this.Value = value;
        }

        public Area(double value, Unit unit = SquareMeter)
        {
            Value = value * UnitHelper.GetFactor<Unit>((byte)unit);
        }

        #region operators

        public static Area operator +(Area area1, Area area2)
        {
            return new Area(area1.Value + area2.Value);
        }

        public static Area operator -(Area area)
        {
            return new Area(-area.Value);
        }

        public static Area operator -(Area area1, Area area2)
        {
            return new Area(area1.Value - area2.Value);
        }

        public static Area operator *(Area area, double factor)
        {
            return new Area(area.Value * factor);
        }

        public static Area operator *(double factor, Area area)
        {
            return new Area(area.Value * factor);
        }

        public static Area operator /(Area divident, double divisor)
        {
            return new Area(divident.Value / divisor);
        }

        public static double operator /(Area divident, Area divisor)
        {
            return divident.Value / divisor.Value;
        }

        public static bool operator ==(Area area1, Area area2)
        {
            return area1.Value == area2.Value;
        }

        public static bool operator !=(Area area1, Area area2)
        {
            return area1.Value != area2.Value;
        }

        public static bool operator <(Area left, Area right)
        {
            return left.Value < right.Value;
        }

        public static bool operator >(Area left, Area right)
        {
            return left.Value > right.Value;
        }

        public static bool operator <=(Area left, Area right)
        {
            return left.Value <= right.Value;
        }

        public static bool operator >=(Area left, Area right)
        {
            return left.Value >= right.Value;
        }

        #endregion

        #region strings

        public static implicit operator Area(string input)
        {
            return new Area(UnitHelper.Parse<Area, Unit>(input));
        }

        public override string ToString()
        {
            return this.Value.ToString() + " m²";
        }

        public string ToString(Unit unit = SquareMeter, string format = null, IFormatProvider provider = null)
        {
            return UnitHelper.ToString<Unit>(Value, (byte)unit, format, provider);
        }

        #endregion

        #region constructors

        public static Area FromCircle(Length radius)
        {
            return new Area(radius.Value * radius.Value * Math.PI);
        }

        public static Area FromEllipsis(Length axis1, Length axis2)
        {
            return new Area(axis1.Value * axis2.Value * Math.PI);
        }

        public static Area FromSquare(Length edge)
        {
            return new Area(edge.Value * edge.Value);
        }

        public static Area FromRectangle(Length edge1, Length edge2)
        {
            return new Area(edge1.Value * edge2.Value);
        }

        public static Area FromParallelogram(Length edge1, Length edge2, Angle angle)
        {
            return new Area(edge1.Value * edge2.Value * angle.Sin);
        }

        public static Area FromTriangle(Length edge1, Length edge2, Angle angle)
        {
            return new Area(edge1.Value * angle.Sin * edge2.Value * 0.5);
        }

        public static Area FromTriangle(Length edge1, Length edge2, Length edge3)
        {
            var perimeter = (edge1.Value + edge2.Value + edge3.Value) * 0.5;

            return new Area(Math.Sqrt(perimeter * (perimeter - edge1.Value)
                * (perimeter - edge2.Value) * (perimeter - edge3.Value)));
        }

        public static Area FromCircularSector(Length radius, Angle angle)
        {
            return new Area(radius.Value * radius.Value * angle.Value);
        }

        #endregion

        #region comparison

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Area other && Equals(other);
        }

        public bool Equals(Area other)
        {
            return this.Value.Equals(other.Value);
        }

        public bool Equals(Area other, double epsilon)
        {
            return Math.Abs(this.Value - other.Value) < epsilon;
        }

        #endregion
    }
}
