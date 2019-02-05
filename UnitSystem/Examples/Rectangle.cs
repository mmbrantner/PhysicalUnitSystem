using System;

namespace UnitSystem.Examples
{
    public class Rectangle : Shape2D
    {
        public override Area Area { get; }

        public Length A { get; }
        public Length B { get; }
        public Length Diagonal => new Length(Math.Sqrt(Math.Pow(A.Value, 2) + Math.Pow(B.Value, 2)));

    }


}
