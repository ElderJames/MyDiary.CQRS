using MyDiary.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.Domain
{
    public class DiaryItem : AggregateRoot,
        IHandle<ItemCreatedEvent>
    {

        public string Title { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string Description { get; set; }

        public DiaryItem(Guid id,string title,string description,DateTime from,DateTime to)
        {
            ApplyChange(new ItemCreatedEvent(id, title, description, from, to));
        }

        public void Handle(ItemCreatedEvent e)
        {
            Title = e.Title;
            From = e.From;
            To = e.To;
            Id = e.AggregateId;
            Description = e.Description;
            Version = e.Version;
        }
    }
}
