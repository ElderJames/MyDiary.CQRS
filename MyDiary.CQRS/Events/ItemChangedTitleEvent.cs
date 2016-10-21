using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.Events
{
    public class ItemChangedTitleEvent:Event
    {
        public string Title { get; set; }

        public ItemChangedTitleEvent(Guid aggregateId,string title)
        {
            AggregateId = aggregateId;
            Title = title;
        }
    }
}
