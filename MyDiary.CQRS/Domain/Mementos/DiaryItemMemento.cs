using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.Domain.Mementos
{
    public class DiaryItemMemento:BaseMemento
    {
        public string Title { get; internal set; }
        public string Description { get; internal set; }
        public DateTime From { get; internal set; }
        public DateTime To { get; internal set; }


        public int EventVersion { get; set; }

        public DiaryItemMemento(Guid id, string title, string description, DateTime from, DateTime to, int version)
        {
            Title = title;
            Id = id;
            Title = title;
            From = from;
            To = to;
            Version = version;
            EventVersion = version;
            Description = description;
        }
    }
}
