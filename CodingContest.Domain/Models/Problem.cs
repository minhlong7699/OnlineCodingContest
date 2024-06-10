using System;
using CodingContest.Domain.Abstractions;
using CodingContest.Domain.Enums;
using CodingContest.Domain.Events;
using CodingContest.Domain.ValueObjects;

namespace CodingContest.Domain.Models
{
    public class Problem : AggregateRoot<Guid>
    {
        public Title Title { get; private set; }
        public Description Description { get; private set; }
        public ProblemDifficulty Difficulty { get; private set; }
        public string? Constraints { get; private set; }
        public string? Hints { get; private set; }
        public Author Author { get; private set; }
        public DateTime LastModifiedDate { get; private set; }
        public TimeLimit TimeLimit { get; private set; }
        public MemoryLimit MemoryLimit { get; private set; }
        public string? Solution { get; private set; }
        public int TotalSubmissions { get; private set; }
        public int AcceptedSubmissions { get; private set; }
        public int TestCaseCount { get; private set; }
        public bool IsAdminCreated { get; private set; }
        public string DescriptionImageUrl { get; private set; }

        private readonly List<TestCase> _testCases = new();
        public IReadOnlyList<TestCase> TestCases => _testCases.AsReadOnly();

        private Problem() { }

        public static Problem Create(Guid id, Title title, Description description, ProblemDifficulty difficulty, string constraints, string hints, Author author, TimeLimit timeLimit, MemoryLimit memoryLimit, string solution, int testCaseCount, bool isAdminCreated, string descriptionImageUrl, string createdBy)
        {
            var problem = new Problem
            {
                Id = id,
                Title = title,
                Description = description,
                Difficulty = difficulty,
                Constraints = constraints,
                Hints = hints,
                Author = author,
                TimeLimit = timeLimit,
                MemoryLimit = memoryLimit,
                Solution = solution,
                TestCaseCount = testCaseCount,
                IsAdminCreated = isAdminCreated,
                DescriptionImageUrl = descriptionImageUrl,
                CreatedBy = createdBy,
                CreatedAt = DateTime.UtcNow,
                LastModifie = DateTime.UtcNow
            };

            problem.AddDomainEvent(new ProblemCreatedEvent(problem));

            return problem;
        }

        public void Update(Title title, Description description, ProblemDifficulty difficulty, string constraints, string hints, Author author, TimeLimit timeLimit, MemoryLimit memoryLimit, string solution, int testCaseCount, string descriptionImageUrl, string updatedBy)
        {
            Title = title;
            Description = description;
            Difficulty = difficulty;
            Constraints = constraints;
            Hints = hints;
            Author = author;
            TimeLimit = timeLimit;
            MemoryLimit = memoryLimit;
            Solution = solution;
            TestCaseCount = testCaseCount;
            DescriptionImageUrl = descriptionImageUrl;
            LastModifieBy = updatedBy;
            LastModifiedDate = DateTime.UtcNow;
            LastModifie = DateTime.UtcNow;

            AddDomainEvent(new ProblemUpdatedEvent(this));
        }

        public void IncrementSubmissions(bool isAccepted)
        {
            TotalSubmissions++;
            if (isAccepted)
            {
                AcceptedSubmissions++;
            }
            LastModifie = DateTime.UtcNow;
        }


        public void AddTestCase(Guid id, string input, string expectedOutput, bool isSample, string description)
        {
            var testCase = TestCase.Create(id, Id, input, expectedOutput, isSample, description);
            _testCases.Add(testCase);
            TestCaseCount = _testCases.Count;
            LastModifie = DateTime.UtcNow;
        }
    }
}
