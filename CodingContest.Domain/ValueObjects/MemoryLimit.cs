using System;

namespace CodingContest.Domain.ValueObjects
{
    public class MemoryLimit
    {
        public int Value { get; private set; }

        private MemoryLimit(int value)
        {
            Value = value;
        }

        public static MemoryLimit Of(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Memory limit must be greater than zero", nameof(value));

            return new MemoryLimit(value);
        }

        public override bool Equals(object obj)
        {
            return obj is MemoryLimit limit && Value == limit.Value;
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
