using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDiary.CQRS.Reporting
{
    public class ReportDatabase : IReportDatabase
    {
        static readonly List<DiaryItemDto> items = new List<DiaryItemDto>();

        public void Add(DiaryItemDto item)
        {
            items.Add(item);
        }

        public void Delete(Guid id)
        {
            items.RemoveAll(x => x.Id == id);
        }

        public DiaryItemDto GetById(Guid id)
        {
            return items.Where(a => a.Id == id).FirstOrDefault();
        }

        public List<DiaryItemDto> GetItems()
        {
            return items;
        }
    }
}
