namespace HasConversion.Models
{
    public readonly struct Dollars
    {
        public Dollars(decimal amount) => Amount = amount;
        public decimal Amount { get; }
        public override string ToString() => Amount.ToString("C");

    }
}