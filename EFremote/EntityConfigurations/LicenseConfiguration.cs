
using System.Data.Entity.ModelConfiguration;
using DAModel.Core.Domain;

namespace EFremote.EntityConfigurations
{
    public class LicenseConfiguration: EntityTypeConfiguration<License>
    {
        public LicenseConfiguration()
        {
            this.HasRequired(l => l.User);

            Property(p => p.LicenseString)
                .HasMaxLength(255);
            Property(p => p.HKeyString)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
