namespace UnitSystem
{
    public readonly partial struct Volume
    {
        public static Length operator /(Volume volume, Area area)
        {
            return new Length(volume.Value / area.Value);
        }

        public static Area operator /(Volume volume, Length length)
        {
            return new Area(volume.Value / length.Value);
        }
    }
}
