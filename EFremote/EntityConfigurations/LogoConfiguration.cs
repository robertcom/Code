using System.Data.Entity.ModelConfiguration;
using DAModel.Core.Domain;

namespace EFremote.EntityConfigurations
{
    public class LogoConfiguration:EntityTypeConfiguration<Logo>
    {
        public LogoConfiguration()
        {
            this.ToTable("Logos");
        }
    }
}
