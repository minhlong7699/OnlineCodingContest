using System;
using CodingContest.Domain.Abstractions;

namespace CodingContest.Domain.Models
{
    public class ExecutionResult : Entity<Guid>
    {
        public Guid SubmissionId { get; private set; }
        public Guid TestCaseId { get; private set; }
        public string Input { get; private set; }
        public string ExpectedOutput { get; private set; }
        public string Status { get; private set; }

        public Submission Submission { get; private set; }
        public TestCase TestCase { get; private set; }

        private ExecutionResult() { }

        public ExecutionResult(Guid submissionId, Guid testCaseId, string input, string expectedOutput, string status)
        {
            SubmissionId = submissionId;
            TestCaseId = testCaseId;
            Input = input;
            ExpectedOutput = expectedOutput;
            Status = status;
            CreatedAt = DateTime.UtcNow;
            LastModifie = DateTime.UtcNow;
        }

        public void Update(string input, string expectedOutput, string status)
        {
            Input = input;
            ExpectedOutput = expectedOutput;
            Status = status;
            LastModifie = DateTime.UtcNow;
        }
    }
}
