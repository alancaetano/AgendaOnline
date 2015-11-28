using AgendaOnline.Server.Infrastructure.Protocol;

namespace AgendaOnline.Server.Infrastructure.Transport.Commands
{
    public class ResponseCommand : AgendaOnlineCommandBase
    {
        public override void ExecuteAstralCommand(AgendaOnlineSession session, byte[] data)
        {
            session.AppendResponse(data);
        }

        protected override CommandNames CommandName
        {
            get { return CommandNames.Response; }
        }
    }
}
