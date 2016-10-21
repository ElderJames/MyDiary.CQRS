using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.Commands
{
    public class ChangeItemCommand:Command
    {
        public string Title { get; internal set; }
        public string Description { get; internal set; }
        public DateTime From { get; internal set; }
        public DateTime To { get; internal set; }

        public ChangeItemCommand(Guid aggregateId, string title, string description, int version, DateTime from, DateTime to)
            : base(aggregateId, version)
        {
            Title = title;
            Description = description;
            From = from;
            To = to;
        }
    }
}
