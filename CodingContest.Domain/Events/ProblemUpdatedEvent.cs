using CodingContest.Domain.Abstractions;
using CodingContest.Domain.Models;

namespace CodingContest.Domain.Events
{
    public record ProblemUpdatedEvent(Problem Problem) : IDomainEvent;
}
