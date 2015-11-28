﻿using System;
using AgendaOnline.Server.Application.Sessions;
using AgendaOnline.Server.Domain.Seedwork;
using AgendaOnline.Utils.Logging;

namespace AgendaOnline.Server.Application.Agents
{
    public abstract class ScheduledAgentBase
    {
        protected static readonly ILogger Logger = LogFactory.GetLogger<ScheduledAgentBase>();
        private static readonly TimeSpan DefaultTimeSpan = TimeSpan.FromMinutes(5);

        protected ScheduledAgentBase(IUnitOfWorkFactory unitOfWorkFactory, ISessionManager sessionManager)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
            SessionManager = sessionManager;
        }

        protected IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }

        protected ISessionManager SessionManager { get; private set; }

        public virtual TimeSpan TimeSpan
        {
            get { return DefaultTimeSpan; }
        }

        public virtual bool DontRunOnStart
        {
            get { return false; }
        }

        public void Execute()
        {
            try
            {
                OnExecute();
            }
            catch (Exception exc)
            {
                Logger.Exception(exc, "Agent [{0}] exception", GetType().Name);
            }
        }

        protected abstract void OnExecute();
    }
}
