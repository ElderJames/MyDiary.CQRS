using MyDiary.CQRS.Events;

namespace MyDiary.CQRS.EventHandlers
{
    public interface IEventHandler<TEvent> where TEvent : Event
    {
        void Handle(TEvent e);
    }
}
