using System;
using AgendaOnline.Server.Application.Seedwork;
using AgendaOnline.Server.Domain.Entities;
using AgendaOnline.Server.Infrastructure.Protocol;
using AgendaOnline.Utils.Logging;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace AgendaOnline.Server.Infrastructure.Transport
{
    public abstract class AgendaOnlineCommandBase : CommandBase<AgendaOnlineSession, BinaryRequestInfo>
    {
        protected static readonly ILogger Logger = LogFactory.GetLogger<AgendaOnlineCommandBase>();

        protected static readonly IDtoSerializer DtoSerializer = ServiceLocator.Resolve<IDtoSerializer>();

        //protected static readonly CommandParser CommandParser = ServiceLocator.Resolve<CommandParser>();

        /// <summary>
        /// Command is allowed to executed by anonymouses
        /// </summary>
        protected virtual bool AllowAnonymousAccess { get { return false; } }

        /// <summary>
        /// True means the command available even if server is in updating state
        /// </summary>
        protected virtual bool AlwaysAvailable { get { return false; } }

        /// <summary>
        /// Command requires admin rights to be executed
        /// </summary>
        protected virtual bool RequiresAdminAccess { get { return false; } }

        /// <summary>
        /// Command handler
        /// </summary>
        public abstract void ExecuteAstralCommand(AgendaOnlineSession session, byte[] data);

        /// <summary>
        /// Command name
        /// </summary>
        protected abstract CommandNames CommandName { get; }

        public override string Name
        {
            get { return CommandName.ToString(); }
        }

        public sealed override void ExecuteCommand(AgendaOnlineSession session, BinaryRequestInfo requestInfo)
        {
            if (RequiresAdminAccess)
            {
                if (!session.IsAuthorized || session.User.Role != UserRole.Admin)
                {
                    //Logger.Warn("Sending access denided (ADMIN command) to {0}", Name);
                    //session.SendCommand(Name, Answers.AccessDenided);
                    return;
                }
            }
            else if (!AllowAnonymousAccess && !session.IsAuthorized)
            {
                //Logger.Warn("Sending access denided to {0}", Name);
                //session.SendCommand(Name, Answers.AccessDenided);
                return;
            }

            try
            {
                ExecuteAstralCommand(session, requestInfo.Body);
            }
            catch (Exception exc)
            {
                //Logger.ErrorException("Command '" + Commands.GetCommandFriendlyName(Name) + "' error!", exc);
            }
        }
    }
}
