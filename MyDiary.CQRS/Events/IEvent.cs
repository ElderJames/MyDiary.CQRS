using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.Events
{
    interface IEvent
    {
        Guid Id { get; }
    }
}
