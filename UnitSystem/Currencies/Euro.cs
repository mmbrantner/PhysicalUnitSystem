namespace UnitSystem.Currencies
{
    public readonly struct Euro
    {
        public decimal Value { get; }

        public Euro(decimal value)
        {
            Value = value;
        }
    }
}
