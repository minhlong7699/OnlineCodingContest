using System;
using CodingContest.Domain.Abstractions;
using CodingContest.Domain.Events;
using CodingContest.Domain.ValueObjects;

namespace CodingContest.Domain.Models
{
    public class Contest : AggregateRoot<Guid>
    {
        public Title Title { get; private set; }
        public Description Description { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        private Contest() { }

        public static Contest Create(Guid id, Title title, Description description, DateTime startTime, DateTime endTime)
        {
            var contest = new Contest
            {
                Id = id,
                Title = title,
                Description = description,
                StartTime = startTime,
                EndTime = endTime,
                CreatedAt = DateTime.UtcNow,
                LastModifie = DateTime.UtcNow
            };

            contest.AddDomainEvent(new ContestCreatedEvent(contest));

            return contest;
        }

        public void Update(Title title, Description description, DateTime startTime, DateTime endTime)
        {
            Title = title;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            LastModifie = DateTime.UtcNow;

            AddDomainEvent(new ContestUpdatedEvent(this));
        }
    }
}
