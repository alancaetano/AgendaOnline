using AgendaOnline.Server.Infrastructure.Protocol;

namespace AgendaOnline.Server.Infrastructure.Transport.Commands
{
    public class PingCommand : AgendaOnlineCommandBase
    {
        protected override bool AllowAnonymousAccess { get { return true; } }

        protected override bool AlwaysAvailable { get { return true; } }

        public override void ExecuteAstralCommand(AgendaOnlineSession session, byte[] data)
        {
        }

        protected override CommandNames CommandName
        {
            get { return CommandNames.Ping; }
        }
    }
}
