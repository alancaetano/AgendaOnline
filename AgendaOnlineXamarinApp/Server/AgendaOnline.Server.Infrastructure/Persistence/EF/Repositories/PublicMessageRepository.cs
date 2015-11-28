using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AgendaOnline.Server.Domain.Entities;
using AgendaOnline.Server.Domain.Repositories;
using AgendaOnline.Server.Domain.Seedwork.Specifications;

namespace AgendaOnline.Server.Infrastructure.Persistence.EF.Repositories
{
    public class PublicMessageRepository : IPublicMessageRepository
    {
        private readonly UnitOfWork _uow;

        public PublicMessageRepository(UnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<PublicMessage> TakeLast(int count)
        {
            return _uow.PublicMessages
                            .Include(i => i.Author)
                            .OrderByDescending(i => i.Timestamp)
                            .Take(count)
                            .ToList();
        }

        public int Count(Specification<PublicMessage> spec)
        {
            return _uow.PublicMessages.Count(spec.SatisfiedBy());
        }

        public void Add(PublicMessage msg)
        {
            _uow.PublicMessages.Add(msg);
        }
    }
}