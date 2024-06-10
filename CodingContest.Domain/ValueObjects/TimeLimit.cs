using System;

namespace CodingContest.Domain.ValueObjects
{
    public class TimeLimit
    {
        public int Value { get; private set; }

        private TimeLimit(int value)
        {
            Value = value;
        }

        public static TimeLimit Of(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Time limit must be greater than zero", nameof(value));

            return new TimeLimit(value);
        }

        public override bool Equals(object obj)
        {
            return obj is TimeLimit limit && Value == limit.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
