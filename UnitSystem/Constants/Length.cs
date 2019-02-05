using System;
using System.Collections.Generic;
using static UnitSystem.Length.Unit;

namespace UnitSystem
{
    public readonly partial struct Length
    {
        public static readonly Length m = new Length(1, Meter);
        public static readonly Length km = new Length(1, Kilometer);
        public static readonly Length dm = new Length(1, Decimeter);
        public static readonly Length cm = new Length(1, Centimeter);
        public static readonly Length mm = new Length(1, Millimeter);
        public static readonly Length µm = new Length(1, Micrometer);
        public static readonly Length nm = new Length(1, Nanometer);

        public static readonly Length ft = new Length(1, Foot);
        public static readonly Length inch = new Length(1, Inch);
        public static readonly Length yd = new Length(1, Yard);
        public static readonly Length mi = new Length(1, Mile);

        private static readonly Dictionary<string, Length> dictionary
            = new Dictionary<string, Length>()
            {
                {nameof(m), m },
                {nameof(km), km },
                {nameof(dm), dm },
                {nameof(cm), cm },
                {nameof(mm), mm },
                {nameof(µm), µm },
                {nameof(nm), nm },
                {nameof(ft), ft },
                {nameof(inch), inch },
                {nameof(yd), yd },
                {nameof(mi), mi },
            };

        public static Length GetLengthBySymbol(string input)
        {
            if (input == null) throw new ArgumentNullException();
            if (dictionary.TryGetValue(input, out var length))
            {
                return length;
            }
            throw new ArgumentException();
        }
    }
}
