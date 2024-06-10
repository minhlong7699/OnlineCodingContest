using System;
using System.Text.RegularExpressions;

namespace CodingContest.Domain.ValueObjects
{
    public class Email
    {
        private static readonly Regex ValidEmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public string Value { get; private set; }

        private Email(string value)
        {
            Value = value;
        }

        public static Email Of(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be empty", nameof(value));
            if (!ValidEmailRegex.IsMatch(value))
                throw new ArgumentException("Email is not valid", nameof(value));

            return new Email(value);
        }

        public override bool Equals(object obj)
        {
            return obj is Email email && Value.Equals(email.Value, StringComparison.OrdinalIgnoreCase);
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
