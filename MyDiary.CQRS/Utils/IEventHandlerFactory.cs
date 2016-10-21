using MyDiary.CQRS.EventHandlers;
using MyDiary.CQRS.Events;
using System.Collections.Generic;

namespace MyDiary.CQRS.Utils
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event;
    }
}
