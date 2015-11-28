using System.Reflection;
using Autofac;
using AgendaOnline.Server.Application.Agents;
using AgendaOnline.Server.Application.DataTransferObjects.Utils;
using AgendaOnline.Server.Application.Seedwork;
using AgendaOnline.Server.Application.Services.Helpers;
using Module = Autofac.Module;

namespace AgendaOnline.Server.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RequestsHandler>().AsSelf().SingleInstance();
            builder.RegisterType<AgentManager>().AsSelf().SingleInstance();
            builder.RegisterType<ProfileChangesNotificator>().AsSelf().SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(i => i.IsSubclassOf(typeof(AppService))).AsSelf().SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(i => i.IsSubclassOf(typeof(ScheduledAgentBase))).AsSelf().SingleInstance();

            base.Load(builder);
        }
    }
}
