using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaOnline.Server.Application.Seedwork;
using AgendaOnline.Server.Application.Sessions;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace AgendaOnline.Server.Infrastructure.Transport
{
    public class AgendaOnlineSocketServer : AppServer<AgendaOnlineSession, BinaryRequestInfo>, ISessionManager
    {
        private readonly TransportPerformanceMeasurer _performanceMeasurer = ServiceLocator.Resolve<TransportPerformanceMeasurer>();

        public AgendaOnlineSocketServer()
            : base(new DefaultReceiveFilterFactory<AgendaOnlineReceiveFilter, BinaryRequestInfo>())
        {
        }

        protected override void ExecuteCommand(AgendaOnlineSession session, BinaryRequestInfo requestInfo)
        {
            _performanceMeasurer.HandleIncomingBytes(requestInfo.Body.LongLength);
            base.ExecuteCommand(session, requestInfo);
        }

        public Dictionary<int, ISession> GetActiveSessions()
        {
            var sessions = base.GetSessions(s => s.IsAuthorized && s.IsOpen).ToDictionarySafe(i => i.User.Id, i => i as ISession);
            return sessions;
        }

        public void SendToEachChatSessions<T>(T data) where T : class
        {
            var allSessions = GetActiveSessions();
            Task.Run(() => Parallel.ForEach(allSessions, session => session.Value.Send(data)));
        }

        public void SendToEachChatSessionsExcept<T>(T data, int exceptionPlayerId) where T : class
        {
            var allSessions = GetActiveSessions();
            
            if (allSessions.ContainsKey(exceptionPlayerId))
                allSessions.Remove(exceptionPlayerId);

            Task.Run(() => Parallel.ForEach(allSessions, session => session.Value.Send(data)));
        }

        public ISession FindSessionByUserId(int playerId)
        {
            return base.GetSessions(s => s.IsAuthorized && s.User.Id == playerId && s.IsOpen).Last();
        }

        public void CloseSessionByUserId(int playerId)
        {
            var sessions = base.GetSessions(s => s.IsAuthorized && s.User.Id == playerId && s.IsOpen).ToList();
            foreach (var session in sessions)
            {
                try
                {
                    session.Close();
                }
                catch { }
            }
        }

        protected override void OnNewSessionConnected(AgendaOnlineSession session)
        {
            _performanceMeasurer.HandleNewConnection();
            session.Authorized += session_OnAuthorized;
            base.OnNewSessionConnected(session);
        }

        protected override void OnSessionClosed(AgendaOnlineSession session, CloseReason reason)
        {
            session.Authorized -= session_OnAuthorized;
            base.OnSessionClosed(session, reason);
            if (session.IsAuthorized)
            {
                AuthenticatedUserDisconnected(this, new SessionEventArgs(session));
            }
        }

        private void session_OnAuthorized(object sender, EventArgs e)
        {
            AuthenticatedUserConnected(this, new SessionEventArgs(sender as ISession));
        }

        public event EventHandler<SessionEventArgs> AuthenticatedUserConnected = delegate { };

        public event EventHandler<SessionEventArgs> AuthenticatedUserDisconnected = delegate { };
    }
}
