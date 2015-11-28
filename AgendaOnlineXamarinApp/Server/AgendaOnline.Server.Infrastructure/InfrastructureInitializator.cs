using System.Data.Entity;
using System.Linq;
using AgendaOnline.Server.Application.Contracts;
using AgendaOnline.Server.Infrastructure.Persistence.EF;
using AgendaOnline.Server.Infrastructure.Transport;
using AgendaOnline.Utils.Logging;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace AgendaOnline.Server.Infrastructure
{
    public class InfrastructureInitializator : IInfrastructureInitializator
    {
        private readonly ISettings _settings;
        private readonly AgendaOnlineSocketServer _AgendaOnlineSocketServer;
        private static readonly ILogger Logger = LogFactory.GetLogger<InfrastructureInitializator>();

        public InfrastructureInitializator(ISettings settings, AgendaOnlineSocketServer AgendaOnlineSocketServer)
        {
            _settings = settings;
            _AgendaOnlineSocketServer = AgendaOnlineSocketServer;
        }
        
        public async void Init()
        {
            Logger.Info("Initing...");
            var config = new ServerConfig
                {
                    Port = _settings.ServerPort,
                    Ip = "Any", 
                    MaxConnectionNumber = 2000,
                    Mode = SocketMode.Tcp,
                    Name = "AgendaOnlineSocketServer",
                    DisableSessionSnapshot = true,
                    LogAllSocketException = false,
                    LogBasicSessionActivity = false,
                    LogCommand = false, 
                };

            var setuped = _AgendaOnlineSocketServer.Setup(config);
            var started = _AgendaOnlineSocketServer.Start();
            //Database.SetInitializer(new DropCreateDatabaseAlways<UnitOfWork>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UnitOfWork>());
            var user = new UnitOfWork().Users.FirstOrDefault();
            Logger.Info("Init completed {0}({1})", setuped, started);
        }
    }
}
