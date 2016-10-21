using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDiary.CQRS.CommandHandlers;
using MyDiary.CQRS.Commands;
using StructureMap;

namespace MyDiary.CQRS.Utils
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        public ICommandHandler<T> GetHandler<T>() where T : Command
        {
            var handlers = GetHandlerTypes<T>().ToList();
            var cmdHandler = handlers.Select(handler =>
              (ICommandHandler<T>)ObjectFactory.GetInstance(handler)).FirstOrDefault();

            return cmdHandler;
        }

        private IEnumerable<Type> GetHandlerTypes<T>() where T : Command
        {
            //找出实现了ICommandHandler<T> 接口的类型
            var handlers = typeof(ICommandHandler<>).Assembly.GetExportedTypes()
                //找出实现了ICommandHandler接口的类型
                .Where(x => x.GetInterfaces().Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                //找出传入的类型参数是T的类型
                .Where(h => h.GetInterfaces().Any(ii => ii.GetGenericArguments().Any(aa => aa == typeof(T))))

                .ToList();

            return handlers;
        }
    }
}
