using MyDiary.CQRS.Commands;
using System;
using MyDiary.CQRS.Storage;
using MyDiary.CQRS.Domain;

namespace MyDiary.CQRS.CommandHandlers
{
    public class ChangeItemCommandHandler : ICommandHandler<ChangeItemCommand>
    {
        private readonly IRepository<DiaryItem> _repository;

        public ChangeItemCommandHandler(IRepository<DiaryItem> repository)
        {
            _repository = repository;
        }

        public void Execute(ChangeItemCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if (_repository == null)
            {
                throw new NullReferenceException("repository");
            }
            var item = _repository.GetById(command.Id);

            if (item.Title != command.Title)
                item.ChangeTitle(command.Title);

            if (item.Description != command.Description)
                item.ChangeDescription(command.Description);


            _repository.Save(item, command.Version);
        }
    }
}
