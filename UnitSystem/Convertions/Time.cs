namespace UnitSystem
{
    public partial struct Time
    {
        public static Time operator *(Time time, double factor)
        {
            return new Time(time.Value * factor);
        }

        public static Time operator *(double factor, Time time)
        {
            return new Time(time.Value * factor);
        }

        public static Time operator /(Time left, double right)
        {
            return new Time(left.Value / right);
        }

        public static double operator /(Time left, Time right)
        {
            return left.Value / right.Value;
        }

        public static Length operator *(Time time, Velocity velocity)
        {
            return new Length(time.Value * velocity.Value);
        }        
    }
}
