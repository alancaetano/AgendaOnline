using System;
using Autofac;
using AgendaOnline.Server.Application;
using AgendaOnline.Server.Application.Agents;
using AgendaOnline.Server.Application.Contracts;
using AgendaOnline.Server.Application.Seedwork;
using AgendaOnline.Server.Infrastructure;

namespace AgendaOnline.Server.ConsoleHost
{
    public static class Bootstrapper
    {
        private static bool _isRunning = false;

        public static IContainer Run()
        {
            if (_isRunning)
                throw new InvalidOperationException();
            _isRunning = true;

            var builder = new ContainerBuilder();
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();

            var container = builder.Build();
            ServiceLocator.Init(container);
            container.Resolve<IInfrastructureInitializator>().Init();
            container.Resolve<AgentManager>().Run();

            return container;
        }
    }
}
