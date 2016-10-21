using MyDiary.CQRS.Domain;
using MyDiary.CQRS.Events;
using MyDiary.CQRS.Messaging;
using MyDiary.CQRS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using MyDiary.CQRS.Domain.Mementos;
using MyDiary.CQRS.Storage.Memento;

namespace MyDiary.CQRS.Storage
{
    public class InMemoryEventStorage:IEventStorage
    {
        private List<Event> _events;
        private List<BaseMemento> _mementoes;
        private readonly IEventBus _eventBus;

        public InMemoryEventStorage(IEventBus eventBus)
        {
            _events = new List<Event>();
            _eventBus = eventBus;
            _mementoes = new List<BaseMemento>();
        }

        public IEnumerable<Event> GetEvents(Guid aggregateId)
        {
            var events = _events.Where(p => p.AggregateId == aggregateId);
            if (events.Count() == 0)
            {
                throw new Exception();
            }
            return events;
        }

        public void Save(AggregateRoot aggregate)
        {
            var uncommittedChanges = aggregate.GetUncommittedChanges();
            var version = aggregate.Version;

            foreach (var @event in uncommittedChanges)
            {
                //每个更改都增加一个版本
                version++;
                //每三个更改建立一次快照
                if (version > 0 && version % 3 == 0)
                {
                    var originator = (IOriginator)aggregate;
                    var memento = originator.GetMemento();
                    memento.Version = version;
                    //保存
                    SaveMemento(memento);
                }

                @event.Version = version;
                //加入事件更改记录
                _events.Add(@event);
                //转换成不同的事件后执行该事件
                _eventBus.Publish(Converter.ChangeTo(@event, @event.GetType()));
            }
            //处理完后清除该聚合根的所有更改
            //因为命令执行完，聚合根自动释放，不需要再清除里面的更改
            aggregate.MarkChangesAsCommitted();
        }

        public T GetMemento<T>(Guid aggregateId) where T : BaseMemento
        {
            //获取最后一个快照
            var memento = _mementoes.Where(m => m.Id == aggregateId).LastOrDefault();
            if (memento != null)
            {
                return (T)memento;
            }
            return null;
        }

        public void SaveMemento(BaseMemento memento)
        {
            _mementoes.Add(memento);
        }
    }
}
