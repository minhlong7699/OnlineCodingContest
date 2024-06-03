using System;
using CodingContest.Domain.Abstractions;

namespace CodingContest.Domain.Models
{
    public class TestCase : Entity<Guid>
    {
        public Guid ProblemId { get; private set; }
        public string TestCaseInput { get; private set; }
        public string ExpectedOutput { get; private set; }
        public bool IsSample { get; private set; }
        public string Description { get; private set; }

        private TestCase() { }

        public static TestCase Create(Guid id, Guid problemId, string testCaseInput, string expectedOutput, bool isSample, string description)
        {
            return new TestCase
            {
                Id = id,
                ProblemId = problemId,
                TestCaseInput = testCaseInput,
                ExpectedOutput = expectedOutput,
                IsSample = isSample,
                Description = description,
                CreatedAt = DateTime.UtcNow,
                LastModifie = DateTime.UtcNow
            };
        }

        public void Update(string testCaseInput, string expectedOutput, bool isSample, string description)
        {
            TestCaseInput = testCaseInput;
            ExpectedOutput = expectedOutput;
            IsSample = isSample;
            Description = description;
            LastModifie = DateTime.UtcNow;
        }
    }
}
