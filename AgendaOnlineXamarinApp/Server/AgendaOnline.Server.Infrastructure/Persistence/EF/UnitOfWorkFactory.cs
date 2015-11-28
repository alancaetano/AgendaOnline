using AgendaOnline.Server.Application.Contracts;
using AgendaOnline.Server.Domain.Seedwork;

namespace AgendaOnline.Server.Infrastructure.Persistence.EF
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ISettings _settings;

        public UnitOfWorkFactory(ISettings settings)
        {
            _settings = settings;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork();
        }
    }
}