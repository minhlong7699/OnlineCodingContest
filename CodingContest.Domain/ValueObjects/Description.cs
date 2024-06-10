using System;

namespace CodingContest.Domain.ValueObjects
{
    public class Description
    {
        public string Value { get; private set; }

        private Description(string value)
        {
            Value = value;
        }

        public static Description Of(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Description cannot be empty", nameof(value));

            return new Description(value);
        }

        public override bool Equals(object obj)
        {
            return obj is Description description && Value.Equals(description.Value, StringComparison.OrdinalIgnoreCase);
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
