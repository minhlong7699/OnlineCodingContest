namespace CodingContest.Domain.ValueObjects
{
    public class Address
    {

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }



        protected Address() { }
        private Address(string firstName, string lastName, string street, string city, string country, string state, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            Country = country;
            State = state;
            ZipCode = zipCode;
        }

        public static Address Of(string firstName, string lastName, string street, string city, string country, string state, string zipCode)
        {

            return new Address(firstName, lastName, street, city, country, state, zipCode);
        }

        protected bool Equals(Address other)
        {
            return Street == other.Street && City == other.City && State == other.State && Country == other.Country && ZipCode == other.ZipCode;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Address)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, City, State, Country, ZipCode);
        }
    }
}
