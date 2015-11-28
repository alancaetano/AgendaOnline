using System.Data.Entity.ModelConfiguration;
using AgendaOnline.Server.Domain.Entities;

namespace AgendaOnline.Server.Infrastructure.Persistence.EF.Mappings
{
    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            HasMany(m => m.Friends)
                .WithMany()
                .Map(m =>
                     {
                         m.MapLeftKey("TargetId");
                         m.MapRightKey("TargetUserId");
                         m.ToTable("UserFriends");
                     });
        }
    }
}
