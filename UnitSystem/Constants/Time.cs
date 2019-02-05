namespace UnitSystem
{
    public readonly partial struct Time
    {
        public static readonly Time s = new Time(1, Unit.Second);
        public static readonly Time min = new Time(1, Unit.Minute);
        public static readonly Time h = new Time(1, Unit.Hour);
        public static readonly Time d = new Time(1, Unit.Day);
        public static readonly Time ms = new Time(1, Unit.Millisecond);
        public static readonly Time µs = new Time(1, Unit.Microsecond);
        public static readonly Time ns = new Time(1, Unit.Nanosecond);       
    }
}
