using MyDiary.CQRS.Events;
using MyDiary.CQRS.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.EventHandlers
{
    public class ItemChangeDescriptionEventHandler : IEventHandler<ItemChangeDescriptionEvent>
    {
        private IReportDatabase _reportDatabase;

        public ItemChangeDescriptionEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public void Handle(ItemChangeDescriptionEvent e)
        {
            var item = _reportDatabase.GetById(e.AggregateId);
            item.Description = e.Description;
            item.Version = e.Version;
        }
    }
}
