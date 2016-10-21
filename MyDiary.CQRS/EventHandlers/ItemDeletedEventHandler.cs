using MyDiary.CQRS.Events;
using MyDiary.CQRS.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.EventHandlers
{
    public class ItemDeletedEventHandler : IEventHandler<ItemDeletedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemDeletedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }


        public void Handle(ItemDeletedEvent e)
        {
            _reportDatabase.Delete(e.AggregateId);
        }
    }
}
