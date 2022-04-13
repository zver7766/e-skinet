namespace Core.Entities.ValueObjects
{
    public class Email : SingleValueObject<string>
    {
        public Email(string value) : base(value)
        {
        }

        protected Email() : base(default!)
        {
        }
        
    }
}