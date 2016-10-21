using MyDiary.CQRS.Domain.Mementos;

namespace MyDiary.CQRS.Storage.Memento
{
    public interface IOriginator
    {
        //获取一个快照
        BaseMemento GetMemento();
        //从快照恢复状态
        void SetMemento(BaseMemento memento);
    }
}
