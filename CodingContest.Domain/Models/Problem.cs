using System;
using CodingContest.Domain.Abstractions;
using CodingContest.Domain.Events;

namespace CodingContest.Domain.Models
{
    public class Problem : AggregateRoot<Guid>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Difficulty { get; private set; }
        public string Constraints { get; private set; }
        public string Hints { get; private set; }
        public string Author { get; private set; }
        public DateTime LastModifiedDate { get; private set; }
        public int TimeLimit { get; private set; }
        public int MemoryLimit { get; private set; }
        public string Solution { get; private set; }
        public int TotalSubmissions { get; private set; }
        public int AcceptedSubmissions { get; private set; }
        public int TestCaseCount { get; private set; }
        public bool IsAdminCreated { get; private set; }
        public string DescriptionImageUrl { get; private set; }

        private Problem() { }

        public static Problem Create(Guid id, string title, string description, string difficulty, string constraints, string hints, string author, int timeLimit, int memoryLimit, string solution, int testCaseCount, bool isAdminCreated, string descriptionImageUrl, string createdBy)
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

        public void Update(string title, string description, string difficulty, string constraints, string hints, string author, int timeLimit, int memoryLimit, string solution, int testCaseCount, string descriptionImageUrl, string updatedBy)
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
    }
}
