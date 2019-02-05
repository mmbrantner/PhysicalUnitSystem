namespace UnitSystem
{
    public partial struct Frequency
    {
        public static Frequency operator *(Frequency frequency, double factor)
        {
            return new Frequency(frequency.Value * factor);
        }

        public static Frequency operator *(double factor, Frequency frequency)
        {
            return new Frequency(frequency.Value * factor);
        }

        public static Frequency operator /(Frequency frequency, double factor)
        {
            return new Frequency(frequency.Value / factor);
        }

        public static double operator /(Frequency left, Frequency right)
        {
            return left.Value / right.Value;
        }

        public static double operator *(Time time, Frequency frequency)
        {
            return time.Value * frequency.Value;
        }
    }
}
