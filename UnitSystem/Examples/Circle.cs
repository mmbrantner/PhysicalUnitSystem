namespace UnitSystem.Examples
{
    public class Circle : Shape2D
    {
        Length Radius { get; }

        public override Area Area => Area.FromCircle(this.Radius);

        public Circle(Length radius)
        {
            this.Radius = radius;
        }
    }
}
