using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDiary.CQRS.Commands;
using MyDiary.CQRS.Storage;
using MyDiary.CQRS.Domain;

namespace MyDiary.CQRS.CommandHandlers
{
    public class DeleteItemCommandHandler : ICommandHandler<DeleteItemCommand>
    {
        private IRepository<DiaryItem> _repository;

        public DeleteItemCommandHandler(IRepository<DiaryItem> repository)
        {
            _repository = repository;
        }

        public void Execute(DeleteItemCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if (_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }
            var aggregate = _repository.GetById(command.Id);
            aggregate.Delete();
            _repository.Save(aggregate, aggregate.Version);
        }
    }
}
