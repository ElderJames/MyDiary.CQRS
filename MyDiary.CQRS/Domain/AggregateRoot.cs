using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDiary.CQRS.Events;
using MyDiary.CQRS.Utils;

namespace MyDiary.CQRS.Domain
{
    /// <summary>
    /// 聚合根
    /// </summary>
    public abstract class AggregateRoot : IEventProvider
    {
        private readonly List<Event> _changes;

        public Guid Id { get; set; }
        public int Version { get; set; }
        public int EventVersion { get; set; }

        protected AggregateRoot()
        {
            _changes = new List<Event>();
        }

        /// <summary>
        /// 删除所有更新，表示已提交
        /// </summary>
        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        /// <summary>
        /// 获取未提交更新
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Event> GetUncommittedChanges()
        {
            return _changes;
        }

        /// <summary>
        /// 从历史记录中获取版本
        /// </summary>
        /// <param name="history"></param>
        public void LoadsFromHistory(IEnumerable<Event> history)
        {
            foreach (var e in history)
            {
                ApplyChange(e, false);
            }
            EventVersion = Version = history.Last().Version;
        }

        protected void ApplyChange(Event @event)
        {
            ApplyChange(@event, true);
        }

        protected void ApplyChange(Event @event, bool isNew)
        {
            dynamic d = this;
            //执行AggregateRoot的实现中定义的Handle
            d.Handle(Converter.ChangeTo(@event, @event.GetType()));
            if (isNew)
            {
                _changes.Add(@event);
            }
        }
        
    }
}
