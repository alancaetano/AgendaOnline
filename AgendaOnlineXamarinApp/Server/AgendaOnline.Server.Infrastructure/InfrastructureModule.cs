using Autofac;
using AgendaOnline.Server.Application.Contracts;
using AgendaOnline.Server.Application.Sessions;
using AgendaOnline.Server.Domain.Seedwork;
using AgendaOnline.Server.Infrastructure.FileSystem;
using AgendaOnline.Server.Infrastructure.Logging;
using AgendaOnline.Server.Infrastructure.Persistence.EF;
using AgendaOnline.Server.Infrastructure.Protocol;
using AgendaOnline.Server.Infrastructure.Serialization;
using AgendaOnline.Server.Infrastructure.Transport;
using AgendaOnline.Utils.Logging;

namespace AgendaOnline.Server.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            LogFactory.Initialize(typeName => new ConsoleLogger(typeName));

            builder.RegisterType<InfrastructureInitializator>().As<IInfrastructureInitializator>().SingleInstance();
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>().SingleInstance();
            builder.RegisterType<AgendaOnlineSocketServer>().AsSelf().As<ISessionManager>().SingleInstance();
            builder.RegisterType<HardcodedSettings>().As<ISettings>().SingleInstance();
            builder.RegisterType<FileStorage>().As<IFileStorage>().SingleInstance();
            builder.RegisterType<ProtobufDtoSerializer>().As<IDtoSerializer>().SingleInstance();
            builder.RegisterType<CommandParser>().AsSelf().SingleInstance();
            builder.RegisterType<TransportPerformanceMeasurer>().AsSelf().SingleInstance();
            
            base.Load(builder);
        }
    }
}
