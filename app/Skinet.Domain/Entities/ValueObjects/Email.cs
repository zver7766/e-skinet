namespace Core.Entities.ValueObjects
{
    public class Email : SingleValueObject<string>
    {
        private Email(string value) : base(value)
        {
        }

        protected Email() : base(default!)
        {
        }

        public static Result<Email> Create(string email)
        {

            return Result.Ok(new Email(email));
        }
        
    }
}