using MyDiary.CQRS.Events;
using MyDiary.CQRS.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.EventHandlers
{
    public class ItemChangedTitleEventHandler : IEventHandler<ItemChangedTitleEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemChangedTitleEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public void Handle(ItemChangedTitleEvent e)
        {
            var item = _reportDatabase.GetById(e.AggregateId);
            item.Title = e.Title;
            item.Version = e.Version;
        }
    }
}
