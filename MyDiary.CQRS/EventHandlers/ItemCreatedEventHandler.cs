using MyDiary.CQRS.Events;
using MyDiary.CQRS.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.EventHandlers
{
    public class ItemCreatedEventHandler : IEventHandler<ItemCreatedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemCreatedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        
        public void Handle(ItemCreatedEvent e)
        {
            _reportDatabase.Add(new DiaryItemDto
            {
                Id = e.AggregateId,
                Description = e.Description,
                From = e.From,
                Title = e.Title,
                To=e.To,
                Version=e.Version
            });
        }
    }
}
