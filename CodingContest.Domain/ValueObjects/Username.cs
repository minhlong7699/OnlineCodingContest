using System;

namespace CodingContest.Domain.ValueObjects
{
    public class Username
    {
        public string Value { get; private set; }

        private Username(string value)
        {
            Value = value;
        }

        public static Username Of(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Username cannot be empty", nameof(value));
            if (value.Length < 6)
                throw new ArgumentException("Username must be at least 6 characters long", nameof(value));

            return new Username(value);
        }

        public override bool Equals(object obj)
        {
            return obj is Username username && Value.Equals(username.Value, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value.ToLower());
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
