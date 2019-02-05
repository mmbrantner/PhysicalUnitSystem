using System;

namespace UnitSystem
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class CurrencyAttribute : Attribute
    {
        public string Name { get; }
        public string[] Symbols { get; }
        public decimal Factor { get; } = 1;

        public CurrencyAttribute(string name, decimal factor = 1m, params string[] symbols)
        {
            Name = name;            
            Symbols = symbols;
            Factor = factor;
        }
    }
}