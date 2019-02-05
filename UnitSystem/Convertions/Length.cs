using static UnitSystem.Length.Unit;
using static UnitSystem.Time.Unit;

namespace UnitSystem
{
    public readonly partial struct Length
    {
        public static Time operator /(Length length, Velocity velocity)
        {
            return new Time(length.Value / velocity.Value, Second);
        }

        public static Velocity operator /(Length length, Time time)
        {
            return new Velocity(length.Value / time.Value, Meter, Second);
        }

        public static Area operator *(Length length1, Length length2)
        {
            return new Area(length1.Value * length2.Value);
        }

        public static Volume operator *(Length length, Area area)
        {
            return new Volume(length.Value * area.Value);
        }        
    }
}
