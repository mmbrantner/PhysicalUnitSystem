using System;
using System.Collections.Generic;

namespace UnitSystem
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class UnitAttribute : Attribute
    {
        public string Name { get; }
        public string[] Symbols { get; }
        public double Factor { get; }

        public UnitAttribute(string name, params string[] symbols)
        {
            Name = name;
            Symbols = symbols;
            Factor = 1;
        }

        public UnitAttribute(string name, double factor, params string[] symbols) 
        {
            Name = name;
            Symbols = symbols;
            Factor = factor;
        }
    }

    internal class DimensionAttribute : Attribute
    {

    }

    internal class BasicDimensionAttribute : DimensionAttribute
    {

    }
}