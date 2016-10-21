using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.Reporting
{
    public interface IReportDatabase
    {
        DiaryItemDto GetById(Guid id);

        List<DiaryItemDto> GetItems();

        void Add(DiaryItemDto item);

        void Delete(Guid id);
    }
}
