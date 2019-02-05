namespace UnitSystem
{
    public readonly partial struct Area
    {
        public static Length operator /(Area area, Length length)
        {
            return new Length(area.Value / length.Value);
        }

        public static Volume operator *(Area area, Length length)
        {
            return new Volume(area.Value * length.Value);
        }
    }
}
