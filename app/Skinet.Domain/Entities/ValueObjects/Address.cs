using System.Collections.Generic;

namespace Core.Entities.ValueObjects
{
    public class Address : ValueObject
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }
        
        protected Address() { }
        private Address(string firstName, string lastName, string street, string city, string state, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
            yield return Street;
            yield return City;
            yield return State;
            yield return ZipCode;
        }

        public static Result<Address> Create(string firstName, string lastName, string street, string city, string state, string zipCode)
        {


            return Result.Ok(new Address(firstName, lastName, street, city, state, zipCode));
        }
    }
}