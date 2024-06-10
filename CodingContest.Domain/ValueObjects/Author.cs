using System;

namespace CodingContest.Domain.ValueObjects
{
    public class Author
    {
        public string Value { get; private set; }

        private Author(string value)
        {
            Value = value;
        }

        public static Author Of(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Author cannot be empty", nameof(value));

            return new Author(value);
        }

        public override bool Equals(object obj)
        {
            return obj is Author author && Value.Equals(author.Value, StringComparison.OrdinalIgnoreCase);
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
