using MyDiary.CQRS.Messaging;
using MyDiary.CQRS.Reporting;
using MyDiary.CQRS.Storage;
using MyDiary.CQRS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace MyDiary.CQRS.Configuration
{
    public class ServiceLocator
    {
        private static ICommandBus _commandBus;
        private static IReportDatabase _reportDatabase;
        private static bool _isInitialized;
        private static readonly object _lockThis = new object();

        static ServiceLocator()
        {
            if (!_isInitialized)
            {
                lock(_lockThis)
                {
                    ContainerBootstrapper.BootstrapAutofac();
                    _commandBus = ObjectFactory.GetInstance<ICommandBus>();
                    _reportDatabase = ObjectFactory.GetInstance<IReportDatabase>();
                    _isInitialized = true;
                }
            }
        }

        public static ICommandBus CommanBus
        {
            get { return _commandBus; }
        }

        public static IReportDatabase ReportDatabase
        {
            get { return _reportDatabase; }
        }

        public class ContainerBootstrapper
        {
            public static void BootstrapAutofac()
            {
                ObjectFactory.Initialize(x =>
                {
                    x.For(typeof(IRepository<>)).Singleton().Use(typeof(Repository<>));
                    x.For<IEventStorage>().Singleton().Use<InMemoryEventStorage>();
                    x.For<IEventBus>().Use<EventBus>();
                    x.For<ICommandHandlerFactory>().Use<CommandHandlerFactory>();
                    x.For<IEventHandlerFactory>().Use<EventHandlerFactory>();
                    x.For<ICommandBus>().Use<CommandBus>();
                    x.For<IEventBus>().Use<EventBus>();
                    x.For<IReportDatabase>().Use<ReportDatabase>();
                });
            }
        }
    }
}
