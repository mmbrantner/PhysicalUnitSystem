using static UnitSystem.Area.Unit;

namespace UnitSystem
{
    public readonly partial struct Area
    {
        public static readonly Area m2 = new Area(1, SquareMeter);
        public static readonly Area km2 = new Area(1, SquareKilometer);
        public static readonly Area dm2 = new Area(1, SquareDecimeter);
        public static readonly Area cm2 = new Area(1, SquareCentimeter);
        public static readonly Area mm2 = new Area(1, SquareMillimeter);
        public static readonly Area µm2 = new Area(1, SquareMicrometer);
        public static readonly Area nm2 = new Area(1, SquareNanometer);

        public static readonly Area ft = new Area(1, SquareFoot);
        public static readonly Area inch = new Area(1, SquareInch);
        public static readonly Area yd = new Area(1, SquareYard);
        public static readonly Area mi = new Area(1, SquareMile);
    }
}
