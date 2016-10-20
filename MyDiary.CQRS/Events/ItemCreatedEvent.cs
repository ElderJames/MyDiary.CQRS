using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.Events
{
    public class ItemCreatedEvent:Event
    {
        public string Title { get;set;}
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Description { get; set; }

        public ItemCreatedEvent(Guid aggregateId,string title,string description,DateTime from,DateTime to)
        {
            AggregateId = aggregateId;
            Title = title;
            From = from;
            To = to;
            Description = description;
        }
    }
}
