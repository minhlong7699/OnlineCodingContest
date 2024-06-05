using System;

namespace CodingContest.Domain.ValueObjects
{
    public class Title
    {
        public string Value { get; private set; }

        private Title(string value)
        {
            Value = value;
        }

        public static Title Of(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Title cannot be empty", nameof(value));
            if (value.Length > 100)
                throw new ArgumentException("Title must be less than 100 characters", nameof(value));

            return new Title(value);
        }

        public override bool Equals(object obj)
        {
            return obj is Title title && Value.Equals(title.Value, StringComparison.OrdinalIgnoreCase);
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
