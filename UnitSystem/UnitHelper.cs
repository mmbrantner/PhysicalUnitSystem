using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace UnitSystem
{
    public static class UnitHelper
    {
        private static IEnumerable<Type> GetTypesWithInterface(Assembly asm)
        {
            var it = typeof(IBaseDimension);
            return asm.GetTypes().Where(it.IsAssignableFrom).Where(t => !t.IsInterface).ToList();
        }

        static UnitHelper()
        {
            var dimensionToSymbols = new Dictionary<Type, (string[], double)[]>();

            //var type = typeof(IDimension<,>);
            //var dimensions = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(assembly => assembly.GetTypes())
            //    .Where(t => !t.IsInterface && type.IsAssignableFrom(t))
            //    .OrderByDescending(t => typeof(IBaseDimension<,>).IsAssignableFrom(t));

            var dimensions = GetTypesWithInterface(Assembly.GetCallingAssembly());

            foreach (var dimension in dimensions)
            {
                var unitType = dimension.GetNestedType("Unit");
                var enumValues = unitType.GetEnumValues();
                var symbols = new List<(string[], double)>();

                foreach (var value in enumValues)
                {
                    var memberInfo = unitType.GetMember(value.ToString()).First();
                    var attribute = memberInfo.GetCustomAttribute<UnitAttribute>();
                    symbols.Add((attribute.Symbols, attribute.Factor));
                }

                dimensionToSymbols.Add(unitType, symbols.ToArray());
            }
            DimensionToSymbols = dimensionToSymbols.ToImmutableDictionary();
        }       

        internal static string GetSymbol<TUnit>(byte enumValue) where TUnit : Enum
        {
            return DimensionToSymbols[typeof(TUnit)][enumValue].Symbols[0];
        }

        internal static (double, double, double) GetFactors<TUnit1, TUnit2, TUnit3>(byte enumValue1, byte enumValue2, byte enumValue3)
            where TUnit1 : Enum
            where TUnit2 : Enum
            where TUnit3 : Enum
        {
            var value1 = GetFactor<TUnit1>(enumValue1);
            var value2 = GetFactor<TUnit2>(enumValue2);
            var value3 = GetFactor<TUnit3>(enumValue3);
            return (value1, value2, value3);
        }

        internal static int GetUnit<TUnit>(string symbol) where TUnit : Enum
        {
            var arrays = DimensionToSymbols[typeof(TUnit)];
            for (int i = 0; i < arrays.Length; i++)
            {
                if (arrays[i].Symbols.Contains(symbol))
                {
                    return i;
                }
            }
            throw new ArgumentException("couldn't parse symbol");
        }

        internal static (double, double, double, double) GetFactors<TUnit1, TUnit2, TUnit3, TUnit4>
            (byte enumValue1, byte enumValue2, byte enumValue3, byte enumValue4)
            where TUnit1 : Enum where TUnit2 : Enum
            where TUnit3 : Enum where TUnit4 : Enum
        {
            var value1 = GetFactor<TUnit1>(enumValue1);
            var value2 = GetFactor<TUnit2>(enumValue2);
            var value3 = GetFactor<TUnit3>(enumValue3);
            var value4 = GetFactor<TUnit4>(enumValue4);
            return (value1, value2, value3, value4);
        }

        public static readonly ImmutableDictionary<Type, ImmutableDictionary<string, double>> pairs;
        public static readonly ImmutableDictionary<Type, (string[] Symbols, double Factor)[]> DimensionToSymbols;

        internal static string ToString<TUnit>(double value, byte enumValue, string format, IFormatProvider provider)
            where TUnit : Enum
        {
            var factor = GetFactor<TUnit>(enumValue);
            var symbol = GetSymbol<TUnit>(enumValue);
            VerifyFormat(format);
            return (value / factor).ToString(format, provider) + " " + symbol;
        }

        public static readonly ImmutableDictionary<Type, double[]> factors;

        public static double GetFactor<TUnit>(byte enumValue) where TUnit : Enum
        {
            return DimensionToSymbols[typeof(TUnit)][enumValue].Factor;
        }

        /// <summary>
        /// Excludes formats for currency and percentage (C and P)
        /// </summary>
        /// <param name="format"></param>
        internal static void VerifyFormat(string format)
        {
            if (format != null && format.Length > 0 
                && (format[0] == 'C' || format[0] == 'P'))
                throw new FormatException(nameof(format));
        }

        //old one
        //public static TDim Parse<TDim, TUnit>(string input) where TDim : struct, IBaseDimension<TDim, TUnit> where TUnit : Enum
        //{
        //    if (input == null) throw new ArgumentNullException(nameof(input));
        //    if (input.Length == 0) throw new ArgumentException(nameof(input));

        //    var value = 0.0;
        //    var span = input.AsSpan();
        //    var i = 1;
        //    while (double.TryParse(span.Slice(0, i), out var result))
        //    {
        //        value = result;
        //        if (input.Length == i)
        //        {
        //            return (TDim)Activator.CreateInstance(typeof(TDim), value);
        //        }
        //        i++;
        //    }

        //    if (span[i] == ' ') i++;
        //    var symbol = span.Slice(i - 1).ToString();
        //    foreach (var (symbols, factor) in DimensionToSymbols[typeof(TUnit)])
        //    {
        //        if (symbols.Contains(symbol))
        //        {
        //            return (TDim)Activator.CreateInstance(typeof(TDim), value * factor);
        //        }
        //    }

        //    throw new ArgumentException("couldn't parse unit");
        //}

        internal static double Parse<TDim, TUnit>(string input) where TDim : struct, IDimension<TDim, TUnit> where TUnit : Enum
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (input.Length == 0) throw new ArgumentException(nameof(input));

            var span = input.AsSpan();
            var i = 0;
            while (i < input.Length && (input[i] == '.' || char.IsDigit(input[i])))
            {                
                i++;
            }
            var value = double.Parse(span.Slice(0, i));
            if (span[i] == ' ') i++;
            var symbol = span.Slice(i).ToString();
            foreach (var (symbols, factor) in DimensionToSymbols[typeof(TUnit)])
            {
                if (symbols.Contains(symbol))
                {
                    return value * factor; // (TDim)Activator.CreateInstance(typeof(TDim), );
                }
            }

            throw new ArgumentException("couldn't parse unit");
        }


    }
}
