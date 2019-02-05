using System;

namespace UnitSystem
{
    public interface IDimension<T, TUnit> where T : struct where TUnit : Enum
    {
        double Value { get; }

        string ToString(TUnit unit, string format, IFormatProvider provider);
    }

    /// <summary>
    /// used for Reflection
    /// </summary>
    public interface IBaseDimension
    {
    }

    public interface IBaseDimension<T, TUnit> : IBaseDimension, IDimension<T, TUnit> where T : struct where TUnit : Enum
    {

    }

    public interface IComposedDimension<T, TUnit, TDimension1, TUnit1> : IDimension<T, TUnit>
        where T : struct where TUnit : Enum
        where TDimension1 : struct, IDimension<TDimension1, TUnit1> where TUnit1 : Enum
    {
    }

    public interface IComposedDimension<T, TUnit, TDimension1, TUnit1, TDimension2, TUnit2> : IDimension<T, TUnit>
        where T : struct where TUnit : Enum
        where TDimension1 : struct, IDimension<TDimension1, TUnit1> where TUnit1 : Enum
        where TDimension2 : struct, IDimension<TDimension2, TUnit2> where TUnit2 : Enum
    {
        string ToString(TUnit1 unit1, TUnit2 unit2, string format, IFormatProvider provider);
    }

    public interface IComposedDimension<T, TUnit, TDimension1, TUnit1, TDimension2, TUnit2, TDimension3, TUnit3> : IDimension<T, TUnit>
        where T : struct where TUnit : Enum
        where TDimension1 : struct, IBaseDimension<TDimension1, TUnit1> where TUnit1 : Enum
        where TDimension2 : struct, IBaseDimension<TDimension2, TUnit2> where TUnit2 : Enum
        where TDimension3 : struct, IBaseDimension<TDimension3, TUnit3> where TUnit3 : Enum
    {
        string ToString(TUnit1 unit1, TUnit2 unit2, TUnit3 unit3, string format, IFormatProvider provider);
    }

    public interface IComposedDimension<T, TUnit, TDimension1, TUnit1, TDimension2, TUnit2, TDimension3, TUnit3, TDimension4, TUnit4> : IDimension<T, TUnit>
       where T : struct where TUnit : Enum
       where TDimension1 : struct, IBaseDimension<TDimension1, TUnit1> where TUnit1 : Enum
       where TDimension2 : struct, IBaseDimension<TDimension2, TUnit2> where TUnit2 : Enum
       where TDimension3 : struct, IBaseDimension<TDimension3, TUnit3> where TUnit3 : Enum
       where TDimension4 : struct, IBaseDimension<TDimension4, TUnit4> where TUnit4 : Enum
    {
        string ToString(TUnit1 unit1, TUnit2 unit2, TUnit3 unit3, TUnit4 unit4, string format, IFormatProvider provider);
    }
}
