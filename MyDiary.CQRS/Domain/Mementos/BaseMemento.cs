using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.Domain.Mementos
{
    public class BaseMemento
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
    }
}
