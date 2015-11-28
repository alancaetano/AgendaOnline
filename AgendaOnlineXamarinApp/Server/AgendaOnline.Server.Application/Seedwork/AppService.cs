using AgendaOnline.Server.Domain.Seedwork;
using AgendaOnline.Utils.Logging;

namespace AgendaOnline.Server.Application.Seedwork
{
    public abstract class AppService
    {
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }

        protected AppService(
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
        }

        protected ILogger Logger
        {
            get { return LogFactory.GetLogger(GetType().Name); }
        }
    }
}
