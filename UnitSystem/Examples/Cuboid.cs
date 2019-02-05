using System;

namespace UnitSystem.Examples
{
    public class Cuboid : Shape3D
    {
        public Length A { get; }
        public Length B { get; }
        public Length C { get; }

        public Length Diagonal => new Length(Math.Sqrt(Math.Pow(A.Value, 2) + Math.Pow(B.Value, 2) + Math.Pow(C.Value, 2)));

        public override Volume Volume { get; }

        public Cuboid(double a, double b, double c, Length.Unit unit = Length.Unit.Meter)
        {
            this.A = new Length(a, unit);
            this.B = new Length(b, unit);
            this.C = new Length(c, unit);
            this.Volume = new Volume(A.Value * B.Value * C.Value);
        }

        public Cuboid(Length a, Length b, Length c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            this.Volume = new Volume(A.Value * B.Value * C.Value);
        }

        public Cuboid(Rectangle rectangle, Length height)
        {
            this.A = rectangle.A;
            this.B = rectangle.B;
            this.C = height;
            this.Volume = new Volume(A.Value * B.Value * C.Value);
        }
    }


}
