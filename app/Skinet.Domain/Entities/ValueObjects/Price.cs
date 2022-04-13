namespace Core.Entities.ValueObjects
{
    public class Price : SingleValueObject<decimal>
    {
        public Price(decimal value) : base(value)
        {
        }

        protected Price() : base(default!)
        {
        }
    }
}