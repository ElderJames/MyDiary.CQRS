using MyDiary.CQRS.Events;
using MyDiary.CQRS.Storage.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDiary.CQRS.Domain.Mementos;

namespace MyDiary.CQRS.Domain
{
    public class DiaryItem : AggregateRoot,IOriginator,
        IHandle<ItemCreatedEvent>,
        IHandle<ItemDeletedEvent>,
        IHandle<ItemChangedTitleEvent>,
        IHandle<ItemChangeDescriptionEvent>
    {

        public string Title { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string Description { get; set; }

        public DiaryItem() { }

        public DiaryItem(Guid id,string title,string description,DateTime from,DateTime to)
        {
            //请求一个创建DiaryItem事件
            ApplyChange(new ItemCreatedEvent(id, title, description, from, to));
        }

        public void Delete()
        {
            ApplyChange(new ItemDeletedEvent(Id));
        }

        public void ChangeTitle(string title)
        {
            ApplyChange(new ItemChangedTitleEvent(Id, title));
        }

        public void ChangeDescription(string description)
        {
            ApplyChange(new ItemChangeDescriptionEvent(Id, description));
        }

        /// <summary>
        /// 处理创建事件
        /// </summary>
        /// <param name="e"></param>
        public void Handle(ItemCreatedEvent e)
        {
            Title = e.Title;
            From = e.From;
            To = e.To;
            Id = e.AggregateId;
            Description = e.Description;
            Version = e.Version;
        }

        public void Handle(ItemDeletedEvent e)
        {
            //Id = e.AggregateId;
        }

        public void Handle(ItemChangedTitleEvent e)
        {
            Title = e.Title;
        }

        public BaseMemento GetMemento()
        {
            return new DiaryItemMemento(Id, Title, Description, From, To, Version);
        }

        //从快照恢复
        public void SetMemento(BaseMemento memento)
        {
            Title = ((DiaryItemMemento)memento).Title;
            To = ((DiaryItemMemento)memento).To;
            Version = memento.Version;
            From = ((DiaryItemMemento)memento).From;
            Description = ((DiaryItemMemento)memento).Description;
            Id = memento.Id;
        }

        public void Handle(ItemChangeDescriptionEvent e)
        {
            Description = e.Description;
        }
    }
}
