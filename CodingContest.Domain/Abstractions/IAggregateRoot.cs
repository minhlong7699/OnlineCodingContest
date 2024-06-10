using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingContest.Domain.Abstractions
{
    public interface IAggregateRoot<T> : IEntity<T>, IAggregateRoot
    {
    }

    public interface IAggregateRoot : IEntity
    {
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
        IDomainEvent[] ClearDomainEvents();
    }
}
