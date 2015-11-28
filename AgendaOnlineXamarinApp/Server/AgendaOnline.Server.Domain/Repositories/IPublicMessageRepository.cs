using System.Collections.Generic;
using AgendaOnline.Server.Domain.Entities;
using AgendaOnline.Server.Domain.Seedwork.Specifications;

namespace AgendaOnline.Server.Domain.Repositories
{
    public interface IPublicMessageRepository : IRepository
    {
        /// <summary>
        /// Takes specified amout of last inserted messages
        /// </summary>
        IEnumerable<PublicMessage> TakeLast(int count);

        /// <summary>
        /// Counts all messages matching specified specification
        /// </summary>
        int Count(Specification<PublicMessage> spec);

        /// <summary>
        /// Adds message to repo
        /// </summary>
        void Add(PublicMessage msg);
    }
}
