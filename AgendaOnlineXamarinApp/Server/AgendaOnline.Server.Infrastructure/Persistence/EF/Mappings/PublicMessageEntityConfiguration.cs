using System.Data.Entity.ModelConfiguration;
using AgendaOnline.Server.Domain.Entities;

namespace AgendaOnline.Server.Infrastructure.Persistence.EF.Mappings
{
    public class PublicMessageEntityConfiguration : EntityTypeConfiguration<PublicMessage>
    {
        public PublicMessageEntityConfiguration()
        {
        }
    }
}