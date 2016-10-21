using System;
using System.Collections.Generic;
using System.Linq;
using MyDiary.CQRS.EventHandlers;
using MyDiary.CQRS.Events;
using StructureMap;

namespace MyDiary.CQRS.Utils
{
    public class EventHandlerFactory : IEventHandlerFactory
    {
        public IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event
        {
            var handlers = GetHandlerTypes<T>();

            var lstHandlers = handlers.Select(handler =>
            (IEventHandler<T>)ObjectFactory.GetInstance(handler)).ToList();

            return lstHandlers;
        }

        public static IEnumerable<Type> GetHandlerTypes<T>() where T:Event
        {
            var handlers = typeof(IEventHandler<>).Assembly.GetExportedTypes()
                //泛型接口是IEventHandler<>
                .Where(x => x.GetInterfaces().Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEventHandler<>)))
                //泛型类型参数是T
                .Where(x => x.GetInterfaces().Any(a => a.IsGenericType && a.GetGenericArguments().Any(aa => aa == typeof(T))))
                
                .ToList();

            return handlers;
        }
    }
}
