using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.Events
{
    public class ItemChangeDescriptionEvent:Event
    {
        public string Description;

        public ItemChangeDescriptionEvent(Guid id,string description)
        {
            AggregateId = id;
            Description = description;
        }
    }
}
