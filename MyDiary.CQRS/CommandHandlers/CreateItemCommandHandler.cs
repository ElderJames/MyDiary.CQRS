using MyDiary.CQRS.Commands;
using MyDiary.CQRS.Domain;
using MyDiary.CQRS.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.CQRS.CommandHandlers
{
    /// <summary>
    /// 文章创建命令处理器
    /// </summary>
    public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand>
    {
        private IRepository<DiaryItem> _repository;

        public CreateItemCommandHandler(IRepository<DiaryItem> repository)
        {
            _repository = repository;
        }

        public void Execute(CreateItemCommand command)
        {
            if (command == null)
                throw new Exception();
            if (_repository == null)
                throw new Exception();

            var aggregate = new DiaryItem(command.Id, command.Title, command.Description, command.From, command.To);
            //从-1开始，每执行一条更改命令会增加1，增加一条记录时会变为0
            aggregate.Version = -1;
            _repository.Save(aggregate, aggregate.Version);
        }
    }
}
