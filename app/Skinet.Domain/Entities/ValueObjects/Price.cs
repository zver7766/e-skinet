namespace Core.Entities.ValueObjects
{
    public class Price : SingleValueObject<decimal>
    {
        private Price(decimal value) : base(value)
        {
        }

        protected Price() : base(default!)
        {
        }

        public static Result<Price> Create(decimal price)
        {
            if (price is < 0 or > 100_000_000)
            {
                return Result.Fail<Price>("Price is too high/ cant be below zero");
            }
            
            return Result.Ok(new Price(price));
        }
    }
}