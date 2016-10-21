using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.Reporting
{
    public class DiaryItemDto
    {
        public Guid Id { get; set; }

        public int Version { get; set; }

        public string Title { get; set; }

        public DateTime From { get; set; } = DateTime.Now;

        public DateTime To { get; set; } = DateTime.Now;

        public string Description { get; set; }
    }
}
