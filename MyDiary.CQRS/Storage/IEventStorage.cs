using MyDiary.CQRS.Domain;
using MyDiary.CQRS.Events;
using MyDiary.CQRS.Domain.Mementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.Storage
{
    public interface IEventStorage
    {
        IEnumerable<Event> GetEvents(Guid aggregateId);

        void Save(AggregateRoot aggregate);

        T GetMemento<T>(Guid aggregateId) where T : BaseMemento;

        void SaveMemento(BaseMemento memento);
    }
}
