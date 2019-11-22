using System.Data.Entity.ModelConfiguration;
using DAModel.Core.Domain;

namespace EFremote.EntityConfigurations
{
    public class UserConfiguration: EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasRequired(u => u.Configuration)
                .WithRequiredPrincipal(c => c.User);

            Property(u => u.Login)
                .IsRequired()
                .HasMaxLength(80);
            Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(80);
        }
    }
}
