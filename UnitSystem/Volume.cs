using System;
using static UnitSystem.Length.Unit;

namespace UnitSystem
{
    public readonly partial struct Volume : IComposedDimension<Volume, Volume.Unit, Length, Length.Unit>
    {
        public double Value { get; }

        public enum Unit : short
        {
            //metric
            [Unit("cubic meter", 1, "m³", "m^3")]
            CubicMeter = Meter << 8 | Meter << 4 | Meter,

            [Unit("cubic kilometer", 10000_00000, "km³", "km^3")]
            CubicKilometer = Kilometer << 8 | Kilometer << 4 | Kilometer,

            [Unit("cubic decimeter", 0.001, "dm³", "dm^3")]
            CubicDecimeter = Decimeter << 8 | Decimeter << 4 | Decimeter,

            [Unit("cubic centimeter", 0.000001, "cm³", "cm^3")]
            CubicCentimeter = Centimeter << 8 | Centimeter << 4 | Centimeter,

            [Unit("cubic millimeter", 0.00000_0001, "mm³", "mm^3")]
            CubicMillimeter = Millimeter << 8 | Millimeter << 4 | Millimeter,

            [Unit("cubic micrometer", 0.00000_00000_00000_001, "µm³", "µm^3")]
            CubicMicrometer = Micrometer << 8 | Micrometer << 4 | Micrometer,

            [Unit("cubic nanometer", 0.00000_00000_00000_00000_00000_01, "nm³", "nm^3")]
            CubicNanometer = Nanometer << 8 | Nanometer << 4 | Nanometer,

            // imperial
            [Unit("cubic foot", 0.02831_68465_92, "ft³", "ft.³", "ft^3", "ft.^3")]
            CubicFoot = Foot << 8 | Foot << 4 | Foot,
            [Unit("cubic inch", 0.00001_63870_64, "in³", "in.³", "in^3", "in.^3")]
            CubicInch = Inch << 8 | Inch << 4 | Inch,
            [Unit("cubic yard", 0.76455_48579_84, "yd³", "yd.³", "yd^3", "yd.^3")]
            CubicYard = Yard << 8 | Yard << 4 | Yard,
            [Unit("cubic mile", 41681_81825.44057_9584, "mi³", "mi.³", "mi^3", "mi.^3")]
            CubicMile = Mile << 8 | Mile << 4 | Mile,

            [Unit("liter", 0.001, "l")]
            Liter = Decimeter << 8 | Decimeter << 4 | Decimeter,
            [Unit("milliliter", 0.000001, "ml")]
            Milliliter = Centimeter << 8 | Centimeter << 4 | Centimeter,
        }

        private Volume(double value)
        {
            Value = value;
        }

        public Volume(double value, Unit unit = Unit.CubicMeter)
        {
            Value = value * UnitHelper.GetFactor<Unit>((byte)unit);
        }

        #region operators

        public static Volume operator +(Volume left, Volume right)
        {
            return new Volume(left.Value + right.Value);
        }

        public static Volume operator -(Volume v)
        {
            return new Volume(-v.Value);
        }

        public static Volume operator -(Volume left, Volume right)
        {
            return new Volume(left.Value - right.Value);
        }

        public static Volume operator *(Volume left, double right)
        {
            return new Volume(left.Value * right);
        }

        public static Volume operator *(double left, Volume right)
        {
            return new Volume(left * right.Value);
        }

        public static Volume operator /(Volume left, double right)
        {
            return new Volume(left.Value / right);
        }

        public static double operator /(Volume left, Volume right)
        {
            return left.Value / right.Value;
        }

        #endregion


        #region constructors       
        // Taken from https://en.wikipedia.org/wiki/Volume#Volume_formulas
        
        public static Volume FromCube(Length edge)
        {
            var value = edge.Value;
            return new Volume(value * value * value);
        }

        public static Volume FromCuboid(Length edgeA, Length edgeB, Length edgeC)
        {
            return new Volume(edgeA.Value * edgeB.Value * edgeC.Value);
        }

        public static Volume FromPrism(Area @base, Length height)
        {
            return new Volume(@base.Value * height.Value);
        }

        public static Volume FromPyramid(Area @base, Length height)
        {
            return new Volume(@base.Value * height.Value / 3);
        }

        public static Volume FromParallelepiped(Length edgeA, Length edgeB, Length edgeC, Angle alpha, Angle beta, Angle gamma)
        {
            var cosAlpha = Math.Cos(alpha.Value);
            var cosBeta = Math.Cos(beta.Value);
            var cosGamma = Math.Cos(gamma.Value);
            var k = 1 + 2 * cosAlpha * cosBeta * cosGamma -
                (cosAlpha * cosAlpha + cosBeta * cosBeta + cosGamma * cosGamma);
            return new Volume(edgeA.Value * edgeB.Value * edgeC.Value * Math.Sqrt(k));
        }

        private const double TetraConst = 0.117851130197758;

        public static Volume FromTetrahedron(Length edge)
        {
            var value = edge.Value;
            return new Volume(TetraConst * value * value * value);
        }

        /// <summary>
        /// PI * 4 / 3
        /// </summary>
        private const double Pi43 = 4.18879020478639;

        public static Volume FromSphere(Length radius)
        {
            var value = radius.Value;
            return new Volume(value * value * value * Pi43);
        }

        public static Volume FromEllipsoid(Length axisA, Length axisB, Length axisC)
        {
            return new Volume(axisA.Value * axisB.Value * axisC.Value * Pi43);
        }

        public static Volume FromCylinder(Length radius, Length height)
        {
            return new Volume(radius.Value * radius.Value * Math.PI * height.Value);
        }

        public static Volume FromCone(Length radius, Length height)
        {
            return new Volume(radius.Value * radius.Value * height.Value * Math.PI / 3);
        }

        /// <summary>
        /// Pi * Pi * 2
        /// </summary>
        private const double PiPi2 = 19.7392088021787;

        public static Volume FromTorus(Length radius, Length girth)
        {
            return new Volume(radius.Value * girth.Value * girth.Value * PiPi2);
        }

        #endregion

        #region strings

        public static implicit operator Volume(string input)
        {
            return new Volume(UnitHelper.Parse<Volume, Unit>(input));
        }



        public override string ToString()
        {
            return this.ToString(Unit.CubicMeter);
        }

        public string ToString(Unit unit = Unit.CubicMeter, string format = null, IFormatProvider provider = null)
        {
            return ConvertValue(Value * UnitHelper.GetFactor<Unit>((byte)unit), format, provider)
                + UnitHelper.GetSymbol<Unit>((byte)unit);
        }

        private static string ConvertValue(double value, string format = null, IFormatProvider provider = null)
        {
            if (format != null && format.Length > 0 && (format[0] == 'C' || format[0] == 'P'))
                throw new FormatException(nameof(format));

            return value.ToString(format, provider);
        }

        #endregion

        #region comparison

        #endregion
    }
}
