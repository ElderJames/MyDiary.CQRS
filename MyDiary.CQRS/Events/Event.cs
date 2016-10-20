using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.Events
{
    public class Event : IEvent
    {
        public Guid Id { get; private set; }

        public int Version;

        public Guid AggregateId { get; set; }
    }
}
